using ScriptGenerator;
using ScriptGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ScriptGenerationService : IScriptGenerationService
    {
        public async Task<string> GenerateCreationScript(Table table)
        {
            return await new Task<string>(() =>
            {
                var scriptBuilder = new StringBuilder();

                return "";
            });
        }

        public async Task<string> GenerateCreationScript(Column column)
        {
            return await new Task<string>(() =>
            {
                var scriptBuilder = new StringBuilder();

                return "";
            });
        }

        public async Task<string> GenerateCreationScript(Sequence sequence)
        {
            return await new Task<string>(() =>
            {
                var scriptBuilder = new StringBuilder();

                scriptBuilder.Append($"DECLARE" + Environment.NewLine);
                scriptBuilder.Append($"  ln_exist NUMBER;" + Environment.NewLine);
                scriptBuilder.Append($"BEGIN" + Environment.NewLine);
                scriptBuilder.Append($"  SELECT COUNT(1)" + Environment.NewLine);
                scriptBuilder.Append($"    INTO ln_exist" + Environment.NewLine);
                scriptBuilder.Append($"    FROM ALL_SEQUENCES A" + Environment.NewLine);
                scriptBuilder.Append($"   WHERE A.SEQUENCE_NAME = '{sequence.Name}'" + Environment.NewLine);
                scriptBuilder.Append($"     AND A.SEQUENCE_OWNER = '{sequence.SchemaName}';" + Environment.NewLine);
                scriptBuilder.Append($"  IF ln_exist = 0 THEN" + Environment.NewLine);
                scriptBuilder.Append($"    EXECUTE IMMEDIATE 'CREATE SEQUENCE {sequence.SchemaName}.{sequence.Name} START WITH {sequence.StartWith} ");
                scriptBuilder.Append($"INCREMENT BY {sequence.IncrementBy} NOCACHE';" + Environment.NewLine);
                scriptBuilder.Append($"  END IF;" + Environment.NewLine);
                scriptBuilder.Append($"END;");

                return scriptBuilder.ToString();
            });
        }

        private string GenerateForeignKeyScript(ConstraintForeignKey constraint)
        {
            return $"EXECUTE IMMEDIATE 'ALTER TABLE {constraint.Schema}.{constraint.TableName} ADD CONSTRAINT {constraint.Name} FOREIGN KEY ({constraint.TableColumnName}) REFERENCES {constraint.Schema}.{constraint.TableName}({constraint.TableColumnName})';";
        }
        private string GenerateIndexScript(ConstraintIndex constraint)
        {
            return $"EXECUTE IMMEDIATE 'CREATE INDEX {constraint.Schema}.{constraint.Name} ON {schema}.{tableName}({columnName}) TABLESPACE {(String.IsNullOrWhiteSpace(tableSpace) ? "INDX" : tableSpace)}';";
        }
    }
}
