using DOVE.Application.Entity.PublicInfoManage;
using System.Data.Entity.ModelConfiguration;

namespace DOVE.Application.Oracle.Mapping.PublicInfoManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 鸽子队足球俱乐部
    /// 创建人：张勇
    /// 日 期：2015.12.8 11:31
    /// 描 述：邮件收件人
    /// </summary>
    public class EmailAddresseeMap : EntityTypeConfiguration<EmailAddresseeEntity>
    {
        public EmailAddresseeMap()
        {
            #region 表、字段、主键
            //表
            this.ToTable("EMAIL_ADDRESSEE");
            //字段
            this.Property(x => x.AddresseeId).HasColumnName("ADDRESSEEID");
            this.Property(x => x.ContentId).HasColumnName("CONTENTID");
            this.Property(x => x.CategoryId).HasColumnName("CATEGORYID");
            this.Property(x => x.RecipientId).HasColumnName("RECIPIENTID");
            this.Property(x => x.RecipientName).HasColumnName("RECIPIENTNAME");
            this.Property(x => x.RecipientState).HasColumnName("RECIPIENTSTATE");
            this.Property(x => x.IsRead).HasColumnName("ISREAD");
            this.Property(x => x.ReadCount).HasColumnName("READCOUNT");
            this.Property(x => x.ReadDate).HasColumnName("READDATE");
            this.Property(x => x.IsHighlight).HasColumnName("ISHIGHLIGHT");
            this.Property(x => x.Backlog).HasColumnName("BACKLOG");
            this.Property(x => x.DeleteMark).HasColumnName("DELETEMARK");
            this.Property(x => x.CreateDate).HasColumnName("CREATEDATE");
            this.Property(x => x.CreateUserId).HasColumnName("CREATEUSERID");
            this.Property(x => x.CreateUserName).HasColumnName("CREATEUSERNAME");
            this.Property(x => x.ModifyDate).HasColumnName("MODIFYDATE");
            this.Property(x => x.ModifyUserId).HasColumnName("MODIFYUSERID");
            this.Property(x => x.ModifyUserName).HasColumnName("MODIFYUSERNAME");
            //主键
            this.HasKey(t => t.AddresseeId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
