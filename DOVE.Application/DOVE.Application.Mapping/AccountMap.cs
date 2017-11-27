﻿using DOVE.Application.Entity;
using System.Data.Entity.ModelConfiguration;

namespace DOVE.Application.Mapping
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 鸽子队足球俱乐部
    /// 创建人：张勇
    /// 日 期：2016.05.11 16:23
    /// 描 述：注册账户
    /// </summary>
    public class AccountMap : EntityTypeConfiguration<AccountEntity>
    {
        public AccountMap()
        {
            #region 表、主键
            // 表
            this.ToTable("Account");
            // 主键
            this.HasKey(t => t.AccountId);

            #endregion

            #region 配置关系
            #endregion
        }
    }
}
