using System.Collections.Generic;

namespace University.Models
{
    public class Teacher : Human
    {
        public enum Genders
        {
            Male,
            Female
        };

        public Dictionary<Genders, string> GendersDisplayNames = new Dictionary<Genders, string>
        {
            { Genders.Female, "Ms" },
            { Genders.Male, "Mr" }
        };

        public Teacher(int id, Genders gender, string name,
            string patronymic, string lesson, int age, int univerId)
        {
            Id = id;
            Gender = gender;
            Name = name;
            Patronymic = patronymic;
            Lesson = lesson;
            Age = age;
            UniverId = univerId;
        }

        public Genders Gender { get; set; }

        public string Patronymic { get; set; } // Отчество

        public string Lesson { get; set; }
        public int UniverId { get; set; }
    }
}