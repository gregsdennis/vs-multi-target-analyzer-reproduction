# VS Source Generator Multi-Target Bug Reproduction

This is a minimal reproduction of an issue where Visual Studio fails to recognize source-generated types in multi-target projects for .NET 9 and 10.

## Projects
- `AnalyzerProject`: Contains a source generator that creates a `GeneratedSimple` class with properties based on classes marked with `[GenerateSimple]`.
- `TestProject`: Multi-targets `net8.0;net9.0;net10.0` and references the analyzer. Contains a `TestClass` with the attribute.

## Expected Behavior
- The `GeneratedSimple.TestClass` property should be available in IntelliSense for all target frameworks.
- In Solution Explorer, generated files should appear under Dependencies > Analyzers for all targets.

## Actual Behavior
- Works for `net8.0`.
- Fails for `net9.0` and `net10.0`: Generated types are not visible, and VS reports errors.

## Steps to Reproduce
1. Open `Reproduction.sln` in VS.
2. Set `TestProject`'s target framework to `net8.0` → `GeneratedSimple.TestClass` is visible.
3. Switch to `net9.0` or `net10.0` → `GeneratedSimple.TestClass` is missing, errors appear.

Build succeeds for all targets, but IDE recognition fails.