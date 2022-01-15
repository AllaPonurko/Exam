using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Entities
{
    public class Base
    {/// <summary>
    /// уникальный идентификатор
    /// </summary>
        private Guid id;

        public Guid GetId()
        {
            return id;
        }

        public void SetId()
        {
            id = new Guid();
        }
/// <summary>
/// название
/// </summary>
        public string Name { get; set; }
        /// <summary>
        /// вендоркод
        /// </summary>
        public string VendorCode { get; set; }
    }
}
