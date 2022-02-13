using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Entities
{[Serializable]
    public class Model_
    {
        [Key]
        public Guid id { get; set; } = new Guid();
        public string Name { get; set; }
        public string VendorCode { get; set; }
        public Model_() { modifications_ = new List<Modification>(); }
      
        public List<Modification> modifications_ { get; set; }

        public Guid modificationId;

        public Guid GetModificationId()
        {
            return modificationId;
        }

        public void SetModificationId(Modification modification)
        {
            modificationId = modification.id;
        }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
