## Library Book Management API
A REST API for a library system that manages books and their borrowing records.

###  Models:
- Book (Id, Title, Author, ISBN, IsAvailable)
- BorrowingRecord (Id, BookId, BorrowDate, ReturnDate, BorrowerName)

###  API Endpoints

-  GET /api/books
-  POST /api/books
-  POST /api/books/{id}/checkout
-  POST /api/books/{id}/return
-  GET /api/books/{id}/history

### Swagger
#### https://localhost:8080/swagger/index.html
