using RH.Application.Entity.BaseManage;
using System.Data.Entity.ModelConfiguration;

namespace RH.Application.Mapping.BaseManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 辽宁瑞华实业集团高新科技有限公司
    /// 创 建：超级管理员
    /// 日 期：2017-09-18 16:14
    /// 描 述：数据字典分类表
    /// </summary>
    public class Base_DataitemMap : EntityTypeConfiguration<Base_DataitemEntity>
    {
        public Base_DataitemMap()
        {
            #region 表、主键
            //表
            this.ToTable("Base_Dataitem");
            //主键
            this.HasKey(t => t.Itemid);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
