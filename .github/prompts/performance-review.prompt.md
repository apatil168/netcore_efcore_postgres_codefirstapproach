---
name: performance-review
mode: agent
description: Eliminating hidden bottlenecks, allocations, and slow code
---
Review the selected C# code exclusively for performance optimizations and heap allocation reductions.

Identify and provide refactoring solutions for:
- High-allocation structures (suggest `Span<T>`, `ReadOnlySpan<T>`, or `Memory<T>` where appropriate).
- Suboptimal string operations (suggest `StringBuilder`, `StringInterpolation`, or composite formatters).
- Boxing/unboxing overhead with value types.
- Unnecessary LINQ allocations inside loops (suggest converting to standard iterative loops if hot path).
- Micro-optimizations like using `.Length == 0` vs `.Any()` or `string.IsNullOrEmpty()`.

Provide a side-by-side comparison of the Original Code vs Optimized Code along with estimated memory/speed gains.
