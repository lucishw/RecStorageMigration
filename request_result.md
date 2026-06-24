# request.md 수행 결과

## 변경 요약

- 솔루션의 프로젝트 표시명, 프로젝트 파일명, 출력 실행 파일명, 어셈블리명, 제품명, 메인 폼 제목을 `RecStorageMigration` 기준으로 정리했습니다.
- `ServicePointManager.DefaultConnectionLimit = 100` 적용 여부를 INI와 WinForms 체크박스로 제어하도록 변경했습니다.
- 실행 파일명 변경 시 `KMSMigration.ini`를 `RecStorageMigration.ini`로 자동 복사하던 호환 처리는 제거했습니다.
- `MediaParser.dll` 프로젝트 참조를 제거하고, 활성 Worker 처리 경로에서 MediaParser/KMS 연결을 사용하지 않도록 분리했습니다. 기존 legacy 코드는 보존했습니다.
- `Multi Worker` 탭의 고정 영역은 디자이너 폼 컨트롤로 구성하고, Worker Row만 코드에서 동적으로 생성하도록 정리했습니다.
- `tsbStart`는 체크된 대기 Worker만 전체 시작하고, `tsbStop`은 실행 중 Worker 전체 중지로 동작하도록 정리했습니다.
- `전체 선택` 버튼을 `작업자 추가` 버튼 왼쪽에 추가했습니다.
- Worker Row별 시작/중지/초기화 버튼, 진행 ProgressBar, 현재 상태, 처리/성공/예외 누적 카운트를 표시하도록 변경했습니다.
- 기존 `현황` 버튼은 제거했습니다.
- Worker Row별 `FromDate`, `ToDate` 입력값을 추가하고, 각 Worker가 자기 날짜 범위로 독립 실행되도록 변경했습니다.
- `Config[DB]`의 전역 `FromDate`, `ToDate` 입력칸은 제거했습니다.
- Worker별 배치 처리 후 interval 대기 기능을 추가하고, 대기 중 남은 초를 상태 문구로 표시하도록 변경했습니다.
- Worker 현재 상태는 `작업 시작`, `조회 중`, `1,000건 조회`, `파일 복사 중.. 파일명`, `Interval 대기 중.. 3` 같은 상세 문구로 표시하고 Worker 로그 화면에도 남기도록 변경했습니다.
- Worker별 설정값과 누적 처리/성공/예외 건수를 `RecStorageMigration.ini`의 개별 Worker 섹션에 저장하도록 변경했습니다.
- 전체 누적 초기화와 Worker별 누적 초기화 버튼을 모두 유지하고, 실행 전 확인 창을 표시하도록 변경했습니다.
- Worker별 초기화 버튼은 Row 하단 우측으로 이동했고, 버튼 영역이 잘리지 않도록 배치를 재계산했습니다.
- WinForms 메인 폼을 리사이즈 가능하게 변경하고, Multi Worker Row가 충분히 넓은 화면에서는 2열로 배치되도록 반응형 UI를 추가했습니다.
- `Config[DB]`의 Target DB 설정 영역과 `Config[Path]`의 KMS 설정 영역은 제거했습니다.
- `Logs` 탭은 좌우 분할로 변경했습니다. 왼쪽은 메인 오케스트레이션 로그, 오른쪽은 선택한 Worker 로그를 표시합니다.
- Worker 로그 선택 RadioButton은 Worker 개수에 맞춰 동적으로 생성됩니다.
- Worker 로그 파일명을 `worker_1_2026-06-22_RecStorageMigration.log`, `worker_1_2026-06-22_RecStorageMigrationErr.log` 형식으로 분리했습니다.
- `Schedule and Process info.` 영역의 전역 `처리 중인 녹음 일자` 표시는 제거했습니다.
- 처리 중인 녹음 일자는 Worker Row의 별도 라벨에 Worker별로 표시되도록 변경했습니다.
- Worker Row의 상태 라벨을 하나로 통합하고, 아래쪽 보조 상태 라벨은 제거했습니다.
- Worker Row 높이와 ProgressBar, 처리/성공/예외, 초기화 버튼 위치를 재정렬했습니다.
- Worker Row별 개별 `삭제` 버튼은 제거했습니다.
- 상단 `선택 삭제` 버튼은 체크된 Worker 목록을 확인 창에 표시한 뒤 사용자 확인을 받고 삭제하도록 변경했습니다.
- 실행 중인 Worker가 삭제 대상으로 포함되면 삭제하지 않고 대상 목록을 안내하도록 변경했습니다.
- Worker Row의 `현재 처리일자`를 작업 상태와 분리해 별도 라벨로 표시하도록 변경했습니다.
- Worker 작업 상태 라벨은 조회/복사/Interval 대기 같은 프로세스 상태만 표시하도록 변경했습니다.
- Worker Row의 `To` 라벨이 잘리지 않도록 라벨 폭과 ToDate 입력 위치를 조정했습니다.
- `Config[DB]`와 `Config[Path]`를 하나의 `Config` 탭으로 통합했습니다.
- 통합된 `Config` 탭 안에서 `DB - Source`, `Path - Impact360`, `Path - Audiolog`, `Path - Target` 카테고리 그룹으로 나눠 표시하도록 정렬했습니다.
- 상단 `Config` 버튼이 통합된 `Config` 탭을 열도록 탭 인덱스를 보정했습니다.
- `Schedule and Process` 설정을 상단 고정 영역에서 제거하고 통합된 `Config` 탭의 첫 카테고리로 이동했습니다.
- `Start` 버튼은 Worker 즉시 실행이 아니라 Worker 스케줄러 시작으로 동작하도록 변경했습니다.
- Worker 스케줄러는 기존 `KMSMigrationBatch`의 Runtime 판정 방식과 동일하게 시작/종료 시간을 판단한 뒤, Runtime 안에서만 체크된 Worker를 실행합니다.
- `Schedule and Process`의 `Interval`은 스케줄 체크 간격으로 사용하며, 타이머는 1초 단위로 동작하도록 명시했습니다.
- Worker가 실행 중이면 스케줄 체크가 반복되어도 중복 시작하지 않고 대기하도록 유지했습니다.
- `Auto Start`는 프로그램 시작 시 Worker 스케줄러를 자동으로 켜는 방식으로 정리했습니다.
- Auto Start 시 체크된 Worker가 없으면 스케줄러를 켜지 않고 로그만 남기도록 변경했습니다.
- Worker 체크 선택 상태를 `[Worker_{번호}]` 섹션의 `Selected` 값으로 INI에 저장/복원하도록 추가했습니다.
- 각 Worker에 `Schedule and Process`의 Runtime 시작/종료 시간을 전달하도록 추가했습니다.
- Worker는 각 배치 처리에 진입하기 직전 Runtime 범위를 다시 확인합니다.
- Runtime 범위를 벗어나면 새 배치에 들어가지 않고 `Runtime 범위 외 중지` 상태로 정상 종료하도록 변경했습니다.
- Runtime 설정을 평일/주말로 분리했습니다. `Config` 화면의 `Schedule and Process` 영역에서 `Weekday`, `Weekend` 시간을 각각 설정할 수 있습니다.
- 스케줄러와 각 Worker는 현재 요일을 기준으로 평일 Runtime 또는 주말 Runtime을 선택해 체크합니다.
- 주말은 토요일/일요일로 판단하며, 평일/주말 모두 시작/종료 시간이 같으면 24시간 실행 가능으로 판단합니다.
- Worker는 interval 대기 중에도 1초마다 Runtime을 다시 확인하고, Runtime 범위를 벗어나면 다음 배치로 넘어가지 않고 중지합니다.
- 스케줄러가 다음 Runtime에 다시 진입하면 체크된 Worker를 다시 시작할 수 있는 기존 흐름은 유지했습니다.
- Worker 진행 상태 이벤트는 즉시 UI 컨트롤을 갱신하지 않고, Worker별 최신 상태만 보관한 뒤 설정된 간격으로 화면에 flush하도록 변경했습니다.
- Worker 누적 처리/성공/예외 건수는 매 건 INI 저장하지 않고, `WorkerStatsSaveIntervalSec` 간격으로 저장하도록 변경했습니다.
- Worker 완료/중지/오류 시에는 저장 간격과 무관하게 최종 누적 결과를 즉시 INI에 저장합니다.
- Worker 로그 화면은 모든 로그를 즉시 `ListBox`에 추가하지 않고, 선택된 Worker 로그만 `WorkerLogFlushIntervalMs` 간격으로 제한 flush하도록 변경했습니다.
- 선택되지 않은 Worker 로그는 메모리에 최근 로그만 보관하고, Worker RadioButton 선택 시 최근 로그를 한 번에 표시합니다.

## 주요 설정

`RecStorageMigration.ini`의 `[General]` 섹션에서 다음 값을 사용합니다.

```ini
EnableDefaultConnectionLimit=1
WorkerStatsSaveIntervalSec=5
WorkerLogFlushIntervalMs=500
```

- `1` 또는 빈 값: `DefaultConnectionLimit`를 100으로 설정
- `0`: 별도 설정하지 않음
- `WorkerStatsSaveIntervalSec`: Worker 누적 처리/성공/예외 건수 INI 저장 간격(초), 기본값 5
- `WorkerLogFlushIntervalMs`: Worker 로그/상태 화면 flush 간격(ms), 기본값 500, 최소 100

Worker 목록은 `[Workers]` 섹션에 저장됩니다.

```ini
[Workers]
Count=2
WorkerIds=1,2
NextWorkerId=3
```

Worker별 설정과 누적 결과는 `[Worker_{번호}]` 섹션에 저장됩니다.

```ini
[Worker_1]
TopCount=5000
IntervalSec=10
FromDate=2026-06-22
ToDate=2026-06-22
MarkField=...
MarkValue=1
SelectCondition=...
ProcessedCount=0
SuccessCount=0
FailureCount=0
```

작업 Runtime은 `[WorkInfo]` 섹션에 평일/주말로 저장됩니다. 기존 `StartTime`, `EndTime` 값은 호환용 fallback으로 유지됩니다.

```ini
[WorkInfo]
StartTime=09:00:00
EndTime=18:00:00
WeekdayStartTime=09:00:00
WeekdayEndTime=18:00:00
WeekendStartTime=09:00:00
WeekendEndTime=18:00:00
```

## 빌드 검증

다음 명령으로 `Debug|x86` 빌드를 검증했습니다.

```powershell
& 'C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe' RecStorageMigration.sln /p:Configuration=Debug /p:Platform=x86 /p:OutDir=bin\DebugVerifyStorage\ /p:BaseIntermediateOutputPath=obj\DebugVerifyStorage\ /p:IntermediateOutputPath=obj\DebugVerifyStorage\x86\Debug\
```

결과:

- 빌드 성공
- 오류 0건
- 기존 경고 2건 유지

남은 경고:

- `SqlAccount.cs`의 미사용 `ex` 변수 경고 2건
