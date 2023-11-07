using Microsoft.EntityFrameworkCore;

namespace DAL.Entities
{
    [Index(nameof(LastName), nameof(Name), nameof(Patronymic), IsUnique = true)]
    public class Student : NamedEntity
    {
        public string LastName { get; set; }
        public string Patronymic { get; set; }

        public Student() : base()
        {
            LastName = "";
            Patronymic = "";
        }
    }
}