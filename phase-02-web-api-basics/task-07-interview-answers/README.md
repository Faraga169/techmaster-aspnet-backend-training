# Phase 02 — Required Questions & Answers



## 1. What does REST mean in the context of Web APIs?



REST stands for Representational State Transfer. It is an architectural style for designing distributed systems and Web APIs. It uses resources identified by URLs and standard HTTP methods such as GET, POST, PUT and DELETE to operate on those resources. RESTful systems follow constraints such as client-server, statelessness, uniform interface, cacheability and layered system.



---



## 2. What is the difference between GET, POST, PUT, PATCH and DELETE?



GET is used to retrieve resources. POST is commonly used to create a new resource. PUT is used to replace an entire resource, while PATCH is used to partially update a resource. DELETE is used to remove a resource. GET and DELETE typically don't use request bodies, while POST, PUT, and PATCH commonly send data in the request body.



---



## 3. When should an API return 200, 201, 204, 400 and 404?



200 OK is returned when a request is successfully processed and a response is returned. 201 Created is used when a new resource is successfully created. 204 No Content means the operation succeeded but there is no response body. 400 Bad Request indicates that the client's request is invalid, such as validation errors. 404 Not Found means the requested resource or route could not be found.



---



## 4. What is the difference between route parameters and query parameters?



A route parameter is part of the URL path and is typically used to identify a specific resource, such as /api/products/5. A query parameter comes after ? in the URL and is commonly used for filtering, searching, sorting, or pagination, such as /api/products?name=laptop&page=2.



---



## 5. What is the role of a controller in ASP.NET Core Web API?



A Controller is responsible for handling HTTP requests and returning HTTP responses. It defines routes and actions, receives input from the client, and delegates business operations to the Service Layer. The Controller should remain thin and should not contain business logic or data access logic. Services are injected into the Controller using Dependency Injection. Input validation can be handled through DTOs and model validation, while business validation belongs in the Service Layer.



---



## 6. Why should we use DTOs instead of exposing models directly?



We use DTOs to control the data exchanged between the client and the API instead of exposing our internal models directly. DTOs improve security by preventing sensitive properties from being exposed, prevent overposting, and provide separation between the API contract and the internal domain model. They also allow us to have different request and response shapes and make the API easier to maintain when the internal model changes.



---



## 7. Why should business logic not stay inside the controller?



Business logic should not stay inside the Controller because Controllers should focus on handling HTTP concerns such as routing, model binding, and returning HTTP responses. Business rules should be placed in the Service Layer to follow Separation of Concerns. This makes the application easier to maintain, test, and reuse. Input validation can be handled through DTOs and model validation, while business validation belongs in the Service Layer.



---



## 8. What is Dependency Injection and why is it useful?



Dependency Injection is a design technique used to provide a class with the dependencies it needs instead of creating them internally. It helps reduce tight coupling by making classes depend on abstractions rather than concrete implementations. In ASP.NET Core, dependencies are registered in the DI container and injected, usually through the constructor. This improves maintainability, flexibility, and testability.



---



## 9. Where can validation happen in a Web API?



Validation can happen at different levels. Input or model validation can be handled using Data Annotations on DTOs, and with [ApiController], ASP.NET Core automatically returns a 400 Bad Request when model validation fails before the action executes. Business validation, such as checking whether a product already exists or whether there is enough stock, should be handled in the Service Layer.



---



## 10. What is Swagger/OpenAPI used for?



OpenAPI is a standard specification used to describe and document Web APIs, including their endpoints, parameters, request bodies, responses, and schemas. Swagger is a set of tools built around the OpenAPI specification, such as Swagger UI, which provides interactive API documentation and allows developers to test endpoints directly from the browser.



---



## 11. Why do we need Postman if Swagger already exists?



Swagger can be used to interact with and test individual endpoints, but Postman provides more advanced and organized testing capabilities such as collections, environments, variables, scripts, and automated test scenarios.



---



## 12. What makes an API response professional and predictable?



A professional API should have a clear and consistent response shape. We should use DTOs to define the response contract and ActionResult<T> to make the expected response type explicit. HTTP status codes should accurately represent the result of the operation, and error responses should follow a consistent structure. This makes the API predictable for clients and easier to document with Swagger/OpenAPI.



---



## 13. How would you implement search and filtering in an API?



Search and filtering are usually implemented using query parameters because they modify how we retrieve a collection without identifying a specific resource. I can use LINQ Where to apply filters, and for text search I can use methods such as Contains for partial matching. Multiple query parameters can be combined to support different filtering criteria.



---



## 14. Why is pagination important in APIs?



Pagination is important because returning a large number of records in a single response can increase response size, memory usage, network bandwidth, database load, and response time. We can use pageNumber and pageSize to return only a specific portion of the data. In LINQ, this can be implemented using Skip((pageNumber - 1) * pageSize) and Take(pageSize), preferably at the database query level.



---



## 15. What is the difference between UI, controller, service and data storage?



The UI is responsible for user interaction and sending HTTP requests. The Controller handles HTTP concerns such as routing, model binding, validation, and returning HTTP responses. The Service Layer contains business logic and business rules. The Data Access or Storage layer is responsible for storing and retrieving data from sources such as a database. This separation follows Separation of Concerns and makes the application easier to maintain and test.



---



## 16. What should reviewers see in your commit history?



Reviewers should see clear and focused commits where each commit represents a specific change or feature. Meaningful commit messages make the project history easier to understand and allow reviewers to follow how the project evolved.



---



## 17. How do you prove that your API works without running it on the reviewer device?



I can prove that the API works using Swagger and Postman evidence. I can provide screenshots showing successful and failure responses, export the Postman collection as JSON so the reviewer can inspect or import the requests, and include a README explaining how to use the collection. I can also provide a demo video showing the API in action.



---



## 18. How do you investigate an endpoint that returns 500?



When an endpoint returns 500, I first reproduce the issue and check the logs and exception details, including the stack trace. Then I debug through the request flow from the Controller to the Service and Data Access layer to identify where the exception occurs. I also check database issues, dependency injection, and configuration if needed. After fixing the issue, I retest the endpoint. In production, I avoid exposing detailed exception information to the client and use centralized exception handling and logging instead.



---



## 19. Why should we not trust request data from users?



We should never trust data coming from the client because client-side validation can be bypassed or removed, and users can send requests directly using tools such as Postman or custom clients. Therefore, the backend must validate and verify all incoming data and enforce business rules, authentication, and authorization before processing the request or storing the data.



---



## 20. Why is in-memory storage not enough for real applications?



In-memory storage is not enough for real applications because the data is temporary and is lost when the application restarts or crashes. It also does not work well when the application runs on multiple servers because each server has its own memory. In addition, it does not provide the persistence, concurrency control, transactions, backup, and querying capabilities that a real database provides.



