using FluentResults;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Globalization;
using TrainingApp.API.DTO;
using TrainingApp.Core.Model;
using TrainingApp.Core.Service.IService;
using TrainingApp.Data.Repository;
using TrainingApp.Data.Repository.IRepository;

namespace TrainingApp.Core.Service
{
    public class TrainingService : ITrainingService
    {
        private readonly ITrainingRepository _trainingRepository;
        public TrainingService(ITrainingRepository trainingRepository) 
        { 
            _trainingRepository = trainingRepository;  
        }

        public Result<CreateTrainingResponseDto> CreateTraining(CreateTrainingDto trainingDto)
        {
            try
            {
                var training = _trainingRepository.Create(new Training
                {
                    TypeId = trainingDto.Type.Id,
                    UserId = new Guid(trainingDto.UserId),
                    Duration = trainingDto.Duration,
                    Calories = trainingDto.Calories,
                    Difficulty = trainingDto.Difficulty,
                    Tiredness = trainingDto.Tiredness,
                    Notes = trainingDto.Notes,
                    DateTime = DateTime.Parse(trainingDto.DateTime).ToUniversalTime()
                });

                training.Validate();

                return new CreateTrainingResponseDto 
                {
                    Id = training.Id.ToString(),
                    TypeId = training.TypeId.ToString(),
                    Duration = training.Duration,
                    Calories = training.Calories,
                    Difficulty = training.Difficulty,
                    Tiredness = training.Tiredness,
                    Notes = training.Notes,
                    DateTime = training.DateTime.ToString()
                };
            }
            catch (Exception e)
            {
                return Result.Fail(new Error("Invalid argument")
                    .WithMetadata("code", 400))
                    .WithError(e.Message);
            }
        }

        public Result<List<StatsResponseDto>> GetStatsForMonth(MonthDto monthDto)
        {
            try
            {
                Dictionary<int, List<Training>> trainingsByWeek = GetSortedTrainingsInMonth(monthDto);
                
                List<StatsResponseDto> stats = trainingsByWeek.Select(t =>
                {
                    var trainings = t.Value;

                    return new StatsResponseDto
                    {
                        StartDate = GetFirstDateOfWeek(trainings.Min(t => t.DateTime)).ToString(),
                        EndDate = GetLastDateOfWeek(trainings.Max(t => t.DateTime)).ToString(),
                        TrainingsNumber = trainings.Count,
                        TrainingsDuration = trainings.Sum(t => t.Duration),
                        DifficultyAvg = Math.Round(trainings.Average(t => t.Difficulty), 2),
                        TirednessAvg = Math.Round(trainings.Average(t => t.Tiredness), 2)
                    };
                }).ToList();


                return stats;
            }
            catch (Exception e)
            {
                return Result.Fail(new Error("Internal server error")
                    .WithMetadata("code", 500))
                    .WithError(e.Message);
            }
        }

        private Dictionary<int, List<Training>> GetSortedTrainingsInMonth(MonthDto monthDto)
        {
            var trainings = _trainingRepository.GetAllBetweenDates(DateTime.Parse(monthDto.DateTime).ToUniversalTime(), new Guid(monthDto.UserId));

            Calendar Calendar = CultureInfo.InvariantCulture.Calendar;

            var trainingsByWeek = trainings
                .GroupBy(t => Calendar.GetWeekOfYear(t.DateTime, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday))
                .OrderBy(pair => pair.Key)
                .ToDictionary(g => g.Key, g => g.ToList());

            return trainingsByWeek;
        }


        private DateTime GetFirstDateOfWeek(DateTime date)
        {
            while (date.DayOfWeek != DayOfWeek.Monday)
                date = date.AddDays(-1);
            return date;
        }

        private DateTime GetLastDateOfWeek(DateTime date)
        {
            while (date.DayOfWeek != DayOfWeek.Sunday)
                date = date.AddDays(1);
            return date;
        }
    }
}
