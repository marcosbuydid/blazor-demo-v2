using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Student: Person
    {
        private int studentId;

        public int StudentId
        {
            get
            {
                return studentId;
            }

            set 
            { 
                studentId = value;
            }
        }
    }
}
