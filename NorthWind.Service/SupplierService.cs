using NorthWind.DATA;
using NorthWind.DATA.Infrastructure;
using NorthWind.DATA.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthWind.Model;

namespace NorthWind.Service
{
    public interface ISupplierService
    {
        IEnumerable<Supplier> GetSuppliers();
        Supplier GetSupplier(int id);
        void CreateSupplier(Supplier supplier);
        void SaveSupplier();
    }

    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository supplierRepository;
        private readonly IUnitOfWork unitofWork;

        public SupplierService(ISupplierRepository supplierRepository,  IUnitOfWork unitofWork)
        {
            this.supplierRepository = supplierRepository;
            this.unitofWork = unitofWork;
        }

        public void CreateSupplier(Supplier supplier)
        {
            supplierRepository.Add(supplier);
        }

        public Supplier GetSupplier(int id)
        {
            return supplierRepository.GetById(id);
        }

        public IEnumerable<Supplier> GetSuppliers()
        {
            return supplierRepository.GetAll();
        }

        public void SaveSupplier()
        {
            unitofWork.Commit();
        }
    }
}
