using DOVE.Application.Entity.BaseManage;
using System.Data.Entity.ModelConfiguration;

namespace DOVE.Application.Oracle.Mapping.BaseManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 鸽子队足球俱乐部
    /// 创建人：张勇
    /// 日 期：2015.11.02 14:27
    /// 描 述：部门管理
    /// </summary>
    public class DepartmentMap : EntityTypeConfiguration<DepartmentEntity>
    {
        public DepartmentMap()
        {
            #region 表、字段、主键
            //表
            this.ToTable("BASE_DEPARTMENT");
            //字段
            this.Property(x => x.DepartmentId).HasColumnName("DEPARTMENTID");
            this.Property(x => x.OrganizeId).HasColumnName("ORGANIZEID");
            this.Property(x => x.ParentId).HasColumnName("PARENTID");
            this.Property(x => x.EnCode).HasColumnName("ENCODE");
            this.Property(x => x.FullName).HasColumnName("FULLNAME");
            this.Property(x => x.ShortName).HasColumnName("SHORTNAME");
            this.Property(x => x.Nature).HasColumnName("NATURE");
            this.Property(x => x.ManagerId).HasColumnName("MANAGERID");
            this.Property(x => x.Manager).HasColumnName("MANAGER");
            this.Property(x => x.OuterPhone).HasColumnName("OUTERPHONE");
            this.Property(x => x.InnerPhone).HasColumnName("INNERPHONE");
            this.Property(x => x.Email).HasColumnName("EMAIL");
            this.Property(x => x.Fax).HasColumnName("FAX");
            this.Property(x => x.Layer).HasColumnName("LAYER");
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
            this.HasKey(t => t.DepartmentId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
