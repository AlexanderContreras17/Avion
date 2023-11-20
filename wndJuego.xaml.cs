using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Avion
{
    /// <summary>
    /// Lógica de interacción para wndJuego.xaml
    /// </summary>
    public partial class wndJuego : Window
    {
        public wndJuego()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // MessageBox.Show(area.ActualWidth.ToString());
            st.Completed += St_Completed;
            da.Duration = new Duration(TimeSpan.FromMilliseconds(500));
            Storyboard storyboard = new Storyboard();
            movAvion.BeginAnimation(TranslateTransform.XProperty, da);
            Storyboard.SetTargetName(da, "movAvion");
            Storyboard.SetTargetProperty(da,
                new PropertyPath(TranslateTransform.XProperty));
            st.Children.Add(da);
        }

        private void St_Completed(object? sender, EventArgs e)
        {
            estaActiva = false;
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            var pos=e.GetPosition(this);
            CordX.Text = $"x:{pos.X}";
            CordY.Text = $"y:{pos.Y}";
        }
        int cont = 0;
        DoubleAnimation da = new DoubleAnimation();
        Storyboard st = new Storyboard();   
        bool estaActiva=false;
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            Tecla.Text = $"tecla: {e.Key.ToString()}";
            //if (e.Key==Key.Up)
            //{
            //    cont++;
            //   Contador.Text = $"c:{cont}";
            //}
            
            if (e.Key == Key.Left)
            {
                if (estaActiva)
                {
                    return;
                }
                
                da.By = -20;
               
                st.Begin(avion);
                estaActiva = true;
            }
            if (e.Key == Key.Right)
            {
                if (estaActiva)
                {
                    return;
                }

                da.By = 20;
               
                st.Begin(avion);
                estaActiva = true;
            }
        }
    }
}
