using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfAppVmeste.ViewModel.Helpers;

namespace WpfAppVmeste.ViewModel
{
    internal class PageViborViewModel : BindingHelper
    {
        #region Свойства
        private bool isCheckedCheckBox1;
        public bool IsCheckedCheckBox1 { get { return isCheckedCheckBox1; } set { isCheckedCheckBox1 = value; OnPropertyChanged(); } }

        private bool isCheckedCheckBox2;
        public bool IsCheckedCheckBox2 { get { return isCheckedCheckBox2; } set { isCheckedCheckBox2 = value; OnPropertyChanged(); } }

        private bool isCheckedCheckBox3;
        public bool IsCheckedCheckBox3 { get { return isCheckedCheckBox3; } set { isCheckedCheckBox3 = value; OnPropertyChanged(); } }

        private bool isCheckedCheckBox4;
        public bool IsCheckedCheckBox4 { get { return isCheckedCheckBox4; } set { isCheckedCheckBox4 = value; OnPropertyChanged(); } }

        private bool isCheckedCheckBox5;
        public bool IsCheckedCheckBox5 { get { return isCheckedCheckBox5; } set { isCheckedCheckBox5 = value; OnPropertyChanged(); } }

        private bool isCheckedCheckBox6;
        public bool IsCheckedCheckBox6 { get { return isCheckedCheckBox6; } set { isCheckedCheckBox6 = value; OnPropertyChanged(); } }

        private bool isCheckedCheckBox7;
        public bool IsCheckedCheckBox7 { get { return isCheckedCheckBox7; } set { isCheckedCheckBox7 = value; OnPropertyChanged(); } }

        private bool isCheckedCheckBox8;
        public bool IsCheckedCheckBox8 { get { return isCheckedCheckBox8; } set { isCheckedCheckBox8 = value; OnPropertyChanged(); } }

        public DateTime fullDate { get; set; }
        #endregion
        List<ModelDannix> models = new List<ModelDannix>();
        public PageViborViewModel(DateTime fullDate)
        {
            this.fullDate = fullDate;
            models = JSONchik.myDeserialize<List<ModelDannix>>();
            if (models != null)
            {
                ModelDannix existingItem = models.FirstOrDefault(item => item.dateTime.Date == fullDate.Date);
                if (existingItem != null)
                {
                    isCheckedCheckBox1 = existingItem.checkbox_1;
                    isCheckedCheckBox2 = existingItem.checkbox_2;
                    isCheckedCheckBox3 = existingItem.checkbox_3;
                    isCheckedCheckBox4 = existingItem.checkbox_4;
                    isCheckedCheckBox5 = existingItem.checkbox_5;
                    isCheckedCheckBox6 = existingItem.checkbox_6;
                    isCheckedCheckBox7 = existingItem.checkbox_7;
                    isCheckedCheckBox8 = existingItem.checkbox_8;
                }
            }
        }
    }
}
