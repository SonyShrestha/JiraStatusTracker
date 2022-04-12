using JiraProgressTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JiraProgressTracker.Dtos;
using AutoMapper;

namespace JiraProgressTracker.Controllers.API
{
    public class TicketsController : ApiController
    {
        private AppDbContext _context;
        public TicketsController()
        {
            _context = new AppDbContext();
        }

        public IEnumerable<TicketDto> GetTicket()
        {
            return _context.Tickets.ToList().Select(Mapper.Map<Ticket,TicketDto>);
        }

        public IHttpActionResult GetTicket(int id)
        {
            var ticket = _context.Tickets.SingleOrDefault(c => c.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Mapper.Map<Ticket,TicketDto>(ticket));
            }
        }


        [HttpPost]
        public IHttpActionResult CreateTicket(TicketDto ticketdto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                var ticket=Mapper.Map<TicketDto, Ticket>(ticketdto);
                _context.Tickets.Add(ticket);
                _context.SaveChanges();
                ticketdto.Id = ticket.Id;
                return Created(new Uri(Request.RequestUri + "/" + ticket.Id), ticketdto); ;
            }
        }

        [HttpPut]
        public void UpdateTicket(int id, TicketDto ticketdto)
        {
            ticketdto.Id = id;
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            else
            {
                var ticketInDb = _context.Tickets.SingleOrDefault(c => c.Id == id);
                if (ticketInDb == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                else
                {
                    Mapper.Map<TicketDto, Ticket>(ticketdto, ticketInDb);
                    
                    _context.SaveChanges();
                    
                }
            } 
        }

        [HttpDelete]
        public void DeleteTicket(int id)
        {
            var ticketInDb = _context.Tickets.SingleOrDefault(c=>c.Id==id);
            if (ticketInDb is null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                _context.Tickets.Remove(ticketInDb);
                _context.SaveChanges();
            }   
        }
    }
}
