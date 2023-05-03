using System;
using System.Dynamic;
using System.Threading;

namespace Pract15
{
    public class StudentGroup
    {
        public int NumberStudent { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public DateTime DataOfBirth { get; set; }

        public string NumberPhone { get; set; }

        public StudentGroup(int numberStudent, string firstName, string middleName, string lastName,
            DateTime dataOfBirth, string numberPhone)
        {
            if (numberStudent <= 0)
            {
                throw new ArgumentException("Номер студента не может быть 0 или меньше 0");
            }

            if (string.IsNullOrWhiteSpace(numberStudent.ToString()))
            {
                throw new ArgumentException("Поле номера студента не может быть пустым");
            }

            foreach (var el in firstName)
            {
                if (char.IsDigit(el))
                {
                    throw new ArgumentException("Имя не может содержать цифры");
                }
            }

            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("Поле Имя не может быть пустым");
            }

            foreach (var el in middleName)
            {
                if (char.IsDigit(el))
                {
                    throw new ArgumentException("Фамилия не может содержать цифры");
                }
            }

            if (string.IsNullOrWhiteSpace(middleName))
            {
                throw new ArgumentException("Поле Фамилия не может быть пустым");
            }

            foreach (var el in lastName)
            {
                if (char.IsDigit(el))
                {
                    throw new ArgumentException("Отчество не может содержать цифры");
                }
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("Поле Отчество не может быть пустым");
            }

            foreach (var el in numberPhone)
            {
                if (!char.IsDigit(el))
                {
                    throw new ArgumentException("Номер телефона не может содержать букв");
                }
            }

            if (string.IsNullOrWhiteSpace(numberPhone))
            {
                throw new ArgumentException("Поле Номер телефона не может быть пустым");
            }

            NumberStudent = numberStudent;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            DataOfBirth = dataOfBirth;
            NumberPhone = numberPhone;
        }

        public StudentGroup()
        {
        }
    }
}