using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.SqlServerModel.Dtos
{
    public class ContactUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }

        [StringLength(100)]
        public string Email { get; set; }
    }
}
