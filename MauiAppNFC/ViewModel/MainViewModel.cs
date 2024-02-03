using System;
using System.Text;
using System.Windows.Input;
using MauiAppNFC;
using MauiAppNFC.Interfaces;
using MauiAppNFC.Platforms;

namespace MauiAppNFC.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly INfcService _nfcAdapter;
        private string stringData;

        public string StringData
        {
            get => stringData;
            set => SetProperty(ref stringData, value);
        }

        public ICommand StartNfcTransmissionCommand { get; set; }

        public MainViewModel(INfcService nfcService)
        {
            this._nfcAdapter = nfcService;
            StartNfcTransmissionCommand = new Command(() => ExecuteNfc());
            stringData = string.Empty;
        }

        public async override void ExecuteOnAppearing()
        {
            base.ExecuteOnAppearing();
            if (await _nfcAdapter.OpenNFCSettingsAsync())
            {
                _nfcAdapter.ConfigureNfcAdapter();
                _nfcAdapter.EnableForegroundDispatch();
            }
        }

        public override void ExecuteOnDisappearing()
        {
            base.ExecuteOnDisappearing();
            _nfcAdapter.DisableForegroundDispatch();
            _nfcAdapter.UnconfigureNfcAdapter();
        }

        private Task ExecuteNfc()
        {
            byte[] bytes = Encoding.ASCII.GetBytes(stringData);
            return _nfcAdapter.SendAsync(bytes);
        }

    }
}

