# REVIEW-004: Source DB 설정

## 1. 메타
- **대응 Task:** TASK-004
- **대응 Result:** RESULT-004
- **검토자:**
- **검토일:**
- **검토 상태:** 미검토

## 2. 코드 검토
- [ ] Task 범위 외 변경 없음
- [ ] Worker별 독립 DB 연결

## 3. 기능 검증 체크리스트
- [ ] Source DB 연결·조회
- [ ] Trust Server 옵션
- [ ] Worker DBName override
- [ ] Year Table 마킹 테이블명

## 4. 빌드·실행 확인
- [ ] msbuild 성공
- [ ] 테스트 DB 또는 mock으로 연결 확인

## 5. 예외·엣지 확인
- [ ] DB 연결 실패 로그
- [ ] ValidateWorkerSettings

## 6. KB·신규 전용 구분
| 항목 | 현재 검증 | 비고 |
|------|-----------|------|
| Bulk Update | 제외 | 신규 전용 (KB-05) |

## 7. 보완 필요 사항
-

## 8. 배포 가능 여부
- [ ] 승인
- [ ] 보완필요
