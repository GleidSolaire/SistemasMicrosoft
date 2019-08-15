namespace ProjetoORM_EF
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ModelPessoas : DbContext
    {
        // Your context has been configured to use a 'ModelPessoas' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ProjetoORM_EF.ModelPessoas' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ModelPessoas' 
        // connection string in the application configuration file.
        public ModelPessoas()
            : base("name=ModelPessoas")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

         public virtual DbSet<Pessoa> Pessoas { get; set; }
        public virtual DbSet<Cidade> cidades { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}