using AutoMapper;
using EBlog.Service.Services.AppUserServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlog.Service.Utilities.UnitOfWorks
{
    public class UnitOfWorks : IUnitOfWorks
    {
        public UnitOfWorks(IMapper mapper)
        {
            Mapper = mapper;
        }

        public IMapper Mapper { get;}


    }
}
