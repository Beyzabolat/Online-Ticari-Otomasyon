namespace mvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class denemekargo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KargoDetays",
                c => new
                    {
                        KargoDetayID = c.Int(nullable: false, identity: true),
                        Aciklama = c.String(maxLength: 300, unicode: false),
                        TakipKodu = c.String(maxLength: 10, unicode: false),
                        Personelid = c.Int(nullable: false, identity: true),
                        Alici = c.String(maxLength: 25, unicode: false),
                        tarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.KargoDetayID);
            
            CreateTable(
                "dbo.KargoTakips",
                c => new
                    {
                        KargoTakipID = c.Int(nullable: false, identity: true),
                        TakipKodu = c.String(maxLength: 10, unicode: false),
                        Aciklama = c.String(maxLength: 100, unicode: false),
                        tarihzaman = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.KargoTakipID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.KargoTakips");
            DropTable("dbo.KargoDetays");
        }
    }
}
