using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Presentation.ViewModels
{
    public class SuccessDataViewModel : ViewModelBase
    {
        private readonly SuccessData _successData;

        private int rating;
        public int Rating { 
            get { return rating; }
            set { rating = value; OnPropertyChanged(nameof(Rating)); }
        }

        private string? comment;
        public string? Comment {
            get { return comment; }
            set { 
                comment = value; OnPropertyChanged(nameof(Comment)); }
        }

        private ObservableCollection<string>? _images;
        public IEnumerable<string>? Images => _images;
       

        private ObservableCollection<UsedDatesViewModel>? _usedDates;
        public IEnumerable<UsedDatesViewModel>? UsedDates => _usedDates;

        public ICommand? AddImageCommand { get; set; }

        public ICommand? AddTodayDateCommand { get; set; }

        public ICommand? SaveChangesCommand { get; set; }

        public SuccessDataViewModel(SuccessData successData)
        {
            _successData = successData;

            rating = successData.Rating;
            comment = successData.Comment;

            _images = new ObservableCollection<string>(successData.Images!);

            _usedDates = new ObservableCollection<UsedDatesViewModel>(
                            (from d in _successData.usedDates
                             select new UsedDatesViewModel(d)).ToList());
        }
    }
}
