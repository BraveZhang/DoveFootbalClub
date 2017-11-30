using DOVE.Application.Entity.DoveManage;
using System.Data.Entity.ModelConfiguration;

namespace DOVE.Application.Mapping.DoveManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 鸽子队足球俱乐部
    /// 创 建：超级管理员
    /// 日 期：2017-11-30 17:00
    /// 描 述：活动信息明细表
    /// </summary>
    public class T_Activity_DetailMap : EntityTypeConfiguration<T_Activity_DetailEntity>
    {
        public T_Activity_DetailMap()
        {
            #region 表、主键
            //表
            this.ToTable("T_Activity_Detail");
            //主键
            this.HasKey(t => t.Activitydetailid);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
