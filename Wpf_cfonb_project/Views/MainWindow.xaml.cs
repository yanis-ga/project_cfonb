using System.Windows;
using Microsoft.Win32;
using System.Collections.Generic;
using Wpf_cfonb_project.Models;
using Wpf_cfonb_project.Services;


namespace Wpf_cfonb_project.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly CfonbParserService _parserService;
        public MainWindow()
        {
            InitializeComponent();
            _parserService = new CfonbParserService();
        }

        private void ImportFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Fichier CFONB120 (*.txt)|*.txt|Tous les fichiers (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    string filePath = openFileDialog.FileName;

                    // Parsing du fichier CFONB
                    _parserService.ParseFile(filePath);

                    // Bind des DataGrid
                    DataGridHeader.ItemsSource = new List<CfonbLineCode01> { _parserService.Header }; // Ligne unique
                    DataGridMovements.ItemsSource = _parserService.Movements; // Lignes 04
                    DataGridComplements.ItemsSource = _parserService.Complements; // Lignes 05
                    DataGridFooter.ItemsSource = new List<CfonbLineCode07> { _parserService.Footer }; // Ligne unique
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de l'importation : " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}