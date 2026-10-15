using ChainofResp.Web.DataAccess;
using ChainofResp.Web.Entities;
using ChainofResp.Web.Models;

namespace ChainofResp.Web.ChainOfResponsibilityPattern
{
    public class Manager(AppDbContext _context) : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel request)
        {
            if (request.Amount <= 500000)
            {
                var customerProcess = new CustomerProcess
                {
                    Amount = request.Amount,
                    FullName = request.FullName,
                    EmployeeName = "Şube Müdürü - Nurgül Elmalı",
                    Description = "Para Çekme İşlemi Onaylandı. Müşteriye tutar ödendi."
                };
                _context.CustomerProcesses.Add(customerProcess);
                _context.SaveChanges();
            }

            else if (NextApprover is not null)
            {
                var customerProcess = new CustomerProcess
                {
                    Amount = request.Amount,
                    FullName = request.FullName,
                    EmployeeName = "Şube Müdürü - Nurgül Elmalı",
                    Description = "Para çekme tutarı şube müdürünün ödeyebileceği miktarı aştığı için işlem bölge müdürüne yönlendirildi."
                };
                _context.CustomerProcesses.Add(customerProcess);
                _context.SaveChanges();
                NextApprover.ProcessRequest(request);
            }
        }
    }
}
