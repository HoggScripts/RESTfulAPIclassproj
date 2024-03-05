eCommerce RESTful API Overview
A RESTful API service by Ben Hogg

Goals and Functions:

Database Design and Integration: Develop and populate a database scheme with 5 entities and integrate it into the .NET Web API for CRUD operations.

Controllers: All controllers should support GET, POST, PUT, and DELETE methods and recieve and return expected data.

    Example database endpoint functionality:
        Order Controller...

        GET /api/orders: Retrieves all orders.
        GET /api/orders/{id}: Retrieves a specific order by its ID.
        PUT /api/orders/{id}: Updates a specific order by its ID.
        POST /api/orders: Creates a new order.
        DELETE /api/orders/{id}: Deletes a specific order by its ID. 

Logging and Monitoring: Implement a logging service for tracking events and errors in all relevant controller methods.

Cloud Deployment: Deploy the API on Azure.

Documentation: Create user-friendly documentation detailing API endpoints and functionalities for efficient integration.

API Testing and Consumption: Test the API endpoints using Postman and look for errors or issues to solve. Learn to consume API endpoints with both serialized and non-serialized JSON objects.

Codebase Organization: Establish a well-structured codebase with clear hierarchies and separation of concerns for readability and maintainability.

User Registration and Validation: Utilize MailKit to enable user registration and validation via Email.

    Example registration endpoint consumption:
        
        POST /api/account/register: Please provide Email and password.
            {
                "Email": "example@example.com"
                "Password": "ExamplePassword321"
            }
    
Security and Authentication: Implement secure authentication mechanisms using JWT for user authorization and Identity framework for user management and role assignment.

        After Email verification. Now use the login endpoint to recieve your JWT token.
        
        POST /api/account/login: Please provide your Email and password.
            {
                "Email": "example@example.com"
                "Password": "ExamplePassword321"
            }

Problem Solving: Learn to identify and solve issues that arise during the development of a RESTful API.

Technologies and Frameworks Used:
Microsoft .NET API
Microsoft Identity Framework Core
MailKit
JWT (JSON Web Tokens)
Postman for API testing and interaction
Microsoft SQL Server
Azure Data Studio
Azure portal



