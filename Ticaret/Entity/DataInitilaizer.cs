using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ticaret.Entity
{
    public class DataInitilaizer:DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var kategoriler = new List<Category>()
            {
                new Category() {Name="KAMERA", Description="Kamera Ürünleri"},
                new Category() {Name="TELEFON", Description="Telefon Ürünleri"},
                new Category() {Name="BİLGİSAYAR", Description="Bilgisayar Ürünleri"}
            };
            foreach(var kategori in kategoriler)
            {
                context.Categories.Add(kategori);
            }
            context.SaveChanges();
            var urunler = new List<Product>()
            {
                new Product(){Name="Canon", Description="kamera ürünleri", price=2500, Stock=5, IsFeatured=true, CategoryId=1, image="1.jpg" },
                new Product(){Name="Asus", Description="bilgisayar ürünleri", price=2000, Stock=25, IsFeatured=true, CategoryId=3, image="2.jpg" },
                new Product(){Name="Lenovo", Description="bilgisayar ürünleri", price=3500, Stock=15, IsFeatured=true, CategoryId=3, image="3.jpg" },
                new Product(){Name="Samsung", Description="telefon ürünleri", price=4500, Stock=5, IsFeatured=true, CategoryId=2, image="4.jpg" },
            };
            foreach(var urun in urunler)
            {
                context.Products.Add(urun);
            }
            context.SaveChanges();
            base.Seed(context);
        }
    }
}