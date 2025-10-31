using Microsoft.Data.Sqlite;

namespace tl2_tp7_2025_nicoodiaz;

public class ProductoRepository
{
    private string cadenaConexion = "Data Source = Db/Tienda.db"; //Path de la BD

    public void CreateProduct(Productos producto)
    {
        string queryConsulta = "INSERT INTO Productos (Descripcion, Precio) VALUES (@Descripcion, @Precio)"; //Creo la consulta
        using var conection = new SqliteConnection(cadenaConexion); //Creo conexion
        conection.Open(); //Conecto

        var command = new SqliteCommand(queryConsulta, conection); //Ejecuto consulta
        command.Parameters.Add(new SqliteParameter("@Descripcion", producto.descripcion)); //Le paso los parametros a la consulta
        command.Parameters.Add(new SqliteParameter("@Precio", producto.precio));
        command.ExecuteNonQuery(); //Como no devuelve nada, ejecuto esto, si algo sale mal, tira excepcion
        conection.Close();//Desconecto
    }
    public void UpdateProduct(int idProduct, Productos productoActualizar)
    {
        string queryConsulta = "UPDATE Productos SET Descripcion = @Descripcion, Precio = @Precio WHERE idProducto = @id";
        using var conection = new SqliteConnection(cadenaConexion);
        conection.Open();

        var command = new SqliteCommand(queryConsulta, conection);
        command.Parameters.Add(new SqliteParameter("@Descripcion", productoActualizar.descripcion));
        command.Parameters.Add(new SqliteParameter("@Precio", productoActualizar.precio));
        command.ExecuteNonQuery();
        conection.Close();
    }

    public List<Productos> GetAllProductos()
    {
        string queryConsulta = "SELECT * FROM productos"; //Creo la consulta que quiero realizar
        List<Productos> productos = new List<Productos>(); //Creo la lista para guardar lo que trae la consulta

        using var conection = new SqliteConnection(cadenaConexion);//Creo la conexion mediante el path de la BD
        conection.Open(); //Me conecto

        var command = new SqliteCommand(queryConsulta, conection); //Ejecuto la consulta

        using (SqliteDataReader reader = command.ExecuteReader()) //Como es SELECT nos devuelve un DataReader para leerlo
        {
            while (reader.Read()) //Leo linea por linea
            {
                var producto = new Productos //Creo nuevos objetos con los datos obtenidos de la BD
                {
                    idProducto = Convert.ToInt32(reader["idProducto"]),
                    descripcion = reader["Descripcion"].ToString(),
                    precio = Convert.ToInt32(reader["Precio"])
                };
                productos.Add(producto); //Los guardo en la lista
            }
        }
        conection.Close(); //Cierro 
        return productos; //Devuelvo la lista
    }
    public Productos GetProductById(int idProduct)
    {
        string queryConsulta = "SELECT Descripcion, Precio FROM Productos WHERE idProducto = @id";
        Productos productoConsultado = null;

        using var conection = new SqliteConnection(cadenaConexion);
        conection.Open();

        using var command = new SqliteCommand(queryConsulta, conection);
        command.Parameters.Add(new SqliteParameter("@id", idProduct));

        using (SqliteDataReader reader = command.ExecuteReader())
        {
            if (reader.Read())
            {
                productoConsultado.descripcion = reader["Descripcion"].ToString();
                productoConsultado.precio = Convert.ToInt32(reader["Precio"]);
            }
        }
        conection.Close();
        return productoConsultado;
    }

    public void DeleteProduct(int idProduct)
    {
        string queryConsulta = "DELETE FROM Productos WHERE idProducto = @id";

        using var conection = new SqliteConnection(cadenaConexion);
        conection.Open();

        using var command = new SqliteCommand(queryConsulta, conection);
        command.Parameters.Add(new SqliteParameter("@id", idProduct));

        command.ExecuteNonQuery();
        conection.Close();
    }
}