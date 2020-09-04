using Balance.Model;
using Balance.ViewModel.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Balance.View.Views
{
    public interface IPageView<T> where T : CommonModel, new()
    {
        void SetEditing();
        MyCommonViewModel<T> myCommonViewModel{ get; }
    }
}
