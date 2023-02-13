using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Domain.ViewModels;
using Persistence;
//using Oracle.ManagedDataAccess.Client;
using System.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Prj_CarPool.IServices.Services
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IHttpClientFactory _clientFactory;
        public Repository(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<bool> CreateAsync(string url, T obj, string token)
        {
            try
            {

                var request = new HttpRequestMessage(HttpMethod.Post, url);
                if (obj != null)
                {
                    request.Content = new StringContent(
                        JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
                }
                else
                {
                    return false;
                }
                var client = _clientFactory.CreateClient();
                if (token.Length != 0)
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                }
                HttpResponseMessage httpResponse = await client.SendAsync(request);
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
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

                return false;

            }
        }


        public async Task<bool> CreateAsynclist(string url, List<T> obj, string token)
        {
            try
            {

                var request = new HttpRequestMessage(HttpMethod.Post, url);
                var json =
                        JsonConvert.SerializeObject(obj);
                if (obj != null)
                {
                    request.Content = new StringContent(
                        JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
                }
                else
                {
                    return false;
                }
                var client = _clientFactory.CreateClient();
                if (token.Length != 0)
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                }
                HttpResponseMessage httpResponse = await client.SendAsync(request);
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
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

                return false;

            }

        }
        public async Task<string> CreateAsyncReturnID(string url, T obj, string token, string table, string colname)
        {
            try
            {

           
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            if (obj != null)
            {
                request.Content = new StringContent(
                    JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
            }
            else
            {
                return null;
            }
            var client = _clientFactory.CreateClient();
            if (token.Length != 0)
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }
            HttpResponseMessage httpResponse = await client.SendAsync(request);
            if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await httpResponse.Content.ReadAsStringAsync();
                var jo = JObject.Parse(jsonString);
                string sysid = jo[table][colname].ToString();
                return sysid;//  JsonConvert.DeserializeObject<T>(jsonString);



            }
            else
            {
                return null;
            }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<string> CreateAsyncJson(string url, T obj, string token)
        {
            try
            {

            
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            if (obj != null)
            {
                request.Content = new StringContent(
                    JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
            }
            else
            {
                return null;
            }
            var client = _clientFactory.CreateClient();
            if (token.Length != 0)
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }
            HttpResponseMessage httpResponse = await client.SendAsync(request);
            if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await httpResponse.Content.ReadAsStringAsync();

                return jsonString;



            }
            else
            {
                return null;
            }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<string> CreateAsync_list(string url, T obj, string token)
        {
            try
            {

            
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            if (obj != null)
            {
                request.Content = new StringContent(
                    JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
            }
            else
            {
                return null;
            }
            var client = _clientFactory.CreateClient();
            if (token.Length != 0)
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }
            HttpResponseMessage httpResponse = await client.SendAsync(request);
            if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await httpResponse.Content.ReadAsStringAsync();


                var jo = JObject.Parse(jsonString);
                string sysid = jo["studentRegistration"]["sysid"].ToString();
                return sysid;//  JsonConvert.DeserializeObject<T>(jsonString);



            }
            else
            {
                return null;
            }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> DeleteAsync(string url, int id, string token)
        {
            try
            {

           
            var request = new HttpRequestMessage(HttpMethod.Delete, url + id);

            var client = _clientFactory.CreateClient();
            if (token.Length != 0)
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }
            HttpResponseMessage httpResponse = await client.SendAsync(request);
            if (httpResponse.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return true;

            }
            else
            {
                return false;
            }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync(string url, string token = "")
        {
            try
            {


                var request = new HttpRequestMessage(HttpMethod.Get, url);

                var client = _clientFactory.CreateClient();
                if (token != null)
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                }
                HttpResponseMessage httpResponse = await client.SendAsync(request);
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonString = await httpResponse.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<IEnumerable<T>>(jsonString);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<string> GetLastConcessionCode(string url, string token = "")
        {
            try
            {


                var request = new HttpRequestMessage(HttpMethod.Get, url);

                var client = _clientFactory.CreateClient();
                if (token != null)
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                }
                HttpResponseMessage httpResponse = await client.SendAsync(request);
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonString = await httpResponse.Content.ReadAsStringAsync();
                    return jsonString;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<string> GetRollNo(string url, string id, string token = "")
        {
            try
            {


                var request = new HttpRequestMessage(HttpMethod.Get, url + id);

                var client = _clientFactory.CreateClient();
                if (token != null)
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                }
                HttpResponseMessage httpResponse = await client.SendAsync(request);
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonString = await httpResponse.Content.ReadAsStringAsync();
                    return jsonString;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<T> GetAsysnc(string url, int id, string token)
        {
            try
            {


                var request = new HttpRequestMessage(HttpMethod.Get, url + id);

                var client = _clientFactory.CreateClient();
                if (token.Length != 0)
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                }
                HttpResponseMessage httpResponse = await client.SendAsync(request);
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonString = await httpResponse.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(jsonString);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<T> GetAsysnc_string(string url, string id, string token)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, url + id);

                var client = _clientFactory.CreateClient();
                if (token.Length != 0)
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                }
                HttpResponseMessage httpResponse = await client.SendAsync(request);
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonString = await httpResponse.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(jsonString);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<IEnumerable<T>> GetAllAsyncList(string url, int id, string token)
        {
            try
            {


                var request = new HttpRequestMessage(HttpMethod.Get, url + id);

                var client = _clientFactory.CreateClient();
                if (token.Length != 0)
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                }
                HttpResponseMessage httpResponse = await client.SendAsync(request);
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonString = await httpResponse.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<IEnumerable<T>>(jsonString);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IEnumerable<T>> GetAllAsyncListbyString(string url, string id, string token)
        {
            try
            {


                var request = new HttpRequestMessage(HttpMethod.Get, url + id);

                var client = _clientFactory.CreateClient();
                if (token.Length != 0)
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                }
                HttpResponseMessage httpResponse = await client.SendAsync(request);
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonString = await httpResponse.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<IEnumerable<T>>(jsonString);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IEnumerable<T>> GetAsysnc_strings(string url, int bID, string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url + "?BranchID=" + bID);

            var client = _clientFactory.CreateClient();
            if (token.Length != 0)
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }
            HttpResponseMessage httpResponse = await client.SendAsync(request);
            if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await httpResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<T>>(jsonString);
            }
            else
            {
                return null;
            }
        }
        //GetAsysnc_stringClass
        public async Task<T> GetAsysnc_stringClass(string url, int id, int bID, int Cid, string token)
        {
            try
            {

                var request = new HttpRequestMessage(HttpMethod.Get, url + "?Cityid=" + id + "&BranchID=" + bID + "&ClassID=" + Cid);

                var client = _clientFactory.CreateClient();
                if (token.Length != 0)
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                }
                HttpResponseMessage httpResponse = await client.SendAsync(request);
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonString = await httpResponse.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(jsonString);
                }
                else
                {
                    return null;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<T> GetAsysnc_stringClassSess(string url, int id, int bID, int Cid, int SID, string token)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, url + "?Cityid=" + id + "&BranchID=" + bID + "&ClassID=" + Cid + "&SessionID=" + SID);

                var client = _clientFactory.CreateClient();
                if (token.Length != 0)
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                }
                HttpResponseMessage httpResponse = await client.SendAsync(request);
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonString = await httpResponse.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(jsonString);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }


        }
        public async Task<bool> UpdateAsync(string url, T obj, string token)
        {

            try
            {


                var request = new HttpRequestMessage(HttpMethod.Patch, url);
                if (obj != null)
                {
                    request.Content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
                }
                else
                {
                    return false;
                }
                var client = _clientFactory.CreateClient();


                if (token.Length != 0)
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                }

                HttpResponseMessage httpResponse = await client.SendAsync(request);
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {

                return false;
            }
        }


        public async Task<bool> UpdateAsync_Put(string url, T obj, string token)
        {

            try
            {


                var request = new HttpRequestMessage(HttpMethod.Put, url);
                if (obj != null)
                {
                    request.Content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
                }
                else
                {
                    return false;
                }
                var client = _clientFactory.CreateClient();
                if (token.Length != 0)
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                }
                HttpResponseMessage httpResponse = await client.SendAsync(request);
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        public async Task<string> UpdateAsync_list(string url, T obj, string token)
        {
            try
            {


                var request = new HttpRequestMessage(HttpMethod.Patch, url);
                if (obj != null)
                {
                    request.Content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
                }
                else
                {
                    return null;
                }
                var client = _clientFactory.CreateClient();
                if (token.Length != 0)
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                }
                HttpResponseMessage httpResponse = await client.SendAsync(request);
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonString = await httpResponse.Content.ReadAsStringAsync();


                    var jo = JObject.Parse(jsonString);
                    string sysid = jo["studentRegistration"]["sysid"].ToString();
                    return sysid;//  JsonConvert.DeserializeObject<T>(jsonString);



                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<bool> UpdateIsDelete_Put(string url, T obj, string token)
        {
            try
            {


                var request = new HttpRequestMessage(HttpMethod.Put, url);
                if (obj != null)
                {
                    request.Content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
                }
                else
                {
                    return false;
                }
                var client = _clientFactory.CreateClient();
                if (token.Length != 0)
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                }
                HttpResponseMessage httpResponse = await client.SendAsync(request);
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }



        }

    }
}
