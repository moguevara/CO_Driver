using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace CO_Driver
{
    public class Market

    {
        public class MarketData
        {
            public DateTime last_update { get; set; }
            public List<MarketItem> market_items { get; set; }
        }
        public class MarketItem
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string LocalizedName { get; set; }
            public string AvailableName { get; set; }
            public string Description { get; set; }
            public int SellOffers { get; set; }
            public double SellPrice { get; set; }
            public int BuyOrders { get; set; }
            public double BuyPrice { get; set; }
            public int Meta { get; set; }
            public int Removed { get; set; }
            public int Craftable { get; set; }
            public int Popularity { get; set; }
            public int WorkbenchRarity { get; set; }
            public double CraftingSellSum { get; set; }
            public double CraftingBuySum { get; set; }
            public int Ammount { get; set; }
            public double DemandSupplyRatio { get; set; }
            public double Margin { get; set; }
            public double ROI { get; set; }
            public double CraftingMargin { get; set; }
            public double FormatSupplyDemandRatio { get; set; }
            public double FormatMargin { get; set; }
            public double FormatROI { get; set; }
            public double FormatCraftingMargin { get; set; }
            public string CraftVBuy { get; set; }
            public DateTime TimeStamp { get; set; }
            public DateTime LastUpdateTime { get; set; }
            public int RarityID { get; set; }
            public string RarityName { get; set; }
            public int CategoryID { get; set; }
            public string CategoryName { get; set; }
            public int TypeID { get; set; }
            public int RecipeID { get; set; }
            public string TypeName { get; set; }
            public int FactionNumber { get; set; }
            public string Faction { get; set; }
            public double FormatBuyPrice { get; set; }
            public double FormatSellPrice { get; set; }
            public double FormatCraftingSellSum { get; set; }
            public double FormatCraftingBuySum { get; set; }
            public int CraftingResultType { get; set; }
            public string Image { get; set; }
            public string ImagePath { get; set; }
            public string SortedStats { get; set; }
        }

        public static MarketData PopulateCrossoutDBData(LogFileManagment.SessionVariables session)
        {
            MarketData data = new MarketData { };

            data = LoadPreviousMarketData(session, data);

            if (data.last_update > DateTime.Now.AddHours(-1))
                return data;

            data.last_update = DateTime.Now;
            try
            {
                data.market_items = LoadCrossoutDBData();
                SaveMarketData(session, data);
            }
            catch
            {

            }

            return data;
        }

        private static List<MarketItem> LoadCrossoutDBData()
        {
            List<MarketItem> marketItems = new List<MarketItem> { };

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://crossoutdb.com/api/v1/items?category=Resources");
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Timeout = 30000;
            using (Stream webStream = request.GetRequestStream())
            using (StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII))
            {
                requestWriter.Write(@"{""object"":{""name"":""Name""}}");
            }

            try
            {
                WebResponse webResponse = request.GetResponse();

                using (Stream webStream = webResponse.GetResponseStream() ?? Stream.Null)
                using (StreamReader responseReader = new StreamReader(webStream))
                {
                    string crossoutdb_json = responseReader.ReadToEnd();
                    marketItems = JsonConvert.DeserializeObject<List<MarketItem>>(crossoutdb_json);

                    return marketItems;
                }
            }
            catch (Exception)
            {
                //MessageBox.Show("The following problem occured when loading data from crossoutdb.com" + Environment.NewLine + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "Defaults will be used.");
            }

            return marketItems;
        }

        public static void SaveMarketData(LogFileManagment.SessionVariables session, MarketData market)
        {
            using (StreamWriter file = File.CreateText(session.MarketDataLocation + @"\crossoutdb_data.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, market);
            }
        }

        public static MarketData LoadPreviousMarketData(LogFileManagment.SessionVariables session, MarketData market)
        {
            if (!File.Exists(session.MarketDataLocation + @"\crossoutdb_data.json"))
                return market;

            MarketData newData = new MarketData { };

            try
            {
                using (StreamReader file = File.OpenText(session.MarketDataLocation + @"\crossoutdb_data.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    newData = (MarketData)serializer.Deserialize(file, typeof(MarketData));
                    if (newData.last_update != null)
                        return newData;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problems loading previous market data " + ex.Message);
            }
            return market;
        }
    }
}
