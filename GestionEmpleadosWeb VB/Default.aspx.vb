Imports System.Configuration
Imports System.Data
Imports System.Data.Odbc

Partial Class _Default
    Inherits System.Web.UI.Page

    Dim connStr As String = ConfigurationManager.ConnectionStrings("MiConexionODBC").ConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ObtenerEmpleados()
        End If
    End Sub

    Private Function ObtenerEmpleados() As DataTable
        Using conn As New OdbcConnection(connStr)
            Dim adapter As New OdbcDataAdapter("SELECT * FROM Empleados", conn)
            Dim tabla As New DataTable()
            adapter.Fill(tabla)
            Return tabla
        End Using
    End Function


    Protected Sub RadGrid1_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs)
        RadGrid1.DataSource = ObtenerEmpleados()
    End Sub

    Protected Sub btnInsertar_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Insertar nuevo empleado en la base
        If txtNombre.Text <> "" AndAlso txtSalario.Value.HasValue Then
            Using conn As New OdbcConnection(connStr)
                conn.Open()
                Dim cmd As New OdbcCommand("INSERT INTO Empleados (Nombre, Salario) VALUES (?, ?)", conn)
                cmd.Parameters.AddWithValue("?", txtNombre.Text)
                cmd.Parameters.AddWithValue("?", txtSalario.Value.Value)
                cmd.ExecuteNonQuery()
            End Using
            RadGrid1.Rebind()
        Else
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Completa todos los campos.');", True)
        End If
    End Sub

    Protected Sub btnRecargar_Click(ByVal sender As Object, ByVal e As EventArgs)
        ObtenerEmpleados()

    End Sub

    Protected Sub RadGrid1_UpdateCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs)
        Dim item As Telerik.Web.UI.GridEditableItem = CType(e.Item, Telerik.Web.UI.GridEditableItem)
        Dim id As Integer = Convert.ToInt32(item.GetDataKeyValue("Id"))
        Dim nombre As String = CType(item("Nombre").Controls(0), TextBox).Text
        Dim salario As Decimal = Convert.ToDecimal(CType(item("Salario").Controls(0), TextBox).Text)

        Using conn As New OdbcConnection(connStr)
            conn.Open()
            Dim cmd As New OdbcCommand("UPDATE Empleados SET Nombre = ?, Salario = ? WHERE Id = ?", conn)
            cmd.Parameters.AddWithValue("?", nombre)
            cmd.Parameters.AddWithValue("?", salario)
            cmd.Parameters.AddWithValue("?", id)
            cmd.ExecuteNonQuery()
        End Using
        ObtenerEmpleados()
    End Sub

    Protected Sub RadGrid1_DeleteCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs)
        Dim id As Integer = Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues(e.Item.ItemIndex)("Id"))

        Using conn As New OdbcConnection(connStr)
            conn.Open()
            Dim cmd As New OdbcCommand("DELETE FROM Empleados WHERE Id = ?", conn)
            cmd.Parameters.AddWithValue("?", id)
            cmd.ExecuteNonQuery()
        End Using
        ObtenerEmpleados()
    End Sub
End Class
