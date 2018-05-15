using MyApp.SqlServerModel.DataStructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.SqlServerModel.Entities
{
    public class ContactAddress: BaseEntity
    {
        [Required]
        [ForeignKey("Contact")]
        public int ContactId { get; set; }

        [Required]
        public virtual Contact Contact { get; set; }

        [Required]
        [ForeignKey("Address")]
        public int AddressId { get; set; }

        [Required]
        public virtual Address Address { get; set; }

        [Required]
        public AddressTypeEnum AddressType { get; set; }
    }
}
