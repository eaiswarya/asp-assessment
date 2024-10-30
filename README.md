## Library Book Management API

###  Models:
- Book (Id, Title, Author, ISBN, IsAvailable)
- BorrowingRecord (Id, BookId, BorrowDate, ReturnDate, BorrowerName)

### 2. API Endpoints

#### 2.1 GET /api/books
#### 2.2 POST /api/books
#### 2.3 POST /api/books/{id}/checkout
#### 2.4 POST /api/books/{id}/return
#### 2.5 GET /api/books/{id}/history

### Swagger
#### https://localhost:8080/swagger/index.html
