using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Common
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            Guid = Guid.NewGuid();
        }
        public Guid Guid { get; set; }
        public int Id { get; protected set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedTime { get; set; }
    }
}
