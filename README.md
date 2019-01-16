# LogicBuilder.OData
Creates LINQ expressions from ODataQueryOptions and executes the query.

To use, call the Get extension method from your OData controller.  IMapper is an AutoMapper interface.

```c#
public static ICollection<TModel> Get<TModel, TData>(this IQueryable<TData> query, IMapper mapper, ODataQueryOptions<TModel> options);
```

```c#
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
```
<br><br>
### OData query examples:

``` 
	http://localhost:<port>/opstenant?$top=5&$expand=Buildings&$filter=Name eq 'One'&$orderby=Name desc
	http://localhost:<port>/opstenant?$top=5&$expand=Buildings&$filter=Name ne 'One'&$orderby=Name desc
	http://localhost:<port>/opstenant?$filter=Name eq 'One'
	http://localhost:<port>/opstenant?$top=5&$expand=Buildings&$orderby=Name desc
	http://localhost:<port>/opstenant?$orderby=Name desc
	http://localhost:<port>/opstenant?$orderby=Name desc&$count=true
	http://localhost:<port>/opstenant?$top=5&$filter=Name eq 'One'&$orderby=Name desc&$count=true
	http://localhost:<port>/opstenant?$top=5&$select=Name, Identity
	http://localhost:<port>/opstenant?$top=5&$expand=Buildings&$filter=Name ne 'One'&$orderby=Name desc
	http://localhost:<port>/opstenant?$top=5&$expand=Buildings($expand=Builder($expand=City))&$filter=Name ne 'One'&$orderby=Name desc

	http://localhost:<port>/corebuilding?$top=5&$expand=Builder,Tenant&$filter=name ne 'One L1'&$orderby=Name desc
	http://localhost:<port>/corebuilding?$top=5&$expand=Builder($expand=City),Tenant&$filter=name ne 'One L2'&$orderby=Name desc
```
