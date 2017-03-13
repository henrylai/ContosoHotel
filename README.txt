Henry Lai
TCSS 431 - Costarella
Final Project Submission
README 3/12/2017

This is a Server Sided Web Application built using ASP.NET MVC and EntityFramework, among other technologies, for Chuck Costarella's TCSS 431 course. This web app models a simple website used by a ficticious hotel establishment, Contoso Hotel.

Upon arriving at the home page, users are presented different views depending on their level of identity.
There are three levels of identity, anonymous user, registered user, and an administrator user.

ANONYMOUS USER: An anonymous user is able to view that available rooms but can not place a reservation. They will be redirected to register/login if they try to reserve a room.
REGISTERED USER: A registered user is able to view available rooms as well as place a reservation. Once they have placed a reservation, they are also able to view their reservations. When a user sucessfully reserves a room, that room is no longer available to reserve for other users.
ADMINISTRATOR USER: The administrator user can do everything a registered user can do, and can also view all guests, rooms, and reservations created. The administrator is also able to make a room available to reserve again by marking it as "vacant". The administrator is also able to create new rooms.

(Note: Please check the Credentials.txt text file for test accounts.)

