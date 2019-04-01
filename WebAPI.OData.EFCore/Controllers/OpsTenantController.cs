using AutoMapper;
using DAL.EFCore;
using Domain.OData;
using LogicBuilder.OData.EFCore;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.OData.EFCore.Controllers
{
    public class OpsTenantController : ODataController
    {
        public OpsTenantController(MyDbContext repository)
        {
            Repository = repository;
        }

        MyDbContext Repository { get; set; }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth = 5)]
        public async Task<IActionResult> Get(ODataQueryOptions<OpsTenant> options)
        {
            return Ok(await Repository.MandatorSet.GetAsync(Mapper.Instance, options, HandleNullPropagationOption.False));
        }
    }

    public class CoreBuildingController : ODataController
    {
        public CoreBuildingController(MyDbContext repository)
        {
            Repository = repository;
        }

        MyDbContext Repository { get; set; }

        [HttpGet]
        [EnableQuery(MaxExpansionDepth = 5)]
        public async Task<IActionResult> Get(ODataQueryOptions<CoreBuilding> options)
        {
            return Ok(await Repository.BuildingSet.GetAsync(Mapper.Instance, options, HandleNullPropagationOption.False));
        }
    }
}