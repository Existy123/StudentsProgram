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
    public class DataGridController
    {
        public DataGrid DataGrid { get; set; }

        public DataGridController(DataGrid dataGrid)
        {
            this.DataGrid = dataGrid;
        }

        public void SetDataSource()
        {
            try
            {
                StudentsOrgEntities entities = new StudentsOrgEntities();

                ICollection<DataBase.Subjects> subjects = new List<Subjects>();

                foreach (var subject in entities.Subjects)
                {
                    subjects.Add(subject);
                }

                this.DataGrid.ItemsSource = OrderSubjectsByDate(subjects);
               
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Nie można nawiązać połączenia.");
                App.Current.Shutdown();
            }           
        }

        private ICollection<Subjects> OrderSubjectsByDate (ICollection<Subjects> subjects)
        {
            ICollection<Subjects> orderedSubjects = subjects.Select(n => n).OrderBy(n => n.subjectTime).ToList();

            return orderedSubjects;
        }
    }
}
