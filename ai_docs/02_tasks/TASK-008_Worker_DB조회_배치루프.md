# TASK-008: Worker DB 조회·배치 루프

## 1. 메타

| Task ID | TASK-008 | F-08 | 선행 TASK-004, 007 | KB [03](../kb_migration_cursor_md/03_db_based_file_processing.md), [05](../kb_migration_cursor_md/05_db_bulk_update_and_bottleneck.md) |

## 2. 목적

Worker가 **FromDate~ToDate**를 하루씩 순회하며, 각 날짜에 **Top N** 미처리 Row를 조회하고 Row 단위 처리 루프를 반복한다. 조회 결과 0건이면 다음 날짜로.

## 3. In / Out of Scope

**In:** `Select Top N ... WITH (NOLOCK) WHERE Date='yyyy-MM-dd' AND (SelectCondition) AND (MarkField IS NULL OR '')`, 필드 FileName, ServerName, Date, Started, DialedNumber, CallerNumber + I360/Audiolog 보조 필드, 배치마다 DB 연결 open/dispose.

**Out:** 파일 복사·마킹(TASK-010), Runtime wait(TASK-011).

## 4. 사용자 시나리오

- **Given** 2026-06-22 미처리 8000건, Top 5000 **When** 배치 **Then** 5000건 조회·처리 후 다음 배치(Interval 후).
- **Given** 해당일 0건 **When** 조회 **Then** 다음 날짜.
- **Given** ToDate 도달·0건 **Then** Worker 정상 완료.

## 5. 입력 · 출력 · 설정

| Row 설정 | TopCount(기본5000), SelectCondition, FromDate, ToDate |
| 쿼리 | 일자=`Date` equality, 미마킹만 |
| 로그 | Query 문자열, Count |

## 6. 수용 기준

- [ ] 배치마다 독립 DB 연결
- [ ] 조회 실패 시 Failure 증가·로그
- [ ] 취소 토큰 시 루프 종료·Cancelled
- [ ] KB: Row 단위 조회 (Bulk fetch는 RESULT)

## 7. 제약

- 디렉터리 스캔 금지

## 8. 검증

1. Top 10 테스트 DB → 10건씩
2. MarkField 채워진 Row 제외
3. SelectCondition 필터
4. 중지 시 배치 중단
