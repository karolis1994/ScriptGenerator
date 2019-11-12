using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
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
        private void charConvButton_Click(object sender, EventArgs e)
        {
            if (charConvCheckedListBox.CheckedItems.Count > 0)
                    scriptTextBox.Text = ReplaceWithCharset(charConvTextBox.Text, ReadCharset(charConvCheckedListBox.CheckedItems[0].ToString()));
        }

        //char conversion checked list
        private void charConvCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //Allow only one box to be checked
            if (e.NewValue == CheckState.Checked)
                for (int ix = 0; ix < charConvCheckedListBox.Items.Count; ++ix)
                    if (e.Index != ix) charConvCheckedListBox.SetItemChecked(ix, false);
        }

        //Replaces each character from a string with an oracle chr function passing the key from the charset as parameter
        private string ReplaceWithCharset(string original, Dictionary<int, string> charset)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(original);

            foreach (KeyValuePair<int, string> pair in charset)
            {
                stringBuilder.Replace(pair.Value, $"' || chr({pair.Key}) || '");
            }

            if (charConvCheckBox.Checked)
                stringBuilder.Replace("'", $"' || chr(39) || '");

            return stringBuilder.ToString();
        }
        
        //Reads charset from a file, each row must contain a number and a symbol separated by a space
        private Dictionary<int, string> ReadCharset(string charsetName)
        {
            Dictionary<int, string> charset = new Dictionary<int, string>();
            string charsetPath = Directory.GetCurrentDirectory() + "\\Resources\\" + charsetName + ".txt";
            int key = 0;

            if (File.Exists(charsetPath))
            {
                IEnumerable<string> lines = File.ReadLines(charsetPath);
                foreach (string line in lines)
                {
                    string[] splitResult = line.Split(' ');

                    if (splitResult.Length == 2)
                        if (int.TryParse(splitResult[0], out key))
                            charset.Add(key, splitResult[1]);
                }
            }

            return charset;
        }
    }
}
