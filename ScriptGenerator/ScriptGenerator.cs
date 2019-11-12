using ScriptGenerator.Services;
using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace ScriptGenerator
{
    public partial class ScriptGenerator : Form
    {
        private IWordService wordService;
        private ICharConverterService charConverterService;
        private IVersioningService versioningService;
        private IScriptGenerationService scriptGenerationService;

        public ScriptGenerator(IWordService wordWorker, ICharConverterService charConverterService, IVersioningService versioningService, IScriptGenerationService scriptGenerationService)
        {
            this.wordService = wordWorker;
            this.charConverterService = charConverterService;
            this.versioningService = versioningService;
            this.scriptGenerationService = scriptGenerationService;

            InitializeWindow();
        }

        private void InitializeWindow()
        {
            InitializeComponent();

            //If icon exists, change the program icon
            if (File.Exists("Resources/generator_icon_01_a6a_icon.ico"))
                Icon = new Icon("Resources/generator_icon_01_a6a_icon.ico");

            //Display program version in the title
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            Text = Text + " " + version.Major + "." + version.Minor;

            InitializeNonVisualSettingLoadTab();
            InitializeCharacterConversionTab();
            InitializeNonVisualSettingsTab();
            InitializeSequenceTab();
            InitializeColumnTab();
            InitializeTableTab();
        }

        private static String Else = "Else";
    }
}
