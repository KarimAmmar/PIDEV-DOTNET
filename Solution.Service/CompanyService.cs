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
    public class CompanyService : Service<Company>, ICompanyService
    {
        static IDataBaseFactory factory = new DataBaseFactory();
        static IUnitOfWork UTK = new UnitOfWork(factory);
        public CompanyService() : base(UTK)
        {

        }
        public IEnumerable<Company> GetCompanyById(int IdCompany)
        {
            return GetMany(c => c.CompanyId == IdCompany);
        }
        public void UpdateCompany(Company c)
        {
            UTK.GetRepositoryBase<Company>().Update(c);
            UTK.commit();
        }
        public IEnumerable<Company> GetCompanyByName(string name)
        {
            return GetMany(c => c.Company_Name.Contains(name));
        }
        public IEnumerable<Company> GetCompanyByPlace (string name)
        {
            return GetMany(x => x.Company_Address.Contains(name) );
            //return GetMany(co => co.Company_Name.Contains(place));
        }
    }
}
