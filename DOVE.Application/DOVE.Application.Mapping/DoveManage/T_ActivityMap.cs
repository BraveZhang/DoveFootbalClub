using DOVE.Application.Entity.DoveManage;
using System.Data.Entity.ModelConfiguration;

namespace DOVE.Application.Mapping.DoveManage
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
            #region ������
            //��
            this.ToTable("T_Activity");
            //����
            this.HasKey(t => t.Activityid);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
