﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using SingleResponsibilityPrinciple.Contracts;


namespace SingleResponsibilityPrinciple
{
    class URLTradeDataProvider : ITradeDataProvider
    {
        private readonly string url;

        public URLTradeDataProvider(string url)
        {
            this.url = url;
        }

        public IEnumerable<string> GetTradeData()
        {
            var tradeData = new List<string>();
            var client = new WebClient();
            using (var stream = client.OpenRead(url))
            using (var reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    tradeData.Add(line);
                }
            }

            return tradeData;
        }
        
    }
}
