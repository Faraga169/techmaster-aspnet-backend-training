# # Two Sum

# 

# ## Pattern

# 

# Hash Map / Dictionary

# 

# ## Initial Approach

# 

# For each element, search through the remaining elements to find another number whose sum equals the target.

# 

# This approach requires nested loops and has a time complexity of **O(n²)**.

# 

# ## Optimized Approach

# 

# Use a `Dictionary<int, int>` to store each number along with its index.

# 

# For every element:

# 

# 1. Calculate the number needed to reach the target:

# 

# &#x20;  ```csharp

# &#x20;  int needed = target - nums[i];

# &#x20;  ```

# 2. Check if `needed` already exists in the dictionary.

# 3. If it exists, return the stored index and the current index.

# 4. Otherwise, store the current number and its index.

# 

# The dictionary stores data in this format:

# 

# ```text

# Number → Index

# ```

# 

# For example:

# 

# ```text

# { 3 → 0, 2 → 1 }

# ```

# 

# 

# ## Time Complexity

# 

# O(n)

# 

# Each element is processed once, and dictionary lookup is O(1) on average.

# 

# ## Space Complexity

# 

# O(n)

# 

# In the worst case, the dictionary stores all elements.

# 

# 

# 

# [LeetCode Problem](https://leetcode.com/problems/two-sum/submissions/2108252915/)



