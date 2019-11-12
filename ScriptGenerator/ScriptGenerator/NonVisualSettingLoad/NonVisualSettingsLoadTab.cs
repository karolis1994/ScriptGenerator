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
        private void InitializeNonVisualSettingLoadTab()
        {
            //Init non visual settings creation tab default values
            List<String> clients = ConfigurationManager.AppSettings["clients"].Split(',').ToList();
            foreach (String client in clients)
            {
                nonVisLoadCheckedListBox.Items.Add(client, false);
            }
        }

        private void ResetNonVisualSettingsLoadTab()
        {
            nonVisLoadCheckedListBox.Items.Clear();
        }

        private void nonVisLoadResetBtn_Click(object sender, EventArgs e)
        {
            ResetNonVisualSettingsLoadTab();
            InitializeNonVisualSettingLoadTab();
        }

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
                stringBuilder.Append($"DECLARE{Environment.NewLine}");
                stringBuilder.Append($"  PROCEDURE update_non_visual_setting(ps_code IN VARCHAR2, ps_value IN VARCHAR2) AS{Environment.NewLine}");
                stringBuilder.Append($"    ln_exist NUMBER;{Environment.NewLine}");
                stringBuilder.Append($"  BEGIN{Environment.NewLine}");
                stringBuilder.Append($"    SELECT COUNT(1) INTO ln_exist FROM dual WHERE EXISTS (SELECT sa.value FROM SETTINGS.SYST_ATTRIBUTES_T sa WHERE sa.code = ps_code);{Environment.NewLine}");
                stringBuilder.Append($"    IF ln_exist = 1 THEN{Environment.NewLine}");
                stringBuilder.Append($"      UPDATE SETTINGS.SYST_ATTRIBUTES_T SET VALUE = ps_value WHERE CODE = ps_code;{Environment.NewLine}");
                stringBuilder.Append($"    ELSE{Environment.NewLine}");
                stringBuilder.Append($"      INSERT INTO SETTINGS.SYST_ATTRIBUTES_T (CODE, VALUE) VALUES (ps_code, ps_value);{Environment.NewLine}");
                stringBuilder.Append($"    END IF;{Environment.NewLine}");
                stringBuilder.Append($"  END;{Environment.NewLine}");
                stringBuilder.Append($"BEGIN{Environment.NewLine}");
                stringBuilder.Append(GenerateUpdateStatementForNonVisualSetting("APT_CLIENT", nonVisLoadCheckedListBox.CheckedItems[0].ToString()));

                foreach (KeyValuePair<String, Int32> entry in wordService.GetClientSettings(nonVisLoadCheckedListBox.CheckedItems[0].ToString(), nonVisualLoadPathLabel.Text))
                {
                    if (entry.Key.Length <= 30)
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
            return $"  update_non_visual_setting('{nonVisualSetting}', '{value}');{Environment.NewLine}";
        }
    }
}
