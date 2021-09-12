using IceCreamFramework;

namespace IcecreamWpfFramework
{
    public class MainViewModel : WindowsDataContext
    {
        public IntVar IntValue { get; }


        public MainViewModel() : base()
        {
            IntValue = RegistryIntVar(5);
        }
    }
}
