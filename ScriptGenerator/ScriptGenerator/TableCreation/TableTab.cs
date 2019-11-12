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

        //Init table creation tab default values
        private void InitializeTableTab()
        {
            tableColumnsGrid.Rows.Add(true, "ID", "NUMBER", null, null, false, "Identificator", false, null, false, null, null, null, null, null);
            tableColumnsGrid.Rows[0].ReadOnly = true;
            tableColumnsGrid.Columns["tableColumnsIsPK"].DefaultCellStyle.BackColor = Color.Gray;
            tableColumnsGrid.Rows[0].DefaultCellStyle.BackColor = Color.Gray;
        }

        private void ResetTableTab()
        {
            tableTableCommentTextBox.Text = String.Empty;
            tableTablespaceTextBox.Text = String.Empty;
            tableTableNameTextBox.Text = String.Empty;
            tableSchemaTextBox.Text = String.Empty;
            tablePKTextBox.Text = String.Empty;

            tableColumnsGrid.Rows.Clear();
        }

        private void tableResetBtn_Click(object sender, EventArgs e)
        {
            ResetTableTab();
            InitializeTableTab();
        }

        private void tableColumnsGrid_CellContentClick(Object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7 || e.ColumnIndex == 9)
                tableColumnsGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);

            if (e.ColumnIndex == 7)
            {
                if ((Boolean)tableColumnsGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)
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

            if (e.ColumnIndex == 8)
            {
                if ((Boolean)tableColumnsGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)
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
            AddNewRow();
        }
        private async void tableBtn_Click(Object sender, EventArgs e)
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

        private Boolean GetCellValueBoolean(DataGridViewRow row, String cell)
        {
            return (Boolean?)row.Cells[cell].Value ?? false;
        }
        private String GetCellValueString(DataGridViewRow row, String cell)
        {
            return (String)row.Cells[cell].Value;
        }
        private void AddUneditableRow(String columnName, String type, String comment)
        {
            Int32 index = tableColumnsGrid.Rows.Add(false, columnName, type, null, null, true, comment, false, null, false, null, null, null, null, null);
            tableColumnsGrid.Rows[index].ReadOnly = true;
            tableColumnsGrid.Rows[index].DefaultCellStyle.BackColor = Color.Gray;
        }
        private void AddNewRow(Int32 size = 1)
        {
            for (Int32 i = 0; i < size; i++)
            {
                Int32 index = tableColumnsGrid.Rows.Add(false, null, null, null, null, true, null, false, null, false, null, null, null, null, null);
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
        }

        private Table TabToModelTable()
        {
            var columns = new HashSet<Column>();

            //Loop through each row and form column, comment, foreign key script values.
            foreach (DataGridViewRow row in tableColumnsGrid.Rows)
            {
                columnDataLengthTextBox.Text.ParseNullable(out var dataLength);

                ConstraintForeignKey foreignKey = null;

                if (columnIsFkCheckBox.Checked)
                {
                    var index = Constraint.CreateNew(tableSchemaTextBox.Text, row.Cells[], tableTableNameTextBox.Text, columnColumnTextBox.Text);

                    foreignKey = ConstraintForeignKey.CreateNew(columnsSchemaTextBox.Text, columnFkNameTextBox.Text, columnsTableNameTextBox.Text,
                        columnColumnTextBox.Text, columnRefSchemaNameTextBox.Text, columnRefTableNameTextBox.Text, columnRefColumnNameTextBox.Text, index);
                }

                var column = Column.CreateNew(columnsSchemaTextBox.Text, columnsTableNameTextBox.Text, columnColumnTextBox.Text,
                    (DataType)columnTypeComboBox.SelectedValue, dataLength, columnDefaultTextBox.Text, columnIsNullableCheckBox.Checked,
                    columnCommentTextBox.Text, false, null, false, null, columnIsFkCheckBox.Checked, foreignKey);

                columns.Add(column);
            }

            var table = Table.CreateNew(tableTableNameTextBox.Text, tableSchemaTextBox.Text, tableTableCommentTextBox.Text, tableTablespaceTextBox.Text,
                );
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
                        if (dgv.Rows[r + iRow].Cells[c + jCol].ValueType == Type.GetType("System.Boolean"))
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
