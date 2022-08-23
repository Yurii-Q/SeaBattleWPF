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

namespace SeaBattleWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            player = new SeaBattle.Player(false);
            PC = new SeaBattle.Player();
            InputClassPC = new SeaBattle.InputClassPC();
            handler = new SeaBattle.Handler(player, PC);

            //var path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            //var pathImage = "\\img\\ship.jpg";
            //var fullpath = System.IO.Path.Combine(path, pathImage);

            Init();
        }

        //Fields
        SeaBattle.Handler handler;
        SeaBattle.InputClassPC InputClassPC;
        SeaBattle.Player player;
        SeaBattle.Player PC;

        private const int rangGrid = 11;
        private const int rang = rangGrid-1;

        private Image shipImage;

        //Player's fields
        private ColumnDefinition[] columnsPlayer;
        private RowDefinition[] rowsPlayer;
        private Label[] letterLabelsPlayer;
        private Label[] numberLabelsPLayer;
        private MyButton[,] buttonsPlayer;        

        //Ps's fields
        private ColumnDefinition[] columnsPC;
        private RowDefinition[] rowsPC;
        private Label[] letterLabelsPC;
        private Label[] numberLabelsPC;
        private MyButton[,] buttonsPC;

        //Methods for init
        private void Display()
        {
            for (int i = 0; i < rang; i++)
                for (int j = 0; j < rang; j++)
                {
                    //Display Player Field
                    if(player.getFieldElement(i,j) == 1)
                    {                        
                        buttonsPlayer[i, j].Content = (Image)this.FindResource("shipImage");
                    }
                    else if(player.getFieldElement(i,j) == 2)
                    {
                        buttonsPlayer[i, j].Content = (Image)this.FindResource("destroyShipImage");
                    }
                    else
                    {
                        buttonsPlayer[i, j].Content = "";
                    }

                    //Display PC Field
                    if (player.getMyMoveElement(i, j) == 1)
                    {
                        buttonsPC[i, j].Content = (Image)this.FindResource("destroyShipImage");
                    }
                    else if (player.getMyMoveElement(i, j) == 2)
                    {
                        buttonsPC[i, j].Content = (Image)this.FindResource("missImage");
                    }
                    else
                    {
                        buttonsPC[i, j].Content = "";
                    }

                    //Modify Player Field
                    if (PC.getMyMoveElement(i,j) == 2)
                    {
                        buttonsPlayer[i, j].Content = (Image)this.FindResource("missImage");
                    }                    
                }
        }//Display

        private void Init()
        {
            InitGrids();
            InitCoordinates();
            InitButtons();
        }//Init
        
        private void InitGrids()
        {         
            columnsPlayer = new ColumnDefinition[rangGrid];
            rowsPlayer = new RowDefinition[rangGrid];

            columnsPC = new ColumnDefinition[rangGrid];
            rowsPC = new RowDefinition[rangGrid];

            for (int i = 0; i < rangGrid; i++)
            {
                columnsPlayer[i] = new ColumnDefinition() { Width = new GridLength(9,GridUnitType.Star)};
                rowsPlayer[i] = new RowDefinition() { Height = new GridLength(9, GridUnitType.Star) };

                columnsPC[i] = new ColumnDefinition() { Width = new GridLength(9, GridUnitType.Star) };
                rowsPC[i] = new RowDefinition() { Height = new GridLength(9, GridUnitType.Star) };

                GridPlayerField.ColumnDefinitions.Add(columnsPlayer[i]);
                GridPlayerField.RowDefinitions.Add(rowsPlayer[i]);

                GridPCField.ColumnDefinitions.Add(columnsPC[i]);
                GridPCField.RowDefinitions.Add(rowsPC[i]);
            }
        }//InitGrids

        private void InitCoordinates()
        {
            letterLabelsPlayer = new Label[rang];
            numberLabelsPLayer = new Label[rang];

            letterLabelsPC = new Label[rang];
            numberLabelsPC = new Label[rang];

            for(int i = 0; i < rang; i++)
            {
                letterLabelsPlayer[i] = new Label() { Content = ((char)('A' + i)).ToString(),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    FontSize = 16,
                    FontWeight = FontWeights.Bold
                };
                numberLabelsPLayer[i] = new Label() { Content = i.ToString(),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    FontSize = 16, 
                    FontWeight = FontWeights.Bold                  
                };

                letterLabelsPC[i] = new Label() { Content = ((char)('A' + i)).ToString(),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    FontSize = 16,
                    FontWeight = FontWeights.Bold
                };
                numberLabelsPC[i] = new Label() { Content = i.ToString(),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    FontSize = 16,
                    FontWeight = FontWeights.Bold
                };

                Grid.SetColumn(letterLabelsPlayer[i], i+1);
                Grid.SetRow(letterLabelsPlayer[i], 0);
                GridPlayerField.Children.Add(letterLabelsPlayer[i]);

                Grid.SetColumn(numberLabelsPLayer[i], 0);
                Grid.SetRow(numberLabelsPLayer[i], i + 1);
                GridPlayerField.Children.Add(numberLabelsPLayer[i]);

                Grid.SetColumn(letterLabelsPC[i], i + 1);
                Grid.SetRow(letterLabelsPC[i], 0);
                GridPCField.Children.Add(letterLabelsPC[i]);

                Grid.SetColumn(numberLabelsPC[i], 0);
                Grid.SetRow(numberLabelsPC[i], i + 1);
                GridPCField.Children.Add(numberLabelsPC[i]);
            }            

        }//InitCoordinates

        private void InitButtons()
        {
            buttonsPlayer = new MyButton[rang, rang];
            buttonsPC = new MyButton[rang, rang];

            for (int i = 0; i < rang; i++)
                for (int j = 0; j < rang; j++)
                {
                    buttonsPlayer[i, j] = new MyButton(i, j); //{ Content = $"{i},{j}"};                   
                    buttonsPC[i, j] = new MyButton(i, j); //{ Content = $"{i},{j}"};

                    buttonsPlayer[i, j].Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#2E92AA");
                    buttonsPC[i, j].Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#2E92AA");

                    buttonsPlayer[i, j].VerticalAlignment = VerticalAlignment.Stretch;
                    buttonsPlayer[i, j].HorizontalAlignment = HorizontalAlignment.Stretch;
                    buttonsPC[i, j].VerticalAlignment = VerticalAlignment.Stretch;
                    buttonsPC[i, j].HorizontalAlignment = HorizontalAlignment.Stretch;                   

                    Grid.SetColumn(buttonsPlayer[i,j], j+1);
                    Grid.SetRow(buttonsPlayer[i,j], i+1);
                    GridPlayerField.Children.Add(buttonsPlayer[i,j]);

                    Grid.SetColumn(buttonsPC[i, j], j+1);
                    Grid.SetRow(buttonsPC[i, j], i+1);
                    GridPCField.Children.Add(buttonsPC[i, j]);
                }
            this.GridPCField.RemoveHandler(System.Windows.Controls.Primitives.ButtonBase.ClickEvent, new System.Windows.RoutedEventHandler(this.GridPCField_Click));
            Display();            
        }//InitButtons         

        //Handlers
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAutoFill_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            player.InitAuto();
            Display();
            this.GridPCField.AddHandler(System.Windows.Controls.Primitives.ButtonBase.ClickEvent, new System.Windows.RoutedEventHandler(this.GridPCField_Click));
            this.GridPlayerField.RemoveHandler(System.Windows.Controls.Primitives.ButtonBase.ClickEvent, new System.Windows.RoutedEventHandler(this.GridPlayerField_Click));
            btnAutoFill.IsEnabled = false;
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            player.zeroingField();
            PC.InitAuto();
            btnAutoFill.IsEnabled = true;
            this.GridPlayerField.AddHandler(System.Windows.Controls.Primitives.ButtonBase.ClickEvent, new System.Windows.RoutedEventHandler(this.GridPlayerField_Click));
            this.GridPCField.RemoveHandler(System.Windows.Controls.Primitives.ButtonBase.ClickEvent, new System.Windows.RoutedEventHandler(this.GridPCField_Click));
            Display();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            if (e.Key == Key.R)
                this.btnReset_Click(sender, e);
        }

        private void GridPlayerField_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            var btn = e.Source as MyButton;

            if(player.placementShip(btn.I, btn.J))
            {                
                this.GridPlayerField.RemoveHandler(System.Windows.Controls.Primitives.ButtonBase.ClickEvent, new System.Windows.RoutedEventHandler(this.GridPlayerField_Click));
                this.GridPCField.AddHandler(System.Windows.Controls.Primitives.ButtonBase.ClickEvent, new System.Windows.RoutedEventHandler(this.GridPCField_Click));
                btnAutoFill.IsEnabled = false;
            }            
            Display();
        }

        private void GridPCField_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            var btn = e.Source as MyButton;

            handler.iPlayer = btn.I;
            handler.jPlayer = btn.J;

            InputClassPC.readKeyPC(PC, handler);

            int result = handler.handler();
            Display();

            if(result == 1)
            {
                MessageBox.Show("You Win!", "You win");
            }
            else if(result == 2)
            {
                MessageBox.Show("You Lose!", "You lose");
            }
        }
    }//MainWindow

    class MyButton : Button
    {
        public MyButton(int indexI, int indexJ)
        {
            this.I = indexI;
            this.J = indexJ;
        }

        public int I { get; }
        public int J { get; }        
    }//class MyButton
}//namespace SeaBattleWPF
