using Microsoft.AspNetCore.Mvc;
using TripPlanner.Models;
using TripPlanner.Services.CultureService;
using TripPlanner.Services.UserService;
using TripPlanner.Services.TourService;
using TripPlanner.Models.DTO.CultureDTOs;

namespace TripPlanner.WebAPI.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    //[ApiExplorerSettings(IgnoreApi = ProjectConfiguration.HideContorller)]
    public class CultureController : ControllerBase
    {
        private readonly ICultureService _CultureService;
        private readonly IUserService _UserService;
        private readonly ITourService _TourService;

        public CultureController(ICultureService CultureService, IUserService userService, ITourService tourService)
        {
            _CultureService = CultureService;
            _UserService = userService;
            _TourService = tourService;
        }

        [HttpGet]
        public async Task<ActionResult<RepositoryResponse<List<CultureDTO>>>> Get()
        {
            var response = await _CultureService.GetCulturesAsync();
            List<CultureDTO> res = response.Data.Select(u => (CultureDTO)u).ToList();
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RepositoryResponse<CultureDTO>>> GetById(int id)
        {
            var response = await _CultureService.GetCultureAsync(u => u.Id == id);
            CultureDTO res = response.Data;
            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult<RepositoryResponse<bool>>> Create([FromBody] CreateCultureDTO Culture)
        {
            var resp = await _CultureService.GetCultureAsync(u => u.Name == Culture.Name);
            if (resp.Data != null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Istnieje już taka nota kulturowa o nazwie = {Culture.Name}" };
            }

            Culture newCulture = Culture;

            var response = await _CultureService.CreateCulture(newCulture);
            return Ok(response.Data);
        }

        [HttpPut("{CultureId}")]
        public async Task<ActionResult<RepositoryResponse<bool>>> Edit(int CultureId, [FromBody] CreateCultureDTO Culture)
        {
            var resp2 = await _CultureService.GetCultureAsync(u => u.Id == CultureId);
            if (resp2.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje taka nota kulturowa o id = {CultureId}" };
            }
            var resp = await _CultureService.GetCultureAsync(u => u.Name == Culture.Name && u.Id != CultureId);
            if (resp.Data != null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Istnieje już taka nota kulturowa o nazwie = {Culture.Name}" };
            }

            Culture elem = Culture;
            elem.Id = CultureId;
            elem.Tours = resp2.Data.Tours;

            var response = await _CultureService.UpdateCulture(elem);
            return Ok(response.Data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<RepositoryResponse<bool>>> Delete(int id)
        {
            var response = await _CultureService.DeleteCulture(new Culture() { Id = id });
            if (response.Success)
            {
                return Ok(response.Data);
            }
            else
            {
                return NotFound(response.Data);
            }
        }
    }
}
