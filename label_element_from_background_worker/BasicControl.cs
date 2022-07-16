using System;
using System.Collections.Generic;
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
            if (((CheckBox)sender).Checked)
            {
                // Get a fresh cancellation token source.
                _cts?.Cancel();
                _cts = new CancellationTokenSource();
                // Get notified when any property changes in CustomDoWorkEventArgs.
                var context = new CustomDoWorkContext(cancellationToken: _cts.Token);
                context.PropertyChanged += (sender, e) =>
                {
                    switch (e.PropertyName)
                    {
                        case nameof(CustomDoWorkContext.Message):
                            Invoke((MethodInvoker)delegate
                            // When myMethod sets Message, change the label text.
                            {  myLabel.Text = $"{context.Message}"; });
                            break;
                        case nameof(CustomDoWorkContext.Count):
                            // When the count increments, change the checkbox text.
                            Invoke((MethodInvoker)delegate
                            { checkBoxDoWork.Text = $"Count = {context.Count}"; });
                            break;
                    }
                };
                // Start background worker however you want to.
                Task.Run(() => bw_DoWork(sender, args: new DoWorkEventArgs(argument: context)));
            }
            else
            {
                checkBoxDoWork.Text = "Do Work";
                _cts?.Cancel();
            }
        }
        CancellationTokenSource _cts = null;

        private async void bw_DoWork(object sender, DoWorkEventArgs args)
        {
            var moc = new MyOtherClass();
            if (args.Argument is CustomDoWorkContext context)
            {
                args.Cancel = context.Token.IsCancellationRequested;
                while (!args.Cancel) // Loop for testing
                {
                    context.Count++;
                    string result = moc.myMethod(args); // Pass the args
                    try { await Task.Delay(1000, context.Token); }
                    catch (TaskCanceledException) { return; }
                }
            }
        }
    }

    internal class MyOtherClass
    {
        internal string myMethod(DoWorkEventArgs args)
        {
            if (args.Argument is CustomDoWorkContext context)
            {
                context.Message = $"THIS WORKS! @ {DateTime.Now} ";
            }
            return "Your result";
        }
    }

    class CustomDoWorkContext : INotifyPropertyChanged
    {
        public CustomDoWorkContext(CancellationToken cancellationToken)
        {
            Token = cancellationToken;
        }
        // This class can have as many bindable properties as you need
        string _message = string.Empty;
        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }
        int _count = 0;
        public int Count
        {
            get => _count;
            set => SetProperty(ref _count, value);
        }
        public CancellationToken Token { get; }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected bool SetProperty<T>( ref T backingStore, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))  return false;
            backingStore = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
