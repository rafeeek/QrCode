using System;
using System.Collections.Generic;

#nullable disable

namespace QR_DAL.Models
{
    public partial class StudentsDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public long EmergencyNumber { get; set; }
        public string City { get; set; }
        public string GetById { get; set; }
    }
}
