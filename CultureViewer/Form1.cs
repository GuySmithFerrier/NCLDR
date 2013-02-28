using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CultureViewer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            LoadCultures(CultureTypes.AllCultures);
        }

        private void btnAllCultures_Click(object sender, EventArgs e)
        {
            LoadCultures(CultureTypes.AllCultures);
        }

        private void btnNeutralCultures_Click(object sender, EventArgs e)
        {
            LoadCultures(CultureTypes.NeutralCultures);
        }

        private void btnSpecificCultures_Click(object sender, EventArgs e)
        {
            LoadCultures(CultureTypes.SpecificCultures);
        }

        private void btnCustomCultures_Click(object sender, EventArgs e)
        {
            LoadCultures(CultureTypes.UserCustomCulture);
        }

        public void LoadCultures(CultureTypes cultureTypes)
        {
            // "EnglishName" is chosen over "DisplayName" here because "DisplayName" returns "NativeName" for
            // custom cultures but the correct display name for non-custom cultures and hence the list appears
            // schizophrenic if it includes both custom and non-custom cultures.
            lbxCultures.Items.Clear();
            foreach (CultureInfo cultureInfo in CultureInfo.GetCultures(cultureTypes).OrderBy(ci => ci.EnglishName))
            {
                lbxCultures.Items.Add(cultureInfo);
            }

            lbxCultures.DisplayMember = "EnglishName";

            if (lbxCultures.Items.Count > 0)
            {
                lbxCultures.SelectedIndex = 0;
            }
        }

        private void lbxCultures_SelectedIndexChanged(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = (CultureInfo)lbxCultures.SelectedItem;
            gbxSelectedCulture.Text = String.Format("{0}: {1}", cultureInfo.Name, cultureInfo.DisplayName);
            tbxEnglishName.Text = cultureInfo.EnglishName;
            tbxNativeName.Text = cultureInfo.NativeName;
            tbxDisplayName.Text = cultureInfo.DisplayName;
            cbxIsCustom.Checked = ((CultureTypes.UserCustomCulture & cultureInfo.CultureTypes) != (CultureTypes)0);
            cbxIsNeutral.Checked = cultureInfo.IsNeutralCulture;

            lbxParents.Items.Clear();
            CultureInfo parentCultureInfo = cultureInfo;
            while (parentCultureInfo != CultureInfo.InvariantCulture)
            {
                parentCultureInfo = parentCultureInfo.Parent;
                if (parentCultureInfo == CultureInfo.InvariantCulture)
                {
                    lbxParents.Items.Add("(Invariant Culture)");
                }
                else
                {
                    lbxParents.Items.Add(String.Format("{0}: {1}", parentCultureInfo.Name, parentCultureInfo.DisplayName));
                }
            }

            tbxLongDatePattern.Text = cultureInfo.DateTimeFormat.LongDatePattern;
            tbxShortDatePattern.Text = cultureInfo.DateTimeFormat.ShortDatePattern;
            tbxLongTimePattern.Text = cultureInfo.DateTimeFormat.LongTimePattern;
            tbxShortTimePattern.Text = cultureInfo.DateTimeFormat.ShortTimePattern;

            DateTime dateTimeNow = DateTime.Now;

            tbxLongDateExample.Text = dateTimeNow.ToString("D", cultureInfo.DateTimeFormat);
            tbxShortDateExample.Text = dateTimeNow.ToString("d", cultureInfo.DateTimeFormat);
            tbxLongTimeExample.Text = dateTimeNow.ToString("T", cultureInfo.DateTimeFormat);
            tbxShortTimeExample.Text = dateTimeNow.ToString("t", cultureInfo.DateTimeFormat);

            tbxAMSymbol.Text = cultureInfo.DateTimeFormat.AMDesignator;
            tbxPMSymbol.Text = cultureInfo.DateTimeFormat.PMDesignator;

            lbxDayNames.Items.Clear();
            foreach(string dayName in cultureInfo.DateTimeFormat.DayNames)
            {
                lbxDayNames.Items.Add(dayName);
            }

            tbxFirstDayOfWeek.Text = cultureInfo.DateTimeFormat.FirstDayOfWeek.ToString();

            lbxMonthNames.Items.Clear();
            foreach (string monthName in cultureInfo.DateTimeFormat.MonthNames)
            {
                lbxMonthNames.Items.Add(monthName);
            }

            lbxCalendars.Items.Clear();
            if (cultureInfo.OptionalCalendars != null)
            {
                foreach (Calendar calendar in cultureInfo.OptionalCalendars)
                {
                    string calendarType = calendar.GetType().Name;
                    if (calendar.GetType().Name == cultureInfo.Calendar.GetType().Name)
                    {
                        calendarType += " *";
                    }

                    lbxCalendars.Items.Add(calendarType);
                }
            }

            decimal number = 123456789.0123M;

            tbxNumberPositiveExample.Text = number.ToString("N", cultureInfo.NumberFormat);
            tbxNumberNegativeExample.Text = (-number).ToString("N", cultureInfo.NumberFormat);

            tbxNumbersDecimalSymbol.Text = cultureInfo.NumberFormat.NumberDecimalSeparator;
            tbxNumbersDecimalDigits.Text = cultureInfo.NumberFormat.NumberDecimalDigits.ToString();
            tbxNumbersGroupingSymbol.Text = cultureInfo.NumberFormat.NumberGroupSeparator;
            tbxNumbersDigitGrouping.Text = String.Join(", ", cultureInfo.NumberFormat.NumberGroupSizes);
            tbxNumbersNegativeNumberFormat.Text = cultureInfo.NumberFormat.NumberNegativePattern.ToString();

            RegionInfo regionInfo = GetRegionInfo(cultureInfo);
            if (regionInfo == null)
            {
                tbxNumbersMeasurementSystem.Text = String.Empty;
            }
            else
            {
                tbxNumbersMeasurementSystem.Text = regionInfo.IsMetric ? "Metric" : "Not metric";
            }

            tbxNumbersStandardDigits.Text = String.Join(String.Empty, cultureInfo.NumberFormat.NativeDigits);
            tbxNumbersUseNativeDigits.Text = cultureInfo.NumberFormat.DigitSubstitution.ToString();

            tbxSymbolNan.Text = cultureInfo.NumberFormat.NaNSymbol;
            tbxSymbolNegativeInfinity.Text = cultureInfo.NumberFormat.NegativeInfinitySymbol;
            tbxSymbolNegativeSign.Text = cultureInfo.NumberFormat.NegativeSign;
            tbxSymbolPositiveInifinity.Text = cultureInfo.NumberFormat.PositiveInfinitySymbol;
            tbxSymbolPositiveSign.Text = cultureInfo.NumberFormat.PositiveSign;
            tbxSymbolPercent.Text = cultureInfo.NumberFormat.PercentSymbol;
            tbxSymbolPerMille.Text = cultureInfo.NumberFormat.PerMilleSymbol;

            tbxCurrencyPositiveExample.Text = number.ToString("C", cultureInfo.NumberFormat);
            tbxCurrencyNegativeExample.Text = (-number).ToString("C", cultureInfo.NumberFormat);

            tbxCurrencyDecimalSymbol.Text = cultureInfo.NumberFormat.CurrencyDecimalSeparator;
            tbxCurrencyDecimalDigits.Text = cultureInfo.NumberFormat.CurrencyDecimalDigits.ToString();
            tbxCurrencyGroupingSymbol.Text = cultureInfo.NumberFormat.CurrencyGroupSeparator;
            tbxCurrencyDigitGrouping.Text = String.Join(", ", cultureInfo.NumberFormat.CurrencyGroupSizes);
            tbxCurrencyNegativeCurrencyFormat.Text = cultureInfo.NumberFormat.CurrencyNegativePattern.ToString();
            tbxCurrencyPositiveCurrencyFormat.Text = cultureInfo.NumberFormat.CurrencyPositivePattern.ToString();
            tbxCurrencySymbol.Text = cultureInfo.NumberFormat.CurrencySymbol;

            tbxCompareInfoName.Text = cultureInfo.CompareInfo.LCID == 127 ? "(Invariant)" : cultureInfo.CompareInfo.Name;
            tbxTextInfoName.Text = cultureInfo.TextInfo.LCID == 127 ? "(Invariant)" : cultureInfo.TextInfo.CultureName;
        }

        private RegionInfo GetRegionInfo(CultureInfo cultureInfo)
        {
            try
            {
                return new RegionInfo(cultureInfo.Name);
            }
            catch
            {
                return null;
            }
        }
    }
}
