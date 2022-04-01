using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utis.EmployeeTest.Client.Models;

namespace Utis.EmployeeTest.Client.Services
{
    internal interface IDataService
    {
        /// <summary>
        /// Получить перечень сотрудников
        /// </summary>
        /// <returns>Перечень сотрудников</returns>
        Task<List<Worker>> GetWorkers();

        /// <summary>
        /// Получить сотрудника по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор сотрудника</param>
        /// <returns>Сотрудник</returns>
        Task<Worker> GetWorkerById(Guid id);

        /// <summary>
        /// Добавляет нового сотрудника
        /// </summary>
        /// <param name="worker">Сотрудник</param>
        Task<Worker> AddWorker(Worker worker);

        /// <summary>
        /// Обновляет данные сотрудника
        /// </summary>
        /// <param name="worker">Сотрудник</param>
        Task<Worker> UpdateWorker(Worker worker);

        /// <summary>
        /// Удаляет сотрудника
        /// </summary>
        /// <param name="worker">Сотрудник</param>
        Task RemoveWorker(Worker worker);
    }
}
