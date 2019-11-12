using ScriptGenerator.Models;
using System;
using System.Windows.Forms;

namespace ScriptGenerator
{
    public partial class ScriptGenerator
    {
        /// <summary>
        /// The last generated model for sequence
        /// </summary>
        private Sequence tabSequence;

        //Init sequence creation tab default values
        private void InitializeSequenceTab()
        {
            seqIncrementByTextBox.Text = "1";
            seqStartWithTextBox.Text = "1";
        }

        private void ResetSequenceTab()
        {
            seqSequenceNameTextBox.Text = String.Empty;
            seqIncrementByTextBox.Text = String.Empty;
            seqStartWithTextBox.Text = String.Empty;
            seqSchemaTextBox.Text = String.Empty;
        }

        private void seqResetBtn_Click(object sender, EventArgs e)
        {
            ResetSequenceTab();
            InitializeSequenceTab();
        }

        private async void seqBtn_Click(Object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            seqBtn.Enabled = false;

            var result = await scriptGenerationService.GenerateCreationScript(TabToModelSequence()).ConfigureAwait(false);

            this.Invoke(new Action(() =>
            {
                scriptTextBox.Text = result;

                Cursor.Current = Cursors.Arrow;
                seqBtn.Enabled = true;
            }));
        }

        private Sequence TabToModelSequence()
        {
            int.TryParse(seqStartWithTextBox.Text, out var startWith);
            int.TryParse(seqIncrementByTextBox.Text, out var incrementBy);

            tabSequence = Sequence.CreateNew(seqSequenceNameTextBox.Text, seqSchemaTextBox.Text, startWith, incrementBy);

            return tabSequence;
        }
    }
}
