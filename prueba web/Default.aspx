<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="prueba_web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <asp:Label Font-Size="Large" Text="PRUEBA" runat="server" />

        <asp:Panel runat="server" ID="pnlDatosNombre">
        <asp:GridView ID="gvdNombre" runat="server" AutoGenerateColumns="false" DataKeyNames="id" OnRowDeleting="gvdNombre_RowDeleted">
            <Columns>
                <asp:BoundField DataField="id" HeaderText ="ID" />
                <asp:BoundField DataField="nombre" HeaderText ="Nombre" />
                <asp:BoundField DataField="apellido" HeaderText ="Apellido" />
                <asp:CommandField ShowDeleteButton="true" EditText="Eliminar" HeaderText="Eliminar" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="linkActualizar" Text="Actualizar" runat="server" OnClick="linkActualizar_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

        </asp:GridView>
            <asp:Button ID="btnNuevo" Text="Agregar" runat="server" OnClick="btnNuevo_Click"/>
        </asp:Panel>

        <asp:Panel ID="pnlAlta" runat="server" Visible="false">
            <div>  
                <asp:Label id="lblNombre" Text="Nombre" runat="server" />
                <asp:TextBox ID="txtnombre" runat="server" />
            </div>

            <div>
                <asp:Label id="lblApellido" Text="Apellido" runat="server" />
                   <asp:TextBox ID="txtapellido" runat="server" />
            </div>

            <br />

            <asp:Label ID="lblIdAlumno" Text="text" runat="server" visible="false"/>
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnActualizar" Text="Actualizar" runat="server" OnClick="btnActualizar_Click"/>
        </asp:Panel>
    </div>

</asp:Content>
