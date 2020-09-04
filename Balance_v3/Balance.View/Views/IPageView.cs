using Balance.Model;
using Balance.ViewModel.Interface;

namespace Balance.View.Views
{
    public interface IPageView<T> where T : CommonModel, new()
    {
        void SetEditing();
        MyCommonViewModel<T> myCommonViewModel { get; }
    }
}
