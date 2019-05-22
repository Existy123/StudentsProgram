using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace StudentsProgramOrganisation.DataGridOperations
{
    using DataBase;
    using Models;
    public class DataGridController
    {
        public DataGrid DataGrid { get; set; }

        public DataGridController(DataGrid dataGrid)
        {
            this.DataGrid = dataGrid;
        }

        public void SetDataSourceForSubjects()
        {
            try
            {

                using (StudentsOrgEntities entities = new StudentsOrgEntities())
                {
                    ICollection<DataBase.Subjects> subjects = new List<Subjects>();

                    foreach (var subject in entities.Subjects)
                    {
                        subjects.Add(subject);
                    }

                    this.DataGrid.ItemsSource = OrderSubjectsByDate(subjects);
                }
                             
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Nie można nawiązać połączenia.");
                App.Current.Shutdown();
            }           
        }
        public void SetDataSourceForExams()
        {
            ICollection<Exams> examsAsSource = new List<Exams>();
            try
            {
                using (StudentsOrgEntities entities = new StudentsOrgEntities())
                {                  
                    foreach (var exam in entities.Exams)
                    {
                        examsAsSource.Add(exam);
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Wystapil blad z egzaminami. Powiadom administratora bazy danych");
                App.Current.Shutdown();
            }

            this.DataGrid.ItemsSource = OrderExamByDate(examsAsSource);
        }
        public void SetDataSourceForLearningDays()
        {
            ICollection<LearningDays> learningDaysAsSource = new List<LearningDays>();
            try
            {
                using (StudentsOrgEntities entities = new StudentsOrgEntities())
                {
                    foreach (var learnDay in entities.LearningDays)
                    {
                        learningDaysAsSource.Add(learnDay);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Wystapil blad z \"Dniami uczenia\". Powiadom administratora bazy danych");
                App.Current.Shutdown();
            }

            ICollection<LearnDayAdvenced> learnDayAdvenceds = new List<LearnDayAdvenced>();

            foreach (var learningDay in learningDaysAsSource)
            {
                LearnDayAdvenced advencedLearnDay = new LearnDayAdvenced(learningDay);
                learnDayAdvenceds.Add(advencedLearnDay);
            }

            this.DataGrid.ItemsSource = learnDayAdvenceds;
        }

        //Unit test
        private ICollection<Subjects> OrderSubjectsByDate (ICollection<Subjects> subjects)
        {
            ICollection<Subjects> orderedSubjects = subjects.Select(n => n).OrderBy(n => n.subjectTime).ToList();

            return orderedSubjects;
        }

        //Unit test
        private ICollection<Exams> OrderExamByDate (ICollection<Exams> exams)
        {
            ICollection<Exams> OrderedExams = exams.Select(n => n).OrderBy(n => n.examTime).ToList();

            return OrderedExams;
        }
    }
}
