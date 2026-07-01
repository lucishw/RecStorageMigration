# RELEASE-001: RecFileMigrationTool 배포 스냅샷

> **기준:** 레거시 코드베이스 (`RecFileMigrationTool/`) 스냅샷 — **greenfield 재구현 전 참고용**  
> **Task 범위:** TASK-001 ~ TASK-014 (활성 기능)  
> **갱신:** greenfield RESULT/REVIEW 전 Task 승인 후 본 문서를 신규 `src/` 기준으로 갱신한다.

---

## 1. 프로그램 식별

| 항목 | 값 |
|------|-----|
| 프로그램명 | RecFileMigrationTool |
| 실행 파일 | `RecFileMigrationTool.exe` |
| 솔루션 | `RecFileMigrationTool.sln` |
| 프로젝트 | `RecFileMigrationTool/RecFileMigrationTool.csproj` |
| RootNamespace | `RecFileMigrationTool` |
| 진입 네임스페이스 | `RecFileMigrationTool` (`Program.cs`) |
| 어셈블리 버전 | 1.0.0.0 (`Properties/AssemblyInfo.cs`) |
| 프레임워크 | .NET Framework 4.6.1 |
| UI | Windows Forms |

---

## 2. 빌드 구성

| Configuration | Platform | OutputPath | PlatformTarget |
|---------------|----------|------------|----------------|
| Debug | x86 | `bin\Debug\` | x86 |
| Release | x86 | `bin\Release\` | x86 |
| Debug | x64 | `bin\x64\Debug\` | x64 |
| Release | x64 | `bin\x64\Release\` | x64 |

**권장**

```powershell
msbuild RecFileMigrationTool.sln /p:Configuration=Debug /p:Platform=x86
msbuild RecFileMigrationTool.sln /p:Configuration=Release /p:Platform=x64
```

**실행**

```powershell
.\RecFileMigrationTool\bin\Debug\RecFileMigrationTool.exe
```

---

## 3. NuGet·외부 의존성

| 구분 | 내용 |
|------|------|
| NuGet | 없음 (csproj Reference는 `System.*`만) |
| MediaParser.dll | **프로젝트 참조 제거됨** — 활성 Worker 경로 미사용 |
| KMSManager.cs | 레거시 코드 보존, `#region 미사용` |
| 네이티브 DLL | csproj 기준 별도 패키지 없음 |
| OS | Windows (RoboCopy, Win32 INI API) |

---

## 4. 런타임 폴더·파일

실행 파일 기준 상대 경로 (`Directory.GetCurrentDirectory()`).

| 경로 | 용도 | 생성 주체 |
|------|------|-----------|
| `ini/RecFileMigrationTool.ini` | 전역·Worker·RoboCopy 설정 | `IniManager.CreateIniFile` |
| `log/` | 메인·Worker·Err 로그 | `LogManager.CreateLogFile` |
| `temp/worker_{id}_{guid}/` | Worker 임시 복사 | `MigrationWorker.Run` |
| `RoboCopyReports/` | Manual RoboCopy 리포트 (기본) | RoboCopy UI |

**로그 파일 패턴**

- `log/{yyyy-MM-dd}_RecFileMigrationTool.log`
- `log/{yyyy-MM-dd}_RecFileMigrationToolErr.log`
- `log/worker_{n}_{yyyy-MM-dd}_RecFileMigrationTool.log`
- `log/worker_{n}_{yyyy-MM-dd}_RecFileMigrationToolErr.log`

---

## 5. 설정 파일 요약

**경로:** `ini/RecFileMigrationTool.ini`

| 섹션 | 용도 |
|------|------|
| `[General]` | Title, LogLevel, EnableDefaultConnectionLimit, WorkerStatsSaveIntervalSec, WorkerLogFlushIntervalMs |
| `[WorkInfo]` | Site, Interval, Weekday/Weekend Runtime, RunAutoStart |
| `[DBInfoSource]` | Source DB·테이블·마킹 |
| `[PathInfo]` | I360/Audiolog/Target/Backup |
| `[PathMappings]` / `[PathMapping_n]` | Impact360 가상→실경로 |
| `[Workers]` / `[Worker_n]` | Multi Worker 목록·설정·누적 |
| `[ManualRoboCopy]` | 수동 RoboCopy |
| `[KMSInfo]` | 전화번호 AES 마킹 (활성). KMS 연결은 미사용 |

상세 키는 TASK-002, TASK-006, TASK-014 참조.

---

## 6. 포함 기능 (Task 매핑)

| Task | 기능 |
|------|------|
| TASK-001 | 프로그램 시작·DefaultConnectionLimit |
| TASK-002 | INI·Config 탭 |
| TASK-003 | Worker 스케줄러 |
| TASK-004 | Source DB |
| TASK-005 | 경로·PathMapping |
| TASK-006 | Multi Worker UI |
| TASK-007 | Worker 시작/중지 |
| TASK-008 | DB 배치 루프 |
| TASK-009 | 파일 경로 생성 |
| TASK-010 | 복사·마킹 |
| TASK-011 | Runtime·Interval |
| TASK-012 | UI flush·통계 INI |
| TASK-013 | 로그·리포트 |
| TASK-014 | Manual RoboCopy |

---

## 7. 배포 산출물

| 파일 | 설명 |
|------|------|
| `RecFileMigrationTool.exe` | 메인 실행 파일 |
| `RecFileMigrationTool.exe.config` | .NET 4.6.1 (`app.config`) |
| `StorageMigration.ico` | 앱 아이콘 (Content) |

**배포 시 함께 제공 권장**

- 빈 `ini/` (또는 샘플 INI — credentials 제외)
- `log/`, `temp/` 디렉터리 (자동 생성 가능)
- 운영자용 TASK-002 Config 설명

**커밋·배포 제외:** `bin/`, `obj/`, 실제 credentials가 포함된 INI, `log/`, `temp/` 내용

---

## 8. 알려진 제약

| 제약 | 설명 |
|------|------|
| Row UPDATE | Bulk Update 미구현 — DB 부하 시 KB-05 참고 |
| 디렉터리 스캔 | 미지원 — DB 조회만 |
| KMS/MediaParser | UI·Worker 미연동 |
| Target DB | Config UI 제거 |
| 그래프 리포트 | request.md 목표 대비 미구현 (텍스트 리포트만) |
| x86/x64 | MediaParser 제거로 플랫폼은 운영 환경에 맞게 선택 |

---

## 9. 롤백·운영

1. 이전 `RecFileMigrationTool.exe` + `RecFileMigrationTool.ini` 백업 복원
2. Worker `[Worker_n]` ProcessedCount 등 INI 통계는 롤백 시점 스냅샷 유지 여부 운영 정책에 따름
3. DB 마킹(1/2/5/6)은 롤백으로 자동 복구되지 않음 — 별도 DB 백업 필요

---

## 10. 검증·릴리스 게이트

1. TASK별 `RESULT-xxx` 작성 완료
2. TASK별 `REVIEW-xxx` **승인**
3. msbuild Debug|x86 및 Release|x64 성공
4. WinForms 스모크: Config Save, Worker 1건, Logs, RoboCopy DryRun

---

## 11. 관련 문서

- [`01_overview/개발_개요.md`](../01_overview/개발_개요.md)
- [`02_tasks/TASK-INDEX.md`](../02_tasks/TASK-INDEX.md)
- [`03_results/RESULT-INDEX.md`](../03_results/RESULT-INDEX.md)
- [`04_review/REVIEW-INDEX.md`](../04_review/REVIEW-INDEX.md)
- 레거시 마이그레이션 기록: [`_archive/request_result.md`](../_archive/request_result.md)
