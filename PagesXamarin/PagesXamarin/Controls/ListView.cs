using System.Windows.Input;
using Syncfusion.ListView.XForms;
using Xamarin.Forms;
using ItemTappedEventArgs = Syncfusion.ListView.XForms.ItemTappedEventArgs;

namespace PagesXamarin.Controls
{
    public class ListView : SfListView
    {
        public static readonly BindableProperty ItemTappedCommandProperty =
            BindableProperty.Create(
                nameof(ItemTappedCommand),
                typeof(ICommand),
                typeof(ListView)
            );

        public ICommand ItemTappedCommand
        {
            get => (ICommand)GetValue(ItemTappedCommandProperty);
            set => SetValue(ItemTappedCommandProperty, value);
        }

        public ListView()
        {
            ItemTapped += ListView_ItemTapped;
        }

        ~ListView()
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
}