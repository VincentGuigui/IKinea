using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Microsoft.Kinect;
using IKinea;
using Microsoft.Speech.Recognition;
using System.ComponentModel;
using Microsoft.Kinect.Toolkit;
using System.Configuration;
using Ikinea.Rest;
using Microsoft.Speech.AudioFormat;
using System.Globalization;

namespace IKinea.ViewModels
{
    public class MeasureViewModel : ViewModelBase
    {
        private KinectViewer _kinectViewer = new KinectViewer();

        public KinectViewer KinectViewer
        {
            get { return _kinectViewer; }
            set
            {
                _kinectViewer = value;
                OnPropertyChanged("KinectViewer");
            }
        }

        public FurnitureViewModel FurnitureViewModel;
        private CoordinateMapper CoordinateMapper;
        private ColorImageFormat ColorImageFormat;
        public MeasureViewModel()
        {
        }

        #region Properties
        private string _status = "";
        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                OnPropertyChanged("Status");
            }
        }

        private double _Hcm = 0;
        public double Hcm
        {
            get { return _Hcm; }
            set
            {
                _Hcm = value;
                OnPropertyChanged("Hcm");
            }
        }

        private double _Vcm = 0;
        public double Vcm
        {
            get { return _Vcm; }
            set
            {
                _Vcm = value;
                OnPropertyChanged("Vcm");
            }
        }

        public Point[] Hpx
        {
            get
            {
                return new Point[] { 
                    new Point(HpxS.X, (HpxS.Y + HpxE.Y)/2), 
                    new Point(HpxE.X, (HpxS.Y + HpxE.Y)/2)};
            }
        }

        private Point _HpxS;// = new Point(50, 300);
        public Point HpxS
        {
            get { return _HpxS; }
            set
            {
                _HpxS = value;
                OnPropertyChanged("HpxS");
                OnPropertyChanged("Hpx");
                OnPropertyChanged("W");
            }
        }

        private Point _HpxE;// = new Point(600, 200);
        public Point HpxE
        {
            get { return _HpxE; }
            set
            {
                _HpxE = value;
                OnPropertyChanged("HpxE");
                OnPropertyChanged("Hpx");
                OnPropertyChanged("W");
            }
        }

        public int W
        {
            get { return (int)Math.Abs(HpxS.X - HpxE.X); }
        }

        public Point[] Vpx
        {
            get
            {
                return new Point[] { 
                    new Point((VpxS.X + VpxE.X)/2, VpxS.Y), 
                    new Point((VpxS.X + VpxE.X)/2, VpxE.Y)};
            }
        }

        private Point _VpxS;// = new Point(50, 300);
        public Point VpxS
        {
            get { return _VpxS; }
            set
            {
                _VpxS = value;
                OnPropertyChanged("VpxS");
                OnPropertyChanged("Vpx");
                OnPropertyChanged("H");
            }
        }

        private Point _VpxE;// = new Point(50, 500);
        public Point VpxE
        {
            get { return _VpxE; }
            set
            {
                _VpxE = value;
                OnPropertyChanged("VpxE");
                OnPropertyChanged("Vpx");
                OnPropertyChanged("H");
            }
        }

        public int H
        {
            get { return (int)Math.Abs(VpxS.Y - VpxE.Y); }
        }

        private bool _HComputed = false;

        public bool HComputed
        {
            get { return _HComputed; }
            set
            {
                _HComputed = value;
                OnPropertyChanged("HComputed");
            }
        }

        private bool _VComputed = false;

        public bool VComputed
        {
            get { return _VComputed; }
            set
            {
                _VComputed = value;
                OnPropertyChanged("VComputed");
            }
        }

        private bool _ShowResult = false;

        public bool ShowResult
        {
            get { return _ShowResult; }
            set
            {
                _ShowResult = value;
                OnPropertyChanged("ShowResult");
            }
        }

        private bool RealTime = false;

        ColorImagePoint hStart;
        ColorImagePoint hEnd;
        ColorImagePoint vStart;
        ColorImagePoint vEnd;

        private productsProduct _furniture;

        public productsProduct Furniture
        {
            get { return _furniture; }
            set
            {
                _furniture = value;
                _furnitureModelIndex = FurnitureViewModel.Products.IndexOf(_furniture);
                OnPropertyChanged("Furniture");
                OnPropertyChanged("FurnitureImage");
                OnPropertyChanged("FurnitureWidth");
                OnPropertyChanged("FurnitureWidthPx");
                OnPropertyChanged("FurnitureHeight");
                OnPropertyChanged("FurnitureHeightPx");
            }
        }

        private int Shelves;
        private int Doors;

        public string FurnitureImage
        {
            get
            {
                if (Furniture == null) return null;
                return Furniture.items.item.ImageZoom;
            }
            set { }
        }

        public int FurnitureWidth
        {
            get
            {
                if (Furniture == null) return 0;
                return Furniture.items.item.PictureDimensionsTuple.Item1;
            }
        }

        public int FurnitureWidthPx
        {
            get
            {
                try
                {
                    if (CoordinateMapper == null) return (int)Math.Abs(HpxS.X - HpxE.X); ;
                    ColorImagePoint furnitureTpx = CoordinateMapper.MapSkeletonPointToColorPoint(mainHand, ColorImageFormat);
                    SkeletonPoint furnitureW = new SkeletonPoint() { X = mainHand.X + FurnitureWidth / 100f, Y = mainHand.Y, Z = mainHand.Z };
                    ColorImagePoint furnitureWpx = CoordinateMapper.MapSkeletonPointToColorPoint(furnitureW, ColorImageFormat);
                    return furnitureWpx.X - furnitureTpx.X;
                }
                catch // Kinect less mode
                {
                    return FurnitureWidth * 2;
                }
            }
            set { }
        }

        public int FurnitureHeight
        {
            get
            {
                if (Furniture == null) return 0;
                return Furniture.items.item.PictureDimensionsTuple.Item3;
            }
        }

        public int FurnitureHeightPx
        {
            get
            {
                try
                {
                    if (CoordinateMapper == null) return (int)Math.Abs(VpxS.Y - VpxE.Y);
                    ColorImagePoint furnitureTpx = CoordinateMapper.MapSkeletonPointToColorPoint(mainHand, ColorImageFormat);
                    SkeletonPoint furnitureH = new SkeletonPoint() { X = mainHand.X, Y = mainHand.Y - FurnitureHeight / 100f, Z = mainHand.Z };
                    ColorImagePoint furnitureHpx = CoordinateMapper.MapSkeletonPointToColorPoint(furnitureH, ColorImageFormat);
                    return furnitureHpx.Y - furnitureTpx.Y;
                }
                catch // Kinect less mode
                {
                    return FurnitureHeight * 2;
                }
            }
            set { }
        }

        private bool _movingMode = false;
        public bool MovingMode
        {
            get { return _movingMode; }
            set
            {
                _movingMode = value;
                OnPropertyChanged("MovingMode");
            }
        }
        #endregion

        public void MapBodyHMetricsToColor()
        {
            //mainHand = Math.Abs(handLeft.X - spine.X) > Math.Abs(handRight.X - spine.X) ? handLeft : handRight;
            hStart = CoordinateMapper.MapSkeletonPointToColorPoint(handLeft, ColorImageFormat);
            hEnd = CoordinateMapper.MapSkeletonPointToColorPoint(handRight, ColorImageFormat);
        }

        public void MapBodyVMetricsToColor()
        {
            GetMainHand();
            vEnd = CoordinateMapper.MapSkeletonPointToColorPoint(foot, ColorImageFormat);
            vStart = CoordinateMapper.MapSkeletonPointToColorPoint(mainHand, ColorImageFormat);
        }

        private void ComputeH()
        {
            HpxS = new Point(hStart.X, hStart.Y);
            HpxE = new Point(hEnd.X, hEnd.Y);
            Hcm = SkeletonMath.Distance(handLeft, handRight) * 100f;
            HComputed = true;
        }

        private void ComputeV()
        {
            VpxS = new Point(vStart.X, vStart.Y);
            VpxE = new Point(vStart.X, vEnd.Y);
            Vcm = Math.Abs(mainHand.Y - foot.Y) * 100f;
            VComputed = true;
        }

        #region Kinect

        public KinectSensor Kinect { get; set; }

        public void Initialize()
        {
            try
            {
                //if (KinectSensor.KinectSensors.Count > 0 && !DesignerProperties.GetIsInDesignMode(Application.Current.MainWindow))
                //{

                //this.SensorChooser = new KinectSensorChooser();
                //this.SensorChooser.KinectChanged += SensorChooserOnKinectChanged;
                this.KinectChanged += KinectViewer.OnKinectSensorChanged;
                //this.SensorChooser.Start();
                KinectSensor.KinectSensors.StatusChanged += KinectSensors_StatusChanged;
                KinectSensor kinect = KinectSensor.KinectSensors.FirstOrDefault(k => k.Status == KinectStatus.Connected);
                if (kinect != null)
                {
                    InitKinect(kinect, new KinectChangedEventArgs(null, kinect));
                }


                //}
            }
            catch (Exception e)
            {
            }
        }

        void KinectSensors_StatusChanged(object sender, StatusChangedEventArgs e)
        {
            switch (e.Status)
            {
                case KinectStatus.Undefined:
                case KinectStatus.Disconnected:
                    break;
                case KinectStatus.Connected:
                    InitKinect(e.Sensor, new KinectChangedEventArgs(null, e.Sensor));
                    break;
            }
        }

        public event EventHandler<KinectChangedEventArgs> KinectChanged;
        public event EventHandler<SkeletonFrameReadyEventArgs> SkeletonFrameReady;

        private void SensorChooserOnKinectChanged(object sender, KinectChangedEventArgs args)
        {
            bool error = false;
            if (args.OldSensor != null)
            {
                try
                {
                    args.OldSensor.SkeletonStream.Disable();
                }
                catch (InvalidOperationException)
                {
                    // KinectSensor might enter an invalid state while enabling/disabling streams or stream features.
                    // E.g.: sensor might be abruptly unplugged.
                    error = true;
                }
            }

            if (args.NewSensor != null)
            {
                try
                {
                    InitKinect(sender, args);
                }
                catch (InvalidOperationException)
                {
                    error = true;
                    // KinectSensor might enter an invalid state while enabling/disabling streams or stream features.
                    // E.g.: sensor might be abruptly unplugged.
                }
            }
            else
            {
                this.CoordinateMapper = null;
                if (KinectChanged != null)
                    KinectChanged(sender, args);
            }
        }

        private void InitKinect(object sender, KinectChangedEventArgs args)
        {
            Dispatcher.CurrentDispatcher.BeginInvoke(new Action(() =>
            {
                Kinect = args.NewSensor;
                Kinect.ColorStream.Enable(ColorImageFormat.RgbResolution1280x960Fps12);
                Kinect.DepthStream.Enable(DepthImageFormat.Resolution640x480Fps30);
                Kinect.SkeletonStream.Enable();
                Kinect.SkeletonFrameReady += OnSkeletonFrameReady;
                if (KinectChanged != null)
                    KinectChanged(sender, args);
                this.CoordinateMapper = this.Kinect.CoordinateMapper;
                Kinect.Start();
                InitKinectAudio();
                OnPropertyChanged("KinectViewer");
            }));
        }

        Skeleton[] skeletons = new Skeleton[6];
        Skeleton skeleton;
        SkeletonPoint handLeft;
        SkeletonPoint handRight;
        SkeletonPoint foot;
        SkeletonPoint bodyCenter;
        SkeletonPoint mainHand;

        private void OnSkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            using (SkeletonFrame frame = e.OpenSkeletonFrame())
            {
                if (frame != null)
                {
                    frame.CopySkeletonDataTo(skeletons);
                    this.ColorImageFormat = Kinect.ColorStream.Format;
                    skeleton = skeletons.Where(s => s.TrackingState == SkeletonTrackingState.Tracked).OrderBy(s => s.Position.Z).FirstOrDefault();
                    if (skeleton != null)
                    {
                        if (RealTime)
                        {
                            GetBodyMetrics();
                            MapBodyHMetricsToColor();
                            MapBodyVMetricsToColor();
                            ComputeH();
                            ComputeV();
                            DoSearch();
                        }
                        if (MovingMode)
                        {
                            GetBodyMetrics();
                            GetMainHand();
                            hStart = CoordinateMapper.MapSkeletonPointToColorPoint(mainHand, ColorImageFormat);
                            VpxS = HpxS = new Point(hStart.X - FurnitureWidthPx / 2, hStart.Y);
                            OnPropertyChanged("FurnitureWidthPx");
                            OnPropertyChanged("FurnitureHeightPx");
                        }
                        if (SkeletonFrameReady != null)
                            SkeletonFrameReady(sender, e);
                    }
                }
            }
        }

        private void GetBodyMetrics()
        {
            if (skeleton != null)
            {
                lock (skeleton)
                {
                    handLeft = skeleton.Joints[JointType.HandLeft].Position;
                    handRight = skeleton.Joints[JointType.HandRight].Position;
                    foot = skeleton.Joints[JointType.FootLeft].Position;
                    bodyCenter = skeleton.Joints[JointType.HipCenter].Position;
                }
            }
        }

        public void StopKinect()
        {
            if (_speechEngine != null)
            {
                _speechEngine.SpeechRecognized -= this.OnSpeechRecognized;
                _speechEngine.SpeechRecognitionRejected -= this.OnSpeechRecognitionRejected;
                _speechEngine.RecognizeAsyncCancel();
                _speechEngine.UnloadAllGrammars();
                //_speechEngine.Dispose();
            }
            if (this._kinectAudioSource != null)
                this._kinectAudioSource.Stop();

            if (Kinect != null)
            {
                Kinect.SkeletonFrameReady -= OnSkeletonFrameReady;
                Kinect.ColorStream.Disable();
                Kinect.SkeletonStream.Disable();
                Kinect.AudioSource.Stop();
                //SensorChooser.Stop();
                Kinect.Stop();
            }
        }
        #endregion

        #region Kinect Audio

        private SpeechRecognitionEngine _speechEngine;
        private KinectAudioSource _kinectAudioSource;

        private void InitKinectAudio()
        {

            this._kinectAudioSource = Kinect.AudioSource;

            this._kinectAudioSource.BeamAngleMode = BeamAngleMode.Automatic;
            this._kinectAudioSource.EchoCancellationMode = EchoCancellationMode.CancellationAndSuppression;
            this._kinectAudioSource.AutomaticGainControlEnabled = false;
            this._kinectAudioSource.NoiseSuppression = true;

            // Initialisation de la commande vocale
            this._speechEngine = this.CreateSpeechRecognizer();

        }

        /// <summary>
        /// Va chercher le pack de langue Francais pour Kinect
        /// </summary>
        /// <returns>Pack de langue, NULL sinon</returns>
        private RecognizerInfo GetKinectRecognizer(string language)
        {
            foreach (RecognizerInfo pack in SpeechRecognitionEngine.InstalledRecognizers())
            {
                Console.WriteLine(pack.Id);
                if (pack.Culture.Name == language && pack.Id.ToLower().Contains("kinect"))
                    return (pack);
            }

            return (null);
        }

        /// <summary>
        /// Crée une instance de détection vocale
        /// </summary>
        /// <returns>Instance de détection vocale, NULL sinon</returns>
        private SpeechRecognitionEngine CreateSpeechRecognizer()
        {
            // Récupération du fichier de reconnaissance Francais pour Kinect
            string language = ConfigurationManager.AppSettings["Language"];
            RecognizerInfo ri = this.GetKinectRecognizer(language);
            if (ri == null)
            {
                MessageBox.Show("Unable to find Language Pack for " + language, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (ri == null)
                return null;

            // Création du moteur Speech avec ce fichier de reconnaissance

            SpeechRecognitionEngine engine = new SpeechRecognitionEngine(ri.Id);

            // Chargement de la grammaire

            engine.LoadGrammar(this.CreateGrammar(ri.Culture));

            // On s'abonne à l'événement de détection

            engine.SpeechRecognized += this.OnSpeechRecognized;
            engine.SpeechRecognitionRejected += OnSpeechRecognitionRejected;

            // On démarre la détection

            //engine.SetInputToDefaultAudioDevice();
            engine.SetInputToAudioStream(
                    _kinectAudioSource.Start(),
                    new SpeechAudioFormatInfo(EncodingFormat.Pcm, 16000, 16, 1, 32000, 2, null));
            engine.RecognizeAsync(RecognizeMode.Multiple);

            // On retourne l'instance

            return (engine);
        }


        class ChoiceAction
        {
            private static string[] NUMBERS;
            public string Key;
            public SemanticResultKey SemanticResultKey;
            public Action<SemanticValue> Action;

            public ChoiceAction(string language, string key, Action<SemanticValue> action)
            {
                if (NUMBERS == null)
                    NUMBERS = ConfigurationManager.AppSettings[language + "_numbers"].Split('|');
                Key = key;
                Action = action;
                string vocabulary = ConfigurationManager.AppSettings[language + "_" + key];
                if (string.IsNullOrWhiteSpace(vocabulary))
                    return;
                GrammarBuilder grammarBuilder = new GrammarBuilder();

                if (vocabulary.Contains("|"))
                {
                    Choices choices = new Choices();
                    foreach (string choice in vocabulary.Split('|'))
                    {
                        choices.Add(CreateSubGrammarWithWildcard(choice));
                    }
                    grammarBuilder.Append(choices);
                }
                else
                    grammarBuilder.Append(CreateSubGrammarWithWildcard(vocabulary));
                SemanticResultKey = new SemanticResultKey(key, grammarBuilder);
            }

            private GrammarBuilder CreateSubGrammarWithWildcard(string vocabulary)
            {
                if (vocabulary.Contains("*"))
                {
                    string[] subchoicesWildcard = vocabulary.Split('*');
                    GrammarBuilder grammarBuilder = new GrammarBuilder();
                    for (int i = 0; i < subchoicesWildcard.Length; i++)
                    {
                        grammarBuilder.Append(CreateSubGrammarWithDigits(subchoicesWildcard[i]));
                        if (i < subchoicesWildcard.Length - 1)
                            grammarBuilder.AppendWildcard();
                    }
                    return grammarBuilder;
                }
                else
                    return new Choices(CreateSubGrammarWithDigits(vocabulary));
            }

            private GrammarBuilder CreateSubGrammarWithDigits(string vocabulary)
            {
                if (vocabulary.Contains("#"))
                {
                    string[] subchoicesWildcard = vocabulary.Split('#');
                    GrammarBuilder grammarBuilder = new GrammarBuilder();
                    for (int i = 0; i < subchoicesWildcard.Length; i++)
                    {
                        grammarBuilder.Append(subchoicesWildcard[i]);
                        Choices numbersChoices = new Choices();
                        if (i < subchoicesWildcard.Length - 1)
                        {
                            for (int n = 0; n < NUMBERS.Length; n++)
                            {
                                numbersChoices.Add(new SemanticResultValue(NUMBERS[n], n));
                            }
                            grammarBuilder.Append(new SemanticResultKey("number", numbersChoices));
                        }
                    }
                    return grammarBuilder;
                }
                else
                    return new Choices(vocabulary);
            }
        }

        List<ChoiceAction> choicesDictionary = new List<ChoiceAction>();

        private void LoadChoices(string language)
        {
            choicesDictionary.Add(new ChoiceAction(language, "width", (s) =>
            {
                ComputeWidth();
            }));
            choicesDictionary.Add(new ChoiceAction(language, "height", (s) =>
            {
                ComputeHeight();
            }));
            choicesDictionary.Add(new ChoiceAction(language, "restart", (s) =>
            {
                Restart();
            }));
            choicesDictionary.Add(new ChoiceAction(language, "realtime", (s) =>
            {
                ToggleRealTime();
            }));
            choicesDictionary.Add(new ChoiceAction(language, "search", (s) =>
            {
                RealTime = false;
                DoSearch();
            }));
            choicesDictionary.Add(new ChoiceAction(language, "shelves", (s) =>
            {
                Shelves = (int)s["number"].Value;
                DoSearch();
            }));
            choicesDictionary.Add(new ChoiceAction(language, "doors", (s) =>
            {
                Doors = (int)s["number"].Value;
                DoSearch();
            }));
            choicesDictionary.Add(new ChoiceAction(language, "confirm", (s) =>
            {
                RealTime = false;
                HComputed = false;
                VComputed = false;
                GetBodyMetrics();
                GetMainHand();
                hStart = CoordinateMapper.MapSkeletonPointToColorPoint(mainHand, ColorImageFormat);
                VpxS = HpxS = new Point(hStart.X - FurnitureWidthPx / 2, hStart.Y);
                OnPropertyChanged("FurnitureWidthPx");
                OnPropertyChanged("FurnitureHeightPx"); 
                MovingMode = false;
            }));

            choicesDictionary.Add(new ChoiceAction(language, "next", (s) =>
            {
                NextModel();
            }));

            choicesDictionary.Add(new ChoiceAction(language, "move", (s) =>
            {
                NativeMethods.SetCursorPos(0, 0);
                RealTime = false;
                HComputed = false;
                VComputed = false;
                MovingMode = true;
            }));

            choicesDictionary.Add(new ChoiceAction(language, "fromhere", (s) =>
            {
                hStart = new ColorImagePoint();
                hEnd = new ColorImagePoint();
                GetFromHereToHereManual();
            }));

            choicesDictionary.Add(new ChoiceAction(language, "tohere", (s) =>
            {
                GetFromHereToHereManual();
            }));
        }

        public void ComputeHeight()
        {
            GetBodyMetrics();
            MapBodyVMetricsToColor();
            ComputeV();
        }

        public void ComputeWidth()
        {
            GetBodyMetrics();
            MapBodyHMetricsToColor();
            ComputeH();
        }

        /// <summary>
        /// Charge la grammaire de détection
        /// </summary>
        /// <returns>Récupère la grammaire</returns>
        private Grammar CreateGrammar(CultureInfo culture)
        {
            // Création de la liste de mots clés
            LoadChoices(culture.Name);

            // GRAMMAIRE
            Choices commands = new Choices();

            foreach (ChoiceAction ca in choicesDictionary)
            {
                GrammarBuilder phrase = new GrammarBuilder();
                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["trigger"]))
                    phrase.Append(ConfigurationManager.AppSettings["trigger"]);

                if (ca.SemanticResultKey != null)
                    phrase.Append(ca.SemanticResultKey);
                commands.Add(phrase);
            }

            // Création de la grammaire pour Speech
            GrammarBuilder grammarBuilder = new GrammarBuilder()
            {
                Culture = culture
            };
            grammarBuilder.Append(commands);

            Grammar grammar = new Grammar(grammarBuilder);
            grammar.Name = "command List";

            // Affectation de la grammaire

            return grammar;
        }

        void OnSpeechRecognitionRejected(object sender, SpeechRecognitionRejectedEventArgs e)
        {
            Status = "";
        }

        public void OnSpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Confidence < 0.4)
            {
                Status = "";
                return;
            }

            // remove trigger
            string choice = e.Result.Text;
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["trigger"]))
                choice = choice.Replace(ConfigurationManager.AppSettings["trigger"] + " ", "");
            string semanticKey = e.Result.Semantics.ElementAt(0).Key;
            ChoiceAction choiceAction = choicesDictionary.FirstOrDefault(ca => ca.Key == semanticKey);
            if (choiceAction != null)
            {
                Status = choice;//string.Format("{0} ({1:P})", choice, e.Result.Confidence);
                if (choiceAction.Action != null)
                    choiceAction.Action(e.Result.Semantics[semanticKey]);

            }
        }

        #endregion

        #region Actions

        public partial class NativeMethods
        {
            /// Return Type: BOOL->int  
            ///X: int  
            ///Y: int  
            [System.Runtime.InteropServices.DllImportAttribute("user32.dll", EntryPoint = "SetCursorPos")]
            [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
            public static extern bool SetCursorPos(int X, int Y);
        }

        private void GetFromHereToHereManual()
        {
            HComputed = false;
            GetMainHand();
            if (mainHand != new SkeletonPoint())
            {
                ColorImagePoint point = CoordinateMapper.MapSkeletonPointToColorPoint(mainHand, ColorImageFormat);
                if (mainHand.X < bodyCenter.X)
                {
                    handLeft = mainHand;
                    hStart = point;
                }
                else
                {
                    hEnd = point;
                    handRight = mainHand;
                }
            }
            if (hStart != new ColorImagePoint() && hEnd != new ColorImagePoint())
                ComputeH();
        }

        private void GetMainHand()
        {
            if (skeleton != null)
            {
                lock (skeleton)
                {
                    mainHand = new SkeletonPoint();
                    bodyCenter = skeleton.Joints[JointType.HipCenter].Position;
                    float l = SkeletonMath.Distance(skeleton.Joints[JointType.HandLeft].Position, bodyCenter);
                    float r = SkeletonMath.Distance(skeleton.Joints[JointType.HandRight].Position, bodyCenter);
                    if (l > r)
                    {
                        mainHand = skeleton.Joints[JointType.HandLeft].Position;
                    }
                    else
                    {
                        mainHand = skeleton.Joints[JointType.HandRight].Position;
                    }
                }
            }
        }

        private int _furnitureModelIndex = 0;

        public void NextModel()
        {
            if (_furnitureModelIndex < FurnitureViewModel.Products.Count - 1)
                _furnitureModelIndex++;
            else
                _furnitureModelIndex = 0;
            Furniture = FurnitureViewModel.Products[_furnitureModelIndex];
        }

        public void Restart()
        {
            FurnitureViewModel.SelectAll();
            ShowResult = false;
            Shelves = 0;
            Doors = 0;
            HpxS = new Point();
            HpxE = new Point();
            VpxS = new Point();
            VpxE = new Point();
            HComputed = false;
            VComputed = false;
            RealTime = false;
            MovingMode = false;
        }

        public void DoSearch()
        {
            FurnitureViewModel.SelectByDimensions((int)Hcm, 0, (int)Vcm, Doors, Shelves);
            if (FurnitureViewModel.Products.Count > 0)
            {
                _furnitureModelIndex = 0;
                Furniture = FurnitureViewModel.Products[_furnitureModelIndex];
            }
            else
            {
                Furniture = null;
            }
            ShowResult = true;
        }

        public void ToggleRealTime()
        {
            RealTime = !RealTime;
            if (!RealTime)
                ShowResult = false;
        }
        #endregion

    }
}
