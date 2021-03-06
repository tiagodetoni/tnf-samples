﻿using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Transactional.Infra.Context;

namespace Transactional.Web.HostedServices
{
    public class MigrationHostedService : IHostedService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public MigrationHostedService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var purchaseOrderContext = scope.ServiceProvider.GetService<PurchaseOrderContext>();

            await purchaseOrderContext.Database.MigrateAsync();
        }

        public Task StopAsync(CancellationToken cancellationToken)
            => Task.CompletedTask;
    }
}
