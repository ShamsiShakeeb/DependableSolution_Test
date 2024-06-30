using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Order
    {
        public int Id { get; set; }
        public string RefId { set; get; }
        public string PONO { set; get; }
        public string PODATE { get; set; }    
        public string Supplier { get; set; }    
        public string ExpectedDate { get; set; }    
        public string Remarks { get; set; }    
        
    }
}
