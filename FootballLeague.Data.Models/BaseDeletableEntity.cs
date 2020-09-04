using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FootballLeague.Data.Models
{
    public class BaseDeletableEntity<TKey>
    {
        public BaseDeletableEntity()
        {
            this.CreatedOn = DateTime.UtcNow;
            this.IsDeleted = false;
        }

        [Key]
        public TKey Id { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
