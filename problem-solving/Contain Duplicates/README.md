# Contains Duplicate

## Pattern

Hash Set / Hashing

## Initial Approach

Use a `HashSet<int>` to keep track of the numbers that have already been seen.

For each element in the array:

* Try to add the number to the `HashSet`.
* If `Add()` returns `false`, the number already exists in the set.
* Return `true` because a duplicate was found.
* If the loop finishes without finding a duplicate, return `false`.


## Time Complexity

O(n)

Each element is checked and added to the `HashSet` once.

## Space Complexity

O(n)

In the worst case, the `HashSet` stores all elements when there are no duplicates.


## Key Concept

`HashSet<T>.Add()` returns:

* `true` → the element was added successfully and did not exist before.
* `false` → the element already exists in the `HashSet`.

This makes it possible to detect duplicates in **O(n)** time.

[LeetCode Problem]https://leetcode.com/problems/contains-duplicate/submissions/2108193758/
