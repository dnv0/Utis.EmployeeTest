using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Utis.EmployeeTest.WorkerAPI;
using WorkerAPI.Infrastructure;
using WorkerAPI.Models;

namespace WorkerAPI
{
    public class WorkerService : WorkerApi.WorkerApiBase
    {
        private readonly WorkerContext _workerContext;

        public WorkerService(WorkerContext workerContext)
        {
            _workerContext = workerContext;
        }

        public override async Task<WorkerList> GetAll(Utis.EmployeeTest.WorkerAPI.Empty request, ServerCallContext context)
        {
            IQueryable<Worker> query = _workerContext.Set<Worker>();

            var result = await query.ToListAsync();

            var workerList = result.Select(x => new WorkerMessage
            {
                Id = x.Id.ToString(),
                Surname = x.SureName,
                Name = x.Name,
                Patronym = x.Patronym,
                Sex = (Sex)x.Sex,
                Birthdate = Timestamp.FromDateTimeOffset(x.BirthDate),
                Haschildren = x.HasChildren
            });

            var response = new WorkerList();

            response.Workers.AddRange(workerList);

            return response;
        }

        public override async Task<WorkerMessage> Get(WorkerRequestId request, ServerCallContext context)
        {
            var workerId = Guid.Parse(request.Id);

            var worker = await _workerContext.Set<Models.Worker>().SingleOrDefaultAsync(w => w.Id == workerId);

            if (worker == null)
            {
                return null;
            }

            return new WorkerMessage
            {
                Id = worker.Id.ToString(),
                Surname = worker.SureName,
                Name = worker.Name,
                Patronym = worker.Patronym,
                Sex = (Sex)worker.Sex,
                Birthdate = Timestamp.FromDateTimeOffset(worker.BirthDate),
                Haschildren = worker.HasChildren
            };
        }

        public override Task<WorkerMessage> Insert(WorkerMessage request, ServerCallContext context)
        {
            var newWorker = new Worker
            {
                Id = Guid.NewGuid(),
                SureName = request.Surname,
                Name = request.Name,
                Patronym = request.Patronym,
                Sex = (Models.Enums.Sex)request.Sex,
                BirthDate = request.Birthdate.ToDateTime(),
                HasChildren = request.Haschildren
            };

            _workerContext.Set<Worker>().Add(newWorker);
            _workerContext.SaveChanges();

            request.Id = newWorker.Id.ToString();

            return Task.FromResult(request);
        }

        public override Task<WorkerMessage> Update(WorkerMessage request, ServerCallContext context)
        {
            var existingWorker = _workerContext.Set<Worker>().SingleOrDefault(w => w.Id == Guid.Parse(request.Id));

            if(existingWorker == null)
            {
                return Insert(request, context);
            }

            existingWorker.SureName = request.Surname;
            existingWorker.Name = request.Name;
            existingWorker.Patronym = request.Patronym;
            existingWorker.Sex = (Models.Enums.Sex)request.Sex;
            existingWorker.BirthDate = request.Birthdate.ToDateTime();
            existingWorker.HasChildren = request.Haschildren;

            _workerContext.Set<Worker>().Update(existingWorker);
            _workerContext.SaveChanges();

            return Task.FromResult(request);
        }

        public override Task<Utis.EmployeeTest.WorkerAPI.Empty> Remove(WorkerMessage request, ServerCallContext context)
        {
            var worker = _workerContext.Set<Worker>().SingleOrDefault(w => w.Id == Guid.Parse(request.Id));

            if(worker == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, "Worker to be deleted not found"));
            }

            _workerContext.Set<Worker>().Remove(worker);
            _workerContext.SaveChanges();

            return Task.FromResult(new Utis.EmployeeTest.WorkerAPI.Empty());
        }
    }
}
