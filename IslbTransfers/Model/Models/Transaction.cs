using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.Models
{
   public class Transaction
   {
       [Key]
       public string UniqueId { get; set; }
       public string Description { get; set; }
       public string ExternalServiceId { get; set; }
       public string Status { get; set; }
       [ForeignKey("UserId")]
       public int UserId { get; set; }
       public string BlockchainFee { get; set; }
       public string Created { get; set; }
       public string TotalAmount { get; set; }
       public string AddressTo { get; set; }
    }

    public class ExchangeTransaction : Transaction
    {
        public string GivenAmount { get; set; }
        public string ReceivedAmount { get; set; }
        public string Stock { get; set; }
        public string Rate { get; set; }
        public string Commission { get; set; }
    }

    public class TransferTransaction : Transaction
    {
        public string TransferredAmount { get; set; }
    }

}
