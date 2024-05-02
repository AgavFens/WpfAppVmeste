using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfAppVmeste.View;
using WpfAppVmeste.ViewModel.Helpers;

namespace WpfAppVmeste.ViewModel
{
    internal class UserControlCardViewModel : BindingHelper
    {
        #region Свойства
        public string DayInLabel { get; set; }
        public string ImageInButton { get; set; }
        #endregion
        #region Команды
        DateTime currentDate;
        DateTime fullDate;
        public BindableCommand OpenPageViborPersonaja { get; set; }
        public BindableCommand ClearDayCommand { get; set; }
        #endregion
        public UserControlCardViewModel(DateTime currentDate)
        {
            this.currentDate = currentDate;
            OpenPageViborPersonaja = new BindableCommand(_ => OpenViborPersonaja(DayInLabel));
            ClearDayCommand = new BindableCommand(_ => ClearDay());
        }

        private void ClearDay()
        {
            List<ModelDannix> modelDannixes = new List<ModelDannix>();
            modelDannixes = JSONchik.myDeserialize<List<ModelDannix>>();
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            fullDate = new DateTime(currentDate.Year, currentDate.Month, Convert.ToInt32(DayInLabel));
            if (modelDannixes != null)
            {
                ModelDannix existingItem = modelDannixes.FirstOrDefault(item => item.dateTime.Date == fullDate.Date);
                if (existingItem != null)
                {
                    modelDannixes.Remove(existingItem);
                    JSONchik.mySerialize(modelDannixes);
                    if (mainWindow.DataContext is MainWindowViewModel mainWindowViewModel)
                    {
                        mainWindowViewModel.RefreshCards();
                    }
                }
            }
        }

        private void OpenViborPersonaja(string dayInLabel)
        {
            fullDate = new DateTime(currentDate.Year, currentDate.Month, Convert.ToInt32(DayInLabel));
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow != null)
            {
                if (mainWindow.DataContext is MainWindowViewModel mainWindowViewModel)
                {
                    PageViborPersonaja pageViborPersonaja = new PageViborPersonaja(fullDate);
                    mainWindowViewModel.PageFrame = pageViborPersonaja;
                    mainWindowViewModel.AfterDateButtonContent = "Сохранить";
                }
            }
        }
    }
}
