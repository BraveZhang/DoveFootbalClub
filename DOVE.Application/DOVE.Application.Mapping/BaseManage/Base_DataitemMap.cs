using RH.Application.Entity.BaseManage;
using System.Data.Entity.ModelConfiguration;

namespace RH.Application.Mapping.BaseManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ������ʵҵ���Ÿ��¿Ƽ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2017-09-18 16:14
    /// �� ���������ֵ�����
    /// </summary>
    public class Base_DataitemMap : EntityTypeConfiguration<Base_DataitemEntity>
    {
        public Base_DataitemMap()
        {
            #region ������
            //��
            this.ToTable("Base_Dataitem");
            //����
            this.HasKey(t => t.Itemid);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
