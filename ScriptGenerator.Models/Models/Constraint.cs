using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptGenerator.Models
{
    /// <summary>
    /// Generic constraint model
    /// </summary>
    public class Constraint
    {
        /// <summary>
        /// Schema name
        /// </summary>
        public string Schema { get; set; }

        /// <summary>
        /// Constraint name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Table name
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// Table column name
        /// </summary>
        public string TableColumnName { get; set; }
    }
}
