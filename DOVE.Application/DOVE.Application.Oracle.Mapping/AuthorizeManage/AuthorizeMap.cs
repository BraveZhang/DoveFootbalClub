using DOVE.Application.Entity.AuthorizeManage;
using System.Data.Entity.ModelConfiguration;

namespace DOVE.Application.Oracle.Mapping.AuthorizeManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 鸽子队足球俱乐部
    /// 创建人：张勇
    /// 日 期：2015.11.27
    /// 描 述：授权功能
    /// </summary>
    public class AuthorizeMap : EntityTypeConfiguration<AuthorizeEntity>
    {
        public AuthorizeMap()
        {
            #region 表、字段、主键
            //表
            this.ToTable("BASE_AUTHORIZE");
            //字段
            this.Property(x => x.AuthorizeId).HasColumnName("AUTHORIZEID");
            this.Property(x => x.Category).HasColumnName("CATEGORY");
            this.Property(x => x.ObjectId).HasColumnName("OBJECTID");
            this.Property(x => x.ItemType).HasColumnName("ITEMTYPE");
            this.Property(x => x.ItemId).HasColumnName("ITEMID");
            this.Property(x => x.SortCode).HasColumnName("SORTCODE");
            this.Property(x => x.CreateDate).HasColumnName("CREATEDATE");
            this.Property(x => x.CreateUserId).HasColumnName("CREATEUSERID");
            this.Property(x => x.CreateUserName).HasColumnName("CREATEUSERNAME");
            //主键
            this.HasKey(t => t.AuthorizeId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
