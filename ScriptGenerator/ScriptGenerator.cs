using Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace ScriptGenerator
{
    public partial class ScriptGenerator : Form
    {
        private IWordWorks wordWorker;

        public ScriptGenerator(IWordWorks wordWorker)
        {
            this.wordWorker = wordWorker;
            InitializeWindow();
        }

        private void InitializeWindow()
        {
            InitializeComponent();

            Icon = new Icon("Resources/generator_icon_01_a6a_icon.ico");

            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            Text = Text + " " + version.Major + "." + version.Minor;

            //Init table creation tab default values
            tableColumnsGrid.Rows.Add(true, "ID", "NUMBER", null, false, "Identificator", false, null, false, null, null, null, null, null);
            tableColumnsGrid.Rows[0].ReadOnly = true;
            tableColumnsGrid.Columns["tableColumnsIsPK"].DefaultCellStyle.BackColor = Color.Gray;
            tableColumnsGrid.Rows[0].DefaultCellStyle.BackColor = Color.Gray;

            //Init column creation tab default values
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

            //Init sequence creation tab default values
            seqIncrementByTextBox.Text = "1";
            seqStartWithTextBox.Text = "1";

            //Init non visual settings creation tab default values
            List<String> clients = ConfigurationManager.AppSettings["clients"].Split(',').ToList();
            foreach (String client in clients)
            {
                nonVisualClientsGrid.Columns.Add(client, client);
                nonVisLoadCheckedListBox.Items.Add(client, false);
            }
            nonVisualClientsGrid.Columns.Add(Else, Else);
            nonVisualClientsGrid.Rows.Add();
        }

        private static String Else = "Else";

        #region Generation methods
        private String GenerateForeignKeyScript(String schema, String tableName, String columnName, String fkName, String refSchema, String refTableName, String refColumnName, String indentation = "")
        {
            return $"{indentation}EXECUTE IMMEDIATE 'ALTER TABLE {schema}.{tableName} ADD CONSTRAINT {fkName} FOREIGN KEY ({columnName}) REFERENCES {refSchema}.{refTableName}({refColumnName})';";
        }
        private String GenerateColumnDefinition(String columnName, String columnType, String defaultValue, Boolean isNullable, String indentation = "")
        {
            return $"{indentation}{columnName} {columnType}{(String.IsNullOrEmpty(defaultValue) ? "" : " DEFAULT " + GetDefaultValue(defaultValue))}{(isNullable ? "" : " NOT NULL")}";
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
        private String GenerateNonVisualSettingScript(String code, String value)
        {
            return $"INSERT INTO SETTINGS.SYST_ATTRIBUTES_T (CODE, VALUE) VALUES ('{code}', '{value}');";
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
        private String GenerateUpdateStatementForNonVisualSetting(String nonVisualSetting, String value)
        {
            return $"  UPDATE SETTINGS.SYST_ATTRIBUTES_T SET VALUE = '{value}' WHERE CODE = '{nonVisualSetting}';{Environment.NewLine}";
        }
        #endregion

        #region Events
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
            String comment = columnCommentTextBox.Text.Length > 0 ?
                GenerateColumnCommentScript(columnsSchemaTextBox.Text, columnsTableNameTextBox.Text, columnColumnTextBox.Text, columnCommentTextBox.Text, "      ") + Environment.NewLine :
                String.Empty;
            String foreignKey = columnIsFkCheckBox.Checked ? GenerateForeignKeyScript(columnsSchemaTextBox.Text, columnsTableNameTextBox.Text, columnColumnTextBox.Text, columnFkNameTextBox.Text,
                columnRefSchemaNameTextBox.Text, columnRefTableNameTextBox.Text, columnRefColumnNameTextBox.Text, "      ") + Environment.NewLine : String.Empty;
            String fkIndex = String.IsNullOrWhiteSpace(columnIndexNameTextBox.Text) ?
                String.Empty :
                GenerateIndexScript(columnsSchemaTextBox.Text, columnsTableNameTextBox.Text, columnColumnTextBox.Text, columnIndexNameTextBox.Text, "      ") + Environment.NewLine;
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
                $"{GenerateColumnDefinition(columnColumnTextBox.Text, columnTypeTextBox.Text, columnDefaultTextBox.Text, columnIsNullableCheckBox.Checked)})';" + Environment.NewLine +
                comment +
                foreignKey +
                $"  END IF;" + Environment.NewLine +
                $"END;" + Environment.NewLine +
                $"/";
        }

        //Table creation tab events
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
            List<String> columns = new List<String>();
            List<String> commentScripts = new List<String>();
            List<String> uniqueConstraintScripts = new List<String>();
            List<String> fkScripts = new List<String>();

            if (!String.IsNullOrEmpty(tableTableCommentTextBox.Text))
                commentScripts.Add(GenerateTableCommentScript(tableSchemaTextBox.Text, tableTableNameTextBox.Text, tableTableCommentTextBox.Text));

            //Loop through each row and form column, comment, foreign key script values.
            foreach (DataGridViewRow row in tableColumnsGrid.Rows)
            {
                var test = GetStrCellValue(row, "tableColumnsType");
                var test3 = row.Cells["tableColumnsIsNullable"].Value;
                var test2 = GetBoolCellValue(row, "tableColumnsIsNullable");

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
                $"      ){(String.IsNullOrWhiteSpace(tableTablespaceTextBox.Text) ? "" : " TABLESPACE " + tableTablespaceTextBox.Text)}';" + Environment.NewLine +
                $"      EXECUTE IMMEDIATE 'ALTER TABLE {tableSchemaTextBox.Text}.{tableTableNameTextBox.Text} ADD CONSTRAINT {tablePKTextBox.Text} PRIMARY KEY (ID) USING INDEX{(String.IsNullOrWhiteSpace(tableTablespaceTextBox.Text) ? "" : " TABLESPACE " + tableTablespaceTextBox.Text)}';" + Environment.NewLine +
                $"      {String.Join(Environment.NewLine + "      ", commentScripts.Concat(fkScripts))}" + Environment.NewLine +
                $"  END IF;" + Environment.NewLine +
                $"END;" + Environment.NewLine +
                $"/";
        }

        //Audit trigger creation events
        private void auditBtn_Click(Object sender, EventArgs e)
        {
            scriptTextBox.Text = $"CREATE OR REPLACE TRIGGER {auditSchemaTextBox.Text}.{auditTableNameTextBox.Text}.{auditTriggerNameTextBox.Text}" + Environment.NewLine +
                $"  BEFORE INSERT OR UPDATE ON {auditSchemaTextBox.Text}.{auditTableNameTextBox.Text}" + Environment.NewLine +
                $"  FOR EACH ROW" + Environment.NewLine +
                $"DECLARE" + Environment.NewLine +
                $"  ls_user VARCHAR2(250);" + Environment.NewLine +
                $"BEGIN" + Environment.NewLine +
                $"  SELECT NVL(settings.glob.s_current_user_name, MIN(vs.osuser))" + Environment.NewLine +
                $"    INTO ls_user" + Environment.NewLine +
                $"    FROM v$session vs" + Environment.NewLine +
                $"   WHERE vs.audsid = userenv('sessionid');" + Environment.NewLine +
                $"  IF INSERTING THEN" + Environment.NewLine +
                $"    :NEW.record_date := sysdate;" + Environment.NewLine +
                $"    IF :NEW.record_user IS NULL THEN" + Environment.NewLine +
                $"      :NEW.record_user := s_user;" + Environment.NewLine +
                $"    END IF;" + Environment.NewLine +
                $"  ELSE" + Environment.NewLine +
                $"    :NEW.edit_date := sysdate;" + Environment.NewLine +
                $"    IF :NEW.edit_user IS NULL THEN" + Environment.NewLine +
                $"      :NEW.edit_user := s_user;" + Environment.NewLine +
                $"    END IF;" + Environment.NewLine +
                $"  END IF;" + Environment.NewLine +
                $"END;";
        }

        //Sequence creation events
        private void seqBtn_Click(Object sender, EventArgs e)
        {
            scriptTextBox.Text = $"DECLARE" + Environment.NewLine +
                $"  ln_exist NUMBER;" + Environment.NewLine +
                $"BEGIN" + Environment.NewLine +
                $"  SELECT COUNT(1)" + Environment.NewLine +
                $"    INTO ln_exist" + Environment.NewLine +
                $"    FROM ALL_SEQUENCES A" + Environment.NewLine +
                $"   WHERE A.SEQUENCE_NAME = '{seqSequenceNameTextBox.Text}'" + Environment.NewLine +
                $"     AND A.SEQUENCE_OWNER = '{seqSchemaTextBox.Text}';" + Environment.NewLine +
                $"  IF ln_exist = 0 THEN" + Environment.NewLine +
                $"    EXECUTE IMMEDIATE 'CREATE SEQUENCE {seqSchemaTextBox.Text}.{seqSequenceNameTextBox.Text} START WITH {seqStartWithTextBox.Text} " +
                $"INCREMENT BY {seqIncrementByTextBox.Text} NOCACHE';" + Environment.NewLine +
                $"  END IF;" + Environment.NewLine +
                $"END;";
        }

        //Non visual setting creation events
        private void nonVisualBtn_Click(Object sender, EventArgs e)
        {
            String insertScript = String.Empty;
            Int32 index = 0;

            foreach (DataGridViewColumn column in nonVisualClientsGrid.Columns)
            {
                if (!String.IsNullOrWhiteSpace(GetStrCellValue(nonVisualClientsGrid.Rows[0], column.HeaderText)))
                {
                    if (column.HeaderText != Else)
                    {
                        if (index == 0)
                            insertScript += $"    IF ls_client = '{column.HeaderText}' THEN" + Environment.NewLine;
                        else
                            insertScript += $"    ELSIF ls_client = '{column.HeaderText}' THEN" + Environment.NewLine;
                    }
                    else
                    {
                        insertScript += $"    ELSE" + Environment.NewLine;
                    }

                    insertScript += $"      {GenerateNonVisualSettingScript(nonVisualCodeTextBox.Text, GetStrCellValue(nonVisualClientsGrid.Rows[0], column.HeaderText))}" + Environment.NewLine;

                    index++;
                }
            }
            insertScript += $"    END IF;" + Environment.NewLine;

            scriptTextBox.Text = $"DECLARE" + Environment.NewLine +
                $"  ln_exist NUMBER;" + Environment.NewLine +
                $"  ls_client VARCHAR2(250);" + Environment.NewLine +
                $"BEGIN" + Environment.NewLine +
                $"  SELECT COUNT(1) INTO ln_exist FROM SETTINGS.SYST_ATTRIBUTES_T WHERE CODE = '{nonVisualCodeTextBox.Text}';" + Environment.NewLine +
                $"  ls_client := SETTINGS.GET_SYST_ATTR('APT_CLIENT');" + Environment.NewLine +
                $"  IF ln_exist = 0 THEN" + Environment.NewLine +
                $"{insertScript}" +
                $"  END IF;" + Environment.NewLine +
                $"END;" + Environment.NewLine +
                $"/";
        }

        //Non visual setting loading events
        private void NonVisLoadCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //Allow only one box to be checked
            if (e.NewValue == CheckState.Checked)
                for (int ix = 0; ix < nonVisLoadCheckedListBox.Items.Count; ++ix)
                    if (e.Index != ix) nonVisLoadCheckedListBox.SetItemChecked(ix, false);
        }

        private void NonVisLoadButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (nonVisLoadCheckedListBox.CheckedItems.Count > 0 && !String.IsNullOrWhiteSpace(nonVisualLoadPathLabel.Text))
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append($"BEGIN{Environment.NewLine}");
                stringBuilder.Append(GenerateUpdateStatementForNonVisualSetting("APT_CLIENT", nonVisLoadCheckedListBox.CheckedItems[0].ToString()));

                foreach (KeyValuePair<String, Int32> entry in wordWorker.GetClientSettings(nonVisLoadCheckedListBox.CheckedItems[0].ToString(), nonVisualLoadPathLabel.Text))
                {
                    stringBuilder.Append(GenerateUpdateStatementForNonVisualSetting(entry.Key, entry.Value.ToString()));
                }

                stringBuilder.Append($"END;");

                scriptTextBox.Text = stringBuilder.ToString();
            }

            Cursor.Current = Cursors.Arrow;
        }

        private void nonVisualLoadFileButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (nonVisualLoadFileDialog.ShowDialog() == DialogResult.OK)
                nonVisualLoadPathLabel.Text = nonVisualLoadFileDialog.FileName;
            else
                nonVisualLoadPathLabel.Text = String.Empty;

            Cursor.Current = Cursors.Arrow;
        }

        #endregion
    }
}
