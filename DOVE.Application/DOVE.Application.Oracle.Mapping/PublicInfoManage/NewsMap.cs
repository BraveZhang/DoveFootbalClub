using DOVE.Application.Entity.PublicInfoManage;
using System.Data.Entity.ModelConfiguration;

namespace DOVE.Application.Oracle.Mapping.PublicInfoManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 鸽子队足球俱乐部
    /// 创建人：张勇
    /// 日 期：2015.12.7 16:40
    /// 描 述：新闻中心
    /// </summary>
    public class NewsMap : EntityTypeConfiguration<NewsEntity>
    {
        public NewsMap()
        {
            #region 表、字段、主键
            //表
            this.ToTable("BASE_NEWS");
            //字段
            this.Property(x => x.NewsId).HasColumnName("NEWSID");
            this.Property(x => x.TypeId).HasColumnName("TYPEID");
            this.Property(x => x.ParentId).HasColumnName("PARENTID");
            this.Property(x => x.Category).HasColumnName("CATEGORY");
            this.Property(x => x.FullHead).HasColumnName("FULLHEAD");
            this.Property(x => x.FullHeadColor).HasColumnName("FULLHEADCOLOR");
            this.Property(x => x.BriefHead).HasColumnName("BRIEFHEAD");
            this.Property(x => x.AuthorName).HasColumnName("AUTHORNAME");
            this.Property(x => x.CompileName).HasColumnName("COMPILENAME");
            this.Property(x => x.TagWord).HasColumnName("TAGWORD");
            this.Property(x => x.Keyword).HasColumnName("KEYWORD");
            this.Property(x => x.SourceName).HasColumnName("SOURCENAME");
            this.Property(x => x.SourceAddress).HasColumnName("SOURCEADDRESS");
            this.Property(x => x.NewsContent).HasColumnName("NEWSCONTENT");
            this.Property(x => x.PV).HasColumnName("PV");
            this.Property(x => x.ReleaseTime).HasColumnName("RELEASETIME");
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
            this.HasKey(t => t.NewsId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
