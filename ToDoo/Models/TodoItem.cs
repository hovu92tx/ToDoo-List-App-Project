using System;
using SQLite;
namespace ToDoo.Models
{
    public class TodoItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        //public string Description { get; set; }
        public DateTime Due { get; set; }
        public bool Completed { get; set; }
    }
}
