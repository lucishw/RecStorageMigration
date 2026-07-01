# TASK-002: INI 설정 및 Config 탭

## 1. 메타

| 항목 | 값 |
|------|-----|
| Task ID | TASK-002 |
| 기능 ID | F-02 |
| 선행 Task | TASK-001 |
| KB | [02_architecture_design.md](../kb_migration_cursor_md/02_architecture_design.md) |

## 2. 목적

운영자가 DB·경로·스케줄·일반 옵션을 **Config 탭**에서 편집하고 INI에 저장·복원한다.

## 3. In / Out of Scope

**In:** Read/Show/Write INI, Config 탭 통합 UI, Save 토글, Worker Row INI 연동(목록·Row 키), Path Mapping INI, Manual RoboCopy INI(TASK-014와 공유 섹션).

**Out:** Target DB UI, KMS 설정 UI, Worker 실행 로직.

## 4. 사용자 시나리오

- **Given** Config 탭 **When** Save **Then** `[General]`, `[WorkInfo]`, `[DBInfoSource]`, `[PathInfo]`, PathMapping, `[Workers]` 등이 INI에 반영된다.
- **Given** 재시작 **When** 로드 **Then** Config 컨트롤에 저장값이 표시된다.
- **Given** DB 비밀번호 **When** Save **Then** 인코딩 저장(복호화 가능), 평문 커밋 금지.

## 5. 입력 · 출력 · 설정

**Config 그룹:** Schedule and Process, Source Database, Impact360 Path Mappings, Audiolog, Target/Backup, EnableDefaultConnectionLimit, RunAutoStart.

**주요 INI:** `[General]` Title, LogLevel, LogRetentionPeriod, EnableDefaultConnectionLimit, WorkerStatsSaveIntervalSec, WorkerLogFlushIntervalMs · `[WorkInfo]` Site, Interval, Weekday/Weekend Start/End, RunAutoStart · `[DBInfoSource]` DBIP, DBNM, DBID, DBPW(인코딩), TableNM, MarkField, SelectCondition, YearDB, Trust Server · `[PathInfo]` I360HttpFullPathField, AudiologPath, TargetPath, BackupPath · `[PathMapping_n]` · `[Workers]` Count, WorkerIds, NextWorkerId · `[Worker_n]` Row 필드.

## 6. 수용 기준

- [ ] Config 탭에서 전역 From/ToDate 없음 (Worker Row별 날짜)
- [ ] Save 시 Worker Row 설정·누적 통계 저장
- [ ] Path Mapping Grid CRUD → INI 반영
- [ ] 설정 파일 경로는 RESULT에서 `config/` 또는 `ini/` 확정

## 7. 제약

- Config Save 중에도 UI freeze 없음 (How: RESULT)
- 민감정보 git 커밋 금지

## 8. 검증

1. DB·경로·Runtime 수정 → Save → 재시작 → 값 유지
2. Path Mapping 추가/삭제 → INI 섹션 일치
3. Worker 2개 추가 → `[Workers]` Count/Ids 갱신
