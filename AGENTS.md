# Repository Guidelines

## Project Structure & Module Organization

This repository contains a small .NET 10 application split into Core, Presentation, and
Console projects, with xUnit test projects for Core and Presentation.

- **PrimeFactors.Core/**: prime-factor domain and business logic.
- **PrimeFactors.Core/PrimeFactorCalculator.cs**: prime-factor calculation logic.
- **PrimeFactors.Presentation/**: testable application flow, input parsing, and display.
- **PrimeFactors.Console/**: executable composition root for terminal input and output.
- **PrimeFactors.Console/Program.cs**: wires the real terminal to Presentation.
- **PrimeFactors.Core.Tests/**: xUnit tests that exercise Core directly.
- **PrimeFactors.Presentation.Tests/**: xUnit tests using in-memory input and output.
- **PrimeFactors.slnx**: solution entry point for building and testing all projects.

Core must not reference Presentation or Console and must not depend on console I/O.
Presentation may reference Core but must not call **System.Console** directly. Console
references Presentation and keeps **Program.cs** limited to composition. Do not add
interfaces or additional architecture layers unless they solve an actual dependency
problem. Build artifacts in **bin/** and **obj/** are generated and ignored by Git.

## Build, Test, and Development Commands

Run commands from the repository root:

    dotnet build PrimeFactors.slnx
    dotnet test PrimeFactors.slnx
    dotnet tool restore
    dotnet test PrimeFactors.slnx --no-restore /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura
    dotnet reportgenerator "-reports:PrimeFactors.*.Tests/coverage.cobertura.xml" "-targetdir:coverage" "-reporttypes:Html;TextSummary"
    dotnet run --project PrimeFactors.Console/PrimeFactors.Console.csproj
    dotnet format PrimeFactors.slnx
    cd PrimeFactors.Core.Tests
    dotnet stryker --break-at 100 --threshold-low 100 --threshold-high 100 --skip-version-check
    cd ..

The build command compiles all five projects. The standard test command builds and runs
all xUnit tests. The coverage test command prints per-project metrics and writes Cobertura
files; the following ReportGenerator command combines them into
**coverage/Summary.txt** and an HTML report at **coverage/index.html**. The run command
starts the interactive console application. Enter **quit** to end it. The format command
applies standard .NET formatting rules; review its changes before committing. Restore
repository-local tools before running coverage reporting or Stryker. Run Stryker from the
Core test project; the 100% break threshold makes the command fail if any executable Core
mutation survives.

## Coding Style & Naming Conventions

Use four-space indentation and standard C# conventions. Use PascalCase for classes,
methods, and public members; use camelCase for parameters and local variables. Enable and
respect nullable reference type warnings. Prefer explicit, descriptive names such as
remaining and divisor.

Keep methods focused and avoid unnecessary abstractions. Place reusable calculation
behavior in **PrimeFactors.Core** and application flow, parsing, and display formatting in
**PrimeFactors.Presentation**. Keep **PrimeFactors.Console** limited to composition with
the real terminal.

## Testing Guidelines

Tests use xUnit and belong in **PrimeFactors.Core.Tests** or
**PrimeFactors.Presentation.Tests**. Core tests should reference and exercise Core
directly. Presentation tests should use in-memory readers and writers instead of the real
terminal. Use FluentAssertions for assertions and structure tests with distinct Arrange,
Act, and Assert sections. Name test classes after the subject and give test methods
behavior-focused names such as **CalculatesFactorsOf60**.

Add tests for normal inputs, repeated factors, primes, and relevant boundary cases when
changing calculation logic. No coverage threshold is configured, but new behavior should
have focused tests. Prefer tests that distinguish the intended implementation from likely
mutations, especially changed boundary and comparison operators. Always run the solution
test command before submitting changes; run mutation tests when hardening calculation
logic or its tests.

## Commit & Pull Request Guidelines

Existing commits use short, descriptive sentence-style summaries rather than Conventional
Commit prefixes. Follow that pattern and describe the completed change, for example:
“Add tests for prime factor edge cases.”

Pull requests should include a concise purpose, a summary of implementation changes, and
test results. Link related issues when applicable. Screenshots are unnecessary unless
console presentation changes materially.
