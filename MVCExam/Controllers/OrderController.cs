using AutoMapper;
using MVCExam.BLL.BLL;
using MVCExam.Model.Model;
using MVCExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCExam.Controllers
{
    public class OrderController : Controller
    {
        OrderManager _orderManager = new OrderManager();
        MemberManager _memberManager = new MemberManager();

        public ActionResult Order()
        {
            OrderViewModel orderViewModel = new OrderViewModel();
            orderViewModel.FoodItemSelectListItems = _orderManager
                                                        .GetAllFoodItem()
                                                        .Select(c => new SelectListItem()
                                                        {
                                                            Value = c.Id.ToString(),
                                                            Text = c.Item
                                                        }).ToList();
            MemberViewModel memberViewModel = new MemberViewModel();
            memberViewModel.MemberSelectListItems = _memberManager
                                                        .GetAllMember()
                                                        .Select(c => new SelectListItem()
                                                        {
                                                            Value = c.Id.ToString(),
                                                            Text = c.Code
                                                        }).ToList();
            ViewBag.MemberId = memberViewModel.MemberSelectListItems;
            return View(orderViewModel);
        }

        [HttpPost]
        public ActionResult Order(OrderViewModel orderViewModel)
        {
            string message = "";
            //OrderViewModel orderViewModel = new OrderViewModel();
            orderViewModel.FoodItemSelectListItems = _orderManager
                                                        .GetAllFoodItem()
                                                        .Select(c => new SelectListItem()
                                                        {
                                                            Value = c.Id.ToString(),
                                                            Text = c.Item
                                                        }).ToList();
            MemberViewModel memberViewModel = new MemberViewModel();
            memberViewModel.MemberSelectListItems = _memberManager
                                                        .GetAllMember()
                                                        .Select(c => new SelectListItem()
                                                        {
                                                            Value = c.Id.ToString(),
                                                            Text = c.Code
                                                        }).ToList();
            ViewBag.MemberId = memberViewModel.MemberSelectListItems;

            if (ModelState.IsValid)
            {
                Order order = Mapper.Map<Order>(orderViewModel);

                if (_orderManager.Add(order))
                {
                    message = "Saved Successfully..";
                }
                else
                {
                    message = "Not Saved..";
                }
            }
            else
            {
                ViewBag.InvalidModel = "ModelState is invalied!";
            }

            ViewBag.Message = message;
            return View(orderViewModel);
        }

        //public JsonResult GetReportDetailsBySelectDate(int? selectDate)
        //{
        //    var reportDetails = _memberManager.GetAllMember().Where(c => c.Id == memberId).ToList();
        //    //var products = from p in productList select (new { p.Code });
        //    return Json(reportDetails, JsonRequestBehavior.AllowGet);
        //}
    }
}