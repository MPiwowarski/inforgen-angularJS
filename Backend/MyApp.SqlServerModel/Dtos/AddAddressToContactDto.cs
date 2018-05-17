using MyApp.SqlServerModel.DataStructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.SqlServerModel.Dtos
{
    public class AddAddressToContactDto
    {
        [Required]
        public int ContactId { get; set; }

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

        public AddressTypeEnum AddressType { get; set; }
    }
}
