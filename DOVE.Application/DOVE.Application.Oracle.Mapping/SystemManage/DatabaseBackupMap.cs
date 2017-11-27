using DOVE.Application.Entity.SystemManage;
using System.Data.Entity.ModelConfiguration;

namespace DOVE.Application.Oracle.Mapping.SystemManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 鸽子队足球俱乐部
    /// 创建人：张勇
    /// 日 期：2015.11.25 11:02
    /// 描 述：数据库备份
    /// </summary>
    public class DataBaseBackupMap : EntityTypeConfiguration<DataBaseBackupEntity>
    {
        public DataBaseBackupMap()
        {
            #region 表、字段、主键
            //表
            this.ToTable("BASE_DATABASEBACKUP");
            //字段
            this.Property(x => x.DatabaseBackupId).HasColumnName("DATABASEBACKUPID");
            this.Property(x => x.DatabaseLinkId).HasColumnName("DATABASELINKID");
            this.Property(x => x.ParentId).HasColumnName("PARENTID");
            this.Property(x => x.EnCode).HasColumnName("ENCODE");
            this.Property(x => x.FullName).HasColumnName("FULLNAME");
            this.Property(x => x.ExecuteMode).HasColumnName("EXECUTEMODE");
            this.Property(x => x.ExecuteTime).HasColumnName("EXECUTETIME");
            this.Property(x => x.BackupPath).HasColumnName("BACKUPPATH");
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
            this.HasKey(t => t.DatabaseBackupId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
