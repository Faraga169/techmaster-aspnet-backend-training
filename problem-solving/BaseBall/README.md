# Baseball Game

## Pattern

Stack / Simulation

## Initial Approach

Process each operation sequentially while maintaining the valid scores in a `Stack<int>`.

Each operation represents one of four actions:

* Integer → Add a new score.
* `+` → Add the sum of the previous two scores.
* `D` → Add double the previous score.
* `C` → Remove the previous score.

## Optimized Approach

Use a `Stack<int>` to keep track of the valid scores.

For every operation:

1. If the operation is a number, parse it and add it to the stack.
2. If the operation is `D`, use `Peek()` to get the previous score and add double its value.
3. If the operation is `C`, use `Pop()` to remove the previous score.
4. If the operation is `+`, retrieve the previous two scores, calculate their sum, and add the new score.

The stack stores the valid scores in order:

```text
Score → Score → Score → ...
```

For example:

```text
Operations: ["5", "2", "C", "D", "+"]

5
↓
[5]

2
↓
[5, 2]

C
↓
[5]

D
↓
[5, 10]

+
↓
[5, 10, 15]
```

Final score:

```text
5 + 10 + 15 = 30
```

## Important Stack Operations

```csharp
Stack.Peek()
```

Returns the last score without removing it.

```csharp
Stack.Pop()
```

Removes and returns the last score.

```csharp
Stack.Push(value)
```

Adds a new score to the stack.

## Time Complexity

**O(n)**

Each operation is processed once, and stack operations such as `Push`, `Pop`, and `Peek` are **O(1)**.

## Space Complexity

**O(n)**

In the worst case, the stack can contain scores for all operations.

[LeetCode Problem](https://leetcode.com/problems/baseball-game/submissions/2109492550/)
