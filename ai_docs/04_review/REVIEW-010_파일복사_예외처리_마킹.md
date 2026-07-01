# REVIEW-010: 파일 복사·예외처리·마킹

## 1. 메타
- **대응 Task:** TASK-010 | **Result:** RESULT-010 | **검토 상태:** 미검토

## 2. 코드 검토
- [ ] Row UPDATE 즉시 반영
- [ ] File.Exists 미사용

## 3. 기능 검증 체크리스트
- [ ] 마킹 1/2/5/6 코드표
- [ ] temp 2단계 Copy
- [ ] 1KB 이하 → 6
- [ ] FileNotFound → 2
- [ ] Year Table UPDATE

## 4. 빌드·실행 확인
- [ ] msbuild 성공
- [ ] 테스트 파일 1건 copy+mark (스테이징)

## 5. 예외·엣지
- [ ] UPDATE 0/2 rows 로그
- [ ] TelNo AES (KMSInfo=1)

## 6. KB·신규 전용
| Bulk Update | 제외 | KB-05 |
| KMS 암호화 | 제외 | Non-Goal |

## 7. 보완 필요 사항
-

## 8. 배포 가능 여부
- [ ] 승인 / [ ] 보완필요

## 참고
- [10_verification_scenarios.md](../kb_migration_cursor_md/10_verification_scenarios.md) F-010 해당 시나리오만 발췌
