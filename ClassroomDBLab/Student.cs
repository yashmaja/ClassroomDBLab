using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClassroomDBLab
{
    class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Food { get; set; }
        public string Hometown { get; set; }
    }
}
