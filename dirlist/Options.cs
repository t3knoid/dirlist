using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dirlist
{
    public class Options
    {
        public string Path { get; set; }
        public BooleanOptions booleanOptions { get; set; }
    }

    [Flags]
    public enum BooleanOptions
    {
        Recursive   = 1,
        PrintEmptyFolder = 2,
    }
}
