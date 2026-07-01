# Implementation Principles — greenfield 구현 원칙

> AI는 본 문서의 **목표·금지**를 만족하는 How를 자유롭게 선택한다.  
> 선택 결과는 **RESULT-xxx**에 반드시 기록한다.  
> 레거시 WinForms 코드의 UI 스레드·구조 패턴은 **복사하지 않는다.**

---

## 1. UI 스레드 · 반응성

### 1.1 금지 (레거시에서 가져오지 않음)

- UI 컨트롤에 대한 광범위한 `Invoke` / `BeginInvoke` 산재
- WinForms `Timer`로 progress·log **수동 flush**를 유일 수단으로 사용
- Worker 이벤트 1건당 UI 컨트롤 직접 갱신
- 수천 줄 단일 Form에 DB·경로·Worker·스케줄러 로직 혼재
- UI 스레드에서 DB 조회·파일 복사·외부 프로세스 대기

### 1.2 달성 목표

| 목표 | 설명 |
|------|------|
| UI non-blocking | 장시간 작업 중에도 창이「응답 없음」이 되지 않음 |
| 관심사 분리 | UI = 입력·표시·설정; Worker = DB·파일·마킹 |
| 구조화된 상태 | 진행·통계·로그는 **모델/이벤트**로 전달, UI는 **저빈도 일괄** 반영 |
| 협력적 취소 | Worker·RoboCopy·스케줄 중지는 일관된 취소 토큰 |
| Form 축소 | App 계층은 얇게; Core/Infrastructure에 비즈니스 |

### 1.3 AI 선택 가능 방향 (강제 아님)

- App / Core / Infrastructure 프로젝트 분리
- `async/await` + UI synchronization context
- `IProgress<T>`, `Channel<T>`, observer, MVVM/Presenter
- 로그·상태 **버퍼 + 배치 렌더** (구체 API는 RESULT에 기록)

---

## 2. 동시성 · DB

- Worker마다 **독립 DB 연결** (공유 연결 금지)
- Worker마다 **독립 CancellationToken**
- 동시 파일 처리 시 **임시 경로·파일명 충돌 방지**
- 스케줄러는 **시작/중지 오케스트레이션**만; 이관 로직은 Core Worker

---

## 3. 아키텍처

```text
src/
├─ RecFileMigrationTool.App/           # WinForms, 설정 UI, 상태 표시
├─ RecFileMigrationTool.Core/          # Worker, Scheduler, Models, Path rules
├─ RecFileMigrationTool.Infrastructure/ # DB, INI, Log, RoboCopy, Security
└─ RecFileMigrationTool.Tests/         # (선택)
config/   logs/   scripts/   release/
```

- SQL·경로 조립·마킹: **Core 또는 Infrastructure**
- UI: Core 상태 **구독·표시**만

[`kb_migration_cursor_md/02_architecture_design.md`](../kb_migration_cursor_md/02_architecture_design.md)와 충돌 시 **KB 우선** (Bulk Update, Orchestrator 등). TASK 수용기준 + RESULT에서 차이 명시.

---

## 4. 로그 · 예외 (원칙)

- 로그 실패가 주 기능을 중단시키지 않음
- 운영자 메시지는 **한글**
- DB·파일·INI 예외는 catch 후 로그 + UI/마킹 정책에 따른 처리
- 함수명: 동사+대상, Boolean은 `Is`/`Has`/`Can`

상세 명명·로그 포맷: [`rules_windows_dotnet_app.md`](../rules_windows_dotnet_app.md) 발췌 (Timer flush 등 레거시 WinForms 패턴은 제외).

---

## 5. RESULT 필수 기록 (How 추적)

각 RESULT-xxx에 포함:

1. **UI–Worker 연동 방식** (선택 패턴, 1문단)
2. **App vs Core 역할** (1문단)
3. **레거시 대비 개선** (1~3 bullet)

---

## 6. 설정 파일

- greenfield: `config/` 또는 `ini/` 중 TASK-002 RESULT에서 확정
- Worker·General·WorkInfo·Path·ManualRoboCopy 섹션은 TASK 사양 따름
- 비밀번호 등 민감정보 커밋 금지
