using DOVE.Application.Entity.DoveManage;
using System.Data.Entity.ModelConfiguration;

namespace DOVE.Application.Oracle.Mapping.DoveManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ���Ӷ�������ֲ�
    /// �� ������������Ա
    /// �� �ڣ�2017-11-30 17:00
    /// �� �������Ϣ��ϸ��
    /// </summary>
    public class T_Activity_DetailMap : EntityTypeConfiguration<T_Activity_DetailEntity>
    {
        public T_Activity_DetailMap()
        {
            #region ���ֶΡ�����
            //��
            this.ToTable("T_ACTIVITY_DETAIL");
            //�ֶ�
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
            //����
            this.HasKey(t => t.Activitydetailid);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
