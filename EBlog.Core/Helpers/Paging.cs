using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlog.Core.Helpers
{
    public static class Paging
    {
        public static (int skip, int take) PagingFunc(int page) {
            int skip = (page - 1) * 10;
            int take = (page * 10);
            return (skip, take);
        }

    }
}
