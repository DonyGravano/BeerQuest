# BeerQuest

Please see the Leeds Beer Quest.pdf in the codebase for the technical spec. I am just attempting the back end aspect of the challenge

Without doing a front end it's hard to know

## Assumptions
-	That the leeds beer quest data needs to be downloaded as I could not find an API to access it
-	No integration/acceptance tests need to be written for this challenge
-	That .net6 is suitable for the task
-	The data does not need to be editted or updated only read
-	It's OK to have a local DB used for the project and use that during run time
-	The data should be left as it is and doesn't need normalising. Venues and reviews could be seperate tables and columns like category and maybe tags could be extracted into another table and used as a ForeignKey.
-	The application only needs to run in the Development environment

## Known bugs
-	SqlLite doesn't handle DateTimes very well and they need to be formatted very specifically. You can't use 2017-03-05T12:44:54+00:00 instead you'd have to replace the T with a space, like 2017-03-05 12:44:54+00:00.
	Because of this any DateTime comparisons for the data are actually just Date comparisons. This could be rectified by editting the data but I do not wish to change it.

## Running the code
-	Nothing should need to be done to run the project. There will be a SqlLite DB copied to the bin 

## Design notes:
-	I've moved the CSV file into a SqlLite DB as it's quick and easy. This wouldn't be suitable for production setup due to scalability, ideally I'd opt for a cloud hosted DB or something like SqlServer/PostgreSql
-	The amount of abstractions and projects I've done for this project may seem overkill as the project is small, especially since there is no business logic so the application layer is essentially a pass through but I like to do it to support extending projects and to have things modular

## Process
-	I won't be following any git workflows such as git flow or trunk based as this task is too small for them

## Testing
-	I TDD'd the application using the red, green, refactor process, however classes were stubbed out prior
-	I've used NUnit as it's what i'm most familiar with so it was the quickest to get setup, however with more time i'd opt for XUnit
-	I've made use of FluentValidations, Moq and AutoFixture for the tests, it might seem a bit overkill but it's my preferred way of doing tests

## What improvements would I make
-	Ideally if I had the time, I'd implement something like GraphQL or OData which would allow for flexible querying without providing extra endpoints. This could be done manually as well but it makes more sense to use a tool
-	Error handling for the endpoints could be done better by checking for errors then returning the correct response, also adding the ProducesResponseType for the error scenarios
-	Swap out the database system for something a bit better as with SqlLite you can't create things like stored procedures and some of the logic and helpful functions are missing. Opting for something like PostgreSql would be better