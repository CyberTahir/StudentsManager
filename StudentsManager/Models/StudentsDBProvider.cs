using DAL.Entities;
using StudentsManager.DAL.Context;
using System.Linq;

namespace StudentsManager.Models
{
    public class StudentsDBProvider
    {
        public StudentsDBContext DbContext { get; }
        public StudentsDBProvider(StudentsDBContext db)
        {
            DbContext = db;
        }

        private void Save()
        {
            DbContext.SaveChanges();
        }
        public Student Get(int id)
        {
            return DbContext.Students
                .FirstOrDefault(stud => stud.Id == id);
        }
        public IQueryable<StudentView> GetStudents()
        {
            return DbContext.Students
                .OrderBy(stud => stud.Id)
                .Select(stud => new StudentView(stud));
        }
        public void Create(StudentView sv)
        {
            var stud = new Student
            {
                Name = sv.Name,
                LastName = sv.LastName,
                Patronymic = sv.Patronymic
            };

            DbContext.Students.Add(stud);
            Save();
        }
        public void Update(StudentView sv)
        {
            var stud = Get(sv.Id);

            stud.LastName = sv.LastName;
            stud.Name = sv.Name;
            stud.Patronymic = sv.Patronymic;

            Save();
        }
        public void Delete(int id)
        {
            var stud = Get(id);

            DbContext.Students.Remove(stud);
            Save();
        }
    }
}