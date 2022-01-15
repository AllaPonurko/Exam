using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.DataCollection
{
   public interface IDataCollection<Entities>
    {

        public void Save();
        public List<Entities> Load();
    }
}
