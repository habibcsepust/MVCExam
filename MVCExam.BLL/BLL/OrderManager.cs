using MVCExam.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCExam.Repository.Repository;

namespace MVCExam.BLL.BLL
{
    public class OrderManager
    {
        OrderRepository _orderRepository = new OrderRepository();

        public List<Order> GetAllOrders()
        {
            return _orderRepository.GetAllOrders();
        }

        public List<Food> GetAllFoodItem()
        {
            return _orderRepository.GetAllFoodItem();
        }

        public bool Add(Order order)
        {
            return _orderRepository.Add(order);
        }
    }
}
