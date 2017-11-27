using DOVE.Application.Entity.WeChatManage;
using System.Data.Entity.ModelConfiguration;

namespace DOVE.Application.Oracle.Mapping.WeChatManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 鸽子队足球俱乐部
    /// 创建人：张勇
    /// 日 期：2015.12.23 11:31
    /// 描 述：企业号应用
    /// </summary>
    public class WeChatAppMap : EntityTypeConfiguration<WeChatAppEntity>
    {
        public WeChatAppMap()
        {
            #region 表、字段、主键
            //表
            this.ToTable("WECHAT_APP");
            //字段
            this.Property(x => x.AppId).HasColumnName("APPID");
            this.Property(x => x.AppLogo).HasColumnName("APPLOGO");
            this.Property(x => x.AppName).HasColumnName("APPNAME");
            this.Property(x => x.AppType).HasColumnName("APPTYPE");
            this.Property(x => x.Description).HasColumnName("DESCRIPTION");
            this.Property(x => x.AppUrl).HasColumnName("APPURL");
            this.Property(x => x.RedirectDomain).HasColumnName("REDIRECTDOMAIN");
            this.Property(x => x.MenuJson).HasColumnName("MENUJSON");
            this.Property(x => x.IsReportUser).HasColumnName("ISREPORTUSER");
            this.Property(x => x.IsReportenter).HasColumnName("ISREPORTENTER");
            this.Property(x => x.DeleteMark).HasColumnName("DELETEMARK");
            this.Property(x => x.EnabledMark).HasColumnName("ENABLEDMARK");
            this.Property(x => x.CreateDate).HasColumnName("CREATEDATE");
            this.Property(x => x.CreateUserId).HasColumnName("CREATEUSERID");
            this.Property(x => x.CreateUserName).HasColumnName("CREATEUSERNAME");
            this.Property(x => x.ModifyDate).HasColumnName("MODIFYDATE");
            this.Property(x => x.ModifyUserId).HasColumnName("MODIFYUSERID");
            this.Property(x => x.ModifyUserName).HasColumnName("MODIFYUSERNAME");
            //主键
            this.HasKey(t => t.AppId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
