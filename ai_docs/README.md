# ai_docs — RecFileMigrationTool greenfield 재구현

## 저장소

- **Remote:** https://github.com/lucishw/RecStorageMigration
- **기본 브랜치:** `main` (Phase 0 단일 initial commit)

## 읽기 순서 (구현 세션)

1. [`00_rules/Rules.md`](00_rules/Rules.md)
2. [`00_rules/ImplementationPrinciples.md`](00_rules/ImplementationPrinciples.md)
3. [`02_tasks/TASK-INDEX.md`](02_tasks/TASK-INDEX.md)
4. **현재 TASK 1개만**

## 구조

| 폴더 | 용도 |
|------|------|
| `00_rules/` | 워크플로, 구현 원칙, 템플릿 |
| `01_overview/` | 프로그램 개요 (What) |
| `02_tasks/` | 기능 Task 14건 |
| `03_results/` | AI 구현·How 기록 |
| `04_review/` | 개발자 검증 |
| `05_release/` | 배포 스냅샷 |
| `_analysis/` | Task 작성용 행위 추출 (**구현 시 로드 금지**) |
| `kb_migration_cursor_md/` | 신규 설계 KB (TASK별 링크만) |
| `_archive/` | 이관 문서 (**로드 금지**) |

## 워크플로

```text
TASK (What) → AI 구현 → RESULT (How) → REVIEW
```

- **수정 승인 / 삭제 승인 절차 없음**
- 레거시 `RecFileMigrationTool/` 소스는 구현 세션에서 읽지 않음

## Task 목록

[`02_tasks/TASK-INDEX.md`](02_tasks/TASK-INDEX.md) — TASK-001 ~ TASK-014
