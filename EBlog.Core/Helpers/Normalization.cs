using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlog.Core.Helpers
{
    public static class Normalization
    {
        public static string TurkishToEnglish(string character)
        {
            string turkishCharacter = "ığüşöç ";
            string englishCharacter = "igusoc-";

            for (int i = 0; i < turkishCharacter.Length; i++)
            {
                character = character.ToLower().Replace(turkishCharacter[i], englishCharacter[i]);
            }
            character = character + "_" + Guid.NewGuid().ToString().Substring(0,4);
            return character;
        }
    }
}
