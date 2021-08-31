using CourseTests.Entities;
using CourseTests.GlobalInterfaces;
using CourseTests.Services.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTests
{
    class Program
    {
       
        static void Main(string[] args)
        {
            IUserCRUDService userCRUDService = new UserCRUDService();
            ICourseCRUDService courseCRUDService = new CourseCRUDService();
        }
    }
}
