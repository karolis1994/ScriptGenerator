using System;
using System.Text;

namespace ScriptGenerator
{
    public partial class ScriptGenerator
    {
        private void seqBtn_Click(Object sender, EventArgs e)
        {
            StringBuilder scriptBuilder = new StringBuilder();

            scriptBuilder.Append($"DECLARE" + Environment.NewLine);
            scriptBuilder.Append($"  ln_exist NUMBER;" + Environment.NewLine);
            scriptBuilder.Append($"BEGIN" + Environment.NewLine);
            scriptBuilder.Append($"  SELECT COUNT(1)" + Environment.NewLine);
            scriptBuilder.Append($"    INTO ln_exist" + Environment.NewLine);
            scriptBuilder.Append($"    FROM ALL_SEQUENCES A" + Environment.NewLine);
            scriptBuilder.Append($"   WHERE A.SEQUENCE_NAME = '{seqSequenceNameTextBox.Text}'" + Environment.NewLine);
            scriptBuilder.Append($"     AND A.SEQUENCE_OWNER = '{seqSchemaTextBox.Text}';" + Environment.NewLine);
            scriptBuilder.Append($"  IF ln_exist = 0 THEN" + Environment.NewLine);
            scriptBuilder.Append($"    EXECUTE IMMEDIATE 'CREATE SEQUENCE {seqSchemaTextBox.Text}.{seqSequenceNameTextBox.Text} START WITH {seqStartWithTextBox.Text} ");
            scriptBuilder.Append($"INCREMENT BY {seqIncrementByTextBox.Text} NOCACHE';" + Environment.NewLine);
            scriptBuilder.Append($"  END IF;" + Environment.NewLine);
            scriptBuilder.Append($"END;");

            scriptTextBox.Text = scriptBuilder.ToString();
        }
    }
}
