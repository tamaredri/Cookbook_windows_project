using Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Stores
{
    public class NavigationStore 
    {

        private Stack<ViewModelBase>? _stackView;

        public NavigationStore()
        {
            _stackView = new Stack<ViewModelBase>();
        }

        public void returnView()
        {
            if (_stackView?.Count() > 1)
            {
               //if(_stackView.Peek() is FullRecipeViewModel)
                    //_stackView.Pop();
                CurrentViewModel = _stackView!.Pop();
                _stackView.Pop();
            }
        }

        private ViewModelBase? _currentViewModel;

		public ViewModelBase CurrentViewModel
        {
			get { return _currentViewModel!; }
			set {
                _stackView?.Push(_currentViewModel!);
                _currentViewModel = value;
                OnCurrentViewModelChange();
            }
		}

        private void OnCurrentViewModelChange()
        {
            CurrentViewModelChanged?.Invoke();
        }

        public event Action? CurrentViewModelChanged;

    }
}
