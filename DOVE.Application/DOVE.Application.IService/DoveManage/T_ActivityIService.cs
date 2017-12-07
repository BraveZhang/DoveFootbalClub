using DOVE.Application.Entity.DoveManage;
using DOVE.Util.WebControl;
using System.Collections.Generic;
using System.Data;

namespace DOVE.Application.IService.DoveManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 鸽子队足球俱乐部
    /// 创 建：超级管理员
    /// 日 期：2017-11-30 15:59
    /// 描 述：活动信息表
    /// </summary>
    public interface T_ActivityIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        DataTable GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取详情列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        DataTable GetDetailList(string queryJson);
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        IEnumerable<T_ActivityEntity> GetList(string queryJson);
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        T_ActivityEntity GetEntity(string keyValue);
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
        /// <param name="strUserIds">参与者id字符串</param>
        /// <returns></returns>
        void SaveForm(string keyValue, T_ActivityEntity entity, string strUserIds);
        /// <summary>
        /// 小立活动Excel导入保存
        /// </summary>
        /// <param name="dt">数据dt</param>
        /// <param name="sheetName">sheetName</param>
        /// <returns></returns>
        void XiaoliSaveForm(DataTable dt, string sheetName);

        /// <summary>
        /// 多活动Excel导入保存
        /// </summary>
        /// <param name="dt">数据dt</param>
        /// <param name="sheetName">sheetName</param>
        /// <returns></returns>
        void ActivitiesSaveForm(DataTable dt);
        #endregion
    }
}
