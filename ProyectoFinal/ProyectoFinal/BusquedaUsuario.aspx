<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="BusquedaUsuario.aspx.cs" Inherits="ProyectoFinal.BusquedaUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server" method="post">
    <h1 style="text-align: center"> Listado de Usuarios</h1>
    <br />
    <div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" 
            onselectedindexchanged="GridView1_SelectedIndexChanged" Width="837px" 
            BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4" ForeColor="Black" GridLines="Vertical" 
            style="text-align: center">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="Codigo_Empleado" HeaderText="Codigo_Empleado" 
                    SortExpression="Codigo_Empleado" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" 
                    SortExpression="Nombre" />
                <asp:BoundField DataField="Apellido_Paterno" HeaderText="Apellido_Paterno" 
                    SortExpression="Apellido_Paterno" />
                <asp:BoundField DataField="Apellido_Materno" HeaderText="Apellido_Materno" 
                    SortExpression="Apellido_Materno" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConexionBaseDatos %>" 
            
            
            
            SelectCommand="SELECT COD_INTERNO AS Codigo_Empleado, NOMBRES AS Nombre, APE_PAT AS Apellido_Paterno, APE_MAT AS Apellido_Materno FROM T_EMPLEADO WHERE (COD_AGRUPA = @COD_AGRUPA)">
            <SelectParameters>
                <asp:ControlParameter ControlID="lblUnidad" Name="COD_AGRUPA" 
                    PropertyName="Text" Type="String" DefaultValue="" />
            </SelectParameters>
        </asp:SqlDataSource>     
    </div>
    <div>
        <asp:Label ID="lblcodigo" runat="server" Visible="false"></asp:Label>
        <asp:Label ID="lblnombre" runat="server" Visible="false"></asp:Label>
        <asp:Label ID="lblUnidad" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="lbfecha" runat="server" Visible="False"></asp:Label>
    </div>
   </form>
</asp:Content>
