<%@ Page Language="vb" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register TagPrefix="uc1" TagName="Boton" Src="~/Controles/Boton.ascx" %>
<%@ Register TagPrefix="uc2" TagName="Boton2" Src="~/Controles/Boton2.ascx" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gestión de Empleados</title>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server" />

        <div>
            <h2>Agregar Nuevo Empleado</h2>

            <telerik:RadTextBox ID="txtNombre" runat="server" Label="Nombre:" Width="200px" />
            <br />
            <telerik:RadNumericTextBox ID="txtSalario" runat="server" Label="Salario:" Width="200px">
                <NumberFormat DecimalDigits="2" />
            </telerik:RadNumericTextBox>
            <br /><br />
            <asp:Button ID="btnInsertar" runat="server" Text="Agregar Empleado" OnClick="btnInsertar_Click" />
            <asp:Button ID="btnRecargar" runat="server" Text="Recargar" OnClick="btnRecargar_Click" />
        </div>

        <br /><hr /><br />

        <h2>Listado de Empleados</h2>
        <telerik:RadGrid ID="RadGrid1" runat="server"
            AllowPaging="true" PageSize="10"
            AllowFilteringByColumn="true"
            AllowSorting="true"
            AutoGenerateColumns="True"
            OnNeedDataSource="RadGrid1_NeedDataSource"
            OnUpdateCommand="RadGrid1_UpdateCommand"
            OnDeleteCommand="RadGrid1_DeleteCommand">
            <MasterTableView DataKeyNames="Id" CommandItemDisplay="Top" EditMode="InPlace">
                <Columns>
                    <telerik:GridBoundColumn DataField="Id" HeaderText="ID" ReadOnly="true" UniqueName="Id" />
                    <telerik:GridBoundColumn DataField="Nombre" HeaderText="Nombre" UniqueName="Nombre" />
                    <telerik:GridBoundColumn DataField="Salario" HeaderText="Salario" DataFormatString="{0:C}" UniqueName="Salario" />
                    <telerik:GridEditCommandColumn ButtonType="ImageButton" />
                    <telerik:GridButtonColumn CommandName="Delete" Text="Eliminar" ButtonType="ImageButton" />
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>

        <br /><hr /><br />

        <h2>Controles Personalizados</h2>
        <uc1:Boton ID="Boton1" runat="server" />
        <uc2:Boton2 ID="Boton2" runat="server" />
    </form>
</body>
</html>
