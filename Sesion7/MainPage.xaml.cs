namespace Sesion7
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent(); //siempre tiene que estar el primero
            Time();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
        private async void Time()
        {
            while (true)
            {
                RelojLBL.Text = DateTime.Now.ToString("HH:mm:ss");
                await Task.Delay(1000); //esto es en milisegundos, espera un segundo
            }
        }
    }

}
