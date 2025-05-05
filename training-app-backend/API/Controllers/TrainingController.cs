using Microsoft.AspNetCore.Mvc;
using TrainingApp.API.DTO;
using TrainingApp.Core.Model;
using TrainingApp.Core.Service;
using TrainingApp.Core.Service.IService;

namespace TrainingApp.API.Controllers
{
    [Route("[controller]")]
    public class TrainingController : BaseApiController
    {
        private readonly ITrainingService _trainingService;

        public TrainingController(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }


        [HttpPost]
        public ActionResult<CreateTrainingResponseDto> Create([FromBody] CreateTrainingDto trainingDto)
        {
            var result = _trainingService.CreateTraining(trainingDto);
            return CreateResponse(result);
        }

        [HttpPut("progress")]
        public ActionResult<List<StatsResponseDto>> GetStatsForMonth([FromBody] MonthDto monthDto)
        {
            var result = _trainingService.GetStatsForMonth(monthDto);
            return CreateResponse(result);
        }

        [HttpGet("types")]
        public ActionResult<List<TrainingType>> GetAllTypes()
        {
            var result = _trainingService.GetAllTypes();
            return CreateResponse(result);
        }


    }
}
