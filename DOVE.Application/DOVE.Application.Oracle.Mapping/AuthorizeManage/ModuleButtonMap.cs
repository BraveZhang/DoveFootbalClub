using DOVE.Application.Entity.AuthorizeManage;
using System.Data.Entity.ModelConfiguration;

namespace DOVE.Application.Oracle.Mapping.AuthorizeManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 鸽子队足球俱乐部
    /// 创建人：张勇
    /// 日 期：2015.08.01 14:00
    /// 描 述：系统按钮
    /// </summary>
    public class ModuleButtonMap : EntityTypeConfiguration<ModuleButtonEntity>
    {
        public ModuleButtonMap()
        {
            #region 表、字段、主键
            //表
            this.ToTable("BASE_MODULEBUTTON");
            //字段
            this.Property(x => x.ModuleButtonId).HasColumnName("MODULEBUTTONID");
            this.Property(x => x.ModuleId).HasColumnName("MODULEID");
            this.Property(x => x.ParentId).HasColumnName("PARENTID");
            this.Property(x => x.Icon).HasColumnName("ICON");
            this.Property(x => x.EnCode).HasColumnName("ENCODE");
            this.Property(x => x.FullName).HasColumnName("FULLNAME");
            this.Property(x => x.ActionAddress).HasColumnName("ACTIONADDRESS");
            this.Property(x => x.SortCode).HasColumnName("SORTCODE");
            //主键
            this.HasKey(t => t.ModuleButtonId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
