using ScriptGenerator.Models;
using System;
using System.Windows.Forms;

namespace ScriptGenerator
{
    public partial class ScriptGenerator
    {
        private Trigger trigger;

        private void ResetAuditTriggerTab()
        {
            auditTriggerNameTextBox.Text = String.Empty;
            auditTableNameTextBox.Text = String.Empty;
            auditSchemaTextBox.Text = String.Empty;
        }

        private void auditResetBtn_Click(object sender, EventArgs e)
        {
            ResetAuditTriggerTab();
        }

        private async void auditBtn_Click(Object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            auditBtn.Enabled = false;
            string result = string.Empty;

            result = await scriptGenerationService.GenerateCreationScript(TabToModelTrigger()).ConfigureAwait(false);

            this.Invoke(new Action(() =>
            {
                scriptTextBox.Text = result;

                Cursor.Current = Cursors.Arrow;
                auditBtn.Enabled = true;
            }));
        }

        private Trigger TabToModelTrigger()
        {
            trigger = Trigger.CreateNew(
                auditSchemaTextBox.Text,
                auditTriggerNameTextBox.Text,
                auditTableNameTextBox.Text);

            return trigger;
        }
    }
}
