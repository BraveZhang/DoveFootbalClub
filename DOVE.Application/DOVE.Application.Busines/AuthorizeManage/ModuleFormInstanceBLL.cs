﻿using DOVE.Application.Entity.AuthorizeManage;
using DOVE.Application.IService.AuthorizeManage;
using DOVE.Application.Service.AuthorizeManage;

namespace DOVE.Application.Busines.AuthorizeManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 鸽子队足球俱乐部
    /// 创建人：张勇
    /// 日 期：2016.04.14 09:16
    /// 描 述：系统表单实例
    /// </summary>
    public class ModuleFormInstanceBLL
    {
        private IModuleFormInstanceService server = new ModuleFormInstanceService();

        #region 获取数据
        /// <summary>
        /// 获取一个实体类
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public ModuleFormInstanceEntity GetEntityByObjectId(string objectId)
        {
            try
            {
                if (!string.IsNullOrEmpty(objectId))
                {
                    return server.GetEntityByObjectId(objectId);
                }
                else
                {
                    return null;
                }
                
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 保存一个实体
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int SaveEntity(string keyValue, ModuleFormInstanceEntity entity)
        {
            try
            {
                return server.SaveEntity(keyValue,entity);
            }
            catch
            {
                throw;
            }
        }
        #endregion
    }
}
