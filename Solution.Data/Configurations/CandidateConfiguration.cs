using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Data.Configurations
{
    class CandidateConfiguration : EntityTypeConfiguration<Candidate>
    {
        public CandidateConfiguration()
        {

           

            HasMany<Experience>(c => c.Experiences)
                    .WithOptional(e=>e.Candidate)
                    .HasForeignKey(e => e.CandidateId).WillCascadeOnDelete(true);

            HasMany<Skill>(c => c.Skills)
                   .WithOptional(e => e.Candidate)
                   .HasForeignKey(e => e.CandidateId).WillCascadeOnDelete(true);

            HasMany<Diploma>(c => c.Diplomas)
                   .WithOptional(e => e.Candidate)
                   .HasForeignKey(e => e.CandidateId).WillCascadeOnDelete(true);

            HasMany<Certification>(c => c.Certifications)
            .WithOptional(e => e.Candidate)
            .HasForeignKey(e => e.CandidateId).WillCascadeOnDelete(true);

            HasMany<Candidate>(c => c.Contacts).WithMany().Map(w => w.ToTable("contact").MapLeftKey("CandidateId").MapRightKey("ContactId"));





            HasMany(prod => prod.Offers).WithMany(cat => cat.Candidates).Map(M =>
            {
    M.ToTable("OffresOfCandidate");
    M.MapRightKey("Candidate");//le nom de la clé dans la tab de relation est Product
    M.MapLeftKey("Offres");
});

        
 

       
 HasMany(prod => prod.Companies).WithMany(cat => cat.Candidates).Map(M =>
            {
    M.ToTable("Subscribers");
    M.MapRightKey("Candidate");//le nom de la clé dans la tab de relation est Product
    M.MapLeftKey("Company");
});

            HasMany(cand => cand.Interviews).
                          WithRequired(inter => inter.candidate).//prop nav
                          HasForeignKey(inter => inter.Candidat_Id).//prop nav
                          WillCascadeOnDelete(false);
        }

}
}
