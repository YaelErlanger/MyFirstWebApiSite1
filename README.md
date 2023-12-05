# Welcome to our musical instrument store
How to use our project:
In order to run this project you need:
VS 2022 version (and on). 
.net 7 (and on).
DB- SQL server. 
For creating the DB, you can use code-first abilities. All what you need is: 
Open your package manager console, 
Write: 
add-migration [DataBaseName]
and then:
Update-DataBase. 

And the DB is ready for use!

about our project:
The project represents a musical instrument store. It includes a login page, when the user gets an option of registering in case of new user. After a successfuly login, you get to a page that offers you to update your user details, or getting into the store. In the store page you can add products to your cart, that is saved in the session storage. There is an option of filtering the products that you see using category, words from product description, minimum price or maximum price as parameters. You can click and go to your cart page, where you can see your cart, remove products from it, and save your order. 
our project in .net7,wrriten by web API .net core and follows the REST architecture principles.
we used SQL server database.
we used ORM of Entity Framework by database first.

we have maintained password strength using the nuget package zxcvbn-core.
the struct's project made from layers who connect between them with Dependency Injections, in order to earn  the advantages of the DI as making the application more encapsulated and flexible,
Enables parallel development, decoupling between the class and its dependencies.
we used Asynchronous function for adding Scalability.
we have a swagger that describes our project structure, if you want to, you can use it by the rout:"localhost:[PORT NUMBER]/swagger" and see everything documented neatly.

we used DTO's layer for in order of preventing circular dependency.


the project maps the objects using package AutoMapper.
we used configuration files for savig sensitive and unconstant data.
we keeped on logging. the Logger send  an email if exception or error accures
we also created middlewares for Handling errors and Raiting. 



Wishing you a pleasant and useful use

                         Yael & Chani.
