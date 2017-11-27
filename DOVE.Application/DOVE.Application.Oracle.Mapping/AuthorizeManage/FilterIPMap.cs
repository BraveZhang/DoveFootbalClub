using DOVE.Application.Entity.AuthorizeManage;
using System.Data.Entity.ModelConfiguration;

namespace DOVE.Application.Oracle.Mapping.AuthorizeManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 鸽子队足球俱乐部
    /// 创建人：张勇
    /// 日 期：2015.11.20 13:32
    /// 描 述：过滤时段
    /// </summary>
    public class FilterIPMap : EntityTypeConfiguration<FilterIPEntity>
    {
        public FilterIPMap()
        {
            #region 表、主键
            //表
            this.ToTable("BASE_FILTERIP");
            //字段
            this.Property(x => x.FilterIPId).HasColumnName("FILTERIPID");
            this.Property(x => x.ObjectType).HasColumnName("OBJECTTYPE");
            this.Property(x => x.ObjectId).HasColumnName("OBJECTID");
            this.Property(x => x.VisitType).HasColumnName("VISITTYPE");
            this.Property(x => x.Type).HasColumnName("TYPE");
            this.Property(x => x.IPLimit).HasColumnName("IPLIMIT");
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
            this.HasKey(t => t.FilterIPId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
