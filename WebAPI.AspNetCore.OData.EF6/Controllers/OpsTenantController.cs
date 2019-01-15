using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.OData;
using LogicBuilder.OData.EF6;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.AspNetCore.OData.EF6.Controllers
{
    public class CoreBuildingController : ODataController
    {
        public CoreBuildingController()
        {
            Repository = new DAL.MyDbContext();
        }

        DAL.MyDbContext Repository { get; set; }

        [HttpGet]
        [EnableQuery(MaxExpansionDepth = 5)]
        public IActionResult Get(ODataQueryOptions<CoreBuilding> options)
        {
            return Ok(Repository.BuildingSet.Get(Mapper.Instance, options));
        }
    }

    public class OpsTenantController : ODataController
    {
        public OpsTenantController()
        {
            Repository = new DAL.MyDbContext();
        }

        DAL.MyDbContext Repository { get; set; }

        [HttpGet]
        [EnableQuery(MaxExpansionDepth = 5)]
        public IActionResult Get(ODataQueryOptions<OpsTenant> options)
        {
            return Ok(Repository.MandatorSet.Get(Mapper.Instance, options));
        }
    }
}