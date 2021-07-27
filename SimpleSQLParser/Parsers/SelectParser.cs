using System;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using SimpleSQLParser.Models;
using SimpleSQLParser.Visitors;

namespace SimpleSQLParser.Parsers
{
    public class SelectParser : ISelectParser
    {
        public SelectStatement ParseSelectStatement(string input)
        {
            ICharStream stream = CharStreams.fromString(input);
            ITokenSource lexer = new sqlLexer(stream);
            ITokenStream tokens = new CommonTokenStream(lexer);
            sqlParser parser = new sqlParser(tokens);
            IParseTree tree = parser.select_stmt();    
            ISelectVisitor visitor = new SelectVisitor();
            SelectStatement selectStatement = visitor.Visit(tree);

            return selectStatement;
        }
    }
}