﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTests.DataTransferObjects.Question
{
    public class QuestionCreate
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid TestId { get; set; }
    }
}
