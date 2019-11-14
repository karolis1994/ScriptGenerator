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
            this.tableSchemaTextBox = new System.Windows.Forms.TextBox();
            this.tableTableNameTextBox = new System.Windows.Forms.TextBox();
            this.tableSchemaLbl = new System.Windows.Forms.Label();
            this.tableTableNameLbl = new System.Windows.Forms.Label();
            this.tableBtn = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tableTabPage = new System.Windows.Forms.TabPage();
            this.tableResetBtn = new System.Windows.Forms.Button();
            this.tableTablespaceTextBox = new System.Windows.Forms.TextBox();
            this.tableTablespaceLbl = new System.Windows.Forms.Label();
            this.tableAuditBtn = new System.Windows.Forms.Button();
            this.tableTableCommentTextBox = new System.Windows.Forms.TextBox();
            this.tableTableCommentLbl = new System.Windows.Forms.Label();
            this.tableRemoveBtn = new System.Windows.Forms.Button();
            this.tableAddBtn = new System.Windows.Forms.Button();
            this.tableColumnsGrid = new System.Windows.Forms.DataGridView();
            this.tableColumnsIsPK = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tableColumnsName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableColumnsType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tableColumnsDataLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.columnTypeComboBox = new System.Windows.Forms.ComboBox();
            this.columnDataLengthTextBox = new System.Windows.Forms.TextBox();
            this.columnDataLengthLbl = new System.Windows.Forms.Label();
            this.columnResetBtn = new System.Windows.Forms.Button();
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
            this.columnTypeLbl = new System.Windows.Forms.Label();
            this.columnColumnTextBox = new System.Windows.Forms.TextBox();
            this.columnColumnLbl = new System.Windows.Forms.Label();
            this.columnsTableNameTextBox = new System.Windows.Forms.TextBox();
            this.columnsSchemaTextBox = new System.Windows.Forms.TextBox();
            this.columnsTableNameLbl = new System.Windows.Forms.Label();
            this.columnsSchemaLbl = new System.Windows.Forms.Label();
            this.auditTabPage = new System.Windows.Forms.TabPage();
            this.auditResetBtn = new System.Windows.Forms.Button();
            this.auditTriggerNameTextBox = new System.Windows.Forms.TextBox();
            this.auditTriggerNameLbl = new System.Windows.Forms.Label();
            this.auditBtn = new System.Windows.Forms.Button();
            this.auditTableNameTextBox = new System.Windows.Forms.TextBox();
            this.auditSchemaTextBox = new System.Windows.Forms.TextBox();
            this.auditTableNameLbl = new System.Windows.Forms.Label();
            this.auditSchemaLbl = new System.Windows.Forms.Label();
            this.SequenceTabPage = new System.Windows.Forms.TabPage();
            this.seqResetBtn = new System.Windows.Forms.Button();
            this.seqBtn = new System.Windows.Forms.Button();
            this.seqIncrementByTextBox = new System.Windows.Forms.TextBox();
            this.seqStartWithTextBox = new System.Windows.Forms.TextBox();
            this.seqIncrementByLbl = new System.Windows.Forms.Label();
            this.seqStartWithLbl = new System.Windows.Forms.Label();
            this.seqSequenceNameTextBox = new System.Windows.Forms.TextBox();
            this.seqSchemaTextBox = new System.Windows.Forms.TextBox();
            this.seqSequenceNameLbl = new System.Windows.Forms.Label();
            this.seqSchemaLbl = new System.Windows.Forms.Label();
            this.nonVisualSettingTabPage = new System.Windows.Forms.TabPage();
            this.nonVisualResetBtn = new System.Windows.Forms.Button();
            this.nonVisualClientsGrid = new System.Windows.Forms.DataGridView();
            this.nonVisualClientsLbl = new System.Windows.Forms.Label();
            this.nonVisualBtn = new System.Windows.Forms.Button();
            this.nonVisualCodeTextBox = new System.Windows.Forms.TextBox();
            this.nonVisualCodeLbl = new System.Windows.Forms.Label();
            this.NonVisLoad = new System.Windows.Forms.TabPage();
            this.nonVisLoadResetBtn = new System.Windows.Forms.Button();
            this.nonVisualLoadPathLabel = new System.Windows.Forms.Label();
            this.nonVisualLoadLabel = new System.Windows.Forms.Label();
            this.nonVisualLoadFileButton = new System.Windows.Forms.Button();
            this.nonVisLoadButton = new System.Windows.Forms.Button();
            this.nonVisLoadCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.charConverterTabPage = new System.Windows.Forms.TabPage();
            this.charConvResetBtn = new System.Windows.Forms.Button();
            this.charConvCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.charConvCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.charConvButton = new System.Windows.Forms.Button();
            this.charConvLabel = new System.Windows.Forms.Label();
            this.charConvTextBox = new System.Windows.Forms.TextBox();
            this.versioning = new System.Windows.Forms.TabPage();
            this.versioningDirectory = new System.Windows.Forms.Label();
            this.versioningButton = new System.Windows.Forms.Button();
            this.versioningCustomVersionTextBox = new System.Windows.Forms.TextBox();
            this.versioningCustomVersionLabel = new System.Windows.Forms.Label();
            this.versioningUseCustomLabel = new System.Windows.Forms.Label();
            this.versioningUseCustomCheckBox = new System.Windows.Forms.CheckBox();
            this.versioningIncreaseMinorLabel = new System.Windows.Forms.Label();
            this.versioningIncreaseMinorCheckBox = new System.Windows.Forms.CheckBox();
            this.versioningIncreaseMajorLabel = new System.Windows.Forms.Label();
            this.versioningIncreaseMajorCheckBox = new System.Windows.Forms.CheckBox();
            this.versioningFilePathLabel = new System.Windows.Forms.Label();
            this.versioningDirectoryButton = new System.Windows.Forms.Button();
            this.domainModels = new System.Windows.Forms.TabPage();
            this.domainNameSpaceTextBox = new System.Windows.Forms.TextBox();
            this.domainNamespaceLbl = new System.Windows.Forms.Label();
            this.domainRemoveBtn = new System.Windows.Forms.Button();
            this.domainAddBtn = new System.Windows.Forms.Button();
            this.domainResetBtn = new System.Windows.Forms.Button();
            this.domainGenerateBtn = new System.Windows.Forms.Button();
            this.domainClassNameTextBox = new System.Windows.Forms.TextBox();
            this.domainClassName = new System.Windows.Forms.Label();
            this.domainPropertiesGrid = new System.Windows.Forms.DataGridView();
            this.PropertyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PropertyType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsNullable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsUsedInCreation = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsUsedInUpdating = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nonVisualLoadFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.versioningFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.tabControl1.SuspendLayout();
            this.tableTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableColumnsGrid)).BeginInit();
            this.columnTabPage.SuspendLayout();
            this.auditTabPage.SuspendLayout();
            this.SequenceTabPage.SuspendLayout();
            this.nonVisualSettingTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nonVisualClientsGrid)).BeginInit();
            this.NonVisLoad.SuspendLayout();
            this.charConverterTabPage.SuspendLayout();
            this.versioning.SuspendLayout();
            this.domainModels.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.domainPropertiesGrid)).BeginInit();
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
            this.tableSchemaTextBox.MaxLength = 30;
            this.tableSchemaTextBox.Name = "tableSchemaTextBox";
            this.tableSchemaTextBox.Size = new System.Drawing.Size(149, 20);
            this.tableSchemaTextBox.TabIndex = 1;
            // 
            // tableTableNameTextBox
            // 
            this.tableTableNameTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tableTableNameTextBox.Location = new System.Drawing.Point(73, 26);
            this.tableTableNameTextBox.MaxLength = 30;
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
            this.tableSchemaLbl.TabIndex = 12;
            this.tableSchemaLbl.Text = "Schema:";
            // 
            // tableTableNameLbl
            // 
            this.tableTableNameLbl.AutoSize = true;
            this.tableTableNameLbl.Location = new System.Drawing.Point(4, 29);
            this.tableTableNameLbl.Name = "tableTableNameLbl";
            this.tableTableNameLbl.Size = new System.Drawing.Size(66, 13);
            this.tableTableNameLbl.TabIndex = 13;
            this.tableTableNameLbl.Text = "Table name:";
            // 
            // tableBtn
            // 
            this.tableBtn.Location = new System.Drawing.Point(10, 307);
            this.tableBtn.Name = "tableBtn";
            this.tableBtn.Size = new System.Drawing.Size(75, 23);
            this.tableBtn.TabIndex = 9;
            this.tableBtn.Text = "Generate";
            this.tableBtn.UseVisualStyleBackColor = true;
            this.tableBtn.Click += new System.EventHandler(this.tableBtn_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tableTabPage);
            this.tabControl1.Controls.Add(this.columnTabPage);
            this.tabControl1.Controls.Add(this.auditTabPage);
            this.tabControl1.Controls.Add(this.SequenceTabPage);
            this.tabControl1.Controls.Add(this.nonVisualSettingTabPage);
            this.tabControl1.Controls.Add(this.NonVisLoad);
            this.tabControl1.Controls.Add(this.charConverterTabPage);
            this.tabControl1.Controls.Add(this.versioning);
            this.tabControl1.Controls.Add(this.domainModels);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1422, 374);
            this.tabControl1.TabIndex = 7;
            // 
            // tableTabPage
            // 
            this.tableTabPage.Controls.Add(this.tableResetBtn);
            this.tableTabPage.Controls.Add(this.tableTablespaceTextBox);
            this.tableTabPage.Controls.Add(this.tableTablespaceLbl);
            this.tableTabPage.Controls.Add(this.tableAuditBtn);
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
            // tableResetBtn
            // 
            this.tableResetBtn.Location = new System.Drawing.Point(91, 307);
            this.tableResetBtn.Name = "tableResetBtn";
            this.tableResetBtn.Size = new System.Drawing.Size(75, 23);
            this.tableResetBtn.TabIndex = 10;
            this.tableResetBtn.Text = "Reset tab";
            this.tableResetBtn.UseVisualStyleBackColor = true;
            this.tableResetBtn.Click += new System.EventHandler(this.tableResetBtn_Click);
            // 
            // tableTablespaceTextBox
            // 
            this.tableTablespaceTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tableTablespaceTextBox.Location = new System.Drawing.Point(330, 3);
            this.tableTablespaceTextBox.MaxLength = 30;
            this.tableTablespaceTextBox.Name = "tableTablespaceTextBox";
            this.tableTablespaceTextBox.Size = new System.Drawing.Size(149, 20);
            this.tableTablespaceTextBox.TabIndex = 3;
            // 
            // tableTablespaceLbl
            // 
            this.tableTablespaceLbl.AutoSize = true;
            this.tableTablespaceLbl.Location = new System.Drawing.Point(258, 7);
            this.tableTablespaceLbl.Name = "tableTablespaceLbl";
            this.tableTablespaceLbl.Size = new System.Drawing.Size(66, 13);
            this.tableTablespaceLbl.TabIndex = 14;
            this.tableTablespaceLbl.Text = "Tablespace:";
            // 
            // tableAuditBtn
            // 
            this.tableAuditBtn.Location = new System.Drawing.Point(257, 55);
            this.tableAuditBtn.Name = "tableAuditBtn";
            this.tableAuditBtn.Size = new System.Drawing.Size(107, 23);
            this.tableAuditBtn.TabIndex = 8;
            this.tableAuditBtn.Text = "Add Audit Columns";
            this.tableAuditBtn.UseVisualStyleBackColor = true;
            this.tableAuditBtn.Click += new System.EventHandler(this.tableAuditBtn_Click);
            // 
            // tableTableCommentTextBox
            // 
            this.tableTableCommentTextBox.Location = new System.Drawing.Point(570, 26);
            this.tableTableCommentTextBox.Name = "tableTableCommentTextBox";
            this.tableTableCommentTextBox.Size = new System.Drawing.Size(841, 20);
            this.tableTableCommentTextBox.TabIndex = 5;
            // 
            // tableTableCommentLbl
            // 
            this.tableTableCommentLbl.AutoSize = true;
            this.tableTableCommentLbl.Location = new System.Drawing.Point(481, 29);
            this.tableTableCommentLbl.Name = "tableTableCommentLbl";
            this.tableTableCommentLbl.Size = new System.Drawing.Size(83, 13);
            this.tableTableCommentLbl.TabIndex = 16;
            this.tableTableCommentLbl.Text = "Table comment:";
            // 
            // tableRemoveBtn
            // 
            this.tableRemoveBtn.Location = new System.Drawing.Point(144, 55);
            this.tableRemoveBtn.Name = "tableRemoveBtn";
            this.tableRemoveBtn.Size = new System.Drawing.Size(107, 23);
            this.tableRemoveBtn.TabIndex = 7;
            this.tableRemoveBtn.Text = "Remove Selected";
            this.tableRemoveBtn.UseVisualStyleBackColor = true;
            this.tableRemoveBtn.Click += new System.EventHandler(this.tableRemoveBtn_Click);
            // 
            // tableAddBtn
            // 
            this.tableAddBtn.Location = new System.Drawing.Point(63, 55);
            this.tableAddBtn.Name = "tableAddBtn";
            this.tableAddBtn.Size = new System.Drawing.Size(75, 23);
            this.tableAddBtn.TabIndex = 6;
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
            this.tableColumnsDataLength,
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
            this.tableColumnsGrid.TabIndex = 11;
            this.tableColumnsGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tableColumnsGrid_CellContentClick);
            this.tableColumnsGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tableColumnsGrid_KeyDown);
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
            this.tableColumnsName.MaxInputLength = 30;
            this.tableColumnsName.Name = "tableColumnsName";
            // 
            // tableColumnsType
            // 
            this.tableColumnsType.HeaderText = "Type";
            this.tableColumnsType.Name = "tableColumnsType";
            this.tableColumnsType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tableColumnsType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // tableColumnsDataLength
            // 
            this.tableColumnsDataLength.HeaderText = "Data length";
            this.tableColumnsDataLength.Name = "tableColumnsDataLength";
            this.tableColumnsDataLength.Resizable = System.Windows.Forms.DataGridViewTriState.True;
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
            this.tableColumnsUniqueConstraintName.MaxInputLength = 30;
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
            this.tableColumnsFKName.MaxInputLength = 30;
            this.tableColumnsFKName.Name = "tableColumnsFKName";
            // 
            // tableColumnsIndexName
            // 
            this.tableColumnsIndexName.HeaderText = "Index name";
            this.tableColumnsIndexName.MaxInputLength = 30;
            this.tableColumnsIndexName.Name = "tableColumnsIndexName";
            // 
            // tableColumnsReferencedSchema
            // 
            this.tableColumnsReferencedSchema.HeaderText = "Referenced Schema";
            this.tableColumnsReferencedSchema.MaxInputLength = 30;
            this.tableColumnsReferencedSchema.Name = "tableColumnsReferencedSchema";
            // 
            // tableColumnsReferencedTable
            // 
            this.tableColumnsReferencedTable.HeaderText = "Referenced Table";
            this.tableColumnsReferencedTable.MaxInputLength = 30;
            this.tableColumnsReferencedTable.Name = "tableColumnsReferencedTable";
            // 
            // tableColumnsReferencedColumn
            // 
            this.tableColumnsReferencedColumn.HeaderText = "Referenced Column";
            this.tableColumnsReferencedColumn.MaxInputLength = 30;
            this.tableColumnsReferencedColumn.Name = "tableColumnsReferencedColumn";
            // 
            // tablePKTextBox
            // 
            this.tablePKTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tablePKTextBox.Location = new System.Drawing.Point(330, 26);
            this.tablePKTextBox.MaxLength = 30;
            this.tablePKTextBox.Name = "tablePKTextBox";
            this.tablePKTextBox.Size = new System.Drawing.Size(149, 20);
            this.tablePKTextBox.TabIndex = 4;
            // 
            // tablePKLbl
            // 
            this.tablePKLbl.AutoSize = true;
            this.tablePKLbl.Location = new System.Drawing.Point(231, 29);
            this.tablePKLbl.Name = "tablePKLbl";
            this.tablePKLbl.Size = new System.Drawing.Size(93, 13);
            this.tablePKLbl.TabIndex = 15;
            this.tablePKLbl.Text = "Primary key name:";
            // 
            // tableColumnsLbl
            // 
            this.tableColumnsLbl.AutoSize = true;
            this.tableColumnsLbl.Location = new System.Drawing.Point(7, 65);
            this.tableColumnsLbl.Name = "tableColumnsLbl";
            this.tableColumnsLbl.Size = new System.Drawing.Size(50, 13);
            this.tableColumnsLbl.TabIndex = 17;
            this.tableColumnsLbl.Text = "Columns:";
            // 
            // columnTabPage
            // 
            this.columnTabPage.Controls.Add(this.columnTypeComboBox);
            this.columnTabPage.Controls.Add(this.columnDataLengthTextBox);
            this.columnTabPage.Controls.Add(this.columnDataLengthLbl);
            this.columnTabPage.Controls.Add(this.columnResetBtn);
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
            // columnTypeComboBox
            // 
            this.columnTypeComboBox.FormattingEnabled = true;
            this.columnTypeComboBox.Location = new System.Drawing.Point(326, 3);
            this.columnTypeComboBox.Name = "columnTypeComboBox";
            this.columnTypeComboBox.Size = new System.Drawing.Size(149, 21);
            this.columnTypeComboBox.TabIndex = 4;
            // 
            // columnDataLengthTextBox
            // 
            this.columnDataLengthTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.columnDataLengthTextBox.Location = new System.Drawing.Point(326, 29);
            this.columnDataLengthTextBox.Name = "columnDataLengthTextBox";
            this.columnDataLengthTextBox.Size = new System.Drawing.Size(149, 20);
            this.columnDataLengthTextBox.TabIndex = 7;
            // 
            // columnDataLengthLbl
            // 
            this.columnDataLengthLbl.AutoSize = true;
            this.columnDataLengthLbl.Location = new System.Drawing.Point(255, 32);
            this.columnDataLengthLbl.Name = "columnDataLengthLbl";
            this.columnDataLengthLbl.Size = new System.Drawing.Size(65, 13);
            this.columnDataLengthLbl.TabIndex = 20;
            this.columnDataLengthLbl.Text = "Data length:";
            // 
            // columnResetBtn
            // 
            this.columnResetBtn.Location = new System.Drawing.Point(84, 110);
            this.columnResetBtn.Name = "columnResetBtn";
            this.columnResetBtn.Size = new System.Drawing.Size(75, 23);
            this.columnResetBtn.TabIndex = 16;
            this.columnResetBtn.Text = "Reset tab";
            this.columnResetBtn.UseVisualStyleBackColor = true;
            this.columnResetBtn.Click += new System.EventHandler(this.columnResetBtn_Click);
            // 
            // columnRefColumnNameTextBox
            // 
            this.columnRefColumnNameTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.columnRefColumnNameTextBox.Location = new System.Drawing.Point(406, 162);
            this.columnRefColumnNameTextBox.MaxLength = 30;
            this.columnRefColumnNameTextBox.Name = "columnRefColumnNameTextBox";
            this.columnRefColumnNameTextBox.Size = new System.Drawing.Size(149, 20);
            this.columnRefColumnNameTextBox.TabIndex = 14;
            // 
            // columnRefColumnNameLbl
            // 
            this.columnRefColumnNameLbl.AutoSize = true;
            this.columnRefColumnNameLbl.Location = new System.Drawing.Point(268, 165);
            this.columnRefColumnNameLbl.Name = "columnRefColumnNameLbl";
            this.columnRefColumnNameLbl.Size = new System.Drawing.Size(132, 13);
            this.columnRefColumnNameLbl.TabIndex = 32;
            this.columnRefColumnNameLbl.Text = "Referenced column name:";
            // 
            // columnRefTableNameTextBox
            // 
            this.columnRefTableNameTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.columnRefTableNameTextBox.Location = new System.Drawing.Point(406, 136);
            this.columnRefTableNameTextBox.MaxLength = 30;
            this.columnRefTableNameTextBox.Name = "columnRefTableNameTextBox";
            this.columnRefTableNameTextBox.Size = new System.Drawing.Size(149, 20);
            this.columnRefTableNameTextBox.TabIndex = 13;
            // 
            // columnRefTableNameLbl
            // 
            this.columnRefTableNameLbl.AutoSize = true;
            this.columnRefTableNameLbl.Location = new System.Drawing.Point(279, 139);
            this.columnRefTableNameLbl.Name = "columnRefTableNameLbl";
            this.columnRefTableNameLbl.Size = new System.Drawing.Size(121, 13);
            this.columnRefTableNameLbl.TabIndex = 30;
            this.columnRefTableNameLbl.Text = "Referenced table name:";
            // 
            // columnRefSchemaNameTextBox
            // 
            this.columnRefSchemaNameTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.columnRefSchemaNameTextBox.Location = new System.Drawing.Point(406, 110);
            this.columnRefSchemaNameTextBox.MaxLength = 30;
            this.columnRefSchemaNameTextBox.Name = "columnRefSchemaNameTextBox";
            this.columnRefSchemaNameTextBox.Size = new System.Drawing.Size(149, 20);
            this.columnRefSchemaNameTextBox.TabIndex = 12;
            // 
            // columnRefSchemaNameLbl
            // 
            this.columnRefSchemaNameLbl.AutoSize = true;
            this.columnRefSchemaNameLbl.Location = new System.Drawing.Point(265, 113);
            this.columnRefSchemaNameLbl.Name = "columnRefSchemaNameLbl";
            this.columnRefSchemaNameLbl.Size = new System.Drawing.Size(135, 13);
            this.columnRefSchemaNameLbl.TabIndex = 28;
            this.columnRefSchemaNameLbl.Text = "Referenced schema name:";
            // 
            // columnIndexNameTextBox
            // 
            this.columnIndexNameTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.columnIndexNameTextBox.Location = new System.Drawing.Point(634, 84);
            this.columnIndexNameTextBox.MaxLength = 30;
            this.columnIndexNameTextBox.Name = "columnIndexNameTextBox";
            this.columnIndexNameTextBox.Size = new System.Drawing.Size(149, 20);
            this.columnIndexNameTextBox.TabIndex = 11;
            // 
            // columnIndexNameLbl
            // 
            this.columnIndexNameLbl.AutoSize = true;
            this.columnIndexNameLbl.Location = new System.Drawing.Point(563, 87);
            this.columnIndexNameLbl.Name = "columnIndexNameLbl";
            this.columnIndexNameLbl.Size = new System.Drawing.Size(65, 13);
            this.columnIndexNameLbl.TabIndex = 26;
            this.columnIndexNameLbl.Text = "Index name:";
            // 
            // columnFkNameTextBox
            // 
            this.columnFkNameTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.columnFkNameTextBox.Location = new System.Drawing.Point(406, 84);
            this.columnFkNameTextBox.MaxLength = 30;
            this.columnFkNameTextBox.Name = "columnFkNameTextBox";
            this.columnFkNameTextBox.Size = new System.Drawing.Size(149, 20);
            this.columnFkNameTextBox.TabIndex = 10;
            // 
            // columnFkNameLbl
            // 
            this.columnFkNameLbl.AutoSize = true;
            this.columnFkNameLbl.Location = new System.Drawing.Point(348, 87);
            this.columnFkNameLbl.Name = "columnFkNameLbl";
            this.columnFkNameLbl.Size = new System.Drawing.Size(52, 13);
            this.columnFkNameLbl.TabIndex = 25;
            this.columnFkNameLbl.Text = "FK name:";
            // 
            // columnIsFkLbl
            // 
            this.columnIsFkLbl.AutoSize = true;
            this.columnIsFkLbl.Location = new System.Drawing.Point(247, 87);
            this.columnIsFkLbl.Name = "columnIsFkLbl";
            this.columnIsFkLbl.Size = new System.Drawing.Size(73, 13);
            this.columnIsFkLbl.TabIndex = 24;
            this.columnIsFkLbl.Text = "Is foreign key:";
            // 
            // columnIsFkCheckBox
            // 
            this.columnIsFkCheckBox.AutoSize = true;
            this.columnIsFkCheckBox.Location = new System.Drawing.Point(326, 87);
            this.columnIsFkCheckBox.Name = "columnIsFkCheckBox";
            this.columnIsFkCheckBox.Size = new System.Drawing.Size(15, 14);
            this.columnIsFkCheckBox.TabIndex = 9;
            this.columnIsFkCheckBox.UseVisualStyleBackColor = true;
            this.columnIsFkCheckBox.CheckedChanged += new System.EventHandler(this.columnIsFkCheckBox_CheckedChanged);
            // 
            // columnCommentTextBox
            // 
            this.columnCommentTextBox.Location = new System.Drawing.Point(299, 58);
            this.columnCommentTextBox.Name = "columnCommentTextBox";
            this.columnCommentTextBox.Size = new System.Drawing.Size(440, 20);
            this.columnCommentTextBox.TabIndex = 8;
            // 
            // columnCommentLbl
            // 
            this.columnCommentLbl.AutoSize = true;
            this.columnCommentLbl.Location = new System.Drawing.Point(239, 61);
            this.columnCommentLbl.Name = "columnCommentLbl";
            this.columnCommentLbl.Size = new System.Drawing.Size(54, 13);
            this.columnCommentLbl.TabIndex = 21;
            this.columnCommentLbl.Text = "Comment:";
            // 
            // columnDefaultTextBox
            // 
            this.columnDefaultTextBox.Location = new System.Drawing.Point(617, 3);
            this.columnDefaultTextBox.Name = "columnDefaultTextBox";
            this.columnDefaultTextBox.Size = new System.Drawing.Size(149, 20);
            this.columnDefaultTextBox.TabIndex = 6;
            // 
            // columnDefaultLbl
            // 
            this.columnDefaultLbl.AutoSize = true;
            this.columnDefaultLbl.Location = new System.Drawing.Point(567, 6);
            this.columnDefaultLbl.Name = "columnDefaultLbl";
            this.columnDefaultLbl.Size = new System.Drawing.Size(44, 13);
            this.columnDefaultLbl.TabIndex = 23;
            this.columnDefaultLbl.Text = "Default:";
            // 
            // columnNullableLbl
            // 
            this.columnNullableLbl.AutoSize = true;
            this.columnNullableLbl.Location = new System.Drawing.Point(481, 6);
            this.columnNullableLbl.Name = "columnNullableLbl";
            this.columnNullableLbl.Size = new System.Drawing.Size(57, 13);
            this.columnNullableLbl.TabIndex = 22;
            this.columnNullableLbl.Text = "Is nullable:";
            // 
            // columnIsNullableCheckBox
            // 
            this.columnIsNullableCheckBox.AutoSize = true;
            this.columnIsNullableCheckBox.Checked = true;
            this.columnIsNullableCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.columnIsNullableCheckBox.Location = new System.Drawing.Point(544, 6);
            this.columnIsNullableCheckBox.Name = "columnIsNullableCheckBox";
            this.columnIsNullableCheckBox.Size = new System.Drawing.Size(15, 14);
            this.columnIsNullableCheckBox.TabIndex = 5;
            this.columnIsNullableCheckBox.UseVisualStyleBackColor = true;
            // 
            // columnBtn
            // 
            this.columnBtn.Location = new System.Drawing.Point(84, 81);
            this.columnBtn.Name = "columnBtn";
            this.columnBtn.Size = new System.Drawing.Size(75, 23);
            this.columnBtn.TabIndex = 15;
            this.columnBtn.Text = "Generate";
            this.columnBtn.UseVisualStyleBackColor = true;
            this.columnBtn.Click += new System.EventHandler(this.columnBtn_Click);
            // 
            // columnTypeLbl
            // 
            this.columnTypeLbl.AutoSize = true;
            this.columnTypeLbl.Location = new System.Drawing.Point(286, 6);
            this.columnTypeLbl.Name = "columnTypeLbl";
            this.columnTypeLbl.Size = new System.Drawing.Size(34, 13);
            this.columnTypeLbl.TabIndex = 19;
            this.columnTypeLbl.Text = "Type:";
            // 
            // columnColumnTextBox
            // 
            this.columnColumnTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.columnColumnTextBox.Location = new System.Drawing.Point(84, 55);
            this.columnColumnTextBox.MaxLength = 30;
            this.columnColumnTextBox.Name = "columnColumnTextBox";
            this.columnColumnTextBox.Size = new System.Drawing.Size(149, 20);
            this.columnColumnTextBox.TabIndex = 3;
            // 
            // columnColumnLbl
            // 
            this.columnColumnLbl.AutoSize = true;
            this.columnColumnLbl.Location = new System.Drawing.Point(4, 58);
            this.columnColumnLbl.Name = "columnColumnLbl";
            this.columnColumnLbl.Size = new System.Drawing.Size(74, 13);
            this.columnColumnLbl.TabIndex = 18;
            this.columnColumnLbl.Text = "Column name:";
            // 
            // columnsTableNameTextBox
            // 
            this.columnsTableNameTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.columnsTableNameTextBox.Location = new System.Drawing.Point(84, 29);
            this.columnsTableNameTextBox.MaxLength = 30;
            this.columnsTableNameTextBox.Name = "columnsTableNameTextBox";
            this.columnsTableNameTextBox.Size = new System.Drawing.Size(149, 20);
            this.columnsTableNameTextBox.TabIndex = 2;
            // 
            // columnsSchemaTextBox
            // 
            this.columnsSchemaTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.columnsSchemaTextBox.Location = new System.Drawing.Point(84, 3);
            this.columnsSchemaTextBox.MaxLength = 30;
            this.columnsSchemaTextBox.Name = "columnsSchemaTextBox";
            this.columnsSchemaTextBox.Size = new System.Drawing.Size(149, 20);
            this.columnsSchemaTextBox.TabIndex = 1;
            // 
            // columnsTableNameLbl
            // 
            this.columnsTableNameLbl.AutoSize = true;
            this.columnsTableNameLbl.Location = new System.Drawing.Point(12, 32);
            this.columnsTableNameLbl.Name = "columnsTableNameLbl";
            this.columnsTableNameLbl.Size = new System.Drawing.Size(66, 13);
            this.columnsTableNameLbl.TabIndex = 17;
            this.columnsTableNameLbl.Text = "Table name:";
            // 
            // columnsSchemaLbl
            // 
            this.columnsSchemaLbl.AutoSize = true;
            this.columnsSchemaLbl.Location = new System.Drawing.Point(29, 6);
            this.columnsSchemaLbl.Name = "columnsSchemaLbl";
            this.columnsSchemaLbl.Size = new System.Drawing.Size(49, 13);
            this.columnsSchemaLbl.TabIndex = 16;
            this.columnsSchemaLbl.Text = "Schema:";
            // 
            // auditTabPage
            // 
            this.auditTabPage.Controls.Add(this.auditResetBtn);
            this.auditTabPage.Controls.Add(this.auditTriggerNameTextBox);
            this.auditTabPage.Controls.Add(this.auditTriggerNameLbl);
            this.auditTabPage.Controls.Add(this.auditBtn);
            this.auditTabPage.Controls.Add(this.auditTableNameTextBox);
            this.auditTabPage.Controls.Add(this.auditSchemaTextBox);
            this.auditTabPage.Controls.Add(this.auditTableNameLbl);
            this.auditTabPage.Controls.Add(this.auditSchemaLbl);
            this.auditTabPage.Location = new System.Drawing.Point(4, 22);
            this.auditTabPage.Name = "auditTabPage";
            this.auditTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.auditTabPage.Size = new System.Drawing.Size(1414, 348);
            this.auditTabPage.TabIndex = 2;
            this.auditTabPage.Text = "Audit trigger creation";
            this.auditTabPage.UseVisualStyleBackColor = true;
            // 
            // auditResetBtn
            // 
            this.auditResetBtn.Location = new System.Drawing.Point(77, 113);
            this.auditResetBtn.Name = "auditResetBtn";
            this.auditResetBtn.Size = new System.Drawing.Size(75, 23);
            this.auditResetBtn.TabIndex = 5;
            this.auditResetBtn.Text = "Reset tab";
            this.auditResetBtn.UseVisualStyleBackColor = true;
            this.auditResetBtn.Click += new System.EventHandler(this.auditResetBtn_Click);
            // 
            // auditTriggerNameTextBox
            // 
            this.auditTriggerNameTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.auditTriggerNameTextBox.Location = new System.Drawing.Point(77, 58);
            this.auditTriggerNameTextBox.MaxLength = 30;
            this.auditTriggerNameTextBox.Name = "auditTriggerNameTextBox";
            this.auditTriggerNameTextBox.Size = new System.Drawing.Size(149, 20);
            this.auditTriggerNameTextBox.TabIndex = 3;
            // 
            // auditTriggerNameLbl
            // 
            this.auditTriggerNameLbl.AutoSize = true;
            this.auditTriggerNameLbl.Location = new System.Drawing.Point(-1, 61);
            this.auditTriggerNameLbl.Name = "auditTriggerNameLbl";
            this.auditTriggerNameLbl.Size = new System.Drawing.Size(72, 13);
            this.auditTriggerNameLbl.TabIndex = 8;
            this.auditTriggerNameLbl.Text = "Trigger name:";
            // 
            // auditBtn
            // 
            this.auditBtn.Location = new System.Drawing.Point(77, 84);
            this.auditBtn.Name = "auditBtn";
            this.auditBtn.Size = new System.Drawing.Size(75, 23);
            this.auditBtn.TabIndex = 4;
            this.auditBtn.Text = "Generate";
            this.auditBtn.UseVisualStyleBackColor = true;
            this.auditBtn.Click += new System.EventHandler(this.auditBtn_Click);
            // 
            // auditTableNameTextBox
            // 
            this.auditTableNameTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.auditTableNameTextBox.Location = new System.Drawing.Point(77, 32);
            this.auditTableNameTextBox.MaxLength = 30;
            this.auditTableNameTextBox.Name = "auditTableNameTextBox";
            this.auditTableNameTextBox.Size = new System.Drawing.Size(149, 20);
            this.auditTableNameTextBox.TabIndex = 2;
            // 
            // auditSchemaTextBox
            // 
            this.auditSchemaTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.auditSchemaTextBox.Location = new System.Drawing.Point(77, 6);
            this.auditSchemaTextBox.MaxLength = 30;
            this.auditSchemaTextBox.Name = "auditSchemaTextBox";
            this.auditSchemaTextBox.Size = new System.Drawing.Size(149, 20);
            this.auditSchemaTextBox.TabIndex = 1;
            // 
            // auditTableNameLbl
            // 
            this.auditTableNameLbl.AutoSize = true;
            this.auditTableNameLbl.Location = new System.Drawing.Point(5, 35);
            this.auditTableNameLbl.Name = "auditTableNameLbl";
            this.auditTableNameLbl.Size = new System.Drawing.Size(66, 13);
            this.auditTableNameLbl.TabIndex = 7;
            this.auditTableNameLbl.Text = "Table name:";
            // 
            // auditSchemaLbl
            // 
            this.auditSchemaLbl.AutoSize = true;
            this.auditSchemaLbl.Location = new System.Drawing.Point(22, 9);
            this.auditSchemaLbl.Name = "auditSchemaLbl";
            this.auditSchemaLbl.Size = new System.Drawing.Size(49, 13);
            this.auditSchemaLbl.TabIndex = 6;
            this.auditSchemaLbl.Text = "Schema:";
            // 
            // SequenceTabPage
            // 
            this.SequenceTabPage.Controls.Add(this.seqResetBtn);
            this.SequenceTabPage.Controls.Add(this.seqBtn);
            this.SequenceTabPage.Controls.Add(this.seqIncrementByTextBox);
            this.SequenceTabPage.Controls.Add(this.seqStartWithTextBox);
            this.SequenceTabPage.Controls.Add(this.seqIncrementByLbl);
            this.SequenceTabPage.Controls.Add(this.seqStartWithLbl);
            this.SequenceTabPage.Controls.Add(this.seqSequenceNameTextBox);
            this.SequenceTabPage.Controls.Add(this.seqSchemaTextBox);
            this.SequenceTabPage.Controls.Add(this.seqSequenceNameLbl);
            this.SequenceTabPage.Controls.Add(this.seqSchemaLbl);
            this.SequenceTabPage.Location = new System.Drawing.Point(4, 22);
            this.SequenceTabPage.Name = "SequenceTabPage";
            this.SequenceTabPage.Size = new System.Drawing.Size(1414, 348);
            this.SequenceTabPage.TabIndex = 3;
            this.SequenceTabPage.Text = "Sequence creation";
            this.SequenceTabPage.UseVisualStyleBackColor = true;
            // 
            // seqResetBtn
            // 
            this.seqResetBtn.Location = new System.Drawing.Point(98, 84);
            this.seqResetBtn.Name = "seqResetBtn";
            this.seqResetBtn.Size = new System.Drawing.Size(75, 23);
            this.seqResetBtn.TabIndex = 6;
            this.seqResetBtn.Text = "Reset tab";
            this.seqResetBtn.UseVisualStyleBackColor = true;
            this.seqResetBtn.Click += new System.EventHandler(this.seqResetBtn_Click);
            // 
            // seqBtn
            // 
            this.seqBtn.Location = new System.Drawing.Point(98, 55);
            this.seqBtn.Name = "seqBtn";
            this.seqBtn.Size = new System.Drawing.Size(75, 23);
            this.seqBtn.TabIndex = 5;
            this.seqBtn.Text = "Generate";
            this.seqBtn.UseVisualStyleBackColor = true;
            this.seqBtn.Click += new System.EventHandler(this.seqBtn_Click);
            // 
            // seqIncrementByTextBox
            // 
            this.seqIncrementByTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.seqIncrementByTextBox.Location = new System.Drawing.Point(332, 29);
            this.seqIncrementByTextBox.Name = "seqIncrementByTextBox";
            this.seqIncrementByTextBox.Size = new System.Drawing.Size(149, 20);
            this.seqIncrementByTextBox.TabIndex = 4;
            // 
            // seqStartWithTextBox
            // 
            this.seqStartWithTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.seqStartWithTextBox.Location = new System.Drawing.Point(332, 3);
            this.seqStartWithTextBox.Name = "seqStartWithTextBox";
            this.seqStartWithTextBox.Size = new System.Drawing.Size(149, 20);
            this.seqStartWithTextBox.TabIndex = 3;
            // 
            // seqIncrementByLbl
            // 
            this.seqIncrementByLbl.AutoSize = true;
            this.seqIncrementByLbl.Location = new System.Drawing.Point(255, 32);
            this.seqIncrementByLbl.Name = "seqIncrementByLbl";
            this.seqIncrementByLbl.Size = new System.Drawing.Size(71, 13);
            this.seqIncrementByLbl.TabIndex = 21;
            this.seqIncrementByLbl.Text = "Increment by:";
            // 
            // seqStartWithLbl
            // 
            this.seqStartWithLbl.AutoSize = true;
            this.seqStartWithLbl.Location = new System.Drawing.Point(272, 6);
            this.seqStartWithLbl.Name = "seqStartWithLbl";
            this.seqStartWithLbl.Size = new System.Drawing.Size(54, 13);
            this.seqStartWithLbl.TabIndex = 20;
            this.seqStartWithLbl.Text = "Start with:";
            // 
            // seqSequenceNameTextBox
            // 
            this.seqSequenceNameTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.seqSequenceNameTextBox.Location = new System.Drawing.Point(98, 29);
            this.seqSequenceNameTextBox.MaxLength = 30;
            this.seqSequenceNameTextBox.Name = "seqSequenceNameTextBox";
            this.seqSequenceNameTextBox.Size = new System.Drawing.Size(149, 20);
            this.seqSequenceNameTextBox.TabIndex = 2;
            // 
            // seqSchemaTextBox
            // 
            this.seqSchemaTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.seqSchemaTextBox.Location = new System.Drawing.Point(98, 3);
            this.seqSchemaTextBox.MaxLength = 30;
            this.seqSchemaTextBox.Name = "seqSchemaTextBox";
            this.seqSchemaTextBox.Size = new System.Drawing.Size(149, 20);
            this.seqSchemaTextBox.TabIndex = 1;
            // 
            // seqSequenceNameLbl
            // 
            this.seqSequenceNameLbl.AutoSize = true;
            this.seqSequenceNameLbl.Location = new System.Drawing.Point(4, 32);
            this.seqSequenceNameLbl.Name = "seqSequenceNameLbl";
            this.seqSequenceNameLbl.Size = new System.Drawing.Size(88, 13);
            this.seqSequenceNameLbl.TabIndex = 17;
            this.seqSequenceNameLbl.Text = "Sequence name:";
            // 
            // seqSchemaLbl
            // 
            this.seqSchemaLbl.AutoSize = true;
            this.seqSchemaLbl.Location = new System.Drawing.Point(21, 6);
            this.seqSchemaLbl.Name = "seqSchemaLbl";
            this.seqSchemaLbl.Size = new System.Drawing.Size(49, 13);
            this.seqSchemaLbl.TabIndex = 16;
            this.seqSchemaLbl.Text = "Schema:";
            // 
            // nonVisualSettingTabPage
            // 
            this.nonVisualSettingTabPage.Controls.Add(this.nonVisualResetBtn);
            this.nonVisualSettingTabPage.Controls.Add(this.nonVisualClientsGrid);
            this.nonVisualSettingTabPage.Controls.Add(this.nonVisualClientsLbl);
            this.nonVisualSettingTabPage.Controls.Add(this.nonVisualBtn);
            this.nonVisualSettingTabPage.Controls.Add(this.nonVisualCodeTextBox);
            this.nonVisualSettingTabPage.Controls.Add(this.nonVisualCodeLbl);
            this.nonVisualSettingTabPage.Location = new System.Drawing.Point(4, 22);
            this.nonVisualSettingTabPage.Name = "nonVisualSettingTabPage";
            this.nonVisualSettingTabPage.Size = new System.Drawing.Size(1414, 348);
            this.nonVisualSettingTabPage.TabIndex = 4;
            this.nonVisualSettingTabPage.Text = "Non visual setting creation";
            this.nonVisualSettingTabPage.UseVisualStyleBackColor = true;
            // 
            // nonVisualResetBtn
            // 
            this.nonVisualResetBtn.Location = new System.Drawing.Point(13, 300);
            this.nonVisualResetBtn.Name = "nonVisualResetBtn";
            this.nonVisualResetBtn.Size = new System.Drawing.Size(75, 23);
            this.nonVisualResetBtn.TabIndex = 4;
            this.nonVisualResetBtn.Text = "Reset tab";
            this.nonVisualResetBtn.UseVisualStyleBackColor = true;
            this.nonVisualResetBtn.Click += new System.EventHandler(this.nonVisualResetBtn_Click);
            // 
            // nonVisualClientsGrid
            // 
            this.nonVisualClientsGrid.AllowUserToAddRows = false;
            this.nonVisualClientsGrid.AllowUserToDeleteRows = false;
            this.nonVisualClientsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.nonVisualClientsGrid.Location = new System.Drawing.Point(13, 45);
            this.nonVisualClientsGrid.Name = "nonVisualClientsGrid";
            this.nonVisualClientsGrid.Size = new System.Drawing.Size(1401, 220);
            this.nonVisualClientsGrid.TabIndex = 2;
            // 
            // nonVisualClientsLbl
            // 
            this.nonVisualClientsLbl.AutoSize = true;
            this.nonVisualClientsLbl.Location = new System.Drawing.Point(10, 29);
            this.nonVisualClientsLbl.Name = "nonVisualClientsLbl";
            this.nonVisualClientsLbl.Size = new System.Drawing.Size(70, 13);
            this.nonVisualClientsLbl.TabIndex = 20;
            this.nonVisualClientsLbl.Text = "Client values:";
            // 
            // nonVisualBtn
            // 
            this.nonVisualBtn.Location = new System.Drawing.Point(13, 271);
            this.nonVisualBtn.Name = "nonVisualBtn";
            this.nonVisualBtn.Size = new System.Drawing.Size(75, 23);
            this.nonVisualBtn.TabIndex = 3;
            this.nonVisualBtn.Text = "Generate";
            this.nonVisualBtn.UseVisualStyleBackColor = true;
            this.nonVisualBtn.Click += new System.EventHandler(this.nonVisualBtn_Click);
            // 
            // nonVisualCodeTextBox
            // 
            this.nonVisualCodeTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nonVisualCodeTextBox.Location = new System.Drawing.Point(51, 3);
            this.nonVisualCodeTextBox.MaxLength = 30;
            this.nonVisualCodeTextBox.Name = "nonVisualCodeTextBox";
            this.nonVisualCodeTextBox.Size = new System.Drawing.Size(149, 20);
            this.nonVisualCodeTextBox.TabIndex = 1;
            // 
            // nonVisualCodeLbl
            // 
            this.nonVisualCodeLbl.AutoSize = true;
            this.nonVisualCodeLbl.Location = new System.Drawing.Point(10, 6);
            this.nonVisualCodeLbl.Name = "nonVisualCodeLbl";
            this.nonVisualCodeLbl.Size = new System.Drawing.Size(35, 13);
            this.nonVisualCodeLbl.TabIndex = 18;
            this.nonVisualCodeLbl.Text = "Code:";
            // 
            // NonVisLoad
            // 
            this.NonVisLoad.Controls.Add(this.nonVisLoadResetBtn);
            this.NonVisLoad.Controls.Add(this.nonVisualLoadPathLabel);
            this.NonVisLoad.Controls.Add(this.nonVisualLoadLabel);
            this.NonVisLoad.Controls.Add(this.nonVisualLoadFileButton);
            this.NonVisLoad.Controls.Add(this.nonVisLoadButton);
            this.NonVisLoad.Controls.Add(this.nonVisLoadCheckedListBox);
            this.NonVisLoad.Location = new System.Drawing.Point(4, 22);
            this.NonVisLoad.Name = "NonVisLoad";
            this.NonVisLoad.Padding = new System.Windows.Forms.Padding(3);
            this.NonVisLoad.Size = new System.Drawing.Size(1414, 348);
            this.NonVisLoad.TabIndex = 5;
            this.NonVisLoad.Text = "Non visual setting load";
            this.NonVisLoad.UseVisualStyleBackColor = true;
            // 
            // nonVisLoadResetBtn
            // 
            this.nonVisLoadResetBtn.Location = new System.Drawing.Point(216, 302);
            this.nonVisLoadResetBtn.Name = "nonVisLoadResetBtn";
            this.nonVisLoadResetBtn.Size = new System.Drawing.Size(75, 23);
            this.nonVisLoadResetBtn.TabIndex = 24;
            this.nonVisLoadResetBtn.Text = "Reset tab";
            this.nonVisLoadResetBtn.UseVisualStyleBackColor = true;
            this.nonVisLoadResetBtn.Click += new System.EventHandler(this.nonVisLoadResetBtn_Click);
            // 
            // nonVisualLoadPathLabel
            // 
            this.nonVisualLoadPathLabel.AutoSize = true;
            this.nonVisualLoadPathLabel.Location = new System.Drawing.Point(78, 328);
            this.nonVisualLoadPathLabel.Name = "nonVisualLoadPathLabel";
            this.nonVisualLoadPathLabel.Size = new System.Drawing.Size(0, 13);
            this.nonVisualLoadPathLabel.TabIndex = 23;
            // 
            // nonVisualLoadLabel
            // 
            this.nonVisualLoadLabel.AutoSize = true;
            this.nonVisualLoadLabel.Location = new System.Drawing.Point(21, 328);
            this.nonVisualLoadLabel.Name = "nonVisualLoadLabel";
            this.nonVisualLoadLabel.Size = new System.Drawing.Size(51, 13);
            this.nonVisualLoadLabel.TabIndex = 22;
            this.nonVisualLoadLabel.Text = "File Path:";
            // 
            // nonVisualLoadFileButton
            // 
            this.nonVisualLoadFileButton.Location = new System.Drawing.Point(20, 302);
            this.nonVisualLoadFileButton.Name = "nonVisualLoadFileButton";
            this.nonVisualLoadFileButton.Size = new System.Drawing.Size(109, 23);
            this.nonVisualLoadFileButton.TabIndex = 21;
            this.nonVisualLoadFileButton.Text = "Choose file path";
            this.nonVisualLoadFileButton.UseVisualStyleBackColor = true;
            this.nonVisualLoadFileButton.Click += new System.EventHandler(this.nonVisualLoadFileButton_Click);
            // 
            // nonVisLoadButton
            // 
            this.nonVisLoadButton.Location = new System.Drawing.Point(135, 302);
            this.nonVisLoadButton.Name = "nonVisLoadButton";
            this.nonVisLoadButton.Size = new System.Drawing.Size(75, 23);
            this.nonVisLoadButton.TabIndex = 20;
            this.nonVisLoadButton.Text = "Generate";
            this.nonVisLoadButton.UseVisualStyleBackColor = true;
            this.nonVisLoadButton.Click += new System.EventHandler(this.NonVisLoadButton_Click);
            // 
            // nonVisLoadCheckedListBox
            // 
            this.nonVisLoadCheckedListBox.FormattingEnabled = true;
            this.nonVisLoadCheckedListBox.Location = new System.Drawing.Point(20, 20);
            this.nonVisLoadCheckedListBox.Name = "nonVisLoadCheckedListBox";
            this.nonVisLoadCheckedListBox.Size = new System.Drawing.Size(190, 274);
            this.nonVisLoadCheckedListBox.TabIndex = 0;
            this.nonVisLoadCheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.NonVisLoadCheckedListBox_ItemCheck);
            // 
            // charConverterTabPage
            // 
            this.charConverterTabPage.Controls.Add(this.charConvResetBtn);
            this.charConverterTabPage.Controls.Add(this.charConvCheckBox);
            this.charConverterTabPage.Controls.Add(this.label1);
            this.charConverterTabPage.Controls.Add(this.charConvCheckedListBox);
            this.charConverterTabPage.Controls.Add(this.charConvButton);
            this.charConverterTabPage.Controls.Add(this.charConvLabel);
            this.charConverterTabPage.Controls.Add(this.charConvTextBox);
            this.charConverterTabPage.Location = new System.Drawing.Point(4, 22);
            this.charConverterTabPage.Name = "charConverterTabPage";
            this.charConverterTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.charConverterTabPage.Size = new System.Drawing.Size(1414, 348);
            this.charConverterTabPage.TabIndex = 6;
            this.charConverterTabPage.Text = "Char converter";
            this.charConverterTabPage.UseVisualStyleBackColor = true;
            // 
            // charConvResetBtn
            // 
            this.charConvResetBtn.Location = new System.Drawing.Point(9, 257);
            this.charConvResetBtn.Name = "charConvResetBtn";
            this.charConvResetBtn.Size = new System.Drawing.Size(75, 23);
            this.charConvResetBtn.TabIndex = 24;
            this.charConvResetBtn.Text = "Reset tab";
            this.charConvResetBtn.UseVisualStyleBackColor = true;
            this.charConvResetBtn.Click += new System.EventHandler(this.charConvResetBtn_Click);
            // 
            // charConvCheckBox
            // 
            this.charConvCheckBox.AutoSize = true;
            this.charConvCheckBox.Location = new System.Drawing.Point(90, 232);
            this.charConvCheckBox.Name = "charConvCheckBox";
            this.charConvCheckBox.Size = new System.Drawing.Size(122, 17);
            this.charConvCheckBox.TabIndex = 23;
            this.charConvCheckBox.Text = "Replace apostrophe";
            this.charConvCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Convert for language:";
            // 
            // charConvCheckedListBox
            // 
            this.charConvCheckedListBox.FormattingEnabled = true;
            this.charConvCheckedListBox.Location = new System.Drawing.Point(9, 20);
            this.charConvCheckedListBox.Name = "charConvCheckedListBox";
            this.charConvCheckedListBox.Size = new System.Drawing.Size(246, 199);
            this.charConvCheckedListBox.TabIndex = 21;
            this.charConvCheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.charConvCheckedListBox_ItemCheck);
            // 
            // charConvButton
            // 
            this.charConvButton.Location = new System.Drawing.Point(9, 228);
            this.charConvButton.Name = "charConvButton";
            this.charConvButton.Size = new System.Drawing.Size(75, 23);
            this.charConvButton.TabIndex = 20;
            this.charConvButton.Text = "Generate";
            this.charConvButton.UseVisualStyleBackColor = true;
            this.charConvButton.Click += new System.EventHandler(this.charConvButton_Click);
            // 
            // charConvLabel
            // 
            this.charConvLabel.AutoSize = true;
            this.charConvLabel.Location = new System.Drawing.Point(258, 4);
            this.charConvLabel.Name = "charConvLabel";
            this.charConvLabel.Size = new System.Drawing.Size(121, 13);
            this.charConvLabel.TabIndex = 19;
            this.charConvLabel.Text = "Text box for conversion:";
            // 
            // charConvTextBox
            // 
            this.charConvTextBox.Location = new System.Drawing.Point(261, 20);
            this.charConvTextBox.Multiline = true;
            this.charConvTextBox.Name = "charConvTextBox";
            this.charConvTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.charConvTextBox.Size = new System.Drawing.Size(998, 199);
            this.charConvTextBox.TabIndex = 1;
            // 
            // versioning
            // 
            this.versioning.Controls.Add(this.versioningDirectory);
            this.versioning.Controls.Add(this.versioningButton);
            this.versioning.Controls.Add(this.versioningCustomVersionTextBox);
            this.versioning.Controls.Add(this.versioningCustomVersionLabel);
            this.versioning.Controls.Add(this.versioningUseCustomLabel);
            this.versioning.Controls.Add(this.versioningUseCustomCheckBox);
            this.versioning.Controls.Add(this.versioningIncreaseMinorLabel);
            this.versioning.Controls.Add(this.versioningIncreaseMinorCheckBox);
            this.versioning.Controls.Add(this.versioningIncreaseMajorLabel);
            this.versioning.Controls.Add(this.versioningIncreaseMajorCheckBox);
            this.versioning.Controls.Add(this.versioningFilePathLabel);
            this.versioning.Controls.Add(this.versioningDirectoryButton);
            this.versioning.Location = new System.Drawing.Point(4, 22);
            this.versioning.Name = "versioning";
            this.versioning.Size = new System.Drawing.Size(1414, 348);
            this.versioning.TabIndex = 7;
            this.versioning.Text = "Version Increase";
            this.versioning.UseVisualStyleBackColor = true;
            // 
            // versioningDirectory
            // 
            this.versioningDirectory.AutoSize = true;
            this.versioningDirectory.Location = new System.Drawing.Point(63, 101);
            this.versioningDirectory.Name = "versioningDirectory";
            this.versioningDirectory.Size = new System.Drawing.Size(0, 13);
            this.versioningDirectory.TabIndex = 33;
            // 
            // versioningButton
            // 
            this.versioningButton.Location = new System.Drawing.Point(6, 117);
            this.versioningButton.Name = "versioningButton";
            this.versioningButton.Size = new System.Drawing.Size(109, 23);
            this.versioningButton.TabIndex = 32;
            this.versioningButton.Text = "Increase versions";
            this.versioningButton.UseVisualStyleBackColor = true;
            this.versioningButton.Click += new System.EventHandler(this.versioningButton_Click);
            // 
            // versioningCustomVersionTextBox
            // 
            this.versioningCustomVersionTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.versioningCustomVersionTextBox.Location = new System.Drawing.Point(274, 47);
            this.versioningCustomVersionTextBox.MaxLength = 30;
            this.versioningCustomVersionTextBox.Name = "versioningCustomVersionTextBox";
            this.versioningCustomVersionTextBox.Size = new System.Drawing.Size(149, 20);
            this.versioningCustomVersionTextBox.TabIndex = 30;
            this.versioningCustomVersionTextBox.Text = "1.0.0.0";
            // 
            // versioningCustomVersionLabel
            // 
            this.versioningCustomVersionLabel.AutoSize = true;
            this.versioningCustomVersionLabel.Location = new System.Drawing.Point(186, 50);
            this.versioningCustomVersionLabel.Name = "versioningCustomVersionLabel";
            this.versioningCustomVersionLabel.Size = new System.Drawing.Size(82, 13);
            this.versioningCustomVersionLabel.TabIndex = 31;
            this.versioningCustomVersionLabel.Text = "Custom version:";
            // 
            // versioningUseCustomLabel
            // 
            this.versioningUseCustomLabel.AutoSize = true;
            this.versioningUseCustomLabel.Location = new System.Drawing.Point(3, 50);
            this.versioningUseCustomLabel.Name = "versioningUseCustomLabel";
            this.versioningUseCustomLabel.Size = new System.Drawing.Size(103, 13);
            this.versioningUseCustomLabel.TabIndex = 29;
            this.versioningUseCustomLabel.Text = "Use custom version:";
            // 
            // versioningUseCustomCheckBox
            // 
            this.versioningUseCustomCheckBox.AutoSize = true;
            this.versioningUseCustomCheckBox.Location = new System.Drawing.Point(165, 50);
            this.versioningUseCustomCheckBox.Name = "versioningUseCustomCheckBox";
            this.versioningUseCustomCheckBox.Size = new System.Drawing.Size(15, 14);
            this.versioningUseCustomCheckBox.TabIndex = 28;
            this.versioningUseCustomCheckBox.UseVisualStyleBackColor = true;
            this.versioningUseCustomCheckBox.CheckedChanged += new System.EventHandler(this.versioningUseCustomCheckBox_CheckedChanged);
            // 
            // versioningIncreaseMinorLabel
            // 
            this.versioningIncreaseMinorLabel.AutoSize = true;
            this.versioningIncreaseMinorLabel.Location = new System.Drawing.Point(3, 30);
            this.versioningIncreaseMinorLabel.Name = "versioningIncreaseMinorLabel";
            this.versioningIncreaseMinorLabel.Size = new System.Drawing.Size(114, 13);
            this.versioningIncreaseMinorLabel.TabIndex = 27;
            this.versioningIncreaseMinorLabel.Text = "Increase minor by one:";
            // 
            // versioningIncreaseMinorCheckBox
            // 
            this.versioningIncreaseMinorCheckBox.AutoSize = true;
            this.versioningIncreaseMinorCheckBox.Location = new System.Drawing.Point(165, 30);
            this.versioningIncreaseMinorCheckBox.Name = "versioningIncreaseMinorCheckBox";
            this.versioningIncreaseMinorCheckBox.Size = new System.Drawing.Size(15, 14);
            this.versioningIncreaseMinorCheckBox.TabIndex = 26;
            this.versioningIncreaseMinorCheckBox.UseVisualStyleBackColor = true;
            this.versioningIncreaseMinorCheckBox.CheckedChanged += new System.EventHandler(this.versioningIncreaseMinorCheckBox_CheckedChanged);
            // 
            // versioningIncreaseMajorLabel
            // 
            this.versioningIncreaseMajorLabel.AutoSize = true;
            this.versioningIncreaseMajorLabel.Location = new System.Drawing.Point(3, 10);
            this.versioningIncreaseMajorLabel.Name = "versioningIncreaseMajorLabel";
            this.versioningIncreaseMajorLabel.Size = new System.Drawing.Size(114, 13);
            this.versioningIncreaseMajorLabel.TabIndex = 25;
            this.versioningIncreaseMajorLabel.Text = "Increase major by one:";
            // 
            // versioningIncreaseMajorCheckBox
            // 
            this.versioningIncreaseMajorCheckBox.Location = new System.Drawing.Point(165, 10);
            this.versioningIncreaseMajorCheckBox.Name = "versioningIncreaseMajorCheckBox";
            this.versioningIncreaseMajorCheckBox.Size = new System.Drawing.Size(15, 14);
            this.versioningIncreaseMajorCheckBox.TabIndex = 24;
            this.versioningIncreaseMajorCheckBox.UseVisualStyleBackColor = true;
            this.versioningIncreaseMajorCheckBox.CheckedChanged += new System.EventHandler(this.versioningIncreaseMajorCheckBox_CheckedChanged);
            // 
            // versioningFilePathLabel
            // 
            this.versioningFilePathLabel.AutoSize = true;
            this.versioningFilePathLabel.Location = new System.Drawing.Point(6, 101);
            this.versioningFilePathLabel.Name = "versioningFilePathLabel";
            this.versioningFilePathLabel.Size = new System.Drawing.Size(51, 13);
            this.versioningFilePathLabel.TabIndex = 23;
            this.versioningFilePathLabel.Text = "File Path:";
            // 
            // versioningDirectoryButton
            // 
            this.versioningDirectoryButton.Location = new System.Drawing.Point(6, 75);
            this.versioningDirectoryButton.Name = "versioningDirectoryButton";
            this.versioningDirectoryButton.Size = new System.Drawing.Size(109, 23);
            this.versioningDirectoryButton.TabIndex = 22;
            this.versioningDirectoryButton.Text = "Choose file path";
            this.versioningDirectoryButton.UseVisualStyleBackColor = true;
            this.versioningDirectoryButton.Click += new System.EventHandler(this.versioningDirectoryButton_Click);
            // 
            // domainModels
            // 
            this.domainModels.Controls.Add(this.domainNameSpaceTextBox);
            this.domainModels.Controls.Add(this.domainNamespaceLbl);
            this.domainModels.Controls.Add(this.domainRemoveBtn);
            this.domainModels.Controls.Add(this.domainAddBtn);
            this.domainModels.Controls.Add(this.domainResetBtn);
            this.domainModels.Controls.Add(this.domainGenerateBtn);
            this.domainModels.Controls.Add(this.domainClassNameTextBox);
            this.domainModels.Controls.Add(this.domainClassName);
            this.domainModels.Controls.Add(this.domainPropertiesGrid);
            this.domainModels.Location = new System.Drawing.Point(4, 22);
            this.domainModels.Name = "domainModels";
            this.domainModels.Padding = new System.Windows.Forms.Padding(3);
            this.domainModels.Size = new System.Drawing.Size(1414, 348);
            this.domainModels.TabIndex = 8;
            this.domainModels.Text = "Domain models";
            this.domainModels.UseVisualStyleBackColor = true;
            // 
            // domainNameSpaceTextBox
            // 
            this.domainNameSpaceTextBox.Location = new System.Drawing.Point(455, 16);
            this.domainNameSpaceTextBox.Name = "domainNameSpaceTextBox";
            this.domainNameSpaceTextBox.Size = new System.Drawing.Size(299, 20);
            this.domainNameSpaceTextBox.TabIndex = 19;
            // 
            // domainNamespaceLbl
            // 
            this.domainNamespaceLbl.AutoSize = true;
            this.domainNamespaceLbl.Location = new System.Drawing.Point(385, 16);
            this.domainNamespaceLbl.Name = "domainNamespaceLbl";
            this.domainNamespaceLbl.Size = new System.Drawing.Size(67, 13);
            this.domainNamespaceLbl.TabIndex = 18;
            this.domainNamespaceLbl.Text = "Namespace:";
            // 
            // domainRemoveBtn
            // 
            this.domainRemoveBtn.Location = new System.Drawing.Point(84, 43);
            this.domainRemoveBtn.Name = "domainRemoveBtn";
            this.domainRemoveBtn.Size = new System.Drawing.Size(107, 23);
            this.domainRemoveBtn.TabIndex = 17;
            this.domainRemoveBtn.Text = "Remove Selected";
            this.domainRemoveBtn.UseVisualStyleBackColor = true;
            this.domainRemoveBtn.Click += new System.EventHandler(this.DomainRemoveBtn_Click);
            // 
            // domainAddBtn
            // 
            this.domainAddBtn.Location = new System.Drawing.Point(3, 43);
            this.domainAddBtn.Name = "domainAddBtn";
            this.domainAddBtn.Size = new System.Drawing.Size(75, 23);
            this.domainAddBtn.TabIndex = 16;
            this.domainAddBtn.Text = "Add Column";
            this.domainAddBtn.UseVisualStyleBackColor = true;
            this.domainAddBtn.Click += new System.EventHandler(this.DomainAddBtn_Click);
            // 
            // domainResetBtn
            // 
            this.domainResetBtn.Location = new System.Drawing.Point(84, 258);
            this.domainResetBtn.Name = "domainResetBtn";
            this.domainResetBtn.Size = new System.Drawing.Size(75, 23);
            this.domainResetBtn.TabIndex = 4;
            this.domainResetBtn.Text = "Reset";
            this.domainResetBtn.UseVisualStyleBackColor = true;
            this.domainResetBtn.Click += new System.EventHandler(this.DomainResetBtn_Click);
            // 
            // domainGenerateBtn
            // 
            this.domainGenerateBtn.Location = new System.Drawing.Point(3, 258);
            this.domainGenerateBtn.Name = "domainGenerateBtn";
            this.domainGenerateBtn.Size = new System.Drawing.Size(75, 23);
            this.domainGenerateBtn.TabIndex = 3;
            this.domainGenerateBtn.Text = "Generate";
            this.domainGenerateBtn.UseVisualStyleBackColor = true;
            this.domainGenerateBtn.Click += new System.EventHandler(this.DomainGenerateBtn_Click);
            // 
            // domainClassNameTextBox
            // 
            this.domainClassNameTextBox.Location = new System.Drawing.Point(76, 16);
            this.domainClassNameTextBox.Name = "domainClassNameTextBox";
            this.domainClassNameTextBox.Size = new System.Drawing.Size(299, 20);
            this.domainClassNameTextBox.TabIndex = 2;
            // 
            // domainClassName
            // 
            this.domainClassName.AutoSize = true;
            this.domainClassName.Location = new System.Drawing.Point(6, 16);
            this.domainClassName.Name = "domainClassName";
            this.domainClassName.Size = new System.Drawing.Size(64, 13);
            this.domainClassName.TabIndex = 1;
            this.domainClassName.Text = "Class name:";
            // 
            // domainPropertiesGrid
            // 
            this.domainPropertiesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.domainPropertiesGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PropertyName,
            this.PropertyType,
            this.IsNullable,
            this.IsUsedInCreation,
            this.IsUsedInUpdating});
            this.domainPropertiesGrid.Location = new System.Drawing.Point(3, 72);
            this.domainPropertiesGrid.Name = "domainPropertiesGrid";
            this.domainPropertiesGrid.Size = new System.Drawing.Size(992, 180);
            this.domainPropertiesGrid.TabIndex = 0;
            // 
            // PropertyName
            // 
            this.PropertyName.HeaderText = "Property name";
            this.PropertyName.Name = "PropertyName";
            this.PropertyName.Width = 300;
            // 
            // PropertyType
            // 
            this.PropertyType.HeaderText = "Property type";
            this.PropertyType.Name = "PropertyType";
            this.PropertyType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PropertyType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PropertyType.Width = 200;
            // 
            // IsNullable
            // 
            this.IsNullable.HeaderText = "Is nullable";
            this.IsNullable.Name = "IsNullable";
            // 
            // IsUsedInCreation
            // 
            this.IsUsedInCreation.HeaderText = "Is used in creation";
            this.IsUsedInCreation.Name = "IsUsedInCreation";
            this.IsUsedInCreation.Width = 150;
            // 
            // IsUsedInUpdating
            // 
            this.IsUsedInUpdating.HeaderText = "Is used in updating";
            this.IsUsedInUpdating.Name = "IsUsedInUpdating";
            this.IsUsedInUpdating.Width = 150;
            // 
            // nonVisualLoadFileDialog
            // 
            this.nonVisualLoadFileDialog.FileName = "Nevizualus_sistemos_nustatymai";
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
            this.auditTabPage.ResumeLayout(false);
            this.auditTabPage.PerformLayout();
            this.SequenceTabPage.ResumeLayout(false);
            this.SequenceTabPage.PerformLayout();
            this.nonVisualSettingTabPage.ResumeLayout(false);
            this.nonVisualSettingTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nonVisualClientsGrid)).EndInit();
            this.NonVisLoad.ResumeLayout(false);
            this.NonVisLoad.PerformLayout();
            this.charConverterTabPage.ResumeLayout(false);
            this.charConverterTabPage.PerformLayout();
            this.versioning.ResumeLayout(false);
            this.versioning.PerformLayout();
            this.domainModels.ResumeLayout(false);
            this.domainModels.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.domainPropertiesGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox scriptTextBox;
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
        private System.Windows.Forms.Button tableAuditBtn;
        private System.Windows.Forms.TabPage auditTabPage;
        private System.Windows.Forms.Button auditBtn;
        private System.Windows.Forms.TextBox auditTableNameTextBox;
        private System.Windows.Forms.TextBox auditSchemaTextBox;
        private System.Windows.Forms.Label auditTableNameLbl;
        private System.Windows.Forms.Label auditSchemaLbl;
        private System.Windows.Forms.TextBox auditTriggerNameTextBox;
        private System.Windows.Forms.Label auditTriggerNameLbl;
        private System.Windows.Forms.TabPage SequenceTabPage;
        private System.Windows.Forms.TextBox seqIncrementByTextBox;
        private System.Windows.Forms.TextBox seqStartWithTextBox;
        private System.Windows.Forms.Label seqIncrementByLbl;
        private System.Windows.Forms.Label seqStartWithLbl;
        private System.Windows.Forms.TextBox seqSequenceNameTextBox;
        private System.Windows.Forms.TextBox seqSchemaTextBox;
        private System.Windows.Forms.Label seqSequenceNameLbl;
        private System.Windows.Forms.Label seqSchemaLbl;
        private System.Windows.Forms.Button seqBtn;
        private System.Windows.Forms.TabPage nonVisualSettingTabPage;
        private System.Windows.Forms.DataGridView nonVisualClientsGrid;
        private System.Windows.Forms.Label nonVisualClientsLbl;
        private System.Windows.Forms.Button nonVisualBtn;
        private System.Windows.Forms.TextBox nonVisualCodeTextBox;
        private System.Windows.Forms.Label nonVisualCodeLbl;
        private System.Windows.Forms.TextBox tableTablespaceTextBox;
        private System.Windows.Forms.Label tableTablespaceLbl;
        private System.Windows.Forms.TabPage NonVisLoad;
        private System.Windows.Forms.CheckedListBox nonVisLoadCheckedListBox;
        private System.Windows.Forms.Button nonVisLoadButton;
        private System.Windows.Forms.Label nonVisualLoadPathLabel;
        private System.Windows.Forms.Label nonVisualLoadLabel;
        private System.Windows.Forms.Button nonVisualLoadFileButton;
        private System.Windows.Forms.OpenFileDialog nonVisualLoadFileDialog;
        private System.Windows.Forms.TabPage charConverterTabPage;
        private System.Windows.Forms.Button charConvButton;
        private System.Windows.Forms.Label charConvLabel;
        private System.Windows.Forms.TextBox charConvTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox charConvCheckedListBox;
        private System.Windows.Forms.TabPage versioning;
        private System.Windows.Forms.TextBox versioningCustomVersionTextBox;
        private System.Windows.Forms.Label versioningCustomVersionLabel;
        private System.Windows.Forms.Label versioningUseCustomLabel;
        private System.Windows.Forms.CheckBox versioningUseCustomCheckBox;
        private System.Windows.Forms.Label versioningIncreaseMinorLabel;
        private System.Windows.Forms.CheckBox versioningIncreaseMinorCheckBox;
        private System.Windows.Forms.Label versioningIncreaseMajorLabel;
        private System.Windows.Forms.CheckBox versioningIncreaseMajorCheckBox;
        private System.Windows.Forms.Label versioningFilePathLabel;
        private System.Windows.Forms.Button versioningDirectoryButton;
        private System.Windows.Forms.Button versioningButton;
        private System.Windows.Forms.Label versioningDirectory;
        private System.Windows.Forms.FolderBrowserDialog versioningFolderBrowserDialog;
        private System.Windows.Forms.CheckBox charConvCheckBox;
        private System.Windows.Forms.Button tableResetBtn;
        private System.Windows.Forms.Button columnResetBtn;
        private System.Windows.Forms.Button auditResetBtn;
        private System.Windows.Forms.Button seqResetBtn;
        private System.Windows.Forms.Button nonVisualResetBtn;
        private System.Windows.Forms.Button nonVisLoadResetBtn;
        private System.Windows.Forms.Button charConvResetBtn;
        private System.Windows.Forms.TabPage domainModels;
        private System.Windows.Forms.DataGridView domainPropertiesGrid;
        private System.Windows.Forms.TextBox domainClassNameTextBox;
        private System.Windows.Forms.Label domainClassName;
        private System.Windows.Forms.Button domainResetBtn;
        private System.Windows.Forms.Button domainGenerateBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PropertyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PropertyType;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsNullable;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsUsedInCreation;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsUsedInUpdating;
        private System.Windows.Forms.Button domainRemoveBtn;
        private System.Windows.Forms.Button domainAddBtn;
        private System.Windows.Forms.TextBox domainNameSpaceTextBox;
        private System.Windows.Forms.Label domainNamespaceLbl;
        private System.Windows.Forms.TextBox columnDataLengthTextBox;
        private System.Windows.Forms.Label columnDataLengthLbl;
        private System.Windows.Forms.ComboBox columnTypeComboBox;
        private System.Windows.Forms.DataGridViewCheckBoxColumn tableColumnsIsPK;
        private System.Windows.Forms.DataGridViewTextBoxColumn tableColumnsName;
        private System.Windows.Forms.DataGridViewComboBoxColumn tableColumnsType;
        private System.Windows.Forms.DataGridViewTextBoxColumn tableColumnsDataLength;
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
    }
}

