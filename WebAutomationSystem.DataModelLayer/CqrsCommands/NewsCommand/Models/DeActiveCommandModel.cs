using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAutomationSystem.DataModelLayer.CqrsCommands.NewsCommand.Models
{
    public class DeActiveCommandModel : IRequest<int>
    {
        public int NewsID { get; set; }
    }
}
