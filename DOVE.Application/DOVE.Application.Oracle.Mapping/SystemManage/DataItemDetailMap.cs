using DOVE.Application.Entity.SystemManage;
using System.Data.Entity.ModelConfiguration;

namespace DOVE.Application.Oracle.Mapping.SystemManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 鸽子队足球俱乐部
    /// 创建人：张勇
    /// 日 期：2015.11.17 9:56
    /// 描 述：数据字典明细
    /// </summary>
    public class DataItemDetailMap : EntityTypeConfiguration<DataItemDetailEntity>
    {
        public DataItemDetailMap()
        {
            #region 表、字段、主键
            //表
            this.ToTable("BASE_DATAITEMDETAIL");
            //字段
            this.Property(x => x.ItemDetailId).HasColumnName("ITEMDETAILID");
            this.Property(x => x.ItemId).HasColumnName("ITEMID");
            this.Property(x => x.ParentId).HasColumnName("PARENTID");
            this.Property(x => x.ItemCode).HasColumnName("ITEMCODE");
            this.Property(x => x.ItemName).HasColumnName("ITEMNAME");
            this.Property(x => x.ItemValue).HasColumnName("ITEMVALUE");
            this.Property(x => x.QuickQuery).HasColumnName("QUICKQUERY");
            this.Property(x => x.SimpleSpelling).HasColumnName("SIMPLESPELLING");
            this.Property(x => x.IsDefault).HasColumnName("ISDEFAULT");
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
            this.HasKey(t => t.ItemDetailId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
