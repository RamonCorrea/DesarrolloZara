<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="ProyectoFinal.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server" style="font-weight: 700; text-align: center">
<br />
    Bienvenido al Sistema de Gestion de Asisten Web, Presione el boton 
    correspondiente a la accion que quiere realizar.<br />
<br />
<div align="center">
<table>
    <tr>
        <td>
          
            <asp:Button ID="btnPlaniTurno" runat="server" onclick="btnPlaniTurno_Click" 
                Text="Planificacion Turno" />
          
        </td>

         <td>
          
             <asp:Button ID="btnAsistencia" runat="server" onclick="btnAsistencia_Click" 
                 Text="Libro Asistencia" />
          
        </td>
    </tr>
</table>
</div>
    </form>
</asp:Content>
