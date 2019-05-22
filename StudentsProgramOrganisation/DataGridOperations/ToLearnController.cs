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

        public ToLearnController(string examName)
        {
            _examName = examName;
        }
        public void AddAndSaveLearnCycle(double learningTime)
        {
            var learnTable = _studentsOrgEntities.LearningDays;

            var learnDay = new LearningDays()
                        {
                            subjectName = _examName,
                            learningTimeAmount = learningTime
                        };

            learnTable.Add(learnDay);
            _studentsOrgEntities.SaveChanges();
        }

        // moze by tak stworzyc model, w ktorym jest pozostala liczba godzin i przycisk ktory pozwala na zmniejszenie ilosci czasu
        // i po prostu by sie go klikalo i calosc by zapisywala sie w bazie danych. gdy np. klika przycisk to jest -1 godzina i np.
        // gdy dochodzi do 0 albo niżej to w zmniejszgodzine() jest warunek ze jesli wartosc godziny tego entity pobranej z bazy danych
        // jest = 0 badz mniej to wywolywany jest kod do usuniecia tego obiektu co w prostym tlumaczeniu ulatwilo by prace i nie musial bym robic
        // zadnych metod na daty itd.

    }
}
