using System.Windows.Input;
using Syncfusion.DataSource;
using Syncfusion.ListView.XForms;
using Xamarin.Forms;
using ItemTappedEventArgs = Syncfusion.ListView.XForms.ItemTappedEventArgs;

namespace WxsMobApp.CustomControls
{
    public class CustomListView : SfListView
    {
        public static readonly BindableProperty ItemTappedCommandProperty =
            BindableProperty.Create(
                nameof(ItemTappedCommand),
                typeof(ICommand),
                typeof(CustomListView)
            );

        //public static readonly BindableProperty SortNameProperty =
           //BindableProperty.Create(
           //    nameof(SortName),
           //    typeof(string),
           //    typeof(CustomListView)
           //);


        public ICommand ItemTappedCommand
        {
            get => (ICommand)GetValue(ItemTappedCommandProperty);
            set => SetValue(ItemTappedCommandProperty, value);
        }

        public string SortName { get; set; }

        public CustomListView()
        {
            this.DataSource.SortDescriptors.Add(new SortDescriptor()
            {
                PropertyName = "MonthDay",
                Direction = ListSortDirection.Ascending
            });
            ItemTapped += ListView_ItemTapped;
        }

        ~CustomListView()
        {
            ItemTapped -= ListView_ItemTapped;
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (ItemTappedCommand != null && ItemTappedCommand.CanExecute(null))
                ItemTappedCommand.Execute(e.ItemData);

            SelectedItem = null;
        }
    }

    /// <summary>
    /// NonSelectable list view.
    /// Assina evento ItemSelected para setar valor nulo ao clicar no item.
    /// Isso vai fazer com que item clicado não fique selecionado.
    /// 
    /// No iOS precisa se custom render para fazer o item não piscar.
    /// Ver iOS/Renderers/NonSelectableListViewRenderer
    /// </summary>
    public class NonSelectableListView : CustomListView
    {
        public NonSelectableListView()
        {
            ItemTapped += OnItemTapped;
        }

        ~NonSelectableListView()
        {
            ItemTapped -= OnItemTapped;
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((CustomListView)sender).SelectedItem = null;
        }
    }
}
