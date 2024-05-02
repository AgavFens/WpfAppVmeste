using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfAppVmeste.View;
using WpfAppVmeste.ViewModel.Helpers;

namespace WpfAppVmeste.ViewModel
{
    internal class PageCalendarViewModel : BindingHelper
    {
        #region Свойства
        public ObservableCollection<UserControlCard> Cards { get; set; }
        #endregion
        DateTime currentDate;
        public PageCalendarViewModel(DateTime currentDate)
        {
            this.currentDate = currentDate;
            Cards = new ObservableCollection<UserControlCard>();
            GenerateCards(currentDate);
        }

        public void GenerateCards(DateTime currentDate)
        {
            Cards.Clear();
            List<ModelDannix> modelDannixList = new List<ModelDannix>();
            modelDannixList = JSONchik.myDeserialize<List<ModelDannix>>();
            int daysInMonth = DateTime.DaysInMonth(currentDate.Year, currentDate.Month);
            for (int i = 1; i <= daysInMonth; i++)
            {
                UserControlCard card = new UserControlCard(currentDate);
                if (card.DataContext is UserControlCardViewModel userControlCardViewModel)
                {
                    userControlCardViewModel.DayInLabel = i.ToString();
                    DateTime fullDate = new DateTime(currentDate.Year, currentDate.Month, i);
                    if (modelDannixList != null)
                    {
                        ModelDannix existingItem = modelDannixList.FirstOrDefault(item => item.dateTime.Date == fullDate.Date);
                        if (existingItem != null)
                        {
                            userControlCardViewModel.ImageInButton = existingItem.PathToLastImage;
                        }
                    }
                }
                Cards.Add(card);
            }
        }
    }
}
