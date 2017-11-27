using RH.Application.Entity.BaseManage;
using RH.Util.WebControl;
using System.Collections.Generic;

namespace RH.Application.IService.BaseManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 辽宁瑞华实业集团高新科技有限公司
    /// 创 建：超级管理员
    /// 日 期：2017-09-18 16:14
    /// 描 述：数据字典分类表
    /// </summary>
    public interface Base_DataitemIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        IEnumerable<Base_DataitemEntity> GetList(string queryJson);
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        Base_DataitemEntity GetEntity(string keyValue);
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        void RemoveForm(string keyValue);
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        void SaveForm(string keyValue, Base_DataitemEntity entity);
        #endregion
    }
}
