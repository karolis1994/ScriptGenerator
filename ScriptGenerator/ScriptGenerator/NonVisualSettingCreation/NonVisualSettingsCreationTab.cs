using ScriptGenerator.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScriptGenerator
{
    public partial class ScriptGenerator
    {
        private NonVisualSetting nonVisualSetting;

        //Init non visual settings creation tab default values
        private void InitializeNonVisualSettingsTab()
        {
            List<string> clients = ConfigurationManager.AppSettings["clients"].Split(',').ToList();
            foreach (string client in clients)
            {
                nonVisualClientsGrid.Columns.Add(client, client);
            }
            nonVisualClientsGrid.Columns.Add(Else, Else);
            nonVisualClientsGrid.Rows.Add();
        }

        private void ResetNonVisualSettingsTab()
        {
            nonVisualCodeTextBox.Text = string.Empty;

            nonVisualClientsGrid.Columns.Clear();
            nonVisualClientsGrid.Rows.Clear();
        }

        private void nonVisualResetBtn_Click(object sender, EventArgs e)
        {
            ResetNonVisualSettingsTab();
            InitializeNonVisualSettingsTab();
        }

        private async void nonVisualBtn_Click(Object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            nonVisualBtn.Enabled = false;

            var result = await scriptGenerationService.GenerateCreationScript(TabToModelNonVisualSetting()).ConfigureAwait(false);

            this.Invoke(new Action(() =>
            {
                scriptTextBox.Text = result;

                Cursor.Current = Cursors.Arrow;
                nonVisualBtn.Enabled = true;
            }));
        }

        private NonVisualSetting TabToModelNonVisualSetting()
        {
            nonVisualSetting = NonVisualSetting.CreateNew(nonVisualCodeTextBox.Text);

            foreach (DataGridViewColumn column in nonVisualClientsGrid.Columns)
            {
                var value = GetCellValue<string>(nonVisualClientsGrid.Rows[0], column.HeaderText);

                if (!String.IsNullOrWhiteSpace(value))
                {
                    nonVisualSetting.Clients.Add(column.HeaderText, value);
                }
            }

            return nonVisualSetting;
        }
    }
}
