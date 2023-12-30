using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlog.Core.Helpers
{
    public static class Normalization
    {
        public static string TurkishToEnglish(string charcter)
        {
            string turkishCharcter = "ığüşöç ";
            string englishCharcter = "igusoc-";

            for (int i = 0; i < turkishCharcter.Length; i++)
            {
                charcter = charcter.ToLower().Replace(turkishCharcter[i], englishCharcter[i]);
            }

            return charcter;
        }
    }
}
