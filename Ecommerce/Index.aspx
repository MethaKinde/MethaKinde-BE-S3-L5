<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Ecommerce.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
        <h2 class="text-danger">Prodotti più venduti</h2>
        <div class="row">
            <asp:Repeater ID="ProductsRepeater" runat="server">
                <ItemTemplate>
                    <div class="col-md-4 mb-5">
                        <div class="card shadow-sm h-100">
                            <img class="card-img-top" src='<%# Eval("ImagePath") %>' alt='<%# Eval("Name") %>'>
                            <div class="card-body">
                                <h4 class="card-title"><%# Eval("Name") %></h4>
                                <p class="card-text"><%# Eval("Description") %></p>
                                <p class="card-text">Prezzo: <%# Eval("Price") %> €</p>
                                <div>
                                    <asp:Button runat="server" ID="AddToCartButton" Text="Aggiungi al carrello" CssClass="btn btn-primary" OnClick="AddToCartButton_Click"  />
                                    <asp:Button runat="server" ID="ViewDetailsButton" Text="Vedi dettagli" CssClass="btn btn-warning" OnClick="ViewDetailsButton_Click" CommandArgument='<%# Eval("ProductID") %>' />
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</asp:Content>
