using ScriptGenerator.Extensions;
using ScriptGenerator.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ScriptGenerator
{
    public partial class ScriptGenerator
    {
        private Table tabTable;

        private const string tableCellKeyIsPrimaryKey = "tableColumnsIsPK";
        private const string tableCellKeyName = "tableColumnsName";
        private const string tableCellKeyType = "tableColumnsType";
        private const string tableCellKeyDataLength = "tableColumnsDataLength";
        private const string tableCellKeyDefault = "tableColumnsDefault";
        private const string tableCellKeyIsNullable = "tableColumnsIsNullable";
        private const string tableCellKeyComment = "tableColumnsComment";
        private const string tableCellKeyIsUnique = "tableColumnsIsUnique";
        private const string tableCellKeyUniqueConstraintName = "tableColumnsUniqueConstraintName";
        private const string tableCellKeyIsForeignKey = "tableColumnsIsForeignKey";
        private const string tableCellKeyForeignKeyName = "tableColumnsFKName";
        private const string tableCellKeyIndexName = "tableColumnsIndexName";
        private const string tableCellKeyForeignKeyReferencedSchema = "tableColumnsReferencedSchema";
        private const string tableCellKeyForeignKeyReferencedTable = "tableColumnsReferencedTable";
        private const string tableCellKeyForeignKeyReferencedTableColumn = "tableColumnsReferencedColumn";

        //Init table creation tab default values
        private void InitializeTableTab()
        {
            ((DataGridViewComboBoxColumn)tableColumnsGrid.Columns[tableCellKeyType]).DataSource = DataTypeDropDown.GetAllDropDownOptions();
            ((DataGridViewComboBoxColumn)tableColumnsGrid.Columns[tableCellKeyType]).DisplayMember = "Value";
            ((DataGridViewComboBoxColumn)tableColumnsGrid.Columns[tableCellKeyType]).ValueMember = "Key";
            tableColumnsGrid.Columns[tableCellKeyType].ValueType = typeof(DataType);

            tableColumnsGrid.Rows.Add(true,
                "ID",
                DataType.Number,
                null,
                null,
                false,
                "Identificator",
                false,
                null,
                false,
                null,
                null,
                null,
                null,
                null);
            tableColumnsGrid.Rows[0].ReadOnly = true;
            tableColumnsGrid.Columns[tableCellKeyIsPrimaryKey].DefaultCellStyle.BackColor = Color.Gray;
            tableColumnsGrid.Rows[0].DefaultCellStyle.BackColor = Color.Gray;
        }

        private void ResetTableTab()
        {
            tableTableCommentTextBox.Text = string.Empty;
            tableTablespaceTextBox.Text = string.Empty;
            tableTableNameTextBox.Text = string.Empty;
            tableSchemaTextBox.Text = string.Empty;
            tablePKTextBox.Text = string.Empty;

            tableColumnsGrid.Rows.Clear();
        }

        private void tableResetBtn_Click(object sender, EventArgs e)
        {
            ResetTableTab();
            InitializeTableTab();
        }

        private void tableColumnsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7 || e.ColumnIndex == 9)
                tableColumnsGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);

            if (e.ColumnIndex == 7)
            {
                if ((bool)tableColumnsGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)
                {
                    tableColumnsGrid.Rows[e.RowIndex].Cells[8].ReadOnly = false;
                    tableColumnsGrid.Rows[e.RowIndex].Cells[8].Style.BackColor = Color.White;
                }
                else
                {
                    tableColumnsGrid.Rows[e.RowIndex].Cells[8].ReadOnly = true;
                    tableColumnsGrid.Rows[e.RowIndex].Cells[8].Style.BackColor = Color.Gray;
                }
            }

            if (e.ColumnIndex == 9)
            {
                if ((bool)tableColumnsGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)
                {
                    tableColumnsGrid.Rows[e.RowIndex].Cells[10].ReadOnly = false;
                    tableColumnsGrid.Rows[e.RowIndex].Cells[10].Style.BackColor = Color.White;
                    tableColumnsGrid.Rows[e.RowIndex].Cells[11].ReadOnly = false;
                    tableColumnsGrid.Rows[e.RowIndex].Cells[11].Style.BackColor = Color.White;
                    tableColumnsGrid.Rows[e.RowIndex].Cells[12].ReadOnly = false;
                    tableColumnsGrid.Rows[e.RowIndex].Cells[12].Style.BackColor = Color.White;
                    tableColumnsGrid.Rows[e.RowIndex].Cells[13].ReadOnly = false;
                    tableColumnsGrid.Rows[e.RowIndex].Cells[13].Style.BackColor = Color.White;
                    tableColumnsGrid.Rows[e.RowIndex].Cells[14].ReadOnly = false;
                    tableColumnsGrid.Rows[e.RowIndex].Cells[14].Style.BackColor = Color.White;
                }
                else
                {
                    tableColumnsGrid.Rows[e.RowIndex].Cells[10].ReadOnly = true;
                    tableColumnsGrid.Rows[e.RowIndex].Cells[10].Style.BackColor = Color.Gray;
                    tableColumnsGrid.Rows[e.RowIndex].Cells[11].ReadOnly = true;
                    tableColumnsGrid.Rows[e.RowIndex].Cells[11].Style.BackColor = Color.Gray;
                    tableColumnsGrid.Rows[e.RowIndex].Cells[12].ReadOnly = true;
                    tableColumnsGrid.Rows[e.RowIndex].Cells[12].Style.BackColor = Color.Gray;
                    tableColumnsGrid.Rows[e.RowIndex].Cells[13].ReadOnly = true;
                    tableColumnsGrid.Rows[e.RowIndex].Cells[13].Style.BackColor = Color.Gray;
                    tableColumnsGrid.Rows[e.RowIndex].Cells[14].ReadOnly = true;
                    tableColumnsGrid.Rows[e.RowIndex].Cells[14].Style.BackColor = Color.Gray;
                }
            }
        }
        private void tableColumnsGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
                PasteInData(ref tableColumnsGrid);
        }
        private void tableRemoveBtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in tableColumnsGrid.SelectedRows)
            {
                if (row.Index != 0)
                    tableColumnsGrid.Rows.Remove(row);
            }
        }
        private void tableAuditBtn_Click(object sender, EventArgs e)
        {
            AddUneditableRow("RECORD_DATE", DataType.Date, null, "Date of record creation");
            AddUneditableRow("EDIT_DATE", DataType.Date, null, "Date of record edit");
            AddUneditableRow("RECORD_USER", DataType.Varchar2, 250, "User name of record creator");
            AddUneditableRow("EDIT_USER", DataType.Varchar2, 250, "User name of last record editor");
        }
        private void tableAddBtn_Click(object sender, EventArgs e)
        {
            AddNewRow();
        }
        private async void tableBtn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            tableBtn.Enabled = false;

            var result = await scriptGenerationService.GenerateCreationScript(TabToModelTable()).ConfigureAwait(false);

            this.Invoke(new Action(() =>
            {
                scriptTextBox.Text = result;

                Cursor.Current = Cursors.Arrow;
                tableBtn.Enabled = true;
            }));
        }

        private T GetCellValue<T>(DataGridViewRow row, string cell)
        {
            return (T) row.Cells[cell].Value;
        }
        private bool GetCellValueBool(DataGridViewRow row, string cell)
        {
            return (bool?) row.Cells[cell].Value ?? false;
        }
        private int? GetCellValueInt(DataGridViewRow row, string cell)
        {
            var value = (string)row.Cells[cell].Value;

            if (string.IsNullOrWhiteSpace(value) || !int.TryParse(value, out var result))
                return null;

            return result;
        }
        private void AddUneditableRow(string columnName, DataType type, int? dataLength, string comment)
        {
            int index = tableColumnsGrid.Rows.Add(false, columnName, type, dataLength, null, true, comment, false, null, false, null, null, null, null, null);
            tableColumnsGrid.Rows[index].ReadOnly = true;
            tableColumnsGrid.Rows[index].DefaultCellStyle.BackColor = Color.Gray;
        }
        private void AddNewRow(int size = 1)
        {
            for (int i = 0; i < size; i++)
            {
                int index = tableColumnsGrid.Rows.Add(false, null, DataType.Number, null, null, true, null, false, null, false, null, null, null, null, null);
                tableColumnsGrid.Rows[index].Cells[tableCellKeyUniqueConstraintName].ReadOnly = true;
                tableColumnsGrid.Rows[index].Cells[tableCellKeyForeignKeyName].ReadOnly = true;
                tableColumnsGrid.Rows[index].Cells[tableCellKeyIndexName].ReadOnly = true;
                tableColumnsGrid.Rows[index].Cells[tableCellKeyForeignKeyReferencedSchema].ReadOnly = true;
                tableColumnsGrid.Rows[index].Cells[tableCellKeyForeignKeyReferencedTable].ReadOnly = true;
                tableColumnsGrid.Rows[index].Cells[tableCellKeyForeignKeyReferencedTableColumn].ReadOnly = true;

                tableColumnsGrid.Rows[index].Cells[tableCellKeyUniqueConstraintName].Style.BackColor = Color.Gray;
                tableColumnsGrid.Rows[index].Cells[tableCellKeyForeignKeyName].Style.BackColor = Color.Gray;
                tableColumnsGrid.Rows[index].Cells[tableCellKeyIndexName].Style.BackColor = Color.Gray;
                tableColumnsGrid.Rows[index].Cells[tableCellKeyForeignKeyReferencedSchema].Style.BackColor = Color.Gray;
                tableColumnsGrid.Rows[index].Cells[tableCellKeyForeignKeyReferencedTable].Style.BackColor = Color.Gray;
                tableColumnsGrid.Rows[index].Cells[tableCellKeyForeignKeyReferencedTableColumn].Style.BackColor = Color.Gray;
            }
        }

        private Table TabToModelTable()
        {
            var columns = new HashSet<Column>();

            //Loop through each row and form column, comment, foreign key script values.
            foreach (DataGridViewRow row in tableColumnsGrid.Rows)
            {
                ConstraintForeignKey foreignKey = null;

                var hasForeignKeyConstraint = GetCellValueBool(row, tableCellKeyIsForeignKey);
                if (hasForeignKeyConstraint)
                {
                    var index = Constraint.CreateNew(
                        tableSchemaTextBox.Text,
                        GetCellValue<string>(row, tableCellKeyIndexName),
                        tableTableNameTextBox.Text,
                        GetCellValue<string>(row, tableCellKeyName),
                        null);

                    foreignKey = ConstraintForeignKey.CreateNew(
                        tableSchemaTextBox.Text,
                        GetCellValue<string>(row, tableCellKeyForeignKeyName),
                        tableTableNameTextBox.Text,
                        GetCellValue<string>(row, tableCellKeyName),
                        GetCellValue<string>(row, tableCellKeyForeignKeyReferencedSchema),
                        GetCellValue<string>(row, tableCellKeyForeignKeyReferencedTable),
                        GetCellValue<string>(row, tableCellKeyForeignKeyReferencedTableColumn),
                        index);
                }

                var hasPrimaryKey = GetCellValueBool(row, tableCellKeyIsPrimaryKey);
                Constraint primaryKey = null;
                if (hasPrimaryKey)
                {
                    primaryKey = Constraint.CreateNew(
                        tableSchemaTextBox.Text,
                        tablePKTextBox.Text,
                        tableTableNameTextBox.Text,
                        GetCellValue<string>(row, tableCellKeyName),
                        null);
                }

                var hasUniqueConstraint = GetCellValueBool(row, tableCellKeyIsUnique);
                Constraint uniqueConstraint = null;
                if (hasUniqueConstraint)
                {
                    uniqueConstraint = Constraint.CreateNew(
                        tableSchemaTextBox.Text,
                        GetCellValue<string>(row, tableCellKeyUniqueConstraintName),
                        tableTableNameTextBox.Text,
                        GetCellValue<string>(row, tableCellKeyName),
                        null);
                }

                GetCellValue<string>(row, tableCellKeyDataLength).ParseNullable(out var dataLength);
                var isNullable = GetCellValueBool(row, tableCellKeyIsNullable);

                var column = Column.CreateNew(
                    tableSchemaTextBox.Text,
                    tableTableNameTextBox.Text,
                    GetCellValue<string>(row, tableCellKeyName),
                    GetCellValue<DataType>(row, tableCellKeyType), 
                    dataLength,
                    GetCellValue<string>(row, tableCellKeyDefault),
                    isNullable,
                    GetCellValue<string>(row, tableCellKeyComment),
                    hasPrimaryKey,
                    primaryKey,
                    hasUniqueConstraint,
                    uniqueConstraint,
                    hasForeignKeyConstraint, 
                    foreignKey);

                columns.Add(column);
            }

            tabTable = Table.CreateNew(
                tableTableNameTextBox.Text, 
                tableSchemaTextBox.Text, 
                tableTableCommentTextBox.Text, 
                tableTablespaceTextBox.Text,
                columns);

            return tabTable;
        }

        // PasteInData pastes clipboard data into the grid passed to it.
        private void PasteInData(ref DataGridView dgv)
        {
            char[] rowSplitter = { '\n', '\r' };  // Cr and Lf.
            char columnSplitter = '\t';         // Tab.

            IDataObject dataInClipboard = Clipboard.GetDataObject();

            string stringInClipboard =
                dataInClipboard.GetData(DataFormats.Text).ToString();

            string[] rowsInClipboard = stringInClipboard.Split(rowSplitter,
                StringSplitOptions.RemoveEmptyEntries);

            int r = dgv.SelectedCells[0].RowIndex;
            int c = dgv.SelectedCells[0].ColumnIndex;

            if (dgv.Rows.Count < (r + rowsInClipboard.Length))
                AddNewRow(r + rowsInClipboard.Length - dgv.Rows.Count);

            // Loop through lines:

            int iRow = 0;
            while (iRow < rowsInClipboard.Length)
            {
                // Split up rows to get individual cells:

                string[] valuesInRow =
                    rowsInClipboard[iRow].Split(columnSplitter);

                // Cycle through cells.
                // Assign cell value only if within columns of grid:

                int jCol = 0;
                while (jCol < valuesInRow.Length)
                {
                    if ((dgv.ColumnCount - 1) >= (c + jCol))
                        if (dgv.Rows[r + iRow].Cells[c + jCol].ValueType == Type.GetType("System.bool"))
                            if (valuesInRow[jCol].Equals("true", StringComparison.InvariantCultureIgnoreCase))
                                dgv.Rows[r + iRow].Cells[c + jCol].Value = true;
                            else
                                dgv.Rows[r + iRow].Cells[c + jCol].Value = false;
                        else
                            dgv.Rows[r + iRow].Cells[c + jCol].Value =
                            valuesInRow[jCol];

                    jCol += 1;
                } // end while

                iRow += 1;
            } // end while
        } // PasteInData
    }
}
