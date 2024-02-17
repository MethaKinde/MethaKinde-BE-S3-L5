<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="ProductDetail.aspx.cs" Inherits="Ecommerce.ProductDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
        <div class="container">
            <h2 class="text-danger">Dettagli Prodotto</h2>
            <div class="card mb-4 shadow-sm">
                <div class="row">
                    <div class="col-md-4">
                        <asp:Image runat="server" ID="ProductImage" CssClass="card-img-top" />
                    </div>
                    <div class="col-md-8">
                        <div class="card-body h-100 justify-content-around">
                            <div>
                                <div class="col-md-12">
                                    <asp:Label runat="server" class="card-title" ID="ProductNameLabel"></asp:Label>
                                </div>
                                <div class="col-md-12">
                                    <asp:Label runat="server" class="card-text" ID="ProductDescriptionLabel"></asp:Label>
                                </div>
                                <div class="col-md-12">
                                    <asp:Label runat="server" class="card-text" ID="ProductBrandLabel"></asp:Label>
                                </div>
                                <div class="col-md-12">
                                    <asp:Label runat="server" class="card-text" ID="ProductMaterialeLabel"></asp:Label>
                                </div>
                                <div class="col-md-12">
                                    <asp:Label runat="server" class="card-text" ID="ProductManicaLabel"></asp:Label>
                                </div>
                                <div class="col-md-12">
                                    <asp:Label runat="server" class="card-text" ID="ProductPaeseLabel"></asp:Label>
                                </div>
                                <div class="col-md-12">
                                    <asp:Label runat="server" class="card-text" ID="ProductPriceLabel"></asp:Label>
                                </div>
                            </div>
                            <asp:Button runat="server" ID="AddToCartButton" Text="Aggiungi al carrello" CssClass="btn btn-primary" OnClick="AddToCartButton_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>


