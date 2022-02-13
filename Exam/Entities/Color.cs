using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Entities
{[Serializable]
    public class Color
    {
        [Key]
        public Guid id { get; set; } = new Guid();
        public string Name { get; set; }
        public override string ToString()
        {
            return $"{Name}";
        }

    }
}
