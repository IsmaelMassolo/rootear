using rootear.Services;
using System.Text;
using System.Text.Json;
using rootear.Utils;
using rootear.mvvm.Models.DTO;

namespace rootear.Services
{
    public class LoginService : ILoginService
    {
        HttpClient client;
        public LoginService()
        {
            client = new HttpClient();
        }

        public async Task<LoginDTO?> ValidarLogin(string _password, string _usuarioNombre)
        {
            try
            {
                var json = JsonSerializer.Serialize(new
                {
                    contrasena = _password,
                    usuarioNombre = _usuarioNombre
                });

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var result = await client.PostAsync(Constants.ValidarCredencialEndpoint, content).ConfigureAwait(false);

                if (result.IsSuccessStatusCode)
                {
                    var jsonData = await result.Content.ReadAsStringAsync();
                    if (!string.IsNullOrWhiteSpace(jsonData))
                    {
                        var responseObject = JsonSerializer.Deserialize<LoginDTO>(jsonData,
                            new JsonSerializerOptions
                            {
                                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                                WriteIndented = true
                            });
                        return responseObject;
                    }
                    else
                    {
                        throw new Exception("No se recibieron datos de autenticación.");
                    }
                }
                else
                {
                    // Aquí capturamos el contenido del error devuelto por la API
                    var errorContent = await result.Content.ReadAsStringAsync();
                    throw new Exception(errorContent);  // Lanza la excepción con el mensaje de la API
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al autenticar: {ex.Message}");
            }
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
    }
}