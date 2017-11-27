using RH.Application.Entity.BaseManage;
using RH.Util.WebControl;
using System.Collections.Generic;

namespace RH.Application.IService.BaseManage
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 ������ʵҵ���Ÿ��¿Ƽ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2017-09-18 16:14
    /// �� ���������ֵ�����
    /// </summary>
    public interface Base_DataitemIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        IEnumerable<Base_DataitemEntity> GetList(string queryJson);
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        Base_DataitemEntity GetEntity(string keyValue);
        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
        void RemoveForm(string keyValue);
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        void SaveForm(string keyValue, Base_DataitemEntity entity);
        #endregion
    }
}
