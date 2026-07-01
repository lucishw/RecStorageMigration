# REVIEW-014: Manual RoboCopy

## 1. 메타
- **대응 Task:** TASK-014 | **Result:** RESULT-014 | **검토 상태:** 미검토

## 2. 코드 검토
- [ ] Process redirect·Cancel·Timeout

## 3. 기능 검증 체크리스트
- [ ] Preview 명령 생성
- [ ] Start/Stop 백그라운드
- [ ] /MIR 확인 MessageBox
- [ ] INI Save/Load
- [ ] Report /LOG, summary
- [ ] ExitCode ≤ 7 성공

## 4. 빌드·실행 확인
- [ ] msbuild 성공
- [ ] DryRun (/L) 스모크

## 5. 예외·엣지
- [ ] Source 없음 차단
- [ ] Timeout Kill

## 6. KB·신규 전용
| Bandwidth | 제외 | KB-06 |

## 7. 보완 필요 사항
-

## 8. 배포 가능 여부
- [ ] 승인 / [ ] 보완필요
