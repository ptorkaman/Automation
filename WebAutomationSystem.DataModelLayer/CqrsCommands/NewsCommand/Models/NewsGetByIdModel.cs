using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAutomationSystem.DataModelLayer.CqrsCommands.NewsCommand.Models
{
    public class NewsGetByIdModel : IRequest<NewsUpdateCommandModel>
    {
        public int NewsID { get; set; }
    }
}
