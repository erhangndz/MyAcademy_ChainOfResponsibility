using ChainofResp.Web.DataAccess;
using ChainofResp.Web.Entities;
using ChainofResp.Web.Models;

namespace ChainofResp.Web.ChainOfResponsibilityPattern
{
    public class Treasurer(AppDbContext _context) : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel request)
        {
            if (request.Amount <= 50000)
            {
                var customerProcess = new CustomerProcess
                {
                    Amount = request.Amount,
                    FullName = request.FullName,
                    EmployeeName = "Veznedar - Barış Bingöl",
                    Description = "Para Çekme İşlemi Onaylandı. Müşteriye tutar ödendi."
                };

                _context.CustomerProcesses.Add(customerProcess);
                _context.SaveChanges();
            }

            else if(NextApprover is not null)
            {
                var customerProcess = new CustomerProcess
                {
                    Amount = request.Amount,
                    FullName = request.FullName,
                    EmployeeName = "Veznedar - Barış Bingöl",
                    Description = "Para çekme tutarı veznedarın ödeyebileceği miktarı aştığı içi işlem müdür yardımcısına yönlendirildi."
                };

                _context.CustomerProcesses.Add(customerProcess);
                _context.SaveChanges();
                NextApprover.ProcessRequest(request);
            }


        }
    }
}
