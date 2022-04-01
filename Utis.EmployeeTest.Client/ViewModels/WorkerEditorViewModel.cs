using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using Utis.EmployeeTest.Client.Models;
using Utis.EmployeeTest.Client.Models.Enums;

namespace Utis.EmployeeTest.Client.ViewModels
{
    internal class WorkerEditorViewModel : BindableBase, IDialogAware
    {
        /// <summary>
        /// Наименование окна
        /// </summary>
        public string Title => "Редактирование профиля";

        /// <summary>
        /// Редатируемый профиль
        /// </summary>
        public Worker Worker { get; set; }

        /// <summary>
        /// Делегат закрытия окна
        /// </summary>
        public event Action<IDialogResult> RequestClose;

        /// <summary>
        /// Перечень вариантов пола
        /// </summary>
        public ICollection<Sex> Sex => Enum.GetValues(typeof(Sex)).Cast<Sex>().ToList();

        /// <summary>
        /// Команда сохранения
        /// </summary>
        public DelegateCommand SaveCommand => new(() =>
        {
            var parameters = new DialogParameters
            {
                {"worker", Worker}
            };

            RequestClose?.Invoke(new DialogResult(ButtonResult.OK, parameters));
        });

        /// <summary>
        /// Команда отмены
        /// </summary>
        public DelegateCommand CancelCommand => new(() =>
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.Cancel));
        });

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            var worker = parameters.GetValue<Worker>("worker");

            Worker = (Worker)worker.Clone();

            RaisePropertyChanged(nameof(Worker));
        }
    }
}
