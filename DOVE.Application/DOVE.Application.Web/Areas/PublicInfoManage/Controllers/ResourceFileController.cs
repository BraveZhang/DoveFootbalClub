﻿using DOVE.Application.Busines.BaseManage;
using DOVE.Application.Busines.DoveManage;
using DOVE.Application.Busines.PublicInfoManage;
using DOVE.Application.Code;
using DOVE.Application.Entity.DoveManage;
using DOVE.Application.Entity.PublicInfoManage;
using DOVE.Util;
using DOVE.Util.Offices;
using DOVE.Util.WebControl;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace DOVE.Application.Web.Areas.PublicInfoManage.Controllers
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 鸽子队足球俱乐部
    /// 创建人：张勇
    /// 日 期：2015.12.15 10:56
    /// 描 述：文件管理
    /// </summary>
    public class ResourceFileController : MvcControllerBase
    {
        private FileFolderBLL fileFolderBLL = new FileFolderBLL();
        private FileInfoBLL fileInfoBLL = new FileInfoBLL();
        private T_ActivityBLL t_activityBLL = new T_ActivityBLL();
        private T_Activity_DetailBLL t_activity_detailBLL = new T_Activity_DetailBLL();
        private UserBLL userBLL = new UserBLL();
        #region 视图功能
        /// <summary>
        /// 文件管理
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult UploadifyForm()
        {
            return View();
        }
        /// <summary>
        /// 上传文件(Plupload)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult UploadifyNewForm()
        {
            return View();
        }
        /// <summary>
        /// 上传文件(活动页面上传)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult UploadifyActivityForm()
        {
            return View();
        }
        /// <summary>
        /// 文件夹表单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult FolderForm()
        {
            return View();
        }
        /// <summary>
        /// 文件表单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult FileForm()
        {
            return View();
        }
        /// <summary>
        /// 文件（夹）移动表单  
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult MoveForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        /// <summary>
        /// 文件夹列表 
        /// </summary>
        /// <returns>返回树形Json</returns>
        [HttpGet]
        public ActionResult GetTreeJson()
        {
            string userId = OperatorProvider.Provider.Current().UserId;
            var data = fileFolderBLL.GetList(userId);
            var treeList = new List<TreeEntity>();
            foreach (FileFolderEntity item in data)
            {
                TreeEntity tree = new TreeEntity();
                bool hasChildren = data.Count(t => t.ParentId == item.FolderId) == 0 ? false : true;
                tree.id = item.FolderId;
                tree.text = item.FolderName;
                tree.value = item.FolderId;
                tree.parentId = item.ParentId;
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = hasChildren;
                if (hasChildren == false)
                {
                    tree.img = "fa fa-folder";
                }
                treeList.Add(tree);
            }
            return Content(treeList.TreeToJson());
        }
        /// <summary>
        /// 所有文件（夹）列表
        /// </summary>
        /// <param name="queryJson">参数</param>
        /// <returns>返回列表Json</returns>
        [HttpGet]
        public ActionResult GetListJson(string queryJson)
        {
            string userId = OperatorProvider.Provider.Current().UserId;
            var data = fileInfoBLL.GetList(queryJson, userId);
            return ToJsonResult(data);
        }
        /// <summary>
        /// 文档列表
        /// </summary>
        /// <returns>返回列表Json</returns>
        [HttpGet]
        public ActionResult GetDocumentListJson(string queryJson)
        {
            string userId = OperatorProvider.Provider.Current().UserId;
            var data = fileInfoBLL.GetDocumentList(queryJson, userId);
            return ToJsonResult(data);
        }
        /// <summary>
        /// 图片列表
        /// </summary>
        /// <returns>返回列表Json</returns>
        [HttpGet]
        public ActionResult GetImageListJson(string queryJson)
        {
            string userId = OperatorProvider.Provider.Current().UserId;
            var data = fileInfoBLL.GetImageList(queryJson, userId);
            return ToJsonResult(data);
        }
        /// <summary>
        /// 回收站文件（夹）列表
        /// </summary>
        /// <returns>返回列表Json</returns>
        [HttpGet]
        public ActionResult GetRecycledListJson(string queryJson)
        {
            string userId = OperatorProvider.Provider.Current().UserId;
            var data = fileInfoBLL.GetRecycledList(queryJson, userId);
            return ToJsonResult(data);
        }
        /// <summary>
        /// 我的文件（夹）共享列表
        /// </summary>
        /// <returns>返回列表Json</returns>
        [HttpGet]
        public ActionResult GetMyShareListJson(string queryJson)
        {
            string userId = OperatorProvider.Provider.Current().UserId;
            var data = fileInfoBLL.GetMyShareList(queryJson, userId);
            return ToJsonResult(data);
        }
        /// <summary>
        /// 他人文件（夹）共享列表
        /// </summary>
        /// <returns>返回列表Json</returns>
        [HttpGet]
        public ActionResult GetOthersShareListJson(string queryJson)
        {
            string userId = OperatorProvider.Provider.Current().UserId;
            var data = fileInfoBLL.GetOthersShareList(queryJson, userId);
            return ToJsonResult(data);
        }
        /// <summary>
        /// 文件夹实体 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public ActionResult GetFolderFormJson(string keyValue)
        {
            var data = fileFolderBLL.GetEntity(keyValue);
            return ToJsonResult(data);
        }
        /// <summary>
        /// 文件实体 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public ActionResult GetFileFormJson(string keyValue)
        {
            var data = fileInfoBLL.GetEntity(keyValue);
            return ToJsonResult(data);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 还原文件（夹）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="fileType">文件类型</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult RestoreFile(string keyValue, string fileType)
        {
            if (fileType == "folder")
            {
                fileFolderBLL.RestoreFile(keyValue);
            }
            else
            {
                fileInfoBLL.RestoreFile(keyValue);
            }
            return Success("还原成功。");
        }
        /// <summary>
        /// 删除文件（夹）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="fileType">文件类型</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult RemoveForm(string keyValue, string fileType)
        {
            if (fileType == "folder")
            {
                fileFolderBLL.RemoveForm(keyValue);
            }
            else
            {
                fileInfoBLL.RemoveForm(keyValue);
            }
            return Success("删除成功。");
        }
        /// <summary>
        /// 彻底删除文件（夹）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="fileType">文件类型</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult ThoroughRemoveForm(string keyValue, string fileType)
        {
            if (fileType == "folder")
            {
                fileFolderBLL.ThoroughRemoveForm(keyValue);
            }
            else
            {
                fileInfoBLL.ThoroughRemoveForm(keyValue);
            }
            return Success("删除成功。");
        }

        /// <summary>
        /// 保存文件夹表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="fileFolderEntity">文件夹实体</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveFolderForm(string keyValue, FileFolderEntity fileFolderEntity)
        {
            fileFolderBLL.SaveForm(keyValue, fileFolderEntity);
            return Success("操作成功。");
        }
        /// <summary>
        /// 保存文件表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="fileInfoEntity">文件实体</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveFileForm(string keyValue, FileInfoEntity fileInfoEntity)
        {
            fileInfoBLL.SaveForm(keyValue, fileInfoEntity);
            return Success("操作成功。");
        }
        /// <summary>
        /// 保存文件（夹）移动位置
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="moveFolderId">要移动文件夹Id</param>
        /// <param name="FileType">文件类型</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveMoveForm(string keyValue, string moveFolderId, string fileType)
        {
            if (fileType == "folder")
            {
                FileFolderEntity fileFolderEntity = new FileFolderEntity();
                fileFolderEntity.FolderId = keyValue;
                fileFolderEntity.ParentId = moveFolderId;
                fileFolderBLL.SaveForm(keyValue, fileFolderEntity);
            }
            else
            {
                FileInfoEntity fileInfoEntity = new FileInfoEntity();
                fileInfoEntity.FileId = keyValue;
                fileInfoEntity.FolderId = moveFolderId;
                fileInfoBLL.SaveForm(keyValue, fileInfoEntity);
            }
            return Success("操作成功。");
        }
        /// <summary>
        /// 共享文件（夹）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="fileType">文件类型</param>
        /// <param name="IsShare">是否共享：1-共享 0取消共享</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult ShareFile(string keyValue, int IsShare, string fileType)
        {
            if (fileType == "folder")
            {
                fileFolderBLL.ShareFolder(keyValue, IsShare);
            }
            else
            {
                fileInfoBLL.ShareFile(keyValue, IsShare);
            }
            return Success("共享成功。");
        }
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="folderId">文件夹Id</param>
        /// <param name="userId">用户Id</param>
        /// <param name="Filedata">文件对象</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UploadifyFile(string folderId, HttpPostedFileBase Filedata)
        {
            try
            {
                Thread.Sleep(500);////延迟500毫秒
                //没有文件上传，直接返回
                if (Filedata == null || string.IsNullOrEmpty(Filedata.FileName) || Filedata.ContentLength == 0)
                {
                    return HttpNotFound();
                }
                //获取文件完整文件名(包含绝对路径)
                //文件存放路径格式：/Resource/ResourceFile/{userId}{data}/{guid}.{后缀名}
                string userId = OperatorProvider.Provider.Current().UserId;
                string fileGuid = Guid.NewGuid().ToString();
                long filesize = Filedata.ContentLength;
                string FileEextension = Path.GetExtension(Filedata.FileName);
                string uploadDate = DateTime.Now.ToString("yyyyMMdd");
                string virtualPath = string.Format("~/Resource/DocumentFile/{0}/{1}/{2}{3}", userId, uploadDate, fileGuid, FileEextension);
                string fullFileName = this.Server.MapPath(virtualPath);
                //创建文件夹
                string path = Path.GetDirectoryName(fullFileName);
                Directory.CreateDirectory(path);
                if (!System.IO.File.Exists(fullFileName))
                {
                    //保存文件
                    Filedata.SaveAs(fullFileName);
                    //文件信息写入数据库
                    FileInfoEntity fileInfoEntity = new FileInfoEntity();
                    fileInfoEntity.Create();
                    fileInfoEntity.FileId = fileGuid;
                    if (!string.IsNullOrEmpty(folderId))
                    {
                        fileInfoEntity.FolderId = folderId;
                    }
                    else
                    {
                        fileInfoEntity.FolderId = "0";
                    }
                    fileInfoEntity.FileName = Filedata.FileName;
                    fileInfoEntity.FilePath = virtualPath;
                    fileInfoEntity.FileSize = filesize.ToString();
                    fileInfoEntity.FileExtensions = FileEextension;
                    fileInfoEntity.FileType = FileEextension.Replace(".", "");
                    fileInfoBLL.SaveForm("", fileInfoEntity);
                }
                return Success("上传成功。");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="KeyValue">主键</param>
        /// <returns></returns>
        [HttpPost]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public void DownloadFile(string keyValue)
        {
            var data = fileInfoBLL.GetEntity(keyValue);
            string filename = Server.UrlDecode(data.FileName);//返回客户端文件名称
            string filepath = this.Server.MapPath(data.FilePath);
            if (FileDownHelper.FileExists(filepath))
            {
                FileDownHelper.DownLoadold(filepath, filename);
            }
        }

        /// <summary>
        /// Plupload测试文件上传
        /// </summary>
        /// <returns></returns>
        public ActionResult Upload(string folderId)
        {
            try
            {
                Thread.Sleep(500);//延迟500毫秒
                //没有文件上传，直接返回
                if (Request.Files.Count == 0)
                {
                    return HttpNotFound();
                }
                //获取文件完整文件名(包含绝对路径)
                //文件存放路径格式：/Resource/ResourceFile/{userId}{data}/{guid}.{后缀名}
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];
                    //file.SaveAs(AppDomain.CurrentDomain.BaseDirectory + "Uploads/" + file.FileName);
                    string userId = OperatorProvider.Provider.Current().UserId;
                    string fileGuid = Guid.NewGuid().ToString();
                    long filesize = file.ContentLength;
                    string FileEextension = Path.GetExtension(file.FileName);
                    string uploadDate = DateTime.Now.ToString("yyyyMMdd");
                    string virtualPath = string.Format("~/Resource/DocumentFile/{0}/{1}/{2}{3}", userId, uploadDate, fileGuid, FileEextension);
                    string fullFileName = this.Server.MapPath(virtualPath);
                    //创建文件夹
                    string path = Path.GetDirectoryName(fullFileName);
                    Directory.CreateDirectory(path);
                    if (!System.IO.File.Exists(fullFileName))
                    {
                        //保存文件
                        file.SaveAs(fullFileName);
                        //文件信息写入数据库
                        FileInfoEntity fileInfoEntity = new FileInfoEntity();
                        fileInfoEntity.Create();
                        fileInfoEntity.FileId = fileGuid;
                        if (!string.IsNullOrEmpty(folderId))
                        {
                            fileInfoEntity.FolderId = folderId;
                        }
                        else
                        {
                            fileInfoEntity.FolderId = "0";
                        }
                        fileInfoEntity.FileName = file.FileName;
                        fileInfoEntity.FilePath = virtualPath;
                        fileInfoEntity.FileSize = filesize.ToString();
                        fileInfoEntity.FileExtensions = FileEextension;
                        fileInfoEntity.FileType = FileEextension.Replace(".", "");
                        fileInfoBLL.SaveForm("", fileInfoEntity);
                    }
                }
                return Success("上传成功。");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        /// <summary>
        /// 活动页面-多活动上传
        /// </summary>
        /// <returns></returns>
        public ActionResult ActivitiesUpload(string folderId)
        {
            try
            {
                Thread.Sleep(500);//延迟500毫秒
                //没有文件上传，直接返回
                if (Request.Files.Count == 0)
                {
                    return HttpNotFound();
                }
                //获取文件完整文件名(包含绝对路径)
                //文件存放路径格式：/Resource/ResourceFile/{userId}{data}/{guid}.{后缀名}
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    #region 文件保存
                    var file = Request.Files[i];
                    string userId = OperatorProvider.Provider.Current().UserId;
                    string fileGuid = Guid.NewGuid().ToString();
                    long filesize = file.ContentLength;
                    string FileEextension = Path.GetExtension(file.FileName);
                    string uploadDate = DateTime.Now.ToString("yyyyMMdd");
                    string virtualPath = string.Format("~/Resource/DocumentFile/{0}/{1}/{2}{3}", userId, uploadDate, fileGuid, FileEextension);
                    string fullFileName = this.Server.MapPath(virtualPath);
                    //创建文件夹
                    string path = Path.GetDirectoryName(fullFileName);
                    Directory.CreateDirectory(path);
                    if (!System.IO.File.Exists(fullFileName))
                    {
                        //保存文件
                        file.SaveAs(fullFileName);
                        //文件信息写入数据库
                        FileInfoEntity fileInfoEntity = new FileInfoEntity();
                        fileInfoEntity.Create();
                        fileInfoEntity.FileId = fileGuid;
                        if (!string.IsNullOrEmpty(folderId))
                        {
                            fileInfoEntity.FolderId = folderId;
                        }
                        else
                        {
                            fileInfoEntity.FolderId = "0";
                        }
                        fileInfoEntity.FileName = file.FileName;
                        fileInfoEntity.FilePath = virtualPath;
                        fileInfoEntity.FileSize = filesize.ToString();
                        fileInfoEntity.FileExtensions = FileEextension;
                        fileInfoEntity.FileType = FileEextension.Replace(".", "");
                        fileInfoBLL.SaveForm("", fileInfoEntity);
                    }
                    #endregion

                    #region 读取活动模板文件
                    DataTable dtActivities = ExcelHelper.ExcelImport(fullFileName);
                    #endregion

                    t_activityBLL.ActivitiesSaveForm(dtActivities);
                }
                return Success("上传成功。");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        /// <summary>
        /// 活动页面-小立报名Excel上传
        /// </summary>
        /// <returns></returns>
        public ActionResult XiaoLiUpload(string folderId)
        {
            try
            {
                Thread.Sleep(500);//延迟500毫秒
                //没有文件上传，直接返回
                if (Request.Files.Count == 0)
                {
                    return HttpNotFound();
                }
                //获取文件完整文件名(包含绝对路径)
                //文件存放路径格式：/Resource/ResourceFile/{userId}{data}/{guid}.{后缀名}
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    #region 文件保存
                    var file = Request.Files[i];
                    string userId = OperatorProvider.Provider.Current().UserId;
                    string fileGuid = Guid.NewGuid().ToString();
                    long filesize = file.ContentLength;
                    string FileEextension = Path.GetExtension(file.FileName);
                    string uploadDate = DateTime.Now.ToString("yyyyMMdd");
                    string virtualPath = string.Format("~/Resource/DocumentFile/{0}/{1}/{2}{3}", userId, uploadDate, fileGuid, FileEextension);
                    string fullFileName = this.Server.MapPath(virtualPath);
                    //创建文件夹
                    string path = Path.GetDirectoryName(fullFileName);
                    Directory.CreateDirectory(path);
                    if (!System.IO.File.Exists(fullFileName))
                    {
                        //保存文件
                        file.SaveAs(fullFileName);
                        //文件信息写入数据库
                        FileInfoEntity fileInfoEntity = new FileInfoEntity();
                        fileInfoEntity.Create();
                        fileInfoEntity.FileId = fileGuid;
                        if (!string.IsNullOrEmpty(folderId))
                        {
                            fileInfoEntity.FolderId = folderId;
                        }
                        else
                        {
                            fileInfoEntity.FolderId = "0";
                        }
                        fileInfoEntity.FileName = file.FileName;
                        fileInfoEntity.FilePath = virtualPath;
                        fileInfoEntity.FileSize = filesize.ToString();
                        fileInfoEntity.FileExtensions = FileEextension;
                        fileInfoEntity.FileType = FileEextension.Replace(".", "");
                        fileInfoBLL.SaveForm("", fileInfoEntity);
                    }
                    #endregion

                    #region 读取小立报名活动Excel
                    DataTable dt = new DataTable();
                    string sheetName = "";
                    ISheet sheet = null;
                    using (FileStream fileStream = new FileStream(fullFileName, FileMode.Open, FileAccess.Read))
                    {
                        if (fullFileName.IndexOf(".xlsx") == -1)//2003
                        {
                            HSSFWorkbook hssfworkbook = new HSSFWorkbook(fileStream);
                            sheet = hssfworkbook.GetSheetAt(0);
                        }
                        else//2007
                        {
                            XSSFWorkbook xssfworkbook = new XSSFWorkbook(fileStream);
                            sheet = xssfworkbook.GetSheetAt(0);
                        }
                    }

                    System.Collections.IEnumerator rows = sheet.GetRowEnumerator();

                    IRow headerRow = sheet.GetRow(0);
                    // 检查SheetName格式
                    sheetName = sheet.SheetName;
                    DateTime dateTime = DateTime.MinValue;
                    IFormatProvider ifp = new CultureInfo("zh-CN", true);
                    if (!DateTime.TryParseExact(sheetName, "yyyyMMdd", ifp, DateTimeStyles.None, out dateTime))
                        return Error("导入Excel的Sheet名称格式不正确！");

                    // 填充datatable
                    int cellCount = headerRow.LastCellNum;

                    for (int j = 0; j < cellCount; j++)
                    {
                        ICell cell = headerRow.GetCell(j);
                        dt.Columns.Add(cell.ToString());
                    }

                    for (int k = (sheet.FirstRowNum + 1); k <= sheet.LastRowNum; k++)
                    {
                        IRow row = sheet.GetRow(k);
                        DataRow dataRow = dt.NewRow();
                        if (row == null) break;// add by zy 20171205 防止异常
                        for (int m = row.FirstCellNum; m < cellCount; m++)
                        {
                            if (row.GetCell(m) != null)
                                dataRow[m] = row.GetCell(m).ToString();
                        }

                        dt.Rows.Add(dataRow);
                    }
                    #endregion

                    t_activityBLL.XiaoLiSaveForm(dt, sheetName);
                }
                return Success("上传成功。");
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }
        #endregion
    }
}
