## 📥 How to Import the Postman Collection

The Phase 02 APIs are organized into a single Postman collection:

```text
TechMaster ASP.NET Phase 02
```

The collection contains folders for:

* Student Management API
* Products & Categories API
* Book Store API
* Error Cases

### 1. Open Postman

Launch **Postman** on your computer.

### 2. Import the Collection

Click **Import** from the Postman workspace.

Select the exported collection file:

```text
TechMaster ASP.NET Phase 02.postman_collection.json
```

Postman will import the complete collection with all folders and requests.

### 3. Configure the Base URL

The collection uses the `baseUrl` variable for the API address.

Set it to the URL where the ASP.NET Core APIs are running.

Example:

```text
baseUrl = https://localhost:7101
```

Requests can then use:

```text
{{baseUrl}}/api/Student
```

instead of writing the complete URL in every request.

### 4. Run the API

Before sending requests, make sure the corresponding ASP.NET Core API is running.

For example:

```bash
dotnet run
```

### 5. Send Requests

Open the imported collection and select the required folder:

```text
TechMaster ASP.NET Phase 02
│
├── Student Management API
├── Products & Categories API
├── Book Store API
└── Error Cases
```

Select any request and click **Send**.

### 6. Verify the Response

Check the HTTP status code and response body to verify that the endpoint is working correctly.

The collection includes both **successful requests** and **error cases** to demonstrate the API behavior under different scenarios.
