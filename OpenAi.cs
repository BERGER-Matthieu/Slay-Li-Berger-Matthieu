using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Embala
{
    abstract class OpenAi
    {
        private static string _key = "A key"; //You thought i'm that dumb

        public static string Key { get { return _key; } }
    }
}
