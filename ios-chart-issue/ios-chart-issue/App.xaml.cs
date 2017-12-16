using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace App1
{
	public partial class App
	{
		public App()
		{
			InitializeComponent();

			MainPage = new ItemDetailPage();
		}
	}
}