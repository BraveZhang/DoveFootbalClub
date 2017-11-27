﻿using DOVE.Application.Entity.AuthorizeManage;
using DOVE.Application.IService.AuthorizeManage;
using DOVE.Application.Service.BaseManage;
using System;
using System.Collections.Generic;

namespace DOVE.Application.Busines.AuthorizeManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 鸽子队足球俱乐部
    /// 创建人：张勇
    /// 日 期：2015.10.29 15:13
    /// 描 述：系统视图
    /// </summary>
    public class ModuleColumnBLL
    {
        private IModuleColumnService service = new ModuleColumnService();

        #region 获取数据
        /// <summary>
        /// 视图列表
        /// </summary>
        /// <returns></returns>
        public List<ModuleColumnEntity> GetList()
        {
            return service.GetList();
        }
        /// <summary>
        /// 视图列表
        /// </summary>
        /// <param name="moduleId">功能Id</param>
        /// <returns></returns>
        public List<ModuleColumnEntity> GetList(string moduleId)
        {
            return service.GetList(moduleId);
        }
        /// <summary>
        /// 视图实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public ModuleColumnEntity GetEntity(string keyValue)
        {
            return service.GetEntity(keyValue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 复制视图 
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="moduleId">功能主键</param>
        /// <returns></returns>
        public void CopyForm(string keyValue, string moduleId)
        {
            try
            {
                ModuleColumnEntity moduleColumnEntity = this.GetEntity(keyValue);
                moduleColumnEntity.ModuleId = moduleId;
                service.AddEntity(moduleColumnEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
