using DOVE.Application.Entity.SystemManage;
using System.Data.Entity.ModelConfiguration;

namespace DOVE.Application.Oracle.Mapping.SystemManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 鸽子队足球俱乐部
    /// 创建人：张勇
    /// 日 期：2016.1.8 9:56
    /// 描 述：系统日志
    /// </summary>
    public class LogMap : EntityTypeConfiguration<LogEntity>
    {
        public LogMap()
        {
            #region 表、字段、主键
            //表
            this.ToTable("BASE_LOG");
            //字段
            this.Property(x => x.LogId).HasColumnName("LOGID");
            this.Property(x => x.CategoryId).HasColumnName("CATEGORYID");
            this.Property(x => x.SourceObjectId).HasColumnName("SOURCEOBJECTID");
            this.Property(x => x.SourceContentJson).HasColumnName("SOURCECONTENTJSON");
            this.Property(x => x.OperateTime).HasColumnName("OPERATETIME");
            this.Property(x => x.OperateUserId).HasColumnName("OPERATEUSERID");
            this.Property(x => x.OperateAccount).HasColumnName("OPERATEACCOUNT");
            this.Property(x => x.OperateTypeId).HasColumnName("OPERATETYPEID");
            this.Property(x => x.OperateType).HasColumnName("OPERATETYPE");
            this.Property(x => x.ModuleId).HasColumnName("MODULEID");
            this.Property(x => x.Module).HasColumnName("MODULE");
            this.Property(x => x.IPAddress).HasColumnName("IPADDRESS");
            this.Property(x => x.IPAddressName).HasColumnName("IPADDRESSNAME");
            this.Property(x => x.Host).HasColumnName("HOST");
            this.Property(x => x.Browser).HasColumnName("BROWSER");
            this.Property(x => x.ExecuteResult).HasColumnName("EXECUTERESULT");
            this.Property(x => x.ExecuteResultJson).HasColumnName("EXECUTERESULTJSON");
            this.Property(x => x.Description).HasColumnName("DESCRIPTION");
            this.Property(x => x.DeleteMark).HasColumnName("DELETEMARK");
            this.Property(x => x.EnabledMark).HasColumnName("ENABLEDMARK");
            //主键
            this.HasKey(t => t.LogId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
