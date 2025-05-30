using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerse_Project.DAL.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public DateTime ModifiedAt { get; set; } = DateTime.UtcNow;
        public DateTime ?AddedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public bool IsDeleted { get; set; } = false;

        public DateTime? DeletedAt { get; set; }
    }
}
