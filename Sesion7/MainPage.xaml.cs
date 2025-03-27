using System.Threading;

namespace Sesion7
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        ProgressBar progressBar;
        Thread[] tasks;
        private readonly object locker = new object(); //solo lectura
        public MainPage()
        {
            InitializeComponent(); //siempre tiene que estar el primero
            progressBar = new ProgressBar //Para añadir elemento en tiempo de ejecucion

            {
                Progress = 0,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center
            };
            Layout.Children.Add(progressBar); //coger los hijos del layout y los añadimos

            Progreso();
            tasks = new Thread[100];
            for (int i = 0; i <= 1000; i++) 
            {
                tasks[i] = new Thread(() => Texto(i.ToString()));
                tasks[i].Start();
            }

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
        private async void Progreso()
        {
            for (int i = 0; i <= 100; i++)
            {
                progressBar.Progress = i/100.0;
                await Task.Delay(500);
            }
        }
        private async void Texto(String txt)
        {
            await Task.Delay(5000);
            lock (locker)
            {
                RelojLBL.Text = txt;
            }
            
        }
    }

}
