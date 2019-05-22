using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace StudentsProgramOrganisation.DataGridOperations
{
    using DataBase;
    public class ToLearnController
    {
        private readonly StudentsOrgEntities _studentsOrgEntities = new StudentsOrgEntities();
        private readonly string _examName;
        private readonly double _learningTime;

        public ToLearnController(string examName,double learningTime)
        {
            _examName = examName;
            _learningTime = learningTime;
        }        

        public void AddAndSaveLearnCycle()
        {
            var learnTable = _studentsOrgEntities.LearningDays;

            var learnDay = new LearningDays()
                        {
                            subjectName = _examName,
                            learningTimeAmount = _learningTime
                        };
            if (CheckIfLearnDayIsNotInTable()) learnTable.Add(learnDay);

            _studentsOrgEntities.SaveChanges();
        }
        public void DeleteLearningDayIfExamDeleteClicked()
        {
            var learnTable = _studentsOrgEntities.LearningDays;
            var learnDayToDelete = learnTable.Single(n => n.subjectName == _examName);

            learnTable.Remove(learnDayToDelete);        
            _studentsOrgEntities.SaveChanges();
        }
        private bool CheckIfLearnDayIsNotInTable()
        {
            var learnTable = _studentsOrgEntities.LearningDays;

            foreach (var learningDay in learnTable)
            {
                if (learningDay.subjectName != _examName) continue;
                else return false;
            }
            return true;
                
        }


    }
}
