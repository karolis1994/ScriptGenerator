using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace ScriptGenerator
{
    public partial class ScriptGenerator : Form
    {
        private void InitializeWindow()
        {
            InitializeComponent();

            if (File.Exists("Resources/generator_icon_01_a6a_icon.ico"))
                Icon = new Icon("Resources/generator_icon_01_a6a_icon.ico");

            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            Text = Text + " " + version.Major + "." + version.Minor;

            //Init table creation tab default values
            tableColumnsGrid.Rows.Add(true, "ID", "NUMBER", null, false, "Identificator", false, null, false, null, null, null, null, null);
            tableColumnsGrid.Rows[0].ReadOnly = true;
            tableColumnsGrid.Columns["tableColumnsIsPK"].DefaultCellStyle.BackColor = Color.Gray;
            tableColumnsGrid.Rows[0].DefaultCellStyle.BackColor = Color.Gray;

            //Init column creation tab default values
            columnFkNameTextBox.BackColor = Color.Gray;
            columnFkNameTextBox.ReadOnly = true;
            columnIndexNameTextBox.BackColor = Color.Gray;
            columnIndexNameTextBox.ReadOnly = true;
            columnRefSchemaNameTextBox.BackColor = Color.Gray;
            columnRefSchemaNameTextBox.ReadOnly = true;
            columnRefTableNameTextBox.BackColor = Color.Gray;
            columnRefTableNameTextBox.ReadOnly = true;
            columnRefColumnNameTextBox.BackColor = Color.Gray;
            columnRefColumnNameTextBox.ReadOnly = true;

            //Init sequence creation tab default values
            seqIncrementByTextBox.Text = "1";
            seqStartWithTextBox.Text = "1";

            //Init non visual settings creation tab default values
            List<String> clients = ConfigurationManager.AppSettings["clients"].Split(',').ToList();
            foreach (String client in clients)
            {
                nonVisualClientsGrid.Columns.Add(client, client);
                nonVisLoadCheckedListBox.Items.Add(client, false);
            }
            nonVisualClientsGrid.Columns.Add(Else, Else);
            nonVisualClientsGrid.Rows.Add();

            //Init available charsets for character conversions
            List<String> charsets = ConfigurationManager.AppSettings["charsets"].Split(',').ToList();
            foreach (String charset in charsets)
            {
                charConvCheckedListBox.Items.Add(charset);
            }
        }

        private static String Else = "Else";
    }
}
