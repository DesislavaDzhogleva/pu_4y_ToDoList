﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public ICollection<UserTask> UserTasks { get; set; }
    }
}

