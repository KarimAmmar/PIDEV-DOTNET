using Service.Pattern;
using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Service
{
    public interface ICompanyService : IService<Company>
    {
        IEnumerable<Company> GetCompanyById(int CompanyId);
        void UpdateCompany(Company c);
        IEnumerable<Company> GetCompanyByName(string name);
        IEnumerable<Company> GetCompanyByPlace(string place);



    }
}
