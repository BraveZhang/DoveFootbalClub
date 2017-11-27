using DOVE.Application.Entity.PublicInfoManage;
using System.Data.Entity.ModelConfiguration;

namespace DOVE.Application.Oracle.Mapping.PublicInfoManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 鸽子队足球俱乐部
    /// 创 建：张勇
    /// 日 期：2016-04-25 10:45
    /// 描 述：日程管理
    /// </summary>
    public class ScheduleMap : EntityTypeConfiguration<ScheduleEntity>
    {
        public ScheduleMap()
        {
            #region 表、字段、主键
            //表
            this.ToTable("BASE_SCHEDULE");
            //字段
            this.Property(x => x.ScheduleId).HasColumnName("SCHEDULEID");
            this.Property(x => x.ScheduleName).HasColumnName("SCHEDULENAME");
            this.Property(x => x.ScheduleContent).HasColumnName("SCHEDULECONTENT");
            this.Property(x => x.Category).HasColumnName("CATEGORY");
            this.Property(x => x.StartDate).HasColumnName("STARTDATE");
            this.Property(x => x.StartTime).HasColumnName("STARTTIME");
            this.Property(x => x.EndDate).HasColumnName("ENDDATE");
            this.Property(x => x.EndTime).HasColumnName("ENDTIME");
            this.Property(x => x.Early).HasColumnName("EARLY");
            this.Property(x => x.IsMailAlert).HasColumnName("ISMAILALERT");
            this.Property(x => x.IsMobileAlert).HasColumnName("ISMOBILEALERT");
            this.Property(x => x.IsWeChatAlert).HasColumnName("ISWECHATALERT");
            this.Property(x => x.ScheduleState).HasColumnName("SCHEDULESTATE");
            this.Property(x => x.SortCode).HasColumnName("SORTCODE");
            this.Property(x => x.DeleteMark).HasColumnName("DELETEMARK");
            this.Property(x => x.EnabledMark).HasColumnName("ENABLEDMARK");
            this.Property(x => x.Description).HasColumnName("DESCRIPTION");
            this.Property(x => x.CreateDate).HasColumnName("CREATEDATE");
            this.Property(x => x.CreateUserId).HasColumnName("CREATEUSERID");
            this.Property(x => x.CreateUserName).HasColumnName("CREATEUSERNAME");
            this.Property(x => x.ModifyDate).HasColumnName("MODIFYDATE");
            this.Property(x => x.ModifyUserId).HasColumnName("MODIFYUSERID");
            this.Property(x => x.ModifyUserName).HasColumnName("MODIFYUSERNAME");
            //主键
            this.HasKey(t => t.ScheduleId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
