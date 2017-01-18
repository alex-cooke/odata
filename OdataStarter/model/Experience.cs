using model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model {
    public class Experience : IEntity {

        public Guid Id { get; set; }
        public virtual Person Person { get; set; }
        public string Name { get; set; }
    }

}
