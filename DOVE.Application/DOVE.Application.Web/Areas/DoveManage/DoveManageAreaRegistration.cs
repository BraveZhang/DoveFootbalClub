﻿using System.Web.Mvc;

namespace DOVE.Application.Web.Areas.DoveManage
{
    public class DoveManageAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "DoveManage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
              this.AreaName + "_Default",
              this.AreaName + "/{controller}/{action}/{id}",
              new { area = this.AreaName, controller = "Home", action = "Index", id = UrlParameter.Optional },
              new string[] { "DOVE.Application.Web.Areas." + this.AreaName + ".Controllers" }
            );
        }
    }
}
