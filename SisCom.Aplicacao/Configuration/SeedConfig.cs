using Microsoft.Extensions.Hosting;
using SisCom.Infraestrutura.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SisCom.Aplicacao.Configuration
{
    public class SeedConfig : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;
        public SeedConfig(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {

        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}