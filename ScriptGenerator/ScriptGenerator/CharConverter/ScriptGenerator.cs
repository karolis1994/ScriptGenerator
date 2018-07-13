using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ScriptGenerator
{
    public partial class ScriptGenerator
    {
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
        private String ReplaceWithCharset(String original, Dictionary<Int32, String> charset)
        {
            String result = original;

            foreach (KeyValuePair<Int32, String> pair in charset)
            {
                result = result.Replace(pair.Value, $"' || chr({pair.Key}) || '");
            }

            return result;
        }
        
        //Reads charset from a file, each row must contain a number and a symbol separated by a space
        private Dictionary<Int32, String> ReadCharset(String charsetName)
        {
            Dictionary<Int32, String> charset = new Dictionary<Int32, String>();
            String charsetPath = Directory.GetCurrentDirectory() + "\\Resources\\" + charsetName + ".txt";
            Int32 key = 0;

            if (File.Exists(charsetPath))
            {
                IEnumerable<String> lines = File.ReadLines(charsetPath);
                foreach (String line in lines)
                {
                    String[] splitResult = line.Split(' ');

                    if (splitResult.Length == 2)
                        if (Int32.TryParse(splitResult[0], out key))
                            charset.Add(key, splitResult[1]);
                }
            }

            return charset;
        }
    }
}
