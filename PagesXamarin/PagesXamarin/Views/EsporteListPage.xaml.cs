using System;
using System.Collections.Generic;
using Syncfusion.DataSource;
using Syncfusion.ListView.XForms;
using PagesXamarin.CustomControls;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using PagesXamarin.Models;
using Xamarin.Forms;
using PagesXamarin.ViewModels;
using System.Linq;

namespace PagesXamarin.Views
{
    public partial class EsporteListPage : ContentPage
    {

        public EsporteListPage()
        {
            var  vm = new ViewModels.EsporteListViewModel();
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
                aluno = obj as Aluno ;
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
