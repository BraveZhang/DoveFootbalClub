using DOVE.Application.Entity.SystemManage;
using System.Data.Entity.ModelConfiguration;

namespace DOVE.Application.Oracle.Mapping.SystemManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 鸽子队足球俱乐部
    /// 创建人：张勇
    /// 日 期：2015.11.12 16:40
    /// 描 述：区域管理
    /// </summary>
    public class DataBaseLinkMap : EntityTypeConfiguration<DataBaseLinkEntity>
    {
        public DataBaseLinkMap()
        {
            #region 表、字段、主键
            //表
            this.ToTable("BASE_DATABASELINK");
            //字段
            this.Property(x => x.DatabaseLinkId).HasColumnName("DATABASELINKID");
            this.Property(x => x.ServerAddress).HasColumnName("SERVERADDRESS");
            this.Property(x => x.DBName).HasColumnName("DBNAME");
            this.Property(x => x.DBAlias).HasColumnName("DBALIAS");
            this.Property(x => x.DbType).HasColumnName("DBTYPE");
            this.Property(x => x.Version).HasColumnName("VERSION");
            this.Property(x => x.DbConnection).HasColumnName("DBCONNECTION");
            this.Property(x => x.DESEncrypt).HasColumnName("DESENCRYPT");
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
            this.HasKey(t => t.DatabaseLinkId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
