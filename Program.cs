using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Xml.Schema;

namespace ConsoleApp2
{

    class Program
    {
        List<Contact> Notebook = new List<Contact>();
        public static void Main(string[] args)
        {
            Console.WriteLine("Приложение Записная книжка.\n");
            Program p = new Program();
            NoteBook nb = new NoteBook();
            nb.NewAction();
        }

        public class NoteBook
        {
            Program p = new Program();

            public void Add()
            {
                Console.WriteLine("Введите фамилию");
                string f = Console.ReadLine();
                if (f == "")
                {
                    Console.WriteLine("Поле является обязательным. Попробуйте снова:");
                    Console.WriteLine("Введите фамилию");
                    f = Console.ReadLine();
                }

                Console.WriteLine("Введите имя");
                string name = Console.ReadLine();
                if (name == "")
                {
                    Console.WriteLine("Поле является обязательным. Попробуйте снова:");
                    Console.WriteLine("Введите имя:");
                    name = Console.ReadLine();
                }
                Console.WriteLine("Введите отчество(необязательно)");
                string secondName = Console.ReadLine();
                Console.WriteLine("Введите номер телефона");
                string pn = Console.ReadLine();
                if (pn == "")
                {
                    Console.WriteLine("Поле является обязательным. Попробуйте снова:");
                    Console.WriteLine("Введите номер телефона");
                    pn = Console.ReadLine();
                }
                Console.WriteLine("Введите страну");
                string country = Console.ReadLine();
                Console.WriteLine("Введите день рождения в формате дд");
                string date = Console.ReadLine();
                Console.WriteLine("Введите место работы");
                string org = Console.ReadLine();
                Console.WriteLine("Введите должность");
                string vac = Console.ReadLine();
                Console.WriteLine("Введите дополнительную информацию");
                string add = Console.ReadLine();
                p.Notebook.Add(new Contact(name, f, secondName, pn, country, date, org, vac, add));
                Console.WriteLine("Контакт " + name + " " + f + "добавлен в телефонную книгу ");
            }

            public void Change()
            {
                Console.WriteLine("Какой параметр вы хотели бы изменить?\n-1 Фамлия \n -2 Имя \n -3 Отчество \n-4 Номер телефона\n -5 Страну\n -6 День рожденья\n -7 Место работы \n-8 Должность -\n -9 Дополнительная информация");
                int number = int.Parse(Console.ReadLine());
                switch (number)
                {
                    case 1:
                        Console.WriteLine("Введите новую фамилию:");
                        p.Notebook.Last().Female = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Введите новое имя:");
                        p.Notebook.Last().Name = Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("Введите новое отчество:");
                        p.Notebook.Last().SecondName = Console.ReadLine();
                        break;
                    case 4:
                        Console.WriteLine("Введите новый номер телефона");
                        p.Notebook.Last().PhoneNumber = Console.ReadLine();
                        break;
                    case 5:
                        Console.WriteLine("Введите новую страну");
                        p.Notebook.Last().Country = Console.ReadLine();
                        break;
                    case 6:
                        Console.WriteLine("Введите новый день рожденья");
                        p.Notebook.Last().dayOfBirthday = Console.ReadLine();
                        break;
                    case 7:
                        Console.WriteLine("Ввести новое место работы");
                        p.Notebook.Last().Organization = Console.ReadLine();
                        break;
                    case 8:
                        Console.WriteLine("Введите новую должность");
                        p.Notebook.Last().Vacancy = Console.ReadLine();
                        break;
                    case 9:
                        Console.WriteLine("Введите новую дополнительную информацию");
                        p.Notebook.Last().AddInformation = Console.ReadLine();
                        break;



                }
            }

            public void ShowAll()
            {
                Program p = new Program();
                Console.WriteLine("Записная книжка");
                foreach (Contact a in p.Notebook)
                {
                    Console.WriteLine("Фамилия:" + a.Female + "\n" + "Имя: " + a.Name + "\n" + "Номер телефона:" + a.PhoneNumber + "\n");
                }

            }
            public void NewAction()
            {
                Console.WriteLine("Выберите действие:\n -1 Создать новую запись\n -2 Редактировать запись \n -3 Удалить созданную запись\n -4 Просмотреть созданную запись\n -5 Просмотреть все созданные учётные записи с краткой информацией \n -6 Выход");
                int s = int.Parse(Console.ReadLine());
                if (s == 1)
                {
                    Add();
                    NewAction();
                }
                if (s == 2)
                {
                    Change();
                    NewAction();
                }

                if (s == 3)
                {
                    Console.WriteLine("Поиск контакта:");
                    Console.WriteLine("Введите фамилию");
                    string female = Console.ReadLine();
                    Console.WriteLine("Введите имя");
                    string name = Console.ReadLine();
                    Console.WriteLine("Введите номер телефона(необязательно)");
                    string pn = Console.ReadLine();
                    Console.WriteLine("Введите страну");
                    string country = Console.ReadLine();
                    p.Notebook.Remove(new Contact(female, name, pn, country));
                    NewAction();
                }
                if (s == 4)
                {
                    Console.WriteLine(p.Notebook[p.Notebook.Count - 1].ToString());
                    NewAction();
                }
                if (s == 5)
                {
                    ShowAll();
                    NewAction();
                }
                if (s == 6)
                {

                }
            }
        }


        public class Contact
        {
            public string female;
            public string name;
            public string secondName;
            public string phoneNumber;
            public string country;
            public string dayOfBirthday;
            public string organization;
            public string vacancy;
            public string addInformation;

            public string Female { get; set; }
            public string Name { get; set; }
            public string SecondName { get; set; }
            public string PhoneNumber { get; set; }
            public string Country { get; set; }
            public string DayOfBirthday { get; set; }
            public string Organization { get; set; }
            public string Vacancy { get; set; }
            public string AddInformation { get; set; }


            public Contact(string female, string name, string phoneNumber, string country)
            {
                this.female = female ?? throw new ArgumentNullException(nameof(female));
                this.name = name ?? throw new ArgumentNullException(nameof(name));
                this.phoneNumber = phoneNumber;
                this.country = country;
            }


            public Contact(string name, string female, string secondName, string pn, string c, string d, string org, string v, string add)
            {
                this.name = name;
                this.female = female;
                this.secondName = secondName;
                this.phoneNumber = pn;
                this.country = c;
                this.organization = org;
                this.vacancy = v;
                this.addInformation = add;
                this.dayOfBirthday = d;
            }

            public void ChangeContact()
            {

            }

            public override string ToString()
            {
                string str = "Фамилия: " + this.female + "\nИмя: " + this.name + "\nНомер телефона" + this.phoneNumber + "\nCтрана" + this.country;
                if (this.secondName != null)
                    str += "\nОтчество: " + this.secondName;
                else if (this.dayOfBirthday != null)
                    str += "\nДень рождения: " + this.dayOfBirthday;
                else if (this.organization != null)
                    str += "\nОрганизация: " + this.organization;
                else if (this.vacancy != null)
                    str += "\nВакансия: " + this.vacancy;
                else if (this.addInformation != null)
                    str += "\nДополнительная информация: " + this.addInformation;

                return str;

            }

            ~Contact()
            {
                Console.WriteLine("Контакт " + this.name + " " + this.female + " был удален");
            }
        }
    }
}

