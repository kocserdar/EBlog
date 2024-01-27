using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlog.Core.Helpers
{
    public static class FullName
    {
        public static string GetFullName(string firstname, string lastname)
        {
            //return firstname.First().ToString().ToUpper() +". "+ lastname;
            return firstname+" "+ lastname;
        }

        public static string GetFSurname(string firstname, string lastname)
        {
            return firstname.First().ToString().ToUpper() +". "+ lastname;

        }
    }
}
