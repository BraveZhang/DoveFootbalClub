using DOVE.Application.Entity.PublicInfoManage;
using System.Data.Entity.ModelConfiguration;

namespace DOVE.Application.Oracle.Mapping.PublicInfoManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ���Ӷ�������ֲ�
    /// �� ��������
    /// �� �ڣ�2016-04-25 10:45
    /// �� �����ճ̹���
    /// </summary>
    public class ScheduleMap : EntityTypeConfiguration<ScheduleEntity>
    {
        public ScheduleMap()
        {
            #region ���ֶΡ�����
            //��
            this.ToTable("BASE_SCHEDULE");
            //�ֶ�
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
            //����
            this.HasKey(t => t.ScheduleId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
