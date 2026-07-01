# TASK-012: Worker 상태·UI·통계·INI 저장

## 1. 메타

| Task ID | TASK-012 | F-12 | 선행 TASK-006, 007 | KB [07](../kb_migration_cursor_md/07_dashboard_ui_design.md), [08](../kb_migration_cursor_md/08_operator_ux_requirements.md) |

## 2. 목적

Worker 진행 상황·누적 통계를 Row UI에 표시하고 INI에 저장한다. **고빈도 이벤트에도 창이 응답 없음이 되지 않아야 한다.**

## 3. In / Out of Scope

**In:** 처리일자 라벨, 상태(조회/복사/Interval/대기/중지/완료), Progress 표시, 처리/성공/예외 누적, RunStart baseline+세션 카운트, INI 간헐 저장(WorkerStatsSaveIntervalSec, default 5), 완료/중지 force save, Row/전체 초기화+확인, Selected INI 저장.

**Out:** Logs 탭 split(TASK-013), 레거시 Timer flush API 복사.

## 4. 사용자 시나리오

- **Given** Worker 5000건 배치 **When** Row 처리 **Then** 상태·카운트 갱신, **UI 멈춤 없음**.
- **Given** 5초 경과 **When** 카운트 변경 **Then** INI Processed/Success/Failure 저장.
- **Given** Worker 완료 **When** — **Then** INI 즉시 저장.
- **Given** 초기화 **When** 확인 **Then** 누적 0, INI 반영 (실행 중 불가).

## 5. 입력 · 출력 · 설정

| UI | CurrentDateLabel, StatusLabel, CountLabel, ProgressBar |
| INI `[General]` | WorkerStatsSaveIntervalSec(5), WorkerLogFlushIntervalMs(500,min100) — **UI 갱신 정책은 How, 간격만 What** |
| INI `[Worker_n]` | ProcessedCount, SuccessCount, FailureCount, Selected |
| Failure UI | Failure+Missing+Small+AlreadyEncrypted 합산 |

## 6. 수용 기준

- [ ] 이벤트 1건=UI 1회 직접 갱신 패턴 **사용하지 않음** (RESULT에 대체 방식)
- [ ] 재시작 후 누적치 복원
- [ ] 처리일자 vs 프로세스 상태 라벨 분리
- [ ] ImplementationPrinciples §1.2 충족

## 7. 제약

- KB(07) 실시간 Dashboard — WinForms Row vs 차트 → RESULT

## 8. 검증

1. 대량 처리 중 Config 탭 전환·스크롤 가능
2. INI 누적 복원
3. Row 초기화·전체 초기화
4. 완료 후 force save
