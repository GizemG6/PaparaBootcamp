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

Example Output
![Ekran görüntüsü 2025-03-09 172233](https://github.com/user-attachments/assets/add012bb-3c88-42d9-9ed9-df7a314378ce)

![Ekran görüntüsü 2025-03-09 172252](https://github.com/user-attachments/assets/43c72655-01b8-4458-a741-8c13e2933363)


Error Handling⚙️
-------------
If an unexpected error occurs during any of the API requests, the ErrorHandlerMiddleware catches the exception and returns a 500 response with a JSON message.
