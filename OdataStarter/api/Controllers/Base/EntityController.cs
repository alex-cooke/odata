
using data;
using model.Base;
using System;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Routing;

namespace api.Controllers.Base
{
    public abstract class EntityController<TEntity> : ODataController 
        where TEntity : class, IEntity{

        protected Context context = new Context("odataStarter");

        [HttpPatch]
        [ODataRoute("({id})")]
        public IHttpActionResult Patch([FromODataUri] Guid id, Delta<TEntity> patch) {

            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var target = context.Set<TEntity>().SingleOrDefault(x => x.Id == id);

            if (target == null) {
                return NotFound();
            }

            patch.Patch(target);

            context.SaveChanges();

            return Ok(target);

        }

        [HttpPut]
        [ODataRoute("({id})")]
        public IHttpActionResult Put([FromODataUri] Guid id, TEntity entity) {

            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var target = context.Set<TEntity>().SingleOrDefault(x => x.Id == id);

            if (target == null) {
                return NotFound();
            }

            entity.Id = target.Id;

            context.Entry(target).CurrentValues.SetValues(entity);

            context.SaveChanges();

            return Ok(target);

        }

        [HttpPost]
        [ODataRoute()]
        public IHttpActionResult Post(TEntity entity) {

            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            context.Set<TEntity>().Add(entity);
            context.SaveChanges();

            return Created(entity);

        }


        [HttpGet]
        [ODataRoute()]
        public IHttpActionResult Get() {
            return Ok(context.Set<TEntity>());
        }

        [HttpGet]
        [ODataRoute("({id})")]
        public virtual IHttpActionResult Get([FromODataUri] Guid id) {

            var entity = context.Set<TEntity>().SingleOrDefault(x => x.Id == id);

            if (entity == null) {
                return NotFound();
            }

            return Ok(entity);

        }

        protected override void Dispose(bool disposing) {
            context.Dispose();

            base.Dispose(disposing);
        }

        public IHttpActionResult CreateOKHttpActionResult(object propertyValue) {
            var okMethod = default(MethodInfo);

            // find the ok method on the current controller
            var methods = this.GetType().GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var method in methods) {
                if (method.Name == "Ok" && method.GetParameters().Length == 1) {
                    okMethod = method;
                    break;
                }
            }

            // invoke the method, passing in the propertyValue
            okMethod = okMethod.MakeGenericMethod(propertyValue.GetType());
            var returnValue = okMethod.Invoke(this, new object[] { propertyValue });
            return (IHttpActionResult)returnValue;
        }
    }


}
