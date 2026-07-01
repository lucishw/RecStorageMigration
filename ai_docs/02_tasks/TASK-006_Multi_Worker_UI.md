# TASK-006: Multi Worker UI

## 1. 메타

| Task ID | TASK-006 | F-06 | 선행 TASK-002 | KB [04](../kb_migration_cursor_md/04_worker_parallel_processing.md), [07](../kb_migration_cursor_md/07_dashboard_ui_design.md), [08](../kb_migration_cursor_md/08_operator_ux_requirements.md) |

## 2. 목적

운영자가 **Worker Row**를 추가·삭제·선택하고, Row별 Top/Interval/날짜/Where/마킹/DB 옵션을 편집한다. 넓은 화면에서 **2열** 배치.

## 3. In / Out of Scope

**In:** FlowLayout 동적 Row, W{n} 체크, Top/Interval/From/To/Mark/Where/Config DB/Year Table, 시작·중지·초기화, 전체선택·작업자추가·선택삭제·전체현황·전체초기화 버튼, INI에서 Worker 복원·CPU 개수 기본 생성, 실행 중 Row 편집 잠금.

**Out:** Worker Core 루프, Logs split(TASK-013).

## 4. 사용자 시나리오

- **Given** 작업자 추가 **When** 클릭 **Then** 새 W{n} Row, INI `[Workers]` 갱신.
- **Given** 실행 중 Row **When** 삭제 시도 **Then** 삭제 불가 안내.
- **Given** 창 너비 ≥ 2열 임계 **When** 리사이즈 **Then** 2열 배치.
- **Given** INI Worker 3개 **When** 시작 **Then** 3 Row 복원.

## 5. 입력 · 출력 · 설정

| Row UI | Select, Top, Interval, From/To, MarkField/Value, Where, Config DB, DBName, Year Table, 처리일자 라벨, 상태, Progress, 처리/성공/예외, 시작/중지/초기화 |
| INI `[Worker_n]` | TopCount, IntervalSec, FromDate, ToDate, Selected, MarkField, MarkValue, SelectCondition, UseConfigDBName, DBName, UseYearTableMarking, Processed/Success/FailureCount |
| INI `[Workers]` | Count, WorkerIds, NextWorkerId |

## 6. 수용 기준

- [ ] Row별 독립 설정·체크 상태 INI 저장/복원
- [ ] 실행 중 해당 Row 입력 잠금
- [ ] 선택 삭제 시 확인 창 + 실행 중 제외
- [ ] UI non-blocking (ImplementationPrinciples)

## 7. 제약

- KB(07) Dashboard — WinForms Row vs 차트 → RESULT

## 8. 검증

1. Worker 추가/삭제/INI 유지
2. 2열/1열 리사이즈
3. 실행 중 편집 불가
4. 전체 선택(실행 중 제외)
