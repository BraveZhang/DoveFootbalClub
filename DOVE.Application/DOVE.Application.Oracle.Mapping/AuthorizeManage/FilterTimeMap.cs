using DOVE.Application.Entity.AuthorizeManage;
using System.Data.Entity.ModelConfiguration;

namespace DOVE.Application.Oracle.Mapping.AuthorizeManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 鸽子队足球俱乐部
    /// 创建人：张勇
    /// 日 期：2015.11.20 13:32
    /// 描 述：过滤IP
    /// </summary>
    public class FilterTimeMap : EntityTypeConfiguration<FilterTimeEntity>
    {
        public FilterTimeMap()
        {
            #region 表、字段、主键
            //表
            this.ToTable("BASE_FILTERTIME");
            //字段
            this.Property(x => x.FilterTimeId).HasColumnName("FILTERTIMEID");
            this.Property(x => x.ObjectType).HasColumnName("OBJECTTYPE");
            this.Property(x => x.ObjectId).HasColumnName("OBJECTID");
            this.Property(x => x.VisitType).HasColumnName("VISITTYPE");
            this.Property(x => x.WeekDay1).HasColumnName("WEEKDAY1");
            this.Property(x => x.WeekDay2).HasColumnName("WEEKDAY2");
            this.Property(x => x.WeekDay3).HasColumnName("WEEKDAY3");
            this.Property(x => x.WeekDay4).HasColumnName("WEEKDAY4");
            this.Property(x => x.WeekDay5).HasColumnName("WEEKDAY5");
            this.Property(x => x.WeekDay6).HasColumnName("WEEKDAY6");
            this.Property(x => x.WeekDay7).HasColumnName("WEEKDAY7");
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
            this.HasKey(t => t.FilterTimeId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
