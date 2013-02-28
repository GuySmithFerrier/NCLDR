using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCldr.Builder
{
    public enum CultureSelection
    {
        All,
        IncludeOnly,
        AllExceptExclude,
        AllNew
    }

    public class NCldrBuilderCultureOptions
    {
        public NCldrBuilderCultureOptions()
        {
            this.CultureSelection = Builder.CultureSelection.All;
            this.IncludeLanguageDisplayNames = true;
            this.IncludeRegionDisplayNames = true;
            this.IncludeScriptDisplayNames = true;
            this.IncludeCasing = true;
            this.IncludeCharacters = true;
            this.IncludeDates = true;
            this.IncludeDelimiters = true;
            this.IncludeListPatterns = true;
            this.IncludeMessages = true;
            this.IncludeNumbers = true;
            this.IncludeRuleBasedNumberFormatting = true;
            this.IncludeUnitPatternSets = true;
            this.ExcludeCultures = new string[] { };
            this.IncludeCultures = new string[] { };
        }

        public CultureSelection CultureSelection { get; set; }

        public string[] ExcludeCultures { get; set; }

        public string[] IncludeCultures { get; set; }

        public bool IncludeLanguageDisplayNames { get; set; }

        public bool IncludeRegionDisplayNames { get; set; }

        public bool IncludeScriptDisplayNames { get; set; }

        public bool IncludeCasing { get; set; }

        public bool IncludeCharacters { get; set; }

        public bool IncludeDates { get; set; }

        public bool IncludeDelimiters { get; set; }

        public bool IncludeListPatterns { get; set; }

        public bool IncludeMessages { get; set; }

        public bool IncludeNumbers { get; set; }

        public bool IncludeRuleBasedNumberFormatting { get; set; }

        public bool IncludeUnitPatternSets { get; set; }
    }
}
