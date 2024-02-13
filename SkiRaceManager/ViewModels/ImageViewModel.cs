using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;
using System.IO;
using System.Windows.Controls;

namespace SkiRaceManager.ViewModels
{
    internal class ImageViewModel
    {
        //private void btnUploadImg(object sender, EventArgs e)
        //{
        //    OpenFileDialog openFileDialog = new OpenFileDialog();
        //    openFileDialog.Filter = "Fichiers image (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg|Tous les fichiers (*.*)|*.*";

        //    if (openFileDialog.ShowDialog() == true)
        //    {
        //        string cheminImage = openFileDialog.FileName;

        //        string nomImage = Path.GetFileName(cheminImage);
        //        string cheminCompletDestination = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", nomImage);

        //        try
        //        {
        //            File.Copy(cheminImage, cheminCompletDestination, true);

        //            ChargerImage(cheminCompletDestination);
        //        }
        //        catch (Exception ex)
        //        {
        //            //MessageBox.Show($"Une erreur s'est produite lors de l'enregistrement de l'image : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
        //            if (File.Exists(cheminCompletDestination))
        //            {
        //                Uri uri = new Uri(cheminCompletDestination);
        //                ImageSource source = new BitmapImage(uri);
        //                votreImageControl.Source = source;
        //            }
        //        }
        //    }
        //}

        public static void ChargerImage(string cheminCompletDestination, Image imgControl)
        {
            try
            {
                if (File.Exists(cheminCompletDestination))
                {
                    Uri uri = new Uri(cheminCompletDestination);
                    ImageSource source = new BitmapImage(uri);
                    imgControl.Source = source;

                }
                else
                {
                    MessageBox.Show($"L'image {cheminCompletDestination} n'a pas pu être chargée dans le répertoire de destination.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur s'est produite lors du chargement ou de la copie de l'image : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
