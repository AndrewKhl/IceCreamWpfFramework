using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamFramework
{
    public class WindowsDataContext
    {
        private readonly Dictionary<string, VariableBase> _variables;
        private readonly string _contextName;

        public WindowsDataContext([CallerMemberName]string contextName = "unknow")
        {
            _contextName = contextName;
            _variables = new Dictionary<string, VariableBase>();
        }

        public IntVar RegistryIntVar(int value = default)
        {
            var newInt = new IntVar(value);

            RegistryVariable(newInt);

            return newInt;
        }

        private void RegistryVariable(VariableBase variable)
        {
            _variables.Add(variable.PropertyName, variable);
        }
    }
}
