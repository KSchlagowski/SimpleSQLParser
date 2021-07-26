# SimpleSQLParser

## Table of contents
* [General info](#general-info)
* [Technologies](#technologies)
* [Setup](#setup)
* [Run](#run)

## General info
This project is simple SELECT statement parser. The program parses the given statement and shows what tables and columns are used in it. 
Grammar file is taken from https://github.com/antlr/grammars-v4. See the sql.g4 file for more information.
	
## Technologies
Project is created with:
* .NET 5.0
* ANTLR v4
* FluentAssertions

Nugets:
* Antlr4.Runtime.Standard
* xUnit.net
	
## Setup
You must have .NET and ANTLR installed to run this project.

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
`dotnet run -- "SQLSamples/SQL1.sql"`
