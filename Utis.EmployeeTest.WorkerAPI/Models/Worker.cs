using System;
using WorkerAPI.Models.Enums;

namespace WorkerAPI.Models
{
    /// <summary>
    /// Сотрудник
    /// </summary>
    public class Worker
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string SureName { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string Patronym { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Пол
        /// </summary>
        public Sex Sex { get; set; }

        /// <summary>
        /// Наличие детей
        /// </summary>
        public bool HasChildren { get; set; }
    }
}
