using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellerApp
{
    public class JsonSerializeModel
    {
        [JsonProperty("icon")]
        public IconSvg Svg { get; set; }
        [JsonProperty("placement")]
        public Placement Placement { get; set; } = new Placement();
        public JsonSerializeModel Model { get; set; }
        public JsonSerializeModel()
        {

        }
        public JsonSerializeModel(JsonSerializeModel model)
        {
            Model = model;
        }
        public void ToJson(string path)
        {
            string jsonString = JsonConvert.SerializeObject(Model, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            //File.WriteAllText(path, jsonString);
        }
    }

    public class IconSvg
    {
        public string Source { get; set; }
        public IconSvg(string s)
        {
            Source = $"svg xmlns=\"http://www.w3.org/2000/svg\" width=\"18\" height=\"18\"><g class=\"eveInteractiveSvgStroke\" fill=\"none\" stroke=\"#fff\"><path {s} /></g></svg>";
        }
    }
    public class Placement
    {

        public string WidthPercent { get; set; }


        public string HeightPercent { get; set; }


        public RightGroup RightGroupProperty { get; set; }


        public CenterGroup CenterGroupProperty { get; set; }


        public TopGroup TopGroupProperty { get; set; }


        public Right RightProperty { get; set; }


        public Center CenterProperty { get; set; }


        public Top TopProperty { get; set; }
    }



    public class RightGroup : ILayoutPlacement
    {
        [JsonProperty("width")]
        public string WidthPercent { get; set; }
        [JsonProperty("height")]
        public string HeightPercent { get; set; }
        [JsonProperty("rightGroup")]
        public RightGroup RightGroupProperty { get; set; }
        [JsonProperty("centerGroup")]
        public CenterGroup CenterGroupProperty { get; set; }
        [JsonProperty("topGroup")]
        public TopGroup TopGroupProperty { get; set; }
        [JsonProperty("right")]
        public Right RightProperty { get; set; }
        [JsonProperty("center")]
        public Center CenterProperty { get; set; }
        [JsonProperty("top")]
        public Top TopProperty { get; set; }

    }

    public class CenterGroup : ILayoutPlacement
    {
        [JsonProperty("width")]
        public string WidthPercent { get; set; }
        [JsonProperty("height")]
        public string HeightPercent { get; set; }
        [JsonProperty("rightGroup")]
        public RightGroup RightGroupProperty { get; set; }
        [JsonProperty("centerGroup")]
        public CenterGroup CenterGroupProperty { get; set; }
        [JsonProperty("topGroup")]
        public TopGroup TopGroupProperty { get; set; }
        [JsonProperty("right")]
        public Right RightProperty { get; set; }
        [JsonProperty("center")]
        public Center CenterProperty { get; set; }
        [JsonProperty("top")]
        public Top TopProperty { get; set; }

    }



    public class TopGroup : ILayoutPlacement
    {
        [JsonProperty("width")]
        public string WidthPercent { get; set; }
        [JsonProperty("height")]
        public string HeightPercent { get; set; }
        [JsonProperty("rightGroup")]
        public RightGroup RightGroupProperty { get; set; }
        [JsonProperty("centerGroup")]
        public CenterGroup CenterGroupProperty { get; set; }
        [JsonProperty("topGroup")]
        public TopGroup TopGroupProperty { get; set; }
        [JsonProperty("right")]
        public Right RightProperty { get; set; }
        [JsonProperty("center")]
        public Center CenterProperty { get; set; }
        [JsonProperty("top")]
        public Top TopProperty { get; set; }

    }
    public class Right : ILayoutPlacement
    {
        [JsonProperty("width")]
        public string WidthPercent { get; set; }
        [JsonProperty("height")]
        public string HeightPercent { get; set; }
        [JsonProperty("rightGroup")]
        public RightGroup RightGroupProperty { get; set; }
        [JsonProperty("centerGroup")]
        public CenterGroup CenterGroupProperty { get; set; }
        [JsonProperty("topGroup")]
        public TopGroup TopGroupProperty { get; set; }
        [JsonProperty("right")]
        public Right RightProperty { get; set; }
        [JsonProperty("center")]
        public Center CenterProperty { get; set; }
        [JsonProperty("top")]
        public Top TopProperty { get; set; }

    }
    public class Center : ILayoutPlacement
    {
        [JsonProperty("width")]
        public string WidthPercent { get; set; }
        [JsonProperty("height")]
        public string HeightPercent { get; set; }
        [JsonProperty("rightGroup")]
        public RightGroup RightGroupProperty { get; set; }
        [JsonProperty("centerGroup")]
        public CenterGroup CenterGroupProperty { get; set; }
        [JsonProperty("topGroup")]
        public TopGroup TopGroupProperty { get; set; }
        [JsonProperty("right")]
        public Right RightProperty { get; set; }
        [JsonProperty("center")]
        public Center CenterProperty { get; set; }
        [JsonProperty("top")]
        public Top TopProperty { get; set; }

    }
    public class Top : ILayoutPlacement
    {
        [JsonProperty("width")]
        public string WidthPercent { get; set; }
        [JsonProperty("height")]
        public string HeightPercent { get; set; }
        [JsonProperty("rightGroup")]
        public RightGroup RightGroupProperty { get; set; }
        [JsonProperty("centerGroup")]
        public CenterGroup CenterGroupProperty { get; set; }
        [JsonProperty("topGroup")]
        public TopGroup TopGroupProperty { get; set; }
        [JsonProperty("right")]
        public Right RightProperty { get; set; }
        [JsonProperty("center")]
        public Center CenterProperty { get; set; }
        [JsonProperty("top")]
        public Top TopProperty { get; set; }

    }
}
