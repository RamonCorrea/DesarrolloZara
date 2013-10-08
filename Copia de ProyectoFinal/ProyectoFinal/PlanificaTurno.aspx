<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PlanificaTurno.aspx.cs" Inherits="ProyectoFinal.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="javascript" type="text/javascript">
        function Open() 
        {
            window.open("ModificaTurno.aspx", "Modifica Turno", "width=350,height=400");
        }
    </script>
   <form runat="server" method="post">
    <table>
        <tr>
        <td>
            <div style="width: 183px">           
                <asp:Label ID="lblDato" runat="server" Visible="False"></asp:Label>
            </div>
        </td>
            <td style="width: 259px">
            <!-- DIV ENCARGADO DE CONTENER EL CALENDARIO -->
            <div>
                <asp:Calendar ID="Calendar2" runat="server" Height="25px" 
                Width="29px" onselectionchanged="Calendar2_SelectionChanged"></asp:Calendar>
            </div>
            </td>

            <td style="width: 666px; border-color:blue">
                <!-- DIV ENCARGADO DE MANTENER EL RELLENO DE DATOS PARA EL INGRESO DE LOS HORARIOS -->
                <div>
                    <table style="width: 632px">
                        <tr>
                            <td style="height: 33px; width: 195px;">
                                <asp:Label ID="lblSeccion" runat="server" Text="Seccion:" 
                                    style="text-align: right"></asp:Label>
                            </td>

                            <td style="width: 256px">
                               <asp:DropDownList ID="DropDownList3" runat="server"
                                    onselectedindexchanged="DropDownList3_SelectedIndexChanged1"
                                    DataSourceID="SqlDataSource1" DataTextField="DESC_AGRUPA" 
                                    DataValueField="COD_AGRUPA" AutoPostBack="True">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:ConexionBaseDatos %>" 
                                    
                                    SelectCommand="Select COD_AGRUPA, DESC_AGRUPA from P_AGRUPACION">
                                </asp:SqlDataSource>
                            </td>

                            <td style="width: 186px; height: 33px;">

                                &nbsp;</td>
                
                            <td style="height: 33px">
                                <asp:Button ID="btnBuscar" runat="server" Text="Buscar Empleado" 
                                    onclick="btnBuscar_Click" Width="125px"/>
                            </td>
                        </tr>

                        <tr>
                            <td style="width: 195px">
                                <asp:Label ID="lblCod_emple" runat="server" Text="Codigo Empleado:" 
                                    style="text-align: right"></asp:Label>
                            </td>

                            <td style="width: 256px">
                                <asp:TextBox ID="txtCodigo_emple" runat="server"></asp:TextBox>
                            </td>

                            <td style="width: 186px" colspan="2" >
                                <asp:Label ID="lblNombre" runat="server" Font-Bold="True" 
                                    Font-Names="Courier New" Font-Overline="False" Font-Size="Small" 
                                    Font-Strikeout="False"></asp:Label>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                         <tr>
                            <td style="width: 195px">
                                <asp:Label ID="lblFecha" runat="server" Text="Fecha Operar:" 
                                    style="text-align: right"></asp:Label>
                            </td>

                            <td style="width: 256px">
                                <asp:TextBox ID="txtFecha" runat="server" AutoPostBack="True"></asp:TextBox>
                                <asp:RequiredFieldValidator ControlToValidate="txtFecha" Display="Dynamic"
                                      ErrorMessage="Ingrese Fecha" runat="server" ID="vFecha">
                                 </asp:RequiredFieldValidator>
                            </td>
                            <td style="width: 186px">
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 195px"> 
                                <asp:Button ID="btnCarga" runat="server" Text="Listar Turno" 
                                    onclick="btnCarga_Click"/>
                            </td>
                            <td>
                                <asp:Button ID="btnLimpia" runat="server" Text="limpia" 
                                    onclick="btnLimpia_Click"/>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
      </table>

      <table>
        <tr>
            <td>
                <div>
                    <table style="width: 1069px; height: 81px;">
                        <tr>
                            <td colspan="3" align="center" style="height: 40px"> 
                                <h1 style="height: 31px; width: 770px"> Asignacion de Turnos </h1></td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:Table ID="ListaUsuario" BorderWidth="1" GridLines="Both" runat="server" 
                                    Width="787px" style="text-align: justify">
                                    <asp:TableRow> 
                                        <asp:TableHeaderCell HorizontalAlign="Center">Lunes</asp:TableHeaderCell>
                                        <asp:TableHeaderCell HorizontalAlign="Center">Martes</asp:TableHeaderCell>
                                        <asp:TableHeaderCell HorizontalAlign="Center">Miercoles</asp:TableHeaderCell>
                                        <asp:TableHeaderCell HorizontalAlign="Center">Jueves</asp:TableHeaderCell>
                                        <asp:TableHeaderCell HorizontalAlign="Center">Viernes</asp:TableHeaderCell>
                                        <asp:TableHeaderCell HorizontalAlign="Center">Sabado</asp:TableHeaderCell>
                                        <asp:TableHeaderCell HorizontalAlign="Center">Domingo</asp:TableHeaderCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </td>
                         </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</form>
</asp:Content>
