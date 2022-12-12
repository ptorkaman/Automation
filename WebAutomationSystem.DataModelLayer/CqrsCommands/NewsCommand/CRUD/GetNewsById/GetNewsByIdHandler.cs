using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebAutomationSystem.DataModelLayer.CqrsCommands.NewsCommand.Models;

namespace WebAutomationSystem.DataModelLayer.CqrsCommands.NewsCommand.CRUD.GetNewsById
{
    public class GetNewsByIdHandler : IRequestHandler<NewsGetByIdModel, NewsUpdateCommandModel>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetNewsByIdHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<NewsUpdateCommandModel> Handle(NewsGetByIdModel request, CancellationToken cancellationToken)
        {
            var model = await _context.News.FindAsync(request.NewsID);
            var mapModel = _mapper.Map<NewsUpdateCommandModel>(model);
            return mapModel;
        }
    }
}