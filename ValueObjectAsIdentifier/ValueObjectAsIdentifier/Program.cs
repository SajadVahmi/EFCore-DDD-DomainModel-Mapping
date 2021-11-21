using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using UseValueObjectAsIdentifier.Domain.Models;
using UseValueObjectAsIdentifier.Persistence.DbContexts;

namespace UseValueObjectAsIdentifier
{
    class Program
    {
        static void Main(string[] args)
        {

            var dbContext = new UniversityDbContext();
            Console.WriteLine("--------------------------------Insert a student----------------------------------------------------");
            var studentForInsert = Student.CreateWith(
                id: Guid.NewGuid(),
                firstName: Faker.Name.First(),
                lastName: Faker.Name.Last()
                );
            dbContext.Add(studentForInsert);
            dbContext.SaveChanges();
            Console.WriteLine($"Inserted Id: {studentForInsert.Id.Value}");
            Console.WriteLine($"Inserted FirstName: {studentForInsert.FirstName}");
            Console.WriteLine($"Inserted LastName: {studentForInsert.LastName}");

            Console.WriteLine("--------------------------------Fetch a student from database---------------------------------------");
            var studentFromDatabaseQuery = dbContext.Students.Where(s => s.Id == studentForInsert.Id);
            Console.WriteLine($"SQL Query For Fetch is: {studentFromDatabaseQuery.ToQueryString()}");
            var studentFromDatabase = studentFromDatabaseQuery.FirstOrDefault();
            Console.WriteLine($"Fetched Id: {studentFromDatabase.Id.Value}");
            Console.WriteLine($"Fetched FirstName: {studentFromDatabase.FirstName}");
            Console.WriteLine($"Fetched LastName: {studentFromDatabase.LastName}");



            Console.WriteLine("--------------------------------Insert three course----------------------------------------------------");
            var firstCourseForInsert = Course.CreateWith(
                id: Guid.NewGuid(),
                name: "FirstCourse",
                unit: Faker.RandomNumber.Next(1, 3)
                );
            dbContext.Add(firstCourseForInsert);
            dbContext.SaveChanges();
            Console.WriteLine($"First Inserted Id: {firstCourseForInsert.Id.Value}");
            Console.WriteLine($"First Inserted Name: {firstCourseForInsert.Name}");
            Console.WriteLine($"First Inserted Unit: {firstCourseForInsert.Unit}");

            var secondCourseForInsert = Course.CreateWith(
                id: Guid.NewGuid(),
                name: "SecondCourse",
                unit: Faker.RandomNumber.Next(1, 3)
                );
            dbContext.Add(secondCourseForInsert);
            dbContext.SaveChanges();
            Console.WriteLine($"Second Inserted Id: {secondCourseForInsert.Id.Value}");
            Console.WriteLine($"Second Inserted Name: {secondCourseForInsert.Name}");
            Console.WriteLine($"Second Inserted Unit: {secondCourseForInsert.Unit}");

            var thirdCourseForInsert = Course.CreateWith(
                id: Guid.NewGuid(),
                name: "ThirdCourse",
                unit: Faker.RandomNumber.Next(1, 3)
                );
            dbContext.Add(thirdCourseForInsert);
            dbContext.SaveChanges();
            Console.WriteLine($"Third Inserted Id: {thirdCourseForInsert.Id.Value}");
            Console.WriteLine($"Third Inserted FirstName: {thirdCourseForInsert.Name}");
            Console.WriteLine($"Third Inserted LastName: {thirdCourseForInsert.Unit}");



            Console.WriteLine("--------------------------------Fetch courses from database---------------------------------------");
            var fistCourseFromDatabaseQuery = dbContext.Courses.Where(s => s.Id == firstCourseForInsert.Id);
            Console.WriteLine($"SQL Query For Fetch is: {fistCourseFromDatabaseQuery.ToQueryString()}");
            var firstCourseFromDatabase = fistCourseFromDatabaseQuery.FirstOrDefault();
            Console.WriteLine($"First Fetched Id: {firstCourseFromDatabase.Id.Value}");
            Console.WriteLine($"First Fetched Name: {firstCourseFromDatabase.Name}");
            Console.WriteLine($"First Fetched Unit: {firstCourseFromDatabase.Unit}");


            var secondCourseFromDatabaseQuery = dbContext.Courses.Where(s => s.Id == secondCourseForInsert.Id);
            Console.WriteLine($"SQL Query For Fetch is: {secondCourseFromDatabaseQuery.ToQueryString()}");
            var secondCourseFromDatabase = secondCourseFromDatabaseQuery.FirstOrDefault();
            Console.WriteLine($"Second Fetched Id: {secondCourseFromDatabase.Id.Value}");
            Console.WriteLine($"Second Fetched Name: {secondCourseFromDatabase.Name}");
            Console.WriteLine($"Second Fetched Unit: {secondCourseFromDatabase.Unit}");

            var thirdCourseFromDatabaseQuery = dbContext.Courses.Where(s => s.Id == thirdCourseForInsert.Id);
            Console.WriteLine($"SQL Query For Fetch is: {thirdCourseFromDatabaseQuery.ToQueryString()}");
            var thirdCourseFromDatabase = thirdCourseFromDatabaseQuery.FirstOrDefault();
            Console.WriteLine($"third Fetched Id: {thirdCourseFromDatabase.Id.Value}");
            Console.WriteLine($"third Fetched Name: {thirdCourseFromDatabase.Name}");
            Console.WriteLine($"third Fetched Unit: {thirdCourseFromDatabase.Unit}");


            Console.WriteLine("--------------------------------Insert two studentcourses ---------------------------------------");
            var firstStudentCourse = StudentCourse.CreateWith(
                id: Guid.NewGuid(),
                studentId: studentFromDatabase.Id,
                courseId: firstCourseFromDatabase.Id,
                mark: Faker.RandomNumber.Next(10, 20));
            dbContext.Add(firstStudentCourse);
            dbContext.SaveChanges();
            Console.WriteLine($"First Inserted Id: {firstStudentCourse.Id.Value}");
            Console.WriteLine($"First Inserted StudentId: {firstStudentCourse.StudentId.Value}");
            Console.WriteLine($"First Inserted CourseId: {firstStudentCourse.CourseId.Value}");
            Console.WriteLine($"First Inserted Mark: {firstStudentCourse.Mark}");

            var secondStudentCourse = StudentCourse.CreateWith(
                id: Guid.NewGuid(),
                studentId: studentFromDatabase.Id,
                courseId: thirdCourseFromDatabase.Id,
                mark: Faker.RandomNumber.Next(10, 20));
            dbContext.Add(secondStudentCourse);
            dbContext.SaveChanges();
            Console.WriteLine($"Second Inserted Id: {secondStudentCourse.Id.Value}");
            Console.WriteLine($"Second Inserted StudentId: {secondStudentCourse.StudentId.Value}");
            Console.WriteLine($"Second Inserted CourseId: {secondStudentCourse.CourseId.Value}");
            Console.WriteLine($"Second Inserted Mark: {secondStudentCourse.Mark}");

            Console.WriteLine("--------------------------------Insert a studentcourse with inavlid studentId ---------------------------------------");
            try
            {
                var studentCourseWithInvalidStudentId = StudentCourse.CreateWith(
                   id: Guid.NewGuid(),
                   studentId: new StudentId(Guid.NewGuid()),
                   courseId: firstCourseFromDatabase.Id,
                   mark: Faker.RandomNumber.Next(10, 20));
                dbContext.Add(studentCourseWithInvalidStudentId);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }


            Console.WriteLine("--------------------------------Insert a studentcourse with inavlid courseId ---------------------------------------");
            try
            {
                var studentCourseWithInvalidCourseId = StudentCourse.CreateWith(
                   id: Guid.NewGuid(),
                   studentId: studentFromDatabase.Id,
                   courseId: new CourseId(Guid.NewGuid()),
                   mark: Faker.RandomNumber.Next(10, 20));
                dbContext.Add(studentCourseWithInvalidCourseId);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }


        }
    }
}
