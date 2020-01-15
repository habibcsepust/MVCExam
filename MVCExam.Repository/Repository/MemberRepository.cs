using MVCExam.DatabaseContext.DatabaseContext;
using MVCExam.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MVCExam.Repository.Repository
{
    public class MemberRepository
    {
        ProjectDbContext db = new ProjectDbContext();

        public List<MemberType> GetAllMemberType()
        {
            return db.MemberTypes.ToList();
        }

        public List<Member> GetAllMember()
        {
            return db.Members.ToList();
        }

        //public List<Member> GetAllMember()
        //{
        //    return db.Members.Include(c => c.MemberType).ToList();
        //}

        public bool Add(Member member)
        {
            db.Members.Add(member);
            return db.SaveChanges() > 0;
        }

        public bool ExistMemberCode(Member member)
        {
            bool isExistMemberCode = false;
            Member membr = db.Members.FirstOrDefault(c => c.Code == member.Code);
            if (membr != null)
            {
                isExistMemberCode = true;
            }
            return isExistMemberCode;
        }
    }
}
