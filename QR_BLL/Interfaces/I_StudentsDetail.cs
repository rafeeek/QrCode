using QR_BLL.Models;
using QR_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR_BLL.Interfaces
{
    public interface I_StudentsDetail
    {
        public IEnumerable<StudentsDetail> GetAllStudents();
        public StudentsDetail GetStudentById(string id);
        public bool CreatNewStudent(StudentsDetail obj);
        public void DeleteStudent(string id);
        public void UpdateStudent(StudentsDetail obj);
    }
}
