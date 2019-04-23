using System;
using System.Collections.Generic;
using System.Text;

namespace StudyField
{
    public class StudyField
    {
        public int Id { get; set; }
        public string FieldName { get; set; }

        private StudyFieldDB db;
        private Utilities.TextUtilities textUtilities;

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
            //Remove any whitespaces
            textUtilities = new Utilities.TextUtilities();
            var text = textUtilities.RemoveWhiteSpacesFromStartToEnd(_fieldName);
            
            //Get the DAL
            db = new StudyFieldDB();
            db.CreateNewStudyField(text);
        }
    }
}
