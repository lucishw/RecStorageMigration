# 기능 검증 및 성능 검증 시나리오

## 목표

개발된 프로그램에 대해 기능 검증과 성능 검증을 수행할 수 있도록 검증 시나리오를 작성한다.

1차 검증은 AI 또는 자동화 테스트로 수행하고, 2차 검증은 사람이 직접 확인하는 방식으로 진행한다.

## 기능 검증 항목

| 번호 | 검증 항목 | 기대 결과 |
|---|---|---|
| F-001 | DB 대상 파일 조회 | Pending 상태의 대상 파일이 Batch 단위로 조회된다. |
| F-002 | 파일 복제 성공 | 원본 파일이 대상 경로에 정상 복제된다. |
| F-003 | 누락 파일 처리 | 원본 파일이 없으면 MissingSource 상태로 기록된다. |
| F-004 | 접근 불가 파일 처리 | 권한 오류 발생 시 Failed 상태와 오류 메시지가 기록된다. |
| F-005 | 재시도 처리 | 실패 파일은 MaxRetryCount 기준으로 재시도된다. |
| F-006 | Bulk Update | 처리 결과가 건건이 아니라 Bulk로 DB에 반영된다. |
| F-007 | Worker 병렬 처리 | 설정된 WorkerCount만큼 병렬 처리된다. |
| F-008 | Worker 상태 표시 | Worker별 상태가 대시보드에 표시된다. |
| F-009 | Bandwidth 제한 | 설정된 Network Bandwidth Limit을 초과하지 않도록 제어된다. |
| F-010 | 프로그램 중단/재시작 | 중단 후 재시작 시 미처리/실패 건을 이어서 처리할 수 있다. |

## 성능 검증 항목

| 번호 | 검증 항목 | 측정 지표 |
|---|---|---|
| P-001 | Worker 수 변화에 따른 성능 | files/sec, MB/sec |
| P-002 | Batch Size 변화에 따른 DB 부하 | DB CPU, Lock, Query Time |
| P-003 | Bulk Update Size 변화에 따른 처리량 | Update/sec, Bulk latency |
| P-004 | 대용량 파일 처리 성능 | MB/sec, Network 사용량 |
| P-005 | 소용량 다건 파일 처리 성능 | files/sec, DB Update latency |
| P-006 | Bandwidth 제한 적용 성능 | Limit 대비 사용률 |
| P-007 | 장시간 실행 안정성 | Memory 증가량, 오류 건수 |
| P-008 | 장애 상황 복구 | 재시작 후 재처리 성공률 |

## 대시보드 검증 항목

- 전체 진행률이 정상 계산되는가?
- Worker별 처리 건수가 정상 표시되는가?
- 실패 건수가 정상 표시되는가?
- Network 사용량이 실시간 표시되는가?
- CPU/Memory/Disk I/O가 표시되는가?
- 최근 오류 목록이 갱신되는가?
- 예상 남은 시간이 합리적으로 계산되는가?

## Cursor 지침

```md
개발 완료 후 기능 검증과 성능 검증을 수행할 수 있도록 테스트 시나리오를 작성한다.

DB 대상 파일 조회, 파일 복제, 누락 파일 처리, 실패 파일 재시도, Bulk Update, Worker 병렬 처리, Network Bandwidth 제한, 대시보드 실시간 갱신, 프로그램 중단 후 재시작 처리를 검증한다.

성능 검증에서는 WorkerCount, DbFetchSize, DbBulkUpdateSize, NetworkBandwidthLimit 값을 변경하면서 처리량과 병목 지점을 측정한다.
```
