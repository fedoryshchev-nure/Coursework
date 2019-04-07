using Core.Entities.Origin;
using Coursework.API.DTOs;
using Data.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Coursework.API.Controllers
{
    [Route("[controller]")]
    public class TeamController : GenericContoller<TeamDTO, Team>
    {
        public TeamController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
