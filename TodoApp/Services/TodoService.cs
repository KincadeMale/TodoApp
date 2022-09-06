using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Data;

namespace TodoApp.Services
{
    internal class TodoService : Data.TODOEntities
    {
        public List<ToDoList> GetTodoList()
        {
            return base.ToDoLists.ToList();
        }

        public int CreateTask(string description, DateTime date)
        {
            base.ToDoLists.Add(new Data.ToDoList()
            {
                Key = GetNextKey(),
                Description = description,
                Date = date,
                Done = false
            });

            return base.SaveChanges();
        }

        private long GetNextKey()
        {
            var item = base.ToDoLists.OrderByDescending(a => a.Key).FirstOrDefault();
            
            if(item == null)
            {
                return 1;
            }
            else
            {
                return item.Key + 1;
            }
        }

        public int DeleteTask(long key)
        {
            var item = base.ToDoLists.Where(a => a.Key == key).FirstOrDefault();
            base.ToDoLists.Remove(item);
            return base.SaveChanges();
        }
    }
}
