# Lite-Berry-Pi
A Unique Way To Communicate with Friends
Lite-Berry Pie: Midterm Prep #4

## MVP User Stories:

### As an Admin I can:
Give users permissions to login to the app
Create new lite-berry designs
Look up which users sent a lite-berry and when
Update lite-berry patterns
Delete lite-berry patterns 
View a list users
View a list of activity

### As a User I can:
log in to the app with a password
select from a predetermined list of lite-berries to send
see a history of the lite-berries I’ve sent

#### Stretch Goal User Stories:

#### As an Admin I can 
rerun the lite-berries that have been sent previously

#### As a User I can 
Create my own designs from the app 
Delete my own designs from the app

### Feature Tasks

Admin can create user in postman
Admin can create lite-berry designs in postman
Admin can update lite-berry designs in postman
Admin can save lite-berry designs  
Admin can get a list of users
Admin can get a list of lite-berries sent by user
Admin can get a list of activity by day
User can log into the app
User can choose from a list of preset lite-berry options
User can get a list of lite-berries they have sent
MVP -Admin can rerun all lite-berries that have been sent previously
MVP- User can create a design from the command line
MVP - User can delete a design they created from the command line 

### Acceptance Tasks

Ensure that admin can create user in postman
Ensure that the user can’t create a user in postman
Ensure that admin can create lite-berry designs in postman
Ensure that admin can update lite-berry designs in postman
Ensure that admin can save lite-berry designs  
Ensure that admin can get a list of users
Ensure that user can’t see other users
Ensure that admin can get a list of lite-berries sent by user
Ensure that admin can get a list of activity by day
Ensure that user can log into the app
Ensure that user must use a password to log into the app
Ensure that user can choose from a list of preset lite-berry design options
Ensure that user can get a list of lite-berries they have sent
MVP - Ensure admin can rerun all lite-berries that have been sent previously
MVP- Ensure user can create a design from the command line
MVP- Ensure user can delete a design they created from the command line 


### Software Requirements

#### Vision:

What is the vision of this product? 
	To provide a platform for people to show that they are present with others, when they aren't able to physically be there.
What pain point does this project solve? 
Being present in a physical sense when not actually able to be present physically.

Why should we care about your product?
	It is a unique way to communicate with others and show that a user cares, when otherwise limited to phone and video calls, as well as texts or emails. Quarantining further limits social interactions, and Lite-Berry Pi will bring friends and loved ones together despite not being able to physically visit. 


### Scope (In/Out)

### In:
Users will be able to log in to their profile in the program
Users will be able to access existing lite-berry patterns to select and send to the Raspberry Pi device
Administrators will be able to delete saved lite-berry designs from the database 
	
### Out:
Users will only be able to light LED lights on the raspberry pi. Sending braille or sound signals is out of scope
Users won’t be able to create animations on the raspberry pi with multiple sends in a row
Users won’t be able to control the timing of the event (ie send lite-berry 10 minutes from now)

### MVP
	Our app will allow a user to select a lite-berry pattern and that pattern will be displayed on a Raspberry Pi device. Administrators will be able to view user activity, create, delete, and update lite-berry designs. Users will also be able to log in to their profile, and save their selected designs. 

### Stretch Goals:
	Users will be able to create their own designs, as well as delete their saved designs.

### Functional Requirements:

Admin can create user in postman
Admin can create lite-berry designs in postman
Admin can update lite-berry designs in postman
Admin can save lite-berry designs  
Admin can get a list of users
Admin can get a list of lite-berries sent by user
Admin can get a list of activity by day
User can log into the app
User can choose from a list of preset lite-berry options
User can get a list of lite-berries they have sent
MVP -Admin can rerun all lite-berries that have been sent previously
MVP- User can create a design from the command line
MVP - User can delete a design they created from the command line 

### Non-Functional Requirements:
Security: User's will be required to log in to the program in order to access it's functions.
Access: Program will be deployed to Azure, and will be accessible 24/7 for at least a year from it's deployment date.
	
### Data Flow
User  1:many UserDesign
User  1:1  ActivityLog
UserDesign 1: many Design

### Domain Model



### ERD
