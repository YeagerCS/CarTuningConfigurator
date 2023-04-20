using K4os.Compression.LZ4.Encoders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CarTuningConfigurator
{
    public class CTCController
    {
        public CTCModel model;
        private List<TuningItem?> tuningItems;

        public CTCController()
        {
            model = new CTCModel();
        }
        public Car ApplyTuningItemToCar(TuningItem? item, Car carF, string type)
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

        public void ShowMessageWindow(string title, string massage, string buttonText = "Ok", int fontsize = 35, string font = "Trebuchet MS", string backgroundColor = "Lime")
        {

            var dialog = new Window
            {
                Title = title,
                Width = 400,
                Height = 200,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(backgroundColor)),
                ResizeMode = ResizeMode.NoResize
            };

            var stackPanel = new StackPanel
            {
                Margin = new Thickness(10),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Bottom,
                Orientation = Orientation.Vertical
            };

            var messageLabel = new Label
            {
                Content = massage,
                FontSize = fontsize,
                FontFamily = new FontFamily(font),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Foreground = new SolidColorBrush(Colors.White)
            };

            var button = new Button
            {
                Content = buttonText,
                Width = 80,
                Height = 35,
                Margin = new Thickness(0, 10, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Bottom
            };

            button.Click += (sender, args) => dialog.Close();

            stackPanel.Children.Add(messageLabel);
            stackPanel.Children.Add(button);

            dialog.Content = stackPanel;

            dialog.ShowDialog();
        }

        public bool ModifyLabels(ref Label[] labels, Car car)
        {
            bool isUpdate = false;
            tuningItems = new List<TuningItem?>
            {
                car.Rims,
                car.Spoiler,
                car.Nitro,
                car.Engine,
                car.Break,
                car.Exhaust,
                car.Tyres
            };
            int i = 0;
            foreach (TuningItem item in tuningItems)
            {
                if (item != null)
                {
                    isUpdate = true;
                    labels[i].Content = item.Name;
                }
                else
                {
                    labels[i].Content = "";
                }
                i++;
            }

            return isUpdate;
        }

        public string[] SetAdditionalLabels(Car initialCar, Car finalCar)
        {
            string[] stats = new string[5];
            stats[0] = finalCar.TopSpeed > initialCar.TopSpeed ? $"+{finalCar.TopSpeed - initialCar.TopSpeed}" : $"{finalCar.TopSpeed - initialCar.TopSpeed}";
            stats[1] = finalCar.BreakingForce > initialCar.BreakingForce ? $"+{finalCar.BreakingForce - initialCar.BreakingForce}" : $"{finalCar.BreakingForce - initialCar.BreakingForce}";
            stats[2] = finalCar.Acceleration < initialCar.Acceleration ? $"{Math.Round(finalCar.Acceleration - initialCar.Acceleration, 1)}" : $"+{Math.Round(finalCar.Acceleration - initialCar.Acceleration, 1)}";
            stats[3] = finalCar.nitroPower > initialCar.nitroPower ? $"+{finalCar.nitroPower - initialCar.nitroPower}" : $"{finalCar.nitroPower - initialCar.nitroPower}";
            stats[4] = finalCar.Hp > initialCar.Hp ? $"+{finalCar.Hp - initialCar.Hp}" : $"{finalCar.Hp - initialCar.Hp}";

            return stats;
        }

        public void SaveToDatabase(Car car)
        {
            model.SaveToDatabase(car);
        }

        public void UpdateDatabase(Car car)
        {
            model.UpdateDatabase(car);
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
