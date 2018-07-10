using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScriptGenerator
{
    public partial class ScriptGenerator
    {
        private void tableColumnsGrid_CellContentClick(Object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6 || e.ColumnIndex == 8)
                tableColumnsGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);

            if (e.ColumnIndex == 6)
            {
                if ((Boolean)tableColumnsGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)
                {
                    tableColumnsGrid.Rows[e.RowIndex].Cells[7].ReadOnly = false;
                    tableColumnsGrid.Rows[e.RowIndex].Cells[7].Style.BackColor = Color.White;
                }
                else
                {
                    tableColumnsGrid.Rows[e.RowIndex].Cells[7].ReadOnly = true;
                    tableColumnsGrid.Rows[e.RowIndex].Cells[7].Style.BackColor = Color.Gray;
                }
            }

            if (e.ColumnIndex == 8)
            {
                if ((Boolean)tableColumnsGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)
                {
                    tableColumnsGrid.Rows[e.RowIndex].Cells[9].ReadOnly = false;
                    tableColumnsGrid.Rows[e.RowIndex].Cells[9].Style.BackColor = Color.White;
                    tableColumnsGrid.Rows[e.RowIndex].Cells[10].ReadOnly = false;
                    tableColumnsGrid.Rows[e.RowIndex].Cells[10].Style.BackColor = Color.White;
                    tableColumnsGrid.Rows[e.RowIndex].Cells[11].ReadOnly = false;
                    tableColumnsGrid.Rows[e.RowIndex].Cells[11].Style.BackColor = Color.White;
                    tableColumnsGrid.Rows[e.RowIndex].Cells[12].ReadOnly = false;
                    tableColumnsGrid.Rows[e.RowIndex].Cells[12].Style.BackColor = Color.White;
                    tableColumnsGrid.Rows[e.RowIndex].Cells[13].ReadOnly = false;
                    tableColumnsGrid.Rows[e.RowIndex].Cells[13].Style.BackColor = Color.White;
                }
                else
                {
                    tableColumnsGrid.Rows[e.RowIndex].Cells[9].ReadOnly = true;
                    tableColumnsGrid.Rows[e.RowIndex].Cells[9].Style.BackColor = Color.Gray;
                    tableColumnsGrid.Rows[e.RowIndex].Cells[10].ReadOnly = true;
                    tableColumnsGrid.Rows[e.RowIndex].Cells[10].Style.BackColor = Color.Gray;
                    tableColumnsGrid.Rows[e.RowIndex].Cells[11].ReadOnly = true;
                    tableColumnsGrid.Rows[e.RowIndex].Cells[11].Style.BackColor = Color.Gray;
                    tableColumnsGrid.Rows[e.RowIndex].Cells[12].ReadOnly = true;
                    tableColumnsGrid.Rows[e.RowIndex].Cells[12].Style.BackColor = Color.Gray;
                    tableColumnsGrid.Rows[e.RowIndex].Cells[13].ReadOnly = true;
                    tableColumnsGrid.Rows[e.RowIndex].Cells[13].Style.BackColor = Color.Gray;
                }
            }
        }
        private void tableRemoveBtn_Click(Object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in tableColumnsGrid.SelectedRows)
            {
                if (row.Index != 0)
                    tableColumnsGrid.Rows.Remove(row);
            }

        }
        private void tableAuditBtn_Click(Object sender, EventArgs e)
        {
            AddUneditableRow("RECORD_DATE", "DATE", "Date of record creation");
            AddUneditableRow("EDIT_DATE", "DATE", "Date of record edit");
            AddUneditableRow("RECORD_USER", "VARCHAR2(250)", "User name of record creator");
            AddUneditableRow("EDIT_USER", "VARCHAR2(250)", "User name of last record editor");
        }
        private void tableAddBtn_Click(Object sender, EventArgs e)
        {
            Int32 index = tableColumnsGrid.Rows.Add(false, null, null, null, true, null, false, null, false, null, null, null, null, null);
            tableColumnsGrid.Rows[index].Cells["tableColumnsUniqueConstraintName"].ReadOnly = true;
            tableColumnsGrid.Rows[index].Cells["tableColumnsFKName"].ReadOnly = true;
            tableColumnsGrid.Rows[index].Cells["tableColumnsIndexName"].ReadOnly = true;
            tableColumnsGrid.Rows[index].Cells["tableColumnsReferencedSchema"].ReadOnly = true;
            tableColumnsGrid.Rows[index].Cells["tableColumnsReferencedTable"].ReadOnly = true;
            tableColumnsGrid.Rows[index].Cells["tableColumnsReferencedColumn"].ReadOnly = true;

            tableColumnsGrid.Rows[index].Cells["tableColumnsUniqueConstraintName"].Style.BackColor = Color.Gray;
            tableColumnsGrid.Rows[index].Cells["tableColumnsFKName"].Style.BackColor = Color.Gray;
            tableColumnsGrid.Rows[index].Cells["tableColumnsIndexName"].Style.BackColor = Color.Gray;
            tableColumnsGrid.Rows[index].Cells["tableColumnsReferencedSchema"].Style.BackColor = Color.Gray;
            tableColumnsGrid.Rows[index].Cells["tableColumnsReferencedTable"].Style.BackColor = Color.Gray;
            tableColumnsGrid.Rows[index].Cells["tableColumnsReferencedColumn"].Style.BackColor = Color.Gray;
        }
        private void tableBtn_Click(Object sender, EventArgs e)
        {
            StringBuilder scriptBuilder = new StringBuilder();

            List<String> columns = new List<String>();
            List<String> commentScripts = new List<String>();
            List<String> uniqueConstraintScripts = new List<String>();
            List<String> fkScripts = new List<String>();

            if (!String.IsNullOrEmpty(tableTableCommentTextBox.Text))
                commentScripts.Add(GenerateTableCommentScript(tableSchemaTextBox.Text, tableTableNameTextBox.Text, tableTableCommentTextBox.Text));

            //Loop through each row and form column, comment, foreign key script values.
            foreach (DataGridViewRow row in tableColumnsGrid.Rows)
            {
                columns.Add(GenerateColumnDefinition(GetStrCellValue(row, "tableColumnsName"), GetStrCellValue(row, "tableColumnsType"), GetStrCellValue(row, "tableColumnsDefault"), GetBoolCellValue(row, "tableColumnsIsNullable")));

                if (GetBoolCellValue(row, "tableColumnsIsUnique"))
                    uniqueConstraintScripts.Add($"CONSTRAINT {GetStrCellValue(row, "tableColumnsUniqueConstraintName")} UNIQUE ({GetStrCellValue(row, "tableColumnsName")})");

                if (!String.IsNullOrEmpty(GetStrCellValue(row, "tableColumnsComment")))
                    commentScripts.Add(GenerateColumnCommentScript(tableSchemaTextBox.Text, tableTableNameTextBox.Text, GetStrCellValue(row, "tableColumnsName"), GetStrCellValue(row, "tableColumnsComment")));

                if (GetBoolCellValue(row, "tableColumnsIsForeignKey"))
                {
                    fkScripts.Add(GenerateForeignKeyScript(tableSchemaTextBox.Text, tableTableNameTextBox.Text, GetStrCellValue(row, "tableColumnsName"), GetStrCellValue(row, "tableColumnsFKName"),
                        GetStrCellValue(row, "tableColumnsReferencedSchema"), GetStrCellValue(row, "tableColumnsReferencedTable"), GetStrCellValue(row, "tableColumnsReferencedColumn")));
                    fkScripts.Add(GenerateIndexScript(tableSchemaTextBox.Text, tableTableNameTextBox.Text, GetStrCellValue(row, "tableColumnsName"), GetStrCellValue(row, "tableColumnsIndexName"), tableSpace: tableTablespaceTextBox.Text));
                }
            }

            scriptBuilder.Append($"DECLARE{Environment.NewLine}");
            scriptBuilder.Append($"  ln_exist NUMBER;{Environment.NewLine}");
            scriptBuilder.Append($"BEGIN{Environment.NewLine}");
            scriptBuilder.Append($"  SELECT COUNT(1){Environment.NewLine}");
            scriptBuilder.Append($"    INTO ln_exist{Environment.NewLine}");
            scriptBuilder.Append($"    FROM ALL_TABLES AT{Environment.NewLine}");
            scriptBuilder.Append($"   WHERE AT.OWNER = '{tableSchemaTextBox.Text}'{Environment.NewLine}");
            scriptBuilder.Append($"     AND AT.TABLE_NAME = '{tableTableNameTextBox.Text}';{Environment.NewLine}");
            scriptBuilder.Append($"  IF ln_exist = 0 THEN{Environment.NewLine}");
            scriptBuilder.Append($"      EXECUTE IMMEDIATE 'CREATE TABLE {tableSchemaTextBox.Text}.{tableTableNameTextBox.Text}{Environment.NewLine}");
            scriptBuilder.Append($"      ({Environment.NewLine}");
            scriptBuilder.Append($"          {String.Join($",{Environment.NewLine}" + "          ", columns.Concat(uniqueConstraintScripts))}{Environment.NewLine}");
            scriptBuilder.Append($"      ){(String.IsNullOrWhiteSpace(tableTablespaceTextBox.Text) ? "" : " TABLESPACE " + tableTablespaceTextBox.Text)}';{Environment.NewLine}");
            scriptBuilder.Append($"      EXECUTE IMMEDIATE 'ALTER TABLE {tableSchemaTextBox.Text}.{tableTableNameTextBox.Text} ADD CONSTRAINT {tablePKTextBox.Text} PRIMARY KEY (ID) USING INDEX{(String.IsNullOrWhiteSpace(tableTablespaceTextBox.Text) ? "" : " TABLESPACE " + tableTablespaceTextBox.Text)}';{Environment.NewLine}");
            scriptBuilder.Append($"      {String.Join(Environment.NewLine + "      ", commentScripts.Concat(fkScripts))}{Environment.NewLine}");
            scriptBuilder.Append($"  END IF;{Environment.NewLine}");
            scriptBuilder.Append($"END;{Environment.NewLine}");
            scriptBuilder.Append($"/");

            scriptTextBox.Text = scriptBuilder.ToString();
        }

        private String GenerateColumnCommentScript(String schema, String tableName, String columnName, String comment, String indentation = "")
        {
            return $"{indentation}EXECUTE IMMEDIATE 'COMMENT ON COLUMN {schema}.{tableName}.\"{columnName}\" IS ''{comment}''';";
        }
        private String GenerateIndexScript(String schema, String tableName, String columnName, String indexName, String indentation = "", String tableSpace = null)
        {
            return $"{indentation}EXECUTE IMMEDIATE 'CREATE INDEX {indexName} ON {schema}.{tableName}({columnName}) TABLESPACE {(String.IsNullOrWhiteSpace(tableSpace) ? "INDX" : tableSpace)}';";
        }
        private String GenerateTableCommentScript(String schema, String tableName, String comment, String indentation = "")
        {
            return $"{indentation}EXECUTE IMMEDIATE 'COMMENT ON TABLE {schema}.{tableName} IS ''{comment}''';";
        }
        private Boolean GetBoolCellValue(DataGridViewRow row, String cell)
        {
            return (Boolean?)row.Cells[cell].Value ?? false;
        }
        private String GetStrCellValue(DataGridViewRow row, String cell)
        {
            return (String)row.Cells[cell].Value;
        }
        private String GetDefaultValue(String input)
        {
            Int64 intOutput;
            DateTime dateOutput;

            if (Int64.TryParse(input, out intOutput) || input.ToUpper() == "SYSDATE")
            {
                return input;
            }

            if (DateTime.TryParse(input, out dateOutput))
            {
                return $"TO_DATE(''{dateOutput.Date.ToString("yyyy-MM-dd")}'', ''yyyy-mm-dd'')";
            }

            return $"''{input}''";
        }
        private void AddUneditableRow(String columnName, String type, String comment)
        {
            Int32 index = tableColumnsGrid.Rows.Add(false, columnName, type, null, true, comment, false, null, false, null, null, null, null, null);
            tableColumnsGrid.Rows[index].ReadOnly = true;
            tableColumnsGrid.Rows[index].DefaultCellStyle.BackColor = Color.Gray;
        }
    }
}
