# Copilot Instructions

Repository summary
- Purpose: .NET 6 Web API (Customer) using EF Core (Postgres) with a code-first approach.
- Projects: Customer.Domain.Api, Customer.Data, Customer.Business, Customer.Common.
- Primary language: C# targeting .NET 6.

How to run (dev)
- Use dotnet CLI or Visual Studio:
  - dotnet build Customer.sln
  - dotnet ef database update (run from Customer.Data if using migrations)
  - Launch Customer.Domain.Api project (F5 or dotnet run)
- Use environment variables or user-secrets for connection strings and secrets. Do NOT use committed appsettings.json for production secrets.

Coding conventions and style
- Follow existing repository style (C# idiomatic, async/await for I/O).
- Keep methods small and single-responsibility.
- Prefer explicit types for public APIs, var for local simple declarations.
- Use DI (IServiceCollection) for all dependencies; avoid newing services in controllers/managers.
- Keep null-checks and argument validation; prefer throwing ArgumentNullException for invalid args.

EF Core & data access guidance
- Prefer LINQ/EF queries; avoid string-based SQL when possible.
- If raw SQL needed, use FromSqlInterpolated(FormattableString) or parameterized commands; never concatenate user input into SQL.
- Use AsNoTracking() for read-only queries to reduce tracking overhead.
- Avoid relying on lazy loading unless intentionally required; prefer explicit Include for related data to prevent N+1.
- Apply paging for list endpoints (limit/offset or cursor) to avoid large in-memory lists.

Security
- Never commit secrets (db passwords, API keys, certificates). Use environment variables, user-secrets, or a secrets store (Key Vault).
- Ensure authentication is configured before enabling UseAuthorization(); annotate controllers with [Authorize] where appropriate.
- Validate incoming DTOs with DataAnnotations or FluentValidation and check ModelState in controllers.
- Avoid insecure cryptography (MD5/SHA1/TripleDES). Use RandomNumberGenerator, HMACSHA256, or higher-level secure APIs.
- Remove committed logs and other sensitive artifacts from repo and add to .gitignore.

Performance & reliability
- Use asynchronous EF Core methods (SaveChangesAsync, ToListAsync, FirstOrDefaultAsync).
- Add resilience for transient faults (IHttpClientFactory, Polly for DB/HTTP retries).
- Use IHttpClientFactory for external HTTP calls to avoid socket exhaustion.
- Benchmark or profile before applying micro-optimizations; fix algorithmic issues first.

Testing
- Preferred framework: NUnit.
- Add unit tests for business layer and repository logic.
- Mock dependencies using Moq or NSubstitute.
- Add integration tests for DbContext using an in-memory or test container Postgres instance.
- Ensure tests are fast, deterministic, and cover happy / edge / error cases.

Logging & telemetry
- Use structured logging (Serilog configured in Program.cs).
- Avoid logging sensitive data (PII, secrets).
- Log exceptions with context; prefer Error level for unexpected failures.

Pull request and commit guidelines
- Small, focused PRs with a clear description of intent and risk.
- Include tests for new behavior or bug fixes.
- Use conventional commit messages: type(scope): short summary (e.g., fix(customer-api): validate dto).
- Run dotnet build and unit tests locally before pushing.

Security checks & CI
- Add automated checks in CI:
  - dotnet build & test
  - static analysis (Roslyn analyzers, security analyzers)
  - secret scanning (git-secrets or repo scanner)
- Gate merges on passing tests and code review.

When editing code
- Make minimal, well-tested changes.
- If you change public contracts (DTOs, database schema), update mappings and migrations, and communicate the change.
- Run database migrations locally to verify schema changes.

What to avoid
- Hardcoding secrets or credentials in source.
- Using FromSqlRaw with concatenated strings containing user input.
- Blocking calls (.Result, .Wait()) on async tasks in request paths.
- Large unpaged queries that return entire tables to memory.

If unsure
- Ask before making breaking or cross-cutting changes (authentication approach, secrets store, major EF configuration).
- When adding third-party libraries, prefer well-maintained packages with active security histories.

Contact / conventions
- Use GitHub issues/PRs for design discussion.
- Keep changes small and documented.

---

Preferred test framework: NUnit (explicitly noted above).
