using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelsApp.DAL.EF;
using TravelsApp.DAL.Entities;
using TravelsApp.DAL.Interfaces;

namespace TravelsApp.DAL.Repositories
{
    class CommentRepository : IRepository<Comment>
    {
        private TravelsContext db;

        public CommentRepository(TravelsContext db)
        {
            this.db = db;
        }

        public void Create(Comment item)
        {
            db.Comments.Add(item);
        }

        public void Delete(int id)
        {
            Comment comment = db.Comments.Find(id);
            if (comment != null)
                db.Comments.Remove(comment);
        }

        public IEnumerable<Comment> Find(Func<Comment, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Comment Get(int id)
        {
            return db.Comments.Find(id);
        }

        public IEnumerable<Comment> GetAll()
        {
            return db.Comments;
        }

        public void Update(Comment item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
