using AutoMapper;
using Core.Entities.Origin;
using Coursework.API.DTOs;
using Data.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Coursework.API.Controllers
{
    [Route("api/[controller]")]
    public class BioMeasureController : GenericContoller<BioMeasureDTO, BioMeasure>
    {
        public BioMeasureController(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }
    }
}
