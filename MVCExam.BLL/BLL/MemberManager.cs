using MVCExam.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCExam.Repository.Repository;

namespace MVCExam.BLL.BLL
{
    public class MemberManager
    {
        MemberRepository _memberRepository = new MemberRepository();
        public List<MemberType> GetAllMemberType()
        {
            return _memberRepository.GetAllMemberType();
        }

        public List<Member> GetAllMember()
        {
            return _memberRepository.GetAllMember();
        }

        public bool Add(Member member)
        {
            return _memberRepository.Add(member);
        }

        public bool ExistMemberCode(Member member)
        {
            return _memberRepository.ExistMemberCode(member);
        }
    }
}
