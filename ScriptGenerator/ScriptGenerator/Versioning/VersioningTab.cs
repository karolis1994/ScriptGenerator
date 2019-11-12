using System;
using System.IO;
using System.Windows.Forms;

namespace ScriptGenerator
{
    public partial class ScriptGenerator
    {
        private void versioningDirectoryButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            FolderSelectDialog folderSelectorDialog = new FolderSelectDialog() { Title = "Select a folder", InitialDirectory = @"c:\" };
            if (folderSelectorDialog.ShowDialog(IntPtr.Zero) && !string.IsNullOrWhiteSpace(folderSelectorDialog.FileName))
            {
                scriptTextBox.Text = "Files that will be updated:" + Environment.NewLine;
                versioningDirectory.Text = folderSelectorDialog.FileName;
                scriptTextBox.Text += string.Join(Environment.NewLine, Directory.GetFiles(versioningDirectory.Text, "AssemblyInfo.cs", SearchOption.AllDirectories));
            }
            Cursor.Current = Cursors.Arrow;
        }

        private async void versioningButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            versioningButton.Enabled = false;

            var result = string.Empty;

            if (versioningUseCustomCheckBox.Checked)
                result = await versioningService.ChangeVersions(versioningDirectory.Text, versioningCustomVersionTextBox.Text).ConfigureAwait(false);
            else if (versioningIncreaseMajorCheckBox.Checked || versioningIncreaseMinorCheckBox.Checked)
                result = await versioningService.ChangeVersions(versioningDirectory.Text, versioningIncreaseMinorCheckBox.Checked, versioningIncreaseMajorCheckBox.Checked).ConfigureAwait(false);

            this.Invoke(new Action(() =>
            {
                scriptTextBox.Text = result;

                Cursor.Current = Cursors.Arrow;
                versioningButton.Enabled = true;
            }));
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
