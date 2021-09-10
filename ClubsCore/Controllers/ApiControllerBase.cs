using AutoMapper;
using ClubsCore.Contracts;
using ClubsCore.Models;
using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ClubsCore.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {
        protected readonly IMapper _mapper;
        protected readonly ClubsContext _context;
        protected ILoggerManager _logger;
        protected IRepositoryWrapper _repository;

        public ApiControllerBase(ClubsContext context, IMapper mapper, ILoggerManager logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
            _context = context;
        }
    }
}