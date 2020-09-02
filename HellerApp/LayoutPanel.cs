using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HellerApp
{
    public class LayoutPanel: DockPanel
    {
        public static int idPanel = 0;
        public LayoutPosition LayoutPosition { get; set; }
        public ILayoutPlacement LayoutGroup { get; set; }
        public ILayoutPlacement NestedLayout { get; set; }
        public LayoutPanel ParentPanel { get; set; }
        //public SvgLine Line { get; set; }
        public PositionPanel PanelPosiotion { get; set; }
        public LayoutPanel() : base()
        {
            LayoutPosition = LayoutPosition.CENTER_GROUP;
        }
        public LayoutPanel(LayoutPosition position, ILayoutPlacement layout, ILayoutPlacement nested, LayoutPanel parent) : base()
        {
            LayoutPosition = position;
            LayoutGroup = layout;
            NestedLayout = nested;
            ParentPanel = parent;
        }
    }
}

public enum LayoutPosition
{
    [Description("rightGroup")]
    RIGHT_GROUP,
    [Description("centerGroup")]
    CENTER_GROUP,
    [Description("topGroup")]
    TOP_GROUP,
    [Description("right")]
    RIGHT,
    [Description("center")]
    CENTER,
    [Description("top")]
    TOP
}
public enum PositionPanel
{
    First,
    Second
}