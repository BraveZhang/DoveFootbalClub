using DOVE.Application.Entity.BaseManage;
using System.Data.Entity.ModelConfiguration;

namespace DOVE.Application.Oracle.Mapping.BaseManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 鸽子队足球俱乐部
    /// 创建人：张勇
    /// 日 期：2015.11.03 10:58
    /// 描 述：用户管理
    /// </summary>
    public class UserMap : EntityTypeConfiguration<UserEntity>
    {
        public UserMap()
        {
            #region 表、字段、主键
            //表
            this.ToTable("BASE_USER");
            //字段
            this.Property(x => x.UserId).HasColumnName("USERID");
            this.Property(x => x.EnCode).HasColumnName("ENCODE");
            this.Property(x => x.Account).HasColumnName("ACCOUNT");
            this.Property(x => x.Password).HasColumnName("PASSWORD");
            this.Property(x => x.Secretkey).HasColumnName("SECRETKEY");
            this.Property(x => x.RealName).HasColumnName("REALNAME");
            this.Property(x => x.NickName).HasColumnName("NICKNAME");
            this.Property(x => x.HeadIcon).HasColumnName("HEADICON");
            this.Property(x => x.QuickQuery).HasColumnName("QUICKQUERY");
            this.Property(x => x.SimpleSpelling).HasColumnName("SIMPLESPELLING");
            this.Property(x => x.Gender).HasColumnName("GENDER");
            this.Property(x => x.Birthday).HasColumnName("BIRTHDAY");
            this.Property(x => x.Mobile).HasColumnName("MOBILE");
            this.Property(x => x.Telephone).HasColumnName("TELEPHONE");
            this.Property(x => x.Email).HasColumnName("EMAIL");
            this.Property(x => x.OICQ).HasColumnName("OICQ");
            this.Property(x => x.WeChat).HasColumnName("WECHAT");
            this.Property(x => x.MSN).HasColumnName("MSN");
            this.Property(x => x.ManagerId).HasColumnName("MANAGERID");
            this.Property(x => x.Manager).HasColumnName("MANAGER");
            this.Property(x => x.OrganizeId).HasColumnName("ORGANIZEID");
            this.Property(x => x.DepartmentId).HasColumnName("DEPARTMENTID");
            this.Property(x => x.RoleId).HasColumnName("ROLEID");
            this.Property(x => x.DutyId).HasColumnName("DUTYID");
            this.Property(x => x.DutyName).HasColumnName("DUTYNAME");
            this.Property(x => x.PostId).HasColumnName("POSTID");
            this.Property(x => x.PostName).HasColumnName("POSTNAME");
            this.Property(x => x.WorkGroupId).HasColumnName("WORKGROUPID");
            this.Property(x => x.SecurityLevel).HasColumnName("SECURITYLEVEL");
            this.Property(x => x.UserOnLine).HasColumnName("USERONLINE");
            this.Property(x => x.OpenId).HasColumnName("OPENID");
            this.Property(x => x.Question).HasColumnName("QUESTION");
            this.Property(x => x.AnswerQuestion).HasColumnName("ANSWERQUESTION");
            this.Property(x => x.CheckOnLine).HasColumnName("CHECKONLINE");
            this.Property(x => x.AllowStartTime).HasColumnName("ALLOWSTARTTIME");
            this.Property(x => x.AllowEndTime).HasColumnName("ALLOWENDTIME");
            this.Property(x => x.LockStartDate).HasColumnName("LOCKSTARTDATE");
            this.Property(x => x.LockEndDate).HasColumnName("LOCKENDDATE");
            this.Property(x => x.FirstVisit).HasColumnName("FIRSTVISIT");
            this.Property(x => x.PreviousVisit).HasColumnName("PREVIOUSVISIT");
            this.Property(x => x.LastVisit).HasColumnName("LASTVISIT");
            this.Property(x => x.LogOnCount).HasColumnName("LOGONCOUNT");
            this.Property(x => x.SortCode).HasColumnName("SORTCODE");
            this.Property(x => x.DeleteMark).HasColumnName("DELETEMARK");
            this.Property(x => x.EnabledMark).HasColumnName("ENABLEDMARK");
            this.Property(x => x.Description).HasColumnName("DESCRIPTION");
            this.Property(x => x.CreateDate).HasColumnName("CREATEDATE");
            this.Property(x => x.CreateUserId).HasColumnName("CREATEUSERID");
            this.Property(x => x.CreateUserName).HasColumnName("CREATEUSERNAME");
            this.Property(x => x.ModifyDate).HasColumnName("MODIFYDATE");
            this.Property(x => x.ModifyUserId).HasColumnName("MODIFYUSERID");
            this.Property(x => x.ModifyUserName).HasColumnName("MODIFYUSERNAME");
            this.Property(x => x.ClothesNumber).HasColumnName("CLOTHESNUMBER");
            this.Property(x => x.ClothesSize).HasColumnName("CLOTHESSIZE");
            this.Property(x => x.JoinDate).HasColumnName("JOINDATE");
            //主键
            this.HasKey(t => t.UserId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
