namespace ScriptGenerator
{
    partial class ScriptGenerator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.scriptTextBox = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tableSchemaTextBox = new System.Windows.Forms.TextBox();
            this.tableTableNameTextBox = new System.Windows.Forms.TextBox();
            this.tableSchemaLbl = new System.Windows.Forms.Label();
            this.tableTableNameLbl = new System.Windows.Forms.Label();
            this.tableBtn = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tableTabPage = new System.Windows.Forms.TabPage();
            this.tableTableCommentTextBox = new System.Windows.Forms.TextBox();
            this.tableTableCommentLbl = new System.Windows.Forms.Label();
            this.tableRemoveBtn = new System.Windows.Forms.Button();
            this.tableAddBtn = new System.Windows.Forms.Button();
            this.tableColumnsGrid = new System.Windows.Forms.DataGridView();
            this.tableColumnsIsPK = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tableColumnsName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableColumnsType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableColumnsDefault = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableColumnsIsNullable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tableColumnsComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableColumnsIsUnique = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tableColumnsUniqueConstraintName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableColumnsIsForeignKey = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tableColumnsFKName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableColumnsIndexName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableColumnsReferencedSchema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableColumnsReferencedTable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableColumnsReferencedColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tablePKTextBox = new System.Windows.Forms.TextBox();
            this.tablePKLbl = new System.Windows.Forms.Label();
            this.tableColumnsLbl = new System.Windows.Forms.Label();
            this.columnTabPage = new System.Windows.Forms.TabPage();
            this.columnRefColumnNameTextBox = new System.Windows.Forms.TextBox();
            this.columnRefColumnNameLbl = new System.Windows.Forms.Label();
            this.columnRefTableNameTextBox = new System.Windows.Forms.TextBox();
            this.columnRefTableNameLbl = new System.Windows.Forms.Label();
            this.columnRefSchemaNameTextBox = new System.Windows.Forms.TextBox();
            this.columnRefSchemaNameLbl = new System.Windows.Forms.Label();
            this.columnIndexNameTextBox = new System.Windows.Forms.TextBox();
            this.columnIndexNameLbl = new System.Windows.Forms.Label();
            this.columnFkNameTextBox = new System.Windows.Forms.TextBox();
            this.columnFkNameLbl = new System.Windows.Forms.Label();
            this.columnIsFkLbl = new System.Windows.Forms.Label();
            this.columnIsFkCheckBox = new System.Windows.Forms.CheckBox();
            this.columnCommentTextBox = new System.Windows.Forms.TextBox();
            this.columnCommentLbl = new System.Windows.Forms.Label();
            this.columnDefaultTextBox = new System.Windows.Forms.TextBox();
            this.columnDefaultLbl = new System.Windows.Forms.Label();
            this.columnNullableLbl = new System.Windows.Forms.Label();
            this.columnIsNullableCheckBox = new System.Windows.Forms.CheckBox();
            this.columnBtn = new System.Windows.Forms.Button();
            this.columnTypeTextBox = new System.Windows.Forms.TextBox();
            this.columnTypeLbl = new System.Windows.Forms.Label();
            this.columnColumnTextBox = new System.Windows.Forms.TextBox();
            this.columnColumnLbl = new System.Windows.Forms.Label();
            this.columnsTableNameTextBox = new System.Windows.Forms.TextBox();
            this.columnsSchemaTextBox = new System.Windows.Forms.TextBox();
            this.columnsTableNameLbl = new System.Windows.Forms.Label();
            this.columnsSchemaLbl = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tableTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableColumnsGrid)).BeginInit();
            this.columnTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // scriptTextBox
            // 
            this.scriptTextBox.Location = new System.Drawing.Point(12, 392);
            this.scriptTextBox.Multiline = true;
            this.scriptTextBox.Name = "scriptTextBox";
            this.scriptTextBox.ReadOnly = true;
            this.scriptTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.scriptTextBox.Size = new System.Drawing.Size(1418, 262);
            this.scriptTextBox.TabIndex = 0;
            // 
            // tableSchemaTextBox
            // 
            this.tableSchemaTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tableSchemaTextBox.Location = new System.Drawing.Point(73, 0);
            this.tableSchemaTextBox.Name = "tableSchemaTextBox";
            this.tableSchemaTextBox.Size = new System.Drawing.Size(149, 20);
            this.tableSchemaTextBox.TabIndex = 1;
            // 
            // tableTableNameTextBox
            // 
            this.tableTableNameTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tableTableNameTextBox.Location = new System.Drawing.Point(73, 26);
            this.tableTableNameTextBox.Name = "tableTableNameTextBox";
            this.tableTableNameTextBox.Size = new System.Drawing.Size(149, 20);
            this.tableTableNameTextBox.TabIndex = 2;
            // 
            // tableSchemaLbl
            // 
            this.tableSchemaLbl.AutoSize = true;
            this.tableSchemaLbl.Location = new System.Drawing.Point(21, 3);
            this.tableSchemaLbl.Name = "tableSchemaLbl";
            this.tableSchemaLbl.Size = new System.Drawing.Size(49, 13);
            this.tableSchemaLbl.TabIndex = 4;
            this.tableSchemaLbl.Text = "Schema:";
            // 
            // tableTableNameLbl
            // 
            this.tableTableNameLbl.AutoSize = true;
            this.tableTableNameLbl.Location = new System.Drawing.Point(4, 29);
            this.tableTableNameLbl.Name = "tableTableNameLbl";
            this.tableTableNameLbl.Size = new System.Drawing.Size(66, 13);
            this.tableTableNameLbl.TabIndex = 5;
            this.tableTableNameLbl.Text = "Table name:";
            // 
            // tableBtn
            // 
            this.tableBtn.Location = new System.Drawing.Point(10, 307);
            this.tableBtn.Name = "tableBtn";
            this.tableBtn.Size = new System.Drawing.Size(75, 23);
            this.tableBtn.TabIndex = 6;
            this.tableBtn.Text = "Generate";
            this.tableBtn.UseVisualStyleBackColor = true;
            this.tableBtn.Click += new System.EventHandler(this.tableBtn_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tableTabPage);
            this.tabControl1.Controls.Add(this.columnTabPage);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1422, 374);
            this.tabControl1.TabIndex = 7;
            // 
            // tableTabPage
            // 
            this.tableTabPage.Controls.Add(this.tableTableCommentTextBox);
            this.tableTabPage.Controls.Add(this.tableTableCommentLbl);
            this.tableTabPage.Controls.Add(this.tableRemoveBtn);
            this.tableTabPage.Controls.Add(this.tableAddBtn);
            this.tableTabPage.Controls.Add(this.tableColumnsGrid);
            this.tableTabPage.Controls.Add(this.tablePKTextBox);
            this.tableTabPage.Controls.Add(this.tablePKLbl);
            this.tableTabPage.Controls.Add(this.tableColumnsLbl);
            this.tableTabPage.Controls.Add(this.tableTableNameTextBox);
            this.tableTabPage.Controls.Add(this.tableBtn);
            this.tableTabPage.Controls.Add(this.tableSchemaTextBox);
            this.tableTabPage.Controls.Add(this.tableTableNameLbl);
            this.tableTabPage.Controls.Add(this.tableSchemaLbl);
            this.tableTabPage.Location = new System.Drawing.Point(4, 22);
            this.tableTabPage.Name = "tableTabPage";
            this.tableTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.tableTabPage.Size = new System.Drawing.Size(1414, 348);
            this.tableTabPage.TabIndex = 0;
            this.tableTabPage.Text = "Table creation";
            this.tableTabPage.UseVisualStyleBackColor = true;
            // 
            // tableTableCommentTextBox
            // 
            this.tableTableCommentTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tableTableCommentTextBox.Location = new System.Drawing.Point(570, 26);
            this.tableTableCommentTextBox.Name = "tableTableCommentTextBox";
            this.tableTableCommentTextBox.Size = new System.Drawing.Size(841, 20);
            this.tableTableCommentTextBox.TabIndex = 16;
            // 
            // tableTableCommentLbl
            // 
            this.tableTableCommentLbl.AutoSize = true;
            this.tableTableCommentLbl.Location = new System.Drawing.Point(481, 29);
            this.tableTableCommentLbl.Name = "tableTableCommentLbl";
            this.tableTableCommentLbl.Size = new System.Drawing.Size(83, 13);
            this.tableTableCommentLbl.TabIndex = 17;
            this.tableTableCommentLbl.Text = "Table comment:";
            // 
            // tableRemoveBtn
            // 
            this.tableRemoveBtn.Location = new System.Drawing.Point(144, 55);
            this.tableRemoveBtn.Name = "tableRemoveBtn";
            this.tableRemoveBtn.Size = new System.Drawing.Size(107, 23);
            this.tableRemoveBtn.TabIndex = 15;
            this.tableRemoveBtn.Text = "Remove Selected";
            this.tableRemoveBtn.UseVisualStyleBackColor = true;
            this.tableRemoveBtn.Click += new System.EventHandler(this.tableRemoveBtn_Click);
            // 
            // tableAddBtn
            // 
            this.tableAddBtn.Location = new System.Drawing.Point(63, 55);
            this.tableAddBtn.Name = "tableAddBtn";
            this.tableAddBtn.Size = new System.Drawing.Size(75, 23);
            this.tableAddBtn.TabIndex = 14;
            this.tableAddBtn.Text = "Add Column";
            this.tableAddBtn.UseVisualStyleBackColor = true;
            this.tableAddBtn.Click += new System.EventHandler(this.tableAddBtn_Click);
            // 
            // tableColumnsGrid
            // 
            this.tableColumnsGrid.AllowUserToAddRows = false;
            this.tableColumnsGrid.AllowUserToDeleteRows = false;
            this.tableColumnsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableColumnsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tableColumnsIsPK,
            this.tableColumnsName,
            this.tableColumnsType,
            this.tableColumnsDefault,
            this.tableColumnsIsNullable,
            this.tableColumnsComment,
            this.tableColumnsIsUnique,
            this.tableColumnsUniqueConstraintName,
            this.tableColumnsIsForeignKey,
            this.tableColumnsFKName,
            this.tableColumnsIndexName,
            this.tableColumnsReferencedSchema,
            this.tableColumnsReferencedTable,
            this.tableColumnsReferencedColumn});
            this.tableColumnsGrid.Location = new System.Drawing.Point(10, 81);
            this.tableColumnsGrid.Name = "tableColumnsGrid";
            this.tableColumnsGrid.Size = new System.Drawing.Size(1401, 220);
            this.tableColumnsGrid.TabIndex = 13;
            this.tableColumnsGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tableColumnsGrid_CellContentClick);
            // 
            // tableColumnsIsPK
            // 
            this.tableColumnsIsPK.HeaderText = "Is Primary Key";
            this.tableColumnsIsPK.Name = "tableColumnsIsPK";
            this.tableColumnsIsPK.ReadOnly = true;
            this.tableColumnsIsPK.Width = 80;
            // 
            // tableColumnsName
            // 
            this.tableColumnsName.HeaderText = "Name";
            this.tableColumnsName.Name = "tableColumnsName";
            // 
            // tableColumnsType
            // 
            this.tableColumnsType.HeaderText = "Type";
            this.tableColumnsType.Name = "tableColumnsType";
            // 
            // tableColumnsDefault
            // 
            this.tableColumnsDefault.HeaderText = "Default";
            this.tableColumnsDefault.Name = "tableColumnsDefault";
            // 
            // tableColumnsIsNullable
            // 
            this.tableColumnsIsNullable.HeaderText = "Is Nullable";
            this.tableColumnsIsNullable.Name = "tableColumnsIsNullable";
            this.tableColumnsIsNullable.Width = 80;
            // 
            // tableColumnsComment
            // 
            this.tableColumnsComment.HeaderText = "Comment";
            this.tableColumnsComment.Name = "tableColumnsComment";
            this.tableColumnsComment.Width = 200;
            // 
            // tableColumnsIsUnique
            // 
            this.tableColumnsIsUnique.HeaderText = "Is Unique";
            this.tableColumnsIsUnique.Name = "tableColumnsIsUnique";
            this.tableColumnsIsUnique.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tableColumnsIsUnique.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tableColumnsIsUnique.Width = 80;
            // 
            // tableColumnsUniqueConstraintName
            // 
            this.tableColumnsUniqueConstraintName.HeaderText = "Unique Constraint Name";
            this.tableColumnsUniqueConstraintName.Name = "tableColumnsUniqueConstraintName";
            // 
            // tableColumnsIsForeignKey
            // 
            this.tableColumnsIsForeignKey.HeaderText = "Is Foreign Key";
            this.tableColumnsIsForeignKey.Name = "tableColumnsIsForeignKey";
            this.tableColumnsIsForeignKey.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tableColumnsIsForeignKey.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tableColumnsIsForeignKey.Width = 80;
            // 
            // tableColumnsFKName
            // 
            this.tableColumnsFKName.HeaderText = "FK name";
            this.tableColumnsFKName.Name = "tableColumnsFKName";
            // 
            // tableColumnsIndexName
            // 
            this.tableColumnsIndexName.HeaderText = "Index name";
            this.tableColumnsIndexName.Name = "tableColumnsIndexName";
            // 
            // tableColumnsReferencedSchema
            // 
            this.tableColumnsReferencedSchema.HeaderText = "Referenced Schema";
            this.tableColumnsReferencedSchema.Name = "tableColumnsReferencedSchema";
            // 
            // tableColumnsReferencedTable
            // 
            this.tableColumnsReferencedTable.HeaderText = "Referenced Table";
            this.tableColumnsReferencedTable.Name = "tableColumnsReferencedTable";
            // 
            // tableColumnsReferencedColumn
            // 
            this.tableColumnsReferencedColumn.HeaderText = "Referenced Column";
            this.tableColumnsReferencedColumn.Name = "tableColumnsReferencedColumn";
            // 
            // tablePKTextBox
            // 
            this.tablePKTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tablePKTextBox.Location = new System.Drawing.Point(330, 26);
            this.tablePKTextBox.Name = "tablePKTextBox";
            this.tablePKTextBox.Size = new System.Drawing.Size(149, 20);
            this.tablePKTextBox.TabIndex = 9;
            // 
            // tablePKLbl
            // 
            this.tablePKLbl.AutoSize = true;
            this.tablePKLbl.Location = new System.Drawing.Point(231, 29);
            this.tablePKLbl.Name = "tablePKLbl";
            this.tablePKLbl.Size = new System.Drawing.Size(93, 13);
            this.tablePKLbl.TabIndex = 10;
            this.tablePKLbl.Text = "Primary key name:";
            // 
            // tableColumnsLbl
            // 
            this.tableColumnsLbl.AutoSize = true;
            this.tableColumnsLbl.Location = new System.Drawing.Point(7, 65);
            this.tableColumnsLbl.Name = "tableColumnsLbl";
            this.tableColumnsLbl.Size = new System.Drawing.Size(50, 13);
            this.tableColumnsLbl.TabIndex = 8;
            this.tableColumnsLbl.Text = "Columns:";
            // 
            // columnTabPage
            // 
            this.columnTabPage.Controls.Add(this.columnRefColumnNameTextBox);
            this.columnTabPage.Controls.Add(this.columnRefColumnNameLbl);
            this.columnTabPage.Controls.Add(this.columnRefTableNameTextBox);
            this.columnTabPage.Controls.Add(this.columnRefTableNameLbl);
            this.columnTabPage.Controls.Add(this.columnRefSchemaNameTextBox);
            this.columnTabPage.Controls.Add(this.columnRefSchemaNameLbl);
            this.columnTabPage.Controls.Add(this.columnIndexNameTextBox);
            this.columnTabPage.Controls.Add(this.columnIndexNameLbl);
            this.columnTabPage.Controls.Add(this.columnFkNameTextBox);
            this.columnTabPage.Controls.Add(this.columnFkNameLbl);
            this.columnTabPage.Controls.Add(this.columnIsFkLbl);
            this.columnTabPage.Controls.Add(this.columnIsFkCheckBox);
            this.columnTabPage.Controls.Add(this.columnCommentTextBox);
            this.columnTabPage.Controls.Add(this.columnCommentLbl);
            this.columnTabPage.Controls.Add(this.columnDefaultTextBox);
            this.columnTabPage.Controls.Add(this.columnDefaultLbl);
            this.columnTabPage.Controls.Add(this.columnNullableLbl);
            this.columnTabPage.Controls.Add(this.columnIsNullableCheckBox);
            this.columnTabPage.Controls.Add(this.columnBtn);
            this.columnTabPage.Controls.Add(this.columnTypeTextBox);
            this.columnTabPage.Controls.Add(this.columnTypeLbl);
            this.columnTabPage.Controls.Add(this.columnColumnTextBox);
            this.columnTabPage.Controls.Add(this.columnColumnLbl);
            this.columnTabPage.Controls.Add(this.columnsTableNameTextBox);
            this.columnTabPage.Controls.Add(this.columnsSchemaTextBox);
            this.columnTabPage.Controls.Add(this.columnsTableNameLbl);
            this.columnTabPage.Controls.Add(this.columnsSchemaLbl);
            this.columnTabPage.Location = new System.Drawing.Point(4, 22);
            this.columnTabPage.Name = "columnTabPage";
            this.columnTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.columnTabPage.Size = new System.Drawing.Size(1414, 348);
            this.columnTabPage.TabIndex = 1;
            this.columnTabPage.Text = "Column creation";
            this.columnTabPage.UseVisualStyleBackColor = true;
            // 
            // columnRefColumnNameTextBox
            // 
            this.columnRefColumnNameTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.columnRefColumnNameTextBox.Location = new System.Drawing.Point(406, 133);
            this.columnRefColumnNameTextBox.Name = "columnRefColumnNameTextBox";
            this.columnRefColumnNameTextBox.Size = new System.Drawing.Size(149, 20);
            this.columnRefColumnNameTextBox.TabIndex = 31;
            // 
            // columnRefColumnNameLbl
            // 
            this.columnRefColumnNameLbl.AutoSize = true;
            this.columnRefColumnNameLbl.Location = new System.Drawing.Point(268, 136);
            this.columnRefColumnNameLbl.Name = "columnRefColumnNameLbl";
            this.columnRefColumnNameLbl.Size = new System.Drawing.Size(132, 13);
            this.columnRefColumnNameLbl.TabIndex = 32;
            this.columnRefColumnNameLbl.Text = "Referenced column name:";
            // 
            // columnRefTableNameTextBox
            // 
            this.columnRefTableNameTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.columnRefTableNameTextBox.Location = new System.Drawing.Point(406, 107);
            this.columnRefTableNameTextBox.Name = "columnRefTableNameTextBox";
            this.columnRefTableNameTextBox.Size = new System.Drawing.Size(149, 20);
            this.columnRefTableNameTextBox.TabIndex = 29;
            // 
            // columnRefTableNameLbl
            // 
            this.columnRefTableNameLbl.AutoSize = true;
            this.columnRefTableNameLbl.Location = new System.Drawing.Point(279, 110);
            this.columnRefTableNameLbl.Name = "columnRefTableNameLbl";
            this.columnRefTableNameLbl.Size = new System.Drawing.Size(121, 13);
            this.columnRefTableNameLbl.TabIndex = 30;
            this.columnRefTableNameLbl.Text = "Referenced table name:";
            // 
            // columnRefSchemaNameTextBox
            // 
            this.columnRefSchemaNameTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.columnRefSchemaNameTextBox.Location = new System.Drawing.Point(406, 81);
            this.columnRefSchemaNameTextBox.Name = "columnRefSchemaNameTextBox";
            this.columnRefSchemaNameTextBox.Size = new System.Drawing.Size(149, 20);
            this.columnRefSchemaNameTextBox.TabIndex = 27;
            // 
            // columnRefSchemaNameLbl
            // 
            this.columnRefSchemaNameLbl.AutoSize = true;
            this.columnRefSchemaNameLbl.Location = new System.Drawing.Point(265, 84);
            this.columnRefSchemaNameLbl.Name = "columnRefSchemaNameLbl";
            this.columnRefSchemaNameLbl.Size = new System.Drawing.Size(135, 13);
            this.columnRefSchemaNameLbl.TabIndex = 28;
            this.columnRefSchemaNameLbl.Text = "Referenced schema name:";
            // 
            // columnIndexNameTextBox
            // 
            this.columnIndexNameTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.columnIndexNameTextBox.Location = new System.Drawing.Point(634, 55);
            this.columnIndexNameTextBox.Name = "columnIndexNameTextBox";
            this.columnIndexNameTextBox.Size = new System.Drawing.Size(149, 20);
            this.columnIndexNameTextBox.TabIndex = 25;
            // 
            // columnIndexNameLbl
            // 
            this.columnIndexNameLbl.AutoSize = true;
            this.columnIndexNameLbl.Location = new System.Drawing.Point(563, 58);
            this.columnIndexNameLbl.Name = "columnIndexNameLbl";
            this.columnIndexNameLbl.Size = new System.Drawing.Size(65, 13);
            this.columnIndexNameLbl.TabIndex = 26;
            this.columnIndexNameLbl.Text = "Index name:";
            // 
            // columnFkNameTextBox
            // 
            this.columnFkNameTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.columnFkNameTextBox.Location = new System.Drawing.Point(406, 55);
            this.columnFkNameTextBox.Name = "columnFkNameTextBox";
            this.columnFkNameTextBox.Size = new System.Drawing.Size(149, 20);
            this.columnFkNameTextBox.TabIndex = 23;
            // 
            // columnFkNameLbl
            // 
            this.columnFkNameLbl.AutoSize = true;
            this.columnFkNameLbl.Location = new System.Drawing.Point(348, 58);
            this.columnFkNameLbl.Name = "columnFkNameLbl";
            this.columnFkNameLbl.Size = new System.Drawing.Size(52, 13);
            this.columnFkNameLbl.TabIndex = 24;
            this.columnFkNameLbl.Text = "FK name:";
            // 
            // columnIsFkLbl
            // 
            this.columnIsFkLbl.AutoSize = true;
            this.columnIsFkLbl.Location = new System.Drawing.Point(247, 58);
            this.columnIsFkLbl.Name = "columnIsFkLbl";
            this.columnIsFkLbl.Size = new System.Drawing.Size(73, 13);
            this.columnIsFkLbl.TabIndex = 22;
            this.columnIsFkLbl.Text = "Is foreign key:";
            // 
            // columnIsFkCheckBox
            // 
            this.columnIsFkCheckBox.AutoSize = true;
            this.columnIsFkCheckBox.Location = new System.Drawing.Point(326, 58);
            this.columnIsFkCheckBox.Name = "columnIsFkCheckBox";
            this.columnIsFkCheckBox.Size = new System.Drawing.Size(15, 14);
            this.columnIsFkCheckBox.TabIndex = 21;
            this.columnIsFkCheckBox.UseVisualStyleBackColor = true;
            this.columnIsFkCheckBox.CheckedChanged += new System.EventHandler(this.columnIsFkCheckBox_CheckedChanged);
            // 
            // columnCommentTextBox
            // 
            this.columnCommentTextBox.Location = new System.Drawing.Point(299, 29);
            this.columnCommentTextBox.Name = "columnCommentTextBox";
            this.columnCommentTextBox.Size = new System.Drawing.Size(440, 20);
            this.columnCommentTextBox.TabIndex = 19;
            // 
            // columnCommentLbl
            // 
            this.columnCommentLbl.AutoSize = true;
            this.columnCommentLbl.Location = new System.Drawing.Point(239, 32);
            this.columnCommentLbl.Name = "columnCommentLbl";
            this.columnCommentLbl.Size = new System.Drawing.Size(54, 13);
            this.columnCommentLbl.TabIndex = 20;
            this.columnCommentLbl.Text = "Comment:";
            // 
            // columnDefaultTextBox
            // 
            this.columnDefaultTextBox.Location = new System.Drawing.Point(590, 3);
            this.columnDefaultTextBox.Name = "columnDefaultTextBox";
            this.columnDefaultTextBox.Size = new System.Drawing.Size(149, 20);
            this.columnDefaultTextBox.TabIndex = 17;
            // 
            // columnDefaultLbl
            // 
            this.columnDefaultLbl.AutoSize = true;
            this.columnDefaultLbl.Location = new System.Drawing.Point(540, 6);
            this.columnDefaultLbl.Name = "columnDefaultLbl";
            this.columnDefaultLbl.Size = new System.Drawing.Size(44, 13);
            this.columnDefaultLbl.TabIndex = 18;
            this.columnDefaultLbl.Text = "Default:";
            // 
            // columnNullableLbl
            // 
            this.columnNullableLbl.AutoSize = true;
            this.columnNullableLbl.Location = new System.Drawing.Point(454, 6);
            this.columnNullableLbl.Name = "columnNullableLbl";
            this.columnNullableLbl.Size = new System.Drawing.Size(57, 13);
            this.columnNullableLbl.TabIndex = 16;
            this.columnNullableLbl.Text = "Is nullable:";
            // 
            // columnIsNullableCheckBox
            // 
            this.columnIsNullableCheckBox.AutoSize = true;
            this.columnIsNullableCheckBox.Checked = true;
            this.columnIsNullableCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.columnIsNullableCheckBox.Location = new System.Drawing.Point(517, 6);
            this.columnIsNullableCheckBox.Name = "columnIsNullableCheckBox";
            this.columnIsNullableCheckBox.Size = new System.Drawing.Size(15, 14);
            this.columnIsNullableCheckBox.TabIndex = 15;
            this.columnIsNullableCheckBox.UseVisualStyleBackColor = true;
            // 
            // columnBtn
            // 
            this.columnBtn.Location = new System.Drawing.Point(84, 81);
            this.columnBtn.Name = "columnBtn";
            this.columnBtn.Size = new System.Drawing.Size(75, 23);
            this.columnBtn.TabIndex = 14;
            this.columnBtn.Text = "Generate";
            this.columnBtn.UseVisualStyleBackColor = true;
            this.columnBtn.Click += new System.EventHandler(this.columnBtn_Click);
            // 
            // columnTypeTextBox
            // 
            this.columnTypeTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.columnTypeTextBox.Location = new System.Drawing.Point(299, 3);
            this.columnTypeTextBox.Name = "columnTypeTextBox";
            this.columnTypeTextBox.Size = new System.Drawing.Size(149, 20);
            this.columnTypeTextBox.TabIndex = 12;
            // 
            // columnTypeLbl
            // 
            this.columnTypeLbl.AutoSize = true;
            this.columnTypeLbl.Location = new System.Drawing.Point(259, 6);
            this.columnTypeLbl.Name = "columnTypeLbl";
            this.columnTypeLbl.Size = new System.Drawing.Size(34, 13);
            this.columnTypeLbl.TabIndex = 13;
            this.columnTypeLbl.Text = "Type:";
            // 
            // columnColumnTextBox
            // 
            this.columnColumnTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.columnColumnTextBox.Location = new System.Drawing.Point(84, 55);
            this.columnColumnTextBox.Name = "columnColumnTextBox";
            this.columnColumnTextBox.Size = new System.Drawing.Size(149, 20);
            this.columnColumnTextBox.TabIndex = 10;
            // 
            // columnColumnLbl
            // 
            this.columnColumnLbl.AutoSize = true;
            this.columnColumnLbl.Location = new System.Drawing.Point(4, 58);
            this.columnColumnLbl.Name = "columnColumnLbl";
            this.columnColumnLbl.Size = new System.Drawing.Size(74, 13);
            this.columnColumnLbl.TabIndex = 11;
            this.columnColumnLbl.Text = "Column name:";
            // 
            // columnsTableNameTextBox
            // 
            this.columnsTableNameTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.columnsTableNameTextBox.Location = new System.Drawing.Point(84, 29);
            this.columnsTableNameTextBox.Name = "columnsTableNameTextBox";
            this.columnsTableNameTextBox.Size = new System.Drawing.Size(149, 20);
            this.columnsTableNameTextBox.TabIndex = 7;
            // 
            // columnsSchemaTextBox
            // 
            this.columnsSchemaTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.columnsSchemaTextBox.Location = new System.Drawing.Point(84, 3);
            this.columnsSchemaTextBox.Name = "columnsSchemaTextBox";
            this.columnsSchemaTextBox.Size = new System.Drawing.Size(149, 20);
            this.columnsSchemaTextBox.TabIndex = 6;
            // 
            // columnsTableNameLbl
            // 
            this.columnsTableNameLbl.AutoSize = true;
            this.columnsTableNameLbl.Location = new System.Drawing.Point(12, 32);
            this.columnsTableNameLbl.Name = "columnsTableNameLbl";
            this.columnsTableNameLbl.Size = new System.Drawing.Size(66, 13);
            this.columnsTableNameLbl.TabIndex = 9;
            this.columnsTableNameLbl.Text = "Table name:";
            // 
            // columnsSchemaLbl
            // 
            this.columnsSchemaLbl.AutoSize = true;
            this.columnsSchemaLbl.Location = new System.Drawing.Point(29, 6);
            this.columnsSchemaLbl.Name = "columnsSchemaLbl";
            this.columnsSchemaLbl.Size = new System.Drawing.Size(49, 13);
            this.columnsSchemaLbl.TabIndex = 8;
            this.columnsSchemaLbl.Text = "Schema:";
            // 
            // ScriptGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1446, 666);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.scriptTextBox);
            this.Name = "ScriptGenerator";
            this.Text = "Script generator";
            this.tabControl1.ResumeLayout(false);
            this.tableTabPage.ResumeLayout(false);
            this.tableTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableColumnsGrid)).EndInit();
            this.columnTabPage.ResumeLayout(false);
            this.columnTabPage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox scriptTextBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox tableSchemaTextBox;
        private System.Windows.Forms.TextBox tableTableNameTextBox;
        private System.Windows.Forms.Label tableSchemaLbl;
        private System.Windows.Forms.Label tableTableNameLbl;
        private System.Windows.Forms.Button tableBtn;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tableTabPage;
        private System.Windows.Forms.TabPage columnTabPage;
        private System.Windows.Forms.Label tableColumnsLbl;
        private System.Windows.Forms.TextBox columnsTableNameTextBox;
        private System.Windows.Forms.TextBox columnsSchemaTextBox;
        private System.Windows.Forms.Label columnsTableNameLbl;
        private System.Windows.Forms.Label columnsSchemaLbl;
        private System.Windows.Forms.TextBox columnTypeTextBox;
        private System.Windows.Forms.Label columnTypeLbl;
        private System.Windows.Forms.TextBox columnColumnTextBox;
        private System.Windows.Forms.Label columnColumnLbl;
        private System.Windows.Forms.Button columnBtn;
        private System.Windows.Forms.Label columnNullableLbl;
        private System.Windows.Forms.CheckBox columnIsNullableCheckBox;
        private System.Windows.Forms.TextBox columnDefaultTextBox;
        private System.Windows.Forms.Label columnDefaultLbl;
        private System.Windows.Forms.TextBox tablePKTextBox;
        private System.Windows.Forms.Label tablePKLbl;
        private System.Windows.Forms.TextBox columnCommentTextBox;
        private System.Windows.Forms.Label columnCommentLbl;
        private System.Windows.Forms.DataGridView tableColumnsGrid;
        private System.Windows.Forms.Button tableRemoveBtn;
        private System.Windows.Forms.Button tableAddBtn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn tableColumnsIsPK;
        private System.Windows.Forms.DataGridViewTextBoxColumn tableColumnsName;
        private System.Windows.Forms.DataGridViewTextBoxColumn tableColumnsType;
        private System.Windows.Forms.DataGridViewTextBoxColumn tableColumnsDefault;
        private System.Windows.Forms.DataGridViewCheckBoxColumn tableColumnsIsNullable;
        private System.Windows.Forms.DataGridViewTextBoxColumn tableColumnsComment;
        private System.Windows.Forms.DataGridViewCheckBoxColumn tableColumnsIsUnique;
        private System.Windows.Forms.DataGridViewTextBoxColumn tableColumnsUniqueConstraintName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn tableColumnsIsForeignKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn tableColumnsFKName;
        private System.Windows.Forms.DataGridViewTextBoxColumn tableColumnsIndexName;
        private System.Windows.Forms.DataGridViewTextBoxColumn tableColumnsReferencedSchema;
        private System.Windows.Forms.DataGridViewTextBoxColumn tableColumnsReferencedTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn tableColumnsReferencedColumn;
        private System.Windows.Forms.TextBox tableTableCommentTextBox;
        private System.Windows.Forms.Label tableTableCommentLbl;
        private System.Windows.Forms.TextBox columnIndexNameTextBox;
        private System.Windows.Forms.Label columnIndexNameLbl;
        private System.Windows.Forms.TextBox columnFkNameTextBox;
        private System.Windows.Forms.Label columnFkNameLbl;
        private System.Windows.Forms.Label columnIsFkLbl;
        private System.Windows.Forms.CheckBox columnIsFkCheckBox;
        private System.Windows.Forms.TextBox columnRefColumnNameTextBox;
        private System.Windows.Forms.Label columnRefColumnNameLbl;
        private System.Windows.Forms.TextBox columnRefTableNameTextBox;
        private System.Windows.Forms.Label columnRefTableNameLbl;
        private System.Windows.Forms.TextBox columnRefSchemaNameTextBox;
        private System.Windows.Forms.Label columnRefSchemaNameLbl;
    }
}

