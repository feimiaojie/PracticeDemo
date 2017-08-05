using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (var ctx = new SchoolContext())
                {
                    Student s = new Student {StudentName="new student" };
                    ctx.Students.Add(s);
                    ctx.SaveChanges();
                }
            }
            catch (DbEntityValidationException dbEx)
            {

            }
        }
    }
}
