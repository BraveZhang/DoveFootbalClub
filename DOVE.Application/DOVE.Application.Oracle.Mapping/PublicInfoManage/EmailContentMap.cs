using DOVE.Application.Entity.PublicInfoManage;
using System.Data.Entity.ModelConfiguration;

namespace DOVE.Application.Oracle.Mapping.PublicInfoManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 鸽子队足球俱乐部
    /// 创建人：张勇
    /// 日 期：2015.12.8 11:31
    /// 描 述：邮件内容
    /// </summary>
    public class EmailContentMap : EntityTypeConfiguration<EmailContentEntity>
    {
        public EmailContentMap()
        {
            #region 表、字段、主键
            //表
            this.ToTable("EMAIL_CONTENT");
            //字段
            this.Property(x => x.ContentId).HasColumnName("CONTENTID");
            this.Property(x => x.CategoryId).HasColumnName("CATEGORYID");
            this.Property(x => x.ParentId).HasColumnName("PARENTID");
            this.Property(x => x.Theme).HasColumnName("THEME");
            this.Property(x => x.ThemeColor).HasColumnName("THEMECOLOR");
            this.Property(x => x.EmailContent).HasColumnName("EMAILCONTENT");
            this.Property(x => x.EmailType).HasColumnName("EMAILTYPE");
            this.Property(x => x.SenderId).HasColumnName("SENDERID");
            this.Property(x => x.SenderName).HasColumnName("SENDERNAME");
            this.Property(x => x.SenderTime).HasColumnName("SENDERTIME");
            this.Property(x => x.IsHighlight).HasColumnName("ISHIGHLIGHT");
            this.Property(x => x.SendPriority).HasColumnName("SENDPRIORITY");
            this.Property(x => x.IsSmsReminder).HasColumnName("ISSMSREMINDER");
            this.Property(x => x.IsReceipt).HasColumnName("ISRECEIPT");
            this.Property(x => x.SendState).HasColumnName("SENDSTATE");
            this.Property(x => x.AddresssHtml).HasColumnName("ADDRESSSHTML");
            this.Property(x => x.CopysendHtml).HasColumnName("COPYSENDHTML");
            this.Property(x => x.BccsendHtml).HasColumnName("BCCSENDHTML");
            this.Property(x => x.DeleteMark).HasColumnName("DELETEMARK");
            this.Property(x => x.EnabledMark).HasColumnName("ENABLEDMARK");
            this.Property(x => x.Description).HasColumnName("DESCRIPTION");
            this.Property(x => x.CreateDate).HasColumnName("CREATEDATE");
            this.Property(x => x.CreateUserId).HasColumnName("CREATEUSERID");
            this.Property(x => x.CreateUserName).HasColumnName("CREATEUSERNAME");
            this.Property(x => x.ModifyDate).HasColumnName("MODIFYDATE");
            this.Property(x => x.ModifyUserId).HasColumnName("MODIFYUSERID");
            this.Property(x => x.ModifyUserName).HasColumnName("MODIFYUSERNAME");
            //主键
            this.HasKey(t => t.ContentId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
