# TASK-009: 파일 경로 생성

## 1. 메타

| Task ID | TASK-009 | F-09 | 선행 TASK-005, 008 | KB [03](../kb_migration_cursor_md/03_db_based_file_processing.md) |

## 2. 목적

조회 Row에서 **소스 파일 절대경로**와 **타겟 파일 절대경로**를 결정한다.

## 3. In / Out of Scope

**In:** I360 — DB 가상경로→Real Mapping→TargetPath prefix 치환; Audiolog — 경로 조립 규칙; Mapping 미일치 시 오류·마킹 5.

**Out:** File.Exists 선행 스캔, 복사(TASK-010).

## 4. 사용자 시나리오

- **Given** I360 full path Row **When** Mapping 일치 **Then** Real Source 및 Target 경로 생성.
- **Given** Audiolog Row **When** 처리 **Then** AudiologPath+서버+세그먼트+날짜+파일명.
- **Given** Mapping 불일치 **When** I360 **Then** 실패 처리.

## 5. 입력 · 출력 · 설정

| Row 필드 | FileName, ServerName, Date, I360 field 또는 Audiolog AddField |
| 출력 | sourceFile, targetFile (절대경로) |

## 6. 수용 기준

- [ ] prefix 대소문자·슬래시 정규화
- [ ] 최장 Mapping 우선
- [ ] 경로 로직 Core 단일화 (App 중복 없음)

## 7. 제약

- NAS 경로만 Row 기반

## 8. 검증

1. I360 Mapping 2개
2. Audiolog AddField 유/무
3. Target 상대 subpath 유지
