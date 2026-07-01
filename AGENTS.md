# Repository Guidelines

## Project Structure & Module Organization

This repository contains a single Visual Studio solution, `RecFileMigrationTool.sln`, with one C# WinForms project in `RecFileMigrationTool/`. Application startup is in `RecFileMigrationTool/Program.cs`; the main form lives in `frmMain.cs`, `frmMain.Designer.cs`, and `frmMain.resx`. Shared helpers are grouped under `RecFileMigrationTool/Common/`. Build output, runtime DLLs, logs, and local INI files appear under `RecFileMigrationTool/bin/` and `RecFileMigrationTool/obj/`.

Greenfield 재구현 사양·Task 워크플로는 [`ai_docs/README.md`](ai_docs/README.md)를 따른다.

## Build, Test, and Development Commands

```powershell
msbuild RecFileMigrationTool.sln /p:Configuration=Debug /p:Platform=x86
msbuild RecFileMigrationTool.sln /p:Configuration=Release /p:Platform=x64
.\RecFileMigrationTool\bin\Debug\RecFileMigrationTool.exe
```

The solution targets .NET Framework 4.6.1 (레거시). 신규 구현은 `ai_docs` Task·RESULT 기준.

## Coding Style & Naming Conventions

Four-space indentation, braces on new lines, PascalCase for classes and public methods. Put reusable logic in `Common/` or greenfield `Core`/`Infrastructure`. UI 스레드·Worker 연동은 [`ai_docs/00_rules/ImplementationPrinciples.md`](ai_docs/00_rules/ImplementationPrinciples.md)를 따른다 (레거시 Invoke/Timer flush 패턴 복사 금지).

## Testing Guidelines

No automated test project currently. Minimum: build + manual WinForms smoke test per TASK RESULT.

## Security & Configuration Tips

Do not commit real credentials, server IPs, or customer data in `app.config`, `ini/`, logs, or backup folders.

## Agent-Specific Instructions

- 기능 구현은 [`ai_docs/02_tasks/TASK-INDEX.md`](ai_docs/02_tasks/TASK-INDEX.md)의 Task 단위로 진행한다.
- 한 세션에 Task 1개 + Rules + ImplementationPrinciples만 로드한다.
- How(구현 방식)는 RESULT에 기록한다.
- **수정 승인 / 삭제 승인 절차는 사용하지 않는다.**
- **Git 커밋:** TASK 1개(또는 동등 Feature) 완료 시에만 1커밋. 형식·접두는 [`ai_docs/00_rules/Rules.md`](ai_docs/00_rules/Rules.md) §9. 사용자 명시 요청 없이 중간/WIP/amend 커밋 금지.
