namespace ProjetoORM_EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class casas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Casas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        endereco = c.String(),
                        cidade_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Cidades", t => t.cidade_id)
                .Index(t => t.cidade_id);
            
            CreateTable(
                "dbo.PessoaCasas",
                c => new
                    {
                        Pessoa_Id = c.Int(nullable: false),
                        Casa_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Pessoa_Id, t.Casa_id })
                .ForeignKey("dbo.Pessoas", t => t.Pessoa_Id, cascadeDelete: true)
                .ForeignKey("dbo.Casas", t => t.Casa_id, cascadeDelete: true)
                .Index(t => t.Pessoa_Id)
                .Index(t => t.Casa_id);
            
            AddColumn("dbo.Pessoas", "LocaldeNascimento_id", c => c.Int());
            CreateIndex("dbo.Pessoas", "LocaldeNascimento_id");
            AddForeignKey("dbo.Pessoas", "LocaldeNascimento_id", "dbo.Cidades", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pessoas", "LocaldeNascimento_id", "dbo.Cidades");
            DropForeignKey("dbo.PessoaCasas", "Casa_id", "dbo.Casas");
            DropForeignKey("dbo.PessoaCasas", "Pessoa_Id", "dbo.Pessoas");
            DropForeignKey("dbo.Casas", "cidade_id", "dbo.Cidades");
            DropIndex("dbo.PessoaCasas", new[] { "Casa_id" });
            DropIndex("dbo.PessoaCasas", new[] { "Pessoa_Id" });
            DropIndex("dbo.Casas", new[] { "cidade_id" });
            DropIndex("dbo.Pessoas", new[] { "LocaldeNascimento_id" });
            DropColumn("dbo.Pessoas", "LocaldeNascimento_id");
            DropTable("dbo.PessoaCasas");
            DropTable("dbo.Casas");
        }
    }
}
