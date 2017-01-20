using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RealAddressing
{
  public static class CityGenerator
  {
    static List<City> cityCollection;
    static Random randomizer;

    static CityGenerator()
    {
      cityCollection = new List<City>();
      try
      {
        var assembly = Assembly.GetExecutingAssembly();
        System.IO.StreamReader fileWithCityNames = new StreamReader(assembly.GetManifestResourceStream("RandomCityGenerator.Properties.Resources.resources"));
        while (!fileWithCityNames.EndOfStream)
        {
          string line = fileWithCityNames.ReadLine();

          cityCollection.Add(new City(line.Split('\t')));
        }
      }
      catch (Exception e)
      {
        throw e;
      }

      randomizer = new Random();
    }

    public static City GetRandomCity()
    {
      int randomNumber = randomizer.Next(TotalAmountOfCities);
      return cityCollection[randomNumber];
    }

    public static int TotalAmountOfCities
    {
      get
      {
        return cityCollection.Count();
      }
    }
  }
}
