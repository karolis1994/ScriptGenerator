using ScriptGenerator.Services;
using Services.Ais;
using System;
using System.Windows.Forms;

namespace ScriptGenerator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ScriptGenerator(new WordService(), new OracleCharConverterService(), new VersioningService(),
                    new ScriptGenerationService(), new CodeComponentsGeneratorService()));
        }
    }
}
