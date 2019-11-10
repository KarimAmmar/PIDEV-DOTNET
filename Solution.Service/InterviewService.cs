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
    public class InterviewService : Service<Interview>, IInterviewService
    {
        static IDataBaseFactory factory = new DataBaseFactory();

        static UnitOfWork UTK = new UnitOfWork(factory);
        public InterviewService() : base(UTK)
        {


        }

        public IEnumerable<Interview> GetInterviewByCandidateId(int Id)
        {
            return GetMany(i => i.Candidat_Id == Id);

        }

        public IEnumerable<Interview> GetInterviewById(int Id)
        {
            return GetMany(i => i.InterviewId == Id);
        }

        public IEnumerable<Interview> GetInterviewByLocation(string loc)
        {
           
            return GetMany(x => x.Interview_Location.Contains(loc) || loc==null);
        }

        public IEnumerable<Interview> GetInterviewByLocationAndType(string loc, string typeint)
        {
            
            if (typeint== "Scheduled")
            {
               // return GetMany( x => x.Interview_Type == TypeInt.Scheduled);
                return GetMany(x => x.Interview_Location.Contains(loc) &&  x.Interview_Type == TypeInt.Scheduled || loc == null ) ;
            }
            if (typeint == "Unscheduled")
            {
                return GetMany(x => x.Interview_Location.Contains(loc) && x.Interview_Type == TypeInt.Unscheduled || loc == null);
            }
            if (typeint == "Done")
            {
                return GetMany(x => x.Interview_Location.Contains(loc) && x.Interview_Type == TypeInt.Done || loc == null);
            }
            return GetMany(x => x.Interview_Location.Contains(loc) || loc == null);

            
        }
    }
}
