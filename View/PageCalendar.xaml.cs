using System.Windows.Controls;
using WpfAppVmeste.ViewModel;

namespace WpfAppVmeste
{
    public partial class PageCalendar : Page
    {
        public PageCalendar(DateTime currentDate)
        {
            InitializeComponent();
            DataContext = new PageCalendarViewModel(currentDate);
        }
    }
}
