﻿using System;
using System.Collections.Generic;

namespace Exam_System.Models;

public partial class Admin
{
    public int AdminId { get; set; }

    public string? AdminFname { get; set; }

    public string? AdminLname { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }
}
