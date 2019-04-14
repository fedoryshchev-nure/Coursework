using Accord.MachineLearning.VectorMachines;
using Accord.MachineLearning.VectorMachines.Learning;
using Accord.Statistics.Kernels;
using Core.Entities.Origin;
using Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.Services.PredictionService
{
    public class PredictionService : IPredictionService
    {
        private readonly IUnitOfWork unitOfWork;
        private static SupportVectorMachine<Gaussian> svm;

        public PredictionService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Train()
        {
            var inputsOutputs = unitOfWork.Matches.GetBioMeasuresForTraining();;
            var inputs = CastListOfBioMeasuresToListOfDoubles(inputsOutputs);
            var outputs = inputsOutputs
                .Select(match => Convert.ToBoolean((int)match.FirstOrDefault().Match.MatchResult))
                .ToArray();

            var smo = new SequentialMinimalOptimization<Gaussian>()
            {
                Complexity = 100
            };

            svm = smo.Learn(inputs, outputs);

            bool[] prediction = svm.Decide(inputs);
        }

        public bool Predict(string matchId)
        {
            var inputs = CastListOfBioMeasuresToListOfDoubles(
                unitOfWork.Matches.GetBioMeasureForPrediction(matchId));

            return svm.Decide(inputs)
                .FirstOrDefault();
        }

        private double[][] CastListOfBioMeasuresToListOfDoubles(
            IEnumerable<IEnumerable<BioMeasure>> measuresForMatches) => measuresForMatches
                .Select(match => match
                    .SelectMany(measure => new double[] { measure.Pulse, measure.Pressure })
                    .ToArray())
                .ToArray();
    }
}
