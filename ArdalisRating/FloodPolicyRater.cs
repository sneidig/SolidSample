using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    class FloodPolicyRater : Rater
    {

        private readonly RatingEngine _engine;
        private readonly ConsoleLogger _logger;

        public FloodPolicyRater(RatingEngine engine, ConsoleLogger logger) : base(engine, logger)
        {
        }

        public override void Rate(Policy policy)
        {
            _logger.Log("Rating FLOOD policy...");
            _logger.Log("Validating policy.");
            if (policy.BondAmount == 0 || policy.Valuation == 0)
            {
                _logger.Log("Flood policy must specify Bond Amount and Valuation");
                return;
            }
            if (policy.EvaluationAboveSeaLevelFeet <= 0)
            {
                _logger.Log("Flood policy is not available for elevation or or below sea level.");
                return;
            }
            decimal multiple = 1.0m;
            if(policy.EvaluationAboveSeaLevelFeet < 100)
            {
                multiple = 2.0m;
            }
            _engine.Rating = policy.BondAmount * 0.05m * multiple;
        }
    }
}
