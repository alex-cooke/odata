using model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model {
    public class Country : IEntity {

        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
