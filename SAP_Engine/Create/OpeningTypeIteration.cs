using BH.oM.Environment.SAP;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.Engine.Environment.SAP
{
    public static partial class Create
    {
        public static List<OpeningTypeIteration> OpeningTypeIteration(double minUValue = double.NaN,  double maxUValue = double.NaN, double minGValue = double.NaN, double maxGValue = double.NaN, int steps = 1, List<string> typesToInclude = null)
        {
            if(double.IsNaN(minUValue) ^ double.IsNaN(maxUValue))
            {
                //Exclusive or - only if either value is NaN which means the other value is not a NaN - if both are a NaN then they will be ignored
                BH.Engine.Base.Compute.RecordError("Please provide both a minimum and a maximum U Value to calculate the number of Opening Type Iterations for UValues.");
                return new List<OpeningTypeIteration>();
            }

            if(double.IsNaN(minGValue) ^ double.IsNaN(maxGValue))
            {
                //Exlusive or - only if either value is NaN which means the other value is not a NaN - if both are a NaN then they will be ignored
                BH.Engine.Base.Compute.RecordError("Please provide both a minimum and a maximum G Value to calculate the number of Opening Type Iterations for GValues.");
                return new List<OpeningTypeIteration>();
            }

            List<OpeningTypeIteration> uValueIterations = new List<OpeningTypeIteration>();
            List<OpeningTypeIteration> gValueIterations = new List<OpeningTypeIteration>();

            if(!double.IsNaN(minUValue) && !double.IsNaN(maxUValue))
            {
                double diff = maxUValue - minGValue;
                double step = diff / (double)steps;

                for(double x = minUValue; x <= maxUValue; x+= step)
                {
                    OpeningTypeIteration iteration = new OpeningTypeIteration();
                    iteration.UValue = x;
                    iteration.Include = typesToInclude;

                    uValueIterations.Add(iteration);
                }
            }

            if(!double.IsNaN(minGValue) && !double.IsNaN(maxGValue))
            {
                double diff = maxGValue - minGValue;
                double step = diff / (double)steps;

                for (double x = minGValue; x <= maxGValue; x += step)
                {
                    OpeningTypeIteration iteration = new OpeningTypeIteration();
                    iteration.GValue = x;
                    iteration.Include = typesToInclude;

                    gValueIterations.Add(iteration);
                }
            }

            List<OpeningTypeIteration> iterations = new List<OpeningTypeIteration>();
            iterations.AddRange(uValueIterations);
            iterations.AddRange(gValueIterations);

            return iterations;
        }
    }
}
