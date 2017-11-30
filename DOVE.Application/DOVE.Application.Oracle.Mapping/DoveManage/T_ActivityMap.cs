using DOVE.Application.Entity.DoveManage;
using System.Data.Entity.ModelConfiguration;

namespace DOVE.Application.Oracle.Mapping.DoveManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ���Ӷ�������ֲ�
    /// �� ������������Ա
    /// �� �ڣ�2017-11-30 15:59
    /// �� �������Ϣ��
    /// </summary>
    public class T_ActivityMap : EntityTypeConfiguration<T_ActivityEntity>
    {
        public T_ActivityMap()
        {
            #region ���ֶΡ�����
            //��
            this.ToTable("T_ACTIVITY");
            //�ֶ�
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
            //����
            this.HasKey(t => t.Activityid);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
