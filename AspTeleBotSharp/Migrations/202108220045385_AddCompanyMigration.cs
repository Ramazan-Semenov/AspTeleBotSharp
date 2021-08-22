namespace AspTeleBotSharp.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddCompanyMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InlineKeyboard",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Questionsid = c.Int(),
                    Text = c.String(),
                    CallBackData = c.String(maxLength: 50),
                    box = c.String(maxLength: 50),
                    Image = c.String(maxLength: 50),
                    Type = c.String(maxLength: 50),
                    file = c.String(maxLength: 50),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.InlineKeyboardBox",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(maxLength: 50),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Questions",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    replyMarkupBox = c.String(maxLength: 50),
                    Text = c.String(),
                    replyToMessageId = c.Int(),
                    box = c.String(maxLength: 50),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.QuestionsBox",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(maxLength: 50),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropTable("dbo.QuestionsBox");
            DropTable("dbo.Questions");
            DropTable("dbo.InlineKeyboardBox");
            DropTable("dbo.InlineKeyboard");
        }
    }
}
