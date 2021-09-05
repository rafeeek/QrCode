using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QR_BLL.Interfaces;
using QR_BLL.Models;
using QR_DAL.Models;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace QR_For_Students.Controllers
{
    public class StudentsController : Controller
    {

        #region Ctor
        private readonly I_StudentsDetail studentsDetail;
        private readonly IMapper mapper;

        public StudentsController(I_StudentsDetail StudentsDetail, IMapper Mapper)
        {
            studentsDetail = StudentsDetail;
            mapper = Mapper;
        }
        #endregion



        public IActionResult Getall()
        {
            var data = studentsDetail.GetAllStudents();
            var result = mapper.Map<IEnumerable<StudentsDetailVM>>(data);
            return View(result);
        }


        public IActionResult Details(string QrId)
        {
            var FinalLink = "~/Students/Details/" + QrId;
            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator Generator = new QRCodeGenerator();
                QRCodeData codeData = Generator.CreateQrCode(FinalLink, QRCodeGenerator.ECCLevel.Q);
                QRCode code = new QRCode(codeData);
                using (Bitmap bitmap = code.GetGraphic(20))
                {
                    bitmap.Save(ms, ImageFormat.Png);
                    ViewBag.QrImage = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                }
            }

            var data = studentsDetail.GetStudentById(QrId);
            var resulet = mapper.Map<StudentsDetailVM>(data);
            return View(resulet);
        }

        [HttpPost]
        public string Creat([FromBody] StudentsDetailVM detailVM)
        {
            detailVM.GetById = Guid.NewGuid()+"";
            var data = mapper.Map<StudentsDetail>(detailVM);
            bool result = studentsDetail.CreatNewStudent(data);
            return result == true ? "Add" : "NotAdd";
        }




        #region Deleteajax
        [HttpPost]
        public void Deleteajax(string deleteid)
        {
            studentsDetail.DeleteStudent(deleteid);
            
        }
        #endregion
    }
}
