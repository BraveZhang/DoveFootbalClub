using DOVE.Application.Entity.PublicInfoManage;
using System.Data.Entity.ModelConfiguration;

namespace DOVE.Application.Mapping.PublicInfoManage
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
            #region ������
            //��
            this.ToTable("Base_Schedule");
            //����
            this.HasKey(t => t.ScheduleId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
