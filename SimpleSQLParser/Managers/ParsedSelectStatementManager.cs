using System;
using SimpleSQLParser.Models;

namespace SimpleSQLParser.Managers
{
    public class ParsedSelectStatementManager
    {
        public void ShowTablesAndColumnsInSelectStatement(string input, SelectStatement selectStmt)
        {
            System.Console.WriteLine("INPUT");
            System.Console.WriteLine($"{input}");
            System.Console.WriteLine();
            System.Console.WriteLine("OUTPUT");

            string tables = "";
            string columns = "";
            foreach (var table in selectStmt.Tables)
                tables += table + ", ";
            foreach (var column in selectStmt.Columns)
                columns += column + ", ";

            if (!String.IsNullOrWhiteSpace(tables))
                tables = tables.Remove(tables.Length - 2);
            if (!String.IsNullOrWhiteSpace(columns))
                columns = columns.Remove(columns.Length - 2);

            System.Console.WriteLine("Tables: " + tables);
            System.Console.WriteLine("Columns: " + columns);
        }
    }
}