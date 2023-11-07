using StudentsManager.DAL.Entities;

namespace DAL.Entities
{
    public class StudentView : NamedEntity
    {
        public string LastName { get; set; }
        public string Patronymic { get; set; }

        public StudentView() : base()
        {
            LastName = "";
            Patronymic = "";
        }

        public StudentView(Student student)
        {
            Id = student.Id;
            Name = student.Name;
            LastName = student.LastName;
            Patronymic = student.Patronymic;
        }
    }
}