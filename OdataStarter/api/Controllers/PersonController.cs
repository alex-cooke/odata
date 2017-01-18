
using api.Controllers.Base;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Routing;

namespace api.Controllers
{
    [ODataRoutePrefix("Person")]
    public class PersonController : EntityController
    {

        [HttpGet]
        [ODataRoute()]
        public IHttpActionResult Get() {
            return Ok(context.Person);
        }

        [HttpGet]
        [ODataRoute("({id})")]
        public IHttpActionResult Get([FromODataUri] Guid id) {

            var entity = context.Person.SingleOrDefault(x => x.Id == id);

            if (entity == null) {
                return NotFound();
            }

            return Ok(entity);

        }


    }
}
