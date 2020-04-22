using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly2.Models;

namespace Vidly2.Dtos
{
    public class CustomerDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter a valid name")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public byte MembershipTypeId { get; set; }
        public MembershipTypeDTO MembershipType { get; set; }

        //[Min18YearsIfMember]
        public DateTime? Birthday { get; set; }
    }
}