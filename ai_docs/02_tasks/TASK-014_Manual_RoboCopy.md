# TASK-014: Manual RoboCopy

## 1. 메타

| Task ID | TASK-014 | F-14 | 선행 TASK-002 | KB — |

## 2. 목적

DB Worker와 **독립**으로 `robocopy.exe`를 UI에서 실행·중지하고, 옵션·명령 미리보기·로그·선택적 리포트 파일을 제공한다.

## 3. In / Out of Scope

**In:** Source/Target 경로, 패턴, /E /MIR /L /R /W /MT, ExtraOptions, DryRun/Mirror 확인, Timeout, SuccessExitCodeMax(0–7), Report log/summary, Start/Stop/Save INI, 실행 중 입력 잠금.

**Out:** Worker 스케줄 연동, DB 마킹.

## 4. 사용자 시나리오

- **Given** 유효 경로 **When** Preview **Then** 명령 문자열 표시.
- **Given** Mirror 체크 **When** Start **Then** 경고 확인 후 실행.
- **Given** 실행 중 **When** Stop **Then** 프로세스 종료·로그 기록.
- **Given** Report ON **When** 완료 **Then** summary.txt + (옵션) 폴더 열기.

## 5. 입력 · 출력 · 설정

| INI `[ManualRoboCopy]` | RoboCopyPath, SourcePath, TargetPath, FilePattern, Retry, Wait, Thread, Timeout, SuccessExitCodeMax, ExtraOptions, IncludeSubdirectories, DryRun, Mirror, NoProgress, Report* |
| Exit | RoboCopy 0–7 성공 허용 |

## 6. 수용 기준

- [ ] Source≠Target, Source 존재 검증
- [ ] stdout/stderr 로그 non-blocking 표시
- [ ] Worker와 동시 실행 정책 RESULT 명시
- [ ] UI freeze 없음

## 7. 제약

- /MIR 데이터 손실 위험 — 확인 필수

## 8. 검증

1. DryRun /L
2. Stop 중간
3. Report 파일 생성
4. INI Save/Load
