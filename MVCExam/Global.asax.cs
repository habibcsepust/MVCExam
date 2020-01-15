using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MVCExam.Models;
using MVCExam.Model.Model;

namespace MVCExam
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<MemberViewModel, Member>();
                cfg.CreateMap<Member, MemberViewModel>();

                cfg.CreateMap<OrderViewModel, Order>();
                cfg.CreateMap<Order, OrderViewModel>();
            });
        }
    }
}
