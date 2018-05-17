using MyApp.SqlServerModel.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.SqlServerModel.Entities
{
    public class Contact: BaseEntity
    {
        public Contact()
        {
            Version = TimestampHelper.Generate();
        }

        [Required]
        [Timestamp]
        public byte[] Version { get; set; }
     
        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public ICollection<ContactAddress> ContactAddresses { get; set; }
    }
}
