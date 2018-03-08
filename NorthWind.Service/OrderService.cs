using NorthWind.DATA.Infrastructure;
using NorthWind.DATA.Repositories;
using NorthWind.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Service
{
    public interface IOrderService
    {
        IEnumerable<Order> GetOrders();
        IEnumerable<Order_Detail> GetOrderLines(int id);
        //IEnumerable<Product> GetCategoryGadgets(string categoryName, string gadgetName = null);
        Order GetOrder(int id);
        void Update(Order order);
        void Delete(Order order);
        void Create(Order order);
        void SaveOrder();
    }

    public class OrderService : IOrderService
    {

        public IOrderRepository orderRepository;

        private readonly IUnitOfWork unitofWork;

        public OrderService(IOrderRepository orderRepository, IUnitOfWork unitofWork)
        {
            this.orderRepository = orderRepository;
            this.unitofWork = unitofWork;
        }

        public void Create(Order order)
        {
            orderRepository.Add(order);
        }

        public void Delete(Order order)
        {
            orderRepository.Delete(order);
        }

        public Order GetOrder(int id)
        {
            return orderRepository.GetById(id);
        }

        public IEnumerable<Order> GetOrders()
        {
            return orderRepository.GetAll();
        }

        public IEnumerable<Order_Detail> GetOrderLines(int id)
        {
            return orderRepository.GetById(id).Order_Details;
        }

        public void SaveOrder()
        {
            unitofWork.Commit();
        }

        public void Update(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
