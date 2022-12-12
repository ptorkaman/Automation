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
    public class NewsUpdateCommandHandler : IRequestHandler<NewsUpdateCommandModel, int>
    {
        private readonly ApplicationDbContext _context;
        public NewsUpdateCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(NewsUpdateCommandModel request, CancellationToken cancellationToken)
        {
            var result = (from n in _context.News where n.NewsID == request.NewsID select n);
            var currentNews = result.FirstOrDefault();

            if (result.Count() > 0)
            {

                currentNews.NewsTitle = request.NewsTitle;
                currentNews.NewsContent = request.NewsContent;
                currentNews.NewsAttachment = request.NewsAttachment;

                //
                _context.News.Attach(currentNews);
                _context.Entry(currentNews).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _context.SaveChangesAsync();
               
            }
            return request.NewsID;
        }
    }
}