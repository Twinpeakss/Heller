using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellerApp
{
    public interface ILayoutPlacement
    {
        [JsonProperty("width")]
        string WidthPercent { get; set; }
        [JsonProperty("height")]
        string HeightPercent { get; set; }
        [JsonProperty("rightGroup")]
        RightGroup RightGroupProperty { get; set; }
        [JsonProperty("centerGroup")]
        CenterGroup CenterGroupProperty { get; set; }
        [JsonProperty("topGroup")]
        TopGroup TopGroupProperty { get; set; }
        [JsonProperty("right")]
        Right RightProperty { get; set; }
        [JsonProperty("center")]
        Center CenterProperty { get; set; }
        [JsonProperty("top")]
        Top TopProperty { get; set; }

    }
}
