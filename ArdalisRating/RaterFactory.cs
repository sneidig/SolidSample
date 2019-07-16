using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    class RaterFactory
    {
        public Rater Create(Policy policy, RatingEngine engine)
        {
            switch (policy.Type)
            {
                case PolicyType.Auto:
                    return new AutoPolicyRater(engine, engine.Logger);
                    break;
                case PolicyType.Land:
                    return new LandPolicyRater(engine, engine.Logger);
                    break;
                case PolicyType.Life:
                    return new LifePolicyRater(engine, engine.Logger);
                    break;
                default:
                    Logger.Log("Unknown policy type");
                    break;
            }
        }
    }
}
