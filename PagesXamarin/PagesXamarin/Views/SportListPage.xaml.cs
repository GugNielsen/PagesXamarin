using System;
using System.Collections.Generic;
using PagesXamarin.Models;
using Xamarin.Forms;

namespace PagesXamarin.Views
{
    public partial class SportListPage : ContentPage
    {
        public SportListPage()
        {
            InitializeComponent();
            var vm = new ViewModels.SportListPageViewModel();
            BindingContext = vm;
            InitializeComponent();
        }

        SearchBar searchBar = null;
        private void OnFilterTextChanged(object sender, TextChangedEventArgs e)
        {
            searchBar = (sender as SearchBar);
            if (listView.DataSource != null)
            {
                this.listView.DataSource.Filter = FilterContacts;
                this.listView.DataSource.RefreshFilter();
            }
        }

        private bool FilterContacts(object obj)
        {
            try
            {
                if (searchBar == null || searchBar.Text == null)
                    return true;

                var aluno = new Aluno();
                aluno = obj as Aluno;
                if (aluno.NameAluno.ToLower().Contains(searchBar.Text.ToLower())
                       || aluno.NameResponsanvel.ToLower().Contains(searchBar.Text.ToLower())
                       || aluno.CelResponsavel.ToLower().Contains(searchBar.Text.ToLower()))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                //var test = ex.Message;
                return false;
            }

        }

    }
}
