using MediatR;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebAutomationSystem.DataModelLayer.CqrsCommands.NewsCommand.Models;
using WebAutomationSystem.DataModelLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebAutomationSystem.DataModelLayer.CqrsCommands.NewsCommand.CRUD.GetAllNews
{
    public class GetAllNewsHandler : IRequestHandler<GetAllNewsCommandModel, IList<News>>
    {
        private readonly ApplicationDbContext _context;

        public GetAllNewsHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IList<News>> Handle(GetAllNewsCommandModel request, CancellationToken cancellationToken)
        {
            var model = await _context.News.Where(n => n.flag == true).ToListAsync();
            return model;
        }
    }
}