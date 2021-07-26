# SimpleSQLParser

## Table of contents
* [General info](#general-info)
* [Technologies](#technologies)
* [Setup](#setup)
* [Run](#run)

## General info
This project is simple SELECT statement parser.
	
## Technologies
Project is created with:
* .NET 5.0
* ANTLR v4
	
## Setup
To run this project, you need to have .NET and ANTLR installed.

* ANTLR setup:
```
$ cd SimpleSQLParser/ANTLR
$ antlr4 -Dlanguage=CSharp -o generated sql.g4 -no-listener -visitor
```
That will create all the necessary files in SimpleSQLParser/ANTLR/generated/ directory. 

* .NET setup:
```
$ cd SimpleSQLParser
$ dotnet restore
```
And same for SimpleSQLParser.Tests project.

## Run
You can parse sample SELECT statement by typing:
`dotnet run -- "SQLSamples/SQL1.sql`
