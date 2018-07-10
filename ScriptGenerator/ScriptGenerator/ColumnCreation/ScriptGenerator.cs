using System;
using System.Drawing;
using System.Text;

namespace ScriptGenerator
{
    public partial class ScriptGenerator
    {
        //Column creation tab events
        private void columnIsFkCheckBox_CheckedChanged(Object sender, EventArgs e)
        {
            if (!columnIsFkCheckBox.Checked)
            {
                columnFkNameTextBox.BackColor = Color.Gray;
                columnFkNameTextBox.ReadOnly = true;
                columnIndexNameTextBox.BackColor = Color.Gray;
                columnIndexNameTextBox.ReadOnly = true;
                columnRefSchemaNameTextBox.BackColor = Color.Gray;
                columnRefSchemaNameTextBox.ReadOnly = true;
                columnRefTableNameTextBox.BackColor = Color.Gray;
                columnRefTableNameTextBox.ReadOnly = true;
                columnRefColumnNameTextBox.BackColor = Color.Gray;
                columnRefColumnNameTextBox.ReadOnly = true;
            }
            else
            {
                columnFkNameTextBox.BackColor = Color.White;
                columnFkNameTextBox.ReadOnly = false;
                columnIndexNameTextBox.BackColor = Color.White;
                columnIndexNameTextBox.ReadOnly = false;
                columnRefSchemaNameTextBox.BackColor = Color.White;
                columnRefSchemaNameTextBox.ReadOnly = false;
                columnRefTableNameTextBox.BackColor = Color.White;
                columnRefTableNameTextBox.ReadOnly = false;
                columnRefColumnNameTextBox.BackColor = Color.White;
                columnRefColumnNameTextBox.ReadOnly = false;
            }
        }
        private void columnBtn_Click(Object sender, EventArgs e)
        {
            StringBuilder scriptBuilder = new StringBuilder();
            String comment = columnCommentTextBox.Text.Length > 0 ?
                GenerateColumnCommentScript(columnsSchemaTextBox.Text, columnsTableNameTextBox.Text, columnColumnTextBox.Text, columnCommentTextBox.Text, "      ") + Environment.NewLine :
                String.Empty;
            String foreignKey = columnIsFkCheckBox.Checked ? GenerateForeignKeyScript(columnsSchemaTextBox.Text, columnsTableNameTextBox.Text, columnColumnTextBox.Text, columnFkNameTextBox.Text,
                columnRefSchemaNameTextBox.Text, columnRefTableNameTextBox.Text, columnRefColumnNameTextBox.Text, "      ") + Environment.NewLine : String.Empty;
            /*String fkIndex = String.IsNullOrWhiteSpace(columnIndexNameTextBox.Text) ?
                String.Empty :
                GenerateIndexScript(columnsSchemaTextBox.Text, columnsTableNameTextBox.Text, columnColumnTextBox.Text, columnIndexNameTextBox.Text, "      ") + Environment.NewLine;*/

            scriptBuilder.Append($"DECLARE{Environment.NewLine}");
            scriptBuilder.Append($"  ln_exist NUMBER;{Environment.NewLine}");
            scriptBuilder.Append($"BEGIN{Environment.NewLine}");
            scriptBuilder.Append($"  SELECT COUNT(1){Environment.NewLine}");
            scriptBuilder.Append($"    INTO ln_exist{Environment.NewLine}");
            scriptBuilder.Append($"    FROM ALL_TAB_COLS ATC{Environment.NewLine}");
            scriptBuilder.Append($"   WHERE ATC.OWNER = '{columnsSchemaTextBox.Text}'{Environment.NewLine}");
            scriptBuilder.Append($"     AND ATC.TABLE_NAME = '{columnsTableNameTextBox.Text}'{Environment.NewLine}");
            scriptBuilder.Append($"     AND ATC.COLUMN_NAME = '{columnColumnTextBox.Text}';{Environment.NewLine}");
            scriptBuilder.Append($"  IF ln_exist = 0 THEN{Environment.NewLine}");
            scriptBuilder.Append($"      EXECUTE IMMEDIATE 'ALTER TABLE {columnsSchemaTextBox.Text}.{columnsTableNameTextBox.Text} ADD (");
            scriptBuilder.Append($"{GenerateColumnDefinition(columnColumnTextBox.Text, columnTypeTextBox.Text, columnDefaultTextBox.Text, columnIsNullableCheckBox.Checked)})';{Environment.NewLine}");
            scriptBuilder.Append(comment);
            scriptBuilder.Append(foreignKey);
            scriptBuilder.Append($"  END IF;{Environment.NewLine}");
            scriptBuilder.Append($"END;{Environment.NewLine}");
            scriptBuilder.Append($"/");

            scriptTextBox.Text = scriptBuilder.ToString();
        }

        private String GenerateForeignKeyScript(String schema, String tableName, String columnName, String fkName, String refSchema, String refTableName, String refColumnName, String indentation = "")
        {
            return $"{indentation}EXECUTE IMMEDIATE 'ALTER TABLE {schema}.{tableName} ADD CONSTRAINT {fkName} FOREIGN KEY ({columnName}) REFERENCES {refSchema}.{refTableName}({refColumnName})';";
        }
        private String GenerateColumnDefinition(String columnName, String columnType, String defaultValue, Boolean isNullable, String indentation = "")
        {
            return $"{indentation}{columnName} {columnType}{(String.IsNullOrEmpty(defaultValue) ? "" : " DEFAULT " + GetDefaultValue(defaultValue))}{(isNullable ? "" : " NOT NULL")}";
        }
    }
}
