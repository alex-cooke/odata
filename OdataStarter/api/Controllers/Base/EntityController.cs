
using data;
using System.Web.OData;

namespace api.Controllers.Base
{
    public class EntityController : ODataController {

        protected Context context = new Context("odataStarter");


        protected override void Dispose(bool disposing) {
            context.Dispose();

            base.Dispose(disposing);
        }
    }
}
