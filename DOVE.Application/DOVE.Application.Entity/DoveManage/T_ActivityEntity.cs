using System;
using DOVE.Application.Code;

namespace DOVE.Application.Entity.DoveManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ���Ӷ�������ֲ�
    /// �� ������������Ա
    /// �� �ڣ�2017-11-30 15:59
    /// �� �������Ϣ��
    /// </summary>
    public class T_ActivityEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// �����ID
        /// </summary>
        /// <returns></returns>
        public string Activityid { get; set; }
        /// <summary>
        /// �����
        /// </summary>
        /// <returns></returns>
        public string Activityname { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string Activitycode { get; set; }
        /// <summary>
        /// ��ص�
        /// </summary>
        /// <returns></returns>
        public string Address { get; set; }
        /// <summary>
        /// �����
        /// </summary>
        /// <returns></returns>
        public string Content { get; set; }
        /// <summary>
        /// ���ʼʱ��
        /// </summary>
        /// <returns></returns>
        public DateTime? Activitystarttime { get; set; }
        /// <summary>
        /// �����ʱ��
        /// </summary>
        /// <returns></returns>
        public DateTime? Activityendtime { get; set; }
        /// <summary>
        /// ������ʼʱ��
        /// </summary>
        /// <returns></returns>
        public DateTime? Signupstarttime { get; set; }
        /// <summary>
        /// ������ֹʱ��
        /// </summary>
        /// <returns></returns>
        public DateTime? Signupendtime { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        public int? Sortcode { get; set; }
        /// <summary>
        /// ������ID
        /// </summary>
        /// <returns></returns>
        public string Initiator { get; set; }
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
        /// ��ע
        /// </summary>
        /// <returns></returns>
        public string Description { get; set; }
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
            this.Activityid = Guid.NewGuid().ToString();
            this.Createdate = DateTime.Now;
            this.Enabledmark = 1;// add by zy 20171206
            this.Deletemark = 0;// add by zy 20171206
            this.Createuserid = OperatorProvider.Provider.Current().UserId;
            this.Createusername = OperatorProvider.Provider.Current().UserName;
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.Activityid = keyValue;
            this.Modifydate = DateTime.Now;
            this.Modifyuserid = OperatorProvider.Provider.Current().UserId;
            this.Modifyusername = OperatorProvider.Provider.Current().UserName;
        }
        #endregion
    }
}