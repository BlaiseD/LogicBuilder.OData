using AutoMapper;
using DAL.EFCore;
using Domain.OData;
using LogicBuilder.OData.EFCore;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Get(ODataQueryOptions<OpsTenant> options)
        {
            return Ok(Repository.MandatorSet.Get(Mapper.Instance, options));
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
        public IActionResult Get(ODataQueryOptions<CoreBuilding> options)
        {
            return Ok(Repository.BuildingSet.Get(Mapper.Instance, options));
        }
    }
}