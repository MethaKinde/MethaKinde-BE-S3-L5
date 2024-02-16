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
            InitializeCartSession();

            if (!IsPostBack)
            {
                LoadProductDetails();
            }
        }

        private void InitializeCartSession()
        {
            if (Session["Cart"] == null)
            {
                Session["Cart"] = new List<Product>();
            }
        }

        private void LoadProductDetails()
        {
            try
            {
                string productId = Request.QueryString["ProductId"];

                List<Product> products = Session["Cart"] as List<Product>;

                Product selectedProduct = products.FirstOrDefault(p => p.ProductID == productId);

                if (selectedProduct != null)
                {
                    string imagePath = selectedProduct.ImagePath;
                    Console.WriteLine("Percorso immagine: " + imagePath);
                    ImagePath.ImageUrl = imagePath;

                    NameLabel.Text = selectedProduct.Name;
                    PriceLabel.Text = "Prezzo: €" + selectedProduct.Price.ToString();
                    ExtendedDescriptionLabel.Text = selectedProduct.Description;
                }
                else
                {
                    Response.Redirect("ErrorPage.aspx");
                }
            }
            catch (Exception ex)
            {
                // Aggiungi eventuali dettagli dell'errore all'output della console o al log degli errori
                Console.WriteLine("Errore durante il caricamento dei dettagli del prodotto: " + ex.Message);
                // Puoi aggiungere ulteriori azioni per gestire l'errore, ad esempio reindirizzare a una pagina di errore specifica
                Response.Redirect("ErrorPage.aspx");
            }
        }

        protected void AddToCartButton_Click(object sender, EventArgs e)
        {
            // Implementa qui la logica per aggiungere il prodotto al carrello, se necessario
            // Puoi utilizzare lo stesso metodo AddProductToCart() che hai nel file Index.aspx.cs
        }
    }
}