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
   public  class EventService : Service<Event>, IEventService
    {
        static IDataBaseFactory factory = new DataBaseFactory();
        static IUnitOfWork UTK = new UnitOfWork(factory);
        public EventService() : base(UTK)
        {

        }
        public IEnumerable<Event> GetEventByCompanyId(int IdCompany)
        {
            return GetMany(c => c.CompanyId == IdCompany);
        }
    }

}
