﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Exam_System.Models;

public partial class QuestionExam
{
    public int ExamId { get; set; }

    public int QuestionId { get; set; }

    public virtual Exam Exam { get; set; }

    public virtual Question Question { get; set; }
}