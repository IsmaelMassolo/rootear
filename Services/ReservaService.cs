using rootear.mvvm.Models;
using rootear.mvvm.Models.DTO;
using rootear.Utils;
using System.Text;
using System.Text.Json;

namespace rootear.Services;

public class ReservaService : IReservaService
{
    HttpClient client;

    private static JsonSerializerOptions options = new()
    {
        PropertyNameCaseInsensitive = true
    };
    public ReservaService()
    {
        client = new HttpClient();
    }
    public async Task<Reserva> GetReservasPorId(int idUsuario) //sala de reserva
    {
        try
        {
            var response = await client.GetAsync($"{Constants.ReservasEndpoint}/{idUsuario}");
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrWhiteSpace(jsonData))
                {
                    var responseObject = JsonSerializer.Deserialize<Reserva>(jsonData, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                        WriteIndented = true
                    });

                    return responseObject!;
                }
                else
                {
                    throw new Exception("No se encontraron datos.");
                }
            }
            else
            {
                throw new Exception($"Falló la petición con el código de estado {response.StatusCode}");
            }
        }
        catch (Exception exception)
        {
            throw new Exception($"Error al obtener el la sala de reserva del usuario: {exception.Message}");
        }
    }

    public async Task<IEnumerable<DetalleReserva>> GetDetalleReservaPorId(int id)
    {
        try
        {
            var response = await client.GetAsync($"{Constants.DetalleReservaEndpoint}/{Transport.IdUsuario}");
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrWhiteSpace(jsonData))
                {
                    var responseObject = JsonSerializer.Deserialize<IEnumerable<DetalleReserva>>(jsonData,
                        new JsonSerializerOptions
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                            WriteIndented = true
                        });
                    return responseObject!;
                }
                else
                {
                    throw new Exception("Recurso no encontrado");
                }
            }
            else
            {
                throw new Exception("Request failed with status code " + response.StatusCode);
            }
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
        }
    }

    public async Task<bool> AgregarA_DetalleReserva(DetalleReservaDTO _detalleReserva)
    {
        try
        {
            var serializedProduct = JsonSerializer.Serialize(_detalleReserva);
            var content = new StringContent(
                serializedProduct,
                Encoding.UTF8,
                "application/json"
            );


            var response = await client.PostAsync(Constants.AgregarEnReservaEndpoint, content).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error: {response.StatusCode}, Detalles: {responseContent}");
                return false;
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    //public async Task<bool> ModificarCarro(int idUsuario, Reserva carro)
    //{
    //    try
    //    {
    //        // Serializamos el objeto modificado a JSON
    //        var jsonViaje = JsonSerializer.Serialize(carro, new JsonSerializerOptions
    //        {
    //            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    //            WriteIndented = true
    //        });

    //        // Creamos el contenido que se enviará en la solicitud PUT
    //        var content = new StringContent(jsonViaje, Encoding.UTF8, "application/json");

    //        // Realizamos la solicitud PUT al endpoint específico
    //        var response = await client.PutAsync($"{Constants.ModificaCarroEndpoint}/{idUsuario}", content);

    //        // Verificamos si la respuesta es exitosa
    //        if (response.StatusCode == System.Net.HttpStatusCode.NoContent ||
    //            response.StatusCode == System.Net.HttpStatusCode.OK)
    //        {
    //            return true; // Se modificó correctamente
    //        }
    //        else
    //        {
    //            Exception exception = new Exception($"Error al modificar el viaje. Código de estado: {response.StatusCode}");
    //            throw new Exception(exception.Message);
    //        }
    //    }
    //    catch (Exception exception)
    //    {
    //        throw new Exception($"Error en la solicitud: {exception.Message}");
    //    }
    //}

    //public async Task<bool> EliminarViajeAsync(EliminarDetalleReservaDTO dto)
    //{
    //    try
    //    {
    //        var jsonViaje = JsonSerializer.Serialize(dto, new JsonSerializerOptions
    //        {
    //            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    //            WriteIndented = true
    //        });

    //        var content = new StringContent(jsonViaje, Encoding.UTF8, "application/json");

    //        var request = new HttpRequestMessage
    //        {
    //            Method = HttpMethod.Delete,
    //            RequestUri = new Uri(Constants.EliminarDetalleReservaEndpoint),
    //            Content = content
    //        };

    //        var response = await client.SendAsync(request);

    //        return response.IsSuccessStatusCode;
    //    }
    //    catch (Exception)
    //    {
    //        return false;
    //    }
    //}
}