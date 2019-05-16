using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentsProgramOrganisation.DataBase;
namespace StudentsProgramOrganisation.DataGridOperations
{
    public class SubjectController
    {
        private readonly StudentsOrgEntities _studentsOrgEntities = new StudentsOrgEntities();

        public void AddSubject(Subjects subject)
        {
            var subjectsDb = _studentsOrgEntities.Subjects;

            if (SubjectValidation(subject)) subjectsDb.Add(subject);

        }
        public void DeleteSubject(int id)
        {

        }

        // Unit testing = false;
        // gitHuB
        public bool SubjectValidation(Subjects subject)
        {
            if (subject.subjectName != null && string.IsNullOrEmpty(subject.subjectName) != true)
            {
                if (subject.subjectTime != null) return true;

                else return false;
            }               

                else return false;
        }
    }
}
