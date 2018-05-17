using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.SqlServerModel.Dtos
{
    public class ContactDetailsDto
    {
        public int Id { get; set; }

        public byte[] Version { get; set; }

        public string Title { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public virtual ICollection<AddressDtoDetails> Addresses { get; set; }
    }
}
