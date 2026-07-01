# RESULT-INDEX — Task별 구현·검증 결과

> TASK와 **1:1 대응**. greenfield 구현 완료 후 AI·개발자가 기록한다.  
> TASK 본문(사양)은 수정하지 않고, **How + 구현 내역**은 본 폴더에만 기록한다.  
> **현재 상태:** 전 Task `미작성` — [`00_rules/Templates.md`](../00_rules/Templates.md) §RESULT 참조.

---

## 1. 결과 문서 목록

| Result ID | 대응 Task | 파일명 | 상태 | 최종 갱신 |
|-----------|-----------|--------|------|-----------|
| RESULT-001 | TASK-001 | [RESULT-001_프로그램_시작_및_공통초기화.md](RESULT-001_프로그램_시작_및_공통초기화.md) | 미작성 | — |
| RESULT-002 | TASK-002 | [RESULT-002_INI_설정_및_Config탭.md](RESULT-002_INI_설정_및_Config탭.md) | 미작성 | — |
| RESULT-003 | TASK-003 | [RESULT-003_Worker_스케줄러.md](RESULT-003_Worker_스케줄러.md) | 미작성 | — |
| RESULT-004 | TASK-004 | [RESULT-004_Source_DB_설정.md](RESULT-004_Source_DB_설정.md) | 미작성 | — |
| RESULT-005 | TASK-005 | [RESULT-005_경로_설정_및_PathMapping.md](RESULT-005_경로_설정_및_PathMapping.md) | 미작성 | — |
| RESULT-006 | TASK-006 | [RESULT-006_Multi_Worker_UI.md](RESULT-006_Multi_Worker_UI.md) | 미작성 | — |
| RESULT-007 | TASK-007 | [RESULT-007_Worker_시작중지_오케스트레이션.md](RESULT-007_Worker_시작중지_오케스트레이션.md) | 미작성 | — |
| RESULT-008 | TASK-008 | [RESULT-008_Worker_DB조회_배치루프.md](RESULT-008_Worker_DB조회_배치루프.md) | 미작성 | — |
| RESULT-009 | TASK-009 | [RESULT-009_파일경로_생성.md](RESULT-009_파일경로_생성.md) | 미작성 | — |
| RESULT-010 | TASK-010 | [RESULT-010_파일복사_예외처리_마킹.md](RESULT-010_파일복사_예외처리_마킹.md) | 미작성 | — |
| RESULT-011 | TASK-011 | [RESULT-011_Runtime_Interval_제어.md](RESULT-011_Runtime_Interval_제어.md) | 미작성 | — |
| RESULT-012 | TASK-012 | [RESULT-012_Worker_상태_UI_통계_INI저장.md](RESULT-012_Worker_상태_UI_통계_INI저장.md) | 미작성 | — |
| RESULT-013 | TASK-013 | [RESULT-013_로그_및_전체현황_리포트.md](RESULT-013_로그_및_전체현황_리포트.md) | 미작성 | — |
| RESULT-014 | TASK-014 | [RESULT-014_Manual_RoboCopy.md](RESULT-014_Manual_RoboCopy.md) | 미작성 | — |

**상태 값:** `미작성` | `작성중` | `완료` | `보류`

---

## 2. RESULT 문서 템플릿

[`Templates.md`](../00_rules/Templates.md) §RESULT 및 각 `RESULT-xxx.md` 플레이스홀더를 따른다.

**필수:** §2 How (UI–Worker 연동, App/Core 분할, 레거시 대비 개선)

---

## 3. 기록 규칙

1. TASK 구현·검증 완료 시 해당 RESULT 파일을 작성하고 본 INDEX의 **상태·최종 갱신**을 갱신한다.
2. 기존 RESULT를 덮어쓸 때는 **갱신 이력**을 RESULT 본문 하단에 남긴다.
3. `_archive/`·`_analysis/`는 구현 세션에서 로드하지 않는다.
4. RESULT만으로 배포하지 않는다 — [`REVIEW-INDEX.md`](../04_review/REVIEW-INDEX.md) 검토 후 RELEASE 문서를 작성한다.
