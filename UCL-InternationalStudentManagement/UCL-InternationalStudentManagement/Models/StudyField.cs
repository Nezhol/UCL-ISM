﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCL_InternationalStudentManagement.Models
{
    public class StudyField
    {
        public int Id { get; set; }
        public string FieldName { get; set; }

        //Creates and passes new field study name to data access layer to create new entity in database
        public void CreateNewStudyField(string _fieldName)
        {
            //Missing class for connect to database
        }
    }
}
