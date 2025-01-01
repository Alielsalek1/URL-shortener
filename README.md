# URLHub  

A robust URL shortening and sharing service developed using **ASP.NET Core** with **MS SQL Server**. **URLHub** offers authenticated access, complete URL management capabilities (CRUD), and social features for sharing URLs with friends.  

---
## Table of Contents  

1. [Features](#features)  
2. [Installation](#installation)  
   - [Prerequisites](#prerequisites)  
   - [Steps](#steps)  
3. [Usage](#usage)  
   - [User Authentication](#user-authentication)  
   - [URL Management](#url-management)  
   - [Social Features](#social-features)  
4. [Technologies](#technologies)  

---

## Features  

- **User Authentication**: Secure user registration and login using **JWT (JSON Web Token)**.  
- **URL Shortening**: Create shortened URLs and manage them through **CRUD operations**.  
- **Social Features**: Add and manage friends; view their shared shortened URLs.  
- **Database Integration**: Uses **Microsoft SQL Server** for reliable data persistence.  
- **Scalable Architecture**: Designed for maintainability and scalability.  

---

## Installation  

### Prerequisites  

Ensure the following tools are installed:  
- **.NET SDK** (version 6 or higher)  
- **MS SQL Server** (local or cloud-based)  
- A code editor, such as **Visual Studio** or **VS Code**  
- **Postman** or another API testing tool (optional)  

### Steps  

1. Clone the repository:
```bash
git clone https://github.com/Alielsalek1/URLHub.git
```
2. Navigate to the project directory: 
```bash
cd URLHub  
```
3. Configure the project:
  - Update the connection string in appsettings.json to match your MS SQL Server setup.
4.Set up the database:
  - Use Entity Framework Core to apply migrations
```bash
dotnet ef database update  
```
5. run the project
```bash
Run the application:
```

## Usage

### User Authentication
- Register: Create a new user account with email and password.
- Login: Authenticate with the credentials to receive a JWT token.
- Include the JWT token in the Authorization header of your API requests:
```makeFile
Authorization: Bearer <your_token>
```
### URL Management
- Create Shortened URL: Submit a URL to receive its shortened version.
- CRUD Operations: Perform read, update, and delete operations on your URLs.
### Social Features
- Add Friends: Send friend requests to share URLs.
- View Friend URLs: Browse the URLs shared by your friends.

## Technologies
- Framework: ASP.NET Core
- Database: Microsoft SQL Server
- Authentication: JWT
- ORM: Entity Framework Core
- API Testing: Postman
