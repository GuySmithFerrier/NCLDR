namespace NCldrBuilderGui
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gbxProgress = new System.Windows.Forms.GroupBox();
            this.tbxProgress = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxNCldrPath = new System.Windows.Forms.TextBox();
            this.tbxCldrPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuild = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxIncludeRegionTelephoneCodes = new System.Windows.Forms.CheckBox();
            this.cbxIncludeWindowsMetaTimeZones = new System.Windows.Forms.CheckBox();
            this.cbxIncludeWeekData = new System.Windows.Forms.CheckBox();
            this.cbxIncludeTimeZones = new System.Windows.Forms.CheckBox();
            this.cbxIncludeRegionInformations = new System.Windows.Forms.CheckBox();
            this.cbxIncludeRegionGroups = new System.Windows.Forms.CheckBox();
            this.cbxIncludeRegionCodes = new System.Windows.Forms.CheckBox();
            this.cbxIncludeReferences = new System.Windows.Forms.CheckBox();
            this.cbxIncludePostcodeRegexes = new System.Windows.Forms.CheckBox();
            this.cbxIncludePluralRuleSets = new System.Windows.Forms.CheckBox();
            this.cbxIncludeParentCultures = new System.Windows.Forms.CheckBox();
            this.cbxIncludeOrdinalRuleSets = new System.Windows.Forms.CheckBox();
            this.cbxIncludeNumeringSystems = new System.Windows.Forms.CheckBox();
            this.cbxIncludeMetaTimeZones = new System.Windows.Forms.CheckBox();
            this.cbxIncludeMeasurementData = new System.Windows.Forms.CheckBox();
            this.cbxIncludeLikelySubTags = new System.Windows.Forms.CheckBox();
            this.cbxIncludeLanguageMatches = new System.Windows.Forms.CheckBox();
            this.cbxIncludeGenderLists = new System.Windows.Forms.CheckBox();
            this.cbxIncludeDayPeriodRuleSets = new System.Windows.Forms.CheckBox();
            this.cbxIncludeCalendarTypes = new System.Windows.Forms.CheckBox();
            this.cbxIncludeCurrencyFractions = new System.Windows.Forms.CheckBox();
            this.cbxIncludeCurrencies = new System.Windows.Forms.CheckBox();
            this.cbxIncludeCultures = new System.Windows.Forms.CheckBox();
            this.cbxIncludeCharacterFallbacks = new System.Windows.Forms.CheckBox();
            this.cbxIncludeCultureNames = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.clbCultures = new System.Windows.Forms.CheckedListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbAllCultures = new System.Windows.Forms.RadioButton();
            this.rbAllNewCultures = new System.Windows.Forms.RadioButton();
            this.rbIncludeOnly = new System.Windows.Forms.RadioButton();
            this.rbExclude = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbxIncludeUnitPatternSets = new System.Windows.Forms.CheckBox();
            this.cbxIncludeListPatterns = new System.Windows.Forms.CheckBox();
            this.cbxIncludeDelimiters = new System.Windows.Forms.CheckBox();
            this.cbxIncludeCharacters = new System.Windows.Forms.CheckBox();
            this.cbxIncludeRuleBasedNumberFormatting = new System.Windows.Forms.CheckBox();
            this.cbxIncludeNumbers = new System.Windows.Forms.CheckBox();
            this.cbxIncludeMessages = new System.Windows.Forms.CheckBox();
            this.cbxIncludeDates = new System.Windows.Forms.CheckBox();
            this.cbxIncludeCasing = new System.Windows.Forms.CheckBox();
            this.cbxIncludeScriptDisplayNames = new System.Windows.Forms.CheckBox();
            this.cbxIncludeRegionDisplayNames = new System.Windows.Forms.CheckBox();
            this.cbxIncludeLanguageDisplayNames = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbxConfigFilename = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cbxIncludeCalendarPreferences = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gbxProgress.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(891, 444);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gbxProgress);
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(883, 418);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Build";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gbxProgress
            // 
            this.gbxProgress.Controls.Add(this.tbxProgress);
            this.gbxProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxProgress.Location = new System.Drawing.Point(3, 142);
            this.gbxProgress.Name = "gbxProgress";
            this.gbxProgress.Size = new System.Drawing.Size(877, 273);
            this.gbxProgress.TabIndex = 6;
            this.gbxProgress.TabStop = false;
            this.gbxProgress.Text = "Build Progress";
            // 
            // tbxProgress
            // 
            this.tbxProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxProgress.Location = new System.Drawing.Point(3, 16);
            this.tbxProgress.Multiline = true;
            this.tbxProgress.Name = "tbxProgress";
            this.tbxProgress.Size = new System.Drawing.Size(871, 254);
            this.tbxProgress.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.tbxNCldrPath);
            this.panel3.Controls.Add(this.tbxCldrPath);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.btnBuild);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(877, 139);
            this.panel3.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "CLDR (Input) Path";
            // 
            // tbxNCldrPath
            // 
            this.tbxNCldrPath.Location = new System.Drawing.Point(16, 74);
            this.tbxNCldrPath.Name = "tbxNCldrPath";
            this.tbxNCldrPath.Size = new System.Drawing.Size(334, 20);
            this.tbxNCldrPath.TabIndex = 4;
            this.tbxNCldrPath.Text = "C:\\Projects\\NCldr\\Source\\NCldr\\NCldrData";
            // 
            // tbxCldrPath
            // 
            this.tbxCldrPath.Location = new System.Drawing.Point(16, 35);
            this.tbxCldrPath.Name = "tbxCldrPath";
            this.tbxCldrPath.Size = new System.Drawing.Size(334, 20);
            this.tbxCldrPath.TabIndex = 1;
            this.tbxCldrPath.Text = "C:\\CLDR\\Release22.1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "NCLDR (Output) Path";
            // 
            // btnBuild
            // 
            this.btnBuild.Location = new System.Drawing.Point(16, 104);
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.Size = new System.Drawing.Size(75, 23);
            this.btnBuild.TabIndex = 2;
            this.btnBuild.Text = "Build";
            this.btnBuild.UseVisualStyleBackColor = true;
            this.btnBuild.Click += new System.EventHandler(this.btnBuild_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer1);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(883, 418);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Build Options";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(877, 355);
            this.splitContainer1.SplitterDistance = 432;
            this.splitContainer1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxIncludeCalendarPreferences);
            this.groupBox1.Controls.Add(this.cbxIncludeRegionTelephoneCodes);
            this.groupBox1.Controls.Add(this.cbxIncludeWindowsMetaTimeZones);
            this.groupBox1.Controls.Add(this.cbxIncludeWeekData);
            this.groupBox1.Controls.Add(this.cbxIncludeTimeZones);
            this.groupBox1.Controls.Add(this.cbxIncludeRegionInformations);
            this.groupBox1.Controls.Add(this.cbxIncludeRegionGroups);
            this.groupBox1.Controls.Add(this.cbxIncludeRegionCodes);
            this.groupBox1.Controls.Add(this.cbxIncludeReferences);
            this.groupBox1.Controls.Add(this.cbxIncludePostcodeRegexes);
            this.groupBox1.Controls.Add(this.cbxIncludePluralRuleSets);
            this.groupBox1.Controls.Add(this.cbxIncludeParentCultures);
            this.groupBox1.Controls.Add(this.cbxIncludeOrdinalRuleSets);
            this.groupBox1.Controls.Add(this.cbxIncludeNumeringSystems);
            this.groupBox1.Controls.Add(this.cbxIncludeMetaTimeZones);
            this.groupBox1.Controls.Add(this.cbxIncludeMeasurementData);
            this.groupBox1.Controls.Add(this.cbxIncludeLikelySubTags);
            this.groupBox1.Controls.Add(this.cbxIncludeLanguageMatches);
            this.groupBox1.Controls.Add(this.cbxIncludeGenderLists);
            this.groupBox1.Controls.Add(this.cbxIncludeDayPeriodRuleSets);
            this.groupBox1.Controls.Add(this.cbxIncludeCalendarTypes);
            this.groupBox1.Controls.Add(this.cbxIncludeCurrencyFractions);
            this.groupBox1.Controls.Add(this.cbxIncludeCurrencies);
            this.groupBox1.Controls.Add(this.cbxIncludeCultures);
            this.groupBox1.Controls.Add(this.cbxIncludeCharacterFallbacks);
            this.groupBox1.Controls.Add(this.cbxIncludeCultureNames);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(432, 355);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // cbxIncludeRegionTelephoneCodes
            // 
            this.cbxIncludeRegionTelephoneCodes.AutoSize = true;
            this.cbxIncludeRegionTelephoneCodes.Checked = true;
            this.cbxIncludeRegionTelephoneCodes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxIncludeRegionTelephoneCodes.Location = new System.Drawing.Point(199, 227);
            this.cbxIncludeRegionTelephoneCodes.Name = "cbxIncludeRegionTelephoneCodes";
            this.cbxIncludeRegionTelephoneCodes.Size = new System.Drawing.Size(184, 17);
            this.cbxIncludeRegionTelephoneCodes.TabIndex = 24;
            this.cbxIncludeRegionTelephoneCodes.Text = "Include region telephone codes ?";
            this.cbxIncludeRegionTelephoneCodes.UseVisualStyleBackColor = true;
            this.cbxIncludeRegionTelephoneCodes.CheckedChanged += new System.EventHandler(this.cbxIncludeRegionTelephoneCodes_CheckedChanged);
            // 
            // cbxIncludeWindowsMetaTimeZones
            // 
            this.cbxIncludeWindowsMetaTimeZones.AutoSize = true;
            this.cbxIncludeWindowsMetaTimeZones.Checked = true;
            this.cbxIncludeWindowsMetaTimeZones.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxIncludeWindowsMetaTimeZones.Location = new System.Drawing.Point(199, 296);
            this.cbxIncludeWindowsMetaTimeZones.Name = "cbxIncludeWindowsMetaTimeZones";
            this.cbxIncludeWindowsMetaTimeZones.Size = new System.Drawing.Size(196, 17);
            this.cbxIncludeWindowsMetaTimeZones.TabIndex = 23;
            this.cbxIncludeWindowsMetaTimeZones.Text = "Include Windows meta time zones ?";
            this.cbxIncludeWindowsMetaTimeZones.UseVisualStyleBackColor = true;
            this.cbxIncludeWindowsMetaTimeZones.CheckedChanged += new System.EventHandler(this.cbxIncludeWindowsMetaTimeZones_CheckedChanged);
            // 
            // cbxIncludeWeekData
            // 
            this.cbxIncludeWeekData.AutoSize = true;
            this.cbxIncludeWeekData.Checked = true;
            this.cbxIncludeWeekData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxIncludeWeekData.Location = new System.Drawing.Point(199, 273);
            this.cbxIncludeWeekData.Name = "cbxIncludeWeekData";
            this.cbxIncludeWeekData.Size = new System.Drawing.Size(123, 17);
            this.cbxIncludeWeekData.TabIndex = 22;
            this.cbxIncludeWeekData.Text = "Include week data ?";
            this.cbxIncludeWeekData.UseVisualStyleBackColor = true;
            this.cbxIncludeWeekData.CheckedChanged += new System.EventHandler(this.cbxIncludeWeekData_CheckedChanged);
            // 
            // cbxIncludeTimeZones
            // 
            this.cbxIncludeTimeZones.AutoSize = true;
            this.cbxIncludeTimeZones.Checked = true;
            this.cbxIncludeTimeZones.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxIncludeTimeZones.Location = new System.Drawing.Point(199, 250);
            this.cbxIncludeTimeZones.Name = "cbxIncludeTimeZones";
            this.cbxIncludeTimeZones.Size = new System.Drawing.Size(123, 17);
            this.cbxIncludeTimeZones.TabIndex = 21;
            this.cbxIncludeTimeZones.Text = "Include time zones ?";
            this.cbxIncludeTimeZones.UseVisualStyleBackColor = true;
            this.cbxIncludeTimeZones.CheckedChanged += new System.EventHandler(this.cbxIncludeTimeZones_CheckedChanged);
            // 
            // cbxIncludeRegionInformations
            // 
            this.cbxIncludeRegionInformations.AutoSize = true;
            this.cbxIncludeRegionInformations.Checked = true;
            this.cbxIncludeRegionInformations.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxIncludeRegionInformations.Location = new System.Drawing.Point(199, 204);
            this.cbxIncludeRegionInformations.Name = "cbxIncludeRegionInformations";
            this.cbxIncludeRegionInformations.Size = new System.Drawing.Size(161, 17);
            this.cbxIncludeRegionInformations.TabIndex = 20;
            this.cbxIncludeRegionInformations.Text = "Include region informations ?";
            this.cbxIncludeRegionInformations.UseVisualStyleBackColor = true;
            this.cbxIncludeRegionInformations.CheckedChanged += new System.EventHandler(this.cbxIncludeRegionInformations_CheckedChanged);
            // 
            // cbxIncludeRegionGroups
            // 
            this.cbxIncludeRegionGroups.AutoSize = true;
            this.cbxIncludeRegionGroups.Checked = true;
            this.cbxIncludeRegionGroups.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxIncludeRegionGroups.Location = new System.Drawing.Point(199, 181);
            this.cbxIncludeRegionGroups.Name = "cbxIncludeRegionGroups";
            this.cbxIncludeRegionGroups.Size = new System.Drawing.Size(137, 17);
            this.cbxIncludeRegionGroups.TabIndex = 19;
            this.cbxIncludeRegionGroups.Text = "Include region groups ?";
            this.cbxIncludeRegionGroups.UseVisualStyleBackColor = true;
            this.cbxIncludeRegionGroups.CheckedChanged += new System.EventHandler(this.cbxIncludeRegionGroups_CheckedChanged);
            // 
            // cbxIncludeRegionCodes
            // 
            this.cbxIncludeRegionCodes.AutoSize = true;
            this.cbxIncludeRegionCodes.Checked = true;
            this.cbxIncludeRegionCodes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxIncludeRegionCodes.Location = new System.Drawing.Point(199, 158);
            this.cbxIncludeRegionCodes.Name = "cbxIncludeRegionCodes";
            this.cbxIncludeRegionCodes.Size = new System.Drawing.Size(134, 17);
            this.cbxIncludeRegionCodes.TabIndex = 18;
            this.cbxIncludeRegionCodes.Text = "Include region codes ?";
            this.cbxIncludeRegionCodes.UseVisualStyleBackColor = true;
            this.cbxIncludeRegionCodes.CheckedChanged += new System.EventHandler(this.cbxIncludeRegionCodes_CheckedChanged);
            // 
            // cbxIncludeReferences
            // 
            this.cbxIncludeReferences.AutoSize = true;
            this.cbxIncludeReferences.Checked = true;
            this.cbxIncludeReferences.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxIncludeReferences.Location = new System.Drawing.Point(199, 135);
            this.cbxIncludeReferences.Name = "cbxIncludeReferences";
            this.cbxIncludeReferences.Size = new System.Drawing.Size(123, 17);
            this.cbxIncludeReferences.TabIndex = 17;
            this.cbxIncludeReferences.Text = "Include references ?";
            this.cbxIncludeReferences.UseVisualStyleBackColor = true;
            this.cbxIncludeReferences.CheckedChanged += new System.EventHandler(this.cbxIncludeReferences_CheckedChanged);
            // 
            // cbxIncludePostcodeRegexes
            // 
            this.cbxIncludePostcodeRegexes.AutoSize = true;
            this.cbxIncludePostcodeRegexes.Checked = true;
            this.cbxIncludePostcodeRegexes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxIncludePostcodeRegexes.Location = new System.Drawing.Point(199, 112);
            this.cbxIncludePostcodeRegexes.Name = "cbxIncludePostcodeRegexes";
            this.cbxIncludePostcodeRegexes.Size = new System.Drawing.Size(157, 17);
            this.cbxIncludePostcodeRegexes.TabIndex = 16;
            this.cbxIncludePostcodeRegexes.Text = "Include postcode regexes ?";
            this.cbxIncludePostcodeRegexes.UseVisualStyleBackColor = true;
            this.cbxIncludePostcodeRegexes.CheckedChanged += new System.EventHandler(this.cbxIncludePostcodeRegexes_CheckedChanged);
            // 
            // cbxIncludePluralRuleSets
            // 
            this.cbxIncludePluralRuleSets.AutoSize = true;
            this.cbxIncludePluralRuleSets.Checked = true;
            this.cbxIncludePluralRuleSets.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxIncludePluralRuleSets.Location = new System.Drawing.Point(199, 89);
            this.cbxIncludePluralRuleSets.Name = "cbxIncludePluralRuleSets";
            this.cbxIncludePluralRuleSets.Size = new System.Drawing.Size(140, 17);
            this.cbxIncludePluralRuleSets.TabIndex = 15;
            this.cbxIncludePluralRuleSets.Text = "Include plural rule sets ?";
            this.cbxIncludePluralRuleSets.UseVisualStyleBackColor = true;
            this.cbxIncludePluralRuleSets.CheckedChanged += new System.EventHandler(this.cbxIncludePluralRuleSets_CheckedChanged);
            // 
            // cbxIncludeParentCultures
            // 
            this.cbxIncludeParentCultures.AutoSize = true;
            this.cbxIncludeParentCultures.Checked = true;
            this.cbxIncludeParentCultures.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxIncludeParentCultures.Location = new System.Drawing.Point(199, 66);
            this.cbxIncludeParentCultures.Name = "cbxIncludeParentCultures";
            this.cbxIncludeParentCultures.Size = new System.Drawing.Size(143, 17);
            this.cbxIncludeParentCultures.TabIndex = 14;
            this.cbxIncludeParentCultures.Text = "Include parent cultures ?";
            this.cbxIncludeParentCultures.UseVisualStyleBackColor = true;
            this.cbxIncludeParentCultures.CheckedChanged += new System.EventHandler(this.cbxIncludeParentCultures_CheckedChanged);
            // 
            // cbxIncludeOrdinalRuleSets
            // 
            this.cbxIncludeOrdinalRuleSets.AutoSize = true;
            this.cbxIncludeOrdinalRuleSets.Checked = true;
            this.cbxIncludeOrdinalRuleSets.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxIncludeOrdinalRuleSets.Location = new System.Drawing.Point(199, 43);
            this.cbxIncludeOrdinalRuleSets.Name = "cbxIncludeOrdinalRuleSets";
            this.cbxIncludeOrdinalRuleSets.Size = new System.Drawing.Size(146, 17);
            this.cbxIncludeOrdinalRuleSets.TabIndex = 13;
            this.cbxIncludeOrdinalRuleSets.Text = "Include ordinal rule sets ?";
            this.cbxIncludeOrdinalRuleSets.UseVisualStyleBackColor = true;
            this.cbxIncludeOrdinalRuleSets.CheckedChanged += new System.EventHandler(this.cbxIncludeOrdinalRuleSets_CheckedChanged);
            // 
            // cbxIncludeNumeringSystems
            // 
            this.cbxIncludeNumeringSystems.AutoSize = true;
            this.cbxIncludeNumeringSystems.Checked = true;
            this.cbxIncludeNumeringSystems.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxIncludeNumeringSystems.Location = new System.Drawing.Point(199, 20);
            this.cbxIncludeNumeringSystems.Name = "cbxIncludeNumeringSystems";
            this.cbxIncludeNumeringSystems.Size = new System.Drawing.Size(162, 17);
            this.cbxIncludeNumeringSystems.TabIndex = 12;
            this.cbxIncludeNumeringSystems.Text = "Include numbering systems ?";
            this.cbxIncludeNumeringSystems.UseVisualStyleBackColor = true;
            this.cbxIncludeNumeringSystems.CheckedChanged += new System.EventHandler(this.cbxIncludeNumeringSystems_CheckedChanged);
            // 
            // cbxIncludeMetaTimeZones
            // 
            this.cbxIncludeMetaTimeZones.AutoSize = true;
            this.cbxIncludeMetaTimeZones.Checked = true;
            this.cbxIncludeMetaTimeZones.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxIncludeMetaTimeZones.Location = new System.Drawing.Point(6, 296);
            this.cbxIncludeMetaTimeZones.Name = "cbxIncludeMetaTimeZones";
            this.cbxIncludeMetaTimeZones.Size = new System.Drawing.Size(149, 17);
            this.cbxIncludeMetaTimeZones.TabIndex = 11;
            this.cbxIncludeMetaTimeZones.Text = "Include meta time zones ?";
            this.cbxIncludeMetaTimeZones.UseVisualStyleBackColor = true;
            this.cbxIncludeMetaTimeZones.CheckedChanged += new System.EventHandler(this.cbxIncludeMetaTimeZones_CheckedChanged);
            // 
            // cbxIncludeMeasurementData
            // 
            this.cbxIncludeMeasurementData.AutoSize = true;
            this.cbxIncludeMeasurementData.Checked = true;
            this.cbxIncludeMeasurementData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxIncludeMeasurementData.Location = new System.Drawing.Point(6, 273);
            this.cbxIncludeMeasurementData.Name = "cbxIncludeMeasurementData";
            this.cbxIncludeMeasurementData.Size = new System.Drawing.Size(160, 17);
            this.cbxIncludeMeasurementData.TabIndex = 10;
            this.cbxIncludeMeasurementData.Text = "Include measurement data ?";
            this.cbxIncludeMeasurementData.UseVisualStyleBackColor = true;
            this.cbxIncludeMeasurementData.CheckedChanged += new System.EventHandler(this.cbxIncludeMeasurementData_CheckedChanged);
            // 
            // cbxIncludeLikelySubTags
            // 
            this.cbxIncludeLikelySubTags.AutoSize = true;
            this.cbxIncludeLikelySubTags.Checked = true;
            this.cbxIncludeLikelySubTags.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxIncludeLikelySubTags.Location = new System.Drawing.Point(6, 250);
            this.cbxIncludeLikelySubTags.Name = "cbxIncludeLikelySubTags";
            this.cbxIncludeLikelySubTags.Size = new System.Drawing.Size(136, 17);
            this.cbxIncludeLikelySubTags.TabIndex = 9;
            this.cbxIncludeLikelySubTags.Text = "Include likely subtags ?";
            this.cbxIncludeLikelySubTags.UseVisualStyleBackColor = true;
            this.cbxIncludeLikelySubTags.CheckedChanged += new System.EventHandler(this.cbxIncludeLikelySubTags_CheckedChanged);
            // 
            // cbxIncludeLanguageMatches
            // 
            this.cbxIncludeLanguageMatches.AutoSize = true;
            this.cbxIncludeLanguageMatches.Checked = true;
            this.cbxIncludeLanguageMatches.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxIncludeLanguageMatches.Location = new System.Drawing.Point(6, 227);
            this.cbxIncludeLanguageMatches.Name = "cbxIncludeLanguageMatches";
            this.cbxIncludeLanguageMatches.Size = new System.Drawing.Size(160, 17);
            this.cbxIncludeLanguageMatches.TabIndex = 8;
            this.cbxIncludeLanguageMatches.Text = "Include language matches ?";
            this.cbxIncludeLanguageMatches.UseVisualStyleBackColor = true;
            this.cbxIncludeLanguageMatches.CheckedChanged += new System.EventHandler(this.cbxIncludeLanguageMatches_CheckedChanged);
            // 
            // cbxIncludeGenderLists
            // 
            this.cbxIncludeGenderLists.AutoSize = true;
            this.cbxIncludeGenderLists.Checked = true;
            this.cbxIncludeGenderLists.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxIncludeGenderLists.Location = new System.Drawing.Point(6, 204);
            this.cbxIncludeGenderLists.Name = "cbxIncludeGenderLists";
            this.cbxIncludeGenderLists.Size = new System.Drawing.Size(126, 17);
            this.cbxIncludeGenderLists.TabIndex = 7;
            this.cbxIncludeGenderLists.Text = "Include gender lists ?";
            this.cbxIncludeGenderLists.UseVisualStyleBackColor = true;
            this.cbxIncludeGenderLists.CheckedChanged += new System.EventHandler(this.cbxIncludeGenderLists_CheckedChanged);
            // 
            // cbxIncludeDayPeriodRuleSets
            // 
            this.cbxIncludeDayPeriodRuleSets.AutoSize = true;
            this.cbxIncludeDayPeriodRuleSets.Checked = true;
            this.cbxIncludeDayPeriodRuleSets.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxIncludeDayPeriodRuleSets.Location = new System.Drawing.Point(6, 181);
            this.cbxIncludeDayPeriodRuleSets.Name = "cbxIncludeDayPeriodRuleSets";
            this.cbxIncludeDayPeriodRuleSets.Size = new System.Drawing.Size(164, 17);
            this.cbxIncludeDayPeriodRuleSets.TabIndex = 6;
            this.cbxIncludeDayPeriodRuleSets.Text = "Include day period rule sets ?";
            this.cbxIncludeDayPeriodRuleSets.UseVisualStyleBackColor = true;
            this.cbxIncludeDayPeriodRuleSets.CheckedChanged += new System.EventHandler(this.cbxIncludeDayPeriodRuleSets_CheckedChanged);
            // 
            // cbxIncludeCalendarTypes
            // 
            this.cbxIncludeCalendarTypes.AutoSize = true;
            this.cbxIncludeCalendarTypes.Checked = true;
            this.cbxIncludeCalendarTypes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxIncludeCalendarTypes.Location = new System.Drawing.Point(6, 158);
            this.cbxIncludeCalendarTypes.Name = "cbxIncludeCalendarTypes";
            this.cbxIncludeCalendarTypes.Size = new System.Drawing.Size(142, 17);
            this.cbxIncludeCalendarTypes.TabIndex = 5;
            this.cbxIncludeCalendarTypes.Text = "Include calendar types ?";
            this.cbxIncludeCalendarTypes.UseVisualStyleBackColor = true;
            this.cbxIncludeCalendarTypes.CheckedChanged += new System.EventHandler(this.cbxIncludeCalendarTypes_CheckedChanged);
            // 
            // cbxIncludeCurrencyFractions
            // 
            this.cbxIncludeCurrencyFractions.AutoSize = true;
            this.cbxIncludeCurrencyFractions.Checked = true;
            this.cbxIncludeCurrencyFractions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxIncludeCurrencyFractions.Location = new System.Drawing.Point(6, 135);
            this.cbxIncludeCurrencyFractions.Name = "cbxIncludeCurrencyFractions";
            this.cbxIncludeCurrencyFractions.Size = new System.Drawing.Size(157, 17);
            this.cbxIncludeCurrencyFractions.TabIndex = 4;
            this.cbxIncludeCurrencyFractions.Text = "Include currency fractions ?";
            this.cbxIncludeCurrencyFractions.UseVisualStyleBackColor = true;
            this.cbxIncludeCurrencyFractions.CheckedChanged += new System.EventHandler(this.cbxIncludeCurrencyFractions_CheckedChanged);
            // 
            // cbxIncludeCurrencies
            // 
            this.cbxIncludeCurrencies.AutoSize = true;
            this.cbxIncludeCurrencies.Checked = true;
            this.cbxIncludeCurrencies.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxIncludeCurrencies.Location = new System.Drawing.Point(6, 112);
            this.cbxIncludeCurrencies.Name = "cbxIncludeCurrencies";
            this.cbxIncludeCurrencies.Size = new System.Drawing.Size(122, 17);
            this.cbxIncludeCurrencies.TabIndex = 3;
            this.cbxIncludeCurrencies.Text = "Include currencies ?";
            this.cbxIncludeCurrencies.UseVisualStyleBackColor = true;
            this.cbxIncludeCurrencies.CheckedChanged += new System.EventHandler(this.cbxIncludeCurrencies_CheckedChanged);
            // 
            // cbxIncludeCultures
            // 
            this.cbxIncludeCultures.AutoSize = true;
            this.cbxIncludeCultures.Checked = true;
            this.cbxIncludeCultures.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxIncludeCultures.Location = new System.Drawing.Point(6, 89);
            this.cbxIncludeCultures.Name = "cbxIncludeCultures";
            this.cbxIncludeCultures.Size = new System.Drawing.Size(110, 17);
            this.cbxIncludeCultures.TabIndex = 2;
            this.cbxIncludeCultures.Text = "Include cultures ?";
            this.cbxIncludeCultures.UseVisualStyleBackColor = true;
            this.cbxIncludeCultures.CheckedChanged += new System.EventHandler(this.cbxIncludeCultures_CheckedChanged);
            // 
            // cbxIncludeCharacterFallbacks
            // 
            this.cbxIncludeCharacterFallbacks.AutoSize = true;
            this.cbxIncludeCharacterFallbacks.Checked = true;
            this.cbxIncludeCharacterFallbacks.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxIncludeCharacterFallbacks.Location = new System.Drawing.Point(6, 66);
            this.cbxIncludeCharacterFallbacks.Name = "cbxIncludeCharacterFallbacks";
            this.cbxIncludeCharacterFallbacks.Size = new System.Drawing.Size(163, 17);
            this.cbxIncludeCharacterFallbacks.TabIndex = 1;
            this.cbxIncludeCharacterFallbacks.Text = "Include character fallbacks ?";
            this.cbxIncludeCharacterFallbacks.UseVisualStyleBackColor = true;
            this.cbxIncludeCharacterFallbacks.CheckedChanged += new System.EventHandler(this.cbxIncludeCharacterFallbacks_CheckedChanged);
            // 
            // cbxIncludeCultureNames
            // 
            this.cbxIncludeCultureNames.AutoSize = true;
            this.cbxIncludeCultureNames.Checked = true;
            this.cbxIncludeCultureNames.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxIncludeCultureNames.Location = new System.Drawing.Point(7, 20);
            this.cbxIncludeCultureNames.Name = "cbxIncludeCultureNames";
            this.cbxIncludeCultureNames.Size = new System.Drawing.Size(139, 17);
            this.cbxIncludeCultureNames.TabIndex = 0;
            this.cbxIncludeCultureNames.Text = "Include culture names ?";
            this.cbxIncludeCultureNames.UseVisualStyleBackColor = true;
            this.cbxIncludeCultureNames.CheckedChanged += new System.EventHandler(this.cbxIncludeCultureNames_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(441, 355);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Culture Options";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.clbCultures);
            this.groupBox4.Controls.Add(this.panel2);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(221, 16);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(217, 336);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Select Cultures";
            // 
            // clbCultures
            // 
            this.clbCultures.CheckOnClick = true;
            this.clbCultures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbCultures.FormattingEnabled = true;
            this.clbCultures.Location = new System.Drawing.Point(3, 144);
            this.clbCultures.Name = "clbCultures";
            this.clbCultures.Size = new System.Drawing.Size(211, 189);
            this.clbCultures.TabIndex = 5;
            this.clbCultures.Visible = false;
            this.clbCultures.SelectedValueChanged += new System.EventHandler(this.clbCultures_SelectedValueChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbAllCultures);
            this.panel2.Controls.Add(this.rbAllNewCultures);
            this.panel2.Controls.Add(this.rbIncludeOnly);
            this.panel2.Controls.Add(this.rbExclude);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(211, 128);
            this.panel2.TabIndex = 4;
            // 
            // rbAllCultures
            // 
            this.rbAllCultures.AutoSize = true;
            this.rbAllCultures.Checked = true;
            this.rbAllCultures.Location = new System.Drawing.Point(3, 22);
            this.rbAllCultures.Name = "rbAllCultures";
            this.rbAllCultures.Size = new System.Drawing.Size(76, 17);
            this.rbAllCultures.TabIndex = 0;
            this.rbAllCultures.TabStop = true;
            this.rbAllCultures.Text = "All cultures";
            this.rbAllCultures.UseVisualStyleBackColor = true;
            this.rbAllCultures.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rbAllNewCultures
            // 
            this.rbAllNewCultures.AutoSize = true;
            this.rbAllNewCultures.Location = new System.Drawing.Point(3, 92);
            this.rbAllNewCultures.Name = "rbAllNewCultures";
            this.rbAllNewCultures.Size = new System.Drawing.Size(136, 17);
            this.rbAllNewCultures.TabIndex = 3;
            this.rbAllNewCultures.TabStop = true;
            this.rbAllNewCultures.Text = "Include all new cultures";
            this.rbAllNewCultures.UseVisualStyleBackColor = true;
            this.rbAllNewCultures.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rbIncludeOnly
            // 
            this.rbIncludeOnly.AutoSize = true;
            this.rbIncludeOnly.Location = new System.Drawing.Point(3, 46);
            this.rbIncludeOnly.Name = "rbIncludeOnly";
            this.rbIncludeOnly.Size = new System.Drawing.Size(187, 17);
            this.rbIncludeOnly.TabIndex = 1;
            this.rbIncludeOnly.Text = "Include only those checked below";
            this.rbIncludeOnly.UseVisualStyleBackColor = true;
            this.rbIncludeOnly.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rbExclude
            // 
            this.rbExclude.AutoSize = true;
            this.rbExclude.Location = new System.Drawing.Point(3, 68);
            this.rbExclude.Name = "rbExclude";
            this.rbExclude.Size = new System.Drawing.Size(213, 17);
            this.rbExclude.TabIndex = 2;
            this.rbExclude.Text = "Include all except those checked below";
            this.rbExclude.UseVisualStyleBackColor = true;
            this.rbExclude.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbxIncludeUnitPatternSets);
            this.groupBox3.Controls.Add(this.cbxIncludeListPatterns);
            this.groupBox3.Controls.Add(this.cbxIncludeDelimiters);
            this.groupBox3.Controls.Add(this.cbxIncludeCharacters);
            this.groupBox3.Controls.Add(this.cbxIncludeRuleBasedNumberFormatting);
            this.groupBox3.Controls.Add(this.cbxIncludeNumbers);
            this.groupBox3.Controls.Add(this.cbxIncludeMessages);
            this.groupBox3.Controls.Add(this.cbxIncludeDates);
            this.groupBox3.Controls.Add(this.cbxIncludeCasing);
            this.groupBox3.Controls.Add(this.cbxIncludeScriptDisplayNames);
            this.groupBox3.Controls.Add(this.cbxIncludeRegionDisplayNames);
            this.groupBox3.Controls.Add(this.cbxIncludeLanguageDisplayNames);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Location = new System.Drawing.Point(3, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(218, 336);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            // 
            // cbxIncludeUnitPatternSets
            // 
            this.cbxIncludeUnitPatternSets.AutoSize = true;
            this.cbxIncludeUnitPatternSets.Checked = true;
            this.cbxIncludeUnitPatternSets.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxIncludeUnitPatternSets.Location = new System.Drawing.Point(6, 280);
            this.cbxIncludeUnitPatternSets.Name = "cbxIncludeUnitPatternSets";
            this.cbxIncludeUnitPatternSets.Size = new System.Drawing.Size(148, 17);
            this.cbxIncludeUnitPatternSets.TabIndex = 12;
            this.cbxIncludeUnitPatternSets.Text = "Include unit pattern sets ?";
            this.cbxIncludeUnitPatternSets.UseVisualStyleBackColor = true;
            this.cbxIncludeUnitPatternSets.CheckedChanged += new System.EventHandler(this.cbxIncludeUnitPatternSets_CheckedChanged);
            // 
            // cbxIncludeListPatterns
            // 
            this.cbxIncludeListPatterns.AutoSize = true;
            this.cbxIncludeListPatterns.Checked = true;
            this.cbxIncludeListPatterns.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxIncludeListPatterns.Location = new System.Drawing.Point(6, 188);
            this.cbxIncludeListPatterns.Name = "cbxIncludeListPatterns";
            this.cbxIncludeListPatterns.Size = new System.Drawing.Size(126, 17);
            this.cbxIncludeListPatterns.TabIndex = 11;
            this.cbxIncludeListPatterns.Text = "Include list patterns ?";
            this.cbxIncludeListPatterns.UseVisualStyleBackColor = true;
            this.cbxIncludeListPatterns.CheckedChanged += new System.EventHandler(this.cbxIncludeListPatterns_CheckedChanged);
            // 
            // cbxIncludeDelimiters
            // 
            this.cbxIncludeDelimiters.AutoSize = true;
            this.cbxIncludeDelimiters.Checked = true;
            this.cbxIncludeDelimiters.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxIncludeDelimiters.Location = new System.Drawing.Point(6, 165);
            this.cbxIncludeDelimiters.Name = "cbxIncludeDelimiters";
            this.cbxIncludeDelimiters.Size = new System.Drawing.Size(116, 17);
            this.cbxIncludeDelimiters.TabIndex = 10;
            this.cbxIncludeDelimiters.Text = "Include delimiters ?";
            this.cbxIncludeDelimiters.UseVisualStyleBackColor = true;
            this.cbxIncludeDelimiters.CheckedChanged += new System.EventHandler(this.cbxIncludeDelimiters_CheckedChanged);
            // 
            // cbxIncludeCharacters
            // 
            this.cbxIncludeCharacters.AutoSize = true;
            this.cbxIncludeCharacters.Checked = true;
            this.cbxIncludeCharacters.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxIncludeCharacters.Location = new System.Drawing.Point(6, 119);
            this.cbxIncludeCharacters.Name = "cbxIncludeCharacters";
            this.cbxIncludeCharacters.Size = new System.Drawing.Size(123, 17);
            this.cbxIncludeCharacters.TabIndex = 9;
            this.cbxIncludeCharacters.Text = "Include characters ?";
            this.cbxIncludeCharacters.UseVisualStyleBackColor = true;
            this.cbxIncludeCharacters.CheckedChanged += new System.EventHandler(this.cbxIncludeCharacters_CheckedChanged);
            // 
            // cbxIncludeRuleBasedNumberFormatting
            // 
            this.cbxIncludeRuleBasedNumberFormatting.AutoSize = true;
            this.cbxIncludeRuleBasedNumberFormatting.Checked = true;
            this.cbxIncludeRuleBasedNumberFormatting.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxIncludeRuleBasedNumberFormatting.Location = new System.Drawing.Point(6, 257);
            this.cbxIncludeRuleBasedNumberFormatting.Name = "cbxIncludeRuleBasedNumberFormatting";
            this.cbxIncludeRuleBasedNumberFormatting.Size = new System.Drawing.Size(209, 17);
            this.cbxIncludeRuleBasedNumberFormatting.TabIndex = 8;
            this.cbxIncludeRuleBasedNumberFormatting.Text = "Include rule based number formatting ?";
            this.cbxIncludeRuleBasedNumberFormatting.UseVisualStyleBackColor = true;
            this.cbxIncludeRuleBasedNumberFormatting.CheckedChanged += new System.EventHandler(this.cbxIncludeRuleBasedNumberFormatting_CheckedChanged);
            // 
            // cbxIncludeNumbers
            // 
            this.cbxIncludeNumbers.AutoSize = true;
            this.cbxIncludeNumbers.Checked = true;
            this.cbxIncludeNumbers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxIncludeNumbers.Location = new System.Drawing.Point(6, 234);
            this.cbxIncludeNumbers.Name = "cbxIncludeNumbers";
            this.cbxIncludeNumbers.Size = new System.Drawing.Size(113, 17);
            this.cbxIncludeNumbers.TabIndex = 7;
            this.cbxIncludeNumbers.Text = "Include numbers ?";
            this.cbxIncludeNumbers.UseVisualStyleBackColor = true;
            this.cbxIncludeNumbers.CheckedChanged += new System.EventHandler(this.cbxIncludeNumbers_CheckedChanged);
            // 
            // cbxIncludeMessages
            // 
            this.cbxIncludeMessages.AutoSize = true;
            this.cbxIncludeMessages.Checked = true;
            this.cbxIncludeMessages.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxIncludeMessages.Location = new System.Drawing.Point(6, 211);
            this.cbxIncludeMessages.Name = "cbxIncludeMessages";
            this.cbxIncludeMessages.Size = new System.Drawing.Size(120, 17);
            this.cbxIncludeMessages.TabIndex = 6;
            this.cbxIncludeMessages.Text = "Include messages ?";
            this.cbxIncludeMessages.UseVisualStyleBackColor = true;
            this.cbxIncludeMessages.CheckedChanged += new System.EventHandler(this.cbxIncludeMessages_CheckedChanged);
            // 
            // cbxIncludeDates
            // 
            this.cbxIncludeDates.AutoSize = true;
            this.cbxIncludeDates.Checked = true;
            this.cbxIncludeDates.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxIncludeDates.Location = new System.Drawing.Point(6, 142);
            this.cbxIncludeDates.Name = "cbxIncludeDates";
            this.cbxIncludeDates.Size = new System.Drawing.Size(99, 17);
            this.cbxIncludeDates.TabIndex = 5;
            this.cbxIncludeDates.Text = "Include dates ?";
            this.cbxIncludeDates.UseVisualStyleBackColor = true;
            this.cbxIncludeDates.CheckedChanged += new System.EventHandler(this.cbxIncludeDates_CheckedChanged);
            // 
            // cbxIncludeCasing
            // 
            this.cbxIncludeCasing.AutoSize = true;
            this.cbxIncludeCasing.Checked = true;
            this.cbxIncludeCasing.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxIncludeCasing.Location = new System.Drawing.Point(6, 96);
            this.cbxIncludeCasing.Name = "cbxIncludeCasing";
            this.cbxIncludeCasing.Size = new System.Drawing.Size(104, 17);
            this.cbxIncludeCasing.TabIndex = 4;
            this.cbxIncludeCasing.Text = "Include casing ?";
            this.cbxIncludeCasing.UseVisualStyleBackColor = true;
            this.cbxIncludeCasing.CheckedChanged += new System.EventHandler(this.cbxIncludeCasing_CheckedChanged);
            // 
            // cbxIncludeScriptDisplayNames
            // 
            this.cbxIncludeScriptDisplayNames.AutoSize = true;
            this.cbxIncludeScriptDisplayNames.Checked = true;
            this.cbxIncludeScriptDisplayNames.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxIncludeScriptDisplayNames.Location = new System.Drawing.Point(6, 73);
            this.cbxIncludeScriptDisplayNames.Name = "cbxIncludeScriptDisplayNames";
            this.cbxIncludeScriptDisplayNames.Size = new System.Drawing.Size(167, 17);
            this.cbxIncludeScriptDisplayNames.TabIndex = 3;
            this.cbxIncludeScriptDisplayNames.Text = "Include script display names ?";
            this.cbxIncludeScriptDisplayNames.UseVisualStyleBackColor = true;
            this.cbxIncludeScriptDisplayNames.CheckedChanged += new System.EventHandler(this.cbxIncludeScriptDisplayNames_CheckedChanged);
            // 
            // cbxIncludeRegionDisplayNames
            // 
            this.cbxIncludeRegionDisplayNames.AutoSize = true;
            this.cbxIncludeRegionDisplayNames.Checked = true;
            this.cbxIncludeRegionDisplayNames.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxIncludeRegionDisplayNames.Location = new System.Drawing.Point(6, 50);
            this.cbxIncludeRegionDisplayNames.Name = "cbxIncludeRegionDisplayNames";
            this.cbxIncludeRegionDisplayNames.Size = new System.Drawing.Size(171, 17);
            this.cbxIncludeRegionDisplayNames.TabIndex = 2;
            this.cbxIncludeRegionDisplayNames.Text = "Include region display names ?";
            this.cbxIncludeRegionDisplayNames.UseVisualStyleBackColor = true;
            this.cbxIncludeRegionDisplayNames.CheckedChanged += new System.EventHandler(this.cbxIncludeRegionDisplayNames_CheckedChanged);
            // 
            // cbxIncludeLanguageDisplayNames
            // 
            this.cbxIncludeLanguageDisplayNames.AutoSize = true;
            this.cbxIncludeLanguageDisplayNames.Checked = true;
            this.cbxIncludeLanguageDisplayNames.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxIncludeLanguageDisplayNames.Location = new System.Drawing.Point(6, 27);
            this.cbxIncludeLanguageDisplayNames.Name = "cbxIncludeLanguageDisplayNames";
            this.cbxIncludeLanguageDisplayNames.Size = new System.Drawing.Size(186, 17);
            this.cbxIncludeLanguageDisplayNames.TabIndex = 1;
            this.cbxIncludeLanguageDisplayNames.Text = "Include language display names ?";
            this.cbxIncludeLanguageDisplayNames.UseVisualStyleBackColor = true;
            this.cbxIncludeLanguageDisplayNames.CheckedChanged += new System.EventHandler(this.cbxIncludeLanguageDisplayNames_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbxConfigFilename);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnLoad);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 358);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(877, 57);
            this.panel1.TabIndex = 0;
            // 
            // tbxConfigFilename
            // 
            this.tbxConfigFilename.Location = new System.Drawing.Point(154, 20);
            this.tbxConfigFilename.Name = "tbxConfigFilename";
            this.tbxConfigFilename.Size = new System.Drawing.Size(195, 20);
            this.tbxConfigFilename.TabIndex = 3;
            this.tbxConfigFilename.Text = "NCLDRBuilder.config";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(151, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Configuration Filename:";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(436, 17);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(355, 17);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbxIncludeCalendarPreferences
            // 
            this.cbxIncludeCalendarPreferences.AutoSize = true;
            this.cbxIncludeCalendarPreferences.Checked = true;
            this.cbxIncludeCalendarPreferences.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxIncludeCalendarPreferences.Location = new System.Drawing.Point(7, 43);
            this.cbxIncludeCalendarPreferences.Name = "cbxIncludeCalendarPreferences";
            this.cbxIncludeCalendarPreferences.Size = new System.Drawing.Size(173, 17);
            this.cbxIncludeCalendarPreferences.TabIndex = 1;
            this.cbxIncludeCalendarPreferences.Text = "Include calendar preferences ?";
            this.cbxIncludeCalendarPreferences.UseVisualStyleBackColor = true;
            this.cbxIncludeCalendarPreferences.CheckedChanged += new System.EventHandler(this.cbxIncludeCalendarPreferences_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 444);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "NCLDR Builder";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.gbxProgress.ResumeLayout(false);
            this.gbxProgress.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbxIncludeCultureNames;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cbxIncludeCurrencies;
        private System.Windows.Forms.CheckBox cbxIncludeCultures;
        private System.Windows.Forms.CheckBox cbxIncludeCharacterFallbacks;
        private System.Windows.Forms.CheckBox cbxIncludeLikelySubTags;
        private System.Windows.Forms.CheckBox cbxIncludeLanguageMatches;
        private System.Windows.Forms.CheckBox cbxIncludeGenderLists;
        private System.Windows.Forms.CheckBox cbxIncludeDayPeriodRuleSets;
        private System.Windows.Forms.CheckBox cbxIncludeCalendarTypes;
        private System.Windows.Forms.CheckBox cbxIncludeCurrencyFractions;
        private System.Windows.Forms.CheckBox cbxIncludeMetaTimeZones;
        private System.Windows.Forms.CheckBox cbxIncludeMeasurementData;
        private System.Windows.Forms.CheckBox cbxIncludeOrdinalRuleSets;
        private System.Windows.Forms.CheckBox cbxIncludeNumeringSystems;
        private System.Windows.Forms.CheckBox cbxIncludeWindowsMetaTimeZones;
        private System.Windows.Forms.CheckBox cbxIncludeWeekData;
        private System.Windows.Forms.CheckBox cbxIncludeTimeZones;
        private System.Windows.Forms.CheckBox cbxIncludeRegionInformations;
        private System.Windows.Forms.CheckBox cbxIncludeRegionGroups;
        private System.Windows.Forms.CheckBox cbxIncludeRegionCodes;
        private System.Windows.Forms.CheckBox cbxIncludeReferences;
        private System.Windows.Forms.CheckBox cbxIncludePostcodeRegexes;
        private System.Windows.Forms.CheckBox cbxIncludePluralRuleSets;
        private System.Windows.Forms.CheckBox cbxIncludeParentCultures;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox cbxIncludeLanguageDisplayNames;
        private System.Windows.Forms.CheckBox cbxIncludeRuleBasedNumberFormatting;
        private System.Windows.Forms.CheckBox cbxIncludeNumbers;
        private System.Windows.Forms.CheckBox cbxIncludeMessages;
        private System.Windows.Forms.CheckBox cbxIncludeDates;
        private System.Windows.Forms.CheckBox cbxIncludeCasing;
        private System.Windows.Forms.CheckBox cbxIncludeScriptDisplayNames;
        private System.Windows.Forms.CheckBox cbxIncludeRegionDisplayNames;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rbAllCultures;
        private System.Windows.Forms.RadioButton rbAllNewCultures;
        private System.Windows.Forms.RadioButton rbExclude;
        private System.Windows.Forms.RadioButton rbIncludeOnly;
        private System.Windows.Forms.CheckedListBox clbCultures;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox tbxNCldrPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBuild;
        private System.Windows.Forms.TextBox tbxCldrPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbxProgress;
        private System.Windows.Forms.TextBox tbxProgress;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox tbxConfigFilename;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbxIncludeRegionTelephoneCodes;
        private System.Windows.Forms.CheckBox cbxIncludeUnitPatternSets;
        private System.Windows.Forms.CheckBox cbxIncludeListPatterns;
        private System.Windows.Forms.CheckBox cbxIncludeDelimiters;
        private System.Windows.Forms.CheckBox cbxIncludeCharacters;
        private System.Windows.Forms.CheckBox cbxIncludeCalendarPreferences;
    }
}

