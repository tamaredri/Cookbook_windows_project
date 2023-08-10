using AppServer;
using Microsoft.Win32;
using Presentation.Commands;
using AppServer.Models;
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
        
        private readonly IServerAccess? _serverAccess;
        
        private int ID { get; }

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


        public ICommand? AddTodayDateCommand => new CommandBase(execute => AddDate());
        private void AddDate()
        {
            try
            {
                UsedDate d = _serverAccess!.GetDateEvent(DateTime.Now, DateTime.Now.AddDays(3));
                _usedDates?.Add(new UsedDatesViewModel(d));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public ICommand? SaveChangesCommand => new CommandBase(execute => SaveComments());
        private void SaveComments()
        {
            //save comments in db
            //save rating in db
        }

        public SuccessDataViewModel(IServerAccess? serverAccess, DBRecipeSuccessData successData)
        {
            _serverAccess = serverAccess;
            ID = successData.ID;

            rating = successData.Rating;
            comment = successData.Comment;

            _images = new ObservableCollection<string>(successData.Images!);

            _usedDates = new ObservableCollection<UsedDatesViewModel>(
                            (from d in successData.UsedDates
                             select new UsedDatesViewModel(d)).ToList());
        }

       
    }
}
