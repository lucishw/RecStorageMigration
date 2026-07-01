/*
    김포 녹취 통합DB 테스트 환경 - 연도별 CENTRAL_YYYY 테이블 생성 스크립트입니다.
    6개 업무 DB x 2024~2026 = 18개 테이블을 생성합니다.
*/

SET NOCOUNT ON;

DECLARE @CentralColumns nvarchar(max) = N'
    [FILENAME]        [varchar](22)    NOT NULL,
    [SERVERNAME]      [varchar](20)    NOT NULL,
    [CHANNEL]         [int]            NULL,
    [CHANNELNAME]     [varchar](40)    NULL,
    [DATE]            [datetime]       NULL,
    [TIME]            [datetime]       NULL,
    [DURATION]        [datetime]       NULL,
    [REFERENCE]       [varchar](20)    NULL,
    [LOCATION]        [varchar](24)    NULL,
    [ARCHIVEFLAG]     [tinyint]        NULL,
    [DIALEDNUMBER]    [varchar](40)    NULL,
    [AGENT]           [varchar](20)    NULL,
    [AGENTNAME]       [varchar](40)    NULL,
    [MEMO]            [tinyint]        NULL,
    [RECNUM]          [money]          NULL,
    [CALLERNAME]      [varchar](40)    NULL,
    [CALLERNUMBER]    [varchar](40)    NULL,
    [CALLDIRECTION]   [char](1)        NULL,
    [CALLINDEX]       [varchar](20)    NULL,
    [SCHEDULE]        [char](1)        NULL,
    [GROUPID]         [varchar](15)    NULL,
    [GROUPNAME]       [varchar](30)    NULL,
    [STATION]         [varchar](10)    NULL,
    [TRUNKNUMBER]     [varchar](15)    NULL,
    [ROUTE]           [varchar](15)    NULL,
    [SPARE01]         [varchar](20)    NULL,
    [EVALUATE]        [varchar](4)     NULL,
    [RECTYPE]         [int]            NULL,
    [STARTED]         [datetime]       NULL,
    [ENDED]           [datetime]       NULL,
    [TERMREASON]      [varchar](4)     NULL,
    [M_INDEX]         [varchar](50)    NULL,
    [SEGMENT]         [tinyint]        NULL,
    [MINRECORDTIME]   [int]            NULL,
    [UPLOADSTATUS]    [int]            NULL,
    [MEMBER]          [int]            NULL,
    [MEMBERNAME]      [int]            NULL,
    [TRUNKGROUP]      [varchar](20)    NULL,
    [BUFFER01]        [varchar](50)    NULL,
    [BUFFER02]        [varchar](50)    NULL,
    [BUFFER03]        [varchar](50)    NULL,
    [BUFFER04]        [varchar](50)    NULL,
    [BUFFER05]        [varchar](50)    NULL,
    [BUFFER06]        [varchar](50)    NULL,
    [BUFFER07]        [varchar](50)    NULL,
    [BUFFER08]        [varchar](50)    NULL,
    [BUFFER09]        [varchar](50)    NULL,
    [BUFFER10]        [varchar](50)    NULL,
    [BUFFER11]        [varchar](50)    NULL,
    [BUFFER12]        [varchar](50)    NULL,
    [BUFFER13]        [varchar](50)    NULL,
    [BUFFER14]        [varchar](50)    NULL,
    [BUFFER15]        [varchar](50)    NULL,
    [BUFFER16]        [varchar](50)    NULL,
    [BUFFER17]        [varchar](50)    NULL,
    [BUFFER18]        [varchar](50)    NULL,
    [BUFFER19]        [varchar](1024)  NULL,
    [BUFFER20]        [varchar](1024)  NULL,
    [READSTATUS]      [smallint]       NULL
';

DECLARE @DatabaseNames TABLE
(
    DbName sysname NOT NULL
);

INSERT INTO @DatabaseNames (DbName)
VALUES
    (N'LucisDB_CC'),
    (N'LucisDB_Car'),
    (N'LucisDB_IPT'),
    (N'LucisDB_BS'),
    (N'LucisDB_JH'),
    (N'LucisDB_Mark');

DECLARE @Years TABLE
(
    YearValue int NOT NULL
);

INSERT INTO @Years (YearValue)
VALUES (2024), (2025), (2026);

DECLARE @DbName sysname;
DECLARE @YearValue int;
DECLARE @TableName sysname;
DECLARE @Sql nvarchar(max);

DECLARE db_cursor CURSOR LOCAL FAST_FORWARD FOR
    SELECT DbName FROM @DatabaseNames;

OPEN db_cursor;
FETCH NEXT FROM db_cursor INTO @DbName;

WHILE @@FETCH_STATUS = 0
BEGIN
    DECLARE year_cursor CURSOR LOCAL FAST_FORWARD FOR
        SELECT YearValue FROM @Years;

    OPEN year_cursor;
    FETCH NEXT FROM year_cursor INTO @YearValue;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        SET @TableName = N'CENTRAL_' + CAST(@YearValue AS nvarchar(4));
        SET @Sql = N'
USE [' + @DbName + N'];
IF OBJECT_ID(N''dbo.' + @TableName + N''', N''U'') IS NULL
BEGIN
    CREATE TABLE dbo.' + QUOTENAME(@TableName) + N' (' + @CentralColumns + N'
    );
    PRINT N''Created table: ' + @DbName + N'.dbo.' + @TableName + N''';
END
ELSE
    PRINT N''Table already exists: ' + @DbName + N'.dbo.' + @TableName + N''';';

        EXEC sys.sp_executesql @Sql;

        FETCH NEXT FROM year_cursor INTO @YearValue;
    END

    CLOSE year_cursor;
    DEALLOCATE year_cursor;

    FETCH NEXT FROM db_cursor INTO @DbName;
END

CLOSE db_cursor;
DEALLOCATE db_cursor;
GO
