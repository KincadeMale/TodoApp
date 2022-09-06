using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Data;

namespace TodoApp.Services
{
    internal class CommentsService : Data.TODOEntities
    {
        public List<Comment> GetComments(long todoKey)
        {
            return base.Comments.Where(a => a.TodoKey == todoKey).ToList();
        }

        public int CreateComment(long todoKey, string comment)
        {
            base.Comments.Add(new Data.Comment()
            {
                Key = GetNextCommentKey(),
                TodoKey = todoKey,
                Comment1 = comment,
                CommentDate = DateTime.Now.Date,
                UserName = System.Security.Principal.WindowsIdentity.GetCurrent().Name
            });

            return base.SaveChanges();
        }

        public int DeleteComment(long commentKey)
        {
            var item = base.Comments.Where(a => a.Key == commentKey).FirstOrDefault();
            base.Comments.Remove(item);
            return base.SaveChanges();
        }

        public int DeleteTodoListComment(long todoKey)
        {
            var item = base.Comments.Where(a => a.TodoKey == todoKey);
            
            foreach(var i in item)
            {
                base.Comments.Remove(i);
            }

            return base.SaveChanges();
        }

        public int UpdateComment(long commentKey, string newComment)
        {
            var comment = base.Comments.Where(a => a.Key == commentKey).FirstOrDefault();

            if(comment != null)
            {
                comment.Comment1 = newComment;

                base.Entry(comment).State = System.Data.EntityState.Modified;
            }

            return base.SaveChanges();
        }

        public string GetComment(long CommentKey)
        {
            var item = base.Comments.Where(a => a.Key == CommentKey).FirstOrDefault();

            if (item != null)
            {
                return item.Comment1;
            }

            return "";
        }

        private long GetNextCommentKey()
        {
            var item = base.Comments.OrderByDescending(a => a.Key).FirstOrDefault();

            if(item == null)
            {
                return 1;
            }
            else
            {
                return item.Key + 1;
            }
        }
    }
}
