﻿using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace ScriptGenerator
{
    public partial class ScriptGenerator : Form
    {
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
            InitializeNonVisualSettingsTabs();
            InitializeSequenceTab();
            InitializeColumnTab();
            InitializeTableTab();
        }

        private static String Else = "Else";
    }
}
