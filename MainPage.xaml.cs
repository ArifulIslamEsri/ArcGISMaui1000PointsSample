using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.Symbology;
using Esri.ArcGISRuntime.UI;

namespace ArcGISMaui1000PointsSample;

public partial class MainPage : ContentPage
{
    private readonly GraphicsOverlay _graphicsOverlay = new GraphicsOverlay();

    public MainPage()
    {
        InitializeComponent();
        LoadMap();
    }

    private void LoadMap()
    {
        // Use a basemap style that exists in your version
        mapView.Map = new Esri.ArcGISRuntime.Mapping.Map(BasemapStyle.ArcGISStreets);

        mapView.GraphicsOverlays.Add(_graphicsOverlay);

        Random random = new Random();

        for (int i = 0; i < 1000; i++)
        {
            double longitude = -130 + random.NextDouble() * 60;
            double latitude = 25 + random.NextDouble() * 20;

            string type;
            string status;
            string severity;
            SimpleMarkerSymbol symbol;

            int category = random.Next(3);
            int severityValue = random.Next(1, 4);

            severity = severityValue switch
            {
                1 => "Low",
                2 => "Medium",
                _ => "High"
            };

            status = random.Next(2) == 0 ? "Open" : "Active";

            if (category == 0)
            {
                type = "Fire";
                symbol = new SimpleMarkerSymbol(
                    SimpleMarkerSymbolStyle.Circle,
                    System.Drawing.Color.Red,
                    11);
            }
            else if (category == 1)
            {
                type = "Police";
                symbol = new SimpleMarkerSymbol(
                    SimpleMarkerSymbolStyle.Diamond,
                    System.Drawing.Color.Blue,
                    11);
            }
            else
            {
                type = "EMS";
                symbol = new SimpleMarkerSymbol(
                    SimpleMarkerSymbolStyle.Cross,
                    System.Drawing.Color.Green,
                    13);
            }

            MapPoint point = new MapPoint(longitude, latitude, SpatialReferences.Wgs84);

            Graphic graphic = new Graphic(point, symbol);
            graphic.Attributes["Id"] = i + 1;
            graphic.Attributes["Type"] = type;
            graphic.Attributes["Status"] = status;
            graphic.Attributes["Severity"] = severity;
            graphic.Attributes["Latitude"] = latitude.ToString("0.0000");
            graphic.Attributes["Longitude"] = longitude.ToString("0.0000");

            _graphicsOverlay.Graphics.Add(graphic);
        }

        mapView.SetViewpoint(new Viewpoint(37, -95, 20000000));
    }
}
