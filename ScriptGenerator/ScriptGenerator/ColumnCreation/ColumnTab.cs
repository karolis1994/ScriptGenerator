using ScriptGenerator.Models;
using ScriptGenerator.Extensions;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScriptGenerator
{
    public partial class ScriptGenerator
    {
        private Column tabColumn;

        /// <summary>
        /// Set default values of column tab
        /// </summary>
        private void InitializeColumnTab()
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

            this.columnTypeComboBox.DataSource = DataTypeDropDown.GetAllDropDownOptions();
            this.columnTypeComboBox.DisplayMember = "Value";
            this.columnTypeComboBox.ValueMember = "Key";

            this.columnTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary>
        /// Reset column tab
        /// </summary>
        private void ResetColumnTab()
        {
            columnRefColumnNameTextBox.Text = string.Empty;
            columnRefSchemaNameTextBox.Text = string.Empty;
            columnRefTableNameTextBox.Text = string.Empty;
            columnsTableNameTextBox.Text = string.Empty;
            columnIndexNameTextBox.Text = string.Empty;
            columnsSchemaTextBox.Text = string.Empty;
            columnCommentTextBox.Text = string.Empty;
            columnDefaultTextBox.Text = string.Empty;
            columnColumnTextBox.Text = string.Empty;
            columnFkNameTextBox.Text = string.Empty;
            columnTypeComboBox.SelectedIndex = 0;
            columnDataLengthTextBox.Text = string.Empty;

            columnIsNullableCheckBox.Checked = true;
            columnIsFkCheckBox.Checked = false;
        }

        private void columnResetBtn_Click(object sender, EventArgs e)
        {
            ResetColumnTab();
            InitializeColumnTab();
        }

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
        private async void columnBtn_Click(Object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            columnBtn.Enabled = false;

            var result = await scriptGenerationService.GenerateCreationScript(TabToModelColumn()).ConfigureAwait(false);

            this.Invoke(new Action(() =>
            {
                scriptTextBox.Text = result;

                Cursor.Current = Cursors.Arrow;
                columnBtn.Enabled = true;
            }));
        }

        private Column TabToModelColumn()
        {
            columnDataLengthTextBox.Text.ParseNullable(out var dataLength);

            ConstraintForeignKey foreignKey = null;
            if (columnIsFkCheckBox.Checked)
            {
                var index = Constraint.CreateNew(columnsSchemaTextBox.Text, columnIndexNameTextBox.Text, columnsTableNameTextBox.Text, columnColumnTextBox.Text);

                foreignKey = ConstraintForeignKey.CreateNew(columnsSchemaTextBox.Text, columnFkNameTextBox.Text, columnsTableNameTextBox.Text,
                    columnColumnTextBox.Text, columnRefSchemaNameTextBox.Text, columnRefTableNameTextBox.Text, columnRefColumnNameTextBox.Text, index);
            }

            tabColumn = Column.CreateNew(columnsSchemaTextBox.Text, columnsTableNameTextBox.Text, columnColumnTextBox.Text,
                (DataType)columnTypeComboBox.SelectedValue, dataLength, columnDefaultTextBox.Text, columnIsNullableCheckBox.Checked,
                columnCommentTextBox.Text, false, null, false, null, columnIsFkCheckBox.Checked, foreignKey);

            return tabColumn;
        }
    }
}
