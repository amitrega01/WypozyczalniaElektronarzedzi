using System;
using System.Windows.Controls;
using ModelBazy;

namespace UI
{
    public class WypozyczenieDto :WypozyczenieView
    {
        public CheckBox Zwrocono { get; set; } = new CheckBox();
    }
}