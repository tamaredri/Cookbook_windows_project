using Microsoft.Win32;
using Presentation.Commands;
using Presentation.Models;
using Presentation.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Presentation.ViewModels
{
    public class SuccessDataViewModel : ViewModelBase
    {
        private readonly SuccessData _successData;

        private double rating;
        public double Rating { 
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

        private NavigationStore _navigationStore;

        private ObservableCollection<UsedDatesViewModel>? _usedDates;

        public IEnumerable<UsedDatesViewModel>? UsedDates => _usedDates;

        public ICommand? AddImageCommand => new CommandBase(execute => UploadImage());
        private void UploadImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.gif)|*.png;*.jpg;*.jpeg;*.gif|All Files (*.*)|*.*";
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == true)
            {
                foreach (string filePath in openFileDialog.FileNames)
                {
                    _images!.Add(filePath); 
                }
            }
        }


        public ICommand? AddTodayDateCommand => new CommandBase(execute => 
                                                                    _usedDates?.Add(
                                                                        new UsedDatesViewModel(new UsedDate(){ Date = DateTime.Now, Description = "..." })));

        public ICommand? SaveChangesCommand => new CommandBase(execute => SaveComments());
        private void SaveComments()
        {
            //save comments in db
        }

        public SuccessDataViewModel(NavigationStore navigationStore, SuccessData successData)
        {
            _navigationStore = navigationStore;

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
