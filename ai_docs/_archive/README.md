# _archive — 레거시 문서

> 구 명칭: **RecStorageMigration** (Phase 0 이전 프로젝트·저장소 식별자). 본 폴더 내용은 역사 보존을 위해 수정하지 않는다.

본 폴더는 ai_docs Task 체계로 이관하기 **전** 프로젝트 요청·결과 문서를 보관한다.

| 파일 | 설명 | 이관 대상 |
|------|------|-----------|
| [request.md](request.md) | 초기 Multi-Worker 마이그레이션 요청 (Project Prompt) | `01_overview/개발_개요.md`, `02_tasks/TASK-xxx.md` |
| [request_result.md](request_result.md) | request.md 수행 결과·변경 요약 | (이관 완료, 참고만) |
| [rules_windows_dotnet_app.md](rules_windows_dotnet_app.md) | 범용 WinForms 개발 규칙 (구버전) | `00_rules/ImplementationPrinciples.md` |

**사용 규칙**

- **AI 구현 세션에서 로드 금지** ([`Rules.md`](../00_rules/Rules.md))
- 신규 구현 기록은 `03_results/RESULT-xxx.md`에만 작성한다.
- 본 archive는 **읽기 전용 참고**이며, TASK 본문과 중복 갱신하지 않는다.
