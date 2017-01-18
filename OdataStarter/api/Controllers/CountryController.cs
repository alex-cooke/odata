using api.Controllers.Base;
using model;
using System.Web.OData.Routing;

namespace api.Controllers
{
    [ODataRoutePrefix("Country")]
    public class CountryController : EntityController<Country>
    {
    }
}
