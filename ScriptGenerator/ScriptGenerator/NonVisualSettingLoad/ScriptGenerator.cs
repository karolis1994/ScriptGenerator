using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ScriptGenerator
{
    public partial class ScriptGenerator
    {
        //Non visual setting loading events
        private void NonVisLoadCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //Allow only one box to be checked
            if (e.NewValue == CheckState.Checked)
                for (int ix = 0; ix < nonVisLoadCheckedListBox.Items.Count; ++ix)
                    if (e.Index != ix) nonVisLoadCheckedListBox.SetItemChecked(ix, false);
        }

        //non visual setting script generator button
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

        //non visual settings file load button
        private void nonVisualLoadFileButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (nonVisualLoadFileDialog.ShowDialog() == DialogResult.OK)
                nonVisualLoadPathLabel.Text = nonVisualLoadFileDialog.FileName;
            else
                nonVisualLoadPathLabel.Text = String.Empty;

            Cursor.Current = Cursors.Arrow;
        }

        private String GenerateUpdateStatementForNonVisualSetting(String nonVisualSetting, String value)
        {
            return $"  UPDATE SETTINGS.SYST_ATTRIBUTES_T SET VALUE = '{value}' WHERE CODE = '{nonVisualSetting}';{Environment.NewLine}";
        }
    }
}
