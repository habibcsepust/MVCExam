using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCExam.Model.Model
{
    public class Order
    {
        public int Id { get; set; }
        public double Quantity { get; set; }
        public DateTime OrderDate { get; set; }

        public Member Member { get; set; }
        public int MemberId { get; set; }

        public Food Food { get; set; }
        public int FoodId { get; set; }
    }
}
