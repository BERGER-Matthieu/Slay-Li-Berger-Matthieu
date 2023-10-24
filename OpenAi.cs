using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Embala
{
    abstract class OpenAi
    {
        private static string _key = "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";

        public static string Key { get { return _key; } }
    }
}
