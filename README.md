# Welcome to our musical instrument store
How To Use:
In order to run this project:
VS 2022 version (and on). 
.net 7 (and on).
DB- SQL. 
For creating the DB, you can use code-first abilities. All what you need is: 
Open your package manager console, 
Write: 1. add-migration [MyDataBaseName]
 		2.Update-DataBase. 	
And your DB is ready for use!

about our project:
The project represents a musical instrument store. It includes a login page, when the user gets an option of registering in case of new user. After a successfuly login, you get to a page that offers you to update your user details, or getting into the store. In the store page you can add products to your cart, that is saved in the session storage. There is an option of filtering the products that you see using category, words from product description, minimum price or maximum price as parameters. You can click and go to your cart page, where you can see your cart, remove products from it, and save your order. 
our project in .net7,wrriten by web API .net core and follows the REST architecture principles.
we used SQL server database.
we used ORM of Entity Framework by database first.

we keeped on password strength using the nuget package zxcvbn-core.
the struct's project made from layers who connect between them with Dependency Injections, in order to earn  the advantages of the DI:
• reusing parts of code
•  The maintainability of the system increases because logic changes in the field affect objects and classes less
• DI allows the module that consumes the dependency not to need any information about the module it consumes

• Enables parallel development
• decoupling between the class and its dependencies
we used Asynchronous function for adding Scalability.
if you want to, you can get into the swagger everything מתועד בצורה מסודרת.

we used DTO's layer for............
.............
.............
.......

191 page.
The project mapped the objects using thr package AutoMapper.
we used configuration files for savig sensitive data and unconstant data.
we keeped on logging. the Logger send  an email if exception or error accures
we also created middlewares for Handling errors and Raiting. 
