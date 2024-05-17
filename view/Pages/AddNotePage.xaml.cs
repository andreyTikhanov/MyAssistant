﻿using Assistant.model;
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

namespace Assistant.view
{
    /// <summary>
    /// Логика взаимодействия для AddNotePage.xaml
    /// </summary>
    public partial class AddNotePage : Page
    {
        private SQLiteAssistantRepository _repository;
        public AddNotePage()
        {
            InitializeComponent();
            _repository = new SQLiteAssistantRepository();
            LoadCategories();
        }
        public void LoadCategories()
        {
            List<Category> categories=_repository.GetAllCategories();
            lbCategory.ItemsSource = categories;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {
            Category selectedCategory = lbCategory.SelectedItem as Category;
            if(selectedCategory != null)
            {
                NavigationService.Navigate(new AddNoteInExistsCategory(selectedCategory));
            }
        }
    }
}