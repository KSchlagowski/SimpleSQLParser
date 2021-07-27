using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using SimpleSQLParser.Models;

namespace SimpleSQLParser.Visitors
{
    public interface ISelectVisitor
    {
        SelectStatement VisitSelect_stmt([NotNull] sqlParser.Select_stmtContext context);
        SelectStatement Visit(IParseTree tree);
    }
}