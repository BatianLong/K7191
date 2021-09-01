using System.Data.Entity;
using System.Data.Common;
using SQLite.CodeFirst;

public class UserContext : DbContext
{
    //用System.Data.SQLite::SQLiteConnection创建DbConnection进行构造初始化
    public UserContext(DbConnection dbConnection, bool contextOwnsConnection = true)
           : base(dbConnection, true)
    {
    }

    //使用SQLite.CodeFirst::SqliteCreateDatabaseIfNotExists进行创建数据库
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<UserContext>(modelBuilder);
        Database.SetInitializer(sqliteConnectionInitializer);
    }

    public DbSet<UserModel> User { get; set; }
}