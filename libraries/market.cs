using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Net;
using Newtonsoft.Json;

namespace CO_Driver{
    public class market
    {
        public class market_data
        {
            public DateTime last_update { get; set; }
            public List<market_item> market_items { get; set; }
        }
        public class market_item
        {
            public int id { get; set; }
            public string name { get; set; }
            public string localizedName { get; set; }
            public string availableName { get; set; }
            public string description { get; set; }
            public int sellOffers { get; set; }
            public double sellPrice { get; set; }
            public int buyOrders{ get; set; }
            public double buyPrice { get; set; }
            public int meta { get; set; }
            public int removed { get; set; }
            public int craftable { get; set; }
            public int popularity { get; set; }
            public int workbenchRarity { get; set; }
            public double craftingSellSum { get; set; }
            public double craftingBuySum { get; set; }
            public int ammount { get; set; }
            public double demandSupplyRatio { get; set; }
            public double margin { get; set; }
            public double roi { get; set; }
            public double craftingMargin { get; set; }
            public double formatDemandSupplyRatio { get; set; }
            public double formatMargin { get; set; }
            public double formatRoi { get; set; }
            public double formatCraftingMargin { get; set; }
            public string craftVsBuy { get; set; }
            public DateTime timestamp { get; set; }
            public DateTime lastUpdateTime { get; set; }
            public int rarityId { get; set; }
            public string rarityName { get; set; }
            public int categoryId { get; set; }
            public string categoryName { get; set; }
            public int typeId { get; set; }
            public int recipeId { get; set; }
            public string typeName { get; set; }
            public int factionNumber { get; set; }
            public string faction { get; set; }
            public double formatBuyPrice { get; set; }
            public double formatSellPrice { get; set; }
            public double formatCraftingSellSum { get; set; }
            public double formatCraftingBuySum { get; set; }
            public int craftingResultAmount { get; set; }
            public string image { get; set; }
            public string imagePath { get; set; }
            public string sortedStats { get; set; }
        }

        public static market_data populate_crossoutdb_data(log_file_managment.session_variables session)
        {
            market_data data = new market_data { };

            data = load_previous_market_data(session, data);

            if (data.last_update > DateTime.Now.AddHours(-1))
                return data;

            data.last_update = DateTime.Now;
            data.market_items = load_crossoutdb_data();
            save_market_data(session, data);
            return data;
        }

        private static List<market_item> load_crossoutdb_data()
        {
            List<market_item> market_items = new List<market_item> { };

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
                    market_items =  JsonConvert.DeserializeObject<List<market_item>>(crossoutdb_json);

                    return market_items;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following problem occured when loading data from crossoutdb.com" + Environment.NewLine + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "Defaults will be used.");
            }

            return market_items;
        }

        public static void save_market_data(log_file_managment.session_variables session, market_data market)
        {
            using (StreamWriter file = File.CreateText(session.market_data_file_location + @"\crossoutdb_data.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, market);
            }
        }

        public static market_data load_previous_market_data(log_file_managment.session_variables session, market_data market)
        {
            if (!File.Exists(session.market_data_file_location + @"\crossoutdb_data.json"))
                return market;

            market_data new_data = new market_data { };

            try
            {
                using (StreamReader file = File.OpenText(session.market_data_file_location + @"\crossoutdb_data.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    new_data = (market_data)serializer.Deserialize(file, typeof(market_data));
                    if (new_data.last_update != null)
                        return new_data;
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
