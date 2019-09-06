using ItemTappedEventArgs = Syncfusion.ListView.XForms.ItemTappedEventArgs;

namespace PagesXamarin.Controls
{
    /// <summary>
    /// NonSelectable list view.
    /// Assina evento ItemSelected para setar valor nulo ao clicar no item.
    /// Isso vai fazer com que item clicado não fique selecionado.
    /// 
    /// No iOS precisa se custom render para fazer o item não piscar.
    /// Ver iOS/Renderers/NonSelectableListViewRenderer
    /// </summary>
    public class NonSelectableListView : ListView
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
            ((ListView)sender).SelectedItem = null;
        }
    }
}