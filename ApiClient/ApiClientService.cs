using ApiClient.Models;
using ApiClient.Models.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ApiClient
{
    public class ApiClientService
    {
        //responsible for sending and receiving HTTP responses and Requests
        private HttpClient _httpClient;

        public ApiClientService(ApiClientOptions clientOptions)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress=new Uri(clientOptions.ApiBaseAddress);
        }

        //get the list of all tasks
        public async Task<List<TodoTask>?> GetTasks()
        {
            return await _httpClient.GetFromJsonAsync<List<TodoTask>?>("/api/Task");
        }
        //get task by id
        public async Task<TodoTask?> GetTaskById(int id)
        {
            return await _httpClient.GetFromJsonAsync<TodoTask?>($"/api/Task{id}");
        }
        //please note a method that is of type Task doesn't return anything, task denotes that it will complete the work
        public async Task CreateTask(TodoTask todoTask)
        {
             await _httpClient.PostAsJsonAsync("/api/Task",todoTask);
        }
        //Updating the product through the product
        public async Task UpdateTask(TodoTask todoTask)
        {
            await _httpClient.PutAsJsonAsync("/api/Task",todoTask);
        }

        //Delete the product using the id of the product
        public async Task DeleteTask(int id)
        {
            await _httpClient.DeleteAsync($"/api/Task{id}");
        }
    }
}
