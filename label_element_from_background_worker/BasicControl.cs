using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace label_element_from_background_worker
{
    public partial class BasicControl : UserControl
    {
        public BasicControl()
        {
            InitializeComponent();
            checkBoxDoWork.CheckedChanged += onCheckboxDoWorkCheckedChanged;
        }

        private void onCheckboxDoWorkCheckedChanged(object sender, EventArgs e)
        {
            if(((CheckBox)sender).Checked)
            {
                // Get a fresh cancellation token source.
                _cts?.Cancel();
                _cts = new CancellationTokenSource();
                // Get notified when any property changes in CustomDoWorkEventArgs
                var customDoWorkEventArgs = new CustomDoWorkEventArgs("Hello", _cts.Token);
                customDoWorkEventArgs.PropertyChanged += (sender, e) =>
                {
                    switch (e.PropertyName)
                    {
                        case nameof(CustomDoWorkEventArgs.Result):
                            Invoke((MethodInvoker)delegate { 
                                label1.Text = $"{customDoWorkEventArgs.Result}"; });
                            break;
                    }
                };
                // Start background worker however you want to.
                Task.Run(()=>bw_DoWork(sender, customDoWorkEventArgs), _cts.Token);
            }
            else _cts?.Cancel();
        }
        CancellationTokenSource _cts = null;

        private async void bw_DoWork(object sender, CustomDoWorkEventArgs customDoWorkEventArgs)
        {
            var moc = new MyOtherClass();
            while (true)
            {
                // For example, we could set the `Result` property 
                // using the return value of myMethod()
                customDoWorkEventArgs.Result = moc.myMethod();
                // A one-second delay for testing.
                try
                {
                    await Task.Delay(1000, customDoWorkEventArgs.Token);
                }
                catch (TaskCanceledException)
                {
                    return;
                }
            }
        }
    }

    internal class MyOtherClass
    {
        internal object myMethod()
        {
            return DateTime.Now;
        }
    }

    class CustomDoWorkEventArgs : DoWorkEventArgs , INotifyPropertyChanged
    {
        public CustomDoWorkEventArgs(object argument, CancellationToken token) : base(argument)
        {
            Token = token;
        }
        // This class can have as many bindable properties
        // as you need. This is one example:
        public new object Result
        {
            get =>base.Result;
            set
            {
                if(!Equals(value, base.Result))
                {
                    base.Result = value;
                    OnPropertyChanged();
                }
            }
        }
        public CancellationToken Token { get; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
