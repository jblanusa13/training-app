using Microsoft.AspNetCore.Mvc;
using TrainingApp.API.DTO;
using TrainingApp.Core.Model;
using TrainingApp.Core.Service;
using TrainingApp.Core.Service.IService;

namespace TrainingApp.API.Controllers
{
    [Route("[controller]")]
    public class TrainingTypeController : BaseApiController
    {
        private readonly ITrainingTypeService _trainingTypeService;

        public TrainingTypeController(ITrainingTypeService trainingTypeService)
        {
            _trainingTypeService = trainingTypeService;
        }

        [HttpGet]
        public ActionResult<List<TrainingType>> GetAllTypes()
        {
            var result = _trainingTypeService.GetAllTypes();
            return CreateResponse(result);
        }
    }
}
