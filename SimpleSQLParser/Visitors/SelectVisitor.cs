using System;
using Antlr4.Runtime.Misc;
using SimpleSQLParser.Models;

namespace SimpleSQLParser.Visitors
{
    public class SelectVisitor : sqlBaseVisitor<SelectStatement>, ISelectVisitor
    {
        public override SelectStatement VisitSelect_stmt([NotNull] sqlParser.Select_stmtContext context)
        {
            string table = "";
            string column = "";
            bool isStatementWithJoinClause = true;

            SelectStatement selectStmt = new SelectStatement();

            try
            {
                foreach (var select_core in context.select_core())
                {
                    foreach (var result in select_core.join_clause().table_or_subquery())
                    {
                        table = result.table_name().GetText();
                        selectStmt.Tables.Add(table);
                    }
                }
            }
            catch(Exception)
            {
                isStatementWithJoinClause = false;
            }

            if (!isStatementWithJoinClause)
            {
                try
                {
                    foreach (var select_core in context.select_core())
                    {
                        foreach (var result in select_core.table_or_subquery())
                        {
                            table = result.table_name().GetText();
                            selectStmt.Tables.Add(table);
                        }
                    }
                }
                catch(Exception ex)
                {
                    throw ex;
                }

                if (String.IsNullOrWhiteSpace(table))
                {
                    throw new ArgumentNullException("Given statement doesn't contain any tables.");
                }
            }

            try
            {
                foreach (var select_core in context.select_core())
                {
                    foreach (var result in select_core.result_column())
                    {
                        if (result.GetText() == "*")
                        {
                            selectStmt.Columns.Add("ALL");
                        }
                        else
                        {
                            column = result.expr().column_name().GetText();
                            selectStmt.Columns.Add(column);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return selectStmt;
        }
    }
}