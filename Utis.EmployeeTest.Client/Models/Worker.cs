using System;
using Utis.EmployeeTest.Client.Models.Enums;

namespace Utis.EmployeeTest.Client.Models
{
    /// <summary>
    /// Сотрудник
    /// </summary>
    internal class Worker : ICloneable
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; set; }

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

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
