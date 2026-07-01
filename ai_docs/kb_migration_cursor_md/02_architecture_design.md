# 전체 아키텍처 설계 지침

## 목표

기존 구조를 답습하지 않고, DB 기반 파일 마이그레이션에 최적화된 신규 구조를 설계한다.

## 기본 구조

```text
[Dashboard UI]
      │
      ▼
[Migration Orchestrator]
      │
      ├── [DB Fetcher]
      │       └── DB에서 대상 파일 Batch 조회
      │
      ├── [Work Queue]
      │       └── Worker에게 작업 분배
      │
      ├── [Worker Pool]
      │       ├── Worker 1
      │       ├── Worker 2
      │       ├── Worker 3
      │       └── Worker N
      │
      ├── [Result Queue / Buffer]
      │       └── 처리 결과 임시 적재
      │
      ├── [Bulk Update Service]
      │       └── 처리 결과를 DB에 Bulk 반영
      │
      ├── [Bandwidth Controller]
      │       └── 전체/Worker별 전송 속도 제한
      │
      ├── [Monitoring Service]
      │       └── CPU, Memory, Disk I/O, Network 수집
      │
      └── [Logging Service]
              └── 오류 및 처리 로그 기록
```

## 주요 컴포넌트

### 1. Dashboard UI

운영자와 엔지니어가 전체 현황을 실시간으로 확인하는 화면이다.

표시 항목:

- 전체 대상 건수
- 완료 건수
- 실패 건수
- 진행률
- Worker별 상태
- Network 사용량
- 서버 리소스
- 오류 현황

### 2. Migration Orchestrator

전체 마이그레이션 프로세스를 제어하는 중심 서비스다.

역할:

- 작업 시작/중지/일시정지 제어
- DB 조회 요청
- Worker Pool 관리
- 처리 결과 수집
- Bulk Update Trigger 제어
- Dashboard 상태 갱신

### 3. DB Fetcher

DB에서 마이그레이션 대상 파일 목록을 Batch 단위로 조회한다.

고려사항:

- 한 번에 너무 많은 데이터를 조회하지 않는다.
- Worker가 직접 DB를 과도하게 호출하지 않도록 한다.
- 처리 상태값을 기준으로 대상 범위를 제어한다.

### 4. Worker Pool

하나의 프로그램 내부에서 N개의 Worker를 실행한다.

역할:

- 파일 존재 여부 확인
- 원본 파일 읽기
- 대상 경로 생성
- 파일 복제
- 검증 정보 수집
- 처리 결과 생성

### 5. Result Queue / Buffer

각 Worker의 처리 결과를 임시로 저장한다.

목적:

- DB 건건이 업데이트 방지
- Bulk Update 단위로 결과 적재
- DB 병목 최소화

### 6. Bulk Update Service

Result Queue에 쌓인 결과를 일정 건수 또는 일정 시간 단위로 DB에 반영한다.

### 7. Bandwidth Controller

파일 복제 중 네트워크 대역폭이 과도하게 사용되지 않도록 제어한다.

### 8. Monitoring Service

서버 리소스와 처리 지표를 수집한다.

수집 항목:

- CPU 사용률
- Memory 사용률
- Disk I/O
- Network 사용량
- 처리 속도
- Worker별 상태

## 설계 원칙

- UI와 비즈니스 로직을 분리한다.
- 파일 처리와 DB 처리를 분리한다.
- DB 업데이트는 Bulk 방식으로 처리한다.
- Worker 개수와 Batch 크기는 설정으로 조정 가능하게 한다.
- 장기 실행 작업이므로 중단/재시작을 고려한다.
- 오류 파일은 반드시 재처리 가능해야 한다.
