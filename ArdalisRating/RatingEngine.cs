﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.IO;

namespace ArdalisRating
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine
    {
        public decimal Rating { get; set; }
        public ConsoleLogger Logger { get; set; }

        public void Rate()
        {
            Console.WriteLine("Starting rate.");

            Console.WriteLine("Loading policy.");

            // load policy - open file policy.json
            string policyJson = File.ReadAllText("policy.json");

            var policy = JsonConvert.DeserializeObject<Policy>(policyJson,
                new StringEnumConverter());

            switch (policy.Type)
            {
                case PolicyType.Auto:
                    var rater = new AutoPolicyRater(this, this.Logger);
                    rater.Rate(policy);
                    break;

                case PolicyType.Land:
                    var rater2 = new LandPolicyRater(this, this.Logger);
                    rater2.Rate(policy);
                    break;                    

                case PolicyType.Life:
                    var rater3 = new LifePolicyRater(this, this.Logger);
                    rater3.Rate(policy);
                    break;

                default:
                    Logger.Log("Unknown policy type");
                    break;
            }
            
            Logger.Log("Rating completed.");
        }
    }
}
