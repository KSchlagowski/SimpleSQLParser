using System;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using FluentAssertions;
using SimpleSQLParser.Models;
using SimpleSQLParser.Parsers;
using Xunit;

namespace SimpleSQLParser.Tests
{
    public class SelectVisitorTests
    {
        [Fact]
        public void Parse_SimpleStatement_ReturnsCorrectParsedTable()
        {
            ISelectParser selectParser = new SelectParser();
            string input = "SELECT Name FROM Users";

            var returnedModel = selectParser.ParseSelectStatement(input);

            returnedModel.Should().NotBeNull();
            returnedModel.Tables[0].Should().NotBeNullOrWhiteSpace();
            returnedModel.Tables[0].Should().Be("Users");
        }

        [Fact]
        public void Parse_SimpleStatement_ReturnsCorrectParsedColumn()
        {
            ISelectParser selectParser = new SelectParser();
            string input = "SELECT Name FROM Users";

            var returnedModel = selectParser.ParseSelectStatement(input);

            returnedModel.Should().NotBeNull();
            returnedModel.Columns[0].Should().NotBeNullOrWhiteSpace();
            returnedModel.Columns[0].Should().Be("Name");
        }

        [Fact]
        public void Parse_StatementWithAsterisk_ReturnsColumnNamedALL()
        {
            ISelectParser selectParser = new SelectParser();
            string input = "SELECT * FROM Users";

            var returnedModel = selectParser.ParseSelectStatement(input);

            returnedModel.Should().NotBeNull();
            returnedModel.Columns[0].Should().NotBeNullOrWhiteSpace();
            returnedModel.Columns[0].Should().Be("ALL");
        }

        [Fact]
        public void Parse_StatementWithSemicolon_ReturnsCorrectParsedTableAndColumn()
        {
            ISelectParser selectParser = new SelectParser();
            string input = "SELECT Name FROM Users;";

            var returnedModel = selectParser.ParseSelectStatement(input);

            returnedModel.Should().NotBeNull();
            returnedModel.Tables[0].Should().NotBeNullOrWhiteSpace();
            returnedModel.Tables[0].Should().Be("Users");
            returnedModel.Columns[0].Should().NotBeNullOrWhiteSpace();
            returnedModel.Columns[0].Should().Be("Name");
        }

        //here will be test with semicolon

        [Fact]
        public void Parse_MoreComplexStatement_ReturnsCorrectParsedTablesAndColumns()
        {
            ISelectParser selectParser = new SelectParser();
            string input = "SELECT u.Name, u.Surname, p.Id, p.ProductOwner FROM Users u, Product p";

            var returnedModel = selectParser.ParseSelectStatement(input);

            returnedModel.Should().NotBeNull();
            returnedModel.Tables[0].Should().Be("Users");
            returnedModel.Tables[1].Should().Be("Product");
            returnedModel.Columns[0].Should().Be("Name");
            returnedModel.Columns[1].Should().Be("Surname");
            returnedModel.Columns[2].Should().Be("Id");
            returnedModel.Columns[3].Should().Be("ProductOwner");
        }

        [Fact]
        public void Parse_StatementWithJoinClause_ReturnsCorrectParsedTablesAndColumns()
        {
            ISelectParser selectParser = new SelectParser();
            string input = "SELECT u.Name, u.Surname, p.Id, p.ProductOwner FROM Users u JOIN Product p ON Product.ProductOwner = User.FullName";

            var returnedModel = selectParser.ParseSelectStatement(input);

            returnedModel.Should().NotBeNull();
            returnedModel.Tables[0].Should().Be("Users");
            returnedModel.Tables[1].Should().Be("Product");
            returnedModel.Columns[0].Should().Be("Name");
            returnedModel.Columns[1].Should().Be("Surname");
            returnedModel.Columns[2].Should().Be("Id");
            returnedModel.Columns[3].Should().Be("ProductOwner");
        }

        [Fact]
        public void Parse_StatementWithoutTables_ReturnsException()
        {
            ISelectParser selectParser = new SelectParser();
            string input = "SELECT Name FROM";

            Action returnedModel = () => selectParser.ParseSelectStatement(input);

            returnedModel.Should().Throw<ArgumentNullException>()
                .WithMessage("Value cannot be null. (Parameter 'Given statement doesn't contain any tables.')");
        }
    }
}
