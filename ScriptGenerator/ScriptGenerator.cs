using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace ScriptGenerator
{
    public partial class ScriptGenerator : Form
    {
        public ScriptGenerator()
        {
            InitializeComponent();

            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            Text = Text + " " + version.Major + "." + version.Minor;

            //Init first tab default values
            tableColumnsGrid.Rows.Add(true, "ID", "NUMBER", null, false, "Identificator", false, null, false, null, null, null, null, null);
            tableColumnsGrid.Rows[0].ReadOnly = true;
            tableColumnsGrid.Columns["tableColumnsIsPK"].DefaultCellStyle.BackColor = Color.Gray;
            tableColumnsGrid.Rows[0].DefaultCellStyle.BackColor = Color.Gray;

            //Init second tab default values
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

        #region Generation methods
        private String GenerateForeignKeyScript(String schema, String tableName, String columnName, String fkName, String refSchema, String refTableName, String refColumnName, String indentation = "")
        {
            return $"EXECUTE IMMEDIATE 'ALTER TABLE {schema}.{tableName} ADD CONSTRAINT {fkName} FOREIGN KEY ({columnName}) REFERENCES {refSchema}.{refTableName}({refColumnName})';";
        }
        private String GenerateColumnDefinition(String columnName, String columnType, String defaultValue, Boolean isNullable, String indentation = "")
        {
            return $"{columnName} {columnType}{(String.IsNullOrEmpty(defaultValue) ? "" : " DEFAULT " + GetDefaultValue(defaultValue))}{(isNullable ? "" : " NOT NULL")}";
        }
        private String GenerateColumnCommentScript(String schema, String tableName, String columnName, String comment, String indentation = "")
        {
            return $"EXECUTE IMMEDIATE 'COMMENT ON COLUMN {schema}.{tableName}.\"{columnName}\" IS ''{comment}''';";
        }
        private String GenerateIndexScript(String schema, String tableName, String columnName, String indexName, String indentation = "")
        {
            return $"EXECUTE IMMEDIATE 'CREATE INDEX {indexName} ON {schema}.{tableName}({columnName}) TABLESPACE INDX';";
        }
        private String GenerateTableCommentScript(String schema, String tableName, String comment, String indentation = "")
        {
            return $"EXECUTE IMMEDIATE 'COMMENT ON TABLE {schema}.{tableName} IS ''{comment}''';";
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

            if (Int64.TryParse(input, out intOutput))
            {
                return input;
            }

            if (DateTime.TryParse(input, out dateOutput))
            {
                return $"TO_DATE(''{dateOutput.Date.ToString("yyyy-MM-dd")}'', ''yyyy-mm-dd'')";
            }

            return $"''{input}''";
        }
        #endregion

        #region Events
        //Column creation tab events
        private void columnIsFkCheckBox_CheckedChanged(object sender, EventArgs e)
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
            String comment = columnCommentTextBox.Text.Length > 0 ?
                GenerateColumnCommentScript(columnsSchemaTextBox.Text, columnsTableNameTextBox.Text, columnColumnTextBox.Text, columnCommentTextBox.Text, "      ") + Environment.NewLine :
                String.Empty;
            String foreignKey = columnIsFkCheckBox.Checked ? GenerateForeignKeyScript(columnsSchemaTextBox.Text, columnsTableNameTextBox.Text, columnColumnTextBox.Text, columnFkNameTextBox.Text,
                columnRefSchemaNameTextBox.Text, columnRefTableNameTextBox.Text, columnRefColumnNameTextBox.Text, "      ") + Environment.NewLine : String.Empty;
            scriptTextBox.Text = $"DECLARE" + Environment.NewLine +
                $"  ln_exist NUMBER;" + Environment.NewLine +
                $"BEGIN" + Environment.NewLine +
                $"  SELECT COUNT(1)" + Environment.NewLine +
                $"    INTO ln_exist" + Environment.NewLine +
                $"    FROM ALL_TAB_COLS ATC" + Environment.NewLine +
                $"   WHERE ATC.OWNER = '{columnsSchemaTextBox.Text}'" + Environment.NewLine +
                $"     AND ATC.TABLE_NAME = '{columnsTableNameTextBox.Text}'" + Environment.NewLine +
                $"     AND ATC.COLUMN_NAME = '{columnColumnTextBox.Text}';" + Environment.NewLine +
                $"  IF ln_exist = 0 THEN" + Environment.NewLine +
                $"      EXECUTE IMMEDIATE 'ALTER TABLE {columnsSchemaTextBox.Text}.{columnsTableNameTextBox.Text} ADD (" +
                $"{GenerateColumnDefinition(columnColumnTextBox.Text, columnTypeTextBox.Text, columnDefaultTextBox.Text, columnIsNullableCheckBox.Checked)});" + Environment.NewLine +
                comment +
                foreignKey +
                $"  END IF;" + Environment.NewLine +
                $"END;" + Environment.NewLine +
                $"/";
        }

        //Table creation tab events
        private void tableColumnsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
        private void tableRemoveBtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in tableColumnsGrid.SelectedRows)
            {
                if (row.Index != 0)
                    tableColumnsGrid.Rows.Remove(row);
            }
                
        }
        private void tableAddBtn_Click(object sender, EventArgs e)
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
            List<String> columns = new List<String>();
            List<String> commentScripts = new List<String>();
            List<String> uniqueConstraintScripts = new List<String>();
            List<String> fkScripts = new List<String>();

            //Loop through each row and form column, comment, foreign key script values.
            foreach (DataGridViewRow row in tableColumnsGrid.Rows)
            {
                var test = GetStrCellValue(row, "tableColumnsType");
                var test3 = row.Cells["tableColumnsIsNullable"].Value;
                var test2 = GetBoolCellValue(row, "tableColumnsIsNullable");

                columns.Add(GenerateColumnDefinition(GetStrCellValue(row, "tableColumnsName"), GetStrCellValue(row, "tableColumnsType"), GetStrCellValue(row, "tableColumnsDefault"), GetBoolCellValue(row, "tableColumnsIsNullable")));

                if (GetBoolCellValue(row, "tableColumnsIsUnique"))
                    uniqueConstraintScripts.Add($"CONSTRAINT {GetStrCellValue(row, "tableColumnsUniqueConstraintName")} UNIQUE ({GetStrCellValue(row, "tableColumnsName")})");

                if (!String.IsNullOrEmpty(tableTableCommentTextBox.Text))
                    commentScripts.Add(GenerateTableCommentScript(tableSchemaTextBox.Text, tableTableNameTextBox.Text, tableTableCommentTextBox.Text));

                if (!String.IsNullOrEmpty(GetStrCellValue(row, "tableColumnsComment")))
                    commentScripts.Add(GenerateColumnCommentScript(tableSchemaTextBox.Text, tableTableNameTextBox.Text, GetStrCellValue(row, "tableColumnsName"), GetStrCellValue(row, "tableColumnsComment")));

                if (GetBoolCellValue(row, "tableColumnsIsForeignKey"))
                {
                    fkScripts.Add(GenerateForeignKeyScript(tableSchemaTextBox.Text, tableTableNameTextBox.Text, GetStrCellValue(row, "tableColumnsName"), GetStrCellValue(row, "tableColumnsFKName"),
                        GetStrCellValue(row, "tableColumnsReferencedSchema"), GetStrCellValue(row, "tableColumnsReferencedColumn"), GetStrCellValue(row, "tableColumnsReferencedTable")));
                    fkScripts.Add(GenerateIndexScript(tableSchemaTextBox.Text, tableTableNameTextBox.Text, GetStrCellValue(row, "tableColumnsName"), GetStrCellValue(row, "tableColumnsIndexName")));
                }
            }

            scriptTextBox.Text = $"DECLARE" + Environment.NewLine +
                $"  ln_exist NUMBER;" + Environment.NewLine +
                $"BEGIN" + Environment.NewLine +
                $"  SELECT COUNT(1)" + Environment.NewLine +
                $"    INTO ln_exist" + Environment.NewLine +
                $"    FROM ALL_TABLES AT" + Environment.NewLine +
                $"   WHERE AT.OWNER = '{tableSchemaTextBox.Text}'" + Environment.NewLine +
                $"     AND AT.TABLE_NAME = '{tableTableNameTextBox.Text}';" + Environment.NewLine +
                $"  IF ln_exist = 0 THEN" + Environment.NewLine +
                $"      EXECUTE IMMEDIATE 'CREATE TABLE {tableSchemaTextBox.Text}.{tableTableNameTextBox.Text}" + Environment.NewLine +
                $"      (" + Environment.NewLine +
                $"          {String.Join("," + Environment.NewLine + "          ", columns.Concat(uniqueConstraintScripts))}" + Environment.NewLine +
                $"      )';" + Environment.NewLine +
                $"      EXECUTE IMMEDIATE 'ALTER TABLE {tableSchemaTextBox.Text}.{tableTableNameTextBox.Text} ADD CONSTRAINT {tablePKTextBox.Text} PRIMARY KEY (ID) USING INDEX';" + Environment.NewLine +
                $"      {String.Join(Environment.NewLine + "      ", commentScripts.Concat(fkScripts))}" + Environment.NewLine +
                $"  END IF;" + Environment.NewLine +
                $"END;" + Environment.NewLine +
                $"/";
        }
        #endregion

    }
}
