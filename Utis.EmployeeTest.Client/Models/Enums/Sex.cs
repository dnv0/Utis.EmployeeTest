using System.ComponentModel;

namespace Utis.EmployeeTest.Client.Models.Enums
{
    /// <summary>
    /// Перечисление полов
    /// </summary>
    internal enum Sex
    {
        [Description("Не задан")]
        Unknown = 0,

        [Description("Мужской")]
        Male = 1,

        [Description("Женский")]
        Female = 2
    }
}
