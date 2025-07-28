using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.CustomActionFiltter;
using NZWalks.API.Data;
using NZWalks.API.DTO;
using NZWalks.API.Mapper;
using NZWalks.API.Model.Data;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RegionController : ControllerBase
    {
        private readonly NZWalksDbContext _nZWalksDb;
        private readonly IRegionRepository repository;
        private readonly IMapper mapper;
        public RegionController(IRegionRepository repository, IMapper mapper, NZWalksDbContext nZWalksDb)
        {
            this.repository = repository;
            _nZWalksDb = nZWalksDb;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var Regiondomain = await repository.GetAllAsncy();

            return Ok( mapper.Map<List<RegionDTO>>(Regiondomain));
            
        }
        [HttpGet]
        [Route("{id:Guid}")]
        //http://localhost:39082/api/Region/id
        public async Task<IActionResult> GetById([FromRoute]Guid id)
        {
            
                var regionDomian = await repository.GetByIdAsync(id);

                if (regionDomian == null)
                {
                    return NotFound();
                }

                return Ok(mapper.Map<RegionDTO>(regionDomian));

        }
        [HttpPost]
        [ValidationModel]
        public async Task<IActionResult> Created([FromBody] AddRegionDto regionDto)
        {
            
                var RegionDomain = mapper.Map<Region>(regionDto);

                RegionDomain = await repository.CreatedAsync(RegionDomain);

                mapper.Map<AddRegionDto>(RegionDomain);
                //var RegionDomain = new Region()
                //{
                //    Id = Guid.NewGuid(),
                //    Code = regionDto.Code,
                //    Name = regionDto.Name,
                //    RegionImageUrl = regionDto.RegionImageUrl
                //};
                //_nZWalksDb.Regions.Add(RegionDomain);
                //_nZWalksDb.SaveChanges();
                //var regionDto1 = new RegionDTO
                //{
                //    Id = RegionDomain.Id, 
                //    Code = RegionDomain.Code,
                //    Name = RegionDomain.Name,
                //    RegionImageUrl = RegionDomain.RegionImageUrl
                //};
                return CreatedAtAction(nameof(GetById), new { id = RegionDomain.Id }, RegionDomain);

            

        }
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidationModel]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateRegionDto updateRegionDto)
        {
             var regionDomian = mapper.Map<Region>(updateRegionDto);

             regionDomian=await repository.UpdateAsync(id, regionDomian);
                if (regionDomian == null)
                {
                    return NotFound();
                }
                var RegionDto=  mapper.Map<UpdateRegionDto>(regionDomian);
                return Ok(RegionDto);
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        [ValidationModel]
        public async Task<IActionResult> Delete(Guid id)
        {
            var regionDomian = await repository.DeleteAsync(id);
            
            if (regionDomian == null)
            {
                return NotFound();
            }
                return Ok(regionDomian = mapper.Map<Region>(regionDomian));
            }
        }
    }

