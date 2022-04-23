using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace laba8
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // пересоздадим базу данных
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                var faculty1 = new Faculty
                {
                    NameFaculty = "Факультет Компьютерных технологий и информационной безопасности",
                    ShortNameFaculty = "ФКТиИБ"
                };
                var faculty2 = new Faculty
                {
                    NameFaculty = "Факультет Менеджмента и предпринимательства",
                    ShortNameFaculty = "ФМиП"
                };
                var chair1 = new Chair
                {
                    Faculty = faculty1,
                    NameChair = "Кафедра Информационных систем и прикладной информатики",
                    ShortNameChair = "КИСиПИ"
                };
                var chair2 = new Chair
                {
                    Faculty = faculty2,
                    NameChair = "Общий и стратегический менеджмент",
                    ShortNameChair = "ОиСМ"
                };
                var cur1 = new Curriculum
                {
                    AcademicYear = 2022,
                    Speciality = "03.03.03",
                    Qualification = "Бакалавриат",
                    FormEducation = "Очная",
                    NameCurriculum = "Управление данными",
                    Course = 2
                };
                var cur2 = new Curriculum
                {
                    AcademicYear = 2022,
                    Speciality = "03.02.01",
                    Qualification = "Бакалавриат",
                    FormEducation = "Очная",
                    NameCurriculum = "Философия",
                    Course = 3
                };
                var dis1 = new Discipline
                {
                    Chair = chair1,
                    Curriculum = cur1,
                    NameDiscipline = "Управление данными",
                    Course = 2,
                    Semester = 4,
                    Lecture = 8,
                    Laboratory = 7,
                    Practical = 9,
                    Examen = true,
                    SetOff = false
                };
                var dis2 = new Discipline
                {
                    Chair = chair1,
                    Curriculum = cur1,
                    NameDiscipline = "Проектирование баз данных",
                    Course = 2,
                    Semester = 4,
                    Lecture = 8,
                    Laboratory = 7,
                    Practical = 9,
                    Examen = true,
                    SetOff = false
                };
                var dis3 = new Discipline
                {
                    Chair = chair2,
                    Curriculum = cur2,
                    NameDiscipline = "Философия",
                    Course = 2,
                    Semester = 4,
                    Lecture = 8,
                    Laboratory = 7,
                    Practical = 9,
                    Examen = true,
                    SetOff = false
                };
                db.Facultys.AddRange(faculty1, faculty2);
                db.Chairs.AddRange(chair1, chair2);
                db.Curriculums.AddRange(cur1, cur2);
                db.Disciplines.AddRange(dis1, dis2, dis3);
                db.SaveChanges();
            }
            using (ApplicationContext db = new ApplicationContext())
            {
                Console.WriteLine("Загрузка данных со сложной структурой с использованием метода TheInclude(): ");
                var ds = db.Disciplines
                .Include(u => u.Curriculum)
                .Include(i => i.Chair)
                .ThenInclude(o => o.Faculty)
                .ToList();
                foreach (var d in ds)
                {
                    Console.WriteLine($"{d.Id}. Кафедра: {d.Chair.ShortNameChair}, " +
                                        $"Учебный план: {d.Curriculum.Speciality}, " +
                                        $"Наименование дисциплины: {d.NameDiscipline}, " +
                                        $"Курс: {d.Course}, \n\t\tСеместр: {d.Semester}, " +
                                        $"Количество лекций: {d.Lecture}, " +
                                        $"Количество лабораторных занятий: {d.Laboratory}, " +
                                        $"Количество практических занятий: {d.Practical}, " +
                                        $"Экзнамен: {d.Examen}, " +  
                                        $"Зачет: {d.SetOff}");
                }
            }
            using (ApplicationContext db = new ApplicationContext())
            {
                Console.WriteLine("\n\n\nЯвная загрузка данных со сложной структурой: ");
                var ds = db.Disciplines.ToList();
                foreach (var d in ds)
                {
                    db.Curriculums.Where(u => u.Id == d.CurriculumId).Load();
                    db.Chairs.Where(i => i.Id == d.ChairId).Load();
                    db.Facultys.Where(o => o.Id == d.Chair.FacultyId).Load();
                     
                    Console.WriteLine($"{d.Id}. Кафедра: {d.Chair.ShortNameChair}, " +
                                        $"Учебный план: {d.Curriculum.Speciality}, " +
                                        $"Наименование дисциплины: {d.NameDiscipline}, " +
                                        $"Курс: {d.Course}, \n\t\tСеместр: {d.Semester}, " +
                                        $"Количество лекций: {d.Lecture}, " +
                                        $"Количество лабораторных занятий: {d.Laboratory}, " +
                                        $"Количество практических занятий: {d.Practical}, " +
                                        $"Экзнамен: {d.Examen}, " +
                                        $"Зачет: {d.SetOff}");
                }
            }
        }
    }
}
