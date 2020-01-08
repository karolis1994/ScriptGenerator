using ScriptGenerator.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScriptGenerator
{
    public partial class ScriptGenerator
    {
        private CodeModel aisModel;

        private const string templaterVariableAccessLevel = "AisVariableAccessLevel";
        private const string templaterVariableName = "AisVariableName";
        private const string templaterAisVariableType = "AisVariableType";
        private const string templaterAisVariableComment = "AisVariableComment";
        private const string templaterAisVariableStringLength = "AisVariableStringLength";
        private const string templaterAisVariableIsRequired = "AisVariableIsRequired";
        private const string templaterAisVariableIsPartOfUpdate = "AisVariableIsPartOfUpdate";
        private const string templaterAisVariableIsPartOfCreateNew = "AisVariableIsPartOfCreateNew";
        private const string templaterAisVariableIsMultilanguage = "AisVariableIsMultilanguage";

        private async void aisTemplaterBtn_Click(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;
            aisTemplaterBtn.Enabled = false;

            TabToModelAisTemplater();

            await WriteAisComponentToFile(await aisComponentsGeneratorService.GenerateDomainModel(aisModel), "\\Domain\\Models");
            await WriteAisComponentToFile(await aisComponentsGeneratorService.GenerateRepositoryInterface(aisModel), "\\Domain\\Models");
            await WriteAisComponentToFile(await aisComponentsGeneratorService.GenerateEntityTypeConfiguration(aisModel), "\\Infrastructure\\EntityConfigurations");
            await WriteAisComponentToFile(await aisComponentsGeneratorService.GenerateRepository(aisModel), "\\Infrastructure\\Repositories");
            await WriteAisComponentToFile(await aisComponentsGeneratorService.GenerateAPIModel(aisModel), "\\Application\\Models");
            await WriteAisComponentToFile(await aisComponentsGeneratorService.GenerateCommand(aisModel, CommandType.Create), "\\Application\\Commands");
            await WriteAisComponentToFile(await aisComponentsGeneratorService.GenerateCommand(aisModel, CommandType.Change), "\\Application\\Commands");
            await WriteAisComponentToFile(await aisComponentsGeneratorService.GenerateCommand(aisModel, CommandType.Delete), "\\Application\\Commands");
            await WriteAisComponentToFile(await aisComponentsGeneratorService.GenerateCommandHandler(aisModel, CommandType.Create), "\\Application\\Commands");
            await WriteAisComponentToFile(await aisComponentsGeneratorService.GenerateCommandHandler(aisModel, CommandType.Change), "\\Application\\Commands");
            await WriteAisComponentToFile(await aisComponentsGeneratorService.GenerateCommandHandler(aisModel, CommandType.Delete), "\\Application\\Commands");

            this.Invoke(new Action(() =>
            {
                Cursor.Current = Cursors.Arrow;
                aisTemplaterBtn.Enabled = true;
            }));
        }

        private void aisTemplaterResetBtn_Click(object sender, EventArgs e)
        {
            ResetAisTemplaterTab();
        }

        private void aisTemplaterAddBtn_Click(object sender, EventArgs e)
        {
            AddNewAisVariableRow();
        }

        private void aisTemplaterRemoveBtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in aisTemplaterGrid.SelectedRows)
            {
                if (row.Index != 0)
                    aisTemplaterGrid.Rows.Remove(row);
            }
        }

        private void ResetAisTemplaterTab()
        {
            aisTemplaterAggregateRootCheckBox.Checked = false;

            aisTemplaterModelNameTextBox.Text = string.Empty;
            aisTemplaterNamespaceTextBox.Text = string.Empty;

            aisTemplaterGrid.Rows.Clear();
        }

        private void AddNewAisVariableRow(int size = 1)
        {
            for (int i = 0; i < size; i++)
            {
                aisTemplaterGrid.Rows.Add(null, null, null, null, null, false, false, false, false);
            }
        }

        private CodeModel TabToModelAisTemplater()
        {
            var variables = new HashSet<CodeModelVariable>();

            //Loop through each row and form variable script values
            foreach (DataGridViewRow row in aisTemplaterGrid.Rows)
            {
                variables.Add(
                    CodeModelVariable.CreateNew(
                        GetCellValue<string>(row, templaterVariableAccessLevel),
                        GetCellValue<string>(row, templaterVariableName),
                        GetCellValue<string>(row, templaterAisVariableType),
                        GetCellValue<string>(row, templaterAisVariableComment),
                        GetCellValue<int?>(row, templaterAisVariableStringLength),
                        GetCellValueBool(row, templaterAisVariableIsRequired),
                        GetCellValueBool(row, templaterAisVariableIsPartOfUpdate),
                        GetCellValueBool(row, templaterAisVariableIsPartOfCreateNew),
                        GetCellValueBool(row, templaterAisVariableIsMultilanguage)
                    ));
            }

            var model = CodeModel.CreateNew(aisTemplaterModelNameTextBox.Text,
                aisTemplaterNamespaceTextBox.Text,
                aisTemplaterClassSummaryTextBox.Text,
                aisTemplaterAggregateRootCheckBox.Checked,
                aisTemplaterIsUserManagedCheckBox.Checked,
                aisTemplaterIsValidityRangeCheckBox.Checked,
                variables,
                aisTemplaterContextTextBox.Text,
                aisTemplaterSubNamespaceTextBox.Text);

            aisModel = model;

            return model;
        }

        private async Task WriteAisComponentToFile(CodeComponentFile component, string relativePath)
        {
            await Task.Run(() =>
            {
                var fullPath = Directory.GetCurrentDirectory() + relativePath;

                if (Directory.Exists(Directory.GetCurrentDirectory() + relativePath))
                    Directory.CreateDirectory(fullPath);

                File.WriteAllText(fullPath + "\\" + component.FileName, component.ComponentCodeText);
            });
        }
    }
}
