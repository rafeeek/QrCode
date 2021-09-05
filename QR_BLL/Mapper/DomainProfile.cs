using AutoMapper;
using QR_BLL.Models;
using QR_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR_BLL.Mapper
{
    public class DomainProfile:Profile
    {
        public DomainProfile()
        {
            CreateMap<StudentsDetail, StudentsDetailVM>().ReverseMap();
        }
    }
}
