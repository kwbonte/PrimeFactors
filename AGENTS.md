# Repository Guidelines

## Project Structure & Module Organization

This repository contains a small .NET 10 console application and an xUnit test project.

- **Program.cs**: console input, validation, and output.
- **PrimeFactorCalculator.cs**: prime-factor calculation logic.
- **PrimeFactors.csproj**: application project configuration.
- **PrimeFactors.Tests/**: automated tests and the test project file.
- **PrimeFactors.slnx**: solution entry point for building and testing all projects.

Keep calculation logic independent of console I/O so it can be tested directly. Build artifacts in **bin/** and **obj/** are generated and ignored by Git.

## Build, Test, and Development Commands

Run commands from the repository root:

    dotnet build PrimeFactors.slnx
    dotnet test PrimeFactors.slnx
    dotnet run --project PrimeFactors.csproj
    dotnet format PrimeFactors.slnx

The build command compiles both projects. The test command builds and runs all xUnit tests. The run command starts the interactive console application. The format command applies standard .NET formatting rules; review its changes before committing.

## Coding Style & Naming Conventions

Use four-space indentation and standard C# conventions. Use PascalCase for classes, methods, and public members; use camelCase for parameters and local variables. Enable and respect nullable reference type warnings. Prefer explicit, descriptive names such as remaining and divisor.

Keep methods focused and avoid unnecessary abstractions. Place reusable calculation behavior in **PrimeFactorCalculator**; keep user prompts and display formatting in **Program.cs**.

## Testing Guidelines

Tests use xUnit and belong in **PrimeFactors.Tests**. Name test classes after the subject, such as **PrimeFactorCalculatorTests**, and give test methods behavior-focused names such as **CalculatesFactorsOf60**.

Add tests for normal inputs, repeated factors, primes, and relevant boundary cases when changing calculation logic. No coverage threshold is configured, but new behavior should have focused tests. Always run the solution test command before submitting changes.

## Commit & Pull Request Guidelines

Existing commits use short, descriptive sentence-style summaries rather than Conventional Commit prefixes. Follow that pattern and describe the completed change, for example: “Add tests for prime factor edge cases.”

Pull requests should include a concise purpose, a summary of implementation changes, and test results. Link related issues when applicable. Screenshots are unnecessary unless console presentation changes materially.
