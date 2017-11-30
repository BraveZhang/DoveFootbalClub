using DOVE.Application.Entity.DoveManage;
using DOVE.Application.IService.DoveManage;
using DOVE.Application.Service.DoveManage;
using DOVE.Util.WebControl;
using System.Collections.Generic;
using System;
using System.Data;

namespace DOVE.Application.Busines.DoveManage
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 ���Ӷ�������ֲ�
    /// �� ������������Ա
    /// �� �ڣ�2017-11-30 17:00
    /// �� �������Ϣ��ϸ��
    /// </summary>
    public class T_Activity_DetailBLL
    {
        private T_Activity_DetailIService service = new T_Activity_DetailService();

        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public DataTable GetPageList(Pagination pagination, string queryJson)
        {
            return service.GetPageList(pagination, queryJson);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<T_Activity_DetailEntity> GetList(string queryJson)
        {
            return service.GetList(queryJson);
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public T_Activity_DetailEntity GetEntity(string keyValue)
        {
            return service.GetEntity(keyValue);
        }
        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
        public void RemoveForm(string keyValue)
        {
            try
            {
                service.RemoveForm(keyValue);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, T_Activity_DetailEntity entity)
        {
            try
            {
                service.SaveForm(keyValue, entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
