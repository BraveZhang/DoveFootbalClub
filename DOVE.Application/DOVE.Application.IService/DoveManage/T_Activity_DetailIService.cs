using DOVE.Application.Entity.DoveManage;
using DOVE.Util.WebControl;
using System.Collections.Generic;
using System.Data;

namespace DOVE.Application.IService.DoveManage
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 ���Ӷ�������ֲ�
    /// �� ������������Ա
    /// �� �ڣ�2017-11-30 17:00
    /// �� �������Ϣ��ϸ��
    /// </summary>
    public interface T_Activity_DetailIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        DataTable GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        IEnumerable<T_Activity_DetailEntity> GetList(string queryJson);
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        T_Activity_DetailEntity GetEntity(string keyValue);
        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
        void RemoveForm(string keyValue);
        /// <summary>
        /// ����������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        void SaveForm(string keyValue, T_Activity_DetailEntity entity);
        #endregion
    }
}