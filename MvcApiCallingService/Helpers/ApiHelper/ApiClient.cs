﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MvcApiCallingService.Models.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace MvcApiCallingService.Helpers.ApiHelper
{
    public class ApiClient<T> : IApiClient<T>
    {
        private HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly ILogger<ApiClient<T>> _logger;

        public ApiClient(IConfiguration configuration, ILogger<ApiClient<T>> logger)
        {
            _configuration = configuration;
            _httpClient = new HttpClient() { BaseAddress = new Uri(_configuration.GetSection("BaseUrl").Value) };
            _logger = logger;
        }

        public async Task<PagedResponse<IEnumerable<T>>> GetPagedAsync(string apiUrl)
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync(apiUrl);

            if (!responseMessage.IsSuccessStatusCode)
                await RaiseException(responseMessage);
            return JsonConvert.DeserializeObject<PagedResponse<IEnumerable<T>>>(await responseMessage.Content.ReadAsStringAsync());
        }

        public async Task<Response<IEnumerable<T>>> GetAllAsync(string apiUrl)
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync(apiUrl);

            if (!responseMessage.IsSuccessStatusCode)
                await RaiseException(responseMessage);
            return JsonConvert.DeserializeObject<Response<IEnumerable<T>>>(await responseMessage.Content.ReadAsStringAsync());
        }

        //public async Task<Response<T>> GetByIdAsync(string apiUrl)
        //{
        //    HttpResponseMessage responseMessage = await _httpClient.GetAsync(apiUrl);
        //    return await ValidateResponse(responseMessage);
        //}

        public async Task<Response<T>> GetByIdAsync(string apiUrl)
        {
            _logger.LogInformation($"Sending GET request to {apiUrl}");
            HttpResponseMessage responseMessage = await _httpClient.GetAsync(apiUrl);
            return await ValidateResponse(responseMessage);
        }







        public async Task<Response<int>> PostAsync<TEntity>(string apiUrl, TEntity entity)
        {
            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(entity), System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await _httpClient.PostAsync(apiUrl, stringContent);
            if (responseMessage.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<Response<int>>(await responseMessage.Content.ReadAsStringAsync());
            return default;
        }
        // For Account
        public async Task<T?> PostAuthAsync<TEntity>(string apiUrl, TEntity entity)
        {
            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(entity), System.Text.Encoding.UTF8, "application/json");
            try
            {
                HttpResponseMessage responseMessage = await _httpClient.PostAsync(apiUrl, stringContent);
                if (responseMessage.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<T>(await responseMessage.Content.ReadAsStringAsync());

            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                throw new AuthenticationException($"{ex.Message}");
            }

            return default;
        }

        //public async Task<Response<T>> PutAsync<TEntity>(string apiUrl, TEntity entity)
        //{
        //    StringContent stringContent = new StringContent(JsonConvert.SerializeObject(entity), System.Text.Encoding.UTF8, "application/json");
        //    HttpResponseMessage responseMessage = await _httpClient.PutAsync(apiUrl, stringContent);
        //    return await ValidateResponse(responseMessage);
        //}

        public async Task PutAsync<TEntity>(string apiUrl, TEntity entity)
        {
            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(entity), System.Text.Encoding.UTF8, "application/json");
            try
            {
                HttpResponseMessage responseMessage = await _httpClient.PutAsync(apiUrl, stringContent);
                //return await ValidateResponse(responseMessage);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                throw new AuthenticationException($"{ex.Message}");

            }
        }


        public async Task<string> DeleteAsync(string apiUrl)
        {
            HttpResponseMessage responseMessage = await _httpClient.DeleteAsync(apiUrl);
            if (!responseMessage.IsSuccessStatusCode)
                await RaiseException(responseMessage);

            return await responseMessage.Content.ReadAsStringAsync();

        }

        public void AddHeaders(Dictionary<string, string> headers)
        {
            foreach (KeyValuePair<string, string> header in headers)
                _httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
        }

        async Task<Response<T>> ValidateResponse(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
                await RaiseException(response);
            return JsonConvert.DeserializeObject<Response<T>>(await response.Content.ReadAsStringAsync());
        }

        async Task RaiseException(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();
            response.Content?.Dispose();
            throw new HttpRequestException($"{response.StatusCode}:{content}");
        }

      
    }
}
