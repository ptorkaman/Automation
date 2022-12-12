using MediatR;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebAutomationSystem.DataModelLayer.CqrsCommands.NewsCommand.Models;

namespace WebAutomationSystem.DataModelLayer.CqrsCommands.NewsCommand.CRUD.Update
{
    public class DeActiveNewsCommandHandler : IRequestHandler<DeActiveCommandModel, int>
    {
        private readonly ApplicationDbContext _context;
        public DeActiveNewsCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeActiveCommandModel request, CancellationToken cancellationToken)
        {
            var result = (from n in _context.News where n.NewsID == request.NewsID select n);
            var currentNews = result.FirstOrDefault();

            if (result.Count() > 0)
            {
                currentNews.flag = false;

                //
                _context.News.Attach(currentNews);
                _context.Entry(currentNews).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _context.SaveChangesAsync();

            }
            return request.NewsID;
        }
    }
}
