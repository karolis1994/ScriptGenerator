using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ScriptGenerator
{
    public partial class ScriptGenerator
    {
        private void InitializeCharacterConversionTab()
        {
            //Init available charsets for character conversions
            List<string> charsets = ConfigurationManager.AppSettings["charsets"].Split(',').ToList();
            foreach (string charset in charsets)
            {
                charConvCheckedListBox.Items.Add(charset);
            }
        }

        private void ResetCharacterConversionTab()
        {
            charConvCheckedListBox.Items.Clear();
        }

        private void charConvResetBtn_Click(object sender, EventArgs e)
        {
            ResetCharacterConversionTab();
            InitializeCharacterConversionTab();
        }

        //char conversion script generator button
        private async void charConvButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            charConvButton.Enabled = false;
            string result = string.Empty;

            if (charConvCheckedListBox.CheckedItems.Count > 0)
            {
                result = await charConverterService.ReplaceWithCharset(charConvTextBox.Text, charConvCheckBox.Checked);
            }

            this.Invoke(new Action(() =>
            {
                scriptTextBox.Text = result;

                Cursor.Current = Cursors.Arrow;
                charConvButton.Enabled = true;
            }));
        }

        //char conversion checked list
        private async void charConvCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //Allow only one box to be checked
            if (e.NewValue == CheckState.Checked)
            {
                for (int ix = 0; ix < charConvCheckedListBox.Items.Count; ++ix)
                    if (e.Index != ix)
                        charConvCheckedListBox.SetItemChecked(ix, false);

                Cursor.Current = Cursors.WaitCursor;
                charConvButton.Enabled = false;

                await charConverterService.LoadCharset(Directory.GetCurrentDirectory() + "\\Resources\\" + charConvCheckedListBox.Items[e.Index].ToString() + ".txt");

                this.Invoke(new Action(() =>
                {
                    Cursor.Current = Cursors.Arrow;
                    charConvButton.Enabled = true;
                }));
            }
        }
    }
}
