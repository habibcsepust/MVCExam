using MVCExam.DatabaseContext.DatabaseContext;
using MVCExam.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCExam.Repository.Repository
{
    public class OrderRepository
    {
        ProjectDbContext db = new ProjectDbContext();

        public List<Order> GetAllOrders()
        {
            return db.Orders.ToList();
        }

        public List<Food> GetAllFoodItem()
        {
            return db.Foods.ToList();
        }

        public bool Add(Order order)
        {
            db.Orders.Add(order);
            return db.SaveChanges() > 0;
        }
    }
}
