using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCldr.Builder
{
    public enum ProgressEventType
    {
        Adding,

        Added,

        Writing
    }

    public delegate void NCldrBuilderProgressEventHandler(object sender, NCldrBuilderProgressEventArgs args);

    public class NCldrBuilderProgressEventArgs: EventArgs
    {
        public string Section { get; set; }

        public string Item { get; set; }

        public ProgressEventType ProgressEventType { get; set; }

        public object AddedObject { get; set; }
    }
}
