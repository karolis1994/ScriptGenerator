using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Word;

namespace ScriptGenerator.Services
{
    public class WordService : IWordService
    {
        /// <summary>
        /// Enumeration for specific client, matches client columns in
        /// the non visual setting  definitions document
        /// </summary>
        enum Client
        {
            ErgoLt = 2,
            ErgoLv = 3,
            ErgoEe = 4,
            Pzu = 5,
            Parex = 6,
            Halyk = 7,
            Nomad = 8,
            Qala = 9,
            Ateshgax = 10
        };

        /// <summary>
        /// Takes in client name and file path of non visual settings word document.
        /// Runs through the table defining the client's non visual settings values and collects
        /// those that parse into an integer.
        /// </summary>
        /// <param name="clientName"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public Dictionary<string, int> GetClientSettings(string clientName, string filePath)
        {
            Dictionary<string, int> map = new Dictionary<string, int>();
            int settingColumn;
            int temp;

            // Open a doc file.
            Application application = new Application();
            try
            {
                settingColumn = GetColumnBySuppliedClientName(clientName);

                Document document = application.Documents.Open(filePath);
                Table nonVisualSettingsTable = document.Tables[5];

                for (int i = 2; i <= nonVisualSettingsTable.Rows.Count; i++)
                {
                    if (int.TryParse(nonVisualSettingsTable.Rows[i].Cells[settingColumn].Range.Text.Replace("\r\a", "").Trim(), out temp))
                        map[nonVisualSettingsTable.Rows[i].Cells[1].Range.Text.Replace("\r\a", "")] = temp;
                }

                // Close word.
                application.Quit();
            }
            catch
            {
                // Close word.
                application.Quit();
            }

            return map;
        }

        private int GetColumnBySuppliedClientName(string clientName)
        {
            Client clientRow;

            switch (clientName) {
                case "ERGO_LT":
                    clientRow = Client.ErgoLt;
                    break;
                case "ERGO_LV":
                    clientRow = Client.ErgoLv;
                    break;
                case "ERGO_EE":
                    clientRow = Client.ErgoEe;
                    break;
                case "PZU":
                    clientRow = Client.Pzu;
                    break;
                case "PAREX":
                    clientRow = Client.Parex;
                    break;
                case "HALYK":
                    clientRow = Client.Halyk;
                    break;
                case "NOMAD":
                    clientRow = Client.Nomad;
                    break;
                case "QALA":
                    clientRow = Client.Qala;
                    break;
                case "ATESHGAX":
                    clientRow = Client.Ateshgax;
                    break;
                default:
                    throw new NotImplementedException("No such client exists in the system.");  
            }

            return (int)clientRow;
        }
    }
}
