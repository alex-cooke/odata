using api.Controllers.Base;
using model;
using System.Web.OData.Routing;

namespace api.Controllers {

    [ODataRoutePrefix("Experience")]
    public class ExperienceController : EntityController<Experience> {

    }
}
