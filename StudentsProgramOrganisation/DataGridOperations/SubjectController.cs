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

            subjectsDb.Add(subject);

            _studentsOrgEntities.SaveChanges();
        }
        public void DeleteSubject(int id)
        {
            
            try
            {
                var subjectsDb = _studentsOrgEntities.Subjects;

                Subjects subjectToDelete = subjectsDb.Single(n => n.subjectId == id);

                subjectsDb.Remove(subjectToDelete);

                _studentsOrgEntities.SaveChanges();
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);           
            }
                  
        }

        // Unit testing
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
