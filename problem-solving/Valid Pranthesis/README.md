# Valid Parentheses

## Pattern
Stack / Matching Pairs

## Initial Approach
Use a `Stack<char>` to store opening brackets.

For each character:
- If it is an opening bracket, push it into the stack.
- If it is a closing bracket, check the top of the stack.
- If the brackets do not match, return `false`.
- At the end, the stack must be empty for the string to be valid.

## Time Complexity
O(n)

## Space Complexity
O(n)

## Approach
A stack is suitable for this problem because the last opening bracket must be the first one to be matched.

https://leetcode.com/problems/valid-parentheses/submissions/2111287572/