using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.PowerBI
{
    public class TableSchema
    {
        public string Name { get; set; }
        public Column[] Columns { get; set; }
    }
}
