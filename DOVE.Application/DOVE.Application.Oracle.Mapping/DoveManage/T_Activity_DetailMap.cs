using DOVE.Application.Entity.DoveManage;
using System.Data.Entity.ModelConfiguration;

namespace DOVE.Application.Oracle.Mapping.DoveManage
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
            #region 表、字段、主键
            //表
            this.ToTable("T_ACTIVITY_DETAIL");
            //字段
            this.Property(x => x.Activitydetailid).HasColumnName("ACTIVITYDETAILID");
            this.Property(x => x.Activityid).HasColumnName("ACTIVITYID");
            this.Property(x => x.Userid).HasColumnName("USERID");
            this.Property(x => x.Time).HasColumnName("TIME");
            this.Property(x => x.Description).HasColumnName("DESCRIPTION");
            this.Property(x => x.Teamname).HasColumnName("TEAMNAME");
            this.Property(x => x.Sortcode).HasColumnName("SORTCODE");
            this.Property(x => x.Deletemark).HasColumnName("DELETEMARK");
            this.Property(x => x.Enabledmark).HasColumnName("ENABLEDMARK");
            this.Property(x => x.Createdate).HasColumnName("CREATEDATE");
            this.Property(x => x.Createuserid).HasColumnName("CREATEUSERID");
            this.Property(x => x.Createusername).HasColumnName("CREATEUSERNAME");
            this.Property(x => x.Modifydate).HasColumnName("MODIFYDATE");
            this.Property(x => x.Modifyuserid).HasColumnName("MODIFYUSERID");
            this.Property(x => x.Modifyusername).HasColumnName("MODIFYUSERNAME");
            //主键
            this.HasKey(t => t.Activitydetailid);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
