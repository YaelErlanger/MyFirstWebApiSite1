# Welcome to our musical instrument store
our project presents a musical instrument store.
for running the project,  you must have .net 07 ,VS 2022 at least.
for creating the database you have to use CODE FIRST and check that you have sql server .

about our project:
our project in .net7,wrriten by web API .net core and follows the REST architecture עקרונות.
we used SQL server database.
we used ORM of Entity Framework, we used database first.

we keeped on password strength using the nuget package zxcvbn-core.
the struct's project made from layers who connect between them with Dependency Injections, על מנת להרויח the advantages of the DI:
• reusing parts of code
•  יכולת תחזוקת המערכת עולה מכיון ששינויי לוגיקה בתחום משפיעים פחות על אוביקטים ומחלקות
• DIמאפשר למדול שצורך את התלות לא להזדקק לשום מידע לגבי המודול אותו הוא צאוך 

• מאפשר פיתוח מקביל
• ניתוק בין המחלקה לבין התלות ש
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
