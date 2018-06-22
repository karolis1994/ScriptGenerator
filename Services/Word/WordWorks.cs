using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Word;

namespace Services
{
    public class WordWorks : IWordWorks
    {
        /*
         * Enumeration detailing the column index for each client
         */
        public enum Client
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

        public Dictionary<String, Int32> GetClientSettings(String clientName, String filePath)
        {
            Dictionary<String, Int32> map = new Dictionary<String, Int32>();
            Int32 settingColumn;
            Int32 temp;

            // Open a doc file.
            Application application = new Application();
            try
            {
                settingColumn = GetColumnBySuppliedClientName(clientName);

                Document document = application.Documents.Open(filePath);
                Table nonVisualSettingsTable = document.Tables[5];

                for (Int32 i = 2; i <= nonVisualSettingsTable.Rows.Count; i++)
                {
                    if (Int32.TryParse(nonVisualSettingsTable.Rows[i].Cells[settingColumn].Range.Text.Replace("\r\a", "").Trim(), out temp))
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

        private Int32 GetColumnBySuppliedClientName(String clientName)
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

            return (Int32)clientRow;
        }
    }
}
