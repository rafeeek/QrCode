using Microsoft.EntityFrameworkCore;
using QR_BLL.Interfaces;
using QR_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR_BLL.Repository
{
    public class I_StudentsDetailRepos: I_StudentsDetail
    {

        #region Ctor
        private readonly QR_ProjectContext context;


        public I_StudentsDetailRepos(QR_ProjectContext Context)
        {
            context = Context;
        }
        #endregion

        #region Crud
        public bool CreatNewStudent(StudentsDetail obj)
        {
            context.StudentsDetails.Add(obj);
            int data = context.SaveChanges();
            return data > 0 ? true : false;
        }

        public void DeleteStudent(string id)
        {
            var data = context.StudentsDetails.Where(a => a.GetById == id).FirstOrDefault();
            context.StudentsDetails.Remove(data);
            context.SaveChanges();
        }

        public IEnumerable<StudentsDetail> GetAllStudents()
        {
            var data = context.StudentsDetails.Select(a => a);
            return data;
        }

        public StudentsDetail GetStudentById(string id)
        {
            var data = context.StudentsDetails.Where(a => a.GetById == id).FirstOrDefault();
            return data;
        }

        public void UpdateStudent(StudentsDetail obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            context.SaveChanges();
        }
        #endregion

    }
}
