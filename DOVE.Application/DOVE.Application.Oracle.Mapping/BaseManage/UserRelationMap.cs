using DOVE.Application.Entity.BaseManage;
using System.Data.Entity.ModelConfiguration;

namespace DOVE.Application.Oracle.Mapping.BaseManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 鸽子队足球俱乐部
    /// 创建人：张勇
    /// 日 期：2015.11.03 10:58
    /// 描 述：用户关系
    /// </summary>
    public class UserRelationMap : EntityTypeConfiguration<UserRelationEntity>
    {
        public UserRelationMap()
        {
            #region 表、字段、主键
            //表
            this.ToTable("BASE_USERRELATION");
            //字段
            this.Property(x => x.UserRelationId).HasColumnName("USERRELATIONID");
            this.Property(x => x.UserId).HasColumnName("USERID");
            this.Property(x => x.Category).HasColumnName("CATEGORY");
            this.Property(x => x.ObjectId).HasColumnName("OBJECTID");
            this.Property(x => x.IsDefault).HasColumnName("ISDEFAULT");
            this.Property(x => x.SortCode).HasColumnName("SORTCODE");
            this.Property(x => x.CreateDate).HasColumnName("CREATEDATE");
            this.Property(x => x.CreateUserId).HasColumnName("CREATEUSERID");
            this.Property(x => x.CreateUserName).HasColumnName("CREATEUSERNAME");
            //主键
            this.HasKey(t => t.UserRelationId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
