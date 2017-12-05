using DOVE.Application.Entity.PublicInfoManage;
using DOVE.Application.IService.PublicInfoManage;
using DOVE.Data;
using DOVE.Data.Repository;
using DOVE.Util;
using DOVE.Util.Extension;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace DOVE.Application.Service.PublicInfoManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 鸽子队足球俱乐部
    /// 创建人：张勇
    /// 日 期：2015.12.15 10:56
    /// 描 述：文件信息
    /// </summary>
    public class FileInfoService : RepositoryFactory<FileInfoEntity>, IFileInfoService
    {
        #region 获取数据
        /// <summary>
        /// 所有文件（夹）列表
        /// </summary>
        /// <param name="queryJson">postData</param>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public IEnumerable<FileInfoEntity> GetList(string queryJson, string userId)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"SELECT  *
                            FROM    ( SELECT    FolderId AS FileId ,
                                                ParentId AS FolderId ,
                                                FolderName AS FileName ,
                                                '' AS FileSize ,
                                                'folder' AS FileType ,
                                                CreateUserId,
                                                ModifyDate,
                                                CreateDate,
                                                IsShare 
                                      FROM      Base_FileFolder  where DeleteMark = 0
                                      UNION
                                      SELECT    FileId ,
                                                FolderId ,
                                                FileName ,
                                                FileSize ,
                                                FileType ,
                                                CreateUserId,
                                                ModifyDate,CreateDate,
                                                IsShare
                                      FROM      Base_FileInfo where DeleteMark = 0
                                    ) t WHERE CreateUserId = " + DbParameters.CreateDbParmCharacter() + "userId");
            var parameter = new List<DbParameter>();
            parameter.Add(DbParameters.CreateDbParameter(DbParameters.CreateDbParmCharacter() + "userId", userId));
            var queryParam = queryJson.ToJObject();
            //查询条件
            if (!queryParam["keyword"].IsEmpty())
            {
                strSql.Append(" AND FileName like " + DbParameters.CreateDbParmCharacter() + "fileName");
                parameter.Add(DbParameters.CreateDbParameter(DbParameters.CreateDbParmCharacter() + "fileName", '%' + queryParam["keyword"].ToString() + '%'));
            }
            if (!queryParam["folderId"].IsEmpty())
            {
                strSql.Append(" AND FolderId = " + DbParameters.CreateDbParmCharacter() + "folderId");
                parameter.Add(DbParameters.CreateDbParameter(DbParameters.CreateDbParmCharacter() + "folderId", queryParam["folderId"].ToString()));
            }
            else
            {
                strSql.Append(" AND FolderId = '0'");
            }
            //strSql.Append(" ORDER BY ModifyDate asc");
            strSql.Append(" ORDER BY CreateDate desc");
            return this.BaseRepository().FindList(strSql.ToString(), parameter.ToArray());
        }
        /// <summary>
        /// 文档列表
        /// </summary>
        /// <param name="queryJson">postData</param> 
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public IEnumerable<FileInfoEntity> GetDocumentList(string queryJson, string userId)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"SELECT  FileId ,
                                    FolderId ,
                                    FileName ,
                                    FileSize ,
                                    FileType ,
                                    CreateUserId ,
                                    ModifyDate,CreateDate,
                                    IsShare
                            FROM    Base_FileInfo
                            WHERE   DeleteMark = 0
                                    AND FileType IN ( 'log', 'txt', 'pdf', 'doc', 'docx', 'ppt', 'pptx',
                                                      'xls', 'xlsx' )
                                    AND CreateUserId = " + DbParameters.CreateDbParmCharacter() + "userId");
            var parameter = new List<DbParameter>();
            parameter.Add(DbParameters.CreateDbParameter(DbParameters.CreateDbParmCharacter() + "userId", userId));
            var queryParam = queryJson.ToJObject();
            //查询条件
            if (!queryParam["keyword"].IsEmpty())
            {
                strSql.Append(" AND FileName like " + DbParameters.CreateDbParmCharacter() + "fileName");
                parameter.Add(DbParameters.CreateDbParameter(DbParameters.CreateDbParmCharacter() + "fileName", '%' + queryParam["keyword"].ToString() + '%'));
            }
            //strSql.Append(" ORDER BY ModifyDate ASC");
            strSql.Append(" ORDER BY CreateDate DESC");
            return this.BaseRepository().FindList(strSql.ToString(), parameter.ToArray());
        }
        /// <summary>
        /// 图片列表
        /// </summary>
        /// <param name="queryJson">postData</param> 
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public IEnumerable<FileInfoEntity> GetImageList(string queryJson, string userId)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"SELECT  FileId ,
                                    FolderId ,
                                    FileName ,
                                    FileSize ,
                                    FileType ,
                                    CreateUserId ,
                                    ModifyDate,CreateDate,
                                    IsShare
                            FROM    Base_FileInfo
                            WHERE   DeleteMark = 0
                                    AND FileType IN ( 'ico', 'gif', 'jpeg', 'jpg', 'png', 'psd' )
                                    AND CreateUserId = " + DbParameters.CreateDbParmCharacter() + "userId");
            var parameter = new List<DbParameter>();
            parameter.Add(DbParameters.CreateDbParameter(DbParameters.CreateDbParmCharacter() + "userId", userId));
            var queryParam = queryJson.ToJObject();
            //查询条件
            if (!queryParam["keyword"].IsEmpty())
            {
                strSql.Append(" AND FileName like " + DbParameters.CreateDbParmCharacter() + "fileName");
                parameter.Add(DbParameters.CreateDbParameter(DbParameters.CreateDbParmCharacter() + "fileName", '%' + queryParam["keyword"].ToString() + '%'));
            }
            //strSql.Append(" ORDER BY ModifyDate ASC");
            strSql.Append(" ORDER BY CreateDate DESC");
            return this.BaseRepository().FindList(strSql.ToString(), parameter.ToArray());
        }
        /// <summary>
        /// 回收站文件（夹）列表
        /// </summary>
        /// <param name="queryJson">postData</param> 
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public IEnumerable<FileInfoEntity> GetRecycledList(string queryJson, string userId)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"SELECT  *
                            FROM    ( SELECT    FolderId AS FileId ,
                                                ParentId AS FolderId ,
                                                FolderName AS FileName ,
                                                '' AS FileSize ,
                                                'folder' AS FileType ,
                                                CreateUserId,CreateDate,
                                                ModifyDate
                                      FROM      Base_FileFolder  where DeleteMark = 1
                                      UNION
                                      SELECT    FileId ,
                                                FolderId ,
                                                FileName ,
                                                FileSize ,
                                                FileType ,
                                                CreateUserId,CreateDate,
                                                ModifyDate
                                      FROM      Base_FileInfo where DeleteMark = 1
                                    ) t WHERE CreateUserId = " + DbParameters.CreateDbParmCharacter() + "userId");
            var parameter = new List<DbParameter>();
            parameter.Add(DbParameters.CreateDbParameter(DbParameters.CreateDbParmCharacter() + "userId", userId));
            var queryParam = queryJson.ToJObject();
            //查询条件
            if (!queryParam["keyword"].IsEmpty())
            {
                strSql.Append(" AND FileName like " + DbParameters.CreateDbParmCharacter() + "fileName");
                parameter.Add(DbParameters.CreateDbParameter(DbParameters.CreateDbParmCharacter() + "fileName", '%' + queryParam["keyword"].ToString() + '%'));
            }
            strSql.Append(" ORDER BY CreateDate DESC");
            return this.BaseRepository().FindList(strSql.ToString(), parameter.ToArray());
        }
        /// <summary>
        /// 我的文件（夹）共享列表
        /// </summary>
        /// <param name="queryJson">postData</param> 
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public IEnumerable<FileInfoEntity> GetMyShareList(string queryJson, string userId)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"SELECT  *
                            FROM    ( SELECT    FolderId AS FileId ,
                                                ParentId AS FolderId ,
                                                FolderName AS FileName ,
                                                '' AS FileSize ,
                                                'folder' AS FileType ,
                                                CreateUserId,CreateDate,
                                                ModifyDate
                                      FROM      Base_FileFolder  WHERE DeleteMark = 0 AND IsShare = 1
                                      UNION
                                      SELECT    FileId ,
                                                FolderId ,
                                                FileName ,
                                                FileSize ,
                                                FileType ,
                                                CreateUserId,CreateDate,
                                                ModifyDate
                                      FROM      Base_FileInfo WHERE DeleteMark = 0 AND IsShare = 1
                                    ) t WHERE CreateUserId = " + DbParameters.CreateDbParmCharacter() + "userId");
            var parameter = new List<DbParameter>();
            parameter.Add(DbParameters.CreateDbParameter(DbParameters.CreateDbParmCharacter() + "userId", userId));
            var queryParam = queryJson.ToJObject();
            //查询条件
            if (!queryParam["keyword"].IsEmpty())
            {
                strSql.Append(" AND FileName like " + DbParameters.CreateDbParmCharacter() + "fileName");
                parameter.Add(DbParameters.CreateDbParameter(DbParameters.CreateDbParmCharacter() + "fileName", '%' + queryParam["keyword"].ToString() + '%'));
            }
            strSql.Append(" ORDER BY CreateDate DESC");
            return this.BaseRepository().FindList(strSql.ToString(), parameter.ToArray());
        }
        /// <summary>
        /// 他人文件（夹）共享列表
        /// </summary>
        /// <param name="queryJson">postData</param> 
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public IEnumerable<FileInfoEntity> GetOthersShareList(string queryJson, string userId)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"SELECT  *
                            FROM    ( SELECT    FolderId AS FileId ,
                                                ParentId AS FolderId ,
                                                FolderName AS FileName ,
                                                '' AS FileSize ,
                                                'folder' AS FileType ,
                                                CreateUserId,
                                                CreateUserName,CreateDate,
                                                ShareTime AS ModifyDate
                                      FROM      Base_FileFolder  WHERE DeleteMark = 0 AND IsShare = 1
                                      UNION
                                      SELECT    FileId ,
                                                FolderId ,
                                                FileName ,
                                                FileSize ,
                                                FileType ,
                                                CreateUserId,
                                                CreateUserName,CreateDate,
                                                ShareTime AS ModifyDate
                                      FROM      Base_FileInfo WHERE DeleteMark = 0 AND IsShare = 1
                                    ) t WHERE CreateUserId != " + DbParameters.CreateDbParmCharacter() + "userId");
            var parameter = new List<DbParameter>();
            parameter.Add(DbParameters.CreateDbParameter(DbParameters.CreateDbParmCharacter() + "userId", userId));
            var queryParam = queryJson.ToJObject();
            //查询条件
            if (!queryParam["keyword"].IsEmpty())
            {
                strSql.Append(" AND FileName like " + DbParameters.CreateDbParmCharacter() + "fileName");
                parameter.Add(DbParameters.CreateDbParameter(DbParameters.CreateDbParmCharacter() + "fileName", '%' + queryParam["keyword"].ToString() + '%'));
            }
            strSql.Append(" ORDER BY CreateDate DESC");
            return this.BaseRepository().FindList(strSql.ToString(), parameter.ToArray());
        }
        /// <summary>
        /// 文件实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public FileInfoEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity(keyValue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 还原文件
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RestoreFile(string keyValue)
        {
            FileInfoEntity fileInfoEntity = new FileInfoEntity();
            fileInfoEntity.Modify(keyValue);
            fileInfoEntity.DeleteMark = 0;
            this.BaseRepository().Update(fileInfoEntity);
        }
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            FileInfoEntity fileInfoEntity = new FileInfoEntity();
            fileInfoEntity.Modify(keyValue);
            fileInfoEntity.DeleteMark = 1;
            this.BaseRepository().Update(fileInfoEntity);
        }
        /// <summary>
        /// 彻底删除文件
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void ThoroughRemoveForm(string keyValue)
        {
            this.BaseRepository().Delete(keyValue);
        }
        /// <summary>
        /// 保存文件表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="fileInfoEntity">文件信息实体</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, FileInfoEntity fileInfoEntity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                fileInfoEntity.Modify(keyValue);
                this.BaseRepository().Update(fileInfoEntity);
            }
            else
            {
                fileInfoEntity.Create();
                this.BaseRepository().Insert(fileInfoEntity);
            }
        }
        /// <summary>
        /// 共享文件
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="IsShare">是否共享：1-共享 0取消共享</param>
        public void ShareFile(string keyValue, int IsShare)
        {
            FileInfoEntity fileInfoEntity = new FileInfoEntity();
            fileInfoEntity.FileId = keyValue;
            fileInfoEntity.IsShare = IsShare;
            fileInfoEntity.ShareTime = DateTime.Now;
            this.BaseRepository().Update(fileInfoEntity);
        }
        #endregion
    }
}
