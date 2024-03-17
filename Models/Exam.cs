﻿using System;
using System.Collections.Generic;

namespace Exam_System.Models;

public partial class Exam
{
    public int ExamId { get; set; }

    public DateOnly? ExamDate { get; set; }

    public TimeOnly? StartTime { get; set; }

    public TimeOnly? EndTime { get; set; }

    public TimeOnly? Duration { get; set; }

    public int? CourseId { get; set; }

    public int? TrackId { get; set; }

    public int? InstructorId { get; set; }

    public int? FullMark { get; set; }

    public virtual Course? Course { get; set; }

    public virtual Instructor? Instructor { get; set; }

    public virtual ICollection<StudentAnswer> StudentAnswers { get; set; } = new List<StudentAnswer>();

    public virtual Track? Track { get; set; }

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
}
