using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Base64DecoderCL;
using System.Windows.Forms;
using Base64DecoderCL.EDI;


namespace Base64Decoder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Folderman folman = new Folderman();
        
        public MainWindow()
        {
            InitializeComponent();
            TbFilepatch.Content =folman.IniUSerinputPatch();
            
        }

        //Handle filedrop to GUI
        private void Window_Drop(object sender, System.Windows.DragEventArgs e)
        {
            XMlControler xmlcon = new XMlControler();
            EDIControler Edicon = new EDIControler();
            LWFilepatchtoFinich.Items.Clear();
            System.Windows.DataObject dataObject = e.Data as System.Windows.DataObject;
            LbResultat.Visibility = System.Windows.Visibility.Hidden;
     List<string> imageFiles = new List<string>();
            
            try 
                {
            if (dataObject.ContainsFileDropList())
            {
                System.Collections.Specialized.StringCollection fileNames =
                    dataObject.GetFileDropList();
                foreach (string fileName in fileNames)
                {
                    string extension = System.IO.Path.GetExtension(fileName).ToString().ToLower();
                    switch (extension)
                    {
                        case ".xml":

                            imageFiles.Add(fileName);
                        xmlcon.DecodeBase64(fileName, folman.GetUserFilePatch());
                        LWFilepatchtoFinich.Items.Add(fileName.ToString());
                        break;
                        case ".fnx":
                            imageFiles.Add(fileName);
                        xmlcon.DecodeBase64(fileName, folman.GetUserFilePatch());
                        LWFilepatchtoFinich.Items.Add(fileName.ToString());
                        break;
                        case ".edi":
                            imageFiles.Add(fileName);
                            Edicon.ExtractEDIFIle(fileName, folman.GetUserFilePatch());
                            LWFilepatchtoFinich.Items.Add(fileName.ToString());
                            break;
                        default:
                            LWFilepatchtoFinich.Items.Add("forkert fil format");
                            break;

                    }
                   
                }

            
            }
            LbResultat.Visibility = System.Windows.Visibility.Visible;
            LbResultat.Content = "Færdig";
            LbResultat.Foreground = new SolidColorBrush(Colors.Green);
                }
            catch
            {
                LbResultat.Visibility = System.Windows.Visibility.Visible;
                LbResultat.Content = "Ingen output";
                LbResultat.Foreground = new SolidColorBrush(Colors.Red);
            }

        }

        //Folderpbrowser, selec patch
        private void BtnOutputfolder_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            string path = dialog.SelectedPath + @"\";
            TbFilepatch.Content = path;
            folman.SaveUserFilePatch(path);

        }
    }
}
