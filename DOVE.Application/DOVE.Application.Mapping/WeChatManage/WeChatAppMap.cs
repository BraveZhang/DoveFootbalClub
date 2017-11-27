using DOVE.Application.Entity.WeChatManage;
using System.Data.Entity.ModelConfiguration;

namespace DOVE.Application.Mapping.WeChatManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 鸽子队足球俱乐部
    /// 创建人：张勇
    /// 日 期：2015.12.23 11:31
    /// 描 述：企业号应用
    /// </summary>
    public class WeChatAppMap : EntityTypeConfiguration<WeChatAppEntity>
    {
        public WeChatAppMap()
        {
            #region 表、主键
            //表
            this.ToTable("WeChat_App");
            //主键
            this.HasKey(t => t.AppId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
