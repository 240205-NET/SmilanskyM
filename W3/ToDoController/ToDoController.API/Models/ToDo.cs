﻿namespace ToDoController.API.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool Completed { get; set; }
    }
}
