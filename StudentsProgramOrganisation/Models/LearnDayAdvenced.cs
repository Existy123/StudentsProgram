using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace StudentsProgramOrganisation.Models
{
    using DataBase;
    using System.Windows;

    /// <summary>
    /// This is superset of learningDay. It means that this is caused every time in ItemsSource
    /// because button is set for one particulary learnDay. 
    /// </summary>
    public class LearnDayAdvenced
    {
        private readonly StudentsOrgEntities _studentsOrgEntities = new StudentsOrgEntities();
        public LearningDays LearnDay { get; set; }

        public Button SubstractByOne = new Button();

        public LearnDayAdvenced(LearningDays learnDay)
        {
            LearnDay = learnDay;
            SubstractByOne.Name = "substract";
            SubstractByOne.Click += new RoutedEventHandler(Button_click);
        }    

        protected void Button_click(object sender, EventArgs e)
        {
            SubstractTime();
        }

        /// <summary>
        /// If learn time = 0 it will delete object from table.
        /// </summary>
        /// <param name="learnDay"></param>
        private void SubstractTime ()
        {
            var learnTable = _studentsOrgEntities.LearningDays;
            var learnObject = learnTable.Single(n => n.dayId == LearnDay.dayId);

            if(learnObject.learningTimeAmount>0)
            {
                learnObject.learningTimeAmount--;               
            }
            else
            {
                learnTable.Remove(learnObject);
            }

            _studentsOrgEntities.SaveChanges();
        }
        
        
        
        

    }
}
