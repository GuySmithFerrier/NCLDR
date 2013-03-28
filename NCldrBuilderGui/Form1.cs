using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NCldr;
using NCldr.Builder;

namespace NCldrBuilderGui
{
    public partial class Form1 : Form
    {
        private NCldrBuilderOptions options;

        public Form1()
        {
            InitializeComponent();

            options = new NCldrBuilderOptions();
        }

        private void cbxIncludeCultureNames_CheckedChanged(object sender, EventArgs e)
        {
            options.IncludeCultureNames = cbxIncludeCultureNames.Checked;
        }

        private void cbxIncludeCalendarPreferences_CheckedChanged(object sender, EventArgs e)
        {
            options.IncludeCalendarPreferences = cbxIncludeCalendarPreferences.Checked;
        }

        private void cbxIncludeCharacterFallbacks_CheckedChanged(object sender, EventArgs e)
        {
            options.IncludeCharacterFallbacks = cbxIncludeCharacterFallbacks.Checked;
        }

        private void cbxIncludeCultures_CheckedChanged(object sender, EventArgs e)
        {
            options.IncludeCultures = cbxIncludeCultures.Checked;
        }

        private void cbxIncludeCurrencies_CheckedChanged(object sender, EventArgs e)
        {
            options.IncludeCurrencies = cbxIncludeCurrencies.Checked;
        }

        private void cbxIncludeCurrencyFractions_CheckedChanged(object sender, EventArgs e)
        {
            options.IncludeCurrencyFractions = cbxIncludeCurrencyFractions.Checked;
        }

        private void cbxIncludeCalendarTypes_CheckedChanged(object sender, EventArgs e)
        {
            options.IncludeCalendarTypes = cbxIncludeCalendarTypes.Checked;
        }

        private void cbxIncludeDayPeriodRuleSets_CheckedChanged(object sender, EventArgs e)
        {
            options.IncludeDayPeriodRuleSets = cbxIncludeDayPeriodRuleSets.Checked;
        }

        private void cbxIncludeGenderLists_CheckedChanged(object sender, EventArgs e)
        {
            options.IncludeGenderLists = cbxIncludeGenderLists.Checked;
        }

        private void cbxIncludeLanguageMatches_CheckedChanged(object sender, EventArgs e)
        {
            options.IncludeLanguageMatches = cbxIncludeLanguageMatches.Checked;
        }

        private void cbxIncludeLikelySubTags_CheckedChanged(object sender, EventArgs e)
        {
            options.IncludeLikelySubTags = cbxIncludeLikelySubTags.Checked;
        }

        private void cbxIncludeMeasurementData_CheckedChanged(object sender, EventArgs e)
        {
            options.IncludeMeasurementData = cbxIncludeMeasurementData.Checked;
        }

        private void cbxIncludeTimeData_CheckedChanged(object sender, EventArgs e)
        {
            options.IncludeTimeData = cbxIncludeTimeData.Checked;
        }

        private void cbxIncludeMetaTimeZones_CheckedChanged(object sender, EventArgs e)
        {
            options.IncludeMetaTimeZones = cbxIncludeMetaTimeZones.Checked;
        }

        private void cbxIncludeNumeringSystems_CheckedChanged(object sender, EventArgs e)
        {
            options.IncludeNumberingSystems = cbxIncludeNumeringSystems.Checked;
        }

        private void cbxIncludeOrdinalRuleSets_CheckedChanged(object sender, EventArgs e)
        {
            options.IncludeOrdinalRuleSets = cbxIncludeOrdinalRuleSets.Checked;
        }

        private void cbxIncludeParentCultures_CheckedChanged(object sender, EventArgs e)
        {
            options.IncludeParentCultures = cbxIncludeParentCultures.Checked;
        }

        private void cbxIncludePluralRuleSets_CheckedChanged(object sender, EventArgs e)
        {
            options.IncludePluralRuleSets = cbxIncludePluralRuleSets.Checked;
        }

        private void cbxIncludePostcodeRegexes_CheckedChanged(object sender, EventArgs e)
        {
            options.IncludePostcodeRegexes = cbxIncludePostcodeRegexes.Checked;
        }

        private void cbxIncludeReferences_CheckedChanged(object sender, EventArgs e)
        {
            options.IncludeReferences = cbxIncludeReferences.Checked;
        }

        private void cbxIncludeRegionCodes_CheckedChanged(object sender, EventArgs e)
        {
            options.IncludeRegionCodes = cbxIncludeRegionCodes.Checked;
        }

        private void cbxIncludeRegionGroups_CheckedChanged(object sender, EventArgs e)
        {
            options.IncludeRegionGroups = cbxIncludeRegionGroups.Checked;
        }

        private void cbxIncludeRegionInformations_CheckedChanged(object sender, EventArgs e)
        {
            options.IncludeRegionInformations = cbxIncludeRegionInformations.Checked;
        }

        private void cbxIncludeTimeZones_CheckedChanged(object sender, EventArgs e)
        {
            options.IncludeTimeZones = cbxIncludeTimeZones.Checked;
        }

        private void cbxIncludeWeekData_CheckedChanged(object sender, EventArgs e)
        {
            options.IncludeWeekData = cbxIncludeWeekData.Checked;
        }

        private void cbxIncludeWindowsMetaTimeZones_CheckedChanged(object sender, EventArgs e)
        {
            options.IncludeWindowsMetaTimeZones = cbxIncludeWindowsMetaTimeZones.Checked;
        }

        private void cbxIncludeLanguageDisplayNames_CheckedChanged(object sender, EventArgs e)
        {
            options.CultureOptions.IncludeLanguageDisplayNames = cbxIncludeLanguageDisplayNames.Checked;
        }

        private void cbxIncludeRegionDisplayNames_CheckedChanged(object sender, EventArgs e)
        {
            options.CultureOptions.IncludeRegionDisplayNames = cbxIncludeRegionDisplayNames.Checked;
        }

        private void cbxIncludeScriptDisplayNames_CheckedChanged(object sender, EventArgs e)
        {
            options.CultureOptions.IncludeScriptDisplayNames = cbxIncludeScriptDisplayNames.Checked;
        }

        private void cbxIncludeCasing_CheckedChanged(object sender, EventArgs e)
        {
            options.CultureOptions.IncludeCasing = cbxIncludeCasing.Checked;
        }

        private void cbxIncludeDates_CheckedChanged(object sender, EventArgs e)
        {
            options.CultureOptions.IncludeDates = cbxIncludeDates.Checked;
        }

        private void cbxIncludeLayouts_CheckedChanged(object sender, EventArgs e)
        {
            options.CultureOptions.IncludeLayout = cbxIncludeLayouts.Checked;
        }

        private void cbxIncludeMessages_CheckedChanged(object sender, EventArgs e)
        {
            options.CultureOptions.IncludeMessages = cbxIncludeMessages.Checked;
        }

        private void cbxIncludeNumbers_CheckedChanged(object sender, EventArgs e)
        {
            options.CultureOptions.IncludeNumbers = cbxIncludeNumbers.Checked;
        }

        private void cbxIncludeRuleBasedNumberFormatting_CheckedChanged(object sender, EventArgs e)
        {
            options.CultureOptions.IncludeRuleBasedNumberFormatting = cbxIncludeRuleBasedNumberFormatting.Checked;
        }

        private void cbxIncludeRegionTelephoneCodes_CheckedChanged(object sender, EventArgs e)
        {
            options.IncludeRegionTelephoneCodes = cbxIncludeRegionTelephoneCodes.Checked;
        }

        private void cbxIncludeCharacters_CheckedChanged(object sender, EventArgs e)
        {
            options.CultureOptions.IncludeCharacters = cbxIncludeCharacters.Checked;
        }

        private void cbxIncludeDelimiters_CheckedChanged(object sender, EventArgs e)
        {
            options.CultureOptions.IncludeDelimiters = cbxIncludeDelimiters.Checked;
        }

        private void cbxIncludeListPatterns_CheckedChanged(object sender, EventArgs e)
        {
            options.CultureOptions.IncludeListPatterns = cbxIncludeListPatterns.Checked;
        }

        private void cbxIncludeUnitPatternSets_CheckedChanged(object sender, EventArgs e)
        {
            options.CultureOptions.IncludeUnitPatternSets = cbxIncludeUnitPatternSets.Checked;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAllCultures.Checked)
            {
                options.CultureOptions.CultureSelection = CultureSelection.All;
            }
            else if (rbIncludeOnly.Checked)
            {
                options.CultureOptions.CultureSelection = CultureSelection.IncludeOnly;
            }
            else if (rbExclude.Checked)
            {
                options.CultureOptions.CultureSelection = CultureSelection.AllExceptExclude;
            }
            else if (rbAllNewCultures.Checked)
            {
                options.CultureOptions.CultureSelection = CultureSelection.AllNew;
            }

            clbCultures.Visible = rbIncludeOnly.Checked || rbExclude.Checked;
            if (clbCultures.Items.Count == 0 && clbCultures.Visible)
            {
                if (!IsCldrPath(tbxCldrPath.Text))
                {
                    MessageBox.Show("The CheckListBox cannot be populated with cultures at the moment because the CLDR path is incorrect");
                }
                else
                {
                    // populate the CheckListBox with CLDR cultures
                    PopulateCheckListBox();
                }
            }

            clbCultures_SelectedValueChanged(null, null);
        }

        private bool IsCldrPath(string cldrPath)
        {
            string aaCultureFile = Path.Combine(cldrPath, @"common\main\aa.xml");
            return File.Exists(aaCultureFile);
        }

        private void PopulateCheckListBox()
        {
            clbCultures.Items.Clear();
            string[] cultureNames = GetCultureNames();
            foreach (string cultureName in cultureNames)
            {
                clbCultures.Items.Add(cultureName);
            }
        }

        private string[] GetCultureNames()
        {
            string[] cldrCultureNames = GetFilenames(@"common\main");
            List<string> dotNetCultureNames = new List<string>();
            foreach (string cldrCultureName in cldrCultureNames)
            {
                dotNetCultureNames.Add(GetDotNetCultureName(cldrCultureName));
            }

            return dotNetCultureNames.ToArray();
        }

        private string[] GetFilenames(string folderName)
        {
            string path = Path.Combine(tbxCldrPath.Text, folderName);
            string[] xmlFilenames = Directory.GetFiles(path, "*.xml");
            List<string> filenames = new List<string>();
            foreach (string xmlFilename in xmlFilenames)
            {
                filenames.Add(Path.GetFileNameWithoutExtension(xmlFilename));
            }

            return filenames.ToArray();
        }

        private static string GetDotNetCultureName(string cldrCultureName)
        {
            if (cldrCultureName.IndexOf("_") > 0)
            {
                return cldrCultureName.Replace("_", "-");
            }

            return cldrCultureName;
        }

        private void btnBuild_Click(object sender, EventArgs e)
        {
            if (!IsCldrPath(tbxCldrPath.Text))
            {
                MessageBox.Show("The CLDR path does not contain any CLDR files");
            }
            else if (!Directory.Exists(tbxNCldrPath.Text))
            {
                MessageBox.Show("The NCLDR output path does not exist");
            }
            else
            {
                previousSection = null;
                INCldrFileDataSource ncldrFileDataSource = this.GetNewNCldrDataSource();
                ncldrFileDataSource.NCldrDataPath = tbxNCldrPath.Text;
                if (!ncldrFileDataSource.Exists() || MessageBox.Show("The NCLDR data file exists - overwrite it ?", "NCLDR Builder", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    tbxProgress.Text = String.Empty;
                    
                    NCldrBuilder.Build(
                        tbxCldrPath.Text, 
                        ncldrFileDataSource, 
                        new NCldrBuilderProgressEventHandler(Progress),
                        this.options);

                    Progress("Done.");
                }
            }
        }

        private INCldrFileDataSource GetNewNCldrDataSource()
        {
            if (rbJson.Checked)
            {
                return new NCldrJsonFileDataSource();
            }
            else if (rbXml.Checked)
            {
                return new NCldrXmlFileDataSource();
            }

            return new NCldrBinaryFileDataSource();
        }

        private string previousSection;

        private void Progress(object sender, NCldrBuilderProgressEventArgs args)
        {
            if (args.ProgressEventType != ProgressEventType.Added)
            {
                if (args.Section != previousSection)
                {
                    Console.WriteLine(String.Empty);
                    if (args.ProgressEventType == ProgressEventType.Adding)
                    {
                        Progress(args.Section + "s...");
                    }
                    else
                    {
                        Progress(args.Section + "...");
                    }
                }

                previousSection = args.Section;

                Application.DoEvents();
            }
        }

        private void Progress(string text)
        {
            tbxProgress.Text += text + System.Environment.NewLine;
            tbxProgress.SelectionStart = tbxProgress.Text.Length;
            tbxProgress.ScrollToCaret();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!File.Exists(tbxConfigFilename.Text) || MessageBox.Show("The NCLDR config file exists - overwrite it ?", "NCLDR Builder", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.options.Save(tbxConfigFilename.Text);
                MessageBox.Show("Config file saved", "NCLDR Builder");
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (!File.Exists(tbxConfigFilename.Text))
            {
                MessageBox.Show("The config file does not exist", "NCLDR Builder");
            }
            else
            {
                try
                {
                    NCldrBuilderOptions builderOptions = NCldrBuilderOptions.Load(tbxConfigFilename.Text);
                    UpdateBuilderOptions(builderOptions);

                    MessageBox.Show("Config file loaded", "NCLDR Builder");
                }
                catch (Exception exception)
                {
                    MessageBox.Show(String.Format("Unable to load config file ({0})", exception.Message), "NCLDR Builder");
                }
            }
        }

        private void UpdateBuilderOptions(NCldrBuilderOptions builderOptions)
        {
            this.options = builderOptions;

            cbxIncludeCultureNames.Checked = options.IncludeCultureNames;
            cbxIncludeCalendarPreferences.Checked = options.IncludeCalendarPreferences;
            cbxIncludeCharacterFallbacks.Checked = options.IncludeCharacterFallbacks;
            cbxIncludeCultures.Checked = options.IncludeCultures;
            cbxIncludeCurrencies.Checked = options.IncludeCurrencies;
            cbxIncludeCurrencyFractions.Checked = options.IncludeCurrencyFractions;
            cbxIncludeCalendarTypes.Checked = options.IncludeCalendarTypes;
            cbxIncludeDayPeriodRuleSets.Checked = options.IncludeDayPeriodRuleSets;
            cbxIncludeGenderLists.Checked = options.IncludeGenderLists;
            cbxIncludeLanguageMatches.Checked = options.IncludeLanguageMatches;
            cbxIncludeLikelySubTags.Checked = options.IncludeLikelySubTags;
            cbxIncludeMeasurementData.Checked = options.IncludeMeasurementData;
            cbxIncludeMetaTimeZones.Checked = options.IncludeMetaTimeZones;
            cbxIncludeNumeringSystems.Checked = options.IncludeNumberingSystems;
            cbxIncludeOrdinalRuleSets.Checked = options.IncludeOrdinalRuleSets;
            cbxIncludeParentCultures.Checked = options.IncludeParentCultures;
            cbxIncludePluralRuleSets.Checked = options.IncludePluralRuleSets;
            cbxIncludePostcodeRegexes.Checked = options.IncludePostcodeRegexes;
            cbxIncludeReferences.Checked = options.IncludeReferences;
            cbxIncludeRegionCodes.Checked = options.IncludeRegionCodes;
            cbxIncludeRegionGroups.Checked = options.IncludeRegionGroups;
            cbxIncludeRegionInformations.Checked = options.IncludeRegionInformations;
            cbxIncludeRegionTelephoneCodes.Checked = options.IncludeRegionTelephoneCodes;
            cbxIncludeTimeData.Checked = options.IncludeTimeData;
            cbxIncludeTimeZones.Checked = options.IncludeTimeZones;
            cbxIncludeWeekData.Checked = options.IncludeWeekData;
            cbxIncludeWindowsMetaTimeZones.Checked = options.IncludeWindowsMetaTimeZones;
            cbxIncludeLanguageDisplayNames.Checked = options.CultureOptions.IncludeLanguageDisplayNames;
            cbxIncludeRegionDisplayNames.Checked = options.CultureOptions.IncludeRegionDisplayNames;
            cbxIncludeScriptDisplayNames.Checked = options.CultureOptions.IncludeScriptDisplayNames;
            cbxIncludeCasing.Checked = options.CultureOptions.IncludeCasing;
            cbxIncludeCharacters.Checked = options.CultureOptions.IncludeCharacters;
            cbxIncludeDates.Checked = options.CultureOptions.IncludeDates;
            cbxIncludeDelimiters.Checked = options.CultureOptions.IncludeDelimiters;
            cbxIncludeLayouts.Checked = options.CultureOptions.IncludeLayout;
            cbxIncludeListPatterns.Checked = options.CultureOptions.IncludeListPatterns;
            cbxIncludeMessages.Checked = options.CultureOptions.IncludeMessages;
            cbxIncludeNumbers.Checked = options.CultureOptions.IncludeNumbers;
            cbxIncludeRuleBasedNumberFormatting.Checked = options.CultureOptions.IncludeRuleBasedNumberFormatting;
            cbxIncludeUnitPatternSets.Checked = options.CultureOptions.IncludeUnitPatternSets;

            if (options.CultureOptions.CultureSelection == CultureSelection.All)
            {
                rbAllCultures.Checked = true;
                clbCultures.Items.Clear();
            }
            else if (options.CultureOptions.CultureSelection == CultureSelection.AllExceptExclude)
            {
                string[] cultures = options.CultureOptions.ExcludeCultures;
                rbExclude.Checked = true;
                options.CultureOptions.ExcludeCultures = cultures;
                SetCheckedItems(options.CultureOptions.ExcludeCultures);
            }
            else if (options.CultureOptions.CultureSelection == CultureSelection.IncludeOnly)
            {
                string[] cultures = options.CultureOptions.IncludeCultures;
                rbIncludeOnly.Checked = true;
                options.CultureOptions.IncludeCultures = cultures;
                SetCheckedItems(options.CultureOptions.IncludeCultures);
            }
            else if (options.CultureOptions.CultureSelection == CultureSelection.AllNew)
            {
                rbAllNewCultures.Checked = true;
                clbCultures.Items.Clear();
            }
        }

        private void SetCheckedItems(string[] checkedItems)
        {
            // clear all existing checked items
            foreach (int index in clbCultures.CheckedIndices)
            {
                clbCultures.SetItemChecked(index, false);
            }

            // check the new items
            foreach (string checkedItem in checkedItems)
            {
                int index = clbCultures.Items.IndexOf(checkedItem);
                if (index > -1)
                {
                    clbCultures.SetItemChecked(index, true);
                }
            }
        }

        private void clbCultures_SelectedValueChanged(object sender, EventArgs e)
        {
            string[] selectedCultures = GetSelectedCultures();
            if (rbExclude.Checked)
            {
                options.CultureOptions.ExcludeCultures = selectedCultures;
                options.CultureOptions.IncludeCultures = null;
            }
            else if (rbIncludeOnly.Checked)
            {
                options.CultureOptions.IncludeCultures = selectedCultures;
                options.CultureOptions.ExcludeCultures = null;
            }
        }

        private string[] GetSelectedCultures()
        {
            string[] selectedCultures = new string[clbCultures.CheckedItems.Count];
            clbCultures.CheckedItems.CopyTo(selectedCultures, 0);
            return selectedCultures;
        }

        private void btnSelectInputPath_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = tbxCldrPath.Text;
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                tbxCldrPath.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void btnSelectOutputPath_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = tbxNCldrPath.Text;
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                tbxNCldrPath.Text = folderBrowserDialog.SelectedPath;
            }
        }
    }
}
