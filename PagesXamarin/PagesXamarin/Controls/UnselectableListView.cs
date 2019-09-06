using Xamarin.Forms;
namespace PagesXamarin.ControlsXamarin
{
    /// <summary>
    /// Unselectable list view p[ara Lista do Xamarin usada em Questionario
    /// Assina evento ItemSelected para setar valor nulo ao clicar no item.
    /// Isso vai fazer com que item clicado não fique selecionado.
    /// 
    /// No iOS precisa se custom render para fazer o item não piscar.
    /// Ver iOS/Renderers/UnselectableListViewRenderer
    /// </summary>
    public class UnselectableListView : ListView
    {
        public UnselectableListView()
        {
            ItemSelected += OnItemSelected;
            
        }

        ~UnselectableListView()
        {
            ItemSelected -= OnItemSelected;
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }
    }
}
