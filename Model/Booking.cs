using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConnection.Model
{
    public class Bookings
    {
        public string id { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public string remarks { get; set; }
        public int room_id { get; set; }
        public string employee_id { get; set; }


    }
}
