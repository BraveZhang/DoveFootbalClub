﻿using DOVE.Application.Busines.AuthorizeManage;
using DOVE.Application.Code;
using DOVE.Application.Entity.AuthorizeManage;
using System.Web.Mvc;

namespace DOVE.Application.Web.Areas.AuthorizeManage.Controllers
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 鸽子队足球俱乐部
    /// 创建人：张勇
    /// 日 期：2015.11.20 13:32
    /// 描 述：过滤IP
    /// </summary>
    public class FilterIPController : MvcControllerBase
    {
        private FilterIPBLL filterIPBLL = new FilterIPBLL();

        #region 视图功能
        /// <summary>
        /// 过滤IP管理
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 过滤IP表单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Form()
        {
            return View();
        }
        #endregion

        #region 获取数据
        /// <summary>
        /// 过滤IP列表
        /// </summary>
        /// <param name="objectId">对象Id</param>
        /// <param name="visitType">访问:0-拒绝，1-允许</param>
        /// <returns>返回树形列表Json</returns>
        [HttpGet]
        public ActionResult GetListJson(string objectId, string visitType)
        {
            var data = filterIPBLL.GetList(objectId, visitType);
            return ToJsonResult(data);
        }
        /// <summary>
        /// 过滤IP实体 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = filterIPBLL.GetEntity(keyValue);
            return ToJsonResult(data);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除过滤IP
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult RemoveForm(string keyValue)
        {
            filterIPBLL.RemoveForm(keyValue);
            return Success("删除成功。");
        }
        /// <summary>
        /// 保存过滤IP表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="databaseLinkEntity">过滤IP实体</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(string keyValue, FilterIPEntity filterIPEntity)
        {
            filterIPBLL.SaveForm(keyValue, filterIPEntity);
            return Success("操作成功。");
        }
        #endregion
    }
}