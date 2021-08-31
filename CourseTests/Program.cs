using CourseTests.DataTransferObjects.User;
using CourseTests.GlobalInterfaces;
using CourseTests.Services.CRUD;

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
