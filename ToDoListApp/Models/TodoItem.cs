using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListApp.Services;

namespace ToDoListApp.Models
{
    
    public class TodoItem
    {
        
        public int Id{ get; set; } 
        public string Title { get; set; }  
        public  DateTime CreatedDate { get; set; }
        public bool IsCompleted { get; set; }

       // public string t { get; set; }



    }
}
