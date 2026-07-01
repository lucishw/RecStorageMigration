# DB 기반 파일 처리 구조

## 목표

마이그레이션 대상 파일을 파일 시스템 스캔이 아니라 DB 데이터를 기준으로 처리한다.

## 기본 흐름

```text
1. DB에서 처리 대상 파일 목록 Batch 조회
2. 조회된 대상 파일을 Work Queue에 적재
3. Worker가 Queue에서 작업을 가져감
4. Worker가 원본 파일 존재 여부 확인
5. Worker가 기존 스토리지에서 TOBE 스토리지로 파일 복제
6. Worker가 처리 결과를 Result Queue에 적재
7. Bulk Update Service가 결과를 DB에 묶어서 반영
8. Dashboard가 처리 현황을 실시간 표시
```

## DB 대상 파일 정보 예시

마이그레이션 대상 파일 테이블에는 다음 정보가 필요하다.

| 컬럼 | 설명 |
|---|---|
| FileId | 파일 고유 ID |
| SourcePath | 원본 파일 경로 |
| TargetPath | 대상 파일 경로 |
| FileSize | 파일 크기 |
| FileExtension | 파일 확장자 |
| Status | 처리 상태 |
| RetryCount | 재시도 횟수 |
| ErrorCode | 오류 코드 |
| ErrorMessage | 오류 메시지 |
| StartedAt | 처리 시작 시각 |
| CompletedAt | 처리 완료 시각 |
| WorkerId | 처리 Worker ID |
| CreatedAt | 생성 시각 |
| UpdatedAt | 수정 시각 |

## 상태값 예시

| 상태 | 의미 |
|---|---|
| Pending | 처리 대기 |
| Processing | 처리 중 |
| Success | 복제 성공 |
| Failed | 복제 실패 |
| MissingSource | 원본 파일 없음 |
| RetryPending | 재시도 대기 |
| Skipped | 처리 제외 |

## Cursor 지침

```md
마이그레이션 대상 파일은 DB 데이터를 기준으로 조회한다.

파일 처리 프로세스는 DB에서 대상 목록을 Batch 단위로 조회하고, Worker가 파일 복제를 수행한 뒤, 처리 결과를 Result Queue에 적재하고, Bulk Update Service가 DB에 묶어서 반영하는 구조로 구현한다.

Worker가 각 파일 처리마다 DB를 직접 업데이트하지 않도록 한다.

DB 테이블에는 파일 경로, 대상 경로, 파일 크기, 처리 상태, 오류 정보, 재시도 횟수, 처리 시각, Worker ID를 기록할 수 있어야 한다.
```
