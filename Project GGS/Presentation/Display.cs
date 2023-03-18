using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_GGS
{
    class Display
    {
        private int closeOperationId = 9;
        private NoteCreate noteCreate = new NoteCreate();
        public Display()
        {
            Input();
        }

        private void ShowMenu()
        {
            Console.WriteLine();
            Console.WriteLine(new string('*', 40));
            Console.WriteLine("*" + new string(' ', 16) + "Бележки" + new string(' ', 15) + "*");
            Console.WriteLine(new string('*', 40));

            Console.WriteLine("1. Показване на всички бележки");
            Console.WriteLine("2. Добавяне на бележка");
            Console.WriteLine("3. Обнови бележка");
            Console.WriteLine("4. Извличане на бележка по ID");
            Console.WriteLine("5. Изтриване на бележка по ID");
            Console.WriteLine("6. Бележката с най-много описание");
            Console.WriteLine("7. Извличане на всички бележки по \n   диапазон от дати");
            Console.WriteLine("8. Извличане на всички бележки по \n   определено ниво на важност");

           
        }

        private void Input()
        {
            var operation = -1;
            do
            {
                ShowMenu();
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1:
                        ListAll();
                        break;
                    case 2:
                        Add();
                        break;
                    case 3:
                        Update();
                        break;
                    case 4:
                        Fetch();
                        break;
                    case 5:
                        Delete();
                        break;
                    case 6:
                        LongestDescription();
                        break;
                    case 7:
                        BetweenDataa();
                        break;
                    case 8:
                        OfLevel();
                        break;
                    default:
                        break;
                }
            } while (operation <= closeOperationId);
        }

        private void Delete()
        {
            Console.WriteLine("Въведи ID за изтриване: ");
            int id = int.Parse(Console.ReadLine());
            noteCreate.Delete(id);
            Console.WriteLine("Готово!");
        }

        private void Fetch()
        {
            Console.WriteLine("Въведи ID за извличане: ");
            int id = int.Parse(Console.ReadLine());
            Note note = noteCreate.Get(id);
            if (note != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine();
                Console.WriteLine("ID: " + note.Id);
                Console.WriteLine("Заглавие на бележката: " + note.Title);
                Console.WriteLine("Описание: " + note.Description);
                Console.WriteLine("Дата: " + note.Dataa);
                Console.WriteLine("Колко важна е: " + note.Level);
                Console.WriteLine();
                Console.WriteLine(new string('-', 40));
            }
        }

        private void Update()
        {
            Console.WriteLine("Въведи ID за обновяване: ");
            int id = int.Parse(Console.ReadLine());
            Note note = noteCreate.Get(id);
            if (note != null)
            {
                Console.WriteLine("Въведи заглавие: ");
                note.Title = Console.ReadLine();
                Console.WriteLine("Въведи описание: ");
                note.Description = Console.ReadLine();
                Console.WriteLine("Въведи дата: ");
                note.Dataa = Console.ReadLine();
                Console.WriteLine("Въведи важнота(1/10): ");
                note.Level = int.Parse(Console.ReadLine());
                noteCreate.Update(note);
            }
            else
            {
                Console.WriteLine("Бележката не е намерена!");
            }
        }

        private void Add()
        {
            Note note = new Note();
            Console.WriteLine("Въведи заглавие: ");
            note.Title = Console.ReadLine();
            Console.WriteLine("Въведи описание: ");
            note.Description = Console.ReadLine();
            Console.WriteLine("Въведи дата: ");
            note.Dataa = Console.ReadLine();
            Console.WriteLine("Въведи важност(1/10): ");
            note.Level = int.Parse(Console.ReadLine());
            noteCreate.Add(note);
        }

        private void ListAll()
        {
            Console.WriteLine(new string('*', 40));
            Console.WriteLine("*" + new string(' ', 12) + "Всички бележки" + new string(' ', 12) + "*");
            Console.WriteLine(new string('*', 40));
            var notes = noteCreate.GetAll();
            foreach (var item in notes)
            {
                Console.WriteLine();
                Console.WriteLine("{0} {1} {2} {3} {4}", item.Id, item.Title, item.Description, item.Dataa, item.Level);
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', 18) + "Край" + new string('-', 18));
            Console.WriteLine();
        }
        private void LongestDescription()
        {
            Console.WriteLine(new string('*', 40));
            Console.WriteLine("*" + new string(' ', 12) + "Всички бележки" + new string(' ', 12) + "*");
            Console.WriteLine(new string('*', 40));

            var notes = noteCreate.Longest();
            foreach (var item in notes)
            {
                Console.WriteLine();
                Console.WriteLine("{0} {1} {2} {3} {4}", item.Id, item.Title, item.Description, item.Dataa, item.Level);
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', 18) + "Край" + new string('-', 18));
            Console.WriteLine();
        }
        private void BetweenDataa()
        {
            Console.WriteLine("Въведи начална дата: ");
            string startdata=Console.ReadLine();
            Console.WriteLine("Въведи крайна дата: ");
            string enddata = Console.ReadLine();

            var notes = noteCreate.Between(startdata, enddata);
            foreach (var item in notes)
            {
                Console.WriteLine();
                Console.WriteLine("{0} {1} {2} {3} {4}", item.Id, item.Title, item.Description, item.Dataa, item.Level);
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', 18) + "Край" + new string('-', 18));
            Console.WriteLine();
        }
        private void OfLevel()
        {
            Console.WriteLine("Въведи важност: ");
            int level = int.Parse(Console.ReadLine());

            var notes = noteCreate.OfLevel(level);

            foreach (var item in notes)
            {
                Console.WriteLine();
                Console.WriteLine("{0} {1} {2} {3} {4}", item.Id, item.Title, item.Description, item.Dataa, item.Level);
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', 18) + "Край" + new string('-', 18));
            Console.WriteLine();
        }


    }
}
