using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR_BLL.Models
{
    public partial class StudentsDetailVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public long EmergencyNumber { get; set; }
        public string City { get; set; }
        public string GetById { get; set; }
    }
}
