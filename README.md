# PaparaBootcamp

WEEK 1
---------------
Project Overview🔎
-------------
This project provides a simple API for managing accounts, supporting basic CRUD operations. The API allows users to perform the following actions:

☑️Create, Read, Update, and Delete (CRUD) accounts.

☑️Partial Update to modify the account balance.

☑️List accounts filtered by the owner's name and sorted by balance.

☑️It also includes basic error handling middleware to manage unexpected errors gracefully.

Features🔑
-------------
☑️Account: Represents an account with properties such as account number, owner name, balance, and account type.

☑️AccountsController: Provides endpoints to manage accounts, including:

•Get all accounts.

•Get a specific account by ID or account number.

•Create, update, and delete accounts.

•Partial update to modify the balance.

•List accounts with filtering and sorting options.

☑️Error Handling: A middleware to catch unhandled exceptions and return an appropriate error response.

Technologies🖥️
-------------
.NET 6 or later

ASP.NET Core Web API

API Endpoints🎯
-------------
1. Get All Accounts📌

Endpoint: GET /api/accounts/GetAll

Retrieves all accounts.

Response: A list of all accounts in the system.

2. Get Account by ID📌

Endpoint: GET /api/accounts/GetById/{id}

Retrieves a single account by its ID.

Parameters:

•id: The ID of the account.

Response: The account details, or a 404 error if not found.

3. Create Account📌

Endpoint: POST /api/accounts

Creates a new account.

Request Body:
```json
{
  "AccountNumber": "1234567890",
  "OwnerName": "John Doe",
  "Balance": 5000.00,
  "AccountType": "Checking"
}
```
Response: The newly created account.

4. Update Account📌

Endpoint: PUT /api/accounts/{id}

Updates an existing account.

Request Body:
```json
{
  "AccountNumber": "1234567890",
  "OwnerName": "Jane Doe",
  "Balance": 6000.00,
  "AccountType": "Savings"
}
```
Parameters:

•id: The ID of the account to update.

Response: The updated account.

5. Partial Update Account (Balance)📌

Endpoint: PATCH /api/accounts/{accountNumber}

Partially updates an account (only the balance in this case).

Request Body:
```json
{
  "Balance": 7000.00
}
```
Parameters:

•accountNumber: The account number of the account to update.

Response: The updated account.

6. Delete Account📌

Endpoint: DELETE /api/accounts/{id}

Deletes an account by its ID.

Parameters:

•id: The ID of the account to delete.

Response: No Content if successful, or a 404 error if not found.

7. List Accounts📌

Endpoint: GET /api/accounts/list

Lists accounts with optional filtering and sorting.

Query Parameters:

•name: Filters accounts by the owner's name.

•sortBy: Sorts the accounts (options: balance, balance_desc).

Response: A list of accounts matching the provided filters.

Error Handling⚙️
-------------
If an unexpected error occurs during any of the API requests, the ErrorHandlerMiddleware catches the exception and returns a 500 response with a JSON message.

WEEK 2
---------------------
🤖Fake User Authentication API
----------------------------
This project is a simple .NET API with a fake authentication system, custom authorization attribute, and global exception middleware. The API allows managing accounts and ensures that only authorized users can access certain endpoints.

✨Features
-----------------
• Fake user authentication using predefined tokens

• Custom authorization attribute to secure endpoints

• Global exception middleware for error handling

• CRUD operations for managing accounts

🖥️Technologies Used
-----------------
• .NET 8 Web API

• C#

• ASP.NET Core Middleware

🚩API Endpoints
-----------------
Authentication

The API uses a fake authentication service where users are identified by static tokens.

🔍Valid Tokens:

• Admin: admin-token

• User: user-token

📍Account Management
-----------------
![Ekran görüntüsü 2025-03-17 211101](https://github.com/user-attachments/assets/45b68971-5818-43a4-8b6e-b3a1844ad0f9)

🎯Code Overview
-----------------
⚙️Fake Authentication Service

![Ekran görüntüsü 2025-03-17 211405](https://github.com/user-attachments/assets/b23882e2-eab7-4600-90d5-458d62465f76)

📚Custom Authorization Attribute

![Ekran görüntüsü 2025-03-17 211302](https://github.com/user-attachments/assets/551de5ed-8768-4f5b-b8fe-5f610db5af01)

🛠️Global Exception Middleware and Global Logging

![Ekran görüntüsü 2025-03-17 211457](https://github.com/user-attachments/assets/4a8a4de6-77dc-4ff8-857d-7f97f123d69e)

![Ekran görüntüsü 2025-03-17 211503](https://github.com/user-attachments/assets/b7a1046e-36d4-40df-ac31-26e2467f552b)

Example Output
-----------------
✅Swagger

![Ekran görüntüsü 2025-03-17 205549](https://github.com/user-attachments/assets/c238db46-fce3-4736-a463-e1e7336c824f)

🚀Postman

GetAll

![Ekran görüntüsü 2025-03-17 205401](https://github.com/user-attachments/assets/48ee5af0-ab75-42ab-a027-a22c833a1d8e)

Post

![Ekran görüntüsü 2025-03-17 205527](https://github.com/user-attachments/assets/5b748d1c-3341-4f4f-9a99-e3cc6b1f80f6)
