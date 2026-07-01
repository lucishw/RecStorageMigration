# Rules — ai_docs 워크플로

> 구현 **How**(UI 스레드, 클래스 구조 등)는 [`ImplementationPrinciples.md`](ImplementationPrinciples.md)를 따른다.  
> TASK는 **What(행위·수용기준)** 만 정의한다. How는 AI가 설계하고 [`03_results/`](../03_results/)에 기록한다.

---

## 1. 문서 목적

- RecFileMigrationTool **활성 기능 14개**를 TASK 단위로 greenfield 재구현한다.
- Context/Token 낭비 방지: **한 세션 = TASK 1개**.
- **수정 승인 / 삭제 승인 절차는 사용하지 않는다.** 범위 이탈 시 RESULT에 기록하고 다음 Task에서 조정한다.

---

## 2. 폴더 역할

```text
ai_docs/
├─ 00_rules/           Rules.md, ImplementationPrinciples.md, Templates.md
├─ 01_overview/        개발_개요.md
├─ 02_tasks/           TASK-INDEX.md, TASK-001~014 (What만)
├─ 03_results/         RESULT-xxx (How + 구현 결과)
├─ 04_review/          REVIEW-xxx (개발자 검증)
├─ 05_release/         RELEASE-xxx (배포 스냅샷)
├─ _analysis/          legacy 행위 추출 (구현 세션 로드 금지)
├─ kb_migration_cursor_md/  설계 KB (TASK에 명시된 파일만)
└─ _archive/           이관 문서 (로드 금지)
```

---

## 3. AI 구현 세션 — 로드 순서

```text
1. ai_docs/00_rules/Rules.md
2. ai_docs/00_rules/ImplementationPrinciples.md
3. ai_docs/02_tasks/TASK-INDEX.md
4. 현재 TASK-xxx.md (+ TASK에 명시된 KB 1~2개)
```

**로드 금지**

- `ai_docs/_analysis/`, `ai_docs/_archive/`
- `RecFileMigrationTool/` 레거시 소스 (구현 시)
- `kb_migration_cursor_md` 일괄 로드
- TASK 본문 일괄 로드

---

## 4. 작업 흐름

```text
TASK-xxx (What) → AI greenfield 구현 → RESULT-xxx (How + 빌드/테스트) → REVIEW-xxx
```

| 단계 | 담당 | 산출물 |
|------|------|--------|
| 사양 | TASK | 행위·수용기준·검증 |
| 구현 | AI | `src/` 코드 |
| 기록 | AI | RESULT (선택한 UI/동시성 방식 포함) |
| 검증 | 개발자 | REVIEW 체크리스트 |

---

## 5. TASK · RESULT 규칙

- TASK 본문은 **사양 고정**. 구현 기록은 RESULT에만 작성한다.
- TASK에 없는 기능 추가 시 RESULT「범위 확장」에 명시한다.
- RESULT 필수: **UI·Worker 연동 방식**(1문단), **레거시 대비 개선**(1~3줄).

템플릿: [`Templates.md`](Templates.md)

---

## 6. Non-Goals (모든 TASK 공통 Out-of-Scope)

- KMS / MediaParser / 암호화 파이프라인
- 레거시 단일 스레드 배치
- Target DB UI, 디렉터리 스캔
- StatusReader UI (미연동)

---

## 7. 보안

- 실 credentials, 고객 IP, 녹취 경로 샘플을 저장소·문서에 커밋하지 않는다.
- `log/`, `ini/` 런타임 산출물은 커밋하지 않는다.

---

## 8. 빌드 (greenfield 확정 후 RESULT에 기록)

현행 레거시 참고:

```powershell
msbuild RecFileMigrationTool.sln /p:Configuration=Debug /p:Platform=x86
```

신규 솔루션 빌드 명령은 RESULT·RELEASE에 기록한다.

---

## 9. Git · 커밋

### 원칙

- **작은 수정마다 커밋하지 않는다** (typo, 단일 파일 리네임, 중간 WIP 등).
- **논리적 Feature 1개가 완성**되었을 때만 커밋한다.
- Feature 단위 = **TASK 1개 완료** (RESULT 작성 + 빌드 성공 + 해당 TASK §8 검증 통과) 또는 TASK와 1:1인 독립 기능.
- 커밋 **전** working tree에 unrelated WIP가 섞이지 않도록 Task 경계를 지킨다.

### 커밋 메시지 형식

```text
feat(TASK-003): Worker 스케줄러 Runtime 자동 기동

- TASK-003 수용 기준 충족
- RESULT-003 How 기록
```

| 접두 | 용도 |
|------|------|
| `feat(TASK-xxx)` | Task/Feature 완료 |
| `fix(TASK-xxx)` | 동일 Task 범위 버그 수정 (단독 소규모 fix 커밋 금지 — Task 재완료 후 1커밋) |
| `docs` | ai_docs만 변경 (Task 문서화 세트 완료 시 1커밋) |
| `chore` | 솔루션/CI/ignore 등 인프라 (논리 단위 묶음) |

### AI·Agent 동작

- Task 구현 **중간**에는 커밋하지 않는다.
- 사용자가 **명시적으로 커밋 요청**할 때만, 위 규칙에 맞는 **Feature 완료 단위**로 1회 커밋한다.
- `git commit --amend`는 사용자 명시 요청 없이 사용하지 않는다.
