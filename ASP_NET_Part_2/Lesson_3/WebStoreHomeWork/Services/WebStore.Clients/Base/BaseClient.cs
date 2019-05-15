using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace WebStore.Clients.Base
{
    public abstract class BaseClient
    {
        protected readonly HttpClient _Client;

        protected string ServiceAddress { get; }

        protected BaseClient(IConfiguration configuration, string ServiceAdress)
        {
            this.ServiceAddress = ServiceAdress;

            _Client = new HttpClient
            {
                BaseAddress = new Uri(configuration["ClientAddress"])
            };

            _Client.DefaultRequestHeaders.Accept.Clear();
            _Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
