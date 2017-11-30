using DOVE.Application.Entity.DoveManage;
using System.Data.Entity.ModelConfiguration;

namespace DOVE.Application.Mapping.DoveManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 鸽子队足球俱乐部
    /// 创 建：超级管理员
    /// 日 期：2017-11-30 15:59
    /// 描 述：活动信息表
    /// </summary>
    public class T_ActivityMap : EntityTypeConfiguration<T_ActivityEntity>
    {
        public T_ActivityMap()
        {
            #region 表、主键
            //表
            this.ToTable("T_Activity");
            //主键
            this.HasKey(t => t.Activityid);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
