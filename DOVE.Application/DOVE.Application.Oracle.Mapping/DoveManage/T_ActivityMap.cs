using DOVE.Application.Entity.DoveManage;
using System.Data.Entity.ModelConfiguration;

namespace DOVE.Application.Oracle.Mapping.DoveManage
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
            #region 表、字段、主键
            //表
            this.ToTable("T_ACTIVITY");
            //字段
            this.Property(x => x.Activityid).HasColumnName("ACTIVITYID");
            this.Property(x => x.Activityname).HasColumnName("ACTIVITYNAME");
            this.Property(x => x.Activitycode).HasColumnName("ACTIVITYCODE");
            this.Property(x => x.Address).HasColumnName("ADDRESS");
            this.Property(x => x.Content).HasColumnName("CONTENT");
            this.Property(x => x.Activitystarttime).HasColumnName("ACTIVITYSTARTTIME");
            this.Property(x => x.Activityendtime).HasColumnName("ACTIVITYENDTIME");
            this.Property(x => x.Signupstarttime).HasColumnName("SIGNUPSTARTTIME");
            this.Property(x => x.Signupendtime).HasColumnName("SIGNUPENDTIME");
            this.Property(x => x.Sortcode).HasColumnName("SORTCODE");
            this.Property(x => x.Initiator).HasColumnName("INITIATOR");
            this.Property(x => x.Deletemark).HasColumnName("DELETEMARK");
            this.Property(x => x.Enabledmark).HasColumnName("ENABLEDMARK");
            this.Property(x => x.Description).HasColumnName("DESCRIPTION");
            this.Property(x => x.Createdate).HasColumnName("CREATEDATE");
            this.Property(x => x.Createuserid).HasColumnName("CREATEUSERID");
            this.Property(x => x.Createusername).HasColumnName("CREATEUSERNAME");
            this.Property(x => x.Modifydate).HasColumnName("MODIFYDATE");
            this.Property(x => x.Modifyuserid).HasColumnName("MODIFYUSERID");
            this.Property(x => x.Modifyusername).HasColumnName("MODIFYUSERNAME");
            //主键
            this.HasKey(t => t.Activityid);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
