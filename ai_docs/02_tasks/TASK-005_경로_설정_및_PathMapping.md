# TASK-005: 경로 설정 및 Path Mapping

## 1. 메타

| Task ID | TASK-005 | F-05 | 선행 TASK-002 | KB [03](../kb_migration_cursor_md/03_db_based_file_processing.md) |

## 2. 목적

녹취 파일의 **소스·타겟 경로 규칙**을 설정한다. Impact360(가상→실경로 Mapping) 또는 Audiolog 경로 규칙 중 환경에 맞게 사용한다.

## 3. In / Out of Scope

**In:** I360HttpFullPathField, Path Mapping Grid(Enabled, Virtual, RealSource, Memo), AudiologPath, AudiologPathAddField, TargetPath, BackupPath, 최장 prefix 매칭.

**Out:** 디렉터리 스캔, Target DB.

## 4. 사용자 시나리오

- **Given** I360 필드에 가상 URL **When** Worker 처리 **Then** Mapping으로 Real Source 치환 후 Target은 TargetPath prefix로 치환.
- **Given** Audiolog 모드 **When** Row 처리 **Then** ServerName·FileName·Date 규칙으로 경로 조립.
- **Given** Mapping 없음 **When** I360 경로 **Then** 실패·마킹 5.

## 5. 입력 · 출력 · 설정

| INI | `[PathInfo]`, `[PathMapping_n]` |
| Mapping | VirtualPath → RealSourcePath; Target 시 RealSource → TargetPath |
| Audiolog | `{AudiologPath}\{server}\{file segments}\{date yyyymmdd}\{fileName}` (+ AddField 서브경로) |

## 6. 수용 기준

- [ ] 복수 Mapping 시 **가장 긴 prefix** 매칭
- [ ] `/` `\` 혼용 정규화
- [ ] Config Grid 순서 변경·추가·삭제 INI 반영

## 7. 제약

- NAS deep tree — **DB Row만**으로 경로 결정

## 8. 검증

1. Mapping 2개 겹침 → 긴 prefix 선택
2. Audiolog AddField 유/무 경로
3. Target 상대 경로 보존
