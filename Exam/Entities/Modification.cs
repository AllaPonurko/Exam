using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Entities
{[Serializable]
   public class Modification:Base
    {
        public List<Color> colors { get; set; }
        public Modification()
        {
            colors = new List<Color>();
        }
        private Guid colorId;

        public Guid GetColorId()
        {
            return colorId;
        }

        public void SetColorId(Color color)
        {
            colorId = color.GetId();
        }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
