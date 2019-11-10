using Service.Pattern;
using Solution.Data.Infrastructure;
using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Service
{
    public class OfferService : Service<Offer>, IOfferService
    {
        static IDataBaseFactory factory = new DataBaseFactory();
        static IUnitOfWork UTK = new UnitOfWork(factory);

        public OfferService() : base(UTK)
        {
            
           
        }
   
        public IEnumerable<Offer> GetOfferByCompanyId(int IdCompany)
        {
            return GetMany(c => c.CompanyId == IdCompany);
        }
       
        public IEnumerable<Offer> GetOfferByTitle(string name)
        {
            return GetMany(c => c.Offer_Title.Contains(name));
        }
       

    }
}
