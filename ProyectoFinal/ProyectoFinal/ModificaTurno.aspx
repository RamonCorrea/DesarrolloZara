﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ModificaTurno.aspx.cs" Inherits="ProyectoFinal.ModificaTurno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server" method="post">
 <div>
 <h1 style="text-align: center"> Datos del Trabajor</h1>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>    
                </td>
                <td>
                    <asp:Label ID="lblNombre2" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblCodigo" runat="server" Text="Codigo Empleado:"></asp:Label>    
                </td>
                <td>
                    <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblFecha" runat="server" Text="Fecha Turno:"></asp:Label>    
                </td>
                <td>
                    <asp:TextBox ID="txtFecha" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>
                    <asp:Label ID="lblTurnoEmple" runat="server" Text="TurnoActual:"></asp:Label>    
                </td>
                <td>
                    <asp:TextBox ID="txtTurnoEmple" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblTurno" runat="server" Text="Turno:"></asp:Label>    
                </td>
                <td>
                    <asp:DropDownList ID="droTurnos" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="droTurnos_SelectedIndexChanged"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnActualizarTurno" runat="server" Text="Actualizar" 
                        onclick="btnActualizarTurno_Click" />
                </td>
                <td>
                    <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" OnClientClick="javascript:window.print();" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</asp:Content>
