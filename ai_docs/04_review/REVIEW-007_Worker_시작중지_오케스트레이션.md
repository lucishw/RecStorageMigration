# REVIEW-007: Worker 시작·중지 오케스트레이션

## 1. 메타
- **대응 Task:** TASK-007
- **대응 Result:** RESULT-007
- **검토자:**
- **검토일:**
- **검토 상태:** 미검토

## 2. 코드 검토
- [ ] UI thread Invoke/BeginInvoke
- [ ] LongRunning Task

## 3. 기능 검증 체크리스트
- [ ] Row 시작/중지
- [ ] tsbStart/Stop 연동
- [ ] 중복 시작 방지
- [ ] Cancel → 중지됨
- [ ] FinishWorker INI save

## 4. 빌드·실행 확인
- [ ] msbuild 성공
- [ ] Worker 1건 start/stop UI 응답 유지

## 5. 예외·엣지 확인
- [ ] Validate 실패 MessageBox
- [ ] Runtime 외 종료 메시지

## 6. KB·신규 전용 구분
| 항목 | 현재 검증 | 비고 |
|------|-----------|------|
| Worker Pool/Channel | 제외 | 신규 전용 |

## 7. 보완 필요 사항
-

## 8. 배포 가능 여부
- [ ] 승인
- [ ] 보완필요
