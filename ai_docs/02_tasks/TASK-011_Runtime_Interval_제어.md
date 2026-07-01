# TASK-011: Runtime·Interval 제어

## 1. 메타

| Task ID | TASK-011 | F-11 | 선행 TASK-003, 008 | KB [04](../kb_migration_cursor_md/04_worker_parallel_processing.md) |

## 2. 목적

Worker는 **배치 진입 전**·**Interval 대기 중** Runtime(평일/주말)을 재확인하고, 범위 밖이면「Runtime 범위 외 중지」로 정상 종료한다. 배치 사이 **IntervalSec** 대기(0=즉시 다음 배치).

## 3. In / Out of Scope

**In:** Config Runtime → Worker, Interval 초 단위 대기·남은 초 상태 표시, Interval 중 Runtime 이탈 시 중지, 취소 시 Interval 중단.

**Out:** 스케줄러 tick(TASK-003).

## 4. 사용자 시나리오

- **Given** Interval 10 **When** 배치 완료 **Then**「Interval 대기 중.. N」10→1.
- **Given** Interval 중 18:00 Runtime 종료 **When** tick **Then** 다음 배치 없이 Runtime 범위 외 중지.
- **Given** Interval 0 **When** 배치 완료 **Then** 즉시 다음 배치( Runtime 허용 시).

## 5. 입력 · 출력 · 설정

| Row | IntervalSec (Config Interval 기본값 가능) |
| Runtime | Worker Settings Weekday/Weekend Start/End |

## 6. 수용 기준

- [ ] 배치 직전 Runtime 검사
- [ ] Interval 1초 단위 Runtime 재검사(또는 동등 — RESULT)
- [ ] RuntimeOut 메시지 UI·로그

## 7. 제약

- Interval 대기도 UI freeze 없음

## 8. 검증

1. Interval 5 카운트다운 표시
2. Runtime 종료 시 중지
3. Interval 0 연속 배치
