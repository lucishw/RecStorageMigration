# TASK-010: 파일 복사·예외 처리·마킹

## 1. 메타

| Task ID | TASK-010 | F-10 | 선행 TASK-008, 009 | KB [03](../kb_migration_cursor_md/03_db_based_file_processing.md), [05](../kb_migration_cursor_md/05_db_bulk_update_and_bottleneck.md) |

## 2. 목적

소스 파일을 타겟으로 복사하고, 결과에 따라 Source DB에 **즉시 Row UPDATE** 마킹한다. 정전·재시작 시 미마킹 Row만 재처리 가능해야 한다.

## 3. In / Out of Scope

**In:** Worker별 temp 복사(동시 충돌 방지), Target 폴더 생성, 크기 ≤1KB → 마킹 6, FileNotFound/DirectoryNotFound → 2, 복사 실패 → 5, 성공 → MarkValue(기본1), ETL_DT=GETDATE(), TelNo encrypt 옵션, FileName+ServerName WHERE.

**Out:** KMS 암호화, Bulk UPDATE.

## 4. 사용자 시나리오

- **Given** 유효 파일 **When** 복사 성공 **Then** Target 존재 + Mark=1.
- **Given** 없는 파일 **When** 복사 시도 **Then** Mark=2, Missing 카운트.
- **Given** 512B 파일 **When** 처리 **Then** Mark=6, 복사 생략.
- **Given** 마킹 UPDATE 실패 **When** — **Then** Failure 처리·로그 (복사 성공과 DB 불일치 방지 — RESULT 정책).

## 5. 입력 · 출력 · 설정

| 마킹 | 1 성공, 2 없음, 5 실패, 6 소용량 |
| MarkValue | Row MarkValueTextBox (기본 1) |
| 테이블 | MarkTable 또는 MarkTable_YYYY |

## 6. 수용 기준

- [ ] Row마다 즉시 UPDATE (배치 마킹 지연 없음)
- [ ] Worker별 temp 정리
- [ ] File.Exists 선행 vs 즉시 Copy — RESULT에서 정책·근거
- [ ] KB(05) Bulk vs Row — RESULT

## 7. 제약

- 대용량 NAS — 불필요 메타 I/O 최소화

## 8. 검증

1. 정상 wav 복사+마킹 1
2. 없는 파일 → 2
3. 0바이트/1KB → 6
4. 재시작 후 미마킹만 재조회
