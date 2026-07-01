# TASK-013: 로그 및 전체 현황 리포트

## 1. 메타

| Task ID | TASK-013 | F-13 | 선행 TASK-007, 012 | KB [08](../kb_migration_cursor_md/08_operator_ux_requirements.md) |

## 2. 목적

**메인 오케스트레이션 로그**와 **Worker별 로그**를 Logs 탭에서 확인하고, Multi Worker **전체 현황 리포트**를 제공한다.

## 3. In / Out of Scope

**In:** Logs 좌우 split(메인/Worker), Worker Radio 선택,「전체 Worker 로그」그리드 옵션, Worker 로그 파일 `worker_{n}_{date}_{app}.log` / Err, 메인 로그, Worker 로그 메모리 상한·배치 표시(고빈도 non-blocking), 전체현황 다이얼로그(요약+Worker 표, 복사).

**Out:** StatusReader DB 집계 UI.

## 4. 사용자 시나리오

- **Given** Worker 1 선택 **When** Logs **Then** W1 로그만 우측 표시.
- **Given** 전체 Worker 로그 체크 **When** — **Then** 그리드에 Worker별 패널.
- **Given** 전체현황 **When** 클릭 **Then** Total/RUNNING/Processed/Success/Failure/SuccessRate + Worker별 표.

## 5. 입력 · 출력 · 설정

| 로그 | `[Success]`, `[Failure]`, `[Info___]`, `[Status_]` 등 태그 |
| INI | LogView 옵션 (ShowMainLog, ShowAllWorkerLogs 등) |
| Retention | LogRetentionPeriod 일 |

## 6. 수용 기준

- [ ] Worker 로그 파일 분리
- [ ] 선택 Worker만 우측 flush (또는 동등 — RESULT)
- [ ] 로그 폭주 시 UI freeze 없음
- [ ] 리포트 텍스트 클립보드 복사

## 7. 제약

- UI Thread 동기 대량 ListBox Append 금지 (Principles)

## 8. 검증

1. W1/W2 로그 분리
2. 전체현황 숫자 vs Row 일치
3. 장시간 Worker 로그 UI 반응성
