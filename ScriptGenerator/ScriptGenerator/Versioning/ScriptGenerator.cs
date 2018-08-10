using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ScriptGenerator
{
    public partial class ScriptGenerator
    {
        private void versioningDirectoryButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DialogResult result = versioningFolderBrowserDialog.ShowDialog();

            if (result == DialogResult.OK && !String.IsNullOrWhiteSpace(versioningFolderBrowserDialog.SelectedPath))
            {
                scriptTextBox.Text = "Files that will be updated:" + Environment.NewLine;
                versioningDirectory.Text = versioningFolderBrowserDialog.SelectedPath;
                scriptTextBox.Text += String.Join(Environment.NewLine, Directory.GetFiles(versioningDirectory.Text, "AssemblyInfo.cs", SearchOption.AllDirectories));
            }
            Cursor.Current = Cursors.Arrow;
        }

        private void versioningButton_Click(object sender, EventArgs e)
        {
            if (versioningIncreaseMajorCheckBox.Checked || versioningIncreaseMinorCheckBox.Checked || versioningUseCustomCheckBox.Checked)
            {
                String[] files = Directory.GetFiles(versioningDirectory.Text, "AssemblyInfo.cs", SearchOption.AllDirectories);
                Regex regex = new Regex("(?<=AssemblyVersion\\(\"|AssemblyFileVersion\\(\")\\d+.\\d+.\\d+.\\d+(?=\"\\)\\])");
                String fileText = String.Empty;
                String newVersion = String.Empty;
                String[] version = new String[4];

                foreach (String file in files)
                {
                    fileText = File.ReadAllText(file);
                    if (versioningUseCustomCheckBox.Checked)
                        newVersion = versioningCustomVersionTextBox.Text;
                    else
                    {
                        Match match = regex.Match(fileText);

                        if (match.Success)
                        {
                            version = match.Value.Split('.');

                            if (versioningIncreaseMajorCheckBox.Checked)
                            {
                                version[0] = (Int32.Parse(version[0]) + 1).ToString();
                            }
                            if (versioningIncreaseMinorCheckBox.Checked)
                            {
                                version[1] = (Int32.Parse(version[1]) + 1).ToString();
                            }

                            newVersion = String.Join(".", version);
                        }
                    }
                    fileText = regex.Replace(fileText, newVersion);
                    File.WriteAllText(file, fileText);
                }
            }
        }

        private void versioningUseCustomCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (versioningUseCustomCheckBox.Checked)
            {
                versioningIncreaseMajorCheckBox.Enabled = false;
                versioningIncreaseMinorCheckBox.Enabled = false;
            }
            else
            {
                versioningIncreaseMajorCheckBox.Enabled = true;
                versioningIncreaseMinorCheckBox.Enabled = true;
            }
        }

        private void versioningIncreaseMinorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (versioningIncreaseMinorCheckBox.Checked)
            {
                versioningUseCustomCheckBox.Enabled = false;
                versioningCustomVersionTextBox.Enabled = false;
            }
            else if (!versioningIncreaseMinorCheckBox.Checked && !versioningIncreaseMajorCheckBox.Checked)
            {
                versioningUseCustomCheckBox.Enabled = true;
                versioningCustomVersionTextBox.Enabled = true;
            }
        }

        private void versioningIncreaseMajorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (versioningIncreaseMajorCheckBox.Checked)
            {
                versioningUseCustomCheckBox.Enabled = false;
                versioningCustomVersionTextBox.Enabled = false;
            }
            else if (!versioningIncreaseMinorCheckBox.Checked && !versioningIncreaseMajorCheckBox.Checked)
            {
                versioningUseCustomCheckBox.Enabled = true;
                versioningCustomVersionTextBox.Enabled = true;
            }
        }
    }
}
