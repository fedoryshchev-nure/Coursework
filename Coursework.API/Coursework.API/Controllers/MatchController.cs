using Core.Entities.Origin;
using Coursework.API.DTOs;
using Data.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Coursework.API.Controllers
{
    [Route("[controller]")]
    public class MatchController : GenericContoller<MatchDTO, Match>
    {
        public MatchController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
