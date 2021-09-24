using ConnectionFour.Service.Services.Validator;
using Microsoft.AspNetCore.Mvc;

namespace ConnectionFour.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConnectionFourController : ControllerBase
    {
        private readonly IValidatorService _validatorService;

        public ConnectionFourController(IValidatorService validatorService)
        {
            _validatorService = validatorService;
        }

        /// <summary>
        /// Get the result of a game
        /// </summary>
        /// <param name="input">42 board positions</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{inputBoard}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(typeof(string), 200)]
        public ActionResult<string> GetWinner(string inputBoard)
        {
            if (!_validatorService.CheckGameIsValid(inputBoard))
            {
                return ValidationProblem();
            }

            var response = _validatorService.CheckForWinner(inputBoard);
            return Ok(response);
        }
    }
}
