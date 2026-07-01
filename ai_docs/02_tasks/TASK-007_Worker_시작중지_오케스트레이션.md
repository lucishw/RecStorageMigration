# TASK-007: Worker 시작/중지 오케스트레이션

## 1. 메타

| Task ID | TASK-007 | F-07 | 선행 TASK-003, 006 | KB [04](../kb_migration_cursor_md/04_worker_parallel_processing.md) |

## 2. 목적

Row **시작/중지**, 스케줄러 **StartAll**, ToolStrip **Stop**이 Core Worker를 기동·취소하고 UI 상태(버튼·Progress)를 갱신한다.

## 3. In / Out of Scope

**In:** Row 시작(설정 검증), Row 중지(취소), 전 Worker 중지, BuildWorkerSettings(Row+전역), Validate(날짜 yyyy-MM-dd, Top>0, TargetPath, Mapping), RunStart*Total baseline, 완료/오류/중지 시 상태·INI 저장.

**Out:** 배치 내부·마킹(TASK-008~010).

## 4. 사용자 시나리오

- **Given** 대기 Row **When** 시작 **Then** 백그라운드 Worker 실행, Start 비활성·Stop 활성.
- **Given** 실행 Row **When** 중지 **Then**「중지 요청」, 협력적 종료 후「중지됨」.
- **Given** 설정 오류 **When** 시작 **Then** MessageBox, 기동 안 함.
- **Given** 스케줄러 StartAll **When** Runtime 내 **Then** 체크·대기 Row만 시작.

## 5. 입력 · 출력 · 설정

| 검증 | Source DB/Table, MarkField, Top, Interval≥0, From/To date, TargetPath, I360 시 Mapping |
| 상태 | 작업 시작 → 조회 → N건 조회 → 파일 복사 중 → Interval 대기 → 완료/Runtime 범위 외 중지 |
| Runtime 전달 | Weekday/Weekend Start/End → Worker |

## 6. 수용 기준

- [ ] UI 스레드에서 DB/파일 I/O 없음
- [ ] Worker당 CancellationToken
- [ ] 완료 시 누적 통계 INI force save
- [ ] How(UI↔Worker): RESULT 필수

## 7. 제약

- 레거시 Invoke/Timer 패턴 복사 금지

## 8. 검증

1. Row 시작→중지→중지됨
2. 잘못된 FromDate → 오류
3. 2 Worker 동시 실행
4. Stop All
