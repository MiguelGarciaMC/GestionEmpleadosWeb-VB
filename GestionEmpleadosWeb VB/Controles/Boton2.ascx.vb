Partial Class Controles_Boton2
    Inherits System.Web.UI.UserControl

    Protected Sub btnPersonalizado2_Click(ByVal sender As Object, ByVal e As EventArgs)
        HttpContext.Current.Response.Write("¡Botón 2 presionado!<br/>")
    End Sub
End Class
