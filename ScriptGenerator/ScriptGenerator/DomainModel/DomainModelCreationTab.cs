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

        public const string domainDefaults = @"using CoreDomain;
using CoreDomain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace ";

        private void ResetDomainTab()
        {
            domainPropertiesGrid.Rows.Clear();
            domainClassNameTextBox.Text = String.Empty;
            domainNameSpaceTextBox.Text = String.Empty;
        }

        private void AddNewDomainPropertyRow(int size = 1)
        {
            for (int i = 0; i < size; i++)
            {
                domainPropertiesGrid.Rows.Add(null, null, false, false, false);
            }
        }

        private void GenerateDomainModel()
        {
            StringBuilder sb = new StringBuilder();
            //StringBuilder sbCreateNew = new StringBuilder();
            //StringBuilder sbUpdate = new StringBuilder();

            sb.Append(domainDefaults);
            sb.Append(domainNameSpaceTextBox.Text);
            sb.Append(Environment.NewLine);
            sb.Append("{");
            sb.Append(Environment.NewLine);
            sb.Append("public class ");
            sb.Append(domainClassNameTextBox.Text);
            sb.Append(" : Entity, IAggregateRoot, IAuditModified, IAuditCreated");
            sb.Append(Environment.NewLine);
            sb.Append("{");
            sb.Append(Environment.NewLine);
            foreach (DataGridViewRow row in domainPropertiesGrid.Rows)
            {
                sb.Append("public ");
                sb.Append(row.Cells["PropertyType"].Value.ToString());
                //sb.Append((bool) row.Cells["IsNullable"].Value == true ? "? " : " ");
                sb.Append(row.Cells["PropertyName"].Value.ToString());
                sb.Append(" { get; set; }");
                sb.Append(Environment.NewLine);
            }
            sb.Append("}");
            sb.Append(Environment.NewLine);
            sb.Append("}");

            scriptTextBox.Text = sb.ToString();
        }

        private void DomainAddBtn_Click(object sender, EventArgs e)
        {
            AddNewDomainPropertyRow();
        }

        private void DomainRemoveBtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in domainPropertiesGrid.SelectedRows)
            {
                domainPropertiesGrid.Rows.Remove(row);
            }
        }

        private void DomainGenerateBtn_Click(object sender, EventArgs e)
        {
            GenerateDomainModel();
        }

        private void DomainResetBtn_Click(object sender, EventArgs e)
        {
            ResetDomainTab();
        }
    }
}
