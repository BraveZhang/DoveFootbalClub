using RH.Application.Entity.BaseManage;
using RH.Application.IService.BaseManage;
using RH.Data.Repository;
using RH.Util.WebControl;
using System.Collections.Generic;
using System.Linq;

namespace RH.Application.Service.BaseManage
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 ������ʵҵ���Ÿ��¿Ƽ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2017-09-18 16:14
    /// �� ���������ֵ�����
    /// </summary>
    public class Base_DataitemService : RepositoryFactory<Base_DataitemEntity>, Base_DataitemIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<Base_DataitemEntity> GetList(string queryJson)
        {
            return this.BaseRepository().IQueryable().ToList();
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public Base_DataitemEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity(keyValue);
        }
        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
        public void RemoveForm(string keyValue)
        {
            this.BaseRepository().Delete(keyValue);
        }
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, Base_DataitemEntity entity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                entity.Modify(keyValue);
                this.BaseRepository().Update(entity);
            }
            else
            {
                entity.Create();
                this.BaseRepository().Insert(entity);
            }
        }
        #endregion
    }
}
