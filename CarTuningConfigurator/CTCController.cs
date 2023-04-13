using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTuningConfigurator
{
    public class CTCController
    {
        private CTCModel model;

        public CTCController()
        {
            model = new CTCModel();
        }

        //Add
        public void AddRims(Rims rims)
        {
            model.AddRims(rims);
        }

        public void AddSpoiler(Spoiler spoiler)
        {
            model.AddSpoiler(spoiler);
        }

        public void AddNitro(Nitro nitro)
        {
            model.AddNitro(nitro);
        }

        public void AddEngine(Engine engine)
        {
            model.AddEngine(engine);
        }

        public void AddCar(Car car)
        {
            model.AddCar(car);
        }

        public void AddTyres(Tyres tyres)
        {
            model.AddTyres(tyres);
        }

        public void AddBreak(Break @break)
        {
            model.AddBreak(@break);
        }

        public void AddExhaust(Exhaust exhaust)
        {
            model.AddExhaust(exhaust);
        }

        public void AddTuningItems(List<TuningItem> tuningItems)
        {
            model.AddTuningItems(tuningItems);
        }

        //Delete

        public void RemoveRims(int index)
        {
            model.RemoveRims(index);
        }

        public void RemoveSpoiler(int index)
        {
            model.RemoveSpoiler(index);
        }

        public void RemoveNitro(int index)
        {
            model.RemoveNitro(index);
        }

        public void RemoveEngine(int index)
        {
            model.RemoveEngine(index);
        }

        public void RemoveCar(int index)
        {
            model.RemoveCar(index);
        }

        public void RemoveTyres(int index)
        {
            model.RemoveTyres(index);
        }

        public void RemoveBreak(int index)
        {
            model.RemoveBreak(index);
        }

        public void RemoveExhaust(int index)
        {
            model.RemoveExhaust(index);
        }

        public void RemoveTuningItems(int index)
        {
            model.RemoveTuningItems(index);
        }

        //Update

        public void UpdateRims(int index, Rims rims)
        {
            model.UpdateRims(index, rims);
        }

        public void UpdateSpoiler(int index, Spoiler spoiler)
        {
            model.UpdateSpoiler(index, spoiler);
        }

        public void UpdateNitro(int index, Nitro nitro)
        {
            model.UpdateNitro(index, nitro);
        }

        public void UpdateEngine(int index, Engine engine)
        {
            model.UpdateEngine(index, engine);
        }

        public void UpdateCar(int index, Car car)
        {
            model.UpdateCar(index, car);
        }

        public void UpdateTyres(int index, Tyres tyres)
        {
            model.UpdateTyres(index, tyres);
        }

        public void UpdateBreak(int index, Break @break)
        {
            model.UpdateBreak(index, @break);
        }

        public void UpdateExhaust(int index, Exhaust exhaust)
        {
            model.UpdateExhaust(index, exhaust);
        }

        public void UpdateTuningItems(int index, List<TuningItem> tuningItems)
        {
            model.UpdateTuningItems(index, tuningItems);
        }

    }
}
