using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce
{
    public partial class Index : System.Web.UI.Page
    {
        public class Product
        {
            public string ImagePath { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Product> products = new List<Product>
                {
                    new Product { ImagePath = ResolveUrl("~/images/image1.jpg"), Name = "FC Barcelona HOME 70", Description = "Maglia vintage degli anni 70", Price = 300.00m },
                    new Product { ImagePath = ResolveUrl("~/images/image2.jpg"), Name = "AS Roma HOME 2001", Description = "Storica maglia A.S. Roma stagione 2001", Price = 200.00m },
                    new Product { ImagePath = ResolveUrl("~/images/image3.jpg"), Name = "Italia FirstKit WordCup", Description = "Maglia vintage del mondiale 1982", Price = 250.00m },
                    new Product { ImagePath = ResolveUrl("~/images/image4.jpg"), Name = "Olanda FirstKit WordCup", Description = "Maglia vintage del mondiale 1978", Price = 350.00m },
                    new Product { ImagePath = ResolveUrl("~/images/image5.jpg"), Name = "FC Inter HOME 20-21", Description = "Prima maglia Inter stagione 20/21", Price = 130.00m },
                    new Product { ImagePath = ResolveUrl("~/images/image6.jpg"), Name = "FC Juventus HOME 84-85", Description = "Prima maglia Juventus stagione 84/85", Price = 100.00m },
                };

                ProductsRepeater.DataSource = products;
                ProductsRepeater.DataBind();
            }

        }
    }
}