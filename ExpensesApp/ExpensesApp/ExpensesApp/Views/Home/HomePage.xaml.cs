
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
            /*
            if (MainViewModel.GetInstance().Home.Expenses != null)
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
                var chart = new DonutChart() { Entries = dataChart };
                this.ChartView.Chart = chart;
            }
             
            */
             
        }

        protected override void OnAppearing()
        {
            //this.LoadChart();
        }
    }
}