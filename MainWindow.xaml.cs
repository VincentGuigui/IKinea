using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Linq.Expressions;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Kinect;
using Microsoft.Kinect.Toolkit;
using IKinea.ViewModels;
using IKinea.Services;
using System.ComponentModel;

namespace IKinea
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window, INotifyPropertyChanged
	{
		MeasureViewModel vm;
		FurnitureViewModel furnitureVM;
		
		public double Scaling
		{
			get
			{
                if (KinectColorViewer != null && KinectColorViewer.Source != null)
					return
                        Viewer.ActualWidth / Viewer.ActualHeight > KinectColorViewer.Source.Width / KinectColorViewer.Source.Height
                        ? Viewer.ActualWidth / KinectColorViewer.Source.Width
                        : Viewer.ActualHeight / KinectColorViewer.Source.Height;
				return Viewer.ActualWidth / Viewer.ActualHeight > 1280d/920d
					? Viewer.ActualWidth / 1280d
					: Viewer.ActualHeight / 960d;
			}
		}

		public MainWindow()
		{
            InitializeComponent();
            GenerateSwitchToMonitorMenu();

            DataContext = Resources["MeasureViewModelDataSource"];
            vm = Resources["MeasureViewModelDataSource"] as MeasureViewModel;
            vm.FurnitureViewModel  = furnitureVM = Resources["FurnitureViewModelDataSource"] as FurnitureViewModel;

            vm.KinectChanged += SensorChooserOnKinectChanged;
            //this.sensorChooserUi.KinectSensorChooser = vm.SensorChooser;

		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			furnitureVM.LoadFurnitures();
			furnitureVM.SelectAll();
			vm.Initialize();
		}

        private void GenerateSwitchToMonitorMenu()
        {
            if (System.Windows.Forms.Screen.AllScreens.Length > 1)
            {
                int idx = 0;
                foreach (System.Windows.Forms.Screen screen in System.Windows.Forms.Screen.AllScreens)
                {
                    MenuItem menuItem = new System.Windows.Controls.MenuItem()
                    {
                        Header = "Switch to monitor " + (idx + 1),
                    };
                    menuItem.Tag = idx;
                    menuItem.Click += (s, re) =>
                    {
                        int offset = (int)-BorderThickness.Left;
                        int _idx = (int)menuItem.Tag;
                        for (int i = 0; i < _idx; i++)
                        {
                            offset += System.Windows.Forms.Screen.AllScreens[_idx].WorkingArea.Width;
                        }
                        this.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            this.WindowState = System.Windows.WindowState.Normal;
                            this.Left = offset;
                            this.WindowState = System.Windows.WindowState.Maximized;
                        }));
                    };
                    LogoContextMenu.Items.Add(menuItem);
                    idx++;
                }
            }
        }


	
		private void SensorChooserOnKinectChanged(object sender, KinectChangedEventArgs args)
		{
			if (args.NewSensor == null)
			{
				LivingRoomSample.Visibility = System.Windows.Visibility.Visible;
				KinectColorViewer.Visibility = System.Windows.Visibility.Hidden;
			}
			else
			{
				LivingRoomSample.Visibility = System.Windows.Visibility.Hidden;
				KinectColorViewer.Visibility = System.Windows.Visibility.Visible;
			}
		}

		private void Window_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				switch (e.Key)
				{
					case Key.PageUp:
						vm.Kinect.ElevationAngle = vm.Kinect.MaxElevationAngle / 2;
						break;
					case Key.PageDown:
						vm.Kinect.ElevationAngle = vm.Kinect.MinElevationAngle / 2;
						break;
					case Key.Up:
						vm.Kinect.ElevationAngle += 3;
						break;
					case Key.Down:
						vm.Kinect.ElevationAngle -= 3;
						break;
					case Key.D0:
						vm.Kinect.ElevationAngle = 0;
						break;

					case Key.H:
						vm.ComputeHeight();
						break;
					case Key.W:
						vm.ComputeWidth();
						break;
					case Key.R:
						vm.Restart();
						break;
					case Key.T:
						vm.ToggleRealTime();
						break;
					case Key.S:
						vm.DoSearch();
						break;
					case Key.N:
						vm.NextModel();
						break;
					case Key.M:
						vm.MovingMode = !vm.MovingMode;
						break;
					case Key.D:
						Random rnd = new Random();
						int w = rnd.Next(130) + 35;
						int h = rnd.Next(130) + 35;
						vm.HpxS = new Point(300, 300);
						vm.HpxE = new Point(vm.HpxS.X + w * 2, vm.HpxS.Y);
						vm.VpxS = new Point(300, 300);
						vm.VpxE = new Point(vm.VpxS.X, vm.VpxS.Y + h * 2);
						vm.Hcm = w;
						vm.Vcm = h;
						vm.HComputed = true;
						vm.VComputed = true;
						vm.DoSearch();
						break;
				}
			}
			catch
			{ }
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			vm.StopKinect();
		}

		private void ListFurnitures_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			vm.Furniture = ListFurnitures.SelectedItem as Ikinea.Rest.productsProduct;
		}

		private void Canvas_MouseMove(object sender, MouseEventArgs e)
		{
			if (vm.MovingMode)
			{
				Point pos = e.GetPosition(sender as IInputElement);
				vm.HpxS = vm.VpxS = new Point(pos.X - MouseMoveOriginInFurniture.X, pos.Y - MouseMoveOriginInFurniture.Y);
			}
		}

		private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
		{
			vm.MovingMode = false;
			vm.Furniture = null;
			vm.HComputed = vm.VComputed = false;
			vm.VpxS = vm.HpxS = e.GetPosition(sender as IInputElement);
		}


		private void Canvas_MouseUp(object sender, MouseButtonEventArgs e)
		{
			if (!vm.MovingMode)
			{
				vm.VpxE = new Point(vm.VpxS.X, e.GetPosition(sender as IInputElement).Y);
				vm.HpxE = new Point(e.GetPosition(sender as IInputElement).X, vm.HpxS.Y);
				vm.Hcm = Math.Abs(vm.HpxS.X - vm.HpxE.X) / 2;
				vm.Vcm = Math.Abs(vm.VpxS.Y - vm.VpxE.Y) / 2;
				vm.HComputed = vm.VComputed = true;
			}
		}

		Point MouseMoveOriginInFurniture = new Point();
		private void Furniture_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (vm.Furniture != null)
			{
				vm.VComputed = vm.HComputed = false;
				MouseMoveOriginInFurniture = e.GetPosition(Furniture);
				vm.MovingMode = true;
			}
		}

		private void Furniture_MouseMove(object sender, MouseEventArgs e)
		{
			if (vm.MovingMode)
			{
				Point pos = e.GetPosition(Viewer);
				vm.HpxS = vm.VpxS = new Point(pos.X - MouseMoveOriginInFurniture.X, pos.Y - MouseMoveOriginInFurniture.Y);
				e.Handled = true;
			}
		}

		private void Furniture_MouseUp(object sender, MouseButtonEventArgs e)
		{
			if (vm.Furniture != null && vm.MovingMode)
			{
				vm.MovingMode = false;
				e.Handled = true;
			}
		}

		private void Viewer_SizeChanged(object sender, System.Windows.SizeChangedEventArgs e)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs("Scaling"));
		}


		public event PropertyChangedEventHandler PropertyChanged;

		private void window_SizeChanged(object sender, SizeChangedEventArgs e)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs("Scaling"));
		}
	}
}
