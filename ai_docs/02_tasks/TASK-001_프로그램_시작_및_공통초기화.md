# TASK-001: 프로그램 시작 및 공통 초기화

## 1. 메타

| 항목 | 값 |
|------|-----|
| Task ID | TASK-001 |
| 기능 ID | F-01 |
| 선행 Task | — |
| KB | [02_architecture_design.md](../kb_migration_cursor_md/02_architecture_design.md) |

## 2. 목적

WinForms 앱을 기동하고, INI 설정에 따라 NAS/DB 동시 연결 제한 등 **전역 초기화**를 적용한다. 프로그램 종료 시까지 유지되는 런타임 폴더(`log`, `temp` 등)를 준비한다.

## 3. In / Out of Scope

**In:** 앱 진입, VisualStyles, 메인 폼 표시, INI 없을 때 생성, `EnableDefaultConnectionLimit` 조건부 적용, Auto Start 분기, temp/log 준비.

**Out:** Worker·스케줄러 (TASK-003, 007), KMS/암호화, Config 탭 상세 (TASK-002).

## 4. 사용자 시나리오

- **Given** INI에 `EnableDefaultConnectionLimit=1` **When** 앱 시작 **Then** 동일 원격 호스트 동시 연결 상한이 완화된다(기본 100).
- **Given** INI 없음 **When** 첫 실행 **Then** 설정 파일·필요 폴더가 생성되고 앱이 기동된다.
- **Given** Auto Start ON + 체크된 Worker 1개 이상 **When** 로드 완료 **Then** 스케줄러가 자동 시작된다.
- **Given** Auto Start ON + 체크 Worker 없음 **When** 로드 **Then** 스케줄러는 시작하지 않고 안내 로그만 남긴다.

## 5. 입력 · 출력 · 설정

| UI | 타이틀에 제품 버전, `[General] Title` 반영 |
| INI `[General]` | `EnableDefaultConnectionLimit` (1/0, 빈 값=1), `Title` |
| INI `[WorkInfo]` | `RunAutoStart` (0/1) |
| 출력 | 메인 로그 `[Start__] [Program]` 등 |

## 6. 수용 기준

- [ ] 단일 WinExe, STA 메인 스레드
- [ ] INI·log·temp 경로가 실행 디렉터리 기준으로 준비됨
- [ ] ConnectionLimit=0일 때 Program에서 강제 100 설정하지 않음
- [ ] ConnectionLimit=1 또는 빈 값일 때 100 적용
- [ ] INI 읽기 실패 시 ConnectionLimit fallback 정책이 RESULT에 명시됨

## 7. 제약

- UI non-blocking (초기화 중 무거운 I/O는 백그라운드 또는 비동기 — How는 RESULT)
- KB(02): HostedService/DI 목표와 다를 수 있음 → RESULT에 기록

## 8. 검증

1. INI 없이 실행 → ini 생성, 앱 표시
2. EnableDefaultConnectionLimit=0 → 연결 제한 미설정
3. Auto Start + Worker 체크 → 스케줄러 시작
4. Auto Start + Worker 미체크 → 스케줄러 미시작, 로그 확인
