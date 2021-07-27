using System;
using System.IO;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using SimpleSQLParser.Managers;
using SimpleSQLParser.Models;
using SimpleSQLParser.Parsers;

namespace SimpleSQLParser
{
    class Program
    {
        static void Main(string[] args)
        {
            ISelectParser selectParser = new SelectParser();
            IParsedSelectStatementManager parsedSelectStatementManager = new ParsedSelectStatementManager();

            string input = File.ReadAllText(args[0]);
            SelectStatement selectStmt = selectParser.ParseSelectStatement(input);

            parsedSelectStatementManager.ShowTablesAndColumnsInSelectStatement(input, selectStmt);
        }
    }
}
