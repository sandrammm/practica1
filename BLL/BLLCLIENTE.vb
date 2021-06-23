Public Class BLLCLIENTE
    Dim midalcliente As New DAL.DALcliente
    Public Function agregarcliente(micliente As LayerEntyty.clscliente) As Boolean

        Return midalcliente.agregarcliente(micliente)
    End Function
End Class
