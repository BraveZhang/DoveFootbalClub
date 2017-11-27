using DOVE.Application.Entity.ReportManage;
using System.Data.Entity.ModelConfiguration;

namespace DOVE.Application.Oracle.Mapping
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 鸽子队足球俱乐部
    /// 创建人：张勇
    /// 日 期：2015.11.27
    /// 描 述：授权数据范围
    /// </summary>
    public class RptTempMap : EntityTypeConfiguration<RptTempEntity>
    {
        public RptTempMap()
        {
            #region 表、字段、主键
            //表
            this.ToTable("RPT_TEMP");
            //字段
            this.Property(x => x.TempId).HasColumnName("TEMPID");
            this.Property(x => x.FullName).HasColumnName("FULLNAME");
            this.Property(x => x.EnCode).HasColumnName("ENCODE");
            this.Property(x => x.TempType).HasColumnName("TEMPTYPE");
            this.Property(x => x.TempCategory).HasColumnName("TEMPCATEGORY");
            this.Property(x => x.Description).HasColumnName("DESCRIPTION");
            this.Property(x => x.ParamJson).HasColumnName("PARAMJSON");
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
            this.HasKey(t => t.TempId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
