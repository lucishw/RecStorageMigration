# REVIEW-011: Runtime·Interval 제어

## 1. 메타
- **대응 Task:** TASK-011 | **Result:** RESULT-011 | **검토 상태:** 미검토

## 2. 코드 검토
- [ ] Worker·Form Runtime 로직 일치

## 3. 기능 검증 체크리스트
- [ ] 배치 전 Runtime 검사
- [ ] IntervalSec 카운트다운 UI
- [ ] Interval 중 Runtime 종료 → 중지
- [ ] 평일/주말 분기
- [ ] 00:00~00:00 = 24h

## 4. 빌드·실행 확인
- [ ] msbuild 성공
- [ ] Runtime 경계 시각 테스트

## 5. 예외·엣지
- [ ] Interval=0 즉시 다음 배치

## 6. KB·신규 전용
| ScheduleService | 제외 | 신규 전용 |

## 7. 보완 필요 사항
-

## 8. 배포 가능 여부
- [ ] 승인 / [ ] 보완필요
