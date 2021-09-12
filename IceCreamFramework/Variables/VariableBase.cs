using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace IceCreamFramework
{
    public class VariableBase : INotifyPropertyChanged, IDisposable
    {
        public string PropertyName { get; protected set; }

        public string DisplayName { get; }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public void Dispose()
        {
        }
    }


    public class VariableBase<T> : VariableBase, IDataErrorInfo
    {
        protected string _lastError = string.Empty;
        private T _value;

        public virtual string this[string columnName] => Error;

        public string Error => _lastError;


        public T Value
        {
            get => _value;

            set
            {
                _value = value;

                OnPropertyChanged();
            }
        }
    }


    public class IntVar : VariableBase<int>
    {
        public IntVar(int value) : base()
        {
            PropertyName = "TestInt";
            Value = value;
        }

        public override string this[string columnName]
        {
            get
            {
                _lastError = string.Empty;

                switch (columnName)
                {
                    case nameof(Value):
                        if (Value > 100)
                            _lastError = $"{Value} cannot be less than 100!";
                        break;
                }

                return _lastError;
            }
        }
    }
}
