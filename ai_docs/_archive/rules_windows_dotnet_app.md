# rules.md - Windows Forms & Service 프로그램 개발 공통 규칙

## 1. 문서 목적

본 문서는 Cursor AI 등 AI IDE를 이용하여 Windows Forms, Windows Service, Worker, Agent, Batch 형태의 Windows 프로그램을 개발할 때 공통으로 준수해야 할 개발 규칙, 문서 작성 규칙, 함수명 규칙, 로그 규칙, 예외 처리 규칙, 테스트 및 배포 규칙을 정의한다.

본 규칙은 개발자가 AI IDE를 사용할 때 작업 범위를 통제하고, 개발 결과의 품질과 추적성을 확보하기 위한 기준 문서로 사용한다.

---

## 2. 적용 대상

본 규칙은 다음 유형의 프로그램에 적용한다.

```text
- Windows Forms 기반 운영자 프로그램
- Windows Service 기반 백그라운드 프로그램
- UI + Service 분리 구조 프로그램
- Worker / Agent 형태의 상주 프로그램
- Batch 형태의 주기 실행 프로그램
- 파일 분석 / 파일 변환 / 파일 수집 프로그램
- 외부 실행파일(ffmpeg, ffprobe, sftp, openssl 등)을 호출하는 프로그램
- 로그 수집, 음원 분석, 파일 전송, 장비 연동 프로그램
```

---

## 3. 프로그램 유형별 기본 원칙

| 유형 | 주요 목적 | 개발 기준 |
|---|---|---|
| Windows Forms | 운영자 조작, 상태 확인, 설정 관리 | UI 응답성, 예외 메시지, 시각화, 버튼 중복 방지 |
| Windows Service | 백그라운드 상시 실행, 자동 처리 | 자동 시작, 복구, 로그, 종료 안정성, 권한 관리 |
| Worker / Agent | 사용자 세션 또는 장비 단위 작업 수행 | 장시간 실행 안정성, 중지 처리, 상태 보고 |
| Batch | 일정 주기 작업 처리 | 재실행 가능성, 중복 실행 방지, 결과 로그 |
| UI + Service | 화면 제어와 백그라운드 작업 분리 | IPC/API/파일 기반 상태 연계, 권한 분리 |

---

## 4. 권장 디렉토리 구조

모든 AI IDE 적용 프로젝트는 아래 구조를 기본으로 한다.

```text
ProjectRoot
├─ src
│  ├─ ProgramName.App
│  │  └─ Windows Forms 또는 실행 프로그램
│  ├─ ProgramName.Service
│  │  └─ Windows Service 프로젝트
│  ├─ ProgramName.Worker
│  │  └─ Worker 또는 Agent 프로젝트
│  ├─ ProgramName.Core
│  │  └─ 공통 비즈니스 로직
│  ├─ ProgramName.Infrastructure
│  │  └─ 파일, 로그, 외부 프로세스, 네트워크, DB 처리
│  └─ ProgramName.Tests
│     └─ 테스트 프로젝트
│
├─ config
│  └─ appsettings.json 또는 프로그램명.json
│
├─ logs
│  └─ 프로그램 실행 로그
│
├─ tools
│  └─ 외부 실행 파일 배치 위치
│
├─ docs
│  └─ 화면, 설치 절차, 운영 참고자료
│
├─ scripts
│  ├─ install-service.ps1
│  ├─ uninstall-service.ps1
│  ├─ start-service.ps1
│  └─ stop-service.ps1
│
├─ release
│  └─ 배포 산출물
│
├─ _ai_docs
│  ├─ 00_rules
│  │  └─ rules.md
│  ├─ 01_overview
│  │  └─ 개발_개요.md
│  ├─ 02_tasks
│  │  └─ TASK-xxx_작업명.md
│  ├─ 03_results
│  │  └─ RESULT-xxx_작업명.md
│  ├─ 04_review
│  │  └─ REVIEW-xxx_검토명.md
│  └─ 05_release
│     └─ RELEASE-xxx_배포명.md
│
└─ README.md
```

### 4.1 폴더별 역할

| 폴더 | 역할 |
|---|---|
| `src` | 실제 프로그램 소스 |
| `config` | 설정 파일 |
| `logs` | 프로그램 실행 로그 |
| `tools` | ffmpeg, ffprobe, sftp 등 외부 실행 도구 |
| `docs` | 운영 문서, 화면 캡처, 참고자료 |
| `scripts` | 서비스 설치/삭제/시작/중지 스크립트 |
| `release` | Release 빌드 결과 및 배포 파일 |
| `_ai_docs/00_rules` | AI IDE 및 개발 공통 규칙 |
| `_ai_docs/01_overview` | 개발 개요, 요구사항, 구조 설명 |
| `_ai_docs/02_tasks` | 기능/화면 단위 개발 지시서 |
| `_ai_docs/03_results` | Task별 개발 결과 기록 |
| `_ai_docs/04_review` | 코드 검토 및 배포 전 검토 기록 |
| `_ai_docs/05_release` | 배포 이력 및 버전별 반영 내역 |

---

## 5. AI IDE 사용 기본 원칙

1. Cursor AI는 개발 보조 도구이며, 최종 책임은 개발자에게 있다.
2. Cursor AI는 현재 Task 문서에 명시된 범위 내에서만 작업한다.
3. Task 범위를 벗어난 리팩토링, UI 재구성, 공통 모듈 변경, 설정 변경은 금지한다.
4. 불가피하게 범위 외 수정이 필요하면 작업을 중단하고 개발자에게 확인을 요청한다.
5. AI IDE가 수정한 코드는 개발자가 `git diff`, 빌드, 실행 테스트를 통해 확인한 후 반영한다.
6. 빌드 실패 상태로 작업을 종료하지 않는다.
7. 빌드가 불가능한 환경이면 그 사유와 미검증 범위를 RESULT 문서에 명시한다.
8. 운영 코드 반영 전에는 REVIEW 문서 기준으로 코드 검토 및 배포 전 검토를 수행한다.

---

## 6. AI IDE 작업 전 절차

작업 전 개발자는 다음을 확인한다.

```powershell
git status
```

Cursor AI에는 다음 순서로 지시한다.

```text
1. _ai_docs/00_rules/rules.md를 먼저 읽어라.
2. _ai_docs/01_overview/개발_개요.md를 읽어라.
3. 현재 작업 대상 TASK 문서를 읽어라.
4. Task 범위 외 수정은 하지 마라.
5. 완료 후 RESULT 문서를 작성하거나 갱신하라.
```

---

## 7. AI IDE 작업 후 절차

작업 후 개발자는 다음을 확인한다.

```powershell
git status
git diff
dotnet build
```

확인 항목은 다음과 같다.

| 항목 | 확인 내용 |
|---|---|
| 수정 파일 | Task 범위 내 파일만 수정되었는가 |
| 빌드 | 오류 없이 빌드되는가 |
| UI | 주요 화면, 버튼, 상태 표시가 정상인가 |
| Service | 설치, 시작, 중지, 재시작이 정상인가 |
| 외부 도구 | ffmpeg, ffprobe, sftp 등 경로 탐색이 정상인가 |
| 예외 처리 | 파일 없음, 권한 없음, 도구 없음, 분석 실패 등이 처리되는가 |
| 로그 | 로그 파일명, 라인 포맷, 한글 설명이 규칙에 맞는가 |
| 결과 문서 | RESULT 문서에 수정 내역과 테스트 결과가 기록되었는가 |

---

## 8. Task / Result / Review / Release 문서 규칙

### 8.1 Task 파일

Task 문서는 기능 또는 화면 단위로 작성한다.

```text
TASK-001_프로젝트_초기구조_UI.md
TASK-002_FFmpeg_FFprobe_분석서비스.md
TASK-003_재생가능성_검증.md
TASK-004_Service_설치스크립트.md
```

Task 문서에는 다음 항목을 포함한다.

```text
- Task 번호
- 작업 제목
- 작업 목적
- 수정 대상 파일
- 구현 요구사항
- 변경 금지 사항
- 로그 요구사항
- 예외 처리 요구사항
- 테스트 방법
- 완료 기준
```

### 8.2 Result 파일

Result 문서는 Task 번호와 1:1로 맞춘다.

```text
RESULT-001_프로젝트_초기구조_UI.md
RESULT-002_FFmpeg_FFprobe_분석서비스.md
RESULT-003_재생가능성_검증.md
RESULT-004_Service_설치스크립트.md
```

Result 문서에는 다음 항목을 포함한다.

```text
- 수행 Task
- 작업 일자
- 작업자
- Cursor AI 사용 여부
- 수정 파일 목록
- 주요 변경 내용
- 빌드 결과
- 테스트 결과
- 미완료 항목
- 추가 확인 필요 사항
- 배포 시 주의사항
```

### 8.3 Review 파일

Review 문서는 코드 검토와 배포 전 검토로 구분한다.

```text
REVIEW-001_코드검토.md
REVIEW-002_배포전검토.md
```

Review 문서에는 다음 항목을 포함한다.

```text
- 검토 대상 Task / Result
- 검토 대상 파일
- 코드 검토 결과
- 빌드 확인 결과
- 기능 확인 결과
- 예외 상황 확인 결과
- 보완 필요 사항
- 배포 가능 여부
```

### 8.4 Release 파일

Release 문서는 배포 단위마다 신규 생성한다.

```text
RELEASE-001_20260625.md
RELEASE-002_20260702.md
```

Release 문서에는 다음 항목을 포함한다.

```text
- 배포일
- 프로그램명
- 버전
- 배포 구분
- 포함 Task
- 포함 Result
- 변경 내용
- 배포 파일
- 배포 경로
- 실행 방법
- 검증 결과
- 알려진 제약사항
- 롤백 방법
```

---

## 9. 프로젝트 분리 규칙

Windows Forms와 Windows Service가 함께 존재하는 경우 UI와 서비스 로직을 분리한다.

### 9.1 권장 구조

```text
ProgramName.App            → Windows Forms UI
ProgramName.Service        → Windows Service
ProgramName.Core           → 공통 업무 로직
ProgramName.Infrastructure → 로그, 파일, 외부 프로세스, 설정, 통신
```

### 9.2 분리 원칙

1. Windows Forms 프로젝트에 핵심 업무 로직을 몰아넣지 않는다.
2. Windows Service 프로젝트에 UI 관련 코드를 포함하지 않는다.
3. 공통 로직은 `Core` 또는 `Infrastructure`로 분리한다.
4. UI는 서비스 상태 조회, 설정 변경, 실행 명령 전달 역할만 수행한다.
5. Service는 무인 실행을 전제로 하며 `MessageBox`, `Form`, `Dialog`를 사용하지 않는다.
6. 공통 모듈 수정은 별도 Task로 분리한다.

---

## 10. 명명 규칙

### 10.1 기본 명명 원칙

소스 내 클래스명, 함수명, 변수명은 목적과 처리 대상을 직관적으로 알 수 있도록 작성한다.

기본 원칙은 다음과 같다.

```text
동사 + 대상 + 처리내용
```

예:

```csharp
LoadApplicationConfig()
ValidateInputFile()
AnalyzeAudioFileAsync()
RunFfprobeAsync()
CheckFfmpegPlayableAsync()
WriteLogLine()
StartServiceWorkerAsync()
StopServiceWorkerAsync()
```

---

### 10.2 C# 표기 규칙

| 대상 | 규칙 | 예 |
|---|---|---|
| Class | PascalCase | `AudioAnalyzerService` |
| Method | PascalCase | `AnalyzeAudioFileAsync()` |
| Property | PascalCase | `InputFilePath` |
| Public Field | PascalCase | 사용 지양 |
| Private Field | `_camelCase` | `_logger`, `_config` |
| Local Variable | camelCase | `filePath`, `result` |
| Constant | PascalCase | `DefaultTimeoutSeconds` |
| Enum | PascalCase | `ServiceStatusType` |
| Interface | I + PascalCase | `IAudioAnalyzerService` |

나쁜 예:

```csharp
analyze_audio()
doit()
proc1()
btn1()
check()
```

좋은 예:

```csharp
AnalyzeAudioFile()
LoadApplicationConfig()
CheckServiceStatus()
```

---

## 11. 함수명 작성 규칙

### 11.1 함수명 기본 규칙

함수명은 함수의 목적과 처리 대상을 직관적으로 알 수 있도록 작성한다.

기본 형식은 다음과 같다.

```text
동사 + 대상 + 처리내용
```

예:

```csharp
LoadApplicationConfig()
ValidateInputFile()
AnalyzeAudioFileAsync()
RunFfprobeAsync()
CheckFfmpegPlayableAsync()
WriteLogLine()
StartServiceWorkerAsync()
StopServiceWorkerAsync()
```

---

### 11.2 Boolean 반환 함수명

Boolean 값을 반환하는 함수는 `Is`, `Has`, `Can`, `Should` 중 하나로 시작한다.

| 접두어 | 사용 목적 | 예 |
|---|---|---|
| `Is` | 상태 여부 | `IsServiceRunning()` |
| `Has` | 보유 여부 | `HasWritePermission()` |
| `Can` | 가능 여부 | `CanAccessNetworkPath()` |
| `Should` | 조건 판단 | `ShouldRetryProcess()` |

예:

```csharp
IsFileExists()
HasWritePermission()
CanAccessNetworkPath()
ShouldRetryProcess()
IsServiceRunning()
IsFfmpegAvailable()
```

나쁜 예:

```csharp
CheckFile()
FileStatus()
Service()
Permission()
```

---

### 11.3 비동기 함수명

`Task`, `Task<T>`를 반환하는 비동기 함수는 반드시 `Async` 접미사를 사용한다.

```csharp
AnalyzeAudioFileAsync()
RunFfprobeAsync()
SaveResultAsync()
StartWorkerAsync()
StopWorkerAsync()
UploadFileAsync()
```

나쁜 예:

```csharp
AnalyzeAudioFile()
RunFfprobe()
SaveResult()
```

단, Windows Forms 이벤트 핸들러의 `async void`는 이벤트 함수명 규칙을 따른다.

```csharp
private async void btnAnalyze_Click(object sender, EventArgs e)
{
    await AnalyzeSelectedFileAsync();
}
```

---

### 11.4 동사 기준 함수명 권장 목록

#### 조회 / 읽기 계열

| 동사 | 사용 목적 | 예 |
|---|---|---|
| `Get` | 단순 값 반환 | `GetLogFilePath()` |
| `Load` | 파일/설정/데이터 로딩 | `LoadApplicationConfig()` |
| `Read` | 파일, Stream, 데이터 읽기 | `ReadJsonFile()` |
| `Find` | 조건에 맞는 항목 탐색 | `FindFfmpegPath()` |
| `Search` | 여러 항목 검색 | `SearchAudioFiles()` |

#### 저장 / 쓰기 계열

| 동사 | 사용 목적 | 예 |
|---|---|---|
| `Save` | 설정/결과 저장 | `SaveApplicationConfig()` |
| `Write` | 로그/파일 쓰기 | `WriteLogLine()` |
| `Append` | 기존 내용에 추가 | `AppendLogMessage()` |
| `Export` | 외부 파일로 내보내기 | `ExportResultToCsv()` |

#### 검증 / 확인 계열

| 동사 | 사용 목적 | 예 |
|---|---|---|
| `Validate` | 입력값 검증, 실패 시 오류 또는 false 반환 | `ValidateInputFile()` |
| `Check` | 상태 확인 | `CheckServiceStatus()` |
| `Verify` | 정확성/무결성 검증 | `VerifyOutputFile()` |
| `Ensure` | 없으면 생성 또는 보정 | `EnsureLogDirectory()` |

#### 실행 / 처리 계열

| 동사 | 사용 목적 | 예 |
|---|---|---|
| `Run` | 외부 프로세스 또는 명령 실행 | `RunFfprobeAsync()` |
| `Execute` | 내부 작업 실행 | `ExecuteBatchJobAsync()` |
| `Process` | 데이터/파일 처리 | `ProcessAudioFileAsync()` |
| `Handle` | 이벤트/예외/상태 처리 | `HandleProcessError()` |
| `Start` | 작업 시작 | `StartWorkerAsync()` |
| `Stop` | 작업 중지 | `StopWorkerAsync()` |
| `Cancel` | 취소 요청 | `CancelCurrentJob()` |

#### 변환 / 분석 계열

| 동사 | 사용 목적 | 예 |
|---|---|---|
| `Analyze` | 분석 | `AnalyzeAudioFileAsync()` |
| `Parse` | 문자열/JSON/XML 해석 | `ParseFfprobeJson()` |
| `Convert` | 형식 변환 | `ConvertToWavAsync()` |
| `Map` | 객체 매핑 | `MapJsonToAudioInfo()` |
| `Build` | 문자열/객체 구성 | `BuildFfprobeArguments()` |

---

### 11.5 Windows Forms 이벤트 함수명 규칙

Windows Forms 이벤트 함수는 컨트롤명과 이벤트명을 조합한다.

```csharp
btnSelectFile_Click()
btnAnalyze_Click()
btnClear_Click()
btnStop_Click()
frmMain_Load()
txtInputPath_TextChanged()
gridResult_CellDoubleClick()
```

단, 이벤트 함수에는 실제 업무 로직을 과도하게 작성하지 않는다.

나쁜 예:

```csharp
private void btnAnalyze_Click(object sender, EventArgs e)
{
    // 파일 검증
    // ffprobe 실행
    // JSON 파싱
    // ffmpeg 실행
    // UI 갱신
    // 로그 저장
}
```

좋은 예:

```csharp
private async void btnAnalyze_Click(object sender, EventArgs e)
{
    await AnalyzeSelectedFileAsync();
}
```

실제 로직은 별도 함수로 분리한다.

```csharp
private async Task AnalyzeSelectedFileAsync()
{
    ValidateSelectedFile();
    var result = await _audioAnalyzer.AnalyzeAudioFileAsync(_selectedFilePath);
    UpdateAnalysisResult(result);
}
```

---

### 11.6 Windows Service 함수명 규칙

Windows Service 함수는 시작, 중지, 반복 작업, 상태 보고 목적이 드러나도록 작성한다.

```csharp
StartServiceAsync()
StopServiceAsync()
ExecuteAsync()
RunWorkerLoopAsync()
ProcessPendingJobsAsync()
LoadServiceConfig()
ValidateServiceConfig()
ReportServiceStatus()
HandleServiceException()
CleanupTemporaryFiles()
```

Service 중지와 관련된 함수는 특히 명확히 작성한다.

```csharp
RequestStopAsync()
StopCurrentJobAsync()
CancelRunningProcess()
WaitForWorkerStoppedAsync()
CleanupBeforeStopAsync()
```

권장 패턴:

```csharp
protected override async Task ExecuteAsync(CancellationToken stoppingToken)
{
    await RunWorkerLoopAsync(stoppingToken);
}

private async Task RunWorkerLoopAsync(CancellationToken stoppingToken)
{
    while (!stoppingToken.IsCancellationRequested)
    {
        await ProcessPendingJobsAsync(stoppingToken);
        await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
    }
}
```

---

### 11.7 외부 프로세스 관련 함수명 규칙

FFmpeg, FFprobe, sFTP 등 외부 실행파일을 호출할 경우 아래처럼 역할을 분리한다.

```csharp
FindFfmpegPath()
FindFfprobePath()
BuildFfprobeArguments()
RunFfprobeAsync()
RunFfmpegDecodeTestAsync()
ParseFfprobeJson()
CheckFfmpegPlayableAsync()
KillExternalProcess()
```

역할을 섞지 않는다.

나쁜 예:

```csharp
CheckAudio()
```

좋은 예:

```csharp
AnalyzeAudioMetadataAsync()
CheckFfmpegPlayableAsync()
RunFfmpegDecodeTestAsync()
```

---

### 11.8 로그 관련 함수명 규칙

로그 함수명은 단순하고 통일한다.

```csharp
WriteLog()
WriteLogAsync()
WriteInfoLog()
WriteWarnLog()
WriteErrorLog()
BuildLogLine()
GetCurrentLogFilePath()
EnsureLogDirectory()
FlushLogQueueAsync()
```

권장 구조:

```csharp
_logger.Info("함수명", "설명");
_logger.Warn("함수명", "설명");
_logger.Error("함수명", "설명", ex);
```

직접 파일 쓰기 함수는 내부로 숨긴다.

```csharp
private void WriteLogLine(LogLevel level, string functionName, string message)
private string BuildLogLine(LogLevel level, string functionName, string message)
private string GetCurrentLogFilePath()
```

---

### 11.9 설정 관련 함수명 규칙

설정 관련 함수는 아래 명칭을 우선 사용한다.

```csharp
LoadConfig()
SaveConfig()
ValidateConfig()
CreateDefaultConfig()
EnsureConfigFile()
ApplyConfig()
ReloadConfig()
```

Service에서는 다음 함수명을 사용할 수 있다.

```csharp
LoadServiceConfig()
ValidateServiceConfig()
WatchConfigChanged()
ApplyConfigChanged()
```

---

### 11.10 금지 또는 지양 함수명

아래와 같이 목적이 불명확한 함수명은 사용하지 않는다.

```csharp
DoWork()
Process()
Run()
Start()
Check()
Test()
Temp()
Proc()
Func1()
Button1_Click()
Data()
Set()
Get()
```

단, 프레임워크에서 요구하는 `ExecuteAsync()` 등은 예외로 한다.

---

## 12. 함수 주석 작성 규칙

모든 함수에는 아래 형식의 주석을 작성한다.

```csharp
/// <summary>
/// 작성일자 : YYYY-MM-DD
/// 함수 설명 : 함수의 주요 목적과 처리 내용을 작성한다.
/// 인자 설명 : parameterName - 파라미터의 의미와 사용 목적을 작성한다.
/// 수정 일자 : YYYY-MM-DD
/// 수정 내역 : 수정한 부분과 수정 사유를 작성한다.
/// </summary>
```

### 12.1 함수 주석 작성 예시

```csharp
/// <summary>
/// 작성일자 : 2026-06-25
/// 함수 설명 : 선택된 음원 파일을 ffprobe로 분석하고 코덱, 재생 시간, 채널 정보를 조회한다.
/// 인자 설명 : filePath - 분석 대상 음원 파일의 전체 경로
/// 수정 일자 : 2026-06-25
/// 수정 내역 : 최초 작성
/// </summary>
private async Task<AudioAnalysisResult> AnalyzeAudioFileAsync(string filePath)
{
    ...
}
```

### 12.2 Service 함수 주석 작성 예시

```csharp
/// <summary>
/// 작성일자 : 2026-06-25
/// 함수 설명 : Windows Service 시작 시 설정 파일을 읽고 백그라운드 작업을 초기화한다.
/// 인자 설명 : cancellationToken - 서비스 중지 요청을 감지하기 위한 토큰
/// 수정 일자 : 2026-06-25
/// 수정 내역 : 최초 작성
/// </summary>
protected override async Task ExecuteAsync(CancellationToken cancellationToken)
{
    ...
}
```

### 12.3 수정 시 주석 규칙

함수 수정 시 기존 작성일자는 유지하고, 수정 일자와 수정 내역을 갱신한다.

```csharp
/// <summary>
/// 작성일자 : 2026-06-25
/// 함수 설명 : 선택된 음원 파일을 ffprobe로 분석하고 코덱, 재생 시간, 채널 정보를 조회한다.
/// 인자 설명 : filePath - 분석 대상 음원 파일의 전체 경로
/// 수정 일자 : 2026-07-02
/// 수정 내역 : ffprobe 실행 Timeout 처리 추가
/// </summary>
```

### 12.4 주석 작성 대상

아래 함수는 반드시 주석을 작성한다.

```text
- Form Event Handler
- 버튼 클릭 함수
- 파일 처리 함수
- 로그 기록 함수
- 외부 프로세스 실행 함수
- 설정 파일 읽기/저장 함수
- 예외 처리 공통 함수
- 비동기 작업 함수
- 데이터 변환 함수
- Service 시작/중지 함수
- Timer/반복 작업 함수
- Queue 처리 함수
- 네트워크/DB 접근 함수
```

---

## 13. 로그 파일 작성 규칙

### 13.1 로그 파일명 규칙

로그 파일명은 아래 형식을 사용한다.

```text
프로세스명_작성년월일_시간(HH).log
```

예:

```text
SpeexWavInspector_20260625_09.log
AgencyWavCollector_20260625_14.log
ScreenCaptureAgent.Service_20260625_23.log
```

### 13.2 로그 저장 위치

기본 로그 저장 위치는 프로그램 실행 경로 하위 `logs` 폴더로 한다.

```text
프로그램실행경로\logs
```

예:

```text
C:\Lucis\Tools\SpeexWavInspector\logs
```

단, 설정 파일에서 로그 경로를 별도로 지정할 수 있도록 구성할 수 있다.

### 13.3 로그 라인 규칙

로그 라인은 `|` 문자를 기준으로 항목을 구분한다.

```text
생성일시분초.밀리세컨트|로그레벨|함수명|쓰레드ID|설명
```

로그 포맷은 다음과 같다.

```text
yyyy-MM-dd HH:mm:ss.fff|LEVEL|FunctionName|ThreadId|한글 설명
```

### 13.4 로그 예시

```text
2026-06-25 09:10:23.125|INFO|AnalyzeAudioFileAsync|12|음원 파일 분석을 시작합니다. 파일=C:\sample\test.wav
2026-06-25 09:10:24.330|ERROR|RunFfprobeAsync|18|ffprobe 분석에 실패했습니다. ExitCode=1, 오류=Invalid data found
2026-06-25 09:10:25.112|WARN|FindFfmpegPath|12|ffmpeg.exe를 찾을 수 없습니다. tools 폴더와 PATH를 확인하십시오.
```

### 13.5 로그 레벨

| 로그 레벨 | 의미 |
|---|---|
| DEBUG | 개발 중 상세 확인용 |
| INFO | 정상 처리 흐름 |
| WARN | 처리는 가능하나 주의가 필요한 상황 |
| ERROR | 기능 실패 또는 예외 발생 |
| FATAL | 프로그램 지속 실행이 어려운 치명 오류 |

### 13.6 로그 설명 작성 규칙

로그 설명은 반드시 한글로 직관적으로 작성한다.

나쁜 예:

```text
2026-06-25 09:10:23.125|INFO|Analyze|12|Start
2026-06-25 09:10:24.330|ERROR|Run|12|Fail
```

좋은 예:

```text
2026-06-25 09:10:23.125|INFO|AnalyzeAudioFileAsync|12|음원 파일 분석을 시작합니다. 파일=C:\sample\test.wav
2026-06-25 09:10:24.330|ERROR|RunFfprobeAsync|12|ffprobe 실행 중 오류가 발생했습니다. 오류=파일 형식을 인식할 수 없습니다.
```

---

## 14. 로그 성능 및 잠금 방지 규칙

로그 기록 시 파일 잠금 또는 성능 저하가 발생하지 않도록 다음 규칙을 준수한다.

1. UI Thread에서 직접 대량 로그 파일 쓰기를 수행하지 않는다.
2. Service의 반복 루프에서 동기 파일 쓰기를 과도하게 수행하지 않는다.
3. 로그 파일은 짧게 열고 기록 후 즉시 닫는다.
4. 다중 Thread에서 동시에 로그를 기록할 수 있으므로 동기화 처리를 적용한다.
5. 로그 기록 실패가 프로그램 오류로 이어지면 안 된다.
6. 로그 파일 기록 중 예외가 발생해도 프로그램 주요 기능은 계속 수행되어야 한다.
7. 장시간 실행 Service는 로그 파일이 무한 증가하지 않도록 보관 기간 또는 용량 제한을 둔다.
8. 로그 파일이 외부 프로그램에서 열려 있어도 프로그램이 멈추지 않도록 처리한다.

### 14.1 권장 구현 방식

| 방식 | 적용 대상 |
|---|---|
| Lock 기반 동기화 | 단순 Form 프로그램 |
| ConcurrentQueue 기반 비동기 로그 Writer | Form + 장시간 작업 |
| BackgroundService 기반 로그 Writer | Windows Service |
| Rolling File 방식 | 장시간 상주 프로그램 |

### 14.2 금지 사항

```text
- 매 로그마다 장시간 파일 핸들을 점유하는 방식 금지
- UI Thread에서 반복 로그를 직접 File.AppendAllText로 수행 금지
- Service 반복 루프에서 로그 파일 쓰기 때문에 작업이 지연되는 구조 금지
- 로그 기록 실패 시 MessageBox를 반복 표시하는 방식 금지
- 로그 파일을 Excel 등에서 열고 있는 상태로 프로그램이 멈추는 구조 금지
```

---

## 15. Windows Forms UI 개발 규칙

### 15.1 UI 기본 규칙

1. 프로그램 실행 후 3초 이내에 메인 화면이 표시되어야 한다.
2. 장시간 작업은 UI Thread에서 직접 수행하지 않는다.
3. 파일 분석, 파일 복사, 변환, 외부 프로세스 실행은 `async/await` 또는 Background Task로 처리한다.
4. 작업 중에는 버튼 중복 클릭을 방지한다.
5. 작업 상태를 화면에 표시한다.
6. 오류 메시지는 운영자가 이해할 수 있는 한글 문장으로 표시한다.
7. 분석 결과 또는 처리 결과는 색상만으로 구분하지 않고 텍스트로도 표시한다.

### 15.2 버튼 규칙

주요 버튼은 시인성을 확보하기 위해 충분히 크게 구성하고, 기능을 명확히 표현한다.

예:

```text
📂 파일 선택
🔍 분석 실행
▶ 결과 확인
🧹 초기화
⏹ 중지
⚙ 설정
```

버튼 규칙은 다음과 같다.

| 항목 | 기준 |
|---|---|
| 버튼 크기 | 주요 버튼은 충분히 크게 구성 |
| 텍스트 | 기능을 명확히 표현 |
| 아이콘 | 가능하면 아이콘성 문자 또는 이미지 사용 |
| 상태 | 작업 중 비활성화 처리 |
| 중복 클릭 | 방지 처리 필수 |

### 15.3 카드형 UI 규칙

운영자가 주요 상태를 빠르게 확인해야 하는 프로그램은 카드형 UI를 사용할 수 있다.

| 카드 | 표시 예 |
|---|---|
| 파일 정보 | 파일명, 경로, 크기 |
| 처리 상태 | 대기, 진행 중, 완료, 오류 |
| 분석 결과 | 코덱, 채널, Duration |
| 외부 도구 상태 | ffmpeg 인식 여부, 버전 |
| 오류 정보 | 오류 코드, 오류 설명 |

### 15.4 UI Thread 접근 규칙

Background Task에서 UI Control을 직접 수정하지 않는다.

필요 시 `Invoke` 또는 `BeginInvoke`를 사용한다.

```csharp
if (this.InvokeRequired)
{
    this.BeginInvoke(() =>
    {
        lblStatus.Text = "분석 완료";
    });
}
else
{
    lblStatus.Text = "분석 완료";
}
```

---

## 16. Windows Service 개발 규칙

### 16.1 Service 기본 원칙

Windows Service는 무인 실행을 전제로 한다.

1. `MessageBox`, `OpenFileDialog`, `Form`, `Dialog` 등 UI 요소를 사용하지 않는다.
2. 모든 상태와 오류는 로그로 기록한다.
3. 서비스 시작, 중지, 재시작 시 상태가 명확히 기록되어야 한다.
4. 서비스 중지 요청 시 진행 중인 작업을 안전하게 종료해야 한다.
5. 서비스 계정 권한을 고려하여 파일, 네트워크, DB 접근 권한을 확인해야 한다.
6. 서비스는 예외로 인해 조용히 종료되면 안 된다.
7. 치명 오류 발생 시 로그를 남기고 종료 또는 재시도 정책을 따른다.
8. Service는 UI가 실행되지 않아도 독립적으로 동작해야 한다.

### 16.2 Service 시작 처리

서비스 시작 시 다음을 수행한다.

| 항목 | 처리 |
|---|---|
| 설정 파일 확인 | 없으면 기본값 생성 또는 오류 로그 기록 |
| 로그 경로 확인 | 없으면 생성 |
| 외부 도구 확인 | 필요 시 경로 검증 |
| DB/네트워크 확인 | 필요 시 연결 가능 여부 검증 |
| 중복 실행 확인 | 동일 프로세스 또는 Lock 파일 확인 |
| 작업 초기화 | Timer, Queue, Worker 초기화 |

### 16.3 Service 중지 처리

서비스 중지 시 다음을 수행한다.

1. 신규 작업 투입 중단
2. 진행 중인 작업에 `CancellationToken` 전달
3. 외부 프로세스 실행 중이면 종료 요청
4. Queue 작업 정리 또는 안전 저장
5. 임시 파일 정리
6. 종료 완료 로그 기록
7. 지정 시간 내 종료되지 않으면 강제 종료 또는 경고 로그 기록

### 16.4 Service 반복 작업 규칙

반복 작업은 `while` 루프만으로 무한 실행하지 않는다.

권장 방식:

```text
- PeriodicTimer
- Timer
- BackgroundService + CancellationToken
- Scheduler 클래스 분리
```

반복 작업에는 반드시 Delay 또는 Timer 간격을 둔다.

금지 예:

```csharp
while (true)
{
    DoWork();
}
```

권장 예:

```csharp
while (!stoppingToken.IsCancellationRequested)
{
    await DoWorkAsync(stoppingToken);
    await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
}
```

### 16.5 Service 복구 정책

Windows Service 배포 시 복구 정책을 명시한다.

권장 예:

| 실패 횟수 | 조치 |
|---|---|
| 1차 실패 | 서비스 재시작 |
| 2차 실패 | 서비스 재시작 |
| 3차 실패 | 재시작하지 않고 로그 확인 |

설치 스크립트 또는 운영 문서에 복구 정책 설정 방법을 포함한다.

### 16.6 Service 계정 권한 규칙

서비스 계정은 운영 환경에 맞게 명확히 지정한다.

| 계정 유형 | 사용 기준 |
|---|---|
| LocalSystem | 로컬 리소스 중심 처리 |
| NetworkService | 네트워크 접근 일부 필요 |
| 전용 서비스 계정 | 파일 공유, DB, 네트워크 접근 필요 |

주의사항:

1. 네트워크 공유 폴더 접근이 필요한 경우 LocalSystem 사용을 피한다.
2. UNC 경로 접근 권한을 반드시 확인한다.
3. 드라이브 매핑 경로는 Service에서 인식되지 않을 수 있으므로 사용하지 않는다.
4. DB 접근이 필요한 경우 서비스 계정 권한을 명확히 부여한다.
5. 권한 문제는 로그에 구체적으로 기록한다.

---

## 17. UI + Service 연계 규칙

Windows Forms UI와 Windows Service가 함께 존재하는 경우 직접 의존을 피한다.

### 17.1 연계 방식

| 방식 | 사용 기준 |
|---|---|
| 설정 파일 | 단순 설정 전달 |
| 로컬 API | 상태 조회, 제어 명령 |
| Named Pipe | 로컬 PC 내 UI-Service 통신 |
| TCP/HTTP | 원격 제어 또는 다중 Agent 관리 |
| DB/File 상태 | 배치성 상태 공유 |

### 17.2 연계 원칙

1. UI가 Service 프로세스를 직접 종료하지 않는다.
2. UI는 Service에 중지 요청을 전달하고 Service가 안전하게 종료한다.
3. UI는 Service 상태를 주기적으로 조회할 수 있다.
4. Service는 UI가 실행되지 않아도 독립적으로 동작해야 한다.
5. Service 설정 변경 시 즉시 반영 여부와 재시작 필요 여부를 명확히 구분한다.
6. UI와 Service 간 명령은 성공/실패 결과를 명확히 반환해야 한다.
7. Service 오류를 UI에 표시할 경우 최근 오류와 발생 시각을 함께 표시한다.

### 17.3 상태 표시 기준

UI에서 Service 상태를 표시할 경우 다음 항목을 포함한다.

| 항목 | 설명 |
|---|---|
| 서비스 설치 여부 | 설치됨 / 미설치 |
| 서비스 실행 상태 | 실행 중 / 중지 / 오류 |
| 마지막 작업 시각 | 최근 처리 일시 |
| 최근 오류 | 마지막 오류 메시지 |
| 현재 작업 | 대기 / 처리 중 / 중지 중 |
| 설정 반영 상태 | 반영됨 / 재시작 필요 |

---

## 18. 예외 처리 규칙

### 18.1 공통 예외 처리 대상

다음 영역에는 반드시 예외 처리를 적용한다.

```text
- 파일 선택
- 파일 읽기/쓰기
- 디렉토리 생성
- 설정 파일 읽기/저장
- 외부 프로세스 실행
- JSON/XML/INI 파싱
- 네트워크 접근
- DB 접근
- UI 이벤트 처리
- Service 시작/중지
- Timer/반복 작업
- Queue 처리
```

### 18.2 예외 메시지 규칙

사용자에게 표시하는 메시지는 한글로 작성한다.

나쁜 예:

```text
Object reference not set to an instance of an object.
```

좋은 예:

```text
분석 대상 파일 정보가 없습니다. 파일을 다시 선택한 후 분석을 실행하십시오.
```

### 18.3 Service 예외 처리 규칙

1. Service에서는 사용자 메시지 대신 로그에 상세히 기록한다.
2. 반복 작업에서 예외가 발생해도 전체 서비스가 즉시 종료되지 않도록 처리한다.
3. 일시 오류와 치명 오류를 구분한다.
4. 일시 오류는 재시도 정책을 적용한다.
5. 치명 오류는 FATAL 로그를 기록하고 종료 또는 운영자 확인 대상으로 분류한다.

### 18.4 예외 발생 시 필수 로그

예외 발생 시 로그에는 다음 정보를 남긴다.

```text
- 함수명
- 예외 메시지
- 주요 입력값
- StackTrace
- 처리 결과
```

단, 개인정보 또는 고객 식별정보는 그대로 로그에 남기지 않는다.

---

## 19. 비동기 및 장시간 작업 처리 규칙

### 19.1 적용 대상

다음 작업은 반드시 비동기 또는 백그라운드 작업으로 처리한다.

```text
- 대용량 파일 검색
- 음원 분석
- 음원 변환
- ffmpeg 실행
- 네트워크 전송
- DB 조회
- 대량 로그 처리
- 파일 업로드/다운로드
- 장비 상태 수집
```

### 19.2 중지 처리 규칙

장시간 작업에는 중지 기능을 제공한다.

```text
- CancellationToken 사용
- 중지 버튼 또는 서비스 중지 요청 시 신규 작업 투입 중단
- 진행 중인 외부 프로세스 종료
- 임시 파일 정리
- UI 버튼 상태 원복
- Service 종료 완료 로그 기록
```

### 19.3 중복 실행 방지

1. 분석/변환/수집 중에는 동일 작업이 중복 실행되지 않도록 버튼을 비활성화한다.
2. Service 또는 Batch는 중복 실행을 방지하기 위해 Mutex, Lock File, 상태 파일 중 하나를 사용할 수 있다.
3. 중복 실행이 감지되면 로그를 기록하고 신규 실행을 중단한다.

---

## 20. 외부 프로세스 실행 규칙

ffmpeg, ffprobe, sftp 등 외부 실행 파일을 호출하는 경우 다음 규칙을 준수한다.

### 20.1 필수 처리

1. 실행 파일 존재 여부 확인
2. 실행 경로 하드코딩 금지
3. Arguments 로그 기록
4. Timeout 적용
5. stdout 수집
6. stderr 수집
7. ExitCode 확인
8. 실패 시 사용자 메시지 또는 Service 로그 기록
9. 실행 중 중지 요청 시 프로세스 종료
10. 공백이 포함된 경로는 반드시 따옴표 처리

### 20.2 금지 사항

```text
- 외부 프로세스를 무제한 대기시키는 코드 금지
- stderr를 읽지 않아 프로세스가 멈추는 구조 금지
- 실행 경로를 하드코딩하는 방식 금지
- Service에서 외부 프로세스 실행 실패를 무시하는 방식 금지
```

---

## 21. 설정 파일 규칙

설정 파일은 `config` 폴더 하위에 저장한다.

```text
config\appsettings.json
config\프로그램명.json
```

설정 파일에는 다음 항목을 포함할 수 있다.

| 항목 | 설명 |
|---|---|
| LogPath | 로그 저장 경로 |
| LogRetentionDays | 로그 보관 일수 |
| ToolPath | 외부 실행 도구 경로 |
| DefaultInputPath | 기본 입력 경로 |
| DefaultOutputPath | 기본 출력 경로 |
| TimeoutSeconds | 외부 프로세스 Timeout |
| MaxParallelCount | 병렬 처리 수 |
| ServiceName | Windows Service 명칭 |
| PollingIntervalSeconds | 반복 작업 주기 |
| RetryCount | 실패 재시도 횟수 |
| RetryDelaySeconds | 재시도 대기 시간 |

### 21.1 설정 파일 처리 규칙

1. 설정 파일이 없으면 기본값으로 생성한다.
2. 설정값 오류 시 기본값으로 보정한다.
3. 설정 파일 파싱 실패 시 사용자 또는 로그로 안내한다.
4. 비밀번호, 토큰 등 민감정보는 평문 저장하지 않는다.
5. Service 설정 변경 시 재시작 필요 여부를 명확히 기록한다.
6. 설정 변경 이력은 필요 시 별도 로그 또는 설정 백업 파일로 남긴다.

---

## 22. 파일 및 경로 처리 규칙

1. 경로는 하드코딩하지 않는다.
2. 상대 경로와 절대 경로를 명확히 구분한다.
3. Service에서는 실행 경로와 현재 작업 경로가 다를 수 있으므로 `AppContext.BaseDirectory` 기준을 우선 사용한다.
4. 네트워크 공유 경로는 UNC 경로 기준으로 처리한다.
5. 드라이브 매핑 경로는 Service에서 인식되지 않을 수 있으므로 사용하지 않는다.
6. 파일명에 사용할 수 없는 문자는 제거하거나 치환한다.
7. 파일 덮어쓰기 여부는 명확히 정책화한다.
8. 임시 파일은 작업 완료 또는 실패 시 정리한다.
9. 파일 접근 실패 시 원인을 구분하여 표시하거나 로그에 기록한다.

오류 구분 예:

| 오류 | 사용자 메시지 또는 로그 |
|---|---|
| 파일 없음 | 파일이 존재하지 않습니다 |
| 권한 없음 | 파일 접근 권한이 없습니다 |
| 사용 중 | 다른 프로그램에서 파일을 사용 중입니다 |
| 경로 오류 | 파일 경로가 올바르지 않습니다 |
| 디스크 공간 부족 | 저장 공간이 부족합니다 |

---

## 23. 개인정보 및 보안 규칙

1. 로그에 주민번호, 전화번호, 계좌번호, 고객명 등 개인정보를 그대로 남기지 않는다.
2. 파일 경로에 고객 식별정보가 포함될 수 있으므로 외부 공유 시 마스킹한다.
3. 운영 로그를 외부 전달할 경우 개인정보 포함 여부를 확인한다.
4. API Key, Token, DB Password는 소스에 하드코딩하지 않는다.
5. 설정 파일에 민감정보가 필요한 경우 암호화 또는 별도 보안 저장 방식을 사용한다.
6. Service 계정에는 필요한 최소 권한만 부여한다.
7. 인증서, 개인키, 접속정보는 저장소에 포함하지 않는다.
8. 외부 도구 실행 경로와 인자는 로그에 남기되, 민감정보가 포함된 인자는 마스킹한다.

---

## 24. Windows Service 설치 및 제거 스크립트 규칙

Windows Service 프로젝트는 설치/제거/시작/중지 스크립트를 포함한다.

```text
scripts\install-service.ps1
scripts\uninstall-service.ps1
scripts\start-service.ps1
scripts\stop-service.ps1
```

### 24.1 install-service.ps1 포함 항목

```text
- 서비스명
- 표시명
- 설명
- 실행 파일 경로
- 시작 유형
- 서비스 계정
- 복구 정책
- 로그 경로 생성
- 설정 파일 존재 여부 확인
```

### 24.2 uninstall-service.ps1 포함 항목

```text
- 서비스 중지
- 서비스 삭제
- 잔여 프로세스 확인
- 로그/설정 삭제 여부 안내
```

### 24.3 start-service.ps1 포함 항목

```text
- 서비스 설치 여부 확인
- 서비스 시작
- 시작 후 상태 확인
- 시작 실패 시 최근 로그 위치 안내
```

### 24.4 stop-service.ps1 포함 항목

```text
- 서비스 설치 여부 확인
- 서비스 중지 요청
- 중지 완료 대기
- 지정 시간 초과 시 안내
```

---

## 25. 빌드 및 배포 규칙

### 25.1 빌드 규칙

배포 전 반드시 Release 빌드를 수행한다.

```powershell
dotnet build -c Release
```

게시가 필요한 경우:

```powershell
dotnet publish -c Release
```

### 25.2 배포 파일 확인

| 항목 | Forms | Service |
|---|---|---|
| exe 생성 여부 | 필수 | 필수 |
| dll 포함 여부 | 필수 | 필수 |
| runtimeconfig 포함 여부 | 필수 | 필수 |
| 설정 파일 포함 여부 | 필요 시 | 필수 |
| 설치 스크립트 | 선택 | 필수 |
| 외부 도구 | 정책에 따름 | 정책에 따름 |
| 로그 폴더 생성 가능 여부 | 필수 | 필수 |
| 서비스 설치 확인 | 해당 없음 | 필수 |

### 25.3 Release 문서 작성

배포 시 `05_release` 폴더에 Release 문서를 작성한다.

```text
RELEASE-001_YYYYMMDD.md
RELEASE-002_YYYYMMDD.md
```

Release 문서에는 다음을 기록한다.

```text
- 배포일
- 프로그램명
- 버전
- 포함 Task
- 포함 Result
- 변경 내용
- 배포 파일
- 배포 경로
- 실행 방법
- 검증 결과
- 알려진 제약사항
- 롤백 방법
```

---

## 26. 테스트 규칙

### 26.1 Windows Forms 필수 테스트

| 테스트 | 확인 내용 |
|---|---|
| 실행 테스트 | 프로그램 정상 실행 여부 |
| 버튼 테스트 | 주요 버튼 클릭 시 오류 여부 |
| 파일 선택 테스트 | 파일 선택 및 경로 표시 |
| 정상 파일 테스트 | 정상 입력 처리 |
| 비정상 파일 테스트 | 손상 파일, 빈 파일, 없는 파일 처리 |
| 외부 도구 없음 테스트 | ffmpeg/ffprobe 등 없음 처리 |
| 로그 생성 테스트 | 로그 파일 생성 및 포맷 확인 |
| 중복 실행 테스트 | 버튼 연속 클릭 시 중복 작업 방지 |
| 종료 테스트 | 작업 중 종료 시 예외 여부 |

### 26.2 Windows Service 필수 테스트

| 테스트 | 확인 내용 |
|---|---|
| 설치 테스트 | 서비스 설치 성공 여부 |
| 시작 테스트 | 서비스 시작 및 시작 로그 기록 |
| 중지 테스트 | 서비스 중지 및 종료 로그 기록 |
| 재시작 테스트 | 재시작 후 정상 작업 복귀 |
| 자동 시작 테스트 | OS 재부팅 후 자동 시작 여부 |
| 권한 테스트 | 파일/DB/네트워크 접근 가능 여부 |
| 설정 오류 테스트 | 설정 파일 오류 시 처리 |
| 외부 도구 없음 테스트 | 외부 실행 파일 누락 시 처리 |
| 장애 복구 테스트 | 예외 발생 후 재시도 또는 종료 정책 확인 |
| 로그 생성 테스트 | 서비스 상태와 오류 로그 기록 |
| 장시간 실행 테스트 | 메모리 증가, 핸들 누수, 로그 증가 확인 |

### 26.3 테스트 결과 기록

테스트 결과는 `RESULT-xxx.md` 또는 `REVIEW-xxx.md`에 기록한다.

---

## 27. 동시 개발 규칙

동시 개발 시에는 반드시 Task 단위로 브랜치를 분리한다.

```text
feature/TASK-001-ui
feature/TASK-002-ffprobe
feature/TASK-003-playability
feature/TASK-004-service-install
fix/TASK-005-error-message
```

공통 파일 수정은 별도 Task로 분리한다.

```text
TASK-010_공통_로그모듈_개선.md
TASK-011_공통_설정모듈_개선.md
TASK-012_Service_공통설치스크립트_개선.md
```

---

## 28. Cursor AI 작업 제한 규칙

Cursor AI는 다음을 임의로 수행하지 않는다.

```text
- Task에 없는 기능 추가
- 대규모 리팩토링
- UI 전체 재배치
- Service 실행 구조 변경
- Service 계정 또는 권한 정책 변경
- 공통 모듈 임의 변경
- DB 구조 변경
- 외부 NuGet 패키지 추가
- 외부 서버 통신 추가
- 설정 파일 형식 변경
- 기존 문서 삭제
- 기존 RESULT 문서 덮어쓰기
- 인증서, 개인키, 접속정보 저장소 포함
```

불가피하게 필요한 경우에는 작업을 중단하고 개발자에게 확인을 요청한다.

---

## 29. 금지 사항

개발 및 AI IDE 작업 중 다음을 금지한다.

1. Task에 없는 기능 추가
2. 임의 패키지 설치
3. 외부 서버 통신 추가
4. DB 연계 추가
5. 외부 실행 파일을 저장소에 포함
6. 대량 리팩토링
7. 기존 문서 삭제
8. 기존 RESULT 문서 덮어쓰기
9. Service에서 UI 표시
10. 로그에 개인정보 평문 기록
11. 설정 파일에 비밀번호 또는 토큰 평문 저장
12. 경로 하드코딩
13. 외부 프로세스 무제한 대기
14. `DoWork`, `Func1`, `Button1_Click` 등 목적이 불명확한 함수명 사용

---

## 30. 완료 기준

Windows Forms & Service 개발 Task는 다음 조건을 만족해야 완료로 판단한다.

1. Task 범위 내 소스 수정 완료
2. 함수명 규칙 준수
3. 함수 주석 작성 완료
4. 로그 규칙 반영 완료
5. 예외 처리 반영 완료
6. UI 멈춤 방지 또는 Service 중지 안정성 처리 완료
7. 빌드 성공
8. 필수 테스트 수행
9. RESULT 문서 작성
10. 미완료 항목 및 제약사항 기록
11. 개발자 검토 완료

Service 프로그램의 경우 추가로 다음을 만족해야 한다.

1. 서비스 설치/삭제 스크립트 작성
2. 서비스 시작/중지 테스트 완료
3. 서비스 계정 권한 확인
4. OS 재부팅 후 자동 시작 여부 확인
5. 장시간 실행 안정성 확인

---

## 31. 필수 문구

아래 문구는 모든 Windows Forms & Service 프로젝트 규칙에 포함한다.

```text
함수명은 동사로 시작하고, 처리 대상과 목적이 드러나야 하며, 비동기는 Async, Boolean은 Is/Has/Can/Should를 사용한다.

Windows Forms 프로그램에서 파일 분석, 변환, 수집, 외부 프로세스 실행 등 장시간 작업은 UI Thread에서 직접 수행하지 않는다.

Windows Service는 무인 실행을 전제로 하며 UI 요소를 사용하지 않는다.

Service 중지 요청 시 신규 작업 투입을 중단하고 진행 중인 작업은 CancellationToken 기반으로 안전하게 종료한다.

Service 프로그램은 설치/삭제/시작/중지 스크립트를 포함해야 한다.

Service 계정 권한, 로그 경로, 설정 파일, 외부 도구 경로는 운영 환경 기준으로 검증해야 한다.

Windows Forms UI와 Windows Service가 함께 존재하는 경우 UI는 상태 조회와 제어 요청만 수행하고, 실제 작업은 Service 또는 Core 모듈에서 수행한다.

외부 프로세스 실행 시 Timeout, stdout, stderr, ExitCode를 반드시 처리한다.

로그에는 개인정보 또는 고객 식별정보를 평문으로 기록하지 않는다.

Cursor AI는 Task 범위 외 기능 추가, 대규모 리팩토링, 공통 모듈 변경을 임의로 수행하지 않는다.

RESULT 문서만으로 배포하지 않는다. REVIEW 문서에서 검토 완료 후 RELEASE 문서를 작성하고 배포한다.
```
