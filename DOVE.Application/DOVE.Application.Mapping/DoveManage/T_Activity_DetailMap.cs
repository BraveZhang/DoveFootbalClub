using DOVE.Application.Entity.DoveManage;
using System.Data.Entity.ModelConfiguration;

namespace DOVE.Application.Mapping.DoveManage
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
            #region ������
            //��
            this.ToTable("T_Activity_Detail");
            //����
            this.HasKey(t => t.Activitydetailid);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
