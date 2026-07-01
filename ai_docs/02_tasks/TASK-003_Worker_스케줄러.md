# TASK-003: Worker 스케줄러

## 1. 메타

| 항목 | 값 |
|------|-----|
| Task ID | TASK-003 |
| 기능 ID | F-03 |
| 선행 Task | TASK-002 |
| KB | [04_worker_parallel_processing.md](../kb_migration_cursor_md/04_worker_parallel_processing.md) |

## 2. 목적

ToolStrip **Start**는 Worker 즉시 실행이 아니라 **스케줄러 시작**이다. `[WorkInfo].Interval` 주기로 Runtime(평일/주말)을 검사하고, Runtime 안에서 **체크된 대기 Worker**를 기동한다.

## 3. In / Out of Scope

**In:** Start/Stop 스케줄러, 1초 단위 타이머 + Interval 누적, Runtime 판정, `StartAllWorkers`(체크·비실행만), 실행 중 Worker 중복 시작 방지, Stop 시 전 Worker 중지 요청.

**Out:** Worker 내부 배치·마킹 (TASK-008~011), RetryCycle 레거시 배치.

## 4. 사용자 시나리오

- **Given** Start + Runtime 내 + 체크 Worker 2 **When** Interval 경과 **Then** 2 Worker 시작(이미 실행 중이면 스킵).
- **Given** Runtime 외 **When** tick **Then** 새 Worker 시작 없음, 상태「Out of job schedule」류 표시.
- **Given** Stop **When** 클릭 **Then** 스케줄러 중지 + 모든 Worker 중지 요청.
- **Given** Start + 체크 Worker 0 **When** Start **Then** MessageBox 안내.

## 5. 입력 · 출력 · 설정

| INI | `[WorkInfo]` Interval(초), WeekdayStart/End, WeekendStart/End, StartTime/EndTime(fallback) |
| UI | ToolStrip Start/Stop, lblStatus (대기 초 / Interval) |
| Runtime | 토/일=주말; Start==End → 24h; 자정 넘김 구간 지원 |

## 6. 수용 기준

- [ ] Start 시 Config 편집 비활성(또는 정책 RESULT 명시)
- [ ] Worker 실행 중 스케줄 tick이 와도 중복 시작 안 함
- [ ] 평일/주말 Runtime 분리 적용
- [ ] Stop 후 Start 재개 가능

## 7. 제약

- 스케줄러 tick은 UI 블로킹 없음
- KB(04): Orchestrator 패턴 가능 → RESULT

## 8. 검증

1. Runtime 09–18, 10시 Start → Worker 기동
2. Runtime 외 tick → 미기동
3. Worker 실행 중 tick → 중복 없음
4. Stop → 전 Worker「중지 요청」상태
