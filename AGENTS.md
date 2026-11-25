# AGENTS.md

## REST API spec
- `ApiSpec.md` is the source of truth for the REST API. The endpoints in `Program.cs` and the records in `Dtos/` should match it.
- If the code and the spec differ, point out the difference and ask which one is right. Don't change either one to match the other without asking.
- An endpoint that is in the spec but not in the code is planned work, not a mistake.
- When changing an endpoint or a DTO, check whether the spec still matches and suggest the spec change.
- Keep `ApiSpec.md` to one page at most (2400 characters including spaces).
