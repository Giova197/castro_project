using FluentMigrator;
using static CastroProgetto.Persistence.Constants.DbConstants;

namespace CastroProgetto.Persistence.Migrations
{
    [Migration(1)]
    public class AddProductTable : Migration
    {
        public override void Down()
        {
            Delete.Table(Product.TableName);
        }

        public override void Up()
        {
            Create.Table(Product.TableName)
                .WithColumn(Product.Sku).AsString().PrimaryKey()
                .WithColumn(Product.Name).AsString(256)
                .WithColumn(Product.Category).AsString(256)
                .WithColumn(Product.Price).AsInt32();
        }
    }
}
