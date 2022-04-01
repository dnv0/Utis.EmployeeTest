using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using Utis.EmployeeTest.Client.Models;
using Utis.EmployeeTest.Client.Services;
using Utis.EmployeeTest.Client.Views;

namespace Utis.EmployeeTest.Client.ViewModels
{
    /// <summary>
    /// Модель-представление оболочки приложения
    /// </summary>
    internal class MainShellViewModel : BindableBase
    {
        private readonly IDataService _dataService;
        private readonly IDialogService _dialogService;
        private Worker _selectedWorker;
        private bool _isLoading;

        /// <summary>
        /// Инициализация экземплра класса <see cref="MainShellViewModel"/>
        /// </summary>
        public MainShellViewModel(IDataService dataService, IDialogService dialogService)
        {
            _dataService = dataService;
            _dialogService = dialogService;

            _ = LoadWorkers();
        }

        /// <summary>
        /// Перечень сотрудников
        /// </summary>
        public ObservableCollection<Worker> Workers { get; set; } = new();

        /// <summary>
        /// Выбранный сотрудник
        /// </summary>
        public Worker SelectedWorker
        {
            get => _selectedWorker;
            set => SetProperty(ref _selectedWorker, value);
        }

        /// <summary>
        /// Загрузка
        /// </summary>
        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        #region Команды

        /// <summary>
        /// Команда добавления сотрудника
        /// </summary>
        public DelegateCommand AddCommand => new(() =>
        {
            var newWorker = new Worker
            {
                Surname = "Новый сотрудник",
                Name = "",
                Patronym = "",
                HasChildren = false,
                BirthDate = DateTime.Today
            };

            try
            {
                Workers.Add(newWorker);

                _dataService.AddWorker(newWorker);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Во время создания новой записи произошла ошибка");
            }
        });

        /// <summary>
        /// Команда удаления сотрудника
        /// </summary>
        public DelegateCommand RemoveCommand => new(() =>
        {
            if(SelectedWorker == null)
            {
                return;
            }

            try
            {
                _dataService.RemoveWorker(SelectedWorker);

                Workers.Remove(SelectedWorker);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Во время удаления записи произошла ошибка");
            }
        });

        /// <summary>
        /// Команда редатирования сотрудника
        /// </summary>
        public DelegateCommand EditCommand => new(() =>
        {
            var parameters = new DialogParameters
            {
                {"worker", SelectedWorker}
            };

            _dialogService.ShowDialog(nameof(WorkerEditor), parameters, (result) =>
            {
                if(result.Result != ButtonResult.OK)
                {
                    return;
                }

                var worker = result.Parameters.GetValue<Worker>("worker");

                try
                {
                    _dataService.UpdateWorker(worker);

                    var index = Workers.IndexOf(SelectedWorker);
                    Workers[index] = worker;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Во время обновления записи произошла ошибка");
                }
            });
        });

        /// <summary>
        /// Команда обновления
        /// </summary>
        public DelegateCommand RefreshCommand => new(async () =>
        {
            await LoadWorkers();
        });

        #endregion

        /// <summary>
        /// Загружает перечень сотрудников
        /// </summary>
        private async Task LoadWorkers()
        {       
                     
            try
            {
                IsLoading = true;

                var workers = await _dataService.GetWorkers();

                Workers = new ObservableCollection<Worker>(workers);

                RaisePropertyChanged(nameof(Workers));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Во время загрузки данных произошла ошибка");
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}
