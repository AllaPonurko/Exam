using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Entities
{[Serializable]
   public class Modification
    {
        [Key]
        public Guid id { get; set; } = new Guid();
        public string Name { get; set; }
        public List<Color> colors { get; set; }
        public Modification()
        {
            colors = new List<Color>();
        }
        public Guid colorId;

        public Guid GetColorId()
        {
            return colorId;
        }

        public void SetColorId(Color color)
        {
            colorId = color.id;
        }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
