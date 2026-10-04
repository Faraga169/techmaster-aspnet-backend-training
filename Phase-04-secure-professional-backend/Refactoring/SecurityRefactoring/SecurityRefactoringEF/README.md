# Task 08 — Bad Auth Refactor Pack

## 📌 Overview

This task was a practical backend security refactoring exercise.

The starting point was intentionally insecure authentication code that handled passwords, tokens, user registration, and database access directly inside the controller.

The goal was to review the code like a real backend code review task, identify the security and architecture problems, and refactor the authentication flow into a safer and more maintainable implementation.

---

# 🔴 Before — Insecure Authentication

The original `AuthController` contained several security and architecture problems.

### Original Problems

```csharp
[HttpPost("login")]
public IActionResult Login(LoginRequest request)
{
    var user = db.Users.FirstOrDefault(x => x.Email == request.Email);

    if (user == null)
        return Ok("wrong email");

    if (user.PasswordHash != request.Password)
        return Ok("wrong password");

    var token = "fake-token-" + user.Id;

    return Ok(new
    {
        token = token,
        user = user
    });
}
```

The registration endpoint was also insecure:

```csharp
[HttpPost("register")]
public IActionResult Register(RegisterRequest request)
{
    var user = new ApplicationUser();

    user.FullName = request.FullName;
    user.Email = request.Email;
    user.PasswordHash = request.Password;
    user.Role = request.Role;

    db.Users.Add(user);
    db.SaveChanges();

    return Ok(user);
}
```

### Main Security Issues

| #  | Problem                                 | Risk                                           |
| -- | --------------------------------------- | ---------------------------------------------- |
| 1  | Password compared as plain text         | Password security vulnerability                |
| 2  | Password stored directly                | Credentials could be exposed                   |
| 3  | Fake token generation                   | No real authentication                         |
| 4  | Full user entity returned               | Sensitive data exposure                        |
| 5  | No request validation                   | Invalid/malicious input accepted               |
| 6  | Role supplied by the client             | Privilege escalation                           |
| 7  | `DbContext` used directly in controller | Business logic and data access tightly coupled |
| 8  | Incorrect HTTP status codes             | Poor API behavior and security semantics       |
| 9  | Synchronous database operations         | Poor scalability                               |
| 10 | No account status check                 | Inactive users could authenticate              |
| 11 | No duplicate email validation           | Duplicate accounts possible                    |


---

# 🟢 After — Refactored Authentication

The authentication flow was completely refactored using the project's existing secure backend architecture.

### New Flow

```text
Client
   ↓
AuthController
   ↓
AuthService
   ↓
ASP.NET Core Identity
   ↓
UserManager / RoleManager
   ↓
Database
```

For login:

```text
Login Request
     ↓
Validate Input
     ↓
Find User
     ↓
Check IsActive
     ↓
Verify Password
     ↓
Get User Roles
     ↓
Generate JWT
     ↓
Return Safe AuthResponse
```

---

# 🔐 Security Improvements

## 1. Password Hashing

### Before

```csharp
user.PasswordHash = request.Password;
```

and:

```csharp
user.PasswordHash != request.Password
```

### After

ASP.NET Core Identity handles password hashing and verification through `UserManager`.

```csharp
await userManager.CreateAsync(user, request.Password);
```

Password verification is performed using Identity's secure password verification mechanism.

Passwords are never stored or compared as plain text.

---

## 2. Real JWT Instead of Fake Token

### Before

```csharp
var token = "fake-token-" + user.Id;
```

### After

The application generates a real signed JWT containing authentication claims such as:

* User ID
* Email
* Role

The token is then used with:

```text
Authorization: Bearer <access_token>
```

This allows protected endpoints to use ASP.NET Core authorization.

---

## 3. Safe Authentication Response

### Before

```csharp
return Ok(new
{
    token = token,
    user = user
});
```

Returning the complete user entity could expose sensitive database fields.

### After

A dedicated authentication response DTO is returned.

```text
AuthResponse
├── AccessToken
├── RefreshToken
└── User Information
```

Only the required information is exposed to the client.

Sensitive properties such as password hashes are never returned.

---

# ✅ 4. Input Validation

The refactored authentication flow validates incoming requests.

Validation covers:

* Required fields
* Email format
* Password requirements
* Role restrictions
* Duplicate email
* Invalid authentication data

Invalid requests are rejected before they reach the business logic.

---

# 🛡️ 5. Role Creation Restrictions

### Before

The client could send:

```json
{
    "role": "Admin"
}
```

This creates a privilege escalation vulnerability.

### After

Public registration cannot freely create privileged roles.

Normal registration creates a:

```text
Student
```

Admin and Instructor accounts are controlled by the application/admin seeding process rather than being freely selected by the client.

---

# 🏗️ 6. Business Logic Moved to AuthService

### Before

The controller directly accessed:

```csharp
AppDbContext
```

and contained database and authentication logic.

### After

The controller is responsible mainly for handling HTTP requests and responses.

Authentication logic is handled by:

```text
AuthService
```

This provides:

* Separation of concerns
* Better testability
* Cleaner controllers
* Reusable authentication logic
* Easier maintenance

---

# 📡 7. Correct HTTP Status Codes

The refactored API uses meaningful HTTP status codes.

Examples:

| Status             | Usage                              |
| ------------------ | ---------------------------------- |
| `200 OK`           | Successful login/operation         |
| `201 Created`      | Successful resource creation       |
| `400 Bad Request`  | Invalid request data               |
| `401 Unauthorized` | Invalid authentication credentials |
| `403 Forbidden`    | Authenticated but not allowed      |
| `409 Conflict`     | Duplicate/conflicting resource     |

This is more correct than returning `200 OK` for authentication failures.

---

# ⚡ 8. Async Database Operations

### Before

```csharp
db.Users.FirstOrDefault(...)
db.SaveChanges()
```

### After

The authentication flow uses asynchronous operations such as:

```csharp
await ...
```

This prevents unnecessary thread blocking and follows ASP.NET Core best practices for I/O-bound operations.

---

# 🚫 9. Inactive Account Protection

The refactored login flow checks the user's account status before allowing authentication.

```text
IsActive = false
        ↓
Login rejected
        ↓
403 Forbidden
```

Inactive accounts cannot obtain authentication tokens.

---


---

# 🔄 Before vs After

| Area            | Before                | After                                 |
| --------------- | --------------------- | ------------------------------------- |
| Passwords       | Plain-text comparison | ASP.NET Identity hashing/verification |
| Token           | Fake string           | Real signed JWT                       |
| User response   | Full entity           | Safe DTO                              |
| Validation      | None                  | Request validation                    |
| Roles           | Client-controlled     | Restricted                            |
| Database access | Controller            | AuthService + Identity                |
| HTTP status     | Mostly `200 OK`       | Correct status codes                  |
| Database calls  | Synchronous           | Async                                 |
| Account status  | Ignored               | `IsActive` checked                    |
| Duplicate email | Not handled           | Validated                             |
 |

---

# 🏛️ Architecture After Refactoring

```text
                ┌─────────────────┐
                │     Client      │
                └────────┬────────┘
                         │
                         ▼
                ┌─────────────────┐
                │ AuthController  │
                └────────┬────────┘
                         │
                         ▼
                ┌─────────────────┐
                │   AuthService   │
                └────────┬────────┘
                         │
             ┌───────────┴───────────┐
             ▼                       ▼
    ┌─────────────────┐     ┌─────────────────┐
    │ ASP.NET Identity│     │   JWT Service   │
    └────────┬────────┘     └────────┬────────┘
             │                       │
             └───────────┬───────────┘
                         ▼
                ┌─────────────────┐
                │    Database     │
                └─────────────────┘
```

---

# 📦 Refactor Deliverables

The task includes:

* Refactored authentication code
* Secure password handling
* Real JWT authentication
* Safe authentication response DTO
* Request validation
* Role restrictions
* Service-layer authentication logic
* Correct HTTP status codes
* Async database operations
* Inactive account protection
* Authentication logging
* Before/After documentation
* Refactor progress commits
* Testing screenshots/notes

---

# 🧪 Testing

The refactored authentication flow was tested through the API client/Swagger to verify:

### Registration

* Valid registration succeeds
* Invalid input is rejected
* Duplicate email is rejected
* Privileged roles cannot be freely assigned

### Login

* Valid credentials return a real JWT
* Invalid credentials are rejected
* Inactive users cannot login
* Returned response does not expose password information

### Authorization

The generated JWT can be used to access protected endpoints according to the user's role and permissions.

---

# 📌 Conclusion

This task transformed the original insecure authentication implementation into a structured and security-focused authentication flow.

The main improvements were:

**Secure passwords → Real JWT → Safe DTOs → Validation → Role protection → Service layer → Correct status codes → Async operations → Account protection → Security logging**

The refactoring demonstrates how insecure authentication code can be reviewed, identified, and progressively improved using standard ASP.NET Core security and architecture practices.
