# 📚 Library CRUD API

This project is a **.NET REST API** for managing authors and books in a simulated library system.
It implements full **CRUD (Create, Read, Update, Delete)** operations and uses **Swagger UI** for interactive documentation and testing.

---

## 🚀 Features

### Author Endpoints

* **GET** `/api/Author/ListAuthors` → Get all authors
* **GET** `/api/Author/FindAuthorById/{authorId}` → Get an author by ID
* **GET** `/api/Author/FindAuthorByBookId/{bookId}` → Get the author of a specific book 
* **POST** `/api/Author/CreateAuthor` → Create a new author
* **PUT** `/api/Author/EditAuthor` → Update an existing author
* **DELETE** `/api/Author/DeleteAuthor` → Delete an author

### Book Endpoints

* **GET** `/api/Book/ListBook` → Get all books
* **GET** `/api/Book/FindBookById/{bookId}` → Get a book by ID
* **GET** `/api/Book/FindBookByAuthorId/{authorId}` → Get all books from a specific author
* **POST** `/api/Book/CreateBook` → Create a new book
* **PUT** `/api/Book/EditBook` → Update an existing book
* **DELETE** `/api/Book/DeleteBook` → Delete a book

---

## 🛠 Tech Stack

* **.NET 8**
* **Entity Framework Core**
* **Swagger UI** for API documentation
* **SQL Server**

---

## ▶️ Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/yourusername/LibraryCrud.git
cd LibraryCrud
```

### 2. Configure the database

Edit the `appsettings.json` file and update your database connection string.

### 3. Apply migrations 

### 4. Run the project

### 5. Access Swagger UI

Once the project is running, open:

```
http://localhost:5000/swagger
```

## 📌 Project Purpose

This repository was created for learning and practicing RESTful API development with .NET.
It demonstrates how to build a clean CRUD API with Swagger documentation, Entity Framework Core, and SQL Server.

---
