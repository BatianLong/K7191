using System.Data.Entity;
using System.Data.Common;
using SQLite.CodeFirst;

public class PossessionContext : DbContext
{
    //用System.Data.SQLite::SQLiteConnection创建DbConnection进行构造初始化
    public PossessionContext(DbConnection dbConnection, bool contextOwnsConnection = true)
           : base(dbConnection, true)
    {
    }

    //使用SQLite.CodeFirst::SqliteCreateDatabaseIfNotExists进行创建数据库
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<PossessionContext>(modelBuilder);
        Database.SetInitializer(sqliteConnectionInitializer);
    }

    public DbSet<PossessionModel> Possession { get; set; }
}