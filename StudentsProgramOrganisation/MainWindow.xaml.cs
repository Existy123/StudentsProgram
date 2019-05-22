using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudentsProgramOrganisation
{
    using DataBase;
    using DataGridOperations;
    using System.Reflection;

    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataGridController gridController = new DataGridController(TimeTable_DataGrid);
            DataGridController examsGridController = new DataGridController(ExamGrid);
            DataGridController learningDaysController = new DataGridController(WhatToLearnToday_DataGrid);

            gridController.SetDataSourceForSubjects();
            examsGridController.SetDataSourceForExams();
            learningDaysController.SetDataSourceForLearningDays();

            SetWebBrowserSilient();
        }

        private void SetWebBrowserSilient()
        {
            dynamic activeX = this.WB.GetType().InvokeMember("ActiveXInstance",
                    BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                    null, this.WB, new object[] { });

            activeX.Silent = true;
        }

        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void AddSubject_Button_Click(object sender, RoutedEventArgs e)
        {
            var subjectName = this.AddSubjectName_TextBox.Text;
            var subjectDate = this.AddSubject_Callendar.SelectedDate;
            var subjectTime = this.AddSubject_TimePicker.SelectedTime;

            var dateToSend = new DateTime();
            try
            {
                var date = new DateTime(subjectDate.Value.Year, subjectDate.Value.Month, subjectDate.Value.Day,
                                   subjectTime.Value.Hour, subjectTime.Value.Minute, subjectTime.Value.Second);
                dateToSend = date;
            }
            catch (Exception)
            {
                MessageBox.Show("Prosze podac poprawne dane.");
            }
 
            Subjects subject = new Subjects()
            {
                subjectName = subjectName,
                subjectTime = dateToSend
            };

            SubjectController controller = new SubjectController();

            if(controller.SubjectValidation(subject))
            {
                controller.AddSubject(subject);
                MessageBox.Show("Pomyślne dodanie przedmiotu.");
                AddSubjectName_TextBox.Text = "";
            }
            
            DataGridController gridController = new DataGridController(TimeTable_DataGrid);
            gridController.SetDataSourceForSubjects();
        }

        private void DeleteSubject_Button_Click(object sender, RoutedEventArgs e)
        {
            Subjects subjectToDelete = new Subjects();
            try
            {
                var val = (Subjects)TimeTable_DataGrid.SelectedValue;
                subjectToDelete = val;
            }
            catch (Exception)
            {
                MessageBox.Show("Prosze zaznaczyc poprawny obiekt. ");
            }
            

            int deletedId = new int();
            try
            {
                deletedId = subjectToDelete.subjectId;

                SubjectController controller = new SubjectController();

                controller.DeleteSubject(deletedId);

                DataGridController gridController = new DataGridController(TimeTable_DataGrid);
                gridController.SetDataSourceForSubjects();
            }
            catch (Exception)
            {
                MessageBox.Show("Zaznacz element do usuniecia.");
            }         
            
        }

        private void AddExam_Button_Click(object sender, RoutedEventArgs e)
        {
            var examName = this.ExamName_TextBox.Text;
            var examDate = this.ExamDate_Calendar.SelectedDate;
            ExamController controller = new ExamController();

            try
            {
                Exams exam = new Exams() { examName = examName, examTime = examDate };
                controller.AddExam(exam);

                ToLearnController toLearnController = new ToLearnController(exam.examName, 10);

                toLearnController.AddAndSaveLearnCycle();

                DataGridController dataGridController = new DataGridController(ExamGrid);
                dataGridController.SetDataSourceForExams();

                dataGridController.DataGrid = WhatToLearnToday_DataGrid;
                dataGridController.SetDataSourceForLearningDays();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void DeleteExam_Button_Click(object sender, RoutedEventArgs e)
        {
            Exams examToDelete = new Exams();
            try
            {
                var itemToDelete = (Exams)ExamGrid.SelectedValue;
                examToDelete = itemToDelete;
            }
            catch (Exception)
            {
                MessageBox.Show("Prosze zaznaczyc obiekt");
            }       
            try
            {
                ExamController controller = new ExamController();
                controller.DeleteExam(examToDelete.examId);
                try
                {
                        ToLearnController toLearnController = new ToLearnController(examToDelete.examName, 10);
                        toLearnController.DeleteLearningDayIfExamDeleteClicked();
                }
                catch (Exception ex)
                {
                        MessageBox.Show(ex.Message);
                }

                DataGridController gridController = new DataGridController(ExamGrid);
                gridController.SetDataSourceForExams();
                gridController.DataGrid = WhatToLearnToday_DataGrid;
                gridController.SetDataSourceForLearningDays();                              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Wystapil blad.");
            }


        }


    }
}
