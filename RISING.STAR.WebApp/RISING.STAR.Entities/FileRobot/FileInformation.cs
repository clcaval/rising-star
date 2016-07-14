using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RISING.STAR.Entities.FileRobot
{
    public class FileInformation
    {

        public string FileName { get; set; }

        public string Exam { get; set; }
        public int PatientID { get; set; }
        public string Eye { get; set; }
        public DateTime ExamDatetime { get; set; }
        public string ImageType { get; set; }
        public int Sequence { get; set;} 

    }
}
