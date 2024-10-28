//using rootear.mvvm.Models;
//using rootear.Utils;
//using System.Text;
//using System.Text.Json;

//namespace rootear.mvvm.Services;

//public class ReservaService : IReservaService
//{
//    HttpClient client;

//    private static JsonSerializerOptions options = new()
//    {
//        PropertyNameCaseInsensitive = true
//    };
//    public ReservaService()
//    {
//        client = new HttpClient();
//    }
//    public async Task<Carrito> GetCarritoPorId(int idUsuario)
//    {
//        try
//        {
//            var response = await client.GetAsync($"{Constants.CarritoEndpoint}/{idUsuario}");
//            if (response.StatusCode == System.Net.HttpStatusCode.OK)
//            {
//                var jsonData = await response.Content.ReadAsStringAsync();
//                if (!string.IsNullOrWhiteSpace(jsonData))
//                {
//                    var responseObject = JsonSerializer.Deserialize<Carrito>(jsonData, new JsonSerializerOptions
//                    {
//                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
//                        WriteIndented = true
//                    });

//                    return responseObject!;
//                }
//                else
//                {
//                    throw new Exception("No se encontraron datos.");
//                }
//            }
//            else
//            {
//                throw new Exception($"Falló la petición con el código de estado {response.StatusCode}");
//            }
//        }
//        catch (Exception exception)
//        {
//            throw new Exception($"Error al obtener el carrito del usuario: {exception.Message}");
//        }
//    }
//    public async Task<IEnumerable<ProductoCarrito>> GetProductoCarritoPorId(int id)
//    {
//        try
//        {
//            var response = await client.GetAsync($"{Constants.ProductoCarritoEndpoint}/{Transport.IdUsuario}");
//            if (response.StatusCode == System.Net.HttpStatusCode.OK)
//            {
//                var jsonData = await response.Content.ReadAsStringAsync();
//                if (!string.IsNullOrWhiteSpace(jsonData))
//                {
//                    // Deserializar como una lista de ProductoCarrito
//                    var responseObject = JsonSerializer.Deserialize<IEnumerable<ProductoCarrito>>(jsonData,
//                        new JsonSerializerOptions
//                        {
//                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
//                            WriteIndented = true
//                        });
//                    return responseObject!;
//                }
//                else
//                {
//                    throw new Exception("Resource Not Found");
//                }
//            }
//            else
//            {
//                throw new Exception("Request failed with status code " + response.StatusCode);
//            }
//        }
//        catch (Exception exception)
//        {
//            throw new Exception(exception.Message);
//        }
//    }
//    public async Task<bool> AgregarAlCarrito(ProductoCarritoDTO _producto)
//    {
//        try
//        {

//            var serializedProduct = JsonSerializer.Serialize(_producto);
//            var content = new StringContent(
//                serializedProduct,
//                Encoding.UTF8,
//                "application/json"
//            );

//            // Realiza la llamada POST
//            var response = await client.PostAsync(Constants.ProductoCarritoAgregarEndpoint, content).ConfigureAwait(false);

//            // Verifica el resultado
//            if (response.IsSuccessStatusCode)
//            {
//                return true; // Se ha agregado exitosamente
//            }
//            else
//            {
//                // Log de error
//                var responseContent = await response.Content.ReadAsStringAsync();
//                Console.WriteLine($"Error: {response.StatusCode}, Detalles: {responseContent}");
//                return false; // Error al agregar
//            }
//        }
//        catch (Exception ex)
//        {
//            throw new Exception(ex.Message);
//        }
//    }
//    public async Task<bool> ModificarCarro(int idUsuario, Carrito carro)
//    {
//        try
//        {
//            // Serializamos el objeto modificado a JSON
//            var jsonProducto = JsonSerializer.Serialize(carro, new JsonSerializerOptions
//            {
//                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
//                WriteIndented = true
//            });

//            // Creamos el contenido que se enviará en la solicitud PUT
//            var content = new StringContent(jsonProducto, Encoding.UTF8, "application/json");

//            // Realizamos la solicitud PUT al endpoint específico
//            var response = await client.PutAsync($"{Constants.ModificaCarroEndpoint}/{idUsuario}", content);

//            // Verificamos si la respuesta es exitosa
//            if (response.StatusCode == System.Net.HttpStatusCode.NoContent ||
//                response.StatusCode == System.Net.HttpStatusCode.OK)
//            {
//                return true; // Se modificó correctamente
//            }
//            else
//            {
//                Exception exception = new Exception($"Error al modificar el producto. Código de estado: {response.StatusCode}");
//                throw new Exception(exception.Message);
//            }
//        }
//        catch (Exception exception)
//        {
//            throw new Exception($"Error en la solicitud: {exception.Message}");
//        }
//    }
//    public async Task<bool> EliminarProductoAsync(EliminarProductoCarritoDTO dto)
//    {
//        try
//        {
//            // Serializamos el objeto a JSON
//            var jsonProducto = JsonSerializer.Serialize(dto, new JsonSerializerOptions
//            {
//                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
//                WriteIndented = true
//            });

//            // Creamos el contenido JSON para enviarlo en la solicitud
//            var content = new StringContent(jsonProducto, Encoding.UTF8, "application/json");

//            // Construimos la solicitud de tipo DELETE con un cuerpo JSON
//            var request = new HttpRequestMessage
//            {
//                Method = HttpMethod.Delete,
//                RequestUri = new Uri(Constants.EliminarProductoDElCarroEndpoint),
//                Content = content
//            };

//            // Enviamos la solicitud
//            var response = await client.SendAsync(request);

//            // Verificamos si la solicitud fue exitosa
//            return response.IsSuccessStatusCode;
//        }
//        catch (Exception)
//        {
//            // Manejo de errores, en este caso devolvemos false si falla
//            return false;
//        }
//    }
//}