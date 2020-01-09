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

        private async void AisTemplaterBtn_Click(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;
            AisTemplaterBtn.Enabled = false;

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
                AisTemplaterBtn.Enabled = true;
            }));
        }

        private void AisTemplaterResetBtn_Click(object sender, EventArgs e)
        {
            ResetAisTemplaterTab();
        }

        private void AisTemplaterAddBtn_Click(object sender, EventArgs e)
        {
            AddNewAisVariableRow();
        }

        private void AisTemplaterRemoveBtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in AisTemplaterGrid.SelectedRows)
            {
                if (row.Index != 0)
                    AisTemplaterGrid.Rows.Remove(row);
            }
        }

        private void ResetAisTemplaterTab()
        {
            AisTemplaterAggregateRootCheckBox.Checked = false;

            AisTemplaterModelNameTextBox.Text = string.Empty;
            AisTemplaterNamespaceTextBox.Text = string.Empty;

            AisTemplaterGrid.Rows.Clear();
        }

        private void AddNewAisVariableRow(int size = 1)
        {
            for (int i = 0; i < size; i++)
            {
                AisTemplaterGrid.Rows.Add(null, null, null, null, null, false, false, false, false);
            }
        }

        private CodeModel TabToModelAisTemplater()
        {
            var variables = new HashSet<CodeModelVariable>();

            //Loop through each row and form variable script values
            foreach (DataGridViewRow row in AisTemplaterGrid.Rows)
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

            var model = CodeModel.CreateNew(AisTemplaterModelNameTextBox.Text,
                AisTemplaterNamespaceTextBox.Text,
                AisTemplaterClassSummaryTextBox.Text,
                AisTemplaterAggregateRootCheckBox.Checked,
                AisTemplaterIsUserManagedCheckBox.Checked,
                AisTemplaterIsValidityRangeCheckBox.Checked,
                variables,
                AisTemplaterContextTextBox.Text,
                AisTemplaterSubNamespaceTextBox.Text);

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
