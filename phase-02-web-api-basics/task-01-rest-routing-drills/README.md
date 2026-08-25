# Phase 02 — REST & Routing Drill Pack



A collection of small ASP.NET Core Web API drills focused on controllers, routing, query strings, request bodies, headers, validation, CRUD operations, pagination, and HTTP status codes.



## Required Output



* Minimum 15 API drills.

* Each drill documented in this README.

* Swagger screenshot for at least 5 drills.

* Postman evidence for at least 8 drills.

* Commit after every 3–5 drills.



## Drill Table



| Drill No. | Endpoint                                            | Concept                                    | Status  | Evidence           |

| --------- | --------------------------------------------------- | ------------------------------------------ | ------- | ------------------ |

| 01        | `GET /api/health`                                   | Basic endpoint / Controller action         | Done    | Swagger screenshot |

| 02        | `GET /api/tools/echo/{name}`                        | Route parameter                            | Done    | Postman screenshot |

| 03        | `GET /api/calculator/add?a=10&b=5`                  | Query parameters                           | Done    | Postman screenshot |

| 04        | `GET /api/converter/celsius-to-fahrenheit?value=25` | Business calculation + Service + DI        | Done    | Swagger screenshot |

| 05        | `GET /api/grades/calculate?score=85`                | Validation + Conditions                    | Done    | Postman screenshot |

| 06        | `POST /api/notes`                                   | Request body + DTO + Create resource       | Done    | Postman screenshot |

| 07        | `GET /api/notes`                                    | Collection response                        | Done    | Swagger screenshot |

| 08        | `GET /api/notes/{id}`                               | Route ID + 404 Not Found                   | Done    | Postman screenshot |

| 09        | `PUT /api/notes/{id}`                               | PUT update + DTO validation                | Done    | Postman screenshot |

| 10        | `DELETE /api/notes/{id}`                            | DELETE + 204 No Content                    | Done    | Postman screenshot |

| 11        | `GET /api/notes/search?keyword=api`                 | Query string search + LINQ                 | Done    | Postman screenshot |

| 12        | `GET /api/notes/pagination?pageNumber=1&pageSize=5` | Pagination + Skip / Take                   | Done    | Swagger screenshot |

| 13        | `GET /api/request-info`                             | Custom request headers                     | Done    | Postman screenshot |

| 14        | `GET/POST multiple`                                 | HTTP status codes: 200, 201, 204, 400, 404 | Done    | —                  |

| 15        | `GET /api/errors/demo`                              | Standard error response shape              | Done    | —                  |



## Drill Details



### Drill 01 — Health Check



**Endpoint:** `GET /api/health`



**Purpose:** Verify that the API is running and reachable.



**Response:**



* HTTP `200 OK`

* JSON response containing status, service name, and server time.



---



### Drill 02 — Route Parameter Echo



**Endpoint:** `GET /api/tools/echo/{name}`



**Purpose:** Practice receiving data directly from the route.



**Example:**



```http

GET /api/tools/echo/Ahmed

```



The response contains the original name and a greeting message.



---



### Drill 03 — Query String Calculator



**Endpoint:** `GET /api/calculator/add?a=10&b=5`



**Purpose:** Practice receiving values from the query string and returning a calculated result.



**Response fields:**



* `a`

* `b`

* `operation`

* `result`



---



### Drill 04 — Temperature Conversion API



**Endpoint:** `GET /api/converter/celsius-to-fahrenheit?value=25`



**Purpose:** Convert the Phase 01 temperature calculation into an API endpoint.



The calculation is handled by `ConverterService` and injected through Dependency Injection.



**Formula:**



```text

Fahrenheit = (Celsius × 9 / 5) + 32

```



---



### Drill 05 — Grade API



**Endpoint:** `GET /api/grades/calculate?score=85`



**Purpose:** Practice validation and conditional logic inside an API endpoint.



The score must be between `0` and `100`.



Invalid values return:



```text

400 Bad Request

```



Valid values return the grade and pass/fail status.



---



### Drill 06 — Create Note



**Endpoint:** `POST /api/notes`



**Purpose:** Practice receiving JSON request bodies through a DTO and creating a new resource.



The request uses `CreateNoteRequest`.



A successful creation returns the generated:



* ID

* Title

* Content

* CreatedAt



---



### Drill 07 — Get Notes List



**Endpoint:** `GET /api/notes`



**Purpose:** Practice returning a collection from an API endpoint.



The endpoint returns all in-memory notes as a JSON collection.



If no notes exist, an empty collection can be returned.



---



### Drill 08 — Get Note By ID



**Endpoint:** `GET /api/notes/{id}`



**Purpose:** Practice route parameters and `404 Not Found`.



If the note exists:



```text

200 OK

```



If the note does not exist:



```text

404 Not Found

```



---



### Drill 09 — Update Note



**Endpoint:** `PUT /api/notes/{id}`



**Purpose:** Practice updating an existing resource using a route ID and request body DTO.



The endpoint validates:



* Title

* Content



If the note does not exist:



```text

404 Not Found

```



If validation fails:



```text

400 Bad Request

```



A successful update returns the updated note.



---



### Drill 10 — Delete Note



**Endpoint:** `DELETE /api/notes/{id}`



**Purpose:** Practice RESTful DELETE behavior and HTTP status codes.



If the note exists, it is removed and the endpoint returns:



```text

204 No Content

```



If the note does not exist:



```text

404 Not Found

```



---



### Drill 11 — Search Notes



**Endpoint:** `GET /api/notes/search?keyword=api`



**Purpose:** Practice query string search and LINQ filtering.



The endpoint searches both:



* Note title

* Note content



The search is case-insensitive.



An empty keyword returns:



```text

400 Bad Request

```



---



### Drill 12 — Pagination



**Endpoint:** `GET /api/notes/pagination?pageNumber=1&pageSize=5`



**Purpose:** Practice API pagination using LINQ `Skip()` and `Take()`.



Pagination calculation:



```text

Skip = (pageNumber - 1) × pageSize

Take = pageSize

```



The response contains:



* `items`

* `pageNumber`

* `pageSize`

* `totalCount`



Validation:



* `pageNumber` must be greater than `0`.

* `pageSize` must be between `1` and `50`.



---



### Drill 13 — Header Reader



**Endpoint:** `GET /api/request-info`



**Purpose:** Practice reading custom HTTP request headers.



The endpoint reads:



```http

X-Student-Name: Ahmed

```



The response contains:



* Student name from the header.

* Current request path.



If the header is missing:



```text

400 Bad Request

```



---



## HTTP Status Codes Used



| Status Code       | Meaning                                         | Example                         |

| ----------------- | ----------------------------------------------- | ------------------------------- |

| `200 OK`          | Request succeeded and response data is returned | Get note                        |

| `201 Created`     | A new resource was created                      | Create note                     |

| `204 No Content`  | Operation succeeded without response body       | Delete note                     |

| `400 Bad Request` | Client sent invalid or incomplete input         | Invalid score / missing keyword |

| `404 Not Found`   | Requested resource does not exist               | Note not found                  |



## Key Concepts Practiced



* Controllers and Actions

* HTTP Methods

* Route Parameters

* Query Parameters

* Request Body

* DTOs

* Model Validation

* Dependency Injection

* Services

* LINQ

* CRUD Operations

* HTTP Headers

* HTTP Status Codes

* Search

* Pagination

* `Skip()` and `Take()`

* Standard API Response Shapes

