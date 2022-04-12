using JiraProgressTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using JiraProgressTracker.ViewModels;

namespace JiraProgressTracker.Controllers
{
    public class TicketsController : Controller
    {
        private AppDbContext _context;
        public TicketsController()
        {
            _context = new AppDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Tickets
        public ActionResult Index()
        {
            var ticket = _context.Tickets.Include(c=>c.Status).Include(c => c.TicketType).ToList();
            return View(ticket);
        }

        
        public ActionResult AddTicket(int? id)
        {
            if (id != 0)
            {
                var status = _context.Status.ToList();
                var ticket_type = _context.TicketType.ToList();
                var priority = _context.Priority.ToList();
                var ticket = _context.Tickets.SingleOrDefault(c => c.Id==id);
                var model = new TicketStatusViewModel()
                {
                    Ticket = ticket,
                    Priority=priority,
                    TicketType=ticket_type,
                    Status = status
                };
                return View(model);
            }
            else
            {
                var status = _context.Status.ToList();
                var ticket_type = _context.TicketType.ToList();
                var priority = _context.Priority.ToList();
                var model = new TicketStatusViewModel()
                {
                    Status = status,
                    TicketType=ticket_type,
                    Priority=priority
                };
                return View(model);
            }
        }

        public ActionResult Delete(int id)
        {
            var ticketInDb = _context.Tickets.SingleOrDefault(c=>c.Id==id);
            if (ticketInDb == null)
            {
                return HttpNotFound();
            }
            else
            {
                _context.Tickets.Remove(ticketInDb);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Details(int id)
        {
            var ticket = _context.Tickets.Include(c=>c.Status).Include(c=>c.Priority).Include(c => c.TicketType).SingleOrDefault(c => c.Id == id);
            if(ticket is null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(ticket);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(TicketStatusViewModel vmModel)
        {
            if (!ModelState.IsValid)
            {
                var ticket = vmModel.Ticket;
                var status = _context.Status.ToList();
                var ticket_type = _context.TicketType.ToList();
                var priority = _context.Priority.ToList();
                var vwModel_ = new TicketStatusViewModel()
                {
                    Ticket= ticket,
                    Status = status,
                    TicketType=ticket_type,
                    Priority=priority
                };
                return View("AddTicket", vwModel_);
            }
            else
            {
                var ticketInDb = _context.Tickets.SingleOrDefault(c => c.Id == vmModel.Ticket.Id);
                
                if (ticketInDb == null)
                {
                    var ticket = new Ticket()
                    {
                        TicketNumber = vmModel.Ticket.TicketNumber,
                        JiraLink = vmModel.Ticket.JiraLink,
                        Description = vmModel.Ticket.Description,
                        Assignee = vmModel.Ticket.Assignee,
                        IsSupportTicket = vmModel.Ticket.IsSupportTicket,
                        StatusId = vmModel.Ticket.StatusId,
                        Comments= vmModel.Ticket.Comments,
                        TicketTypeId= vmModel.Ticket.TicketTypeId,
                        PriorityId=vmModel.Ticket.PriorityId
                    };
                    _context.Tickets.Add(ticket);
                }
                else
                {
                    ticketInDb.TicketNumber = vmModel.Ticket.TicketNumber;
                    ticketInDb.JiraLink = vmModel.Ticket.JiraLink;
                    ticketInDb.Description = vmModel.Ticket.Description;
                    ticketInDb.Assignee = vmModel.Ticket.Assignee;
                    ticketInDb.IsSupportTicket = vmModel.Ticket.IsSupportTicket;
                    ticketInDb.StatusId = vmModel.Ticket.StatusId;
                    ticketInDb.Comments = vmModel.Ticket.Comments;
                    ticketInDb.TicketTypeId = vmModel.Ticket.TicketTypeId;
                    ticketInDb.PriorityId = vmModel.Ticket.PriorityId;

                }
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}