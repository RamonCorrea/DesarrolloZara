<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProyectoFinal.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 909px">
<form runat="server" method="post" style="width: 907px">
    <table>
        <tr>
            <td> <asp:Label ID="lblUsuario" runat="server">Usuario :</asp:Label> </td>
            <td> <asp:TextBox ID="txtUsuario" runat="server" Width="110px" MaxLength="10"></asp:TextBox> </td>
            <td> <asp:RequiredFieldValidator ControlToValidate="txtUsuario" Display="Dynamic"
                  ErrorMessage="Ingrese Usuario" runat="server" ID="vUserName">
                 </asp:RequiredFieldValidator> 
                 </td>
        </tr>
        
        <tr>
            <td> <asp:Label ID="lblPassword" runat="server">Contraseña :</asp:Label> </td>
            <td> <asp:TextBox ID="txtPassword" runat="server" Width="111px" TextMode="Password" 
                          MaxLength="10">
                 </asp:TextBox> </td>
            <td> <asp:RequiredFieldValidator ControlToValidate="txtPassword" Display="Dynamic"
                  ErrorMessage="Ingrese Password" runat="server" ID="vPassword">
                 </asp:RequiredFieldValidator> 
                 </td>
        </tr>
        
        <tr>
            <td> <asp:Label ID="lblEmpresa" runat="server">Empresa :</asp:Label> </td>
            <td> <asp:DropDownList ID="DropDownList1" runat="server" 
                                DataSourceID="SqlDataSource1" DataTextField="NOMBRE_EMPRESA" 
                                DataValueField="COD_EMPRESA"
                                AutoPostBack="True">
                 </asp:DropDownList> </td>
        </tr>
        
        <tr>
            <td> <asp:Label ID="lblCosto" runat="server">Centro Costo :</asp:Label> </td>
            <td> <asp:DropDownList ID="DropDownList2" runat="server" 
                             OnPreRender="CargaCCosto" >
                 </asp:DropDownList></td>
        </tr>

        <tr>
           <td><asp:Button ID="btnEnviar" Text="Ingreso" runat="server" onclick="btnEnviar_Click"/> </td>
           <td colspan="3"> <asp:Label ID="Mensaje" runat="server"></asp:Label> </td>
        </tr>
    </table> 
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                 ConnectionString="<%$ ConnectionStrings:ConexionBaseDatos%>"
                 ProviderName="System.Data.SqlClient" 
                 SelectCommand="SELECT [COD_EMPRESA], [NOMBRE_EMPRESA] FROM [P_EMPRESA]">
    </asp:SqlDataSource>
  </form>
</div>
</asp:Content>
