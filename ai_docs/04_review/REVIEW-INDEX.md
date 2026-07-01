# REVIEW-INDEX — Task별 개발자 검토·테스트 체크리스트

> TASK·RESULT와 **1:1 대응**. 개발자가 수동 검증 시 사용한다.  
> [`kb_migration_cursor_md/10_verification_scenarios.md`](../kb_migration_cursor_md/10_verification_scenarios.md)에서 **현재 프로그램에 해당하는 F-00x만** 발췌한다.  
> Bulk Update, Bandwidth, Dashboard 등 **신규(.NET 8) 전용** 항목은 "신규 전용"으로 표시하고 현재 검증에서 제외한다.

---

## 1. 검토 문서 목록

| Review ID | 대응 Task | Result | 파일명 | 검토 상태 | 검토일 |
|-----------|-----------|--------|--------|-----------|--------|
| REVIEW-001 | TASK-001 | RESULT-001 | [REVIEW-001_프로그램_시작_및_공통초기화.md](REVIEW-001_프로그램_시작_및_공통초기화.md) | 미검토 | — |
| REVIEW-002 | TASK-002 | RESULT-002 | [REVIEW-002_INI_설정_및_Config탭.md](REVIEW-002_INI_설정_및_Config탭.md) | 미검토 | — |
| REVIEW-003 | TASK-003 | RESULT-003 | [REVIEW-003_Worker_스케줄러.md](REVIEW-003_Worker_스케줄러.md) | 미검토 | — |
| REVIEW-004 | TASK-004 | RESULT-004 | [REVIEW-004_Source_DB_설정.md](REVIEW-004_Source_DB_설정.md) | 미검토 | — |
| REVIEW-005 | TASK-005 | RESULT-005 | [REVIEW-005_경로_설정_및_PathMapping.md](REVIEW-005_경로_설정_및_PathMapping.md) | 미검토 | — |
| REVIEW-006 | TASK-006 | RESULT-006 | [REVIEW-006_Multi_Worker_UI.md](REVIEW-006_Multi_Worker_UI.md) | 미검토 | — |
| REVIEW-007 | TASK-007 | RESULT-007 | [REVIEW-007_Worker_시작중지_오케스트레이션.md](REVIEW-007_Worker_시작중지_오케스트레이션.md) | 미검토 | — |
| REVIEW-008 | TASK-008 | RESULT-008 | [REVIEW-008_Worker_DB조회_배치루프.md](REVIEW-008_Worker_DB조회_배치루프.md) | 미검토 | — |
| REVIEW-009 | TASK-009 | RESULT-009 | [REVIEW-009_파일경로_생성.md](REVIEW-009_파일경로_생성.md) | 미검토 | — |
| REVIEW-010 | TASK-010 | RESULT-010 | [REVIEW-010_파일복사_예외처리_마킹.md](REVIEW-010_파일복사_예외처리_마킹.md) | 미검토 | — |
| REVIEW-011 | TASK-011 | RESULT-011 | [REVIEW-011_Runtime_Interval_제어.md](REVIEW-011_Runtime_Interval_제어.md) | 미검토 | — |
| REVIEW-012 | TASK-012 | RESULT-012 | [REVIEW-012_Worker_상태_UI_통계_INI저장.md](REVIEW-012_Worker_상태_UI_통계_INI저장.md) | 미검토 | — |
| REVIEW-013 | TASK-013 | RESULT-013 | [REVIEW-013_로그_및_전체현황_리포트.md](REVIEW-013_로그_및_전체현황_리포트.md) | 미검토 | — |
| REVIEW-014 | TASK-014 | RESULT-014 | [REVIEW-014_Manual_RoboCopy.md](REVIEW-014_Manual_RoboCopy.md) | 미검토 | — |

**검토 상태:** `미검토` | `검토중` | `승인` | `보완필요`

---

## 2. REVIEW 문서 템플릿

```markdown
# REVIEW-xxx: [Task 기능명]

## 1. 메타
- **대응 Task:** TASK-xxx
- **대응 Result:** RESULT-xxx
- **검토자:**
- **검토일:** YYYY-MM-DD

## 2. 코드 검토
- [ ] Task 범위 외 변경 없음
- [ ] 명명·주석·로그 규칙 준수
- [ ] 예외 처리 적절

## 3. 기능 검증 체크리스트
(TASK §9 재구현 체크리스트를 복사·확장)

- [ ] ...
- [ ] ...

## 4. 빌드·실행 확인
- [ ] msbuild 성공 (Configuration / Platform 명시)
- [ ] 프로그램 기동·해당 기능 스모크 테스트

## 5. 예외·엣지 확인
- [ ] (TASK §8 항목별)

## 6. KB·신규 전용 구분
| 항목 | 현재 검증 | 비고 |
|------|-----------|------|
| Row UPDATE 마킹 | 해당 | |
| Bulk Update | 제외 | 신규 전용 |
| Bandwidth 제한 | 제외 | 신규 전용 |
| Dashboard UI | 제외 | 신규 전용 |

## 7. 보완 필요 사항
-

## 8. 배포 가능 여부
- [ ] 승인 — RELEASE 반영 가능
- [ ] 보완필요 — RESULT 보완 후 재검토
```

---

## 3. 검토 절차

1. 해당 **RESULT-xxx** 작성 완료 확인
2. REVIEW-xxx 체크리스트로 수동 테스트
3. `10_verification_scenarios.md`에서 F-00x 해당 시나리오만 추가 (신규 전용 표시)
4. 본 INDEX **검토 상태·검토일** 갱신
5. 전 Task 승인 후 [`05_release/`](../05_release/) RELEASE 문서 작성
