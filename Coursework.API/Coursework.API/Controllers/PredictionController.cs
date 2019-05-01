using System;
using BusinessLogic.Services.PredictionService;
using Microsoft.AspNetCore.Mvc;

namespace Coursework.API.Controllers
{
    [Route("[controller]/[action]")]
    public class PredictionController : Controller
    {
        private readonly IPredictionService predictionService;

        public PredictionController(IPredictionService predictionService)
        {
            this.predictionService = predictionService;
        }

        [HttpGet]
        public IActionResult Train()
        {
            try
            {
                predictionService.Train();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{matchId}")]
        public ActionResult<bool> Predict(string matchId)
        {
            try
            {
                return predictionService.Predict(matchId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
