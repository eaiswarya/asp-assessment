## Library Book Management API

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
