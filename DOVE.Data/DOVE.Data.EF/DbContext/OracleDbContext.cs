using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Reflection;
using System.Linq;
using System.Web;
using System.IO;
using Oracle.ManagedDataAccess.Client;

namespace DOVE.Data.EF
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 鸽子队科技
    /// 创建人：张勇
    /// 日 期：2017.09.06
    /// 描 述：数据访问(Oracle) 上下文
    /// </summary>

    public class OracleDbContext : DbContext, IDbContext
    {
        // 数据库连接name add by zy 20170913
        private string connName = "";

        #region 构造函数
        /// <summary>
        /// 初始化一个 使用指定数据连接名称或连接串 的数据访问上下文类 的新实例
        /// </summary>
        /// <param name="connString"></param>
        public OracleDbContext(string connString)
            : base(connString)
        {
            this.Configuration.AutoDetectChangesEnabled = false;
            this.Configuration.ValidateOnSaveEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
            connName = connString;// add by zy 20170913
        }
        #endregion

        #region 重载
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings[connName].ConnectionString;
            OracleConnectionStringBuilder ora_sb = new OracleConnectionStringBuilder(connectionString);
            DbHelper.UserID = ora_sb.UserID;// 将数据库当前用户名存下来
            modelBuilder.HasDefaultSchema(ora_sb.UserID);// 需要指定数据库用户名
            //string assembleFileName = Assembly.GetExecutingAssembly().CodeBase.Replace("DOVE.Data.EF.DLL", "DOVE.Application.Mapping.dll").Replace("file:///", "");
            string assembleFileName = Assembly.GetExecutingAssembly().CodeBase.Replace("DOVE.Data.EF.DLL", "DOVE.Application.Oracle.Mapping.dll").Replace("file:///", "");// add by zhangy 20170912 采用Oracle的Mapping类库，由于大小写敏感
            Assembly asm = Assembly.LoadFile(assembleFileName);
            var typesToRegister = asm.GetTypes()
            .Where(type => !String.IsNullOrEmpty(type.Namespace))
            .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            base.OnModelCreating(modelBuilder);
        }
        #endregion
    }
}
