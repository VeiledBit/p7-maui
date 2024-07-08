using P7.Models;
using P7.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace P7.ViewModels
{
    public class SalesViewModel : INotifyPropertyChanged
    {
        private readonly SaleItemService _saleItemService;
        private List<SaleItem> _saleItems;
        private List<string> _saleItemsCategories;
        public List<string> Stores { get; } = new List<string> { "maxi", "lidl", "elakolije", "gomex", "dis" };
        private int _selectedStoreIndex;
        private string _selectedStore;
        public List<string> Sorting { get; } = new List<string>
        {
            "category", "discountHighest", "discountLowest", "priceLowest", "priceHighest", "pricePerUnitLowest", "pricePerUnitHighest"
        };
        private int _selectedSortingIndex;
        private string _selectedSorting;
        private bool _isLoadMoreButtonVisible;
        private bool _isLoading;
        private bool _isRecommended;

        public List<SaleItem> SaleItems
        {
            get => _saleItems;
            set
            {
                _saleItems = value;
                OnPropertyChanged(nameof(SaleItems));
            }
        }

        public List<string> SaleItemsCategories
        {
            get => _saleItemsCategories;
            set
            {
                _saleItemsCategories = value;
                OnPropertyChanged(nameof(SaleItemsCategories));
            }
        }

        public int SelectedStoreIndex
        {
            get => _selectedStoreIndex;
            set
            {
                if (_selectedStoreIndex != value)
                {
                    _selectedStoreIndex = value;
                    OnPropertyChanged();
                    OnStoreChanged();
                }
            }
        }

        public string SelectedStore
        {
            get => _selectedStore;
            set
            {
                _selectedStore = value;
                OnPropertyChanged();
            }
        }

        public int SelectedSortingIndex
        {
            get => _selectedSortingIndex;
            set
            {
                if (_selectedSortingIndex != value)
                {
                    _selectedSortingIndex = value;
                    OnPropertyChanged();
                    OnSortingChanged();
                }
            }
        }

        public string SelectedSorting
        {
            get => _selectedSorting;
            set
            {
                _selectedSorting = value;
                OnPropertyChanged();
            }
        }

        public bool IsLoadMoreButtonVisible
        {
            get => _isLoadMoreButtonVisible;
            set
            {
                if (_isLoadMoreButtonVisible != value)
                {
                    _isLoadMoreButtonVisible = value;
                    OnPropertyChanged(nameof(IsLoadMoreButtonVisible));
                }
            }
        }

        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        public bool IsRecommended
        {
            get => _isRecommended;
            set
            {
                if (_isRecommended != value)
                {
                    _isRecommended = value;
                    OnPropertyChanged(nameof(_isRecommended));
                    OnIsRecommendedChanged();
                }
            }
        }

        public SalesViewModel()
        {
            _saleItemService = new SaleItemService();
            SelectedStoreIndex = 0;
            SelectedStore = Stores[SelectedStoreIndex];
            SelectedSortingIndex = 0;
            SelectedSorting = Sorting[SelectedSortingIndex];
            IsRecommended = true;
            LoadSaleItems(SelectedStore, SelectedSorting, IsRecommended);
        }

        private async void LoadSaleItems(string storeName, string sorting, bool isRecommended)
        {
            IsLoading = true;
            var response = await _saleItemService.getSaleItemsAsync(storeName, sorting, isRecommended);
            SaleItems = response.Items;
            SaleItemsCategories = response.Categories;
            IsLoadMoreButtonVisible = response.Items?.Count == 60;
            IsLoading = false;
        }

        private void OnStoreChanged()
        {
            SelectedStore = Stores[SelectedStoreIndex];
            SaleItems = new List<SaleItem>();
            IsLoadMoreButtonVisible = false;
            LoadSaleItems(SelectedStore, SelectedSorting, IsRecommended);
        }

        private void OnSortingChanged()
        {
            SelectedSorting = Sorting[SelectedSortingIndex];
            SaleItems = new List<SaleItem>();
            IsLoadMoreButtonVisible = false;
            LoadSaleItems(SelectedStore, SelectedSorting, IsRecommended);
        }

        private void OnIsRecommendedChanged()
        {
            SaleItems = new List<SaleItem>();
            IsLoadMoreButtonVisible = false;
            LoadSaleItems(SelectedStore, SelectedSorting, IsRecommended);
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
