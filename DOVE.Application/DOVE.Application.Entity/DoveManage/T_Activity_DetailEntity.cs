using System;
using DOVE.Application.Code;

namespace DOVE.Application.Entity.DoveManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ���Ӷ�������ֲ�
    /// �� ������������Ա
    /// �� �ڣ�2017-11-30 17:00
    /// �� �������Ϣ��ϸ��
    /// </summary>
    public class T_Activity_DetailEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ���ϸ����ID
        /// </summary>
        /// <returns></returns>
        public string Activitydetailid { get; set; }
        /// <summary>
        /// �ID
        /// </summary>
        /// <returns></returns>
        public string Activityid { get; set; }
        /// <summary>
        /// �û�ID
        /// </summary>
        /// <returns></returns>
        public string Userid { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <returns></returns>
        public DateTime? Time { get; set; }
        /// <summary>
        /// ��ע
        /// </summary>
        /// <returns></returns>
        public string Description { get; set; }
        /// <summary>
        /// �ӱ�
        /// </summary>
        /// <returns></returns>
        public string Teamname { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        public int? Sortcode { get; set; }
        /// <summary>
        /// ɾ�����
        /// </summary>
        /// <returns></returns>
        public int? Deletemark { get; set; }
        /// <summary>
        /// ��Ч��־
        /// </summary>
        /// <returns></returns>
        public int? Enabledmark { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        public DateTime? Createdate { get; set; }
        /// <summary>
        /// �����û�����
        /// </summary>
        /// <returns></returns>
        public string Createuserid { get; set; }
        /// <summary>
        /// �����û�
        /// </summary>
        /// <returns></returns>
        public string Createusername { get; set; }
        /// <summary>
        /// �޸�����
        /// </summary>
        /// <returns></returns>
        public DateTime? Modifydate { get; set; }
        /// <summary>
        /// �޸��û�����
        /// </summary>
        /// <returns></returns>
        public string Modifyuserid { get; set; }
        /// <summary>
        /// �޸��û�
        /// </summary>
        /// <returns></returns>
        public string Modifyusername { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.Activitydetailid = Guid.NewGuid().ToString();
            this.Createdate = DateTime.Now;
            this.Createuserid = OperatorProvider.Provider.Current().UserId;
            this.Createusername = OperatorProvider.Provider.Current().UserName;
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.Activitydetailid = keyValue;
            this.Modifydate = DateTime.Now;
            this.Modifyuserid = OperatorProvider.Provider.Current().UserId;
            this.Modifyusername = OperatorProvider.Provider.Current().UserName;
        }
        #endregion
    }
}