using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WebAutomationSystem.DataModelLayer.Entities;

namespace WebAutomationSystem.DataModelLayer.CqrsCommands.NewsCommand.Models
{
    public class GetAllNewsCommandModel : IRequest<IList<News>>
    {
        //Response
        public int NewsID { get; set; }
        public string NewsTitle { get; set; }
        public string NewsContent { get; set; }
        public DateTime NewsDate { get; set; }
        public string NewsAttachment { get; set; }
        public string UserID { get; set; }
    }
}