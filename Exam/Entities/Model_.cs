using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Entities
{[Serializable]
    public class Model_:Base
    {
        public Model_() { modifications_ = new List<Modification>(); }
      
        public List<Modification> modifications_ { get; set; }

        private Guid modificationId;

        public Guid GetModificationId()
        {
            return modificationId;
        }

        public void SetModificationId(Modification modification)
        {
            modificationId = modification.GetId();
        }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
