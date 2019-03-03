﻿using System.Diagnostics; //Debug.WriteLine
using System.IO; //Folder, Directory
using System.Windows;
using System.Windows.Controls;
using WinForms = System.Windows.Forms; //FolderDialog

namespace ImageCompreziptor.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            wait1.Visibility = Visibility.Visible;
            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //DXSplashScreen.Close();
            this.Activate();
        }

        private void BtnHelp_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnReportBug_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MainWindow1_Drop(object sender, DragEventArgs e)
        {
            /*
            string[] droppedFiles = null;
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                droppedFiles = e.Data.GetData(DataFormats.FileDrop, true) as string[];
            }

            if ((null == droppedFiles) || (!droppedFiles.Any())) { return; }

            listFiles.Items.Clear();

            foreach (string s in droppedFiles)
            {
                listFiles.Items.Add(s);
            }
            
            dataGridFiles.ItemsSource = droppedFiles;
            */
        }

        private void btnSelect_Folder_Click(object sender, RoutedEventArgs e)
        {
            WinForms.FolderBrowserDialog folderDialog = new WinForms.FolderBrowserDialog
            {
                ShowNewFolderButton = false,
                SelectedPath = System.AppDomain.CurrentDomain.BaseDirectory
            };
            WinForms.DialogResult result = folderDialog.ShowDialog();

            if (result == WinForms.DialogResult.OK)
            {
                //----< Selected Folder >----
                //< Selected Path >
                string sPath = folderDialog.SelectedPath;
                tbxFolder.Text = sPath;
                //</ Selected Path >

                //DataTable table = new DataTable();
                //table.Columns.Add("FileName");
                //table.Columns.Add("Size");

                //--------< Folder >--------
                DirectoryInfo folder = new DirectoryInfo(sPath);
                if (folder.Exists)
                {
                    //------< @Loop: Files >------
                    foreach (FileInfo fileInfo in folder.GetFiles())
                    {
                        //----< File >----
                        string sDate = fileInfo.CreationTime.ToString("yyyy-MM-dd");
                        Debug.WriteLine("#Debug: File: " + fileInfo.Name + " Date:" + sDate);

                        /*
                        fileInfo.Length;
                        fileInfo.CreationTime;
                        fileInfo.CreationTimeUtc;
                        fileInfo.Directory;
                        fileInfo.DirectoryName;
                        fileInfo.Extension;
                        fileInfo.FullName;
                        fileInfo.IsReadOnly;
                        fileInfo.LastAccessTime;
                        fileInfo.LastAccessTimeUtc;
                        fileInfo.LastWriteTime;
                        fileInfo.LastWriteTimeUtc;
                        */



                        //----</ File >----
                    }
                    //------</ @Loop: Files >------

                    dataGridFiles.ItemsSource = folder.GetFiles();

                    //hide columns
                    //dataGridFiles.Items.

                    //dataGridFiles.ItemsSource = table.AsEnumerable();



                }
                //--------</ Folder >--------
                //----</ Selected Folder >----


            }
        }

        private void DataGridFiles_AutoGeneratedColumns(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "CreationTime"
                || e.Column.Header.ToString() == "CreationTimeUtc"
                || e.Column.Header.ToString() == "Directory"
                || e.Column.Header.ToString() == "DirectoryName"
                || e.Column.Header.ToString() == "FullName"
                || e.Column.Header.ToString() == "IsReadOnly"
                || e.Column.Header.ToString() == "LastAccessTime"
                || e.Column.Header.ToString() == "LastAccessTimeUtc"
                || e.Column.Header.ToString() == "LastWriteTime"
                || e.Column.Header.ToString() == "LastWriteTimeUtc"
                )
            {
                e.Column.Visibility = Visibility.Hidden;
            }
        }

        private void DataGridFiles_AutoGeneratedColumns_1(object sender, System.EventArgs e)
        {

            DataGrid grid = sender as DataGrid;
            
            //TODO: Works for all languages? ex. spanish? or need to hide by index...
            foreach (DataGridColumn col in grid.Columns)
            {
                if (
                   col.Header.ToString() == "CreationTime"
        || col.Header.ToString() == "CreationTimeUtc"
        || col.Header.ToString() == "Directory"
        || col.Header.ToString() == "DirectoryName"
        || col.Header.ToString() == "FullName"
        || col.Header.ToString() == "IsReadOnly"
        || col.Header.ToString() == "LastAccessTime"
        || col.Header.ToString() == "LastAccessTimeUtc"
        || col.Header.ToString() == "LastWriteTime"
        || col.Header.ToString() == "LastWriteTimeUtc"
        || col.Header.ToString() == "Exists"
        || col.Header.ToString() == "Extension"
        || col.Header.ToString() == "Attributes"
        )
                {
                    col.Visibility = Visibility.Hidden;
                }

            }
                                                  

        }
    }
}

