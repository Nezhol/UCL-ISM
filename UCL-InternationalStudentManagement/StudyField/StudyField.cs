using System;
using System.Collections.Generic;
using System.Text;

namespace StudyField
{
    public class StudyField
    {
        public int Id { get; set; }
        public string FieldName { get; set; }

        public List<StudyField> GetAllStudyFields()
        {
            return null;
        }

        public StudyField GetStudyField(int _id)
        {
            return null;
        }

        //Creates and passes new field study name to data access layer to create new entity in database
        public void CreateNewStudyField(string _fieldName)
        {
            //Missing class for connect to database, maybe we will decide on something ...?
        }
    }
}
