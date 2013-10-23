<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="LibroAsistencia.aspx.cs" Inherits="ProyectoFinal.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <h1> Configuracion Libro de Asistencia </h1>
    <table> 
            <table style="width: 215px">
                <tr>
                    <td style="width: 155px" colspan="2">
                        Informe Por
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>   
                </tr>
                <tr>
                    <td>
                        Empresa:
                    </td>
                    <td>
                        <asp:RadioButton ID="RadioButton3" runat="server" />
                    </td>               
                </tr>
                <tr>
                    <td>
                        Gerencia:
                    </td> 
                    <td>
                        <asp:RadioButton ID="RadioButton2" runat="server" />
                    </td>              
                </tr>
                <tr>
                    <td>
                        Division:
                    </td> 
                    <td>
                        <asp:RadioButton ID="RadioButton1" runat="server" />
                    </td>              
                </tr>
                <tr>
                    <td>
                        Empleado:
                    </td>
                    <td>
                        <asp:RadioButton ID="radioEmpleado" runat="server" />
                    </td>            
                </tr>
            </table>
        </tr>
        
        <tr>
            <table>
                <tr>
                    <td colspan="2" style="height: 23px">
                        Rango de Fecha
                    </td>
                </tr>
                <tr>
                    <td>
                        Rango Inicial:
                    </td>
                    <td>
                        <asp:TextBox ID="txtRangoInicio" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Rango Fin:
                    </td>
                    <td>
                        <asp:TextBox ID="txtRangoFin" runat="server"></asp:TextBox>                
                    </td>
                </tr>
            </table>
        </tr>
      </tr>
      <tr>
        <td>
            <asp:DropDownList ID="dropDatosPorCargo" runat="server"></asp:DropDownList>        
        </td>
      </tr>
      <tr>
        <td>
            <asp:Button ID="BUTT" runat="server" onclick="BUTT_Click" />
        </td>
      </tr>
   </table>
    </form>
</asp:Content>
