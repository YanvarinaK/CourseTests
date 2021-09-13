using CourseTests.DataTransferObjects.TestBuilder;
using CourseTests.DataTransferObjects.User;
using CourseTests.GlobalInterfaces;
using CourseTests.Services;
using CourseTests.Services.CRUD;
using System;
using System.Collections.Generic;

namespace CourseTests
{
    class Program
    {
       
        static void Main(string[] args)
        {
            IUserCRUDService userCRUDService = new UserCRUDService();
            ICourseCRUDService courseCRUDService = new CourseCRUDService();
            ITestBuilder testBuilder = new TestBuilder();
        }
    }
}
