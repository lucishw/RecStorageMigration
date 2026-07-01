# REVIEW-006: Multi Worker UI

## 1. 메타
- **대응 Task:** TASK-006
- **대응 Result:** RESULT-006
- **검토자:**
- **검토일:**
- **검토 상태:** 미검토

## 2. 코드 검토
- [ ] Designer 고정 + Row 동적 분리

## 3. 기능 검증 체크리스트
- [ ] INI Worker 로드·CPU count fallback
- [ ] 작업자 추가/선택삭제/전체선택
- [ ] 2열 FlowLayout
- [ ] 실행 중 Row 입력 잠금
- [ ] Logs RadioButton 동적 생성

## 4. 빌드·실행 확인
- [ ] msbuild 성공
- [ ] Row 추가·삭제·INI 유지

## 5. 예외·엣지 확인
- [ ] 실행 중 Worker 삭제 차단

## 6. KB·신규 전용 구분
| 항목 | 현재 검증 | 비고 |
|------|-----------|------|
| Dashboard·그래프 | 제외 | 신규 전용 (KB-07) |

## 7. 보완 필요 사항
-

## 8. 배포 가능 여부
- [ ] 승인
- [ ] 보완필요
