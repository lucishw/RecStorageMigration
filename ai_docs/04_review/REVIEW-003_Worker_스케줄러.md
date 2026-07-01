# REVIEW-003: Worker 스케줄러

## 1. 메타
- **대응 Task:** TASK-003
- **대응 Result:** RESULT-003
- **검토자:**
- **검토일:**
- **검토 상태:** 미검토

## 2. 코드 검토
- [ ] Task 범위 외 변경 없음
- [ ] 명명·주석·로그 규칙 준수

## 3. 기능 검증 체크리스트
- [ ] tsbStart → 스케줄러 ON
- [ ] tsbStop → Worker 전체 중지 + 스케줄러 OFF
- [ ] Runtime 외 Worker 미시작
- [ ] 체크 idle Worker만 시작
- [ ] 실행 중 중복 시작 방지
- [ ] Auto Start 동작

## 4. 빌드·실행 확인
- [ ] msbuild 성공
- [ ] Interval·Runtime 조합 스모크

## 5. 예외·엣지 확인
- [ ] Runtime 외 상태 문구
- [ ] 체크 Worker 없음

## 6. KB·신규 전용 구분
| 항목 | 현재 검증 | 비고 |
|------|-----------|------|
| BackgroundService 스케줄 | 제외 | 신규 전용 |

## 7. 보완 필요 사항
-

## 8. 배포 가능 여부
- [ ] 승인
- [ ] 보완필요
