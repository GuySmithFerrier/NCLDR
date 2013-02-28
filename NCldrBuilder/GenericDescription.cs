using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCldr.Types;

namespace NCldr.Builder
{
    public class GenericDescription : IDescription
    {
        public string Id { get; set; }

        public string Description { get; set; }
    }
}
