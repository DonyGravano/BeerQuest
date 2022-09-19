# BeerQuest

Please see the Leeds Beer Quest.pdf in the codebase for the technical spec

## Assumptions
-	That the leeds beer quest data needs to be downloaded as I could not find an API to access it
-	No integration/acceptance tests need to be written for this challenge
-	That .net6 is suitable for the task
-	The data does not need to be editted or updated only read
-	It's OK to have a local DB used for the project and use that during run time
-	The data should be left as it is and doesn't need normalising. Pubs and reviews could be seperate tables and columns like category and maybe tags could be extracted into another table and used as a ForeignKey.

## Running the code

## Design notes:
-	I've moved the CSV file into a SqlLite DB as it's quick and easy. This wouldn't be suitable for production setup due to scalability, ideally I'd opt for a cloud hosted DB or something like SqlServer/PostgreSql
-	The amount of abstractions and projects I've done for this project may seem overkill as the project is small but I like to do it to support extending projects and to have things modular

## Process
-	I won't be following any git workflows such as git flow or trunk based as this task is too small for them

## Testing
-	I TDD'd the application using the red, green, refactor process, however classes were stubbed out prior
-	I've used NUnit as it's what i'm most familiar with so it was the quickest to get setup, however with more time i'd opt for XUnit
-	I've made use of FluentValidations, Moq and AutoFixture for the tests, it might seem a bit overkill but it's my preferred way of doing tests

## What improvements would I make