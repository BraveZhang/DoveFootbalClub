using DOVE.Application.Entity.AuthorizeManage;
using System.Data.Entity.ModelConfiguration;

namespace DOVE.Application.Oracle.Mapping.AuthorizeManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 鸽子队足球俱乐部
    /// 创建人：张勇
    /// 日 期：2015.10.27 09:16
    /// 描 述：系统功能
    /// </summary>
    public class ModuleMap : EntityTypeConfiguration<ModuleEntity>
    {
        public ModuleMap()
        {
            #region 表、字段、主键
            //表
            this.ToTable("BASE_MODULE");
            //字段
            this.Property(x => x.ModuleId).HasColumnName("MODULEID");
            this.Property(x => x.ParentId).HasColumnName("PARENTID");
            this.Property(x => x.EnCode).HasColumnName("ENCODE");
            this.Property(x => x.FullName).HasColumnName("FULLNAME");
            this.Property(x => x.Icon).HasColumnName("ICON");
            this.Property(x => x.UrlAddress).HasColumnName("URLADDRESS");
            this.Property(x => x.Target).HasColumnName("TARGET");
            this.Property(x => x.IsMenu).HasColumnName("ISMENU");
            this.Property(x => x.AllowExpand).HasColumnName("ALLOWEXPAND");
            this.Property(x => x.IsPublic).HasColumnName("ISPUBLIC");
            this.Property(x => x.AllowEdit).HasColumnName("ALLOWEDIT");
            this.Property(x => x.AllowDelete).HasColumnName("ALLOWDELETE");
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
            //主键
            this.HasKey(t => t.ModuleId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
