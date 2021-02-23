using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerManager
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.ProductAdded);
        }

        //public IDataResult<List<Customer>>GetCustomer(int customerId)
        //{
        //    return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(c => c.Id == customerId), Messages.ProductList);
        //}

        public IDataResult<Customer>GetCustomer(int customerId)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.Id == customerId), Messages.ProductList);
        }
        public IDataResult<List<Customer>> GetAllList() { 
            var customer =  _customerDal.GetAll();
            return new SuccessDataResult<List<Customer>>(customer, "başarılı");
        }
    }
}
