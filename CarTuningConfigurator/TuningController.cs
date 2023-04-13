using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CarTuningConfigurator
{
    public  class TuningController
    {
        CTCModel model;
        public TuningController()
        {
            model = new CTCModel();
        }

        public List<TuningItem> InsertContent(string itm)
        {
            switch (itm)
            {
                case "Breaks":
                    return new List<TuningItem>(model.Breaks);
                case "Nitros":
                    return new List<TuningItem>(model.Nitros);
                case "Engines":
                    return new List<TuningItem>(model.Engines);
                case "Rims":
                    return new List<TuningItem>(model.Rims);
                case "Tyres":
                    return new List<TuningItem>(model.Tyres);
                case "Exhausts":
                    return new List<TuningItem>(model.Exhausts);
                case "Spoilers":
                    return new List<TuningItem>(model.Spoilers);
                default:
                    return new List<TuningItem>();
            }
        }

        public void AddToListBox(ListBox lbx, List<TuningItem> list)
        {
            foreach(TuningItem item in list) { 
                lbx.Items.Add(item);
            }
        }




    }
}
