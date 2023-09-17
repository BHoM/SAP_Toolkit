using BH.oM.Base.Attributes;
using BH.oM.Environment.SAP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Linq;

namespace BH.Engine.Environment.SAP
{
    public static partial class Create
    {
        [Description("Create a collection of Opening Type Iterations from provided min/max values and the number of steps. One iteration object will be created for U Values, and one for G Values. The calculation of values will be done as the maximum value minus the minimum value, divided the number of steps, with each iteration then being the minimum value plus each step value for each iteration until the maximum value is met. The final iteration object will have the maximum value provided. If you do not wish to do iterations for one of the value types, then leave the inputs for those values empty. E.G. if you only wish to do iterations for G Values, then leave the U Value inputs empty and no U Value iterations will be created.")]
        [Input("minUValue", "The minimum U Value for the iterations - the first iteration object for U Values will be given this value. If this value is provided, then you MUST also provide a maximum U Value. Leave blank to ignore producing U Value iterations.")]
        [Input("maxUValue", "The maximum U Value for the iterations - the last iteration object for U Values will be given this value. If this value is provided, then you MUST also provide a minimum U Value. Leave blank to ignore producing U Value iterations.")]
        [Input("minGValue", "The minimum G Value for the iterations - the first iteration object for G Values will be given this value. If this value is provided, then you MUST also provide a maximum G Value. Leave blank to ignore producing G Value iterations.")]
        [Input("maxGValue", "The maximum G Value for the iterations - the last iteration object for G Values will be given this value. If this value is provided, then you MUST also provide a minimum G Value. Leave blank to ignore producing G Value iterations.")]
        [Input("steps", "The number of increments for iterations between the minimum and maximum value. If only 1 step is provided, then only two iterations will be provided (one for the minimum and one for the maximum).")]
        [Input("typesToInclude", "Specify the type of openings which the iteration objects should be applied to. If left blank, then all opening types within the SAP Report will have these iterations provided.")]
        [Output("openingTypeIterations", "A collection of iterations to be applied to SAP Reports for Parametric Studies.")]
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

                if(uValueIterations.Last().UValue != maxUValue)
                {
                    OpeningTypeIteration iteration = new OpeningTypeIteration();
                    iteration.UValue = maxUValue;
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

                if(gValueIterations.Last().GValue != maxGValue)
                {
                    OpeningTypeIteration iteration = new OpeningTypeIteration();
                    iteration.GValue = maxGValue;
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
