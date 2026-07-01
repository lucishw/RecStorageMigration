# REVIEW-002: INI 설정 및 Config 탭

## 1. 메타
- **대응 Task:** TASK-002
- **대응 Result:** RESULT-002
- **검토자:**
- **검토일:**
- **검토 상태:** 미검토

## 2. 코드 검토
- [ ] Task 범위 외 변경 없음
- [ ] 명명·주석·로그 규칙 준수
- [ ] 예외 처리 적절

## 3. 기능 검증 체크리스트
- [ ] ReadINI/ShowINI/WriteINI
- [ ] 통합 Config 5그룹
- [ ] Path Mapping Grid ↔ INI
- [ ] DB PW Encode/Decode
- [ ] Save 시 Worker·RoboCopy 포함

## 4. 빌드·실행 확인
- [ ] msbuild 성공
- [ ] Config 편집·Save·재기동 후 값 유지

## 5. 예외·엣지 확인
- [ ] ReadINI parse 오류 MessageBox
- [ ] Legacy IIS/NetBios mapping fallback

## 6. KB·신규 전용 구분
| 항목 | 현재 검증 | 비고 |
|------|-----------|------|
| appsettings.json | 제외 | 신규 전용 |

## 7. 보완 필요 사항
-

## 8. 배포 가능 여부
- [ ] 승인
- [ ] 보완필요
