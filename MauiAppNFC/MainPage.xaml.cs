using System.Text;

namespace MauiAppNFC
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        private bool _nfcIsEnabled;
        public bool NfcIsEnabled
        {
            get => _nfcIsEnabled;
            set
            {
                _nfcIsEnabled = value;
                OnPropertyChanged(nameof(NfcIsEnabled));
                OnPropertyChanged(nameof(NfcIsDisabled));
            }
        }

        bool NfcIsDisabled => !NfcIsEnabled;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            //SentrySdk.CaptureMessage("Hello Sentry");

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
