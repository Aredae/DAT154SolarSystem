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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Color = System.Windows.Media.Brushes;

namespace SpaceSim
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
	/// 

    public partial class MainWindow : Window
    {
		double increase;
		double time=0;
		double x = 0;
		double y = 0;
		DispatcherTimer timer = new DispatcherTimer();
		List<SpaceObject> solarSystem;
		Dictionary<string, Ellipse> planets_view;
		Dictionary<String, Ellipse> orbits_view;

		public MainWindow()
        {
			planets_view = new Dictionary<string, Ellipse>();
			orbits_view = new Dictionary<String, Ellipse>();
			InitializeComponent();
			canvas.Measure(new System.Windows.Size(Double.PositiveInfinity, Double.PositiveInfinity));
			canvas.Arrange(new Rect(canvas.DesiredSize));
			canvas.Background = Color.Black;
			solarSystem = new List<SpaceObject>
		{
			new Star("Sun",0,0,696.3,30,Color.Red, 0,0, ""),
			new Planet("Mercury", 58, 88, 7.8,88, Color.Orange,58,0,"Sun"),
			new Planet("Venus", 138,224,19,225,Color.Brown, 108,0,"Sun"),
			new Planet("Terra", 220, 365,6.3,1,Color.Blue, 150, 0,"Sun"),
			new Satellite("The Moon",0.504,30, 1.7, 1, Color.Red, 384400,0,"Terra"),
			new Comet("Hyakutake", 400,150, 10.1, 400, Color.Yellow, 400,0,"Sun"),
			new Asteroid("Haumea",600,200.39, 10.51, 0.51, Color.Green, 600,0,"Sun"),
			//new AsteroidBelt("Kuiper Belt",343557, 4343, 4343, 3434234, Color.Purple, 343557,0,"Sun"),
			new Dwarf("Pluto", 5874,248*365,1.15,5,Color.White,5874,0,"Sun"),
			//new Dwarf("Eris", 5500,2036,1.16,1,Color.Gray, 5500,0,"Sun"),
			new Satellite("ISS", 0.270, 1, 0.001, 1, Color.Pink,0,0, "Terra"),
			new Planet("Mars", 258, 687, 3.9, 1, Color.Red,0,0, "Sun"),
			new Satellite("Phobos", 0.039, 0.32, 1, 1, Color.Gray,0,0, "Mars"),
			new Satellite("Deimos", 0.053, 1.26, 1, 1, Color.Gray,0,0, "Mars"),
			new Planet("Jupiter", 808, 4332, 71, 0.45, Color.Salmon,0,0, "Sun"),
			new Satellite("Metis", 0.158, 0.29, 1 ,1, Color.Gray,0,0, "Jupiter"),
			new Satellite("Adrastea", 0.159, 0.3, 1 ,1, Color.Gray,0,0, "Jupiter"),
			new Satellite("Amalthea", 0.211, 0.5, 1 ,1, Color.Gray,0,0, "Jupiter"),
			new Satellite("Thebe", 0.252, 0.267, 1 ,1, Color.Gray,0,0, "Jupiter"),
			new Satellite("Io", 0.452, 1.77, 1 ,1, Color.Gray,0,0, "Jupiter"),
			new Satellite("Europa", 0.701, 3.55, 1 ,1, Color.Gray,0,0, "Jupiter"),
			new Satellite("Ganymede", 1.280, 7.15, 1 ,1, Color.Gray,0,0, "Jupiter"),
			new Satellite("Callisto", 2.093, 16.69, 1 ,1, Color.Gray,0,0, "Jupiter"),
			new Planet("Saturn", 1450, 10768, 58, 1, Color.Goldenrod,0,0, "Sun"),
			new Satellite("Pan", 0.164, 0.58, 1, 1, Color.Gray,0,0, "Saturn"),
			new Satellite("Mimas", 0.216, 0.94, 1, 1, Color.Gray,0,0, "Saturn"),
			new Satellite("Enceladus", 0.268, 1.37, 1, 1, Color.Gray,0,0, "Saturn"),
			new Satellite("Tethys", 0.325, 1.89, 1, 1, Color.Gray,0,0, "Saturn"),
			new Satellite("Dione", 0.407, 2.74, 1, 1, Color.Gray,0,0, "Saturn"),
			new Satellite("Rhea", 0.557, 4.52, 1, 1, Color.Gray,0,0, "Saturn"),
			new Planet("Uranus", 2901,30687, 25.5, 0.70, Color.Cyan,0,0, "Sun"),
			new Satellite("Cordelia", 0.35, 0.34, 1,1, Color.Gray,0,0, "Uranus"),
			new Satellite("Ophelia", 0.084, 0.38, 1,1, Color.Gray,0,0, "Uranus"),
			new Satellite("Bianca", 0.089, 0.43, 1,1, Color.Gray,0,0, "Uranus"),
			new Satellite("Cressida", 0.092, 0.46, 1,1, Color.Gray,0,0, "Uranus"),
			new Satellite("Desdemona", 0.093, 0.47, 1,1, Color.Gray,0,0, "Uranus"),
			new Planet("Neptune", 4528, 60190, 25, 0.66, Color.DarkBlue,0,0, "Sun"),
			new Satellite("Naiad",0.078,0.29,1,1,Color.Gray,0,0,"Neptune"),
			new Satellite("Thalassa",0.080,0.31,1,1,Color.Gray,0,0,"Neptune"),
			new Satellite("Despina",0.083,0.33,1,1,Color.Gray,0,0,"Neptune"),
			new Satellite("Galatea",0.092,0.43,1,1,Color.Gray,0,0,"Neptune"),
			new Satellite("Larissa",0.104,0.55,1,1,Color.Gray,0,0,"Neptune"),
			new Satellite("Charon",0.030,6.39,0.51,0.51,Color.Gray,0,0,"Pluto"),

		};

			double rx = 0;
			double ry = 0;
			foreach (SpaceObject obj in solarSystem)
			{
				obj.calcPos(time);

				if (obj is Satellite)
				{
					rx = obj.xpos + solarSystem.Find(x => x.name == obj.origin).xpos;
					ry = obj.ypos + solarSystem.Find(x => x.name == obj.origin).ypos;
					rx = Math.Round(rx, 2);
					ry = Math.Round(ry, 2);
				}
				else {
					rx = Math.Round(obj.xpos, 2);
					ry = Math.Round(obj.ypos, 2);
				}

				double WindowSizeX = canvas.ActualWidth-300;
				double WindowSizeY = canvas.ActualHeight;

				Ellipse rocks = new Ellipse
				{
					Fill = obj.objectcolor,
					Stroke = Brushes.White,
					HorizontalAlignment = HorizontalAlignment.Center,
					VerticalAlignment = VerticalAlignment.Center,
					Width = 5 * Math.Sqrt(obj.objectRadius),
					Height = 5 * Math.Sqrt(obj.objectRadius),
					MaxHeight = 200,
					MaxWidth = 200,
				};

				x = (WindowSizeX - rocks.Width) / 2 + rx;
				y = (WindowSizeY - rocks.Height) / 2 + ry;

				if (obj == solarSystem[0]) {
					Canvas.SetTop(rocks, (WindowSizeY - rocks.Height) / 2);
					Canvas.SetLeft(rocks, (WindowSizeX- rocks.Width)/2);
				}
				else
				{
					Canvas.SetTop(rocks, y);
					Canvas.SetLeft(rocks, x);
				}

				Ellipse orbit = new Ellipse
				{

					Fill = Brushes.Transparent,
					Stroke = Brushes.White,
					HorizontalAlignment = HorizontalAlignment.Center,
					VerticalAlignment = VerticalAlignment.Center,
					Height = 2 * (obj.xpos),
					Width = 2 * (obj.xpos),
				};

				if (obj is Satellite) {

					Canvas.SetTop(orbit, (WindowSizeY - orbit.Height) / 2 +ry-obj.ypos);
					Canvas.SetLeft(orbit, (WindowSizeX - orbit.Width) / 2 +rx-obj.xpos);

				}
				else
				{
					Canvas.SetTop(orbit, (WindowSizeY - orbit.Height) / 2 );
					Canvas.SetLeft(orbit, (WindowSizeX - orbit.Width) / 2 );
				}

				canvas.Children.Add(orbit);
				planets_view.Add(obj.name, rocks);
				orbits_view.Add(obj.name, orbit);
				canvas.Children.Add(rocks);
				
			}
			
			timer.Tick += new EventHandler(update);
			timer.Interval = new TimeSpan(0, 0, 0, 0,200);
			timer.Start();
			KeyDown += onKeyHandler;
        }

		private void update(object sender, EventArgs a)
		{


			double rx = 0;
			double ry = 0;
			foreach (SpaceObject obj in solarSystem.Skip(1))
			{
				Ellipse planetv2 = planets_view[obj.name];
				Ellipse orbitv2 = orbits_view[obj.name];
				obj.calcPos(time);

				if (obj is Satellite)
				{
					rx = obj.xpos + solarSystem.Find(x => x.name == obj.origin).xpos;
					ry = obj.ypos + solarSystem.Find(x => x.name == obj.origin).ypos;
					rx = Math.Round(rx, 2);
					ry = Math.Round(ry, 2);
				}
				else
				{
					rx = Math.Round(obj.xpos, 2);
					ry = Math.Round(obj.ypos, 2);
				}

				double WindowSizeX = canvas.ActualWidth-300;
				double WindowSizeY = canvas.ActualHeight;

				x = (WindowSizeX - planetv2.Width) / 2 + rx;
				y = (WindowSizeY - planetv2.Height) / 2 + ry;

				if (obj == solarSystem[0])
				{
					Canvas.SetTop(planetv2, (WindowSizeY - planetv2.Height) / 2);
					Canvas.SetLeft(planetv2, (WindowSizeX - planetv2.Width) / 2);
				}
				else
				{
					Canvas.SetTop(planetv2, y);
					Canvas.SetLeft(planetv2, x);
				}
				if (obj is Satellite)
				{

					Canvas.SetTop(orbitv2, (WindowSizeY - orbitv2.Height) / 2 + ry - obj.ypos);
					Canvas.SetLeft(orbitv2, (WindowSizeX - orbitv2.Width) / 2 + rx - obj.xpos);

				}
				else
				{
					Canvas.SetTop(orbitv2, (WindowSizeY - orbitv2.Height) / 2);
					Canvas.SetLeft(orbitv2, (WindowSizeX - orbitv2.Width) / 2);
				}

				time += 0.02+increase;

			}


		}

		public void onKeyHandler(Object sender, KeyEventArgs a)
		{

			if(a.Key == Key.Down)
			{
				if(increase <=0)
				{
					increase = 0;
				}
				else
				{
					increase -= 0.2;
				}
			}
			if(a.Key == Key.Up)
			{
				//if(time == 1)
				//{
					//time = 1;
				//}
				//else
				//{
					increase += 0.2;
				//}
			}
			if(a.Key == Key.Space)
			{
				if (timer.IsEnabled)
				{
					timer.Stop();
				}
				else
				{
					timer.Start();
				}
			}

		}

	}
}
