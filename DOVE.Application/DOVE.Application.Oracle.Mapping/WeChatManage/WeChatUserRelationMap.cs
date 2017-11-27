using DOVE.Application.Entity.WeChatManage;
using System.Data.Entity.ModelConfiguration;

namespace DOVE.Application.Oracle.Mapping.WeChatManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 鸽子队足球俱乐部
    /// 创建人：张勇
    /// 日 期：2015.12.23 11:31
    /// 描 述：企业号成员
    /// </summary>
    public class WeChatUserRelationMap : EntityTypeConfiguration<WeChatUserRelationEntity>
    {
        public WeChatUserRelationMap()
        {
            #region 表、字段、主键
            //表
            this.ToTable("WECHAT_USERRELATION");
            //字段
            this.Property(x => x.UserRelationId).HasColumnName("USERRELATIONID");
            this.Property(x => x.DeptId).HasColumnName("DEPTID");
            this.Property(x => x.DeptName).HasColumnName("DEPTNAME");
            this.Property(x => x.WeChatDeptId).HasColumnName("WECHATDEPTID");
            this.Property(x => x.UserId).HasColumnName("USERID");
            this.Property(x => x.SyncState).HasColumnName("SYNCSTATE");
            this.Property(x => x.SyncLog).HasColumnName("SYNCLOG");
            this.Property(x => x.CreateDate).HasColumnName("CREATEDATE");
            this.Property(x => x.CreateUserId).HasColumnName("CREATEUSERID");
            this.Property(x => x.CreateUserName).HasColumnName("CREATEUSERNAME");
            //主键
            this.HasKey(t => t.UserRelationId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
