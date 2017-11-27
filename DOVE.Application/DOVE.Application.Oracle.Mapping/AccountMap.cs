using DOVE.Application.Entity;
using System.Data.Entity.ModelConfiguration;

namespace DOVE.Application.Oracle.Mapping
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 鸽子队足球俱乐部
    /// 创建人：张勇
    /// 日 期：2016.05.11 16:23
    /// 描 述：注册账户
    /// </summary>
    public class AccountMap : EntityTypeConfiguration<AccountEntity>
    {
        public AccountMap()
        {
            #region 表、字段、主键
            // 表
            this.ToTable("ACCOUNT");
            //字段
            this.Property(x => x.AccountId).HasColumnName("ACCOUNTID");
            this.Property(x => x.MobileCode).HasColumnName("MOBILECODE");
            this.Property(x => x.SecurityCode).HasColumnName("SECURITYCODE");
            this.Property(x => x.Password).HasColumnName("PASSWORD");
            this.Property(x => x.CompanyName).HasColumnName("COMPANYNAME");
            this.Property(x => x.FullName).HasColumnName("FULLNAME");
            this.Property(x => x.RegisterTime).HasColumnName("REGISTERTIME");
            this.Property(x => x.ExpireTime).HasColumnName("EXPIRETIME");
            this.Property(x => x.IPAddress).HasColumnName("IPADDRESS");
            this.Property(x => x.IPAddressName).HasColumnName("IPADDRESSNAME");
            this.Property(x => x.DeleteMark).HasColumnName("DELETEMARK");
            this.Property(x => x.EnabledMark).HasColumnName("ENABLEDMARK");
            this.Property(x => x.Description).HasColumnName("DESCRIPTION");
            this.Property(x => x.CreateDate).HasColumnName("CREATEDATE");
            this.Property(x => x.LastVisit).HasColumnName("LASTVISIT");
            this.Property(x => x.LogOnCount).HasColumnName("LOGONCOUNT");
            this.Property(x => x.AmountCount).HasColumnName("AMOUNTCOUNT");
            // 主键
            this.HasKey(t => t.AccountId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
