# Book-API

This is a simple RESTful API developed using .NET Core 3.1 (or later), designed to manage book records in a database. The API allows you to perform CRUD operations on book data, including sorting by various fields and calculating the total price of all books.

# Features
*Sort Books:* Sort books by Publisher, Author (Last, First), and Title.

*Total Price:* Calculate the total price of all books in the database.

*Bulk Insert:* Save a large number of books to the database in one API call.

*Citations:* Generate MLA and Chicago style citations for books.

# Technologies Used
.NET Core 3.1 or above
Entity Framework Core (for data access)
SQL Server (for database)

# Testing the APIs
Once the API is running, you can test the following endpoints:

# 1. Get Books Sorted by Publisher
Endpoint: GET /api/books/sorted-by-publisher

Description: Returns a list of books sorted by Publisher, then by Author (Last, First), then by Title.

# 2. Get Books Sorted by Author
Endpoint: GET /api/books/sorted-by-author

Description: Returns a list of books sorted by Author (Last, First), then by Title.

# 3. Get Total Price of All Books
Endpoint: GET /api/books/total-price

Description: Returns the total price of all books in the database.

# 4. Bulk Insert Books
Endpoint: POST /api/books/bulk-insert

Description: Inserts a list of books into the database.

Request Body Example:

  {
    "Publisher": "Penguin Random House",
    "Title": "The Great Gatsby",
    "AuthorLastName": "Fitzgerald",
    "AuthorFirstName": "F. Scott",
    "Price": 10.99
  },  
  {
    "Publisher": "HarperCollins",
    "Title": "1984",
    "AuthorLastName": "Orwell",
    "AuthorFirstName": "George",
    "Price": 8.99
  }

# 5. Get Books Sorted by Publisher (Using Stored Procedure)
Endpoint: GET /api/books/sorted-by-publisher-sp

Description: Uses a stored procedure to return a sorted list of books.

# 6. Get Books Sorted by Author (Using Stored Procedure)
Endpoint: GET /api/books/sorted-by-author-sp

Description: Uses a stored procedure to return a sorted list of books.


# Test Data
For testing purposes, here is some sample JSON data you can use to populate your database via the Bulk Insert API:

Sample Books Data (for Bulk Insert)

  {
    "Publisher": "Penguin Random House",
    "Title": "The Great Gatsby",
    "AuthorLastName": "Fitzgerald",
    "AuthorFirstName": "F. Scott",
    "Price": 10.99
  },
  {
    "Publisher": "HarperCollins",
    "Title": "1984",
    "AuthorLastName": "Orwell",
    "AuthorFirstName": "George",
    "Price": 8.99
  },
  {
    "Publisher": "Macmillan",
    "Title": "To Kill a Mockingbird",
    "AuthorLastName": "Lee",
    "AuthorFirstName": "Harper",
    "Price": 12.49
  },
  {
    "Publisher": "Penguin Random House",
    "Title": "Moby-Dick",
    "AuthorLastName": "Melville",
    "AuthorFirstName": "Herman",
    "Price": 15.99
  },
  {
    "Publisher": "Simon & Schuster",
    "Title": "The Catcher in the Rye",
    "AuthorLastName": "Salinger",
    "AuthorFirstName": "J.D.",
    "Price": 9.99
  }
