using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using test_crud.core.CustomEntities;
using test_crud.core.DTOs;
using test_crud.core.Entities;
using test_crud.core.QueryFilters;
using test_crud.core.Services;
using test_crud.infrastructure.Interfaces;
using test_crud.Responses;

namespace test_crud.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;
        public UserController(IUserService userService, IMapper mapper, IUriService uriService)
        {
            _userService = userService;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// Retrive all users
        /// </summary>
        /// <param name="filters">Filters to apply</param>
        /// <returns>Users collection</returns>
        [HttpGet(Name = nameof(GetAllUsers))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<UserDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ApiResponse<IEnumerable<UserDto>>))]
        public IActionResult GetAllUsers([FromQuery] UserQueryFilter filters)
        {
            var users = _userService.Get(filters);

            var usersDto = _mapper.Map<IEnumerable<UserDto>>(users);

            var metadata = new Metadata
            {
                CurrentPage = users.CurrentPage,
                PageSize = users.PageSize,
                TotalPages = users.TotalPages,
                TotalCount = users.TotalCount,
                HasPreviousPage = users.HasPreviousPage,
                HasNextPage = users.HasNextPage,
                PreviousPageUrl = _uriService.GetUserPaginationUri(filters, Url.RouteUrl(nameof(GetAllUsers))).ToString(),
                NextPageUrl = _uriService.GetUserPaginationUri(filters, Url.RouteUrl(nameof(GetAllUsers))).ToString()
            };

            var response = new ApiResponse<IEnumerable<UserDto>>(usersDto)
            {
                Metadata = metadata
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(response);
        }

        /// <summary>
        /// Retrive a specific User
        /// </summary>
        /// <param name="id"></param>
        /// <returns>User</returns>
        [HttpGet("{id}", Name = nameof(GetUserById))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<UserDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ApiResponse<UserDto>))]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.Get(id);

            var userDto = _mapper.Map<UserDto>(user);
            var response = new ApiResponse<UserDto>(userDto);

            return Ok(response);
        }

        /// <summary>
        /// Add new User
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns>User</returns>
        [HttpPost(Name = nameof(PostUser))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<UserDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ApiResponse<UserDto>))]
        public async Task<IActionResult> PostUser([FromBody] UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);

            await _userService.Post(user);

            userDto = _mapper.Map<UserDto>(userDto);
            var response = new ApiResponse<UserDto>(userDto);

            return Ok(response);
        }

        /// <summary>
        /// Update all parameters from specific User
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userDto"></param>
        /// <returns>bool</returns>
        [HttpPut("{id}", Name = nameof(PutUser))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<bool>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ApiResponse<bool>))]
        public async Task<IActionResult> PutUser(int id, [FromBody] UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            user.Id = id;

            var result = await _userService.Put(user);
            var response = new ApiResponse<bool>(result);

            return Ok(response);
        }

        /// <summary>
        /// Delete a specific User
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        [HttpDelete("{id}", Name = nameof(DeleteUser))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<bool>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ApiResponse<bool>))]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userService.Delete(id);
            var response = new ApiResponse<bool>(result);

            return Ok(response);
        }
    }
}
