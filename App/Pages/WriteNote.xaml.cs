using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Search;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using App.Entity;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace App.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WriteNote : Page
    {
        public WriteNote()
        {
            this.InitializeComponent();
        }

        public async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var note = new Note
            {
                name = DateTime.Now.ToString("yyyy-MM-dd-hh-mm"),
                text = textNote.Text,

            };
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;

            Windows.Storage.StorageFile sampleFile = storageFolder.CreateFileAsync(note.name + ".txt",
                Windows.Storage.CreationCollisionOption.ReplaceExisting).GetAwaiter().GetResult();

            Windows.Storage.FileIO.WriteTextAsync(sampleFile, note.text).GetAwaiter().GetResult();
            Debug.WriteLine(sampleFile.Name);

            IReadOnlyList<StorageFile> listNotes = await storageFolder.GetFilesAsync();
            foreach (StorageFile file in listNotes)
                Debug.WriteLine(file.Name);
        }
        

        
    }
}
