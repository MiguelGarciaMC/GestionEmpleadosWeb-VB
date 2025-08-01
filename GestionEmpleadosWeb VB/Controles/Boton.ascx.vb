Partial Class Controles_Boton
    Inherits System.Web.UI.UserControl

    Protected Sub btnPersonalizado_Click(ByVal sender As Object, ByVal e As EventArgs)
        HttpContext.Current.Response.Write("¡Botón 1 presionado!<br/>")
    End Sub
End Class