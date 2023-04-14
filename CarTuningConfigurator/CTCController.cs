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
        public Car ApplyTuningItemToCar(Dictionary<string, double> impacts, TuningItem item, Car carF)
        {
            if (item is Spoiler)
            {
                carF.Spoiler = (Spoiler)item;
            }
            else if (item is Rims)
            {
                carF.Rims = (Rims)item;
            }
            else if (item is Nitro)
            {
                carF.Nitro = (Nitro)item;
            }
            else if (item is Engine)
            {
                carF.Engine = (Engine)item;
            }
            else if (item is Break)
            {
                carF.Break = (Break)item;
            }
            else if (item is Exhaust)
            {
                carF.Exhaust = (Exhaust)item;
            }
            else if (item is Tyres)
            {
                carF.Tyres = (Tyres)item;
            }

            return carF;
        }

        public object[] CalculatePriceAndStats(Car car)
        {
            object[] objs = new object[2];
            Car defaultCar = GetDefaultCarModel(car.Brand);
            double TotalPriceCalc = 0;
            if (car.Spoiler != null)
            {
                car.TopSpeed = defaultCar.TopSpeed + car.Spoiler.ImpactVelocity;
                TotalPriceCalc += car.Spoiler.Price;
            }
            if (car.Rims != null)
            {
                TotalPriceCalc += car.Rims.Price;
            }
            if (car.Nitro != null)
            {
                car.nitroPower = defaultCar.nitroPower + car.Nitro.ImpactNitro;
                TotalPriceCalc += car.Nitro.Price;
            }
            if (car.Engine != null)
            {
                car.TopSpeed = car.Spoiler != null ? defaultCar.TopSpeed + car.Engine.ImpactVelocity + car.Spoiler.ImpactVelocity : defaultCar.TopSpeed + car.Engine.ImpactVelocity;
                car.Acceleration = defaultCar.Acceleration - car.Engine.ImpactAcceleration;
                car.Hp = car.Engine.ImpactHorsePower;
                TotalPriceCalc += car.Engine.Price;
            }
            if (car.Break != null)
            {
                car.BreakingForce = defaultCar.BreakingForce + car.Break.ImpactBreakingForce;
                TotalPriceCalc += car.Break.Price;
            }
            if (car.Exhaust != null)
            {
                car.nitroPower = car.Nitro != null ? defaultCar.nitroPower + car.Exhaust.ImpactNitro + car.Nitro.ImpactNitro : defaultCar.nitroPower + car.Exhaust.ImpactNitro;
                TotalPriceCalc += car.Exhaust.Price;
            }
            if (car.Tyres != null)
            {
                car.BreakingForce = car.Break != null ? defaultCar.BreakingForce + car.Tyres.ImpactBreakingForce + car.Break.ImpactBreakingForce : defaultCar.BreakingForce + car.Tyres.ImpactBreakingForce;
                car.Acceleration = car.Engine != null ? defaultCar.Acceleration - car.Tyres.ImpactAcceleration - car.Engine.ImpactAcceleration : defaultCar.Acceleration - car.Tyres.ImpactAcceleration;
                TotalPriceCalc += car.Tyres.Price;
            }

            TotalPriceCalc += defaultCar.Price;
            objs[0] = TotalPriceCalc;
            objs[1] = car;

            return objs;
        }

        public Car GetDefaultCarModel(string brand)
        {
            return model.GetDefaultCarModel(brand);
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
