using Service.Pattern;
using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Service
{
    public interface IInterviewService : IService<Interview>
    {
        IEnumerable<Interview> GetInterviewById(int Id);
        IEnumerable<Interview> GetInterviewByCandidateId(int Id);
        IEnumerable<Interview> GetInterviewByLocation(string loc);
        IEnumerable<Interview> GetInterviewByLocationAndType(string loc,string typeint);

    }
}
