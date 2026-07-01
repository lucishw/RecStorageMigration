# Templates — TASK / RESULT / REVIEW / RELEASE

---

## TASK-xxx (8항목 — What만)

```markdown
# TASK-xxx: [기능명]

## 1. 메타
| 항목 | 값 |
| Task ID | TASK-xxx |
| 기능 ID | F-xx |
| 선행 Task | ... |
| KB | (링크, 차이점 참고용) |

## 2. 목적
(운영자 관점 2~4문장)

## 3. In / Out of Scope
- In: ...
- Out: ... (Non-Goals 참조)

## 4. 사용자 시나리오
- **Given** ... **When** ... **Then** ...
(2~4개)

## 5. 입력 · 출력 · 설정
- UI 항목 (탭, 컨트롤, 상태 문구)
- INI 섹션/키/기본값
- DB·파일·마킹 (값·코드표, SQL 전문 X)

## 6. 수용 기준
- [ ] 관측 가능한 결과 ...

## 7. 제약
- UI non-blocking, Row 즉시 마킹, 디렉터리 스캔 금지 등

## 8. 검증
- 수동 테스트 3~5건 (Given/When/Then)
```

**TASK에 넣지 않음:** 레거시 함수명, `Invoke`/Timer API, `src/` 파일 트리, 코드 블록.

---

## RESULT-xxx

```markdown
# RESULT-xxx: [기능명]

- Task ID / 일자 / 작업자
- **How (필수):** UI–Worker 연동, App/Core 분할
- **레거시 대비 개선**
- 수정·추가 파일 목록
- 빌드 (Configuration / Platform)
- 테스트 결과
- 미구현·KB 차이
```

---

## REVIEW-xxx

```markdown
# REVIEW-xxx: [기능명]

- 대응 TASK / RESULT
- [ ] 수용 기준 충족
- [ ] UI non-blocking 확인
- [ ] INI 저장/복원
- 코드 검토 메모
- 배포 가능 여부
```

---

## RELEASE-xxx

```markdown
# RELEASE-xxx

- 프로그램명·버전·TFM·플랫폼
- 포함 Task / Result
- NuGet·외부 DLL·런타임 폴더
- 빌드·배포 명령
- 알려진 제약
```
