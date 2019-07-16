﻿using System;
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
                case PolicyType.Land:
                    return new LandPolicyRater(engine, engine.Logger);
                case PolicyType.Life:
                    return new LifePolicyRater(engine, engine.Logger);

                default:
                    // Null Object Pattern

            }
        }
    }
}
