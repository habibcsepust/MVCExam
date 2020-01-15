using MVCExam.Model.Model;
using MVCExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCExam.BLL.BLL;
using AutoMapper;

namespace MVCExam.Controllers
{
    public class MemberController : Controller
    {
        MemberManager _memberManager = new MemberManager();
        OrderManager _orderManager = new OrderManager();
     
        public ActionResult AddMember()
        {

            MemberViewModel memberViewModel = new MemberViewModel();
            memberViewModel.MemberTypeSelectListItems = _memberManager
                                                        .GetAllMemberType()
                                                        .Select(c => new SelectListItem()
                                                        {
                                                            Value = c.Id.ToString(),
                                                            Text = c.Type
                                                        }).ToList();
            return View(memberViewModel);
        }

        [HttpPost]
        public ActionResult AddMember(MemberViewModel memberViewModel)
        {
            string message = "";
            memberViewModel.MemberTypeSelectListItems = _memberManager
                                                        .GetAllMemberType()
                                                        .Select(c => new SelectListItem()
                                                        {
                                                            Value = c.Id.ToString(),
                                                            Text = c.Type
                                                        }).ToList();
            if (ModelState.IsValid)
            {
                Member member = Mapper.Map<Member>(memberViewModel);
                bool isExisMemberCode = _memberManager.ExistMemberCode(member);
                if (isExisMemberCode)
                {
                    ViewBag.existDuplicate = "Member is Already Exist..";
                    return View(memberViewModel);
                }


                if (_memberManager.Add(member))
                {
                    message = "Saved Successfully..";
                }
                else
                {
                    message = "Not Saved";
                }
            }
            else
            {
                ViewBag.InvalidModel = "ModelState is invalied!";
            }

            ViewBag.Message = message;
            return View(memberViewModel);
        }

        public JsonResult GetMemberDetailsByMemberId(int? memberId)
        {
            var memberDetails = _memberManager.GetAllMember().Where(c => c.Id == memberId).ToList();
            //var products = from p in productList select (new { p.Code });
            return Json(memberDetails, JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult GetFoodPriceByFoodId(int? foodId)
        {
            var foodPrice = _orderManager.GetAllFoodItem().Where(c => c.Id == foodId).ToList();
            //var products = from p in productList select (new { p.Code });
            return Json(foodPrice, JsonRequestBehavior.AllowGet);
        }
    }
}