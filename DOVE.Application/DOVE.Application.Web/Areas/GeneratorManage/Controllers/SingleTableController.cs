using DOVE.Application.Busines.AuthorizeManage;
using DOVE.Application.Busines.SystemManage;
using DOVE.Application.Code;
using DOVE.Application.Entity.AuthorizeManage;
using DOVE.Application.Entity.SystemManage;
using DOVE.CodeGenerator;
using DOVE.CodeGenerator.Model;
using DOVE.CodeGenerator.Template;
using DOVE.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace DOVE.Application.Web.Areas.GeneratorManage.Controllers
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 鸽子队足球俱乐部
    /// 创建人：张勇
    /// 日 期：2016.2.2 10:29
    /// 描 述：生成器单表
    /// </summary>
    public class SingleTableController : MvcControllerBase
    {
        private ModuleBLL moduleBLL = new ModuleBLL();

        #region 视图功能
        /// <summary>
        /// 代码生成器
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CodeBuilder()
        {
            string OutputDirectory = Server.MapPath("~/Web.config"); ;
            for (int i = 0; i < 2; i++)
                OutputDirectory = OutputDirectory.Substring(0, OutputDirectory.LastIndexOf('\\'));
            ViewBag.OutputDirectory = OutputDirectory;
            ViewBag.UserName = OperatorProvider.Provider.Current().UserName;
            return View();
        }
        /// <summary>
        /// 编辑表格
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EditGrid()
        {
            return View();
        }
        /// <summary>
        /// 编辑控件
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EditControl()
        {
            return View();
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 查看代码
        /// </summary>
        /// <param name="baseInfoJson">基本信息配置Json</param>
        /// <param name="gridInfoJson">表格信息Json</param>
        /// <param name="gridColumnJson">表格字段信息Json</param>
        /// <param name="formInfoJson">表单信息Json</param>
        /// <param name="formFieldJson">表单字段信息Json</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult LookCode(string baseInfoJson, string gridInfoJson, string gridColumnJson, string formInfoJson, string formFieldJson)
        {
            SingleTable default_Template = new SingleTable();
            BaseConfigModel baseConfigModel = baseInfoJson.ToObject<BaseConfigModel>();
            baseConfigModel.gridModel = gridInfoJson.ToObject<GridModel>();
            baseConfigModel.gridColumnModel = gridColumnJson.ToList<GridColumnModel>();
            baseConfigModel.formModel = formInfoJson.ToObject<FormModel>();
            baseConfigModel.formFieldModel = formFieldJson.ToList<FormFieldModel>();

            var tableFiled = new DataBaseTableBLL().GetTableFiledList(baseConfigModel.DataBaseLinkId, baseConfigModel.DataBaseTableName);
            string entitybuilder = default_Template.EntityBuilder(baseConfigModel, DataHelper.ListToDataTable<DataBaseTableFieldEntity>(tableFiled.ToList()));
            string entitymapbuilder = default_Template.EntityMapBuilder(baseConfigModel);
            string entitymapbuilder_oracle = default_Template.EntityMapBuilder_Oracle(baseConfigModel, tableFiled);// add by zy 20170918 增加Oracle的映射类
            string servicebuilder = default_Template.ServiceBuilder(baseConfigModel);
            string iservicebuilder = default_Template.IServiceBuilder(baseConfigModel);
            string businesbuilder = default_Template.BusinesBuilder(baseConfigModel);
            string controllerbuilder = default_Template.ControllerBuilder(baseConfigModel);
            string indexbuilder = default_Template.IndexBuilder(baseConfigModel);
            string formbuilder = default_Template.FormBuilder(baseConfigModel);
            var jsonData = new
            {
                entityCode = entitybuilder,
                entitymapCode = entitymapbuilder,
                entitymapCode_Oracle = entitymapbuilder_oracle,// add by zy 20170918 增加Oracle的映射类
                serviceCode = servicebuilder,
                iserviceCode = iservicebuilder,
                businesCode = businesbuilder,
                controllerCode = controllerbuilder,
                indexCode = indexbuilder,
                formCode = formbuilder
            };
            return ToJsonResult(jsonData);
        }
        /// <summary>
        /// 创建代码（自动写入VS里面目录）
        /// </summary>
        /// <param name="baseInfoJson">基本信息配置Json</param>
        /// <param name="strCode">生成代码内容</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult CreateCode(string baseInfoJson, string strCode)
        {
            BaseConfigModel baseConfigModel = baseInfoJson.ToObject<BaseConfigModel>();
            CreateCodeFile.CreateExecution(baseConfigModel, Server.UrlDecode(strCode));
            return Success("恭喜您，创建成功！");
        }
        /// <summary>
        /// 发布功能（自动创建导航菜单）
        /// </summary>
        /// <param name="baseInfoJson">基本信息配置Json</param>
        /// <param name="moduleEntity">功能实体</param>
        /// <param name="moduleButtonList">按钮实体列表</param>
        /// <param name="moduleColumnList">视图实体列表</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult PublishModule(string baseInfoJson, ModuleEntity moduleEntity, string moduleButtonListJson, string moduleColumnListJson)
        {
            BaseConfigModel baseConfigModel = baseInfoJson.ToObject<BaseConfigModel>();
            var urlAddress = "/" + baseConfigModel.OutputAreas + "/" + CommonHelper.DelLastLength(baseConfigModel.ControllerName, 10) + "/" + baseConfigModel.IndexPageName;

            moduleEntity.SortCode = moduleBLL.GetSortCode();
            moduleEntity.IsMenu = 1;
            moduleEntity.EnabledMark = 1;
            moduleEntity.Target = "iframe";
            moduleEntity.UrlAddress = urlAddress;
            moduleBLL.SaveForm("", moduleEntity, moduleButtonListJson, moduleColumnListJson);
            return Success("发布成功！");
        }
        #endregion

        #region 处理数据
        /// <summary>
        /// 加载模板数据
        /// </summary>
        /// <param name="templateId">模板Id</param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetTemplateData(string templateId)
        {
            string filepath = Server.MapPath("~/Areas/SystemManage/Views/CodeGenerator/template/" + templateId + ".txt");
            FileStream fs = new System.IO.FileStream(filepath, FileMode.Open, System.IO.FileAccess.Read, FileShare.ReadWrite);
            StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("gb2312"));
            return Content(sr.ReadToEnd().ToString());
        }
        #endregion
    }
}
