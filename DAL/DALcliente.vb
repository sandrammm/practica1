Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Web
Imports LayerEntyty

Public Class DALcliente
    Dim cnn As New SqlClient.SqlConnection(clsconexion.cadcon)
    Public Function agregarcliente(micliente As LayerEntyty.clscliente) As Boolean
        Dim cnn As New SqlConnection(DAL.clsconexion.cadcon)
        Dim cmd As New SqlCommand("SP_INSERTAR_CLIENTE", cnn)

        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("ID_CLIENTE", SqlDbType.Int).Value = micliente.ID_CLIENTE
        cmd.Parameters.Add("NOMBRE", SqlDbType.NVarChar, 100).Value = micliente.NOMBRE
        cmd.Parameters.Add("SEXO", SqlDbType.NChar, 1).Value = micliente.SEXO
        cmd.Parameters.Add("EDAD", SqlDbType.Int).Value = micliente.EDAD
        cmd.Parameters.Add("OBSERVACIONES", SqlDbType.NVarChar, 100).Value = micliente.OBSERVACIONES

        Try
            If cnn.State = ConnectionState.Closed Then
                cnn.Open()

            End If

            cmd.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Return False
        End Try
        cnn.Close()




    End Function

    Public Sub modificarcliente(ByVal ID_CLIENTE As Integer, ByRef NOMBRE As String, ByRef SEXO As String, ByRef EDAD As Integer, ByRef OBSERVACIONES As String)
        Dim cnn As New SqlClient.SqlConnection(clsconexion.cadcon)
        Dim cmd As New SqlClient.SqlCommand("SP_MODIFICAR", cnn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("ID_CLIENTE", SqlDbType.Int).Value = ID_CLIENTE
        cmd.Parameters.Add("NOMBRE", SqlDbType.NVarChar, 100).Value = NOMBRE
        cmd.Parameters.Add("SEXO", SqlDbType.NChar, 1).Value = SEXO
        cmd.Parameters.Add("EDAD", SqlDbType.Int).Value = EDAD
        cmd.Parameters.Add("OBSERVACIONES", SqlDbType.NVarChar, 100).Value = OBSERVACIONES

        Try
            cnn.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception

        End Try
        cnn.Close()

    End Sub

    Public Sub buscarcliente(ByVal ID_CLIENTE As Integer, ByRef NOMBRE As String, ByRef SEXO As String, ByRef EDAD As Integer, ByRef OBSERVACIONES As String)
        Dim cnn As New SqlClient.SqlConnection(clsconexion.cadcon)
        Dim cmd As New SqlClient.SqlCommand("SP_BUSCAR_CLIENTE", cnn)

        cmd.Parameters.Add("ID_CLIENTE", SqlDbType.Int).Value = ID_CLIENTE
        cmd.CommandType = CommandType.StoredProcedure

        Try
            cnn.Open()
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader

            If dr.hasrows Then
                dr.read()
                NOMBRE = dr(0).ToString
                SEXO = dr(1).ToString
                EDAD = dr(2).ToString
                OBSERVACIONES = dr(3).ToString



            End If
            cmd.ExecuteNonQuery()
            dr.close()

        Catch ex As Exception


        End Try
        cnn.Close()
    End Sub


    Public Sub eliminarcliente(ByVal ID_CLIENTE As Integer, ByRef NOMBRE As String, ByRef SEXO As String, ByRef EDAD As Integer, ByRef OBSERVACIONES As String)
        Dim cnn As New SqlClient.SqlConnection(clsconexion.cadcon)
        Dim cmd As New SqlClient.SqlCommand("SP_ELIMINAR_CLIENTE", cnn)
        cmd.Parameters.Add("ID_CLIENTE", SqlDbType.Int).Value = ID_CLIENTE
        cmd.CommandType = CommandType.StoredProcedure

        Try
            cnn.Open()
        Catch ex As Exception

        End Try

        cnn.Close()
    End Sub


End Class

