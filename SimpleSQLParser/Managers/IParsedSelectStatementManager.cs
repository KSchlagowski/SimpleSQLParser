using SimpleSQLParser.Models;

namespace SimpleSQLParser.Managers
{
    public interface IParsedSelectStatementManager
    {
        void ShowTablesAndColumnsInSelectStatement(string input, SelectStatement selectStmt);
    }
}