using AutoMapper;
using Domain.OData;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebAPI.AspNet.OData.EF6
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            DAL.MyDbContext.DSN = @"data source=.\SQL2014;initial catalog=Issue3;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";//"Data Source=adeaeawe;Initial Catalog=aeaweawe;User ID=aeaweads;Password=aweasdawae; MultipleActiveResultSets=True";

            config.Count().Filter().OrderBy().Expand().Select().MaxTop(null);

            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<OpsTenant>(nameof(OpsTenant));
            builder.EntitySet<CoreBuilding>(nameof(CoreBuilding));
            builder.EntitySet<OpsBuilder>(nameof(OpsBuilder));
            builder.EntitySet<OpsCity>(nameof(OpsCity));
            config.MapODataServiceRoute("odata", "", builder.GetEdmModel());

            Mapper.Initialize(cfg => {
                cfg.AddProfiles(typeof(WebApiConfig));
            });
        }
    }
}
