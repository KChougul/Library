## Environment:  
- .NET version: 3.0

## Read-Only Files:   
- LibraryService.Tests/IntegrationTests.cs

## Data:  
Example of a book data JSON object:
```
{
    id: 1,
    title: "title 1",
    body: "Advantage old had otherwise sincerity dependent additions.",
    authorName: "Rick D.",
    publishedDate: 1573843210
}
```

## Requirements:

A company is launching a library service for managing books. The service should be a web API layer using .NET Core 3.0. You already have a prepared infrastructure and need to implement the Web API Controllers "BooksController". Use the Middleware mechanism from .Net Core to keep the track of total count of requests to this API service.


The following API calls are implemented:

1. Creating books - a POST request to the endpoint api/books adds the book to the database. The HTTP response code is 200.  
2. Getting all books - a GET request to the endpoint api/books returns the entire list of books. The HTTP response code is 200.  
3. Getting book by id - a GET request to the endpoint api/books/{id} returns the details of the book for {id}. If there is no book with {id}, status code 404 is returned. On success, status code 200 is returned.  
4. Getting all books filtered by the authorName property- a GET request to the endpoint api/books?AuthorNames={AuthorName1}&AuthorNames={AuthorName2} returns the entire list of books for AuthorName1 and AuthorName2. The HTTP response code is 200.  


Complete the Middleware of the project in the following way:  

- The Middleware needs to track the number of calls to this back-end service. For this, it maintains the counter and keeps incrementing the counter value by 1 on every request. For each request, return the current value of the counter in the response header with the name "requestCounter". Middleware should set the counter to 0 on project/API configuration.  

Note: Integration tests take care of testing the Middleware. Each integration test sets up the API service again before its execution (as a pre-execution step), so for each integration test, the counter value starts from 0. For example, if you make 3 calls to the API service per 1 integration test, then the response for the last request in this test contains the header "requestCounter" with the value 3.





Definition of Book model:  
+ id - The ID of the book. [INTEGER]  
+ title - The title of the book. [STRING]  
+ body - The content of the book. [STRING]  
+ authorName - The name of the book's author. [STRING]  
+ publishedDate - The date when the book was published in UTC (GMT + 0). [EPOCH INTEGER]


## Example requests and responses with headers


**Request 1:**

POST request to api/books

Request body:

```
{
    id: 1,
    title: "title 1",
    body: "Advantage old had otherwise sincerity dependent additions.",
    authorName: "Rick D.",
    publishedDate: 1573843210
}
```

The response code will be 200 because the document was created. It also contains the header "requestCounter" with the value 1 because the service endpoint is called only once.

**Request 2:**  

GET request to api/books/1  

The response code will be 200 with the book's details:

```
{
    id: 1,
    title: "title 1",
    body: "Advantage old had otherwise sincerity dependent additions.",
    authorName: "Rick D.",
    publishedDate: 1573843210
}
```

It also contains the header "requestCounter" with the value 2 because the service endpoint is called twice (POST request 1 for creating, and GET request 2 for getting a book).
