# Worker 병렬 처리 구조

## 목표

기존처럼 프로그램을 여러 개 실행하는 방식이 아니라, 하나의 프로그램 내부에서 N개의 Worker를 운영한다.

## 핵심 방향

- 하나의 프로그램에서 Worker Pool을 구성한다.
- Worker 개수는 설정값으로 조정 가능해야 한다.
- 각 Worker는 독립적으로 파일 복제를 수행한다.
- Worker 상태는 대시보드에서 실시간으로 확인 가능해야 한다.
- Worker별 처리 건수, 실패 건수, 현재 파일, 처리 속도를 표시한다.

## 설정 항목 예시

```json
{
  "Migration": {
    "WorkerCount": 8,
    "DbFetchSize": 1000,
    "DbBulkUpdateSize": 500,
    "MaxRetryCount": 3,
    "SourceRootPath": "\\source-storage\data",
    "TargetRootPath": "\\target-storage\data",
    "NetworkBandwidthLimitMbps": 500,
    "DashboardRefreshIntervalMs": 1000
  }
}
```

## Worker 처리 흐름

```text
1. Work Queue에서 파일 작업 가져오기
2. Worker 상태를 Processing으로 변경
3. 원본 파일 존재 여부 확인
4. 대상 디렉터리 생성
5. 파일 복제 수행
6. 필요 시 파일 크기 또는 해시 검증
7. 처리 결과 생성
8. Result Queue에 처리 결과 적재
9. Worker 통계 갱신
10. 다음 작업 처리
```

## Worker별 상태 정보

| 항목 | 설명 |
|---|---|
| WorkerId | Worker 식별자 |
| Status | Idle, Processing, Error, Stopped |
| CurrentFile | 현재 처리 중인 파일 |
| CompletedCount | 완료 건수 |
| FailedCount | 실패 건수 |
| BytesCopied | 복제한 바이트 수 |
| CurrentSpeed | 현재 처리 속도 |
| AverageSpeed | 평균 처리 속도 |
| LastProcessedAt | 마지막 처리 시각 |
| LastErrorMessage | 마지막 오류 메시지 |

## Cursor 지침

```md
하나의 프로그램 내부에서 Worker Pool을 구성하여 병렬 파일 복제를 수행한다.

Worker 개수는 설정값으로 변경 가능해야 한다.

각 Worker는 Work Queue에서 작업을 가져와 파일 복제를 수행하고, 처리 결과를 Result Queue에 적재한다.

대시보드에서 Worker별 상태, 현재 처리 파일, 처리 완료 건수, 실패 건수, 처리 속도, 오류 메시지를 실시간으로 확인할 수 있도록 한다.
```
