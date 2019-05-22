using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using StudentsProgramOrganisation.DataBase;

namespace StudentsProgramOrganisation.DataGridOperations
{
    public class ExamController
    {
        private readonly StudentsOrgEntities _studentsOrgEntities = new StudentsOrgEntities();

        public void AddExam(Exams exam)
        {
            var examDb = _studentsOrgEntities.Exams;

            examDb.Add(exam);
            _studentsOrgEntities.SaveChanges();
        }
        public void DeleteExam(int examId)
        {
            try
            {
                var examDb = _studentsOrgEntities.Exams;

                Exams examToDelete = examDb.Single(n => n.examId == examId);

                examDb.Remove(examToDelete);
                _studentsOrgEntities.SaveChanges();
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message, "Wystapil blad o tresci: ");
            }
            
        }
        //Unit testing
        public bool ExamValidation(Exams exam)
        {
            if (string.IsNullOrEmpty(exam.examName) || exam.examTime == null)
            {
                return false;
            }
            else return true;
        }
    }
}
