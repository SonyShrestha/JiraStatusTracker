using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using JiraProgressTracker.Dtos;
using JiraProgressTracker.Models;

namespace JiraProgressTracker.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Ticket, TicketDto>();
            Mapper.CreateMap<TicketDto, Ticket>();

        }
    }
}