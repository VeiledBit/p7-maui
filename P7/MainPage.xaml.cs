using P7.Models;
using P7.ViewModels;
using System.Text.Json.Serialization;

namespace P7
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new SalesViewModel();
        }


        //private void pickerStore_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    var picker = (Picker) sender;
        //    var selectedStore = picker.SelectedItem.ToString();
        //    if (selectedStore != null)
        //    {
        //        // Send request to backend server
        //        var itemsOnSale = await FetchItemsOnSaleAsync(selectedStore);

        //        // Display the results in the CollectionView
        //        ItemsCollectionView.ItemsSource = itemsOnSale;
        //    }
        //}
    }

}
