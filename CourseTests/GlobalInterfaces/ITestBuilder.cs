using CourseTests.DataTransferObjects.TestBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTests.GlobalInterfaces
{
    public interface ITestBuilder
    {
        Guid QuestionBuild(QuestionBuildSettings setting);
    }
}
