using MyApp.SqlServerModel.DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.SqlServerModel.Dtos
{
    public class AddressDtoDetails
    {
        public int Id { get; set; }

        public byte[] Version { get; set; }

        public string Line1 { get; set; }

        public string Line2 { get; set; }

        public string Line3 { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string PostCode { get; set; }

        public AddressTypeEnum AddressType { get; set; }
    }
}
