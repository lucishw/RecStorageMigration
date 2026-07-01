# REVIEW-005: 경로 설정 및 PathMapping

## 1. 메타
- **대응 Task:** TASK-005
- **대응 Result:** RESULT-005
- **검토자:**
- **검토일:**
- **검토 상태:** 미검토

## 2. 코드 검토
- [ ] Task 범위 외 변경 없음

## 3. 기능 검증 체크리스트
- [ ] Path Mapping Grid CRUD·INI
- [ ] I360 vs Audiolog 모드 분기
- [ ] Legacy mapping fallback
- [ ] Enabled=0 무시

## 4. 빌드·실행 확인
- [ ] msbuild 성공
- [ ] 샘플 mapping으로 Validate 통과

## 5. 예외·엣지 확인
- [ ] I360 + mapping 없음 → 시작 차단

## 6. KB·신규 전용 구분
| 항목 | 현재 검증 | 비고 |
|------|-----------|------|
| PathResolver 서비스 | 제외 | 신규 전용 |

## 7. 보완 필요 사항
-

## 8. 배포 가능 여부
- [ ] 승인
- [ ] 보완필요
