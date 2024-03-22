﻿using Exam_System.IRepository;
using Exam_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Exam_System.Controllers
{
    public class InstructorController : Controller
    {
        IRepoInstructor instructor;
        IRepoStudentCourse studentCourse;
        IRepoTrack track;
        IRepoExam exams;
        public InstructorController(IRepoInstructor _instructor , IRepoStudentCourse _studentCourse,IRepoTrack _track, IRepoExam _exams)
        {
            instructor = _instructor;
            studentCourse = _studentCourse;
            track = _track;
            exams = _exams;
        }
       
        public IActionResult Index()
        {
            var userIdClaim = HttpContext.User.FindFirst("UserId");
            int id = int.Parse(userIdClaim.Value);

            var modal = instructor.getCourseForInstructor(id);
            return View(modal);
        }
        public IActionResult StudentGrades(int id)
        {
            var modal = studentCourse.getByCourseId(id);
            return View(modal);
        }
        [HttpPost]
        public IActionResult StudentGrades(int id , Dictionary<int, int> StudentGrade)
        {
            foreach (var item in StudentGrade)
            {
                var std = studentCourse.getByIds(id, item.Key);

                if (std != null && item.Value != 0)
                {

                    studentCourse.UpdateGrade(std, item.Value);
                }
            }
            return RedirectToAction("index");
        }
        public IActionResult GenerateExam(int id)
        {
            ViewBag.Tracks = track.getAll();
            return View();
        }
        [HttpPost]
        public IActionResult GenerateExam(int id,Exam exam,int numTrueFalseQuestions,int numMCQuestions)
        {
            exam.CourseId = id;

            var userIdClaim = HttpContext.User.FindFirst("UserId");
            int InstructorId = int.Parse(userIdClaim.Value);

            exam.InstructorId = InstructorId;

            bool hasConflict = exams.HasExamConflict(exam.TrackId, exam.CourseId, exam.InstructorId, exam.ExamDate, exam.StartTime, exam.EndTime);
            if (hasConflict)
            {
                ViewBag.Tracks = track.getAll();
                ViewBag.ExamConflict = "There is a conflicting exam scheduled for the same time in this track, course, and instructor.";
                return View(exam);

            }

            exams.InsertExam(exam, numTrueFalseQuestions, numMCQuestions);
            return View("Index");
        }
        public IActionResult AllExams(int id)
        {
            var modal = exams.getAll(4,id);
            return View(modal);
        }

        public IActionResult Delete(int id)
        {
            exams.Delete(id);
            return View("Index");
        }
        
    }
}
