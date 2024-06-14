using FeedbackApp.Data.Entities;
using FeedbackApp.Data;
using FeedbackApp.Models.FeedbackType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeedbackApp.Utilities;
using FeedbackApp.Models.Feedback;
using FeedbackApp.Models.CloseQuestionCategory;
using System.Security.Cryptography.X509Certificates;
using FeedbackApp.Models.ScoreType;
using FeedbackApp.Models.Score;

namespace FeedbackApp.Services
{
    public class FeedbackService
    {
        private readonly AppDbContext dbContext;
        public FeedbackService()
        {
            var dbContextFactory = new DesignTimeDbContextFactory();
            dbContext = dbContextFactory.CreateDbContext(null);
        }

        public Response CreateFeedback(FeedbackCreateModel model)
        {
            var newFeedback = new Feedback()
            {
                Date = DateTimeOffset.UtcNow,
                FeebackTypeId = model.FeedbackTypeId,
                PhoneNumber = model.PhoneNumber,
                IsInsurance = model.IsInsurance,
                DayNumber = model.DayNumber
            };
            dbContext.Feedbacks.Add(newFeedback);
            var result = dbContext.SaveChanges();
            if (result > 0)
            {

                foreach(var item in model.CloseFeedbacks)
                {
                    dbContext.CloseFeedbackDetails.Add(new CloseFeedbackDetail()
                    {
                        FeedbackId = newFeedback.Id,
                        CloseQuestionId = item.CloseQuestionId,
                        ScoreId = item.ScoreId
                    });
                }
                foreach (var item in model.OpenFeedbacks)
                {
                    dbContext.OpenFeedbackDetails.Add(new OpenFeedbackDetail()
                    {
                        FeedbackId = newFeedback.Id,
                        OpenQuestionId = item.OpenQuestionId,
                        Conttent = item.Content
                    });
                }
                var result2 = dbContext.SaveChanges();
                if(result2 > 0)
                {
                    return new Response(true, "Thêm loại khảo sát thành công");
                }
            }
            return new Response(false, "Thêm loại khảo sát không thành công");
        }

        public FeedbackLoadViewModel LoadFeedbackQuestion(string feedbackTypeId)
        {
            var feedbackLoadViewModels = new FeedbackLoadViewModel();
            var closeFeedbacks = from cf in dbContext.CloseFeedbackQuestions
                                 join cq in dbContext.CloseQuestions on cf.CloseQuestionId equals cq.Id
                                 join ct in dbContext.CloseQuestionCategories on cq.CloseQuestionCategoryId equals ct.Id
                                 where cf.FeedbackTypeId.Equals(feedbackTypeId) && ct.Status == true && cq.Status == true
                                 select new {cq, ct};
            var closeFeedbackViewModel = new Dictionary<CloseQuestionCategoryLoadViewModel, List<CloseFeedbackViewModel>>();
            foreach(var item in closeFeedbacks)
            {
                var key = closeFeedbackViewModel.Keys.FirstOrDefault(x => x.Id.Equals(item.ct.Id));
                if (key == null)
                {
                    var closeQuestionCategoryLoadViewModel = new CloseQuestionCategoryLoadViewModel()
                    {
                        Id = item.ct.Id,
                        Name = item.ct.Name
                    };
                    var closeFeedbackViewModels = new List<CloseFeedbackViewModel>()
                    {
                        new CloseFeedbackViewModel()
                        {
                            CloseQuestionId = item.cq.Id,
                            CloseQuestionName = item.cq.Name,
                            ScoreTypeId = item.cq.ScoreTypeId,
                            OrdinalNumber = item.cq.OrdinalNumber
                        }
                    };
                    closeFeedbackViewModel.Add(closeQuestionCategoryLoadViewModel, closeFeedbackViewModels);
                }
                else
                {
                    closeFeedbackViewModel[key].Add(new CloseFeedbackViewModel()
                    {
                        CloseQuestionId = item.cq.Id,
                        CloseQuestionName = item.cq.Name,
                        ScoreTypeId = item.cq.ScoreTypeId,
                        OrdinalNumber = item.cq.OrdinalNumber
                    });
                }
            }
            closeFeedbackViewModel = closeFeedbackViewModel.OrderBy(x => x.Key.Id).ToDictionary();
            foreach(var item in closeFeedbackViewModel)
            {
                closeFeedbackViewModel[item.Key] = closeFeedbackViewModel[item.Key].OrderBy(x => x.OrdinalNumber).ToList();
            }

            var openFeedbacks = (from of in dbContext.OpenFeedbackQuestions
                                join oq in dbContext.OpenQuestions on of.OpenQuestionId equals oq.Id
                                where of.FeedbackTypeId.Equals(feedbackTypeId) && oq.Status == true
                                select new OpenFeedbackViewModel()
                                {
                                    OpenQuestionId = oq.Id,
                                    OpenQuestionName = oq.Name,
                                    OrdinalNumber = oq.OrdinalNumber
                                }).OrderBy(x => x.OrdinalNumber).ToList();
            var feedbackLoadViewModel = new FeedbackLoadViewModel()
            {
                CloseFeedbacks = closeFeedbackViewModel,
                OpenFeedbacks = openFeedbacks,
            };
            return feedbackLoadViewModel;
        }

        public List<FeedbackViewModel> GetFeedbacks(DateTime startDay, DateTime endDate, bool? insurance = null)
        {
            var result = dbContext.Feedbacks.Select(x => new FeedbackViewModel()
            {
                Id = x.Id,
                FeedbackDate = x.Date.DateTime,
                FeebackTypeId = x.FeebackTypeId,
                IsInsurance = x.IsInsurance,
                DayNumber = x.DayNumber
            }).Where(x => x.FeedbackDate >= startDay && x.FeedbackDate <= endDate).ToList();
            if (insurance != null)
            {
                result = result.Where(x => x.IsInsurance == insurance).ToList();
            }
            return result;
        }

        public FeedbackFastViewModel GetFeedbackById(long id)
        {
            var query = from f in dbContext.Feedbacks
                        join c in dbContext.Clients on f.PhoneNumber equals c.PhoneNumber
                        where f.Id == id
                        select new { f, c };
            var result = query.Select(x => new FeedbackFastViewModel()
            {
                Id = x.f.Id,
                FeedbackDate = x.f.Date.DateTime,
                FeebackTypeId = x.f.FeebackTypeId,
                Age = x.c.Age,
                PhoneNumber = x.c.PhoneNumber,
                DayNumber = x.f.DayNumber,
                Distance = x.c.Distance,
                FullName = x.c.FullName,
                Gender = x.c.Gender,
                IsInsurance = x.f.IsInsurance
            }).ToList();
            return result[0];
        }

        public FeedbackDetailViewModel GetFeedbackDetail(long id)
        {
            var feedbackLoadViewModels = new FeedbackLoadViewModel();
            var closeFeedbacks = from cfd in dbContext.CloseFeedbackDetails
                                 join cq in dbContext.CloseQuestions on cfd.CloseQuestionId equals cq.Id
                                 join ct in dbContext.CloseQuestionCategories on cq.CloseQuestionCategoryId equals ct.Id
                                 join s in dbContext.Scores on cfd.ScoreId equals s.Id
                                 where cfd.FeedbackId == id
                                 select new { cq, ct, s };
            var closeFeedbackResultModel = new Dictionary<CloseQuestionCategoryLoadViewModel, List<CloseFeedbackResultModel>>();
            foreach (var item in closeFeedbacks)
            {
                var key = closeFeedbackResultModel.Keys.FirstOrDefault(x => x.Id.Equals(item.ct.Id));
                if (key == null)
                {
                    var closeQuestionCategoryLoadViewModel = new CloseQuestionCategoryLoadViewModel()
                    {
                        Id = item.ct.Id,
                        Name = item.ct.Name
                    };
                    var closeFeedbackResultModels = new List<CloseFeedbackResultModel>()
                    {
                        new CloseFeedbackResultModel()
                        {
                            CloseQuestionId = item.cq.Id,
                            CloseQuestionName = item.cq.Name,
                            ScoreId = item.s.Id,
                            OrdinalNumber = item.cq.OrdinalNumber,
                            ScoreTypeId  = item.s.ScoreTypeId
                        }
                    };
                    closeFeedbackResultModel.Add(closeQuestionCategoryLoadViewModel, closeFeedbackResultModels);
                }
                else
                {
                    closeFeedbackResultModel[key].Add(new CloseFeedbackResultModel()
                    {
                        CloseQuestionId = item.cq.Id,
                        CloseQuestionName = item.cq.Name,
                        ScoreId = item.s.Id,
                        OrdinalNumber = item.cq.OrdinalNumber,
                        ScoreTypeId = item.s.ScoreTypeId
                    });
                }
            }
            closeFeedbackResultModel = closeFeedbackResultModel.OrderBy(x => x.Key.Id).ToDictionary();
            foreach (var item in closeFeedbackResultModel)
            {
                closeFeedbackResultModel[item.Key] = closeFeedbackResultModel[item.Key].OrderBy(x => x.OrdinalNumber).ToList();
            }

            var openFeedbacks = (from ofd in dbContext.OpenFeedbackDetails
                                 join oq in dbContext.OpenQuestions on ofd.OpenQuestionId equals oq.Id
                                 where ofd.FeedbackId == id
                                 select new OpenFeedbackResultModel()
                                 {
                                     OpenQuestionName = oq.Name,
                                     OrdinalNumber = oq.OrdinalNumber,
                                     Content = ofd.Conttent
                                 }).OrderBy(x => x.OrdinalNumber).ToList();
            var feedbackDetailModel= new FeedbackDetailViewModel()
            {
                CloseFeedbacks = closeFeedbackResultModel,
                OpenFeedbacks = openFeedbacks,
            };
            return feedbackDetailModel;
        }

        public List<FeedbackStatisticsModel> CompileFeedback(DateTime startDate, DateTime endDate, bool? insurance = null)
        {
            var query = from f in dbContext.Feedbacks
                        join ft in dbContext.FeedbackTypes on f.FeebackTypeId equals ft.Id
                        where f.Date.DateTime >= startDate && f.Date.DateTime <= endDate
                        select new { f, ft };
            if (insurance != null)
            {
                query = query.Where(x => x.f.IsInsurance == insurance);
            }
            var queryGroup = query.GroupBy(x => x.ft);
            var result = new List<FeedbackStatisticsModel>();
            foreach ( var g in queryGroup)
            {
                result.Add(new FeedbackStatisticsModel()
                {
                    FeedbackTypeId = g.Key.Id,
                    FeedbackName = g.Key.Name,
                    FeedbackNumber = g.Count()
                });
            }
            foreach(var item in dbContext.FeedbackTypes)
            {
                if (result.FirstOrDefault(x => x.FeedbackTypeId.Equals(item.Id)) == null)
                {
                    result.Add(new FeedbackStatisticsModel()
                    {
                        FeedbackTypeId = item.Id,
                        FeedbackName = item.Name,
                        FeedbackNumber = 0
                    });
                }
            }
            return result.OrderBy(x => x.FeedbackTypeId).ToList();
        }

        public List<FeedbackDetailStatisticsModel> CompileFeedbackDetail(DateTime startDate, DateTime endDate, string feedbackTypeId, bool? insurance = null)
        {
            var query = from fcd in dbContext.CloseFeedbackDetails
                        join f in dbContext.Feedbacks on fcd.FeedbackId equals f.Id
                        join cq in dbContext.CloseQuestions on fcd.CloseQuestionId equals cq.Id
                        where f.Date.DateTime >= startDate && f.Date.DateTime <= endDate && f.FeebackTypeId.Equals(feedbackTypeId)
                        select new { f, cq };
            if (insurance != null)
            {
                query = query.Where(x => x.f.IsInsurance == insurance);
            }
           
            var result = query.Select(x => new FeedbackDetailStatisticsModel()
            {
                ScoreTypeId = x.cq.ScoreTypeId,
                CloseQuestionCategoryId = x.cq.CloseQuestionCategoryId,
                CloseQuestionId = x.cq.Id,
                CloseQuestionName = x.cq.Name,
                CloseQuestionNumber = x.cq.OrdinalNumber,
                AvergraveScore = 0,
                ScoreStatisticsModels = new List<ScoreStatisticsModel> ()
            }).ToList();
            result = result.DistinctBy(x => x.CloseQuestionId).ToList();
            foreach(var item  in result)
            {
                long scoreTotal = 0;
                var scores = dbContext.Scores.Where(x => x.ScoreTypeId.Equals(item.ScoreTypeId)).ToList();
                foreach(var score in scores)
                {
                    var scoreDetails = from cfd in dbContext.CloseFeedbackDetails
                                          join f in dbContext.Feedbacks on cfd.FeedbackId equals f.Id
                                          where f.Date.DateTime >= startDate && f.Date.DateTime <= endDate && cfd.CloseQuestionId == item.CloseQuestionId && cfd.ScoreId == score.Id && f.FeebackTypeId.Equals(feedbackTypeId)
                                          select new { f, cfd };
                   if (insurance != null)
                    {
                        scoreDetails = scoreDetails.Where(x => x.f.IsInsurance == insurance);
                    }
                    item.ScoreStatisticsModels.Add(new ScoreStatisticsModel()
                    {
                        ScoreId = score.Id,
                        Number = scoreDetails.ToList().Count
                    });
                    scoreTotal += scoreDetails.ToList().Count * score.Number;
                }
                long total = 0;
                foreach (var i in item.ScoreStatisticsModels)
                {
                    total += i.Number;
                }
                item.AvergraveScore = (int)Math.Round(scoreTotal / (double) total);
                item.FeedbackTotals = total;
            }
            return result;
        }
    }
}
