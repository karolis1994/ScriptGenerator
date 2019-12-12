using ScriptGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptGenerator.Services
{
    public class ScriptGenerationService : IScriptGenerationService
    {
        public async Task<string> GenerateCreationScript(Table t)
        {
            if (t == null)
                return string.Empty;

            return await Task.Run(() =>
            {
                StringBuilder scriptBuilder = new StringBuilder();

                List<String> columns = new List<String>();
                List<String> commentScripts = new List<String>();
                List<String> uniqueConstraintScripts = new List<String>();
                List<String> fkScripts = new List<String>();

                if (!String.IsNullOrEmpty(t.Comment))
                    commentScripts.Add(GenerateCommentScript(t));

                //Loop through each column and form column, comment, foreign key script values.
                foreach (var c in t.Columns)
                {
                    columns.Add(GenerateColumnDefinition(c));

                    if (c.HasUniqueConstraint)
                        uniqueConstraintScripts.Add(GenerateUniqueScript(c.UniqueConstraint));

                    if (!String.IsNullOrEmpty(c.Comment))
                        commentScripts.Add(GenerateCommentScript(c));

                    if (c.HasForeignKeyConstraint)
                    {
                        fkScripts.Add(GenerateForeignKeyScript(c.ForeignKey));
                        fkScripts.Add(GenerateIndexScript(c.ForeignKey?.Index));
                    }
                }

                var primaryKeyConstraint = t.Columns.Where(e => e.HasPrimaryKeyConstraint).FirstOrDefault()?.PrimaryKey;

                scriptBuilder.AppendLine("DECLARE");
                scriptBuilder.AppendLine("  ln_exist NUMBER;");
                scriptBuilder.AppendLine("BEGIN");
                scriptBuilder.AppendLine("  SELECT COUNT(1)");
                scriptBuilder.AppendLine("    INTO ln_exist");
                scriptBuilder.AppendLine("    FROM ALL_TABLES AT");
                scriptBuilder.AppendLine($"   WHERE AT.OWNER = '{t.Schema}'");
                scriptBuilder.AppendLine($"     AND AT.TABLE_NAME = '{t.Name}';");
                scriptBuilder.AppendLine("  IF ln_exist = 0 THEN");
                scriptBuilder.AppendLine($"      EXECUTE IMMEDIATE 'CREATE TABLE {t.Schema}.{t.Name}");
                scriptBuilder.AppendLine("      (");
                scriptBuilder.AppendLine($"          {String.Join($",{Environment.NewLine}          ", columns)}");
                scriptBuilder.AppendLine($"      ){(String.IsNullOrWhiteSpace(t.TableSpace) ? "" : " TABLESPACE " + t.TableSpace)}';");
                scriptBuilder.AppendLine($"      {GeneratePrimaryKeyScript(primaryKeyConstraint)}");
                scriptBuilder.AppendLine($"      {String.Join(Environment.NewLine + "      ", commentScripts.Concat(fkScripts))}");
                scriptBuilder.AppendLine($"      {String.Join(Environment.NewLine + "      ", uniqueConstraintScripts)}");
                scriptBuilder.AppendLine("  END IF;");
                scriptBuilder.AppendLine("END;");
                scriptBuilder.AppendLine("/");

                return scriptBuilder.ToString();
            })
            .ConfigureAwait(false);
        }

        public async Task<string> GenerateCreationScript(Column c)
        {
            if (c == null)
                return string.Empty;

            return await Task.Run(() =>
            {
                var scriptBuilder = new StringBuilder();

                scriptBuilder.AppendLine("DECLARE");
                scriptBuilder.AppendLine("  ln_exist NUMBER;");
                scriptBuilder.AppendLine("BEGIN");
                scriptBuilder.AppendLine("  SELECT COUNT(1)");
                scriptBuilder.AppendLine("    INTO ln_exist");
                scriptBuilder.AppendLine("    FROM ALL_TAB_COLS ATC");
                scriptBuilder.AppendLine($"   WHERE ATC.OWNER = '{c.TableSchema}'");
                scriptBuilder.AppendLine($"     AND ATC.TABLE_NAME = '{c.TableName}'");
                scriptBuilder.AppendLine($"     AND ATC.COLUMN_NAME = '{c.Name}';");
                scriptBuilder.AppendLine("  IF ln_exist = 0 THEN");
                scriptBuilder.AppendLine($"      EXECUTE IMMEDIATE 'ALTER TABLE {c.TableSchema}.{c.TableName} ADD ({GenerateColumnDefinition(c)})';");
                scriptBuilder.AppendLine(GenerateCommentScript(c));
                scriptBuilder.AppendLine(GenerateForeignKeyScript(c.ForeignKey));
                scriptBuilder.AppendLine(GenerateIndexScript(c.ForeignKey?.Index));
                scriptBuilder.AppendLine("  END IF;");
                scriptBuilder.AppendLine("END;");
                scriptBuilder.AppendLine("/");

                return scriptBuilder.ToString();
            })
            .ConfigureAwait(false);
        }

        public async Task<string> GenerateCreationScript(Sequence sequence)
        {
            if (sequence == null)
                return string.Empty;

            return await Task.Run(() =>
            {
                var scriptBuilder = new StringBuilder();

                scriptBuilder.AppendLine("DECLARE");
                scriptBuilder.AppendLine("  ln_exist NUMBER;");
                scriptBuilder.AppendLine("BEGIN");
                scriptBuilder.AppendLine("  SELECT COUNT(1)");
                scriptBuilder.AppendLine("    INTO ln_exist");
                scriptBuilder.AppendLine("    FROM ALL_SEQUENCES A");
                scriptBuilder.AppendLine($"   WHERE A.SEQUENCE_NAME = '{sequence.Name}'");
                scriptBuilder.AppendLine($"     AND A.SEQUENCE_OWNER = '{sequence.Schema}';");
                scriptBuilder.AppendLine("  IF ln_exist = 0 THEN");
                scriptBuilder.AppendLine($"    EXECUTE IMMEDIATE 'CREATE SEQUENCE {sequence.Schema}.{sequence.Name} START WITH {sequence.StartWith} ");
                scriptBuilder.AppendLine($"INCREMENT BY {sequence.IncrementBy} NOCACHE';");
                scriptBuilder.AppendLine("  END IF;");
                scriptBuilder.AppendLine("END;");

                return scriptBuilder.ToString();
            })
            .ConfigureAwait(false);
        }

        public async Task<string> GenerateCreationScript(Trigger trigger)
        {
            if (trigger == null)
                return string.Empty;

            return await Task.Run(() =>
            {
                var scriptBuilder = new StringBuilder();

                scriptBuilder.AppendLine($"CREATE OR REPLACE TRIGGER {trigger.Schema}.{trigger.TableName}.{trigger.Name}");
                scriptBuilder.AppendLine($"  BEFORE INSERT OR UPDATE ON {trigger.Schema}.{trigger.TableName}");
                scriptBuilder.AppendLine("  FOR EACH ROW");
                scriptBuilder.AppendLine("DECLARE");
                scriptBuilder.AppendLine("  ls_user VARCHAR2(250);");
                scriptBuilder.AppendLine("BEGIN");
                scriptBuilder.AppendLine("  SELECT NVL(settings.glob.s_current_user_name, MIN(vs.osuser))");
                scriptBuilder.AppendLine("    INTO ls_user");
                scriptBuilder.AppendLine("    FROM v$session vs");
                scriptBuilder.AppendLine("   WHERE vs.audsid = userenv('sessionid');");
                scriptBuilder.AppendLine("  IF INSERTING THEN");
                scriptBuilder.AppendLine("    :NEW.record_date := sysdate;");
                scriptBuilder.AppendLine("    IF :NEW.record_user IS NULL THEN");
                scriptBuilder.AppendLine("      :NEW.record_user := s_user;");
                scriptBuilder.AppendLine("    END IF;");
                scriptBuilder.AppendLine("  ELSE");
                scriptBuilder.AppendLine("    :NEW.edit_date := sysdate;");
                scriptBuilder.AppendLine("    IF :NEW.edit_user IS NULL THEN");
                scriptBuilder.AppendLine("      :NEW.edit_user := s_user;");
                scriptBuilder.AppendLine("    END IF;");
                scriptBuilder.AppendLine("  END IF;");
                scriptBuilder.AppendLine("END;");

                return scriptBuilder.ToString();
            })
            .ConfigureAwait(false);
        }

        public async Task<string> GenerateCreationScript(NonVisualSetting nonVisualSetting)
        {
            if (nonVisualSetting == null)
                return string.Empty;

            return await Task.Run(() =>
            {
                StringBuilder insertsBuilder = new StringBuilder();
                StringBuilder scriptBuilder = new StringBuilder();
                Int32 index = 0;

                foreach (var clientValue in nonVisualSetting.Clients)
                {
                    if (clientValue.Key != NonVisualSetting.Else)
                    {
                        if (index == 0)
                            insertsBuilder.AppendLine($"    IF ls_client = '{clientValue.Key}' THEN");
                        else
                            insertsBuilder.AppendLine($"    ELSIF ls_client = '{clientValue.Key}' THEN");
                    }
                    else
                    {
                        insertsBuilder.AppendLine($"    ELSE");
                    }
                    insertsBuilder.AppendLine($"      insert_non_visual('{nonVisualSetting.Name}', '{clientValue.Value}');");

                    index++;
                }
                insertsBuilder.AppendLine($"    END IF;");

                scriptBuilder.AppendLine($"DECLARE");
                scriptBuilder.AppendLine($"  ln_exist NUMBER;");
                scriptBuilder.AppendLine($"  ls_client VARCHAR2(250);");
                scriptBuilder.AppendLine($"  PROCEDURE insert_non_visual(ps_name  IN VARCHAR2, ps_value IN VARCHAR2) AS");
                scriptBuilder.AppendLine($"  BEGIN");
                scriptBuilder.AppendLine($"    INSERT INTO SETTINGS.SYST_ATTRIBUTES_T(CODE, VALUE) VALUES(ps_name, ps_value);");
                scriptBuilder.AppendLine($"  END; ");
                scriptBuilder.AppendLine($"BEGIN");
                scriptBuilder.AppendLine($"  SELECT COUNT(1) INTO ln_exist FROM SETTINGS.SYST_ATTRIBUTES_T WHERE CODE = '{nonVisualSetting.Name}';");
                scriptBuilder.AppendLine($"  ls_client := SETTINGS.GET_SYST_ATTR('APT_CLIENT');");
                scriptBuilder.AppendLine($"  IF ln_exist = 0 THEN");
                scriptBuilder.AppendLine($"{insertsBuilder.ToString()}");
                scriptBuilder.AppendLine($"  END IF;");
                scriptBuilder.AppendLine($"END;");
                scriptBuilder.AppendLine($"/");

                return scriptBuilder.ToString();
            });
        }

        private string GenerateForeignKeyScript(ConstraintForeignKey c)
        {
            if (c == null)
                return string.Empty;

            return $"EXECUTE IMMEDIATE 'ALTER TABLE {c.Schema}.{c.TableName} ADD CONSTRAINT {c.Name} FOREIGN KEY ({c.TableColumnName}) REFERENCES {c.ReferencedTableSchemaName}.{c.ReferencedTableName}({c.ReferencedTableColumnName})';";
        }

        private string GenerateIndexScript(Constraint c)
        {
            if (c == null)
                return string.Empty;

            return $"EXECUTE IMMEDIATE 'CREATE INDEX {c.Schema}.{c.Name} ON {c.Schema}.{c.TableName}({c.TableColumnName}) TABLESPACE {(string.IsNullOrWhiteSpace(c.TableSpace) ? "INDX" : c.TableSpace)}';";
        }
        private string GeneratePrimaryKeyScript(Constraint c)
        {
            if (c == null)
                return string.Empty;

            return $"EXECUTE IMMEDIATE 'ALTER TABLE {c.Schema}.{c.TableName} ADD CONSTRAINT {c.Name} PRIMARY KEY (ID) USING INDEX{(string.IsNullOrWhiteSpace(c.TableSpace) ? "" : " TABLESPACE " + c.TableSpace)}';";
        }
        private string GenerateUniqueScript(Constraint c)
        {
            if (c == null)
                return string.Empty;

            return $"EXECUTE IMMEDIATE 'ALTER TABLE {c.Schema}.{c.TableName} ADD CONSTRAINT {c.Name} UNIQUE ({c.TableColumnName})';";
        }

        private string GenerateCommentScript(Table t)
        {
            if (!string.IsNullOrWhiteSpace(t.Comment))
                return $"EXECUTE IMMEDIATE 'COMMENT ON TABLE {t.Schema}.{t.Name} IS ''{t.Comment}''';";

            return string.Empty;
        }

        private string GenerateColumnDefinition(Column c)
        {
            if (c == null)
                return string.Empty;

            return $"{c.Name} {GenerateTypeDefinition(c)} {GenerateDefaultValueDefinition(c)}";
        }
        private string GenerateDefaultValueDefinition(Column c)
        {
            if (c != null && !string.IsNullOrWhiteSpace(c.DefaultValue))
            {
                string result = "DEFAULT ";
                if (long.TryParse(c.DefaultValue, out long intOutput) || c.DefaultValue.ToUpper() == "SYSDATE")
                    result += c.DefaultValue;
                else if (DateTime.TryParse(c.DefaultValue, out DateTime dateOutput))
                    result += $"TO_DATE(''{dateOutput.Date.ToString("yyyy-MM-dd")}'', ''yyyy-mm-dd'')";
                else
                    result += $" DEFAULT ''{c.DefaultValue}''";

                if (c.IsNullable)
                    result += " NOT NULL";

                return result;
            }

            return string.Empty;
        }
        private string GenerateCommentScript(Column c)
        {
            if (!string.IsNullOrWhiteSpace(c.Comment))
                return $"EXECUTE IMMEDIATE 'COMMENT ON COLUMN {c.TableSchema}.{c.TableName}.\"{c.Name}\" IS ''{c.Comment}''';";

            return string.Empty;
        }
        private string GenerateTypeDefinition(Column c)
        {
            if (c == null)
                return string.Empty;

            string result = Enum.GetName(typeof(DataType), c.DataType).ToUpper();

            if (c.DataLength.HasValue && (c.DataType == DataType.Number || c.DataType == DataType.Varchar2))
            {
                result += $"({c.DataLength.ToString()})";
            }

            return result;
        }
    }
}
