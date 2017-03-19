using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Phoneword
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public Entry phoneNumberText { get { return _phoneNumberText; } }
        public Button translateButton { get { return _translateButton; } }
        public Button callButton { get { return _callButton; } }
        public Button callHistoryButton { get { return _callHistoryButton; } }
    }
}
