# REVIEW-008: Worker DB 조회·배치 루프

## 1. 메타
- **대응 Task:** TASK-008 | **Result:** RESULT-008 | **검토 상태:** 미검토

## 2. 코드 검토
- [ ] 배치당 using DBManager
- [ ] with (nolock) 쿼리

## 3. 기능 검증 체크리스트
- [ ] From~To 일별 루프
- [ ] Top N + SelectCondition + 미마킹 조건
- [ ] 0건 시 다음 날짜
- [ ] Cancel mid-batch

## 4. 빌드·실행 확인
- [ ] msbuild 성공
- [ ] 테스트 DB SELECT (Dry run)

## 5. 예외·엣지
- [ ] DB 실패 시 FailureCount

## 6. KB·신규 전용
| Bulk Update | 제외 | KB-05 |

## 7. 보완 필요 사항
-

## 8. 배포 가능 여부
- [ ] 승인 / [ ] 보완필요
