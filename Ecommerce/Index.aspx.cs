using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Ecommerce.Index;

namespace Ecommerce
{
    public partial class Index : System.Web.UI.Page
    {
        public class Product
        {
            public string ProductID { get; set; }
            public string ImagePath { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadProductData();
            }

        }

        protected void AddToCartButton_Click(object sender, EventArgs e)
        {
            Button btnAddToCart = (Button)sender;
            string[] args = btnAddToCart.CommandArgument.Split('|');

            string productId = args[0];
            string productName = args[1];
            decimal productPrice = decimal.Parse(args[2]);

            Product selectedProduct = new Product
            {
                ProductID = productId,
                ImagePath = ResolveUrl("~/Images/" + productId + ".jpg"),
                Name = productName,
                Description = "Breve descrizione dell'articolo " + productId,
                Price = productPrice
            };

            AddProductToCart(selectedProduct);
        }

        private void LoadProductData()
        {
            List<Product> products = new List<Product>
               {
                new Product { ProductID = "1", ImagePath = ResolveUrl("~/images/image1.jpg"), Name = "FC Barcelona HOME 70", Description = "Maglia vintage degli anni 70", Price = 300.00m },
                new Product { ProductID = "2", ImagePath = ResolveUrl("~/images/image2.jpg"), Name = "AS Roma HOME 2001", Description = "Storica maglia A.S. Roma stagione 2001", Price = 200.00m },
                new Product { ProductID = "3", ImagePath = ResolveUrl("~/images/image3.jpg"), Name = "Italia FirstKit WordCup", Description = "Maglia vintage del mondiale 1982", Price = 250.00m },
                new Product { ProductID = "4", ImagePath = ResolveUrl("~/images/image4.jpg"), Name = "Olanda FirstKit WordCup", Description = "Maglia vintage del mondiale 1978", Price = 350.00m },
                new Product { ProductID = "5", ImagePath = ResolveUrl("~/images/image5.jpg"), Name = "FC Inter HOME 20-21", Description = "Prima maglia Inter stagione 20/21", Price = 130.00m },
                new Product { ProductID = "6", ImagePath = ResolveUrl("~/images/image6.jpg"), Name = "FC Juventus HOME 84-85", Description = "Prima maglia Juventus stagione 84/85", Price = 100.00m },
               };

            ProductsRepeater.DataSource = products;
            ProductsRepeater.DataBind();
        }

        private void AddProductToCart(Product product)
        {
            List<Product> cart = Session["Cart"] as List<Product> ?? new List<Product>();

            cart.Add(product);

            Session["Cart"] = cart;
        }

        protected void ViewDetailsButton_Click(object sender, EventArgs e)
        {
            Button btnViewDetails = (Button)sender;
            string productId = btnViewDetails.CommandArgument;

            Response.Redirect("ProductDetail.aspx?ProductId=" + productId);
        }
    }
}