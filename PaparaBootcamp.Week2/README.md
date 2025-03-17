WEEK 2
---------------
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


