using MyApp.SqlServerModel.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.SqlServerModel.Entities
{
    public class Address : BaseEntity
    {
        public Address()
        {
            Version = TimestampHelper.Generate();
        }

        [Required]
        [Timestamp]
        public byte[] Version { get; set; }

        [StringLength(100)]
        public string Line1 { get; set; }

        [StringLength(100)]
        public string Line2 { get; set; }

        [StringLength(100)]
        public string Line3 { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        [StringLength(20)]
        public string PostCode { get; set; }

        public ICollection<ContactAddress> ContactAddresses { get; set; }

    }
}
