# TASK-004: Source DB 설정

## 1. 메타

| Task ID | TASK-004 | 기능 ID | F-04 | 선행 | TASK-002 |
| KB | [03](../kb_migration_cursor_md/03_db_based_file_processing.md), [05](../kb_migration_cursor_md/05_db_bulk_update_and_bottleneck.md) |

## 2. 목적

Source MSSQL 연결 정보·테이블·마킹 필드·Trust Server 옵션을 Config에서 관리하고, Worker·조회가 동일 설정을 사용한다.

## 3. In / Out of Scope

**In:** DB IP/Name/ID/PW, TableNM, MarkField, SelectCondition(기본), YearDB, Enable Trust DB Server, SqlAccount 인코딩/복호화, TelNo AES256 마킹 옵션(`Enable TelNo data encryptoin.`).

**Out:** Target DB, ORM 강제, Bulk Update (KB 목표는 RESULT).

## 4. 사용자 시나리오

- **Given** 유효 DB 설정 **When** Worker 조회 **Then** Source DB 연결 성공.
- **Given** Trust Server 체크 **When** 연결 **Then** Encrypt=True;TrustServerCertificate=False 등 적용.
- **Given** CheckTelNoEncrypt=1 **When** 마킹 **Then** DialedNumber/CallerNumber AES256 저장.

## 5. 입력 · 출력 · 설정

| INI `[DBInfoSource]` | DBIP, DBNM, DBID, DBPW, TableNM, MarkTableNM(기본=TableNM), MarkField, SelectCondition, YearDB, Enable Trust DB Server |
| INI `[KMSInfo]` 또는 동일 | Enable TelNo data encryptoin. |
| Worker Row | UseConfigDBName, DBName, UseYearTableMarking → 조회 View / 마킹 Table_YYYY |

## 6. 수용 기준

- [ ] Worker마다 독립 DB 연결 (공유 금지)
- [ ] 연결 실패 시 Worker 로그 + Failure 카운트 정책
- [ ] 비밀번호 INI 인코딩 저장

## 7. 제약

- SQL은 운영자 조건(SelectCondition) 포함 가능 — injection 주의 RESULT
- KB(05): Row UPDATE vs Bulk → RESULT

## 8. 검증

1. 잘못된 DBIP → 연결 실패 로그
2. Trust ON/OFF 연결
3. Year Table 마킹 ON → `Table_YYYY` UPDATE
