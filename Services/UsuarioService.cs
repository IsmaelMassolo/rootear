using rootear.mvvm.Models;
using rootear.mvvm.Models.DTO;
using rootear.Utils;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;


namespace rootear.Services;

public class UsuarioService : IUsuarioService
{
    HttpClient client;

    private static JsonSerializerOptions options = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public UsuarioService()
    {
        client = new HttpClient();
    }

    public async Task<IEnumerable<Usuario>> GetUsersAsync()
    {
        var response = await client.GetAsync(Constants.ObtenerUsuariosEndpoint);

        if (response.IsSuccessStatusCode)
        return await response.Content.ReadFromJsonAsync<IEnumerable<Usuario>>(options);
        return default;
    }


    public async Task<bool> AgregarUsuario(UsuarioDTO _usuario)
    {
        try
        {
            var content = new StringContent(
                    JsonSerializer.Serialize(_usuario),
                    Encoding.UTF8, "application/json"
            );

            var result = await client.PostAsync(Constants.CrearUsuarioEndpoint, content).ConfigureAwait(false);



            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }


    public async Task<bool> SubirImagen(UsuarioDTO registro)
    {
        try
        {
            string extension = Path.GetExtension(registro.RutaImagen);
            string nuevoNombre = $"{registro.UsuarioNombre}{extension}";
            string rutaTemporal = Path.Combine(Path.GetTempPath(), nuevoNombre); 

            File.Copy(registro.RutaImagen, rutaTemporal, true);

            using (var stream = File.OpenRead(rutaTemporal))
            {
                var content = new MultipartFormDataContent();
                var imageContent = new StreamContent(stream);
                imageContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/png");
                content.Add(imageContent, "Archivo", nuevoNombre);

                var result = await client.PostAsync(Constants.GuardarImagenUsuarioEndpoint, content);
                return result.IsSuccessStatusCode;
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Error al subir la imagen: " + ex.Message);
        }
    }


    public async Task<bool> DeshabilitarUsuarioAsync(Usuario usuario)
    {
        try
        {
            var content = new StringContent(
                    JsonSerializer.Serialize(usuario),
                    Encoding.UTF8, "application/json"
            );

            var result = await client.PutAsync($"{Constants.DeshabilitarUsuarioEndpoint}/{usuario.IdUsuario}", content);

            return result.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<bool> ActualizarUsuarioAsync(Usuario usuario)
    {
        try
        {
            var content = new StringContent(
                    JsonSerializer.Serialize(usuario),
                    Encoding.UTF8, "application/json"
            );

            var result = await client.PutAsync($"{Constants.ModificarUsuarioEndpoint}/{usuario.IdUsuario}", content);

            return result.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<Usuario> GetPorId(int idUsuario)
    {
        try
        {
            var response = await client.GetAsync($"{Constants.ObtenerUsuarioEndpoint}/{idUsuario}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Usuario>(json, options); // Usa opciones de serialización.


            }
            return null;
        }
        catch (Exception ex)
        {
            // Manejo de excepción según necesidad
            throw new Exception("Error al obtener el usuario", ex);
        }
    }

}