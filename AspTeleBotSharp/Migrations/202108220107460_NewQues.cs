namespace AspTeleBotSharp.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class NewQues : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "Image", c => c.String(maxLength: 50));
            AddColumn("dbo.Questions", "Type", c => c.String(maxLength: 50));
            AddColumn("dbo.Questions", "file", c => c.String(maxLength: 50));
        }

        public override void Down()
        {
            DropColumn("dbo.Questions", "file");
            DropColumn("dbo.Questions", "Type");
            DropColumn("dbo.Questions", "Image");
        }
    }
}
