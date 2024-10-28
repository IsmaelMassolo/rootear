//using rootear.mvvm.Models;
//using System.Net.Http.Headers;
//using System.Text.Json;
//using System.Net.Http.Json;
//using rootear.Utils;
//using System.Net.Http;
//using System.Text;

//namespace rootear.mvvm.Services;

//public class ViajeService : IViajeService
//{
//    HttpClient client;
//    static HttpClient httpClient = new HttpClient() { Timeout = TimeSpan.FromSeconds(60) };

//    public ViajeService()
//    {
//        client = new HttpClient();
//    }

//    public async Task<IEnumerable<Producto>> GetProductos()
//    {
//        try
//        {
//            var response = await client.GetAsync(Constants.ProductsEndpoint);
//            if (response.StatusCode == System.Net.HttpStatusCode.OK)
//            {
//                var jsonData = await response.Content.ReadAsStringAsync();
//                if (!string.IsNullOrWhiteSpace(jsonData))
//                {
//                    var responseObject = JsonSerializer.Deserialize<List<Producto>>(jsonData,
//                        new JsonSerializerOptions
//                        {
//                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
//                            WriteIndented = true
//                        });
//                    return responseObject!;
//                }
//                else
//                {
//                    Exception exception = new Exception("Resource Not Found");
//                    throw new Exception(exception.Message);
//                }
//            }
//            else
//            {
//                Exception exception = new Exception("Request failed with status code " + response.StatusCode);
//                throw new Exception(exception.Message);
//            }
//        }
//        catch (Exception exception)
//        {
//            throw new Exception(exception.Message);
//        }
//    }

//    public async Task<Producto> GetProductoPorId(int id)
//    {
//        try
//        {
//            var response = await client.GetAsync(Constants.ProductsEndpoint);
//            if (response.StatusCode == System.Net.HttpStatusCode.OK)
//            {
//                var jsonData = await response.Content.ReadAsStringAsync();
//                if (!string.IsNullOrWhiteSpace(jsonData))
//                {
//                    // Inside the ApiService class
//                    var responseObject = JsonSerializer.Deserialize<Producto>(jsonData,
//                        new JsonSerializerOptions
//                        {
//                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
//                            WriteIndented = true
//                        });
//                    return responseObject!;
//                }
//                else
//                {
//                    Exception exception = new Exception("Resource Not Found");
//                    throw new Exception(exception.Message);
//                }
//            }
//            else
//            {
//                Exception exception = new Exception("Request failed with status code " + response.StatusCode);
//                throw new Exception(exception.Message);
//            }
//        }
//        catch (Exception exception)
//        {
//            throw new Exception(exception.Message);
//        }
//    }

//    public async Task<bool> AgregarProducto(ProductoDTO _producto)
//    {
//        try
//        {
//            var content = new StringContent(
//                    JsonSerializer.Serialize(_producto),
//                    Encoding.UTF8, "application/json"
//                );

//            var result = await httpClient.PostAsync(Constants.ProductsGrabarEndpoint, content).ConfigureAwait(false);

//            if (result.StatusCode == System.Net.HttpStatusCode.OK)
//            {
//                return true;
//            }
//            else
//            {
//                return false;
//            }

//        }
//        catch (Exception ex)
//        {
//            throw new Exception(ex.Message);
//        }
//    }

//    public async Task<bool> EliminarProductoAsync(int id)
//    {
//        var response = await client.DeleteAsync($"{Constants.ProductsEndpoint}/{id}");


//        return response.IsSuccessStatusCode;
//    }


//    public async Task<bool> SubirImagen(ProductoDTO registro)
//    {
//        try
//        {
//            // Generar un nuevo nombre basado en el título
//            string extension = Path.GetExtension(registro.RutaImagenLocal);
//            string nuevoNombre = $"{registro.Titulo}{extension}"; // Usa el título del registro
//            string rutaTemporal = Path.Combine(Path.GetTempPath(), nuevoNombre); // Ruta temporal

//            // Copiar el archivo a la nueva ruta con el nuevo nombre
//            File.Copy(registro.RutaImagenLocal, rutaTemporal, true);

//            using (var stream = File.OpenRead(rutaTemporal))
//            {
//                var content = new MultipartFormDataContent();
//                var imageContent = new StreamContent(stream);
//                imageContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/png");
//                content.Add(imageContent, "Archivo", nuevoNombre); // Usa el nuevo nombre al agregar

//                var result = await httpClient.PostAsync(Constants.GuardarImagenEndpoint, content);
//                return result.IsSuccessStatusCode;
//            }
//        }
//        catch (Exception ex)
//        {
//            throw new Exception("Error al subir la imagen: " + ex.Message);
//        }
//    }

//}