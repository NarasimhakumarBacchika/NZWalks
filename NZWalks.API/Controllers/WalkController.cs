using AutoMapper;
using LazyCache;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using NZWalks.API.Catching;
using NZWalks.API.CustomActionFiltter;
using NZWalks.API.DTO;
using NZWalks.API.Model.Data;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class WalkController : ControllerBase
    {
        private readonly IWalkRepository sqlWalkRepository;
        private readonly IMapper mapper;
        private readonly ICacheProvider cacheProvider;

        public WalkController(IMapper mapper, IWalkRepository sqlWalkRepository, ICacheProvider cacheProvider)
        {
            this.mapper = mapper;
            this.sqlWalkRepository = sqlWalkRepository;
            this.cacheProvider = cacheProvider;
        }
        
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            if (!cacheProvider.TryGetValue(CatchKeys.GetAll, out List<Walk> walks))
            {
                var WalkDomain = await sqlWalkRepository.GetAllAsync();

                var catchEntryOption = new MemoryCacheEntryOptions()
                {
                    AbsoluteExpiration = DateTime.Now.AddSeconds(60),
                    SlidingExpiration = TimeSpan.FromSeconds(60),
                    Size = 1024
                };
                cacheProvider.Set(CatchKeys.GetAll, WalkDomain, catchEntryOption);
                walks = WalkDomain;
            }

            return Ok(walks);
            //var WalkDomain = await sqlWalkRepository.GetAllAsync();

            // return Ok(mapper.Map<List<WalkDto>>(WalkDomain));
        }
        [HttpPost]
        [ValidationModel]
        public async Task<IActionResult> Create(AddWalkDto addWalkDto)
        {
            var WalkDomain = mapper.Map<Walk>(addWalkDto);
            WalkDomain = await sqlWalkRepository.CreateAsync(WalkDomain);

            return Ok(mapper.Map<AddWalkDto>(WalkDomain));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [ValidationModel]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var WalkDomain = await sqlWalkRepository.GetByIdAsync(id);
            if (WalkDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<WalkDto>(WalkDomain));
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidationModel]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateWalkDto updateWalkDto)
        {
            var WalkDomain=  mapper.Map<Walk>(updateWalkDto);

            WalkDomain = await sqlWalkRepository.UpdateAsync(id, WalkDomain);

            return Ok(mapper.Map<UpdateWalkDto>(WalkDomain));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var WalkDomain= await sqlWalkRepository.DeleteAsync(id);
            if(WalkDomain == null)
            {
                return NotFound();
            }
            return Ok(WalkDomain =mapper.Map<Walk>(WalkDomain));
        }

    }
}
