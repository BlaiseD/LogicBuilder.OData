﻿using System;
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
        private readonly IMapper _mapper;

        public CoreBuildingController(IMapper mapper)
        {
            Repository = new DAL.MyDbContext();
            this._mapper = mapper;
        }

        DAL.MyDbContext Repository { get; set; }

        [HttpGet]
        [EnableQuery(MaxExpansionDepth = 5)]
        public async Task<IActionResult> Get(ODataQueryOptions<CoreBuilding> options)
        {
            return Ok(await Repository.BuildingSet.GetAsync(_mapper, options));
        }
    }

    public class OpsTenantController : ODataController
    {
        private readonly IMapper _mapper;

        public OpsTenantController(IMapper mapper)
        {
            Repository = new DAL.MyDbContext();
            this._mapper = mapper;
        }

        DAL.MyDbContext Repository { get; set; }

        [HttpGet]
        [EnableQuery(MaxExpansionDepth = 5)]
        public async Task<IActionResult> Get(ODataQueryOptions<OpsTenant> options)
        {
            return Ok(await Repository.MandatorSet.GetAsync(_mapper, options));
        }
    }
}