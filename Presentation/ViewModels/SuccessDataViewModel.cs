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
using System.IO;

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

        private string? recipeImage;

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
                    if (IsValidImageFile(filePath))
                    {
                        _images!.Add(filePath);
                    }
                    else MessageBox.Show($"Invalid image file: {Path.GetFileName(filePath)}. Image does not match the recipe", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private bool IsValidImageFile(string filePath)
        {
            try
            {
                return _serverAccess!.DoesImageMatchRecipe(recipeImage!, filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        public ICommand? AddTodayDateCommand => new CommandBase(execute => AddDate());
        private void AddDate()
        {
            try
            {
                _usedDates?.Add(new UsedDatesViewModel(_serverAccess!.GetDateEvent()));
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
            double a = rating;
            var t = Images;
            a = 3;
        }

        public SuccessDataViewModel(IServerAccess? serverAccess, RecipeDB successData, string? image)
        {
            _serverAccess = serverAccess;
            ID = successData.ID;

            Random rnd = new Random();
            rating = rnd.NextInt64(5);//successData.Rating;
            comment = successData.Comment;
            recipeImage = image;

            _images = new ObservableCollection<string>((from r_image in successData.RecipeImages! 
                                                        select r_image.Path).ToList());

            _usedDates = new ObservableCollection<UsedDatesViewModel>(
                            (from d in successData.RecipeDates
                             select new UsedDatesViewModel(d)).ToList());
        }

       
    }
}
