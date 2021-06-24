using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamApp.Models
{
    public class Orders
    {
        
        public int ord_id { get; set; }
        public int ord_cust_id { get; set; }
        public int ord_prod_id { get; set; }
        public int ord_prod_count { get; set; }
        public int ord_worker_id { get; set; }
        public int ord_price { get; set; }
        public DateTime ord_start_date { get; set; }
        public DateTime ord_over_date { get; set; }
        public int ord_status { get; set; }

    }
}
