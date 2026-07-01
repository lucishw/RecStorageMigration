# DB 병목 최소화 및 Bulk Update 구조

## 목표

파일 처리는 병렬로 수행하되, DB 접근은 병목이 되지 않도록 Batch 조회와 Bulk Update 방식으로 제어한다.

## 주요 문제

파일을 병렬로 복제하면서 각 Worker가 파일 한 건마다 DB를 업데이트하면 다음 문제가 발생할 수 있다.

- DB Connection Pool 고갈
- UPDATE 과다 발생
- Lock 경합 증가
- Deadlock 가능성 증가
- 전체 처리 속도 저하
- DB가 파일 처리보다 먼저 병목이 되는 상황 발생

## 설계 방향

- 대상 목록 조회는 Batch 단위로 수행한다.
- Worker는 DB를 직접 자주 호출하지 않는다.
- 처리 결과는 Result Queue 또는 Buffer에 적재한다.
- Bulk Update Service가 일정 건수 또는 일정 시간마다 DB에 반영한다.
- 프로그램 종료 시 남은 결과를 반드시 Flush한다.

## Bulk Update Trigger 조건 예시

| 조건 | 설명 |
|---|---|
| 건수 기준 | Result Queue에 500건 이상 쌓이면 Bulk Update |
| 시간 기준 | 3초마다 한 번씩 Bulk Update |
| 종료 기준 | 프로그램 종료 시 남은 결과 Flush |
| 수동 기준 | 운영자가 Flush 버튼 클릭 시 즉시 반영 |

## Bulk Update 데이터 예시

| 항목 | 설명 |
|---|---|
| FileId | 파일 ID |
| Status | 처리 상태 |
| WorkerId | Worker ID |
| SourcePath | 원본 경로 |
| TargetPath | 대상 경로 |
| FileSize | 파일 크기 |
| StartedAt | 시작 시각 |
| CompletedAt | 완료 시각 |
| RetryCount | 재시도 횟수 |
| ErrorCode | 오류 코드 |
| ErrorMessage | 오류 메시지 |

## Cursor 지침

```md
DB 업데이트는 파일 한 건 처리할 때마다 즉시 수행하지 않는다.

각 Worker의 처리 결과는 Result Queue 또는 Buffer에 적재한다.

Bulk Update Service가 설정된 건수 또는 시간 기준으로 처리 결과를 DB에 묶어서 반영한다.

DB Connection Pool 고갈, Lock 경합, Deadlock 가능성을 최소화하도록 설계한다.

프로그램 종료, 중지, 예외 발생 시에도 Result Queue에 남아 있는 처리 결과를 반드시 Flush한다.
```
