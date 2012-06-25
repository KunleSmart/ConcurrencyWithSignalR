//------------------------------------------------------------------------------------------
//THIS CODE CONSTITUTES INTELLECTUAL PROPERTY AND IS FULLY OWNED BY BYAXIOM SOLUTIONS LIMITED
//NO PORTION OF IT MAY BE TRANSMITTED OR MADE AVAILABLE IN ANY FORM OR MEDIA WITHOUT FULL
//AUTHORIZATION (IN WRITING) FROM BYAXIOM SOLUTIONS LIMITED.
//Copyright (c) 2012 BYAXIOM SOLUTIONS LIMITED.  All Rights Reserved
//Module      : Bank
//DateTime    : 14-May-2012 00:05:AM
//Author      : Ishmail A. Rahman
//Position    : Lead Developer
//Purpose     : 
//Procedures  : 
//Assumptions : 
//Comment     : 
//------------------------------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ConcurrencySample.Models
{
    public partial class Bank
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 BankId { get; set; }
        [Required(ErrorMessage = "*")]
        //[MaxLengthAttribute(50)]
        public string Name { get; set; }
        [Required(ErrorMessage = "*")]
        //[MaxLengthAttribute(50)]
        public string Shortname { get; set; }
        [Key]
        [Required(ErrorMessage = "*")]
        //[MaxLengthAttribute(5)]
        public string CBNCode { get; set; }
        //[Required(ErrorMessage = "*")]
        //[MaxLengthAttribute(50)]
        public string Addressee { get; set; }
        //[Required(ErrorMessage = "*")]
        //[MaxLengthAttribute(50)]
        public string AddressLine1 { get; set; }
        //[Required(ErrorMessage = "*")]
        //[MaxLengthAttribute(50)]
        public string AddressLine2 { get; set; }
		public bool IsActive { get; set; }
        [ConcurrencyCheck]
        [Timestamp]
        public byte[] Timestamp { get; set; }

        public Bank()
        {
			this.Name = string.Empty;
			this.Shortname = string.Empty;
			this.CBNCode = string.Empty;
			this.Addressee = string.Empty;
			this.AddressLine1 = string.Empty;
			this.AddressLine2 = string.Empty;
            this.IsActive = true;
        }
    }
}
