using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfAppVmeste.View;
using WpfAppVmeste.ViewModel.Helpers;

namespace WpfAppVmeste.ViewModel
{
    internal class MainWindowViewModel : BindingHelper
    {
        #region Свойства
        private string dateNow;
        public string DateNow
        {
            get { return dateNow; }
            set
            {
                dateNow = value;
                OnPropertyChanged();
            }
        }
        private Page pageFrame;
        public Page PageFrame
        {
            get { return pageFrame; }
            set
            {
                pageFrame = value;
                OnPropertyChanged();
            }
        }
        private string afterDateButtonContent;
        public string AfterDateButtonContent
        {
            get { return afterDateButtonContent; }
            set
            {
                afterDateButtonContent = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region Команды
        public BindableCommand BeforeDateButtonCommand { get; set; }
        public BindableCommand AfterDateButtonCommand { get; set; }
        #endregion
        DateTime currentDate;
        PageCalendar _pageCalendar;
        public static List<ModelDannix> modelDannixes = new List<ModelDannix>();
        public MainWindowViewModel()
        {
            currentDate = DateTime.Now;
            DateNow = currentDate.ToString("MMMM, yyyy");
            BeforeDateButtonCommand = new BindableCommand(_ => BeforeDateButton_Click());
            AfterDateButtonCommand = new BindableCommand(_ => AfterDateButton_Click());
            PageCalendar pageCalendar = new PageCalendar(currentDate);
            _pageCalendar = pageCalendar;
            PageFrame = pageCalendar;
            AfterDateButtonContent = "Вперед";
            modelDannixes = JSONchik.myDeserialize<List<ModelDannix>>();
        }

        private void BeforeDateButton_Click()
        {
            if (PageFrame is not PageViborPersonaja)
            {
                currentDate = currentDate.AddMonths(-1);
                DateNow = currentDate.ToString("MMMM, yyyy");
                if (PageFrame.DataContext is PageCalendarViewModel pageCalendarViewModel)
                {
                    pageCalendarViewModel.GenerateCards(currentDate);
                }
            }
            else if (PageFrame is PageViborPersonaja)
            {
                PageFrame = _pageCalendar;
                if (PageFrame.DataContext is PageCalendarViewModel pageCalendarViewModel)
                {
                    pageCalendarViewModel.GenerateCards(currentDate);
                }
                AfterDateButtonContent = "Вперед";
            }
        }

        private void AfterDateButton_Click()
        {
            if (PageFrame is not PageViborPersonaja)
            {
                currentDate = currentDate.AddMonths(1);
                DateNow = currentDate.ToString("MMMM, yyyy");
                if (PageFrame.DataContext is PageCalendarViewModel pageCalendarViewModel)
                {
                    pageCalendarViewModel.GenerateCards(currentDate);
                }
            }
            else if (PageFrame is PageViborPersonaja)
            {
                if (PageFrame.DataContext is PageViborViewModel pageViborViewModel)
                {
                    ModelDannix modelDannix = new ModelDannix();
                    modelDannix.dateTime = pageViborViewModel.fullDate;
                    string LastImage;
                    if (pageViborViewModel.IsCheckedCheckBox1 == true)
                    {
                        LastImage = "/images/Свофорд.jpg";
                    }
                    else if (pageViborViewModel.IsCheckedCheckBox2 == true)
                    {
                        LastImage = "/images/Папич серьезны.jpg";
                    }
                    else if (pageViborViewModel.IsCheckedCheckBox3 == true)
                    {
                        LastImage = "/images/пудж.jpg";
                    }
                    else if (pageViborViewModel.IsCheckedCheckBox4 == true)
                    {
                        LastImage = "/images/Даун.jpg";
                    }
                    else if (pageViborViewModel.IsCheckedCheckBox5 == true)
                    {
                        LastImage = "/images/чел_чипсы_хавает.jpg";
                    }
                    else if (pageViborViewModel.IsCheckedCheckBox6 == true)
                    {
                        LastImage = "/images/Хайзенберг.jpg";
                    }
                    else if (pageViborViewModel.IsCheckedCheckBox7 == true)
                    {
                        LastImage = "/images/Гламурный мейк))).jpg";
                    }
                    else if (pageViborViewModel.IsCheckedCheckBox8 == true)
                    {
                        LastImage = "/images/бубузьяна.jpg";
                    }
                    else
                    {
                        LastImage = "not found";
                    }
                    modelDannix.PathToLastImage = LastImage;
                    modelDannix.checkbox_1 = pageViborViewModel.IsCheckedCheckBox1;
                    modelDannix.checkbox_2 = pageViborViewModel.IsCheckedCheckBox2;
                    modelDannix.checkbox_3 = pageViborViewModel.IsCheckedCheckBox3;
                    modelDannix.checkbox_4 = pageViborViewModel.IsCheckedCheckBox4;
                    modelDannix.checkbox_5 = pageViborViewModel.IsCheckedCheckBox5;
                    modelDannix.checkbox_6 = pageViborViewModel.IsCheckedCheckBox6;
                    modelDannix.checkbox_7 = pageViborViewModel.IsCheckedCheckBox7;
                    modelDannix.checkbox_8 = pageViborViewModel.IsCheckedCheckBox8;
                    if (modelDannixes == null)
                    {
                        modelDannixes = new List<ModelDannix>();
                    }
                    modelDannixes.Add(modelDannix);
                    JSONchik.mySerialize(modelDannixes);
                }
            }
        }
    }
}
