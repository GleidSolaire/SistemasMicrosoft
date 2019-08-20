namespace ProjetoORM_EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version20190819 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cidades",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Nome_cidade = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Pessoas", "cidade_id", c => c.Int());
            CreateIndex("dbo.Pessoas", "cidade_id");
            AddForeignKey("dbo.Pessoas", "cidade_id", "dbo.Cidades", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pessoas", "cidade_id", "dbo.Cidades");
            DropIndex("dbo.Pessoas", new[] { "cidade_id" });
            DropColumn("dbo.Pessoas", "cidade_id");
            DropTable("dbo.Cidades");
        }
    }
}
