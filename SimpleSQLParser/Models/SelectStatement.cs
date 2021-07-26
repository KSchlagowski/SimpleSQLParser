using System.Collections.Generic;

namespace SimpleSQLParser.Models
{
    public class SelectStatement
    {
        public List<string> Tables { get; set; } = new List<string>();
        public List<string> Columns { get; set; } = new List<string>();
    }
}