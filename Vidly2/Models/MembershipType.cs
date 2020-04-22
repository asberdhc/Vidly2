using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly2.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }

        //add a new property named name
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        public static readonly byte UNKNOWN = 0;
        public static readonly byte PAY_AS_YOU_GO = 1;
    }
}