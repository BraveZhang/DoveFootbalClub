using DOVE.Application.Entity.AuthorizeManage;
using System.Data.Entity.ModelConfiguration;

namespace DOVE.Application.Oracle.Mapping.AuthorizeManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 鸽子队足球俱乐部
    /// 创建人：张勇
    /// 日 期：2015.10.29 15:13
    /// 描 述：系统视图
    /// </summary>
    public class ModuleColumnMap : EntityTypeConfiguration<ModuleColumnEntity>
    {
        public ModuleColumnMap()
        {
            #region 表、字段、主键
            //表
            this.ToTable("BASE_MODULECOLUMN");
            //字段
            this.Property(x => x.ModuleColumnId).HasColumnName("MODULECOLUMNID");
            this.Property(x => x.ModuleId).HasColumnName("MODULEID");
            this.Property(x => x.ParentId).HasColumnName("PARENTID");
            this.Property(x => x.EnCode).HasColumnName("ENCODE");
            this.Property(x => x.FullName).HasColumnName("FULLNAME");
            this.Property(x => x.SortCode).HasColumnName("SORTCODE");
            this.Property(x => x.Description).HasColumnName("DESCRIPTION");
            //主键
            this.HasKey(t => t.ModuleColumnId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
