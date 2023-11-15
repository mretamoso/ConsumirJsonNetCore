namespace WebApplication2.Controllers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

public class UserController:Controller
    {

    [HttpGet("api/User/GetAll")]
    [Produces("application/json")]
    public async Task<IActionResult> GetAll()
    {
       
        string apiUrl = "https://jsonplaceholder.typicode.com/users";

        using (HttpClient httpClient = new HttpClient())
        {
            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                List<UsuariosModel> userList = JsonConvert.DeserializeObject<List<UsuariosModel>>(jsonString);

                return new JsonResult(userList);
            }
            else
            {
                return StatusCode((int)response.StatusCode, "Error al obtener los usuarios");
            }
        }
    }

}

