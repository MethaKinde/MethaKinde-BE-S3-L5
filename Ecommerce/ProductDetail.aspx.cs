using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Ecommerce.Index;

namespace Ecommerce
{
    public partial class ProductDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Controlla se è stato fornito un ProductId nei parametri della richiesta
                if (Request.QueryString["ProductId"] != null)
                {
                    string productId = Request.QueryString["ProductId"];

                    // Ottieni il prodotto corrispondente dal database o da una lista di prodotti
                    // In questo caso, useremo la stessa lista di prodotti usata in Index.aspx.cs per semplicità

                    List<Index.Product> products = GetProducts();
                    Index.Product selectedProduct = products.FirstOrDefault(p => p.ProductID == productId);

                    if (selectedProduct != null)
                    {
                        // Visualizza i dettagli del prodotto
                        ProductNameLabel.Text = selectedProduct.Name;
                        ProductImage.ImageUrl = selectedProduct.ImagePath;
                        ProductDescriptionLabel.Text = "Descrizione: " + selectedProduct.Description;
                        ProductBrandLabel.Text = "Brand: " + selectedProduct.Brand;
                        ProductMaterialeLabel.Text = "Materiale 1: " + selectedProduct.Materiale;
                        ProductManicaLabel.Text = "Macina: " + selectedProduct.Manica;
                        ProductPaeseLabel.Text = "Paese: " + selectedProduct.Paese;
                        ProductPriceLabel.Text = "Prezzo: " + selectedProduct.Price.ToString("C"); // Formatta il prezzo come valuta
                    }
                }
            }
        }

        // Metodo di esempio per ottenere la lista dei prodotti (puoi modificare questo metodo in base alla tua logica)
        private List<Index.Product> GetProducts()
        {
            List<Index.Product> products = new List<Index.Product>
            {
                new Index.Product
                { 
                    ProductID = "1", 
                    ImagePath = ResolveUrl("~/images/image1.jpg"), 
                    Name = "FC Barcelona HOME 70", 
                    Description = "Maglia vintage degli anni 70",
                    Brand = "Copa Classic",
                    Materiale = "50% Cotone - 50% Pollestere",
                    Manica = "Manica corta",
                    Paese = "Spagna",
                    Price = 300.00m
                },
                new Index.Product 
                { 
                    ProductID = "2", 
                    ImagePath = ResolveUrl("~/images/image2.jpg"), 
                    Name = "AS Roma HOME 2001", 
                    Description = "Storica maglia A.S. Roma stagione 2001",
                    Brand = "Copa Classic",
                    Materiale = "50% Cotone - 50% Pollestere",
                    Manica = "Manica corta",
                    Paese = "Italia",
                    Price = 200.00m
                },
                new Index.Product 
                { 
                    ProductID = "3",  
                    ImagePath = ResolveUrl("~/images/image3.jpg"), 
                    Name = "Italia FirstKit WordCup", 
                    Description = "Maglia vintage del mondiale 1982",
                    Brand = "TOFFS",
                    Materiale = "Cotone",
                    Manica = "Manica corta",
                    Paese = "Italia",
                    Price = 250.00m 
                },
                new Index.Product 
                { 
                    ProductID = "4", 
                    ImagePath = ResolveUrl("~/images/image4.jpg"), 
                    Name = "Olanda FirstKit WordCup", 
                    Description = "Maglia vintage del mondiale 1978",
                    Brand = "Copa Classic",
                    Materiale = "Cotone",
                    Manica = "Manica corta",
                    Paese = "Olanda",
                    Price = 350.00m 
                },
                new Index.Product 
                { 
                    ProductID = "5", 
                    ImagePath = ResolveUrl("~/images/image5.jpg"), 
                    Name = "FC Inter HOME 20-21", 
                    Description = "Prima maglia Inter stagione 20/21",
                    Brand = "Nike Football",
                    Materiale = "50% Cotone - 50% Pollestere",
                    Manica = "Manica corta",
                    Paese = "Italia",
                    Price = 130.00m
                },
                new Index.Product 
                { 
                    ProductID = "6", 
                    ImagePath = ResolveUrl("~/images/image6.jpg"), 
                    Name = "FC Juventus HOME 84-85", 
                    Description = "Prima maglia Juventus stagione 84/85",
                    Brand = "Copa Classic",
                    Materiale = "Cotone",
                    Manica = "Manica corta",
                    Paese = "Italia",
                    Price = 100.00m 
                },
            };

            return products;
        }

        private void AddProductToCart(Product product)
        {
            List<Product> cart = Session["Cart"] as List<Product> ?? new List<Product>();

            cart.Add(product);

            Session["Cart"] = cart;
        }

        protected void AddToCartButton_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["ProductId"] != null)
            {
                string productId = Request.QueryString["ProductId"];

                List<Product> products = GetProducts();
                Product selectedProduct = products.FirstOrDefault(p => p.ProductID == productId);

                if (selectedProduct != null)
                {
                    AddProductToCart(selectedProduct);
                    Response.Redirect(Request.RawUrl);
                }
            }
        }
    }
}