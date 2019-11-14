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
        //Init non visual settings creation tab default values
        private void InitializeNonVisualSettingsTab()
        {
            List<String> clients = ConfigurationManager.AppSettings["clients"].Split(',').ToList();
            foreach (String client in clients)
            {
                nonVisualClientsGrid.Columns.Add(client, client);
            }
            nonVisualClientsGrid.Columns.Add(Else, Else);
            nonVisualClientsGrid.Rows.Add();
        }

        private void ResetNonVisualSettingsTab()
        {
            nonVisualCodeTextBox.Text = String.Empty;

            nonVisualClientsGrid.Columns.Clear();
            nonVisualClientsGrid.Rows.Clear();
        }

        private void nonVisualResetBtn_Click(object sender, EventArgs e)
        {
            ResetNonVisualSettingsTab();
            InitializeNonVisualSettingsTab();
        }

        private void nonVisualBtn_Click(Object sender, EventArgs e)
        {
            StringBuilder insertsBuilder = new StringBuilder();
            StringBuilder scriptBuilder = new StringBuilder();
            Int32 index = 0;

            foreach (DataGridViewColumn column in nonVisualClientsGrid.Columns)
            {
                if (!String.IsNullOrWhiteSpace(GetCellValue<string>(nonVisualClientsGrid.Rows[0], column.HeaderText)))
                {
                    if (column.HeaderText != Else)
                    {
                        if (index == 0)
                            insertsBuilder.Append($"    IF ls_client = '{column.HeaderText}' THEN{Environment.NewLine}");
                        else
                            insertsBuilder.Append($"    ELSIF ls_client = '{column.HeaderText}' THEN{Environment.NewLine}");
                    }
                    else
                    {
                        insertsBuilder.Append($"    ELSE{Environment.NewLine}");
                    }

                    insertsBuilder.Append($"      {GenerateNonVisualSettingScript(nonVisualCodeTextBox.Text, GetCellValue<string>(nonVisualClientsGrid.Rows[0], column.HeaderText))}{Environment.NewLine}");

                    index++;
                }
            }
            insertsBuilder.Append($"    END IF;{Environment.NewLine}");

            scriptBuilder.Append($"DECLARE{Environment.NewLine}");
            scriptBuilder.Append($"  ln_exist NUMBER;{Environment.NewLine}");
            scriptBuilder.Append($"  ls_client VARCHAR2(250);{Environment.NewLine}");
            scriptBuilder.Append($"  PROCEDURE insert_non_visual(ps_name  IN VARCHAR2, ps_value IN VARCHAR2) AS{Environment.NewLine}");
            scriptBuilder.Append($"  BEGIN{Environment.NewLine}");
            scriptBuilder.Append($"    INSERT INTO SETTINGS.SYST_ATTRIBUTES_T(CODE, VALUE) VALUES(ps_name, ps_value);{Environment.NewLine}");
            scriptBuilder.Append($"  END; {Environment.NewLine}");
            scriptBuilder.Append($"BEGIN{Environment.NewLine}");
            scriptBuilder.Append($"  SELECT COUNT(1) INTO ln_exist FROM SETTINGS.SYST_ATTRIBUTES_T WHERE CODE = '{nonVisualCodeTextBox.Text}';{Environment.NewLine}");
            scriptBuilder.Append($"  ls_client := SETTINGS.GET_SYST_ATTR('APT_CLIENT');{Environment.NewLine}");
            scriptBuilder.Append($"  IF ln_exist = 0 THEN{Environment.NewLine}");
            scriptBuilder.Append($"{insertsBuilder.ToString()}");
            scriptBuilder.Append($"  END IF;{Environment.NewLine}");
            scriptBuilder.Append($"END;{Environment.NewLine}");
            scriptBuilder.Append($"/");

            scriptTextBox.Text = scriptBuilder.ToString();
        }

        private String GenerateNonVisualSettingScript(String code, String value)
        {
            return $"insert_non_visual('{code}', '{value}');";
        }
    }
}
