﻿using DOVE.Application.Entity.AuthorizeManage;
using System.Data.Entity.ModelConfiguration;

namespace DOVE.Application.Oracle.Mapping.AuthorizeManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 鸽子队足球俱乐部
    /// 创建人：张勇
    /// 日 期：2016.04.14 09:16
    /// 描 述：系统表单
    /// </summary>
    public class ModuleFormInstanceMap : EntityTypeConfiguration<ModuleFormInstanceEntity>
    {
        public ModuleFormInstanceMap()
        {
            #region 表、字段、主键
            //表
            this.ToTable("BASE_MODULEFORMINSTANCE");
            //字段
            this.Property(x => x.FormInstanceId).HasColumnName("FORMINSTANCEID");
            this.Property(x => x.FormId).HasColumnName("FORMID");
            this.Property(x => x.FormInstanceJson).HasColumnName("FORMINSTANCEJSON");
            this.Property(x => x.ObjectId).HasColumnName("OBJECTID");
            this.Property(x => x.SortCode).HasColumnName("SORTCODE");
            this.Property(x => x.Description).HasColumnName("DESCRIPTION");
            //主键
            this.HasKey(t => t.FormInstanceId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}