using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using test_crud.core.DTOs;
using test_crud.core.Entities;
using test_crud.core.Services;
using test_crud.Responses;

namespace test_crud.Controllers
{
    [Authorize(Roles = "1")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityService _securityService;
        private readonly IMapper _mapper;
        public SecurityController(ISecurityService securityService, IMapper mapper)
        {
            _securityService = securityService;
            _mapper = mapper;
        }

        /// <summary>
        /// Add new security
        /// </summary>
        /// <param name="securityDto"></param>
        /// <returns>security</returns>
        [HttpPost(Name = nameof(PostSecurity))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<SecurityDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ApiResponse<SecurityDto>))]
        public async Task<IActionResult> PostSecurity([FromBody] SecurityDto securityDto)
        {
            var security = _mapper.Map<Security>(securityDto);

            await _securityService.RegisterUser(security);

            securityDto = _mapper.Map<SecurityDto>(securityDto);
            var response = new ApiResponse<SecurityDto>(securityDto);

            return Ok(response);
        }
    }
}
