# # Plus One

# 

# ## Pattern

# 

# Array Traversal / Carry Propagation

# 

# ## Initial Approach

# 

# Start from the last digit and increment it by one.

# 

# If the result is less than `10`, the operation is complete.

# 

# If the result is `10`, set the current digit to `0` and propagate the carry to the digit on the left.

# 

# If the carry reaches the first digit, create a new array with one additional position.

# 

# 

# ## Time Complexity

# 

# O(n)

# 

# Each digit is processed at most once while propagating the carry from right to left.

# 

# 

# ## Space Complexity

# 

# O(1) extra space in the normal case.

# 

# O(n) in the worst case when all digits are `9`, because a new array is created.

# 

# 



# [LeetCode Problem](https://leetcode.com/problems/plus-one/)


