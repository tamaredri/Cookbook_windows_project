using Presentation.Stores;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace Presentation.Commands
{
    class ReturnViewCommand : CommandBase
    {
        private NavigationStore _navigation;


        public ReturnViewCommand(NavigationStore navigation):base(null)
        {
            _navigation = navigation;
            _execute = e => _navigation.returnView();
        }
    }
}
