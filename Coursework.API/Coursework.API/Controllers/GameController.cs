using Core.Entities.Origin;
using Coursework.API.DTOs;
using Data.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Coursework.API.Controllers
{
    [Route("[controller]")]
    public class GameController : GenericContoller<GameDTO, Game>
    {
        public GameController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
