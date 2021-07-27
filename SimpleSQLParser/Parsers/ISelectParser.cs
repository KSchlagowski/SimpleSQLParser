using SimpleSQLParser.Models;

namespace SimpleSQLParser.Parsers
{
    public interface ISelectParser
    {
        SelectStatement ParseSelectStatement(string input);
    }
}