# BeerQuest

Please see the Leeds Beer Quest.pdf in the codebase for the technical spec. I am just attempting the back end aspect of the challenge

## My thoughts on the challenge
I liked the freedom of the challenge and think if I was doing both the front and back end it would be a really interesting one and enjoyable. However, without doing a front end it's hard to know what endpoints would be required and what the spec would be, I think for people attempting individual parts maybe a minimalistic spec could be provided. 

Without ever having done a front end like this it's quite dificult to come up with what would be required. I've tried to create the endpoints to fuel a basic UI which would just filter through the list, I've added a few endpoints that have some flexibility, there are limitations due to the database on some of these, noted in the known issues section below.   

There's loads of different things that could be done with the data but I like to follow the YAGNI principle as to now over complicate things. I appreciate this might be seen as an excuse to not add lots of functionality but I only spent a few hours doing this (not including time getting distracted by GraphQL) and don't want to spend loads of extra time.

## Assumptions
-	That the leeds beer quest data needs to be downloaded as I could not find an API to access it
	-	If the data needed to be accessed via an API I'd use the AddHttpClient method when doing DI, give it a base address then DI the HttpClient into a class built for interacting with said API
-	No integration/acceptance tests need to be written for this challenge
-	That .net6 is suitable for the task
-	The data does not need to be editted or updated only read
-	It's OK to have a local DB used for the project and use that during run time
-	The data should be left as it is and doesn't need normalising. Venues and reviews could be seperate tables and columns like category and maybe tags could be extracted into another table and used as a ForeignKey.
-	The application only needs to run in the Development environment
-	No default ordering is required by the front end

## Known issues
-	SqlLite doesn't handle DateTimes very well and they need to be formatted very specifically. You can't use 2017-03-05T12:44:54+00:00 instead you'd have to replace the T with a space, like 2017-03-05 12:44:54+00:00.
	Because of this any DateTime comparisons for the data are actually just Date comparisons. This could be rectified by editting the data but I do not wish to change it.

## Running the code
-	Nothing should need to be done to run the project. There will be a SqlLite DB copied to the bin when running, this SqlLite DB contains the base dataset, by default the DB is copied to the bin everytime you run. This can be changed via the leedsbeerquest.db "Copy to Output directory" property within the CoreDataProvider project.

## Design notes:
-	I've moved the CSV file into a SqlLite DB as it's quick and easy. This wouldn't be suitable for production setup due to scalability, ideally I'd opt for a cloud hosted DB or something like SqlServer/PostgreSql
-	The amount of abstractions and projects I've done for this project may seem overkill as the project is small, especially since there is no business logic so the application layer is essentially a pass through but I like to do it to support extending projects and to have things modular. I have gone against this with the SqlLite implementation of the VenueReviewRepository,  this could be in it's project that just deals with SqlLite interactions

## Process
-	I won't be following any git workflows such as git flow or trunk based as this task is too small for them
-	I've also not checked the code into main as although it doesn't really matter for this project, I feel unreviewed code shouldn't go into main

## Testing
-	I TDD'd the application using the red, green, refactor process, however classes were stubbed out prior 
-	I've used NUnit as it's what i'm most familiar with so it was the quickest to get setup, however with more time I'd opt for XUnit as I feel it's the better testing framework
-	I've made use of FluentAssertions, Moq and AutoFixture for the tests, it might seem a bit overkill but it's my preferred way of doing tests and provides some really good functionality.

## What improvements would I make
-	Ideally if I had the time, I'd implement something like GraphQL or OData which would allow for flexible querying without providing extra endpoints. This could be done manually as well but it makes more sense to use a tool
-	Error handling for the endpoints could be done better by checking for errors then returning the correct response such as 404 or 400
	-	Also adding the ProducesResponseType for the error scenarios.
-	Swap out the database system for something a bit better as with SqlLite you can't create things like stored procedures and some of the logic and helpful functions are missing. Opting for something like PostgreSql would be better for querying some of the text fields
-	An endpoint that returns items based on how close they are to a location would be an interesting one and probably used by a UI