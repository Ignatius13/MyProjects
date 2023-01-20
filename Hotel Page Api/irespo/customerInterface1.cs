using Curdoperations;
using Curdoperations.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace put_task.irepo
{
    public interface CustomerInterface1
    {


        List<productClass> GetAllcusDetails();
        productClass GetcusDetail(int id);

        
        string Deletedetails(int id);
        string UpdateAllDetails(productClass id);
        
        string Bulkinsert(List<Customer> em);
        Customer GetById(int CustomerId);
       
        
        object insert(productClass customerId);
        
    }
    class cusdetail : CustomerInterface1
    {
        CRUDDBEntities sx = new CRUDDBEntities();
        public List<productClass> cuslist = new List<productClass>()
        { };

        public object CustomerInterface1 => throw new NotImplementedException();



        List<productClass> CustomerInterface1.GetAllcusDetails()
        {
            List<productClass> cuslist = null;
            cuslist = sx.Customers.Select(s => new productClass()
            {
                CustomerId = s.CustomerId,
                Name = s.Name,
                Address = s.Address,
                MobileNo = s.MobileNo,
                EmailId = s.EmailId,
            }).ToList<productClass>();
            return cuslist;
        }

        string CustomerInterface1.Deletedetails(int id)
        {
            var A = sx.Customers.Where(u => u.CustomerId == id).FirstOrDefault();
            if (A != null)
            {
                sx.Customers.Remove(A);
            }
            sx.SaveChanges();
            return "Deleted";
        }
        string CustomerInterface1.UpdateAllDetails(productClass id)
        {
            var abc = sx.Customers.Where(u => u.CustomerId == id.CustomerId).FirstOrDefault();
            if (abc != null)
            {
                abc.CustomerId = id.CustomerId;
                abc.Name = id.Name;
                abc.Address = id.Address;
                abc.MobileNo = id.MobileNo;
                abc.EmailId = id.EmailId;
                sx.SaveChanges();
                sx.Dispose();
                return "Updated";

            }
            return "not";
        }
        public Object insert(productClass CustomerId)
        {
            var abc = sx.Customers.Where(i => i.CustomerId == CustomerId.CustomerId).FirstOrDefault();
            if (abc == null)
            {
                sx.Customers.Add(new Customer
                {
                    CustomerId = CustomerId.CustomerId,
                    Name = CustomerId.Name,
                    Address = CustomerId.Address,
                    MobileNo = CustomerId.MobileNo,
                    EmailId = CustomerId.EmailId,

                });

            }
            sx.SaveChanges();
            return "inserted";

        }
        string CustomerInterface1.Bulkinsert(List<Customer> em)
        {
            foreach (Customer ins in em)
            {

                var abc = sx.Customers.Where(i => i.CustomerId == ins.CustomerId).FirstOrDefault();
                if (abc == null)
                {
                    sx.Customers.Add(new Customer
                    {

                        CustomerId = ins.CustomerId,
                        Name = ins.Name,
                        Address = ins.Address,
                        MobileNo = ins.MobileNo,
                        EmailId = ins.EmailId,
                    });

                }
                sx.SaveChanges();

            }
            return "Bulk inserted";
        }





        productClass CustomerInterface1.GetcusDetail(int id)
        {
            throw new NotImplementedException();
        }



        internal static object Bulkinsert(List<Customer> em)
        {
            throw new NotImplementedException();
        }

        public string GetById(productClass id)
        {
            throw new NotImplementedException();
        }



        Customer CustomerInterface1.GetById(int CustomerId)
        {
            var emplist = sx.Customers.FirstOrDefault(s => s.CustomerId == CustomerId);
            return emplist;
        }
    }

        
}












