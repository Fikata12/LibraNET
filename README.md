# LibraNET - Web Store for Books

## Introduction

LibraNET is an ASP.NET MVC application that serves as an online bookstore. It allows clients to browse and purchase books while also providing information about book authors. This web store offers a user-friendly interface for book enthusiasts to explore, add books to their favorites, and make purchases. Additionally, it offers admin capabilities for managing books, categories, authors, and user roles.

## Users

LibraNET supports three types of users:

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
- Access all users and categories pages for management purposes.
- Promote other users to the admin role.

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

- #### Admin Layout

![Екранна снимка 2023-09-01 185642](https://github.com/Fikata12/LibraNET/assets/90516828/dc4e909a-8e65-4de8-b4da-1ab544798d4e)

![Екранна снимка 2023-09-01 185927](https://github.com/Fikata12/LibraNET/assets/90516828/69ae1c26-fb1f-4d4d-96b4-8ec40bb455ad)

![Екранна снимка 2023-09-01 185936](https://github.com/Fikata12/LibraNET/assets/90516828/aa912cae-7966-45e8-bbf4-10a6d3e14c93)

### Pages

- #### Home

> Guest and User

![Екранна снимка 2023-09-01 190439](https://github.com/Fikata12/LibraNET/assets/90516828/73180faf-1909-40bc-8da4-e7d4f09648db)

> Admin

![Екранна снимка 2023-09-01 192124](https://github.com/Fikata12/LibraNET/assets/90516828/d6e5c191-9429-4c35-a3ff-384bb6d7fe55)

- #### All Books

> Guest and User

![Екранна снимка 2023-09-01 190802](https://github.com/Fikata12/LibraNET/assets/90516828/adf2e976-fa41-4562-aa30-2a58d693c603)

> Admin

![Екранна снимка 2023-09-01 191819](https://github.com/Fikata12/LibraNET/assets/90516828/827b994f-9084-44ce-9c3b-18f07b0ffee1)

- #### All Authors

> Guest and User

![Екранна снимка 2023-09-01 191008](https://github.com/Fikata12/LibraNET/assets/90516828/0e242089-d4c8-456a-9604-fdb8952f8eb5)

> Admin

![Екранна снимка 2023-09-01 192004](https://github.com/Fikata12/LibraNET/assets/90516828/a2748773-333a-4f91-abd6-591fcd4dadc8)

- #### All Categories

![Екранна снимка 2023-09-01 191153](https://github.com/Fikata12/LibraNET/assets/90516828/ed4db5ce-7274-4f14-ba24-21d178ebd907)

- #### All Users

![Екранна снимка 2023-09-01 191301](https://github.com/Fikata12/LibraNET/assets/90516828/cf691fa4-4bed-4c0b-9e8f-38dafb5b0fdb)


- #### Add Book

![Екранна снимка 2023-09-01 192635](https://github.com/Fikata12/LibraNET/assets/90516828/f8e9fcf0-9384-4ad2-b815-dfad4ce9457d)
![Екранна снимка 2023-09-01 192647](https://github.com/Fikata12/LibraNET/assets/90516828/dcdf7d01-4e59-4425-baa1-f8427e3494cb)

- #### Add Author

![Екранна снимка 2023-09-01 191457](https://github.com/Fikata12/LibraNET/assets/90516828/7d9601ec-a8bc-40d7-bb01-37571c1ee232)

- #### Add Category

![Екранна снимка 2023-09-01 191524](https://github.com/Fikata12/LibraNET/assets/90516828/f6c36564-3c62-4c71-8a7d-41b3fe2d1ab4)

- #### Book Details
  
![Екранна снимка 2023-09-01 192435](https://github.com/Fikata12/LibraNET/assets/90516828/858a3a07-2039-41f3-9771-bacd222ad06d)

![Екранна снимка 2023-09-01 192513](https://github.com/Fikata12/LibraNET/assets/90516828/34038d0e-9040-44cf-9fcc-e0cd215533d2)

- #### Author Details

![Екранна снимка 2023-09-01 192825](https://github.com/Fikata12/LibraNET/assets/90516828/ce6ff89f-6743-4f4c-a062-dfecc6c458b9)

- #### Favorites

![Екранна снимка 2023-09-01 193033](https://github.com/Fikata12/LibraNET/assets/90516828/76710a7c-2698-4353-bbe8-525f62665854)

- #### Cart

![Екранна снимка 2023-09-01 193059](https://github.com/Fikata12/LibraNET/assets/90516828/03bb7878-81aa-4c13-b897-1705bb5550e7)

- #### Checkout

![Екранна снимка 2023-09-01 193108](https://github.com/Fikata12/LibraNET/assets/90516828/a367b8b4-18ac-46f3-99c8-745e376c5f90)

- #### Account

![Екранна снимка 2023-09-01 193124](https://github.com/Fikata12/LibraNET/assets/90516828/734b1a61-8bce-4fa5-9291-0c79107aade7)
