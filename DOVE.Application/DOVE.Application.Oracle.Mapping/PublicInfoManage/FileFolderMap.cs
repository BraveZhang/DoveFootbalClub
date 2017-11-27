﻿using DOVE.Application.Entity.PublicInfoManage;
using System.Data.Entity.ModelConfiguration;

namespace DOVE.Application.Oracle.Mapping.PublicInfoManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 鸽子队足球俱乐部
    /// 创建人：张勇
    /// 日 期：2015.12.15 10:56
    /// 描 述：文件夹
    /// </summary>
    public class FileFolderMap : EntityTypeConfiguration<FileFolderEntity>
    {
        public FileFolderMap()
        {
            #region 表、字段、主键
            //表
            this.ToTable("BASE_FILEFOLDER");
            //字段
            this.Property(x => x.FolderId).HasColumnName("FOLDERID");
            this.Property(x => x.ParentId).HasColumnName("PARENTID");
            this.Property(x => x.FolderType).HasColumnName("FOLDERTYPE");
            this.Property(x => x.FolderName).HasColumnName("FOLDERNAME");
            this.Property(x => x.IsShare).HasColumnName("ISSHARE");
            this.Property(x => x.ShareLink).HasColumnName("SHARELINK");
            this.Property(x => x.ShareCode).HasColumnName("SHARECODE");
            this.Property(x => x.ShareTime).HasColumnName("SHARETIME");
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
            this.HasKey(t => t.FolderId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
