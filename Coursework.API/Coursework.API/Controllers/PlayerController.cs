using Core.Entities.Origin;
using Coursework.API.DTOs;
using Data.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Coursework.API.Controllers
{
    [Route("[controller]")]
    public class PlayerController : GenericContoller<PlayerDTO, Player>
    {
        public PlayerController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
