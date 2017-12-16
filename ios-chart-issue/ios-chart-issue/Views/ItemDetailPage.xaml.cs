using System;
using System.Linq;
using Telerik.XamarinForms.Chart;

namespace App1
{
	public partial class ItemDetailPage
	{
		public ItemDetailPage()
		{
			InitializeComponent();

			// it works OK if series added from constructor
			var random = new Random(13);
			var points1 = Enumerable.Range(1, 100).Select(i => DateTime.Today.AddDays(i - 50)).Select(d => new PointViewModel { Date = d, Value = random.NextDouble() * 300d }).ToArray();
			var points2 = Enumerable.Range(1, 100).Select(i => DateTime.Today.AddDays(i - 50)).Select(d => new PointViewModel { Date = d, Value = random.NextDouble() * 300d }).ToArray();

			var lineSeries1 = new LineSeries
			{
				DisplayName = "Series 1",
				ItemsSource = points1,
				ValueBinding = new PropertyNameDataPointBinding("Value"),
				CategoryBinding = new PropertyNameDataPointBinding("Date"),
				StrokeThickness = 3
			};

			var lineSeries2 = new LineSeries
			{
				DisplayName = "Series 2",
				ItemsSource = points2,
				ValueBinding = new PropertyNameDataPointBinding("Value"),
				CategoryBinding = new PropertyNameDataPointBinding("Date"),
				StrokeThickness = 5
			};

			chart1.Series.Add(lineSeries1);
			chart1.Series.Add(lineSeries2);

			// but FAILS when added from Appearing handler
			Appearing += (sender, args) =>
			{
				var lineSeries11 = new LineSeries
				{
					DisplayName = "Series 11",
					ItemsSource = points1,
					ValueBinding = new PropertyNameDataPointBinding("Value"),
					CategoryBinding = new PropertyNameDataPointBinding("Date"),
					StrokeThickness = 3
				};

				var lineSeries22 = new LineSeries
				{
					DisplayName = "Series 22",
					ItemsSource = points2,
					ValueBinding = new PropertyNameDataPointBinding("Value"),
					CategoryBinding = new PropertyNameDataPointBinding("Date"),
					StrokeThickness = 5
				};

				chart2.Series.Add(lineSeries11);
				chart2.Series.Add(lineSeries22);
			};
		}
	}

	public sealed class DataViewModel
	{
		public PointViewModel[] Points1 { get; set; }
		public PointViewModel[] Points2 { get; set; }
	}

	public sealed class PointViewModel
	{
		public double Value { get; set; }
		public DateTime Date { get; set; }
	}
}