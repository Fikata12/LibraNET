# LibraNET - Web Store for Books

## Introduction

LibraNET is an ASP.NET MVC application that serves as an online bookstore. It allows clients to browse and purchase books while also providing information about book authors. This web store offers a user-friendly interface for book enthusiasts to explore, add books to their favorites, and make purchases. Additionally, it offers admin capabilities for managing books, categories, authors, and user roles.

## Users

LibraNET supports four types of users:

### Guest

Guests have limited access to the web store and can perform the following actions:

- View the home page.
- Browse all books and authors.

### User

- View the home page.
- Browse all books and authors.
- Add books to their favorites and cart.
- Make book purchases.

### Admin

In addition to the capabilities of regular users, administrators have the following privileges:

- Add new books, categories, and authors to the store.
- Access admin pages.

### Super Admin

In addition to the capabilities of admins, super admins have the following privileges:

- Promote other users to the admin role.

## Seeded Accounts
- **User**
  - Username: `user@gmail.com`
  - Password: `12345678`
    
- **Admin**
  - Username: `admin@gmail.com`
  - Password: `12345678`
 
- **Super Admin**
  - Username: `super.admin@gmail.com`
  - Password: `12345678`

## Built With

LibraNET is built using a variety of technologies and frameworks, including:

- ASP.NET Core 6.0
- Microsoft SQL Server
- Entity Framework Core
- MVC Areas
- Bootstrap
- ASP.NET Identity System
- AJAX
- jQuery
- SignalR
- AutoMapper
- Toastr
- NUnit
- Select2
- X.PagedList
- RateYo!
  
## Database Diagram
> Some tables are excluded from the diagram for better readability. Only the tables used in the application are left.

![Екранна снимка 2023-09-01 184428](https://github.com/Fikata12/LibraNET/assets/90516828/6e619bbe-f356-4370-831f-4687112cf4ed)

## Screenshots

### Layouts

- #### Guest Layout

![Екранна снимка 2023-09-01 185628](https://github.com/Fikata12/LibraNET/assets/90516828/f2d56527-e6c8-4177-9c16-a40bbac8230c)

- #### User Layout

![Екранна снимка 2023-09-01 185705](https://github.com/Fikata12/LibraNET/assets/90516828/c87628be-00c1-4b3c-bb8a-edf824230e23)

- #### Admin and Super Admin Layout

![image](https://github.com/Fikata12/LibraNET/assets/90516828/651ec42a-84b5-483e-9382-28fbb20bbfdb)

### Pages

- #### Home

![Екранна снимка 2023-09-01 190439](https://github.com/Fikata12/LibraNET/assets/90516828/73180faf-1909-40bc-8da4-e7d4f09648db)

- #### All Books

![Екранна снимка 2023-09-01 190802](https://github.com/Fikata12/LibraNET/assets/90516828/adf2e976-fa41-4562-aa30-2a58d693c603)

- #### All Authors

![Екранна снимка 2023-09-01 191008](https://github.com/Fikata12/LibraNET/assets/90516828/0e242089-d4c8-456a-9604-fdb8952f8eb5)

- #### Order Details

> Customer

![image](https://github.com/Fikata12/LibraNET/assets/90516828/8f48fbff-6d88-44ef-bd63-1df55394e330)

> Admin and Super Admin

![image](https://github.com/Fikata12/LibraNET/assets/90516828/22c76ab4-860e-4e4a-934d-b1ec64052793)

- #### Book Details
> Customer

![Екранна снимка 2023-09-01 192435](https://github.com/Fikata12/LibraNET/assets/90516828/858a3a07-2039-41f3-9771-bacd222ad06d)
![Екранна снимка 2023-09-01 192513](https://github.com/Fikata12/LibraNET/assets/90516828/34038d0e-9040-44cf-9fcc-e0cd215533d2)

> Admin and Super Admin

![image](https://github.com/Fikata12/LibraNET/assets/90516828/d0ba6042-fb98-410f-a703-8c4a83206b35)
![image](https://github.com/Fikata12/LibraNET/assets/90516828/dc610a9a-0d5e-4bcc-ab9c-efbc9740c5ec)

- #### Author Details

> Customer

![Екранна снимка 2023-09-01 192825](https://github.com/Fikata12/LibraNET/assets/90516828/ce6ff89f-6743-4f4c-a062-dfecc6c458b9)

> Admin and Super Admin

![image](https://github.com/Fikata12/LibraNET/assets/90516828/2e1f6cf3-84d3-402b-9d0b-8054637abc5c)

- #### Favorites

![Екранна снимка 2023-09-01 193033](https://github.com/Fikata12/LibraNET/assets/90516828/76710a7c-2698-4353-bbe8-525f62665854)

- #### Cart

![Екранна снимка 2023-09-01 193059](https://github.com/Fikata12/LibraNET/assets/90516828/03bb7878-81aa-4c13-b897-1705bb5550e7)

- #### Checkout

![Екранна снимка 2023-09-01 193108](https://github.com/Fikata12/LibraNET/assets/90516828/a367b8b4-18ac-46f3-99c8-745e376c5f90)

- #### Account

![image](https://github.com/Fikata12/LibraNET/assets/90516828/54df4ccb-1f7e-4d58-bd85-18d9fed2262f)

### Admin Pages

- #### Dashboard

![image](https://github.com/Fikata12/LibraNET/assets/90516828/a7f601ac-7dc8-4ad6-9e3c-42c385a3141f)

- #### All Users
  
> Admin

![image](https://github.com/Fikata12/LibraNET/assets/90516828/cb37f7bf-7c8a-44a1-be6b-8ab325a0e703)

> Super Admin

![image](https://github.com/Fikata12/LibraNET/assets/90516828/4f99e2af-5427-4c65-94dc-91d9625d71dd)

- #### All Orders

![image](https://github.com/Fikata12/LibraNET/assets/90516828/f4fe8358-8494-43d5-a954-a0fb5d2cfc2c)

- #### Entities

  ![image](https://github.com/Fikata12/LibraNET/assets/90516828/8ebf1cda-74d7-45e0-a53a-34aefa59d2db)

- #### All Books

![image](https://github.com/Fikata12/LibraNET/assets/90516828/414e8078-266d-450e-8164-e62287086744)

- #### All Authors

![image](https://github.com/Fikata12/LibraNET/assets/90516828/2877e61f-6ae1-4c62-b189-80a06688dd02)

- #### All Categories

![image](https://github.com/Fikata12/LibraNET/assets/90516828/08ffab02-f122-4a61-839a-5155ab2d6aef)

- #### Add

![image](https://github.com/Fikata12/LibraNET/assets/90516828/67843959-7677-4139-ac07-b3913674bdf9)

- #### Add Book

![Екранна снимка 2023-09-01 192635](https://github.com/Fikata12/LibraNET/assets/90516828/f8e9fcf0-9384-4ad2-b815-dfad4ce9457d)
![Екранна снимка 2023-09-01 192647](https://github.com/Fikata12/LibraNET/assets/90516828/dcdf7d01-4e59-4425-baa1-f8427e3494cb)

- #### Add Author

![Екранна снимка 2023-09-01 191457](https://github.com/Fikata12/LibraNET/assets/90516828/7d9601ec-a8bc-40d7-bb01-37571c1ee232)

- #### Add Category

![Екранна снимка 2023-09-01 191524](https://github.com/Fikata12/LibraNET/assets/90516828/f6c36564-3c62-4c71-8a7d-41b3fe2d1ab4)
