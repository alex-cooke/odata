
using api.Controllers.Base;
using model;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Routing;
using System.Data.Entity;
using api.Helpers;
using System.Web.OData.Query;

namespace api.Controllers
{
    [ODataRoutePrefix("Person")]
    public class PersonController : EntityController<Person> {

        //[HttpPost]
        //[ODataRoute("({id})/Friends/$ref")]
        //public IHttpActionResult AddFriend([FromODataUri] Guid id, [FromBody] Uri link) {

        //    var target = context.Person.SingleOrDefault(x => x.Id == id);

        //    if (target == null) {
        //        return NotFound();
        //    }

        //    Guid friendKey = Request.GetKeyValue<Guid>(link);

        //    return null;


        //}

        [ODataRoute("({id})/FirstName")]
        [ODataRoute("({id})/LastName")]
        [ODataRoute("({id})/DateOfBirth")]
        public IHttpActionResult GetProperty([FromUri] Guid id) {

            var entity = context.Person.SingleOrDefault(x => x.Id == id);

            if (entity == null) {
                return NotFound();
            }

            var propertyName = Url.Request.RequestUri.Segments.Last();

            var propertyInfo = typeof(Person).GetProperty(propertyName);

            if (propertyInfo == null) {
                return NotFound();
            }

            var propertyValue = propertyInfo.GetValue(entity, new object[] { });

            if (propertyValue == null) {
                return StatusCode(System.Net.HttpStatusCode.NoContent);
            }

            return CreateOKHttpActionResult(propertyValue);
        }

        [ODataRoute("({id})/FirstName/$value")]
        [ODataRoute("({id})/LastName/$value")]
        [ODataRoute("({id})/DateOfBirth/$value")]
        public IHttpActionResult GetPropertyValue([FromUri] Guid id) {

            var entity = context.Person.SingleOrDefault(x => x.Id == id);

            if (entity == null) {
                return NotFound();
            }

            var propertyName = Url.Request.RequestUri.Segments.Reverse().ToArray()[1].Replace("/", "");

            var propertyInfo = typeof(Person).GetProperty(propertyName);

            if (propertyInfo == null) {
                return NotFound();
            }

            var propertyValue = propertyInfo.GetValue(entity, new object[] { });

            if (propertyValue == null) {
                return StatusCode(System.Net.HttpStatusCode.NoContent);
            }

            return CreateOKHttpActionResult(propertyValue.ToString());
        }



        [ODataRoute("({id})/Experiences")]
        [EnableQuery]
        public IHttpActionResult GetCollection([FromUri] Guid id) {

            var entity = context
                .Person
                .Include(x => x.Experiences)
                .SingleOrDefault(x => x.Id == id);

            if (entity == null) {
                return NotFound();
            }

            var propertyName = Url.Request.RequestUri.Segments.Last();

            var propertyInfo = typeof(Person).GetProperty(propertyName);

            if (propertyInfo == null) {
                return NotFound();
            }

            var propertyValue = propertyInfo.GetValue(entity, new object[] { });

            if (propertyValue == null) {
                return StatusCode(System.Net.HttpStatusCode.NoContent);
            }

            return CreateOKHttpActionResult(propertyValue);
        }


    }
}
