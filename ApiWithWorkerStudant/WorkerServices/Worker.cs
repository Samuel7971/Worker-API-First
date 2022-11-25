using ApiWithWorkerRespository;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace WorkerServices
{
    public class Worker : IHostedService
    {
        private int executionCount;
        private string message = string.Empty;
        private Timer _timer;
        private ICommandRepository _commandRepository;

        public Worker(ICommandRepository commandRepository)
        {
            _commandRepository = commandRepository;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine($"Teste Worker: {nameof(Worker)}");

            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            message = "Ola eu sou o Woker!!";
            var count = Interlocked.Increment(ref executionCount);
            Console.WriteLine($"Data e Hora: {DateTime.Now:o} => Mensagem: {_commandRepository.GetMessage()} -- Contador: {count}");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine($"Finalizando: {nameof(Worker)}");
            return Task.CompletedTask;
        }
    }
}
