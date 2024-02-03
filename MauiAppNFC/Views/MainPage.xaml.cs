using MauiAppNFC.ViewModels;
using MauiAppNFC.Views;
using System.Text;

namespace MauiAppNFC
{
    public partial class MainPage : BaseContentPage
    {
        private readonly MainViewModel _mainViewModel;

        public MainPage(MainViewModel mainViewModel):base(mainViewModel)
        {
            InitializeComponent();
            _mainViewModel = mainViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _mainViewModel.ExecuteOnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _mainViewModel.ExecuteOnDisappearing();
        }
        int count = 0;

        //private bool _nfcIsEnabled;
        //public bool NfcIsEnabled
        //{
        //    get => _nfcIsEnabled;
        //    set
        //    {
        //        _nfcIsEnabled = value;
        //        OnPropertyChanged(nameof(NfcIsEnabled));
        //        OnPropertyChanged(nameof(NfcIsDisabled));
        //    }
        //}

        //bool NfcIsDisabled => !NfcIsEnabled;

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            //SentrySdk.CaptureMessage("Hello Sentry");
            //_mainViewModel.ExecuteOnAppearing();
            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
