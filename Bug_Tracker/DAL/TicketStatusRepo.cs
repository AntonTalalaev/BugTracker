using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Bug_Tracker.Models;

namespace Bug_Tracker.DAL
{
    public class TicketStatusRepo : IRepository<TicketStatus>
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public virtual void Add(TicketStatus entity)
        {
            db.TicketStatuses.Add(entity);
            db.SaveChanges();
        }
        public virtual List<TicketStatus> GetCollection()
        {
            return db.TicketStatuses.ToList();
        }

        public IEnumerable<TicketStatus> GetCollection(Func<TicketStatus, bool> condition)
        {
            return db.TicketStatuses.Where(condition);
        }

        public TicketStatus GetEntity(int id)
        {
            return db.TicketStatuses.Find(id);
        }

        public TicketStatus GetEntity(Func<TicketStatus, bool> condition)
        {
            return db.TicketStatuses.FirstOrDefault(condition);
        }

        public void Update(TicketStatus entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}