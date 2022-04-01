using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utis.EmployeeTest.Client.Models;
using Utis.EmployeeTest.GrpcClientProto;

namespace Utis.EmployeeTest.Client.Services
{
    internal class DataService : IDataService
    {
        private readonly WorkerApi.WorkerApiClient _client;

        public DataService()
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            _client = new WorkerApi.WorkerApiClient(channel);
        }

        public Task<Worker> AddWorker(Worker worker)
        {
            var addedWorker = _client.Insert(new WorkerMessage
            {
                Surname = worker.Surname,
                Name = worker.Name,
                Patronym = worker.Patronym,
                Birthdate = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTimeOffset(worker.BirthDate),
                Sex = (Sex)worker.Sex,
                Haschildren = worker.HasChildren
            });

            worker.Id = Guid.Parse(addedWorker.Id);

            return Task.FromResult(worker);
        }

        public Task<Worker> GetWorkerById(Guid id)
        {
            var request = new WorkerRequestId
            {
                Id = id.ToString()
            };

            var response = _client.Get(request);

            var worker = new Worker
            {
                Id = Guid.Parse(response.Id),
                Surname = response.Surname,
                Name = response.Name,
                Patronym = response.Patronym,
                BirthDate = response.Birthdate.ToDateTime(),
                Sex = (Models.Enums.Sex)response.Sex,
                HasChildren = response.Haschildren
            };

            return Task.FromResult(worker);
        }

        public async Task<List<Worker>> GetWorkers()
        {
            var response = await _client.GetAllAsync(new Empty());

            return response.Workers.Select(w => new Worker
            {
                Id = Guid.Parse(w.Id),
                Surname = w.Surname,
                Name = w.Name,
                Patronym = w.Patronym,
                BirthDate = w.Birthdate.ToDateTime(),
                Sex = (Models.Enums.Sex)w.Sex,
                HasChildren = w.Haschildren
            }).ToList();
        }

        public Task RemoveWorker(Worker worker)
        {
            _client.Remove(new WorkerMessage { Id = worker.Id.ToString() });

            return Task.CompletedTask;
        }

        public Task<Worker> UpdateWorker(Worker worker)
        {
            var updatedWorker = _client.Insert(new WorkerMessage
            {
                Surname = worker.Surname,
                Name = worker.Name,
                Patronym = worker.Patronym,
                Birthdate = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTimeOffset(worker.BirthDate),
                Sex = (Sex)worker.Sex,
                Haschildren = worker.HasChildren
            });

            _client.Update(updatedWorker);

            return Task.FromResult(worker);
        }
    }
}
