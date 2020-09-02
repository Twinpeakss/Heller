using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace HellerApp
{
    public class Layout : EventArgs
    {
        private LayoutPanel ChoosenPanel { get; set; }

        private List<LayoutPanel> AllPanels = new List<LayoutPanel>();

        public JsonSerializeModel Model { get; set; } = new JsonSerializeModel();

        public LayoutPanel FirstPanel { get; set; }

        bool FirstPanelSplited { get; set; } = false;

        TextBox Widthsplitter { get; set; }

        TextBox Heightsplitter { get; set; }

        ILayoutPlacement ClickedLayout { get; set; }

        private static List<LayoutPanel> setsFields = new List<LayoutPanel>();

        double NewX { get; set; }

        double NewY { get; set; }


        public Layout(LayoutPanel panel, TextBox widthSplitter, TextBox heightSplitter)
        {
            ChoosenPanel = panel;
            FirstPanel = panel;
            Widthsplitter = widthSplitter;
            Heightsplitter = heightSplitter;
        }


        private List<int> DebugPanels = new List<int>();

        public void VerticalSplitter()
        {
            if (ChoosenPanel != null)
            {
                if (!FirstPanelSplited)
                {
                    ILayoutPlacement placement = Model.Placement.CenterGroupProperty = new CenterGroup();

                    var firstPanel = placement.CenterProperty = new Center
                    {
                        WidthPercent = "50%",
                        HeightPercent = "100%"
                    };
                    var secondPanel = placement.RightProperty = new Right
                    {
                        WidthPercent = "50%",
                        HeightPercent = "100%"
                    };

                    ChoosenPanel.MouseDown -= Panel_MouseDown;

                    //IsChoosenPanel.Line = new SvgLine(new Point(0, 0), new Point(Svg._width, Svg._height));

                    Grid NewGrid = GenerateGridWithColumn(placement, firstPanel, secondPanel, ChoosenPanel);
                    ChoosenPanel.Children.Add(NewGrid);
                    AllPanels.Add(ChoosenPanel);
                    //AllPanels.Add(NewGrid);
                    //layoutPanels.Push(NewGrid);
                    DebugPanels.Add(NewGrid.GetHashCode());
                    Console.WriteLine(NewGrid.GetHashCode());
                    FirstPanelSplited = true;
                }
                else
                {
                    ChoosenPanel.MouseDown -= Panel_MouseDown;
                    if (ChoosenPanel.LayoutPosition == LayoutPosition.CENTER)
                    {

                        ChoosenPanel.LayoutPosition = ResolveNewPosition(ChoosenPanel);
                        ClickedLayout.CenterProperty = null;

                        ILayoutPlacement group = ClickedLayout.CenterGroupProperty = new CenterGroup
                        {
                            WidthPercent = "100%",
                            HeightPercent = "50%"
                        };
                        ChoosenPanel.NestedLayout = group;

                        var firstPanel = group.CenterProperty = new Center
                        {
                            WidthPercent = "50%",
                            HeightPercent = "100%"
                        };
                        var secondPanel = group.RightProperty = new Right
                        {
                            WidthPercent = "50%",
                            HeightPercent = "100%"
                        };

                        Grid newLayout = GenerateGridWithColumn(group, firstPanel, secondPanel, ChoosenPanel);
                        AllPanels.Add(ChoosenPanel);
                        ChoosenPanel.Children.Add(newLayout);
                        DebugPanels.Add(newLayout.GetHashCode());
                        Console.WriteLine(newLayout.GetHashCode());
                    }
                    else if (ChoosenPanel.LayoutPosition == LayoutPosition.RIGHT)
                    {

                        ChoosenPanel.LayoutPosition = ResolveNewPosition(ChoosenPanel);
                        ClickedLayout.RightProperty = null;

                        ILayoutPlacement group = ClickedLayout.RightGroupProperty = new RightGroup
                        {
                            WidthPercent = "100%",
                            HeightPercent = "50%"
                        };
                        ChoosenPanel.NestedLayout = group;
                        var firstPanel = group.CenterProperty = new Center
                        {
                            WidthPercent = "50%",
                            HeightPercent = "100%"
                        };

                        var secondPanel = group.RightProperty = new Right
                        {
                            WidthPercent = "50%",
                            HeightPercent = "100%"
                        };

                        Grid newLayout = GenerateGridWithColumn(group, firstPanel, secondPanel, ChoosenPanel);

                        ChoosenPanel.Children.Add(newLayout);
                        AllPanels.Add(ChoosenPanel);
                        DebugPanels.Add(newLayout.GetHashCode());
                        Console.WriteLine(newLayout.GetHashCode());
                    }
                    else if (ChoosenPanel.LayoutPosition == LayoutPosition.TOP)
                    {

                        ChoosenPanel.LayoutPosition = ResolveNewPosition(ChoosenPanel);
                        ClickedLayout.TopProperty = null;
                        ILayoutPlacement group = ClickedLayout.TopGroupProperty = new TopGroup
                        {
                            WidthPercent = "100%",
                            HeightPercent = "50%"
                        };
                        ChoosenPanel.NestedLayout = group;
                        var firstPanel = group.CenterProperty = new Center
                        {
                            WidthPercent = "50%",
                            HeightPercent = "100%"
                        };
                        var secondPanel = group.TopProperty = new Top
                        {
                            WidthPercent = "50%",
                            HeightPercent = "100%"
                        };

                        Grid newLayout = GenerateGridWithColumn(group, firstPanel, secondPanel, ChoosenPanel);
                        ChoosenPanel.Children.Add(newLayout);
                        AllPanels.Add(ChoosenPanel);
                        DebugPanels.Add(newLayout.GetHashCode());
                        Console.WriteLine(newLayout.GetHashCode());
                    }

                }

                //ChoosenPanel = null;
            }
            else MessageBox.Show("Proszę zaznaczyć okno");
        }



        public void HorizontalSplitter()
        {
            if (ChoosenPanel != null)
            {
                if (FirstPanelSplited == false)
                {
                    ILayoutPlacement group = Model.Placement.CenterGroupProperty = new CenterGroup();

                    var firstPanel = group.TopProperty = new Top
                    {
                        WidthPercent = "100%",
                        HeightPercent = "50%"
                    };
                    var secondPanel = group.CenterProperty = new Center
                    {
                        WidthPercent = "100%",
                        HeightPercent = "50%"
                    };

                    //IsChoosenPanel.Line = new SvgLine(new Point(0, 0), new Point(Svg._width, Svg._height));

                    ChoosenPanel.MouseDown -= Panel_MouseDown;

                    ChoosenPanel.MouseDown -= Panel_MouseDown;

                    ChoosenPanel.LayoutPosition = LayoutPosition.CENTER;

                    Grid newLayout = GenerateGridWithRows(group, firstPanel, secondPanel, ChoosenPanel);

                    ChoosenPanel.Children.Add(newLayout);
                    AllPanels.Add(ChoosenPanel);
                    DebugPanels.Add(newLayout.GetHashCode());
                    Console.WriteLine(newLayout.GetHashCode());
                    FirstPanelSplited = true;
                }
                else
                {
                    ChoosenPanel.MouseDown -= Panel_MouseDown;
                    if (ChoosenPanel.LayoutPosition == LayoutPosition.CENTER)
                    {
                        ChoosenPanel.LayoutPosition = ResolveNewPosition(ChoosenPanel);
                        ClickedLayout.CenterProperty = null;
                        ILayoutPlacement group = ClickedLayout.CenterGroupProperty = new CenterGroup
                        {
                            HeightPercent = "100%",
                            WidthPercent = "50%"
                        };
                        ChoosenPanel.NestedLayout = group;
                        var firstPanel = group.TopProperty = new Top
                        {
                            WidthPercent = "100%",
                            HeightPercent = "50%"
                        };
                        var secondPanel = group.CenterProperty = new Center
                        {
                            WidthPercent = "100%",
                            HeightPercent = "50%"
                        };

                        Grid newLayout = GenerateGridWithRows(group, firstPanel, secondPanel, ChoosenPanel);

                        ChoosenPanel.Children.Add(newLayout);
                        AllPanels.Add(ChoosenPanel);
                        DebugPanels.Add(newLayout.GetHashCode());
                        Console.WriteLine(newLayout.GetHashCode());
                        //setsFields.Add(ChoosenPanel); // add in cause find created elements
                    }
                    else if (ChoosenPanel.LayoutPosition == LayoutPosition.TOP)
                    {

                        ChoosenPanel.LayoutPosition = ResolveNewPosition(ChoosenPanel);
                        ClickedLayout.TopProperty = null;
                        ILayoutPlacement group = ClickedLayout.TopGroupProperty = new TopGroup
                        {
                            HeightPercent = "100%",
                            WidthPercent = "50%"
                        };

                        ChoosenPanel.NestedLayout = group;

                        var firstPanel = group.TopProperty = new Top
                        {
                            WidthPercent = "50%",
                            HeightPercent = "100%"
                        };
                        var secondPanel = group.CenterProperty = new Center
                        {
                            WidthPercent = "50%",
                            HeightPercent = "100%"
                        };

                        Grid newLayout = GenerateGridWithRows(group, firstPanel, secondPanel, ChoosenPanel);
                        DebugPanels.Add(newLayout.GetHashCode());
                        ChoosenPanel.Children.Add(newLayout);
                        AllPanels.Add(ChoosenPanel);
                        Console.WriteLine(newLayout.GetHashCode());
                    }
                    else if (ChoosenPanel.LayoutPosition == LayoutPosition.RIGHT)
                    {
                        ChoosenPanel.LayoutPosition = ResolveNewPosition(ChoosenPanel);
                        ClickedLayout.RightProperty = null;
                        ILayoutPlacement group = ClickedLayout.RightGroupProperty = new RightGroup
                        {
                            HeightPercent = "100%",
                            WidthPercent = "50%"
                        };

                        ChoosenPanel.NestedLayout = group;


                        var firstPanel = group.RightProperty = new Right
                        {
                            WidthPercent = "50%",
                            HeightPercent = "100%"
                        };
                        var secondPanel = group.CenterProperty = new Center
                        {
                            WidthPercent = "50%",
                            HeightPercent = "100%"
                        };
                        Grid newLayout = GenerateGridWithRows(group, firstPanel, secondPanel, ChoosenPanel);

                        ChoosenPanel.Children.Add(newLayout);
                        AllPanels.Add(ChoosenPanel);
                        setsFields.Add(ChoosenPanel); // add in cause find created elements
                        DebugPanels.Add(newLayout.GetHashCode());
                        Console.WriteLine(newLayout.GetHashCode());
                    }
                }
                // ChoosenPanel = null;
            }
            else MessageBox.Show("Proszę zaznaczyć okno");
        }

        //Usuwa layout ostatni i pokazuje poprzednio wybrany
        //firstpanel splitted
        public void BackwardSplitter()
        {
            var count = AllPanels.Count;
            if (count > 0)
            {
                if (ChoosenPanel.Children.Count == 0)
                {
                    ChoosenPanel = ChoosenPanel.ParentPanel;
                    ChoosenPanel.Children.RemoveAt(0);
                    ChoosenPanel.MouseDown += Panel_MouseDown;
                    AllPanels.RemoveAt(count - 1);
                    Console.WriteLine(DebugPanels[DebugPanels.Count - 1]);//debug
                    DebugPanels.RemoveAt(DebugPanels.Count - 1);
                    var code = ChoosenPanel.GetHashCode();
                    Console.WriteLine(code);
                    
                }
                else
                {
                    ChoosenPanel.Children.RemoveAt(0);
                    ChoosenPanel.MouseDown += Panel_MouseDown;
                    AllPanels.RemoveAt(count - 1);
                    Console.WriteLine(DebugPanels[DebugPanels.Count - 1]);//debug
                    DebugPanels.RemoveAt(DebugPanels.Count - 1);
                    var code = ChoosenPanel.GetHashCode();
                    Console.WriteLine(code);
                   
                }
            }
            else
            {
                FirstPanelSplited = false;
            }
             
        }

            private Grid GenerateGridWithRows(ILayoutPlacement group, ILayoutPlacement firstPanel, ILayoutPlacement secondPanel, LayoutPanel parent)
            {
                Grid newGrid = new Grid();

                newGrid.RowDefinitions.Add(new RowDefinition());
                newGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(2.5) });
                newGrid.RowDefinitions.Add(new RowDefinition());

                GridSplitter gridSplitter = new GridSplitter()
                {
                    Height = 2.5,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    Background = new SolidColorBrush(Colors.Red),
                    ResizeBehavior = GridResizeBehavior.PreviousAndNext

                };


                gridSplitter.DragStarted += SizeChanged;

                LayoutPanel panel = new LayoutPanel(LayoutPosition.TOP, group, firstPanel, parent);
                LayoutPanel panel2 = new LayoutPanel(LayoutPosition.CENTER, group, secondPanel, parent);

                panel.ParentPanel = parent;
                panel2.ParentPanel = parent;

                panel.MouseDown += Panel_MouseDown;
                panel2.MouseDown += Panel_MouseDown;



                panel.Background = new SolidColorBrush(Colors.White);
                panel2.Background = new SolidColorBrush(Colors.White);

                //NewY = (IsChoosenPanel.Line.StartPoint.Y + IsChoosenPanel.Line.EndPoint.Y) / 2;


                //SvgLine line = new SvgLine(new Point(LastChoosenPanel.Line.StartPoint.X, LastChoosenPanel.Line.StartPoint.Y), new Point(LastChoosenPanel.Line.EndPoint.X, NewY));
                //SvgLine line2 = new SvgLine(new Point(LastChoosenPanel.Line.StartPoint.X, NewY), new Point(LastChoosenPanel.Line.EndPoint.X, LastChoosenPanel.Line.EndPoint.Y));

                //Svg.AddLine(line);
                //Svg.AddLine(line2);
                //Svg.AddLine(new SvgLine(new Point(LastChoosenPanel.Line.StartPoint.X, NewY), new Point(LastChoosenPanel.Line.EndPoint.X, NewY)));

                //panel.Line = line;
                //panel2.Line = line2;

                Grid.SetRow(panel, 0);
                Grid.SetRow(gridSplitter, 1);
                Grid.SetRow(panel2, 2);

                newGrid.Children.Add(panel);
                newGrid.Children.Add(gridSplitter);
                newGrid.Children.Add(panel2);

                return newGrid;
            }


            public Grid GenerateGridWithColumn(ILayoutPlacement group, ILayoutPlacement firstPanel, ILayoutPlacement secondPanel, LayoutPanel parent)
            {
                Grid newGrid = new Grid();
                newGrid.ColumnDefinitions.Add(new ColumnDefinition());
                newGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(2.5) });
                newGrid.ColumnDefinitions.Add(new ColumnDefinition());
                GridSplitter gridSplitter = new GridSplitter()
                {
                    Width = 2.5,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    Background = new SolidColorBrush(Colors.Black),
                    ResizeBehavior = GridResizeBehavior.PreviousAndNext
                };

                gridSplitter.DragStarted += SizeChanged;

                LayoutPanel panel = new LayoutPanel(LayoutPosition.CENTER, group, firstPanel, parent);
                LayoutPanel panel2 = new LayoutPanel(LayoutPosition.RIGHT, group, secondPanel, parent);

                panel.ParentPanel = parent;
                panel2.ParentPanel = parent;

                //NewX = (IsChoosenPanel.Line.StartPoint.X + IsChoosenPanel.Line.EndPoint.X) / 2;

                //SvgLine line = new SvgLine(new Point(LastChoosenPanel.Line.StartPoint.X, LastChoosenPanel.Line.StartPoint.Y), new Point(NewX, LastChoosenPanel.Line.EndPoint.Y));
                //SvgLine line2 = new SvgLine(new Point(NewX, LastChoosenPanel.Line.StartPoint.Y), new Point(LastChoosenPanel.Line.EndPoint.X, LastChoosenPanel.Line.EndPoint.Y));

                //Svg.AddLine(line);
                //Svg.AddLine(line2);
                //Svg.AddLine(new SvgLine(new Point(NewX, LastChoosenPanel.Line.StartPoint.Y), new Point(NewX, LastChoosenPanel.Line.EndPoint.Y)));

                //panel.Line = line;
                //panel2.Line = line2;

                Grid.SetColumn(panel, 0);
                Grid.SetColumn(gridSplitter, 1);
                Grid.SetColumn(panel2, 2);

                newGrid.Children.Add(panel);

                newGrid.Children.Add(gridSplitter);
                newGrid.Children.Add(panel2);

                panel.MouseDown += Panel_MouseDown;
                panel2.MouseDown += Panel_MouseDown;

                panel.Background = new SolidColorBrush(Colors.White);
                panel2.Background = new SolidColorBrush(Colors.White);

                return newGrid;
            }

            //trza sprawdzic czy grid ktory przesuwamy jest ostatni
            private void SizeChanged(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
            {
                GridSplitter splitter = (GridSplitter)sender;
                if (AllPanels[AllPanels.Count - 1].Children.GetHashCode() == splitter.GetHashCode())
                {
                    Grid gridParent = (Grid)splitter.Parent;

                    LayoutPanel panel1 = (LayoutPanel)gridParent.Children[0];
                    LayoutPanel panel2 = (LayoutPanel)gridParent.Children[2];

                    decimal width = Decimal.Round((decimal)((panel1.ActualWidth * 100) / gridParent.ActualWidth), 0);
                    decimal height = Decimal.Round((decimal)((panel1.ActualHeight * 100) / gridParent.ActualHeight), 0);

                    if (width == 100)
                    {
                        panel1.NestedLayout.HeightPercent = height.ToString() + "%";
                        panel2.NestedLayout.HeightPercent = (100 - height).ToString() + "%";
                        // panel1.Line.EndPoint = new Point(Convert.ToDouble(height), Convert.ToDouble(width));
                        // Svg.ChangeHeight(panel1.Line, height);
                    }
                    else if (height == 100)
                    {
                        panel1.NestedLayout.WidthPercent = width.ToString() + "%";
                        panel2.NestedLayout.WidthPercent = (100 - width).ToString() + "%";
                        // Svg.ChangeWidth(panel1, width);
                    }


                    Widthsplitter.Text = width.ToString();
                    Heightsplitter.Text = height.ToString();
                }


            }


            public void ShowSize(object sender, MouseButtonEventArgs e)
            {

                LayoutPanel layout = (LayoutPanel)sender;
                Grid gridParent = (Grid)layout.Parent;

                LayoutPanel panel1 = (LayoutPanel)gridParent.Children[0];
                LayoutPanel panel2 = (LayoutPanel)gridParent.Children[2];

                decimal width = Decimal.Round((decimal)((panel1.ActualWidth * 100) / gridParent.ActualWidth), 0);
                decimal height = Decimal.Round((decimal)((panel1.ActualHeight * 100) / gridParent.ActualHeight), 0);

                if (width == 100)
                {
                    panel1.NestedLayout.HeightPercent = height.ToString() + "%";
                    panel2.NestedLayout.HeightPercent = (100 - height).ToString() + "%";
                    // panel1.Line.EndPoint = new Point(Convert.ToDouble(height), Convert.ToDouble(width));
                    // Svg.ChangeHeight(panel1.Line, height);
                }
                else if (height == 100)
                {
                    panel1.NestedLayout.WidthPercent = width.ToString() + "%";
                    panel2.NestedLayout.WidthPercent = (100 - width).ToString() + "%";
                    // Svg.ChangeWidth(panel1, width);
                }


                Widthsplitter.Text = width.ToString();
                Heightsplitter.Text = height.ToString();
            }



            private void Panel_MouseDown(object sender, MouseButtonEventArgs e)
            {
                ChoosenPanel.Background = new SolidColorBrush(Colors.White);
                var ClickedWindow = (LayoutPanel)sender;
                ChoosenPanel = ClickedWindow;
                ChoosenPanel.Background = new SolidColorBrush(Colors.Indigo);
                ClickedLayout = ClickedWindow.LayoutGroup;

            }





            private LayoutPosition ResolveNewPosition(LayoutPanel panel)
            {
                switch (panel.LayoutPosition)
                {
                    case LayoutPosition.CENTER:
                        return LayoutPosition.CENTER_GROUP;

                    case LayoutPosition.RIGHT:
                        return LayoutPosition.RIGHT_GROUP;

                    case LayoutPosition.TOP:
                        return LayoutPosition.TOP_GROUP;

                    default:
                        return panel.LayoutPosition;
                }
            }



    }
}   
