using ExpensesApp.Models;
using ExpensesApp.Services;
using ExpensesApp.ViewModels;
using Microcharts;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpensesApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
		public HomePage ()
		{
			InitializeComponent ();
        }

        public void LoadChart()
        {
            var data = MainViewModel.GetInstance().Home.Expenses;
            List<Microcharts.Entry> dataChart = new List<Microcharts.Entry>();
            string[] color = { "#266489", "#266489", "#68B9C0", "#266456" };
            int i = 0;
            foreach (var d in data)
            {
                dataChart.Add(new Microcharts.Entry((float)d.Total)
                {
                    Label = d.Category.Name,
                    ValueLabel = d.Total.ToString(),
                    Color = SKColor.Parse(color[i])
                });
                i++;
            }
            //var entries = new[]
            //{
            //    new Microcharts.Entry(200)
            //    {
            //        Label = "January",
            //        ValueLabel = "200",
            //        Color = SKColor.Parse("#266489")
            //    },
            //    new Microcharts.Entry(400)
            //    {
            //    Label = "February",
            //    ValueLabel = "400",
            //    Color = SKColor.Parse("#68B9C0")
            //    },
            //    new Microcharts.Entry(-100)
            //    {
            //    Label = "March",
            //    ValueLabel = "-100",
            //    Color = SKColor.Parse("#90D585")
            //    }
            //};
            var chart = new DonutChart() { Entries = dataChart };
            this.ChartView.Chart = chart;
        }

        protected override void OnAppearing()
        {
            this.LoadChart();
        }
    }
}