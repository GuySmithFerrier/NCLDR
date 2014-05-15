using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;
using NCldr;
using NCldr.Extensions;
using NCldr.Types;

namespace NCldrExplorer
{
    public partial class Form1 : Form
    {
        private Hashtable tabPagesVisited = new Hashtable();

        public Form1()
        {
            InitializeComponent();
        }

        public Form1(string[] args)
        {
            InitializeComponent();

            if (args.GetLength(0) > 0 && Directory.Exists(args[0]))
            {
                tbxNCldrDataPath.Text = args[0];

                if (args.GetLength(0) > 1)
                {
                    string dataSourceName = args[1];
                    if (string.Compare(dataSourceName, "Binary", StringComparison.InvariantCultureIgnoreCase) == 0)
                    {
                        rbBinary.Checked = true;
                    }
                    else if (string.Compare(dataSourceName, "Json", StringComparison.InvariantCultureIgnoreCase) == 0)
                    {
                        rbJson.Checked = true;
                    }
                    else if (string.Compare(dataSourceName, "XML", StringComparison.InvariantCultureIgnoreCase) == 0)
                    {
                        rbXml.Checked = true;
                    }
                }

                btnLoadNCldrData_Click(this, null);
            }
        }

        private void btnLoadNCldrData_Click(object sender, EventArgs e)
        {
            lblLoading.Visible = true;
            Application.DoEvents();

            INCldrFileDataSource ncldrFileDataSource = this.GetNewNCldrDataSource();
            ncldrFileDataSource.NCldrDataPath = tbxNCldrDataPath.Text;
            INCldrData ncldrData = ncldrFileDataSource.Load();
            if (ncldrData == null)
            {
                MessageBox.Show("The NCLDR data file cannot be found");
            }
            else
            {
                NCldr.NCldr.NCldrData = ncldrData;

                lblLoading.Visible = false;

                foreach (string culture in NCldr.NCldr.CultureNames)
                {
                    lbxCultures.Items.Add(culture);
                }

                if (lbxCultures.Items.Count > 0)
                {
                    lbxCultures.SelectedIndex = 0;
                }

                tabControl.SelectedIndex = 1;
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

        private void AddPluralRuleSets()
        {
            lbxPluralRuleSets.DisplayMember = "CultureNames";
            lbxPluralRuleSets.Items.Clear();
            PluralRuleSet[] pluralRuleSets = NCldr.NCldr.PluralRuleSets;
            foreach (PluralRuleSet pluralRuleSet in pluralRuleSets)
            {
                lbxPluralRuleSets.Items.Add(new PluralRuleSetDisplay
                {
                    CultureNames = String.Join(" ", pluralRuleSet.CultureNames),
                    PluralRuleSet = pluralRuleSet
                });
            }

            if (lbxPluralRuleSets.Items.Count > 0)
            {
                lbxPluralRuleSets.SelectedIndex = 0;
            }
        }

        private void AddOrdinalRuleSets()
        {
            lbxOrdinalRuleSets.DisplayMember = "CultureNames";
            lbxOrdinalRuleSets.Items.Clear();
            PluralRuleSet[] ordinalRuleSets = NCldr.NCldr.OrdinalRuleSets;
            foreach (PluralRuleSet ordinalRuleSet in ordinalRuleSets)
            {
                lbxOrdinalRuleSets.Items.Add(new PluralRuleSetDisplay
                {
                    CultureNames = String.Join(" ", ordinalRuleSet.CultureNames),
                    PluralRuleSet = ordinalRuleSet
                });
            }

            if (lbxOrdinalRuleSets.Items.Count > 0)
            {
                lbxOrdinalRuleSets.SelectedIndex = 0;
            }
        }

        private void AddPostalCodes()
        {
            lbxPostalCodeRegions.DisplayMember = "RegionId";
            lbxPostalCodeRegions.Items.Clear();
            PostcodeRegex[] postcodeRegexes = NCldr.NCldr.PostcodeRegexes;
            foreach (PostcodeRegex postcodeRegex in postcodeRegexes)
            {
                lbxPostalCodeRegions.Items.Add(postcodeRegex);
            }

            if (lbxPostalCodeRegions.Items.Count > 0)
            {
                lbxPostalCodeRegions.SelectedIndex = 0;
            }
        }

        private void AddTelephoneCodes()
        {
            lbxTelephoneCodeRegions.DisplayMember = "RegionId";
            lbxTelephoneCodeRegions.Items.Clear();
            RegionTelephoneCode[] telephoneCodes = NCldr.NCldr.RegionTelephoneCodes;
            foreach (RegionTelephoneCode telephoneCode in telephoneCodes)
            {
                lbxTelephoneCodeRegions.Items.Add(telephoneCode);
            }

            if (lbxTelephoneCodeRegions.Items.Count > 0)
            {
                lbxTelephoneCodeRegions.SelectedIndex = 0;
            }
        }

        private void AddDayPeriods()
        {
            lbxDayPeriodRuleSets.DisplayMember = "CultureNames";
            lbxDayPeriodRuleSets.Items.Clear();
            DayPeriodRuleSet[] dayPeriodRuleSets = NCldr.NCldr.DayPeriodRuleSets;
            foreach (DayPeriodRuleSet dayPeriodRuleSet in dayPeriodRuleSets)
            {
                lbxDayPeriodRuleSets.Items.Add(new DayPeriodRuleSetDisplay
                {
                    CultureNames = String.Join(" ", dayPeriodRuleSet.CultureNames),
                    DayPeriodRuleSet = dayPeriodRuleSet
                });
            }

            if (lbxDayPeriodRuleSets.Items.Count > 0)
            {
                lbxDayPeriodRuleSets.SelectedIndex = 0;
            }
        }

        private void AddNumberingSystems()
        {
            lbxNumberingSystems.DisplayMember = "Id";
            lbxNumberingSystems.Items.Clear();
            NumberingSystemType[] numberingSystems = NCldr.NCldr.NumberingSystems;
            foreach (NumberingSystemType numberingSystem in numberingSystems)
            {
                lbxNumberingSystems.Items.Add(numberingSystem);
            }

            if (lbxNumberingSystems.Items.Count > 0)
            {
                lbxNumberingSystems.SelectedIndex = 0;
            }
        }

        private void lbxCultures_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cultureName = lbxCultures.Items[lbxCultures.SelectedIndex].ToString();
            Culture culture = Culture.GetCulture(cultureName);
            tbxLanguage.Text = culture.Identity.Language.Id;
            tbxLanguageEnglish.Text = culture.Identity.Language.EnglishName;
            tbxLanguageNative.Text = culture.Identity.Language.NativeName;

            if (culture.Layout == null || culture.Layout.Orientation == null || !culture.Layout.Orientation.IsRightToLeft)
            {
                tbxLanguageNative.RightToLeft = RightToLeft.No;
                tbxRegionNative.RightToLeft = RightToLeft.No;
                tbxScriptNative.RightToLeft = RightToLeft.No;
            }
            else
            {
                tbxLanguageNative.RightToLeft = RightToLeft.Yes;
                tbxRegionNative.RightToLeft = RightToLeft.Yes;
                tbxScriptNative.RightToLeft = RightToLeft.Yes;
            }

            if (culture.Identity.Region == null)
            {
                tbxRegion.Text = String.Empty;
                tbxRegionEnglish.Text = String.Empty;
                tbxRegionNative.Text = String.Empty;
            }
            else
            {
                tbxRegion.Text = culture.Identity.Region.Id;
                tbxRegionEnglish.Text = culture.Identity.Region.EnglishName;
                tbxRegionNative.Text = culture.Identity.Region.DisplayName(culture.Identity.Language.Id);
            }

            if (culture.Identity.Script == null)
            {
                tbxScript.Text = String.Empty;
                tbxScriptEnglish.Text = String.Empty;
                tbxScriptNative.Text = String.Empty;
            }
            else
            {
                tbxScript.Text = culture.Identity.Script.Id;
                tbxScriptEnglish.Text = culture.Identity.Script.EnglishName;
                tbxScriptNative.Text = culture.Identity.Script.DisplayName(culture.Identity.Language.Id);
            }

            if (culture.Identity.Variant == null)
            {
                tbxVariant.Text = String.Empty;
            }
            else
            {
                tbxVariant.Text = culture.Identity.Variant.Id;
            }

            ShowDisplayNames<LanguageDisplayName>(lbxLanguageDisplayNames, culture.LanguageDisplayNames);
            ShowDisplayNames<RegionDisplayName>(lbxRegionDisplayNames, culture.RegionDisplayNames);
            ShowDisplayNames<ScriptDisplayName>(lbxScriptDisplayNames, culture.ScriptDisplayNames);

            ShowCalendars(culture.Dates);

            ShowCasing(culture.Casing);

            ShowCharacters(culture.Characters);

            ShowDelimiters(culture.Delimiters);

            ShowLayout(culture.Layout);

            ShowListPatterns(culture.ListPatterns);

            ShowMessages(culture.Messages);

            ShowNumbers(culture.Numbers);

            ShowRuleBasedNumberFormatting(culture.RuleBasedNumberFormatting);

            ShowUnitPatternSets(culture.UnitPatternSets);
        }

        private void ShowNumbers(Numbers numbers)
        {
            dgvNumbersNumberingSystemIds.DataSource = null;
            dgvCultureCurrencyNames.DataSource = null;

            tbxNumbersDefaultNumberingSystemId.Text = String.Empty;

            dgvCurrencyDisplayNameSets.DataSource = null;

            dgvCurrencyPeriods.DataSource = null;

            if (numbers != null)
            {
                tbxNumbersDefaultNumberingSystemId.Text = numbers.DefaultNumberingSystemId;

                List<NumberingSystemId> numberingSystemIds = new List<NumberingSystemId>();
                foreach (OtherNumberingSystem otherNumberingSystem in numbers.OtherNumberingSystems)
                {
                    NumberingSystem numberingSystem = (from ns in numbers.NumberingSystems
                                                       where ns.Id == otherNumberingSystem.Value
                                                       select ns).FirstOrDefault();

                    numberingSystemIds.Add(new NumberingSystemId()
                    {
                        Id = otherNumberingSystem.Id,
                        Value = otherNumberingSystem.Value,
                        NumberingSystem = numberingSystem
                    });
                }

                dgvNumbersNumberingSystemIds.DataSource = numberingSystemIds;
                dgvNumbersNumberingSystemIds.Columns[0].Width = 70;
                dgvNumbersNumberingSystemIds.Columns[1].Width = 70;
                dgvNumbersNumberingSystemIds.Columns.RemoveAt(2);

                ShowNumberingSystem(numberingSystemIds[0].NumberingSystem);

                ShowCurrencyDisplayNames(numbers.CurrencyDisplayNameSets);

                ShowCurrencyPeriods(numbers.CurrencyPeriods);
            }
        }

        private void ShowCurrencyPeriods(CurrencyPeriod[] currencyPeriods)
        {
            if (currencyPeriods != null)
            {
                dgvCurrencyPeriods.DataSource = currencyPeriods;
                dgvCurrencyPeriods.Columns.Remove("Currency");
            }
        }

        private void ShowCurrencyDisplayNames(CurrencyDisplayNameSet[] currencyDisplayNameSets)
        {
            if (currencyDisplayNameSets != null && currencyDisplayNameSets.GetLength(0) > 0)
            {
                dgvCurrencyDisplayNameSets.DataSource = currencyDisplayNameSets.OrderBy(cdns => cdns.Id).ToList();
                dgvCurrencyDisplayNameSets.Columns[0].Width = 66;
                dgvCurrencyDisplayNameSets.Columns[1].Width = 66;
            }
        }

        private void ShowRuleBasedNumberFormatting(RuleBasedNumberFormatting ruleBasedNumberFormatting)
        {
            if (ruleBasedNumberFormatting == null)
            {
                dgvOrdinalRuleSets.DataSource = null;
                dgvOrdinalRules.DataSource = null;
                dgvSpelloutRuleSets.DataSource = null;
                dgvSpelloutRules.DataSource = null;
            }
            else
            {
                dgvOrdinalRules.DataSource = null;
                if (ruleBasedNumberFormatting.OrdinalRuleSets == null ||
                    ruleBasedNumberFormatting.OrdinalRuleSets.GetLength(0) == 0)
                {
                    dgvOrdinalRuleSets.DataSource = null;
                }
                else
                {
                    dgvOrdinalRuleSets.DataSource = ruleBasedNumberFormatting.OrdinalRuleSets;
                }

                dgvSpelloutRules.DataSource = null;
                if (ruleBasedNumberFormatting.SpelloutRuleSets == null ||
                    ruleBasedNumberFormatting.SpelloutRuleSets.GetLength(0) == 0)
                {
                    dgvSpelloutRuleSets.DataSource = null;
                }
                else
                {
                    dgvSpelloutRuleSets.DataSource = ruleBasedNumberFormatting.SpelloutRuleSets;
                }
            }
        }

        private void ShowUnitPatternSets(UnitPatternSet[] unitPatternSets)
        {
            lbxUnitPatternSetIds.Items.Clear();
            if (unitPatternSets == null || unitPatternSets.GetLength(0) == 0)
            {
                dgvUnitPatterns.DataSource = null;
            }
            else
            {
                lbxUnitPatternSetIds.Items.AddRange(unitPatternSets);
                lbxUnitPatternSetIds.DisplayMember = "Id";
                lbxUnitPatternSetIds.SelectedIndex = 0;
            }
        }

        private void ShowMessages(MessageSet messages)
        {
            if (messages == null)
            {
                dgvMessages.DataSource = null;

                tbxMessagesYes.Text = String.Empty;
                tbxMessagesY.Text = String.Empty;
                tbxMessagesNo.Text = String.Empty;
                tbxMessagesN.Text = String.Empty;
            }
            else
            {
                dgvMessages.DataSource = messages.Messages;

                tbxMessagesYes.Text = messages.Yes;
                tbxMessagesY.Text = messages.YesShort;
                tbxMessagesNo.Text = messages.No;
                tbxMessagesN.Text = messages.NoShort;
            }
        }

        private void ShowLayout(Layout layout)
        {
            if (layout == null || layout.Orientation == null)
            {
                tbxOrientationCharacters.Text = String.Empty;
                tbxOrientationLines.Text = String.Empty;
            }
            else
            {
                tbxOrientationCharacters.Text = layout.Orientation.CharacterOrder;
                tbxOrientationLines.Text = layout.Orientation.LineOrder;
            }
        }

        private void ShowListPatterns(ListPattern[] listPatterns)
        {
            if (listPatterns == null || listPatterns.GetLength(0) == 0)
            {
                dgvListPatterns.DataSource = null;
            }
            else
            {
                dgvListPatterns.DataSource = listPatterns;
            }
        }

        private void ShowCalendars(Dates dates)
        {
            lbxCalendars.Items.Clear();

            if (dates == null)
            {
                tbxCalendarsDefault.Text = String.Empty;
            }
            else
            {
                if (dates.DefaultCalendarId == null)
                {
                    tbxCalendarsDefault.Text = String.Empty;
                }
                else
                {
                    tbxCalendarsDefault.Text = dates.DefaultCalendarId;
                }

                if (dates.Calendars != null && dates.Calendars.GetLength(0) > 0)
                {
                    lbxCalendars.DisplayMember = "Id";
                    lbxCalendars.Items.AddRange(dates.Calendars);
                    lbxCalendars.SelectedIndex = 0;
                }

                if (dates.DisplayNames == null)
                {
                    tbxCalendarEra.Text = String.Empty;
                    tbxCalendarYear.Text = String.Empty;
                    tbxCalendarMonth.Text = String.Empty;
                    tbxCalendarDay.Text = String.Empty;
                    tbxCalendarYesterday.Text = String.Empty;
                    tbxCalendarToday.Text = String.Empty;
                    tbxCalendarTomorrow.Text = String.Empty;
                    tbxCalendarWeek.Text = String.Empty;
                    tbxCalendarWeekDay.Text = String.Empty;
                    tbxCalendarDayPeriod.Text = String.Empty;
                    tbxCalendarHour.Text = String.Empty;
                    tbxCalendarMinute.Text = String.Empty;
                    tbxCalendarSecond.Text = String.Empty;
                    tbxCalendarZone.Text = String.Empty;

                    dgvDayFutureRelativeTimeRules.DataSource = null;
                    dgvDayPastRelativeTimeRules.DataSource = null;
                    dgvWeekFutureRelativeTimeRules.DataSource = null;
                    dgvWeekPastRelativeTimeRules.DataSource = null;
                    dgvMonthFutureRelativeTimeRules.DataSource = null;
                    dgvMonthPastRelativeTimeRules.DataSource = null;
                    dgvYearFutureRelativeTimeRules.DataSource = null;
                    dgvYearPastRelativeTimeRules.DataSource = null;
                    dgvSecondFutureRelativeTimeRules.DataSource = null;
                    dgvSecondPastRelativeTimeRules.DataSource = null;
                    dgvMinuteFutureRelativeTimeRules.DataSource = null;
                    dgvMinutePastRelativeTimeRules.DataSource = null;
                    dgvHourFutureRelativeTimeRules.DataSource = null;
                    dgvHourPastRelativeTimeRules.DataSource = null;
                }
                else
                {
                    tbxCalendarEra.Text = dates.DisplayNames.Era;
                    tbxCalendarYear.Text = dates.DisplayNames.Year;
                    tbxCalendarMonth.Text = dates.DisplayNames.Month;
                    tbxCalendarDay.Text = dates.DisplayNames.Day;
                    tbxCalendarYesterday.Text = dates.DisplayNames.Yesterday;
                    tbxCalendarToday.Text = dates.DisplayNames.Today;
                    tbxCalendarTomorrow.Text = dates.DisplayNames.Tomorrow;
                    tbxCalendarWeek.Text = dates.DisplayNames.Week;
                    tbxCalendarWeekDay.Text = dates.DisplayNames.WeekDay;
                    tbxCalendarDayPeriod.Text = dates.DisplayNames.DayPeriod;
                    tbxCalendarHour.Text = dates.DisplayNames.Hour;
                    tbxCalendarMinute.Text = dates.DisplayNames.Minute;
                    tbxCalendarSecond.Text = dates.DisplayNames.Second;
                    tbxCalendarZone.Text = dates.DisplayNames.Zone;

                    SetRelativeTimeRules(dgvDayFutureRelativeTimeRules, dates.DisplayNames.DayFutureRelativeTimeRules);
                    SetRelativeTimeRules(dgvDayPastRelativeTimeRules, dates.DisplayNames.DayPastRelativeTimeRules);
                    SetRelativeTimeRules(dgvWeekFutureRelativeTimeRules, dates.DisplayNames.WeekFutureRelativeTimeRules);
                    SetRelativeTimeRules(dgvWeekPastRelativeTimeRules, dates.DisplayNames.WeekPastRelativeTimeRules);
                    SetRelativeTimeRules(dgvMonthFutureRelativeTimeRules, dates.DisplayNames.MonthFutureRelativeTimeRules);
                    SetRelativeTimeRules(dgvMonthPastRelativeTimeRules, dates.DisplayNames.MonthPastRelativeTimeRules);
                    SetRelativeTimeRules(dgvYearFutureRelativeTimeRules, dates.DisplayNames.YearFutureRelativeTimeRules);
                    SetRelativeTimeRules(dgvYearPastRelativeTimeRules, dates.DisplayNames.YearPastRelativeTimeRules);
                    SetRelativeTimeRules(dgvSecondFutureRelativeTimeRules, dates.DisplayNames.SecondFutureRelativeTimeRules);
                    SetRelativeTimeRules(dgvSecondPastRelativeTimeRules, dates.DisplayNames.SecondPastRelativeTimeRules);
                    SetRelativeTimeRules(dgvMinuteFutureRelativeTimeRules, dates.DisplayNames.MinuteFutureRelativeTimeRules);
                    SetRelativeTimeRules(dgvMinutePastRelativeTimeRules, dates.DisplayNames.MinutePastRelativeTimeRules);
                    SetRelativeTimeRules(dgvHourFutureRelativeTimeRules, dates.DisplayNames.HourFutureRelativeTimeRules);
                    SetRelativeTimeRules(dgvHourPastRelativeTimeRules, dates.DisplayNames.HourPastRelativeTimeRules);
                }
            }
        }

        private void SetRelativeTimeRules(DataGridView dataGridView, RelativeTimeRuleSet relativeTimeRuleSet)
        {
            if (relativeTimeRuleSet == null)
            {
                dataGridView.DataSource = null;
            }
            else
            {
                dataGridView.DataSource = relativeTimeRuleSet.RelativeTimeRules;
                dataGridView.Columns[0].Width = 50;
            }
        }

        private void ShowDelimiters(Delimiters delimiters)
        {
            if (delimiters == null)
            {
                tbxCharactersQuotationStart.Text = String.Empty;;
                tbxCharactersQuotationEnd.Text = String.Empty;;
                tbxCharactersAlternateQuotationStart.Text = String.Empty;;
                tbxCharactersAlternateQuotationEnd.Text = String.Empty;;
            }
            else
            {
                tbxCharactersQuotationStart.Text = delimiters.QuotationStart;
                tbxCharactersQuotationEnd.Text = delimiters.QuotationEnd;
                tbxCharactersAlternateQuotationStart.Text = delimiters.AlternateQuotationStart;
                tbxCharactersAlternateQuotationEnd.Text = delimiters.AlternateQuotationEnd;
            }
        }

        private void ShowCharacters(Characters characters)
        {
            if (characters == null)
            {
                tbxCharactersExemplarCharacters.Text = String.Empty;
                tbxCharactersAuxiliaryExemplarCharacters.Text = String.Empty;
                tbxCharactersPunctuationExemplarCharacters.Text = String.Empty;
                tbxCharactersIndexExemplarCharacters.Text = String.Empty;

                tbxCharactersFinalEllipsis.Text = String.Empty;
                tbxCharactersInitialEllipsis.Text = String.Empty;
                tbxCharactersMedialEllipsis.Text = String.Empty;
                tbxCharactersMoreInformation.Text = String.Empty;
            }
            else
            {
                tbxCharactersExemplarCharacters.Text = String.Join(" ", characters.ExemplarCharacters);
                tbxCharactersAuxiliaryExemplarCharacters.Text = String.Join(" ", characters.AuxiliaryExemplarCharacters);
                tbxCharactersPunctuationExemplarCharacters.Text = String.Join(" ", characters.PunctuationExemplarCharacters);

                if (characters.IndexExemplarCharacters != null)
                {
                    tbxCharactersIndexExemplarCharacters.Text = String.Join(" ", characters.IndexExemplarCharacters);
                }
                else
                {
                    tbxCharactersIndexExemplarCharacters.Text = string.Empty;
                }

                tbxCharactersFinalEllipsis.Text = characters.FinalEllipsis;
                tbxCharactersInitialEllipsis.Text = characters.InitialEllipsis;
                tbxCharactersMedialEllipsis.Text = characters.MedialEllipsis;
                tbxCharactersMoreInformation.Text = characters.MoreInformation;
            }
       }

        private void ShowCasing(Casing casing)
        {
            if (casing == null)
            {
                tbxCasingCalendarField.Text = String.Empty;
                tbxCasingDayFormatExceptNarrow.Text = String.Empty;
                tbxCasingDayNarrow.Text = String.Empty;
                tbxCasingDayStandAloneExceptNarrow.Text = String.Empty;
                tbxCasingDisplayName.Text = String.Empty;
                tbxCasingDisplayNameCount.Text = String.Empty;
                tbxCasingEraAbbr.Text = String.Empty;
                tbxCasingEraName.Text = String.Empty;
                tbxCasingEraNarrow.Text = String.Empty;
                tbxCasingKey.Text = String.Empty;
                tbxCasingLanguage.Text = String.Empty;
                tbxCasingMetaZoneLong.Text = String.Empty;
                tbxCasingMetaZoneShort.Text = String.Empty;
                tbxCasingMonthFormatExceptNarrow.Text = String.Empty;
                tbxCasingMonthNarrow.Text = String.Empty;
                tbxCasingMonthStandAloneExceptNarrow.Text = String.Empty;
                tbxCasingQuarterAbbreviated.Text = String.Empty;
                tbxCasingScript.Text = String.Empty;
                tbxCasingSymbol.Text = String.Empty;
                tbxCasingRegion.Text = String.Empty;
                tbxCasingTense.Text = String.Empty;
                tbxCasingType.Text = String.Empty;
                tbxCasingZoneExemplarCity.Text = String.Empty;
            }
            else
            {
                tbxCasingCalendarField.Text = casing.CalendarField.ToString();
                tbxCasingDayFormatExceptNarrow.Text = casing.DayFormatExceptNarrow.ToString();
                tbxCasingDayNarrow.Text = casing.DayNarrow.ToString();
                tbxCasingDayStandAloneExceptNarrow.Text = casing.DayStandAloneExceptNarrow.ToString();
                tbxCasingDisplayName.Text = casing.DisplayName.ToString();
                tbxCasingDisplayNameCount.Text = casing.DisplayNameCount.ToString();
                tbxCasingEraAbbr.Text = casing.EraAbbr.ToString();
                tbxCasingEraName.Text = casing.EraName.ToString();
                tbxCasingEraNarrow.Text = casing.EraNarrow.ToString();
                tbxCasingKey.Text = casing.Key.ToString();
                tbxCasingLanguage.Text = casing.Language.ToString();
                tbxCasingMetaZoneLong.Text = casing.MetaZoneLong.ToString();
                tbxCasingMetaZoneShort.Text = casing.MetaZoneShort.ToString();
                tbxCasingMonthFormatExceptNarrow.Text = casing.MonthFormatExceptNarrow.ToString();
                tbxCasingMonthNarrow.Text = casing.MonthNarrow.ToString();
                tbxCasingMonthStandAloneExceptNarrow.Text = casing.MonthStandAloneExceptNarrow.ToString();
                tbxCasingQuarterAbbreviated.Text = casing.QuarterAbbreviated.ToString();
                tbxCasingScript.Text = casing.Script.ToString();
                tbxCasingSymbol.Text = casing.Symbol.ToString();
                tbxCasingRegion.Text = casing.Region.ToString();
                tbxCasingTense.Text = casing.Tense.ToString();
                tbxCasingType.Text = casing.Type.ToString();
                tbxCasingZoneExemplarCity.Text = casing.ZoneExemplarCity.ToString();
            }
        }

        private void AddDotNetCultures()
        {
            tbxDotNetNeutralCultures.Text = CultureInfo.GetCultures(CultureTypes.NeutralCultures).Count().ToString();
            tbxDotNetSpecificCultures.Text = CultureInfo.GetCultures(CultureTypes.SpecificCultures).Count().ToString();
            tbxDotNetTotalCultures.Text = CultureInfo.GetCultures(CultureTypes.AllCultures).Count().ToString();

            AddDotNetCulturesToListBox(false);
        }

        private void AddDotNetCulturesToListBox(bool uniqueOnly)
        {
            lbxDotNetCultures.Items.Clear();
            List<string> dotNetCultureNames = new List<string>();
            foreach (CultureInfo cultureInfo in CultureInfo.GetCultures(CultureTypes.AllCultures))
            {
                dotNetCultureNames.Add(cultureInfo.Name);
            }

            dotNetCultureNames.Sort();

            foreach (string dotNetCultureName in dotNetCultureNames)
            {
                string listBoxCultureName = dotNetCultureName;
                bool isUnique = Culture.GetCulture(dotNetCultureName) == null;
                if (!isUnique)
                {
                    listBoxCultureName += " *";
                }

                if (!uniqueOnly || isUnique)
                {
                    lbxDotNetCultures.Items.Add(listBoxCultureName);
                }
            }
        }

        private void AddNCldrCultures()
        {
            tbxNCldrNeutralCultures.Text = Culture.GetCultures(CultureTypes.NeutralCultures).Count().ToString();
            tbxNCldrSpecificCultures.Text = Culture.GetCultures(CultureTypes.SpecificCultures).Count().ToString();
            tbxNCldrTotalCultures.Text = Culture.GetCultures(CultureTypes.AllCultures).Count().ToString();

            AddNCldrCulturesToListBox(false);
        }

        private void AddNCldrCulturesToListBox(bool uniqueOnly)
        {
            AddNCldrCulturesToListBox(uniqueOnly, lbxNCldrCultures);
        }

        private void AddNCldrCulturesToListBox(bool uniqueOnly, ListBox listBox, bool excludeRoot = false)
        {
            listBox.Items.Clear();
            List<string> ncldrCultureNames = new List<string>();
            foreach (Culture culture in Culture.GetCultures(CultureTypes.AllCultures))
            {
                if (!excludeRoot || culture.Identity.CultureName != "root")
                {
                    ncldrCultureNames.Add(culture.Identity.CultureName);
                }
            }

            ncldrCultureNames.Sort();

            CultureInfo[] cultureInfos = CultureInfo.GetCultures(CultureTypes.AllCultures);
            foreach (string ncldrCultureName in ncldrCultureNames)
            {
                string listBoxCultureName = ncldrCultureName;
                bool isUnique = !IsDotNetCulture(cultureInfos, ncldrCultureName);
                if (!isUnique)
                {
                    listBoxCultureName += " *";
                }

                if (!uniqueOnly || isUnique)
                {
                    listBox.Items.Add(listBoxCultureName);
                }
            }
        }

        private bool IsDotNetCulture(CultureInfo[] cultureInfos, string cultureName)
        {
            return (from c in cultureInfos
                    where c.Name == cultureName
                    select c).Any();
        }

        private void ShowDisplayNames<T>(ListBox listBox, List<T> displayNames) where T : DisplayName
        {
            listBox.Items.Clear();
            if (displayNames != null)
            {
                foreach (DisplayName displayName in displayNames)
                {
                    listBox.Items.Add(String.Format(@"{0} ""{1}""", displayName.Id, displayName.Name));
                }
            }
        }

        private void lbxDotNetCultures_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cultureName = lbxDotNetCultures.SelectedItem.ToString();
            if (cultureName.EndsWith(" *"))
            {
                cultureName = cultureName.Substring(0, cultureName.Length - 2);
            }

            CultureInfo cultureInfo = new CultureInfo(cultureName);
            tbxDotNetCultureEnglishDisplayName.Text = cultureInfo.EnglishName;
            tbxDotNetCultureNativeDisplayName.Text = cultureInfo.NativeName;

            tbxDotNetCultureNativeDisplayName.RightToLeft = cultureInfo.TextInfo.IsRightToLeft ? RightToLeft.Yes : RightToLeft.No;

            StringBuilder builder = new StringBuilder();
            CultureInfo parentCultureInfo = cultureInfo.Parent;
            while (parentCultureInfo != CultureInfo.InvariantCulture)
            {
                builder.AppendLine(parentCultureInfo.Name);
                parentCultureInfo = parentCultureInfo.Parent;
            }

            builder.AppendLine("(InvariantCulture)");

            tbxDotNetCultureParents.Text = builder.ToString();
        }

        private void lbxNCldrCultures_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cultureName = lbxNCldrCultures.SelectedItem.ToString();
            if (cultureName.EndsWith(" *"))
            {
                cultureName = cultureName.Substring(0, cultureName.Length - 2);
            }

            Culture culture = Culture.GetCulture(cultureName);
            tbxNCldrCultureEnglishDisplayName.Text = culture.EnglishName;
            tbxNCldrCultureNativeDisplayName.Text = culture.NativeName;

            tbxNCldrCultureNativeDisplayName.RightToLeft =
                culture.Layout == null || culture.Layout.Orientation == null || !culture.Layout.Orientation.IsRightToLeft
                ? RightToLeft.No : RightToLeft.Yes;

            StringBuilder builder = new StringBuilder();
            string[] parentNames = culture.GetParentNames();
            foreach(string parentName in parentNames)
            {
                builder.AppendLine(parentName);
            }

            tbxNCldrCultureParents.Text = builder.ToString();
        }

        private void cbxShowUniqueDotNetCulturesOnly_CheckedChanged(object sender, EventArgs e)
        {
            AddDotNetCulturesToListBox(cbxShowUniqueDotNetCulturesOnly.Checked);
        }

        private void cbxShowUniqueNCldrCulturesOnly_CheckedChanged(object sender, EventArgs e)
        {
            AddNCldrCulturesToListBox(cbxShowUniqueNCldrCulturesOnly.Checked);
        }

        private void lbxPluralRuleSets_SelectedIndexChanged(object sender, EventArgs e)
        {
            PluralRuleSet pluralRuleSet = ((PluralRuleSetDisplay)lbxPluralRuleSets.SelectedItem).PluralRuleSet;
            tbxPluralRuleSetCultures.Text = String.Join(" ", pluralRuleSet.CultureNames);
            lbxPluralRuleSetRules.Items.Clear();
            foreach (PluralRule pluralRule in pluralRuleSet.PluralRules)
            {
                lbxPluralRuleSetRules.Items.Add(String.Format("{0}: {1}", pluralRule.Id.ToString(), pluralRule.Rule));
            }
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage tabPage = tabControl.SelectedTab;
            if (!tabPagesVisited.ContainsKey(tabPage))
            {
                // this TabPage has never been visited before so it needs to be initialized
                tabPagesVisited.Add(tabPage, true);
                InitializeTabPage(tabPage);
            }
        }

        private void InitializeTabPage(TabPage tabPage)
        {
            if (tabPage == this.tbpSupplemental)
            {
                this.AddDayPeriods();
                this.AddOrdinalRuleSets();
                this.AddPluralRuleSets();
                this.AddPostalCodes();
                this.AddNumberingSystems();
                this.AddTelephoneCodes();
            }
            else if (tabPage == this.tbpDotNetComparison)
            {
                this.AddDotNetCultures();
                this.AddNCldrCultures();
            }
            else if (tabPage == this.tbpCustomCultures)
            {
                this.AddCustomCultures();
            }
        }

        private void AddCustomCultures()
        {
            AddNCldrCulturesToListBox(false, clbCustomCultures, true);
            if (clbCustomCultures.Items.Count > 0)
            {
                clbCustomCultures.SelectedIndex = 0;
            }
        }

        private void btnGetPluralRules_Click(object sender, EventArgs e)
        {
            PluralRule[] pluralRules = CultureExtensions.GetPluralRules(tbxPluralRulesCultureName.Text);
            StringBuilder builder = new StringBuilder();
            foreach (PluralRule pluralRule in pluralRules)
            {
                builder.AppendLine(String.Format("{0}: {1}", pluralRule.Id.ToString(), pluralRule.Rule));
            }
            
            tbxPluralRuleResults.Text = builder.ToString();
        }

        private void btnGetPluralRuleForInteger_Click(object sender, EventArgs e)
        {
            int value;
            if (int.TryParse(tbxPluralRuleInteger.Text, out value))
            {
                PluralRule pluralRule = CultureExtensions.GetPluralRule(tbxPluralRulesCultureName.Text, value);
                if (pluralRule == null)
                    tbxPluralRuleResults.Text = "There is no rule for this integer";
                else
                    tbxPluralRuleResults.Text = String.Format("{0}: {1}", pluralRule.Id.ToString(), pluralRule.Rule);
            }
        }

        private void lbxPostalCodeRegions_SelectedIndexChanged(object sender, EventArgs e)
        {
            PostcodeRegex postcodeRegex = (PostcodeRegex)lbxPostalCodeRegions.SelectedItem;
            tbxPostalCodesRegionId.Text = postcodeRegex.RegionId;
            tbxPostalCodesRegex.Text = postcodeRegex.Regex;
        }

        private void btnGetPostalCodeRegex_Click(object sender, EventArgs e)
        {
            tbxPostalCodeGetRegex.Text = RegionExtensions.GetPostcodeRegex(tbxPostalCodeGetRegionId.Text);
        }

        private void lbxNumberingSystems_SelectedIndexChanged(object sender, EventArgs e)
        {
            NumberingSystemType numberingSystem = (NumberingSystemType)lbxNumberingSystems.SelectedItem;
            tbxNumberingSystemId.Text = numberingSystem.Id;
            tbxNumberingSystemType.Text = numberingSystem.DigitsOrRules.ToString();
            tbxNumberingSystemDigits.Text = numberingSystem.Digits;
            tbxNumberingSystemRules.Text = numberingSystem.Rules;
        }

        private void lbxOrdinalRuleSets_SelectedIndexChanged(object sender, EventArgs e)
        {
            PluralRuleSet pluralRuleSet = ((PluralRuleSetDisplay)lbxOrdinalRuleSets.SelectedItem).PluralRuleSet;
            tbxOrdinalRuleSetCultures.Text = String.Join(" ", pluralRuleSet.CultureNames);
            lbxOrdinalRuleSetRules.Items.Clear();
            foreach (PluralRule pluralRule in pluralRuleSet.PluralRules)
            {
                lbxOrdinalRuleSetRules.Items.Add(String.Format("{0}: {1}", pluralRule.Id.ToString(), pluralRule.Rule));
            }
        }

        private void btnGetOrdinalRules_Click(object sender, EventArgs e)
        {
            PluralRule[] pluralRules = CultureExtensions.GetOrdinalRules(tbxOrdinalRulesCultureName.Text);
            StringBuilder builder = new StringBuilder();
            foreach (PluralRule pluralRule in pluralRules)
            {
                builder.AppendLine(String.Format("{0}: {1}", pluralRule.Id.ToString(), pluralRule.Rule));
            }

            tbxOrdinalRuleResults.Text = builder.ToString();
        }

        private void btnGetOrdinalRuleForInteger_Click(object sender, EventArgs e)
        {
            int value;
            if (int.TryParse(tbxOrdinalRuleInteger.Text, out value))
            {
                PluralRule pluralRule = CultureExtensions.GetOrdinalRule(tbxOrdinalRulesCultureName.Text, value);
                if (pluralRule == null)
                    tbxOrdinalRuleResults.Text = "There is no rule for this integer";
                else
                    tbxOrdinalRuleResults.Text = String.Format("{0}: {1}", pluralRule.Id.ToString(), pluralRule.Rule);
            }
        }

        private void lbxDayPeriodRuleSets_SelectedIndexChanged(object sender, EventArgs e)
        {
            DayPeriodRuleSet dayPeriodRuleSet = ((DayPeriodRuleSetDisplay)lbxDayPeriodRuleSets.SelectedItem).DayPeriodRuleSet;
            tbxDayPeriodCultures.Text = String.Join(" ", dayPeriodRuleSet.CultureNames);
            lbxDayPeriodRules.Items.Clear();
            foreach (DayPeriodRule dayPeriodRule in dayPeriodRuleSet.DayPeriodRules)
            {
                lbxDayPeriodRules.Items.Add(dayPeriodRule.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DayPeriodRule[] dayPeriodRules = CultureExtensions.GetDayPeriodRules(tbxDayPeriodCulture.Text);
            StringBuilder builder = new StringBuilder();
            foreach (DayPeriodRule dayPeriodRule in dayPeriodRules)
            {
                builder.AppendLine(dayPeriodRule.ToString());
            }

            tbxDayPeriodResults.Text = builder.ToString();
        }

        private void clbCustomCultures_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cultureName = clbCustomCultures.SelectedItem.ToString();
            if (cultureName.EndsWith(" *"))
            {
                cultureName = cultureName.Substring(0, cultureName.Length - 2);
            }

            Culture culture = Culture.GetCulture(cultureName);
            tbxCustomCultureEnglishDisplayName.Text = culture.EnglishName;
            tbxCustomCultureNativeDisplayName.Text = culture.NativeName;

            tbxCustomCultureNativeDisplayName.RightToLeft =
                culture.Layout == null || culture.Layout.Orientation == null || !culture.Layout.Orientation.IsRightToLeft
                ? RightToLeft.No : RightToLeft.Yes;
        }

        private void btnCustomCulturesCheckAll_Click(object sender, EventArgs e)
        {
            for (int index = 0; index < clbCustomCultures.Items.Count; index++)
            {
                clbCustomCultures.SetItemChecked(index, true);
            }
        }

        private void btnCustomCulturesUncheckAll_Click(object sender, EventArgs e)
        {
            for (int index = 0; index < clbCustomCultures.Items.Count; index++)
            {
                clbCustomCultures.SetItemChecked(index, false);
            }
        }

        private void btnCustomCulturesCheckAllNew_Click(object sender, EventArgs e)
        {
            for (int index = 0; index < clbCustomCultures.Items.Count; index++)
            {
                string cultureName = clbCustomCultures.Items[index].ToString();
                clbCustomCultures.SetItemChecked(index, !cultureName.EndsWith(" *"));
            }
        }

        private void btnCreateLdmlFiles_Click(object sender, EventArgs e)
        {
            CreateCustomCulturesCheck(false);
        }

        private void btnRegisterCustomCultures_Click(object sender, EventArgs e)
        {
            CreateCustomCulturesCheck(true);
        }

        private void CreateCustomCulturesCheck(bool register)
        {
            string question = register ? 
                String.Format("Register {0} custom cultures ?", clbCustomCultures.CheckedItems.Count) : 
                String.Format("Create LDML files for {0} cultures ? (existing files will be overwritten)", clbCustomCultures.CheckedItems.Count);

            if (clbCustomCultures.CheckedItems.Count == 0)
            {
                MessageBox.Show("Select one or more NCLDR cultures to create .NET custom cultures from");
            }
            else if (IsCustomCultureNameConflict())
            {
                MessageBox.Show("One or more selected cultures will create a name conflict with an existing .NET culture. Use a prefix to avoid the name conflict.");
            }
            else if (IsSpecificCultureWithoutNeutralCulture() && MessageBox.Show(
                "One or more selected cultures are specific cultures that currently have no .NET parent culture." + System.Environment.NewLine + System.Environment.NewLine +
                "If you continue to create these then the specific cultures will inherit from .NET's Invariant culture." + System.Environment.NewLine + System.Environment.NewLine +
                "It is recommended that you create the required neutral cultures first and then create the specific cultures so that the specific cultures will have a suitable parent culture." + System.Environment.NewLine + System.Environment.NewLine +
                "Continue anyway ?", "NCLDR Explorer", MessageBoxButtons.YesNo) == DialogResult.No)
            {
            }
            else if (!register && !Directory.Exists(tbxCustomCultureOutputFolder.Text) &&
                MessageBox.Show("The output folder does not exist - Create it now ?", "NCLDR Explorer",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
            }
            else if (MessageBox.Show(question,
                "NCLDR Explorer", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!Directory.Exists(tbxCustomCultureOutputFolder.Text))
                {
                    Directory.CreateDirectory(tbxCustomCultureOutputFolder.Text);
                }

                CreateCustomCultures(register);
            }
        }

        private bool IsCustomCultureNameConflict()
        {
            foreach (string cultureName in clbCustomCultures.CheckedItems)
            {
                string dotNetCultureName = cultureName.EndsWith(" *") ? cultureName.Substring(0, cultureName.Length - 2) : cultureName;
                dotNetCultureName = tbxCustomCulturePrefix.Text + dotNetCultureName;

                try
                {
                    new CultureInfo(dotNetCultureName);
                    return true;
                }
                catch
                {
                }
            }

            return false;
        }

        private bool IsSpecificCultureWithoutNeutralCulture()
        {
            foreach (string cultureName in clbCustomCultures.CheckedItems)
            {
                string cldrCultureName = cultureName.EndsWith(" *") ? cultureName.Substring(0, cultureName.Length - 2) : cultureName;
                Culture culture = Culture.GetCulture(cldrCultureName);
                if (!culture.IsNeutralCulture)
                {
                    string dotNetParentCultureName = culture.GetParentName();
                    try
                    {
                        new CultureInfo(dotNetParentCultureName);
                    }
                    catch
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private void CreateCustomCultures(bool register)
        {
            tbxCustomCultureProgress.Text = String.Empty;
            gbxCustomCultureProgress.Visible = true;

            foreach (string checkedCldrCultureName in clbCustomCultures.CheckedItems)
            {
                string cldrCultureName = checkedCldrCultureName;
                if (cldrCultureName.EndsWith(" *"))
                {
                    cldrCultureName = cldrCultureName.Substring(0, cldrCultureName.Length - 2);
                }

                string dotNetCultureName = tbxCustomCulturePrefix.Text + cldrCultureName;

                if (register)
                {
                    CustomCultureProgress(String.Format("Registering culture {0}...", cldrCultureName));

                    CultureAndRegionInfoBuilder builder =
                        NCldrCustomCulture.CreateNCldrCultureAndRegionInfoBuilder(cldrCultureName, dotNetCultureName);
                    try
                    {
                        builder.Register();
                    }
                    catch (UnauthorizedAccessException)
                    {
                        MessageBox.Show("To register custom cultures this application must be run as Administrator");
                        break;
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(String.Format("Custom culture registration failed ({0})", exception.Message));
                        break;
                    }
                }
                else
                {
                    string ldmlFilename = Path.Combine(tbxCustomCultureOutputFolder.Text, dotNetCultureName + ".ldml");

                    CustomCultureProgress(String.Format("Saving culture {0} to {1}...", cldrCultureName, ldmlFilename));

                    CultureAndRegionInfoBuilder builder =
                        NCldrCustomCulture.CreateNCldrCultureAndRegionInfoBuilder(cldrCultureName, dotNetCultureName);
                    if (File.Exists(ldmlFilename))
                    {
                        File.Delete(ldmlFilename);
                    }

                    builder.Save(ldmlFilename);
                }
            }

            CustomCultureProgress("Done.");
        }

        private void CustomCultureProgress(string text)
        {
            tbxCustomCultureProgress.Text = text + System.Environment.NewLine + tbxCustomCultureProgress.Text;
            Application.DoEvents();
        }

        private void btnCheckAllNeutralCultures_Click(object sender, EventArgs e)
        {
            CheckAllCultures(true);
        }

        private void CheckAllCultures(bool isNeutral)
        {
            for (int index = 0; index < clbCustomCultures.Items.Count; index++)
            {
                string cultureName = clbCustomCultures.Items[index].ToString();
                bool isChecked = false;
                if (!cultureName.EndsWith(" *"))
                {
                    Culture culture = Culture.GetCulture(cultureName);
                    if (isNeutral)
                    {
                        isChecked = culture.IsNeutralCulture;
                    }
                    else
                    {
                        isChecked = !culture.IsNeutralCulture;
                    }
                }

                clbCustomCultures.SetItemChecked(index, isChecked);
            }
        }

        private void btnUnregisterCustomCultures_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbxCustomCultureName.Text))
            {
                MessageBox.Show("Enter a custom culture name to unregister");
            }
            else if (MessageBox.Show(String.Format("Unregister the '{0}' custom culture ?", tbxCustomCultureName.Text),
                "NCLDR Explorer", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    CultureAndRegionInfoBuilder.Unregister(tbxCustomCultureName.Text);

                    MessageBox.Show("Done. To see the changes you must restart this application.");
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show("To unregister custom cultures this application must be run as Administrator");
                }
                catch (InvalidOperationException exception)
                {
                    MessageBox.Show(String.Format("Exception: {0}" + System.Environment.NewLine +
                    "This can occur if the custom culture has already been loaded by this application." +
                    System.Environment.NewLine +
                    "Restart this application and try again.", exception.Message));
                }
                catch (Exception exception)
                {
                    MessageBox.Show(String.Format("Exception: {0}", exception.Message));
                }
            }
        }

        private void btnCheckAllNonNeutralCultures_Click(object sender, EventArgs e)
        {
            CheckAllCultures(false);
        }

        private void btnUnregisterAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Unregister all custom cultures ?", "NCLDR Explorer", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CultureInfo[] customCultureInfos = CultureInfo.GetCultures(CultureTypes.UserCustomCulture);
                if (customCultureInfos.GetLength(0) == 0)
                {
                    MessageBox.Show("There are no custom cultures register on this machine");
                }
                else
                {
                    if (File.Exists("CustomCultures.txt"))
                    {
                        File.Delete("CustomCultures.txt");
                    }

                    File.WriteAllText("CustomCultures.txt", GetCustomCulturesList());

                    string message =
                        "A list of custom cultures to unregister has been written to CustomCultures.txt." + System.Environment.NewLine + System.Environment.NewLine +
                        "To unregister these custom cultures use the UnregisterCustomCultures.exe command line utility like this:-" + System.Environment.NewLine + System.Environment.NewLine +
                        "UnregisterCustomCultures CustomCultures.txt" + System.Environment.NewLine + System.Environment.NewLine +
                        "Note that you must run UnregisterCustomCultures with administrator priviledges." + System.Environment.NewLine + System.Environment.NewLine +
                        "In addition you may need to reboot before using UnregisterCustomCultures because it cannot unregister custom cultures when they are in use.";

                    if (IsRunningAsAdministrator())
                    {
                        string unregisterCustomCulturesPath = FindUnregisterCustomCulturesExecutable(
                            Path.GetDirectoryName(Application.ExecutablePath));

                        if (!String.IsNullOrEmpty(unregisterCustomCulturesPath))
                        {
                            Process.Start(
                                unregisterCustomCulturesPath, 
                                Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "CustomCultures.txt"));

                            MessageBox.Show("A separate process has been started to unregister the custom cultures");
                        }
                        else
                        {
                            MessageBox.Show(
                                "The UnregisterCustomCultures.exe file could not be found so the custom cultures have not been unregistered." + System.Environment.NewLine + System.Environment.NewLine +
                                message);
                        }
                    }
                    else
                    {
                        MessageBox.Show(
                            "This process is not running as Administrator so the custom cultures cannot be unregistered from here." + System.Environment.NewLine + System.Environment.NewLine +
                            message);
                    }
                }
            }
        }

        private bool IsRunningAsAdministrator()
        {
            WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent();
            SecurityIdentifier securityIdentifier = new SecurityIdentifier(WellKnownSidType.BuiltinAdministratorsSid, null);
            return windowsIdentity.Groups.Select(g => (SecurityIdentifier)g.Translate(typeof(SecurityIdentifier))).
                Any(s => s == securityIdentifier);
            //return identity.User.ToString() == securityIdentifier.ToString();
        }

        private string FindUnregisterCustomCulturesExecutable(string path)
        {
            string unregisterCustomCulturesPath = Path.Combine(path, "UnregisterCustomCultures.exe");
            if (File.Exists(unregisterCustomCulturesPath))
            {
                return unregisterCustomCulturesPath;
            }

            string unregisterCustomCulturesFolder = Path.Combine(path, "UnregisterCustomCultures");
            if (Directory.Exists(unregisterCustomCulturesFolder))
            {
                unregisterCustomCulturesPath = Path.Combine(unregisterCustomCulturesFolder, "UnregisterCustomCultures.exe");
                if (File.Exists(unregisterCustomCulturesPath))
                {
                    return unregisterCustomCulturesPath;
                }

                unregisterCustomCulturesFolder = Path.Combine(unregisterCustomCulturesFolder, @"bin\debug");
                unregisterCustomCulturesPath = Path.Combine(unregisterCustomCulturesFolder, "UnregisterCustomCultures.exe");
                if (File.Exists(unregisterCustomCulturesPath))
                {
                    return unregisterCustomCulturesPath;
                }
            }

            string parentFolder = Directory.GetParent(path).FullName;
            if (!String.IsNullOrEmpty(parentFolder))
            {
                return FindUnregisterCustomCulturesExecutable(parentFolder);
            }

            return null;
        }

        private string GetCustomCulturesList()
        {
            List<CultureInfo> customCultureInfos = new List<CultureInfo>(CultureInfo.GetCultures(CultureTypes.UserCustomCulture));

            // list the cultures in order of the fewest number of parent CultureInfos
            customCultureInfos = customCultureInfos.OrderBy(ci => -CultureParentCount(ci)).ToList();

            StringBuilder builder = new StringBuilder();

            foreach (CultureInfo customCultureInfo in customCultureInfos)
            {
                builder.Append(customCultureInfo.Name + ",");
            }

            string customCultures = builder.ToString();

            // strip off the trailing comma
            customCultures = customCultures.Substring(0, customCultures.Length - 1);
            return customCultures;
        }

        private int CultureParentCount(CultureInfo cultureInfo)
        {
            int count = 0;
            CultureInfo parentCultureInfo = cultureInfo;
            while (parentCultureInfo != CultureInfo.InvariantCulture)
            {
                count++;
                parentCultureInfo = parentCultureInfo.Parent;
            }

            return count;
        }

        private void tabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!NCldr.NCldr.IsDataLoaded && tabControl.SelectedTab != tbpLoad)
            {
                e.Cancel = true;
            }
        }

        private void btnGetTelephoneCode_Click(object sender, EventArgs e)
        {
            tbxTelephoneCode.Text = RegionExtensions.GetTelephoneCode(tbxTelephoneCodeRegionIdInput.Text);
        }

        private void lbxTelephoneCodeRegions_SelectedIndexChanged(object sender, EventArgs e)
        {
            RegionTelephoneCode telephoneCode = (RegionTelephoneCode)lbxTelephoneCodeRegions.SelectedItem;
            tbxTelephoneCodeRegionId.Text = telephoneCode.RegionId;
            tbxTelephoneCodes.Text = String.Join(System.Environment.NewLine, telephoneCode.TelephoneCodes);
        }

        private void lbxCalendars_SelectedIndexChanged(object sender, EventArgs e)
        {
            NCldr.Types.Calendar calendar = (NCldr.Types.Calendar)lbxCalendars.SelectedItem;
            if (calendar.DateFormats == null || calendar.DateFormats.GetLength(0) == 0)
            {
                dgvCalendarDateFormats.DataSource = null;
            }
            else
            {
                dgvCalendarDateFormats.DataSource = calendar.DateFormats;
                dgvCalendarDateFormats.Columns[1].Width = 200;
            }

            if (calendar.TimeFormats == null || calendar.TimeFormats.GetLength(0) == 0)
            {
                dgvCalendarTimeFormats.DataSource = null;
            }
            else
            {
                dgvCalendarTimeFormats.DataSource = calendar.TimeFormats;
                dgvCalendarTimeFormats.Columns[1].Width = 200;
            }

            ShowCalendarNameSets<DayNameSet, DayName>(calendar.DayNameSets, dgvCalendarDayNameSets, dgvCalendarDayNames);

            ShowCalendarNameSets<DayPeriodNameSet, DayPeriodName>(calendar.DayPeriodNameSets, dgvCalendarDayPeriodNameSets, dgvCalendarDayPeriodNames);

            ShowCalendarNameSets<EraNameSet, EraName>(calendar.EraNameSets, lbxCalendarEraNameSetIds, dgvCalendarEraNames);

            ShowCalendarNameSets<MonthNameSet, MonthName>(calendar.MonthNameSets, dgvCalendarMonthNameSetIds, dgvCalendarMonthNames);
        }

        private void ShowCalendarNameSets<T, U>(T[] nameSets, ListBox listBox, DataGridView dataGridView) where T: CalendarNameSet<U> where U: CalendarName
        {
            listBox.Items.Clear();
            if (nameSets != null && nameSets.GetLength(0) > 0)
            {
                foreach (T nameSet in nameSets)
                {
                    listBox.Items.Add(nameSet);
                }

                listBox.DisplayMember = "Id";
                listBox.SelectedIndex = 0;
            }
            else
            {
                dataGridView.DataSource = null;
            }
        }

        private void ShowCalendarNameSets<T, U>(T[] nameSets, DataGridView dataGridViewParents, DataGridView dataGridViewChildren)
            where T : CalendarNameSet<U>
            where U : CalendarName
        {
            dataGridViewParents.DataSource = nameSets;
            if (nameSets != null && nameSets.GetLength(0) > 0)
            {
                dataGridViewParents.Columns[0].Width = 70;
                dataGridViewParents.Columns[1].Width = 70;
            }
            else
            {
                dataGridViewChildren.DataSource = null;
            }
        }

        private void CalendarNameSetChanged<T>(ListBox listBox, DataGridView dataGridView) where T: CalendarName
        {
            CalendarNameSet<T> nameSet = (CalendarNameSet<T>)(listBox).SelectedItem;
            if (nameSet.Names == null || nameSet.Names.GetLength(0) == 0)
            {
                dataGridView.DataSource = null;
            }
            else
            {
                dataGridView.DataSource = nameSet.Names;
                dataGridView.Columns[0].Width = 60;
                dataGridView.Columns[1].Width = 150;
            }
        }

        private void dgvCalendarMonthNameSetIds_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = (sender as DataGridView).Rows[e.RowIndex];
            CalendarNameSetChanged<MonthName>(row, dgvCalendarMonthNames);
        }

        private void dgvCalendarDayNameSets_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = (sender as DataGridView).Rows[e.RowIndex];
            CalendarNameSetChanged<DayName>(row, dgvCalendarDayNames);
        }

        private void dgvCalendarDayPeriodNameSets_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = (sender as DataGridView).Rows[e.RowIndex];
            CalendarNameSetChanged<DayPeriodName>(row, dgvCalendarDayPeriodNames);
        }

        private void CalendarNameSetChanged<T>(DataGridViewRow dataGridViewRowParent, DataGridView dataGridViewChildren) where T : CalendarName
        {
            CalendarNameSet<T> nameSet = (CalendarNameSet<T>)dataGridViewRowParent.DataBoundItem;
            if (nameSet.Names == null || nameSet.Names.GetLength(0) == 0)
            {
                dataGridViewChildren.DataSource = null;
            }
            else
            {
                dataGridViewChildren.DataSource = nameSet.Names;
                dataGridViewChildren.Columns[0].Width = 50;
                dataGridViewChildren.Columns[1].Width = 90;
            }
        }

        private void lbxCalendarEraNameSetIds_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalendarNameSetChanged<EraName>(sender as ListBox, dgvCalendarEraNames);
        }

        private void lbxUnitPatternSetIds_SelectedIndexChanged(object sender, EventArgs e)
        {
            UnitPatternSet unitPatternSet = (UnitPatternSet)lbxUnitPatternSetIds.SelectedItem;
            dgvUnitPatterns.DataSource = unitPatternSet.UnitPatterns;
        }

        private void DataGridViewRuleSetsRowEnter(DataGridView dgvRuleSets, int rowIndex, DataGridView dgvRules)
        {
            DataGridViewRow row = dgvRuleSets.Rows[rowIndex];
            RuleBasedNumberFormattingRuleSet ruleSet = (RuleBasedNumberFormattingRuleSet)row.DataBoundItem;
            dgvRules.DataSource = ruleSet.RuleBasedNumberFormattingRules;
        }

        private void dgvOrdinalRuleSets_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRuleSetsRowEnter(dgvOrdinalRuleSets, e.RowIndex, dgvOrdinalRules);
        }

        private void dgvSpelloutRuleSets_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRuleSetsRowEnter(dgvSpelloutRuleSets, e.RowIndex, dgvSpelloutRules);
        }

        private void dgvNumbersNumberingSystemIds_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvNumbersNumberingSystemIds.Rows[e.RowIndex];
            NumberingSystemId numberingSystemId = (NumberingSystemId)row.DataBoundItem;
            ShowNumberingSystem(numberingSystemId.NumberingSystem);
        }

        private void ShowNumberingSystem(NumberingSystem numberingSystem)
        {
            tbxBeforeCurrencySpacingCurrencyMatch.Text = String.Empty;
            tbxBeforeCurrencySpacingSurroundingMatch.Text = String.Empty;
            tbxBeforeCurrencySpacingInsertBetween.Text = String.Empty;
            tbxAfterCurrencySpacingCurrencyMatch.Text = String.Empty;
            tbxAfterCurrencySpacingSurroundingMatch.Text = String.Empty;
            tbxAfterCurrencySpacingInsertBetween.Text = String.Empty;

            lbxDecimalFormatPatternSetIds.Items.Clear();
            dgvDecimalFormatPatterns.DataSource = null;

            if (numberingSystem == null)
            {
                tbxSymbolGroup.Text = String.Empty;
                tbxSymbolList.Text = String.Empty;
                tbxSymbolExponential.Text = String.Empty;
                tbxSymbolPerMille.Text = String.Empty;
                tbxSymbolPercent.Text = String.Empty;
                tbxSymbolPlusSign.Text = String.Empty;
                tbxSymbolMinusSign.Text = String.Empty;
                tbxSymbolInfinity.Text = String.Empty;
                tbxSymbolDecimal.Text = String.Empty;
                tbxSymbolNan.Text = String.Empty;

                tbxNumbersCurrencyFormatPattern.Text = String.Empty;
                tbxNumbersDecimalFormatPattern.Text = String.Empty;
                tbxNumbersPercentFormatPattern.Text = String.Empty;
                tbxNumbersScientificFormatPattern.Text = String.Empty;

                tbxNumberingSystemTypeDescription.Text = String.Empty;
                tbxNumberingSystemTypeDigitsOrRules.Text = String.Empty;
                tbxNumberingSystemTypeDigits.Text = String.Empty;
                tbxNumberingSystemTypeRules.Text = String.Empty;
            }
            else
            {
                if (numberingSystem.Symbols == null)
                {
                    tbxSymbolGroup.Text = String.Empty;
                    tbxSymbolList.Text = String.Empty;
                    tbxSymbolExponential.Text = String.Empty;
                    tbxSymbolPerMille.Text = String.Empty;
                    tbxSymbolPercent.Text = String.Empty;
                    tbxSymbolPlusSign.Text = String.Empty;
                    tbxSymbolMinusSign.Text = String.Empty;
                    tbxSymbolInfinity.Text = String.Empty;
                    tbxSymbolDecimal.Text = String.Empty;
                    tbxSymbolNan.Text = String.Empty;
                }
                else
                {
                    NumberingSystemSymbols symbols = numberingSystem.Symbols;
                    tbxSymbolGroup.Text = symbols.Group;
                    tbxSymbolList.Text = symbols.List;
                    tbxSymbolExponential.Text = symbols.Exponential;
                    tbxSymbolPerMille.Text = symbols.PerMille;
                    tbxSymbolPercent.Text = symbols.PercentSign;
                    tbxSymbolPlusSign.Text = symbols.PlusSign;
                    tbxSymbolMinusSign.Text = symbols.MinusSign;
                    tbxSymbolInfinity.Text = symbols.Infinity;
                    tbxSymbolDecimal.Text = symbols.Decimal;
                    tbxSymbolNan.Text = symbols.Nan;
                }

                tbxNumbersCurrencyFormatPattern.Text = numberingSystem.CurrencyFormatPattern;
                tbxNumbersDecimalFormatPattern.Text = numberingSystem.DecimalFormatPattern;
                tbxNumbersPercentFormatPattern.Text = numberingSystem.PercentFormatPattern;
                tbxNumbersScientificFormatPattern.Text = numberingSystem.ScientificFormatPattern;

                if (numberingSystem.CurrencySpacings != null)
                {
                    if (numberingSystem.CurrencySpacings.BeforeCurrency != null)
                    {
                        CurrencySpacing currencySpacing = numberingSystem.CurrencySpacings.BeforeCurrency;
                        tbxBeforeCurrencySpacingCurrencyMatch.Text = currencySpacing.CurrencyMatch;
                        tbxBeforeCurrencySpacingSurroundingMatch.Text = currencySpacing.SurroundingMatch;
                        tbxBeforeCurrencySpacingInsertBetween.Text = currencySpacing.InsertBetween;
                    }

                    if (numberingSystem.CurrencySpacings.AfterCurrency != null)
                    {
                        CurrencySpacing currencySpacing = numberingSystem.CurrencySpacings.AfterCurrency;
                        tbxAfterCurrencySpacingCurrencyMatch.Text = currencySpacing.CurrencyMatch;
                        tbxAfterCurrencySpacingSurroundingMatch.Text = currencySpacing.SurroundingMatch;
                        tbxAfterCurrencySpacingInsertBetween.Text = currencySpacing.InsertBetween;
                    }
                }

                if (numberingSystem.DecimalFormatPatternSets != null && numberingSystem.DecimalFormatPatternSets.GetLength(0) > 0)
                {
                    lbxDecimalFormatPatternSetIds.Items.AddRange(numberingSystem.DecimalFormatPatternSets);
                    lbxDecimalFormatPatternSetIds.DisplayMember = "Id";
                    lbxDecimalFormatPatternSetIds.SelectedIndex = 0;
                }

                if (numberingSystem.NumberingSystemType != null)
                {
                    tbxNumberingSystemTypeDescription.Text = numberingSystem.NumberingSystemType.Description;
                    tbxNumberingSystemTypeDigitsOrRules.Text = numberingSystem.NumberingSystemType.DigitsOrRules.ToString();
                    tbxNumberingSystemTypeDigits.Text = numberingSystem.NumberingSystemType.Digits;
                    tbxNumberingSystemTypeRules.Text = numberingSystem.NumberingSystemType.Rules;
                }
            }
        }

        private void lbxDecimalFormatPatternSetIds_SelectedIndexChanged(object sender, EventArgs e)
        {
            DecimalFormatPatternSet set = (DecimalFormatPatternSet)lbxDecimalFormatPatternSetIds.SelectedItem;
            dgvDecimalFormatPatterns.DataSource = set.Patterns;
        }

        private void dgvCurrencyDisplayNameSets_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            CurrencyDisplayNameSet currencyDisplayNameSet = 
                (CurrencyDisplayNameSet)dgvCurrencyDisplayNameSets.Rows[e.RowIndex].DataBoundItem;

            dgvCultureCurrencyNames.DataSource = currencyDisplayNameSet.CurrencyDisplayNames;
            dgvCultureCurrencyNames.Columns[0].Width = 70;
            dgvCultureCurrencyNames.Columns[1].Width = 140;
        }
    }

    public class NumberingSystemId
    {
        public string Id { get; set; }

        public string Value { get; set; }

        public NumberingSystem NumberingSystem { get; set; }
    }

    public class DayPeriodRuleSetDisplay
    {
        public string CultureNames { get; set; }

        public DayPeriodRuleSet DayPeriodRuleSet { get; set; }
    }

    public class PluralRuleSetDisplay
    {
        public string CultureNames { get; set; }

        public PluralRuleSet PluralRuleSet { get; set; }
    }
}
