# 김포 녹취 통합DB 테스트 환경 프로비저닝 스크립트입니다.
# sqlcmd로 DB/테이블/뷰를 순서대로 생성합니다.

param(
    [string]$ServerInstance = "",
    [switch]$UseWindowsAuth,
    [string]$SqlUser = "",
    [string]$SqlPassword = "",
    [string]$ConnectionString = ""
)

$ErrorActionPreference = "Stop"
$ScriptRoot = Split-Path -Parent $MyInvocation.MyCommand.Path

function Get-ConnectionSettings
{
    param(
        [string]$ServerInstance,
        [bool]$UseWindowsAuth,
        [string]$SqlUser,
        [string]$SqlPassword,
        [string]$ConnectionString
    )

    if (-not [string]::IsNullOrWhiteSpace($ConnectionString))
    {
        return Parse-ConnectionString -ConnectionString $ConnectionString
    }

    if (-not [string]::IsNullOrWhiteSpace($env:MSSQL_CONNECTION_STRING))
    {
        return Parse-ConnectionString -ConnectionString $env:MSSQL_CONNECTION_STRING
    }

    if (-not [string]::IsNullOrWhiteSpace($ServerInstance))
    {
        return @{
            ServerInstance = $ServerInstance
            UseWindowsAuth = $UseWindowsAuth.IsPresent
            SqlUser = $SqlUser
            SqlPassword = $SqlPassword
        }
    }

    return @{
        ServerInstance = "DESKTOP-6GTHHB1\DEV2022"
        UseWindowsAuth = $true
        SqlUser = $SqlUser
        SqlPassword = $SqlPassword
    }
}

function Parse-ConnectionString
{
    param(
        [string]$ConnectionString
    )

    $settings = @{
        ServerInstance = ""
        UseWindowsAuth = $false
        SqlUser = ""
        SqlPassword = ""
    }

    foreach ($part in $ConnectionString.Split(';'))
    {
        if ([string]::IsNullOrWhiteSpace($part))
        {
            continue
        }

        $pair = $part.Split('=', 2)
        if ($pair.Count -ne 2)
        {
            continue
        }

        $key = $pair[0].Trim()
        $value = $pair[1].Trim()

        switch -Regex ($key)
        {
            '^(Server|Data Source)$' { $settings.ServerInstance = $value }
            '^(User Id|UID)$' { $settings.SqlUser = $value; $settings.UseWindowsAuth = $false }
            '^(Password|PWD)$' { $settings.SqlPassword = $value }
        }
    }

    if ([string]::IsNullOrWhiteSpace($settings.ServerInstance))
    {
        throw "Connection string must include Server."
    }

    if (-not $settings.UseWindowsAuth -and [string]::IsNullOrWhiteSpace($settings.SqlUser))
    {
        throw "Connection string must include User Id or use Windows authentication."
    }

    return $settings
}

function Invoke-SqlScript
{
    param(
        [hashtable]$ConnectionSettings,
        [string]$ScriptFile,
        [string]$StepName
    )

    Write-Host ""
    Write-Host "=== $StepName ===" -ForegroundColor Cyan
    Write-Host "Running: $ScriptFile"

    $sqlcmdArgs = @(
        "-S", $ConnectionSettings.ServerInstance,
        "-b",
        "-C",
        "-i", $ScriptFile
    )

    if ($ConnectionSettings.UseWindowsAuth)
    {
        $sqlcmdArgs += "-E"
    }
    else
    {
        if ([string]::IsNullOrWhiteSpace($ConnectionSettings.SqlUser) -or [string]::IsNullOrWhiteSpace($ConnectionSettings.SqlPassword))
        {
            throw "SQL authentication requires User Id and Password."
        }

        $sqlcmdArgs += @("-U", $ConnectionSettings.SqlUser, "-P", $ConnectionSettings.SqlPassword)
    }

    & sqlcmd @sqlcmdArgs

    if ($LASTEXITCODE -ne 0)
    {
        throw "sqlcmd failed for $ScriptFile (exit code: $LASTEXITCODE)"
    }
}

$sqlcmdPath = Get-Command sqlcmd -ErrorAction SilentlyContinue
if (-not $sqlcmdPath)
{
    throw "sqlcmd not found. Install SQL Server command-line tools or use Developer Command Prompt."
}

$connectionSettings = Get-ConnectionSettings `
    -ServerInstance $ServerInstance `
    -UseWindowsAuth:$UseWindowsAuth `
    -SqlUser $SqlUser `
    -SqlPassword $SqlPassword `
    -ConnectionString $ConnectionString

Write-Host "Gimpo Integrated DB Test Environment Provisioning" -ForegroundColor Green
Write-Host "Server: $($connectionSettings.ServerInstance)"

if ($connectionSettings.UseWindowsAuth)
{
    Write-Host "Auth: Windows"
}
else
{
    Write-Host "Auth: SQL ($($connectionSettings.SqlUser))"
}

Invoke-SqlScript -ConnectionSettings $connectionSettings -ScriptFile (Join-Path $ScriptRoot "01-create-databases.sql") -StepName "Step 1: Create Databases"
Invoke-SqlScript -ConnectionSettings $connectionSettings -ScriptFile (Join-Path $ScriptRoot "03-create-year-tables.sql") -StepName "Step 2: Create Year Tables"
Invoke-SqlScript -ConnectionSettings $connectionSettings -ScriptFile (Join-Path $ScriptRoot "04-create-central-views.sql") -StepName "Step 3: Create CENTRAL Views"
Invoke-SqlScript -ConnectionSettings $connectionSettings -ScriptFile (Join-Path $ScriptRoot "05-create-media-central.sql") -StepName "Step 4: Create Media CENTRAL Table"

Write-Host ""
Write-Host "Provisioning completed successfully." -ForegroundColor Green
