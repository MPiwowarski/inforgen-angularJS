using MyApp.SqlServerModel.DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.WebAPI.Models.ContactModels
{
    public class AddAddressViewModel
    {
        public int AddressId { get; set; }

        public int ContactId { get; set; }

        public AddressTypeEnum AddressType { get; set; }
    }
}