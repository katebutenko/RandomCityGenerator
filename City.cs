using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealAddressing
{
  public class City
  {
    public string Name;
    public float Latitude;
    public float Longitude;
    public string Country;

    public City()
    {

    }

    public City(string[] values)
    {
      if (values.Count() < 4) return;

      Name = values[0];

      Latitude = float.Parse(values[1], CultureInfo.InvariantCulture.NumberFormat);
      Longitude = float.Parse(values[2], CultureInfo.InvariantCulture.NumberFormat);
      try
      {
        RegionInfo regionInfo = new RegionInfo(values[3]);
        Country = regionInfo.DisplayName;
      }
      catch
      {
        Country = values[3];
      }
    }
  }
}
