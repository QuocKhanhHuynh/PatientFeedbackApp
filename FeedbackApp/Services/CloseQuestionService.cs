using FeedbackApp.Data;
using FeedbackApp.Data.Entities;
using FeedbackApp.Models.CloseQuestion;
using FeedbackApp.Models.Employee;
using FeedbackApp.Models.Function;
using FeedbackApp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XSystem.Security.Cryptography;

namespace FeedbackApp.Services
{
    public class CloseQuestionService
    {
        private readonly AppDbContext dbContext;
        public CloseQuestionService()
        {
            var dbContextFactory = new DesignTimeDbContextFactory();
            dbContext = dbContextFactory.CreateDbContext(null);
        }

        public Response CreateCloseQuestion(CloseQuestionCreateModel model)
        {
            var closeQuestion = dbContext.CloseQuestions.FirstOrDefault(x => x.CloseQuestionCategoryId.Equals(model.CloseQuestionCategoryId) && x.OrdinalNumber == model.OrdinalNumber);
            if (closeQuestion != null)
            {
                return new Response(false, "Số thứ tự câu hỏi trong danh mục đã có, vui lòng đổi số thứ tự khác");
            }

            var newCloseQuestion = new CloseQuestion()
            {
                Name = model.Name,
                Status = true,
                ScoreTypeId = model.ScoreTypeId,
                CloseQuestionCategoryId = model.CloseQuestionCategoryId,
                OrdinalNumber = model.OrdinalNumber
            };
            dbContext.CloseQuestions.Add(newCloseQuestion);
            var closeFeedbackQuestions = new List<CloseFeedbackQuestion>();
            var result = dbContext.SaveChanges();
            foreach (string feedbackTypeId in model.FeedTypeIds)
            {
                closeFeedbackQuestions.Add(new CloseFeedbackQuestion()
                {
                    CloseQuestionId = newCloseQuestion.Id,
                    FeedbackTypeId = feedbackTypeId
                });
            }
            if (result > 0)
            {
                dbContext.CloseFeedbackQuestions.AddRange(closeFeedbackQuestions);
                var result2 = dbContext.SaveChanges();
                if (result2 == 0)
                {
                    return new Response(false, "Tạo câu hỏi không thành công");
                }
                return new Response(true, "Tạo câu hỏi thành công");
            }
            return new Response(false, "Tạo câu hỏi không thành công");
        }

        public List<CloseQuestionViewModel> GetCloseQuestions(string keyword = null)
        {
            var query = dbContext.CloseQuestions;
            var filter = query.ToList();
            if (keyword != null)
            {
                filter = query.Where(x => x.Name.ToUpper().Contains(keyword.ToUpper())).ToList();
            }
            var closeQuestions = new List<CloseQuestionViewModel>();
            foreach (var item in filter)
            {
                var closeQuestion = new CloseQuestionViewModel()
                {
                    CloseQuestionCategoryId = item.CloseQuestionCategoryId,
                    Id = item.Id,
                    ScoreTypeId = item.ScoreTypeId,
                    Name = item.Name,
                    OrdinalNumber = item.OrdinalNumber,
                    Status = item.Status
                };
                var feedbackTypeIds = dbContext.CloseFeedbackQuestions.Where(x => x.CloseQuestionId.Equals(item.Id)).Select(x => x.FeedbackTypeId).ToList();
                closeQuestion.FeedbackTypeIds = feedbackTypeIds;
                closeQuestions.Add(closeQuestion);
            }
            return closeQuestions;
        }

        public CloseQuestionViewModel GetCloseQuestionById(short id)
        {
            var closeQuestion = dbContext.CloseQuestions.FirstOrDefault(x => x.Id == id);
            var result = new CloseQuestionViewModel()
            {
                Id = closeQuestion.Id,
                Name = closeQuestion.Name,
                OrdinalNumber = closeQuestion.OrdinalNumber,
                Status = closeQuestion.Status,
                ScoreTypeId = closeQuestion.ScoreTypeId,
                CloseQuestionCategoryId = closeQuestion.CloseQuestionCategoryId,
            };
            var feedbackTypeIds = dbContext.CloseFeedbackQuestions.Where(x => x.CloseQuestionId.Equals(result.Id)).Select(x => x.FeedbackTypeId).ToList();
            result.FeedbackTypeIds = feedbackTypeIds;
            return result;
        }

        public Response UpdateCloseQuestion(CloseQuestionUpdateModel model)
        {
            var closeQuestion = dbContext.CloseQuestions.Find(model.Id);
            if (closeQuestion == null)
            {
                return new Response(false, "Câu hỏi không tồn tại");
            }

            closeQuestion.Name = model.Name;
            closeQuestion.OrdinalNumber = model.OrdinalNumber;
            closeQuestion.Status = model.Status;
            closeQuestion.CloseQuestionCategoryId = model.CloseQuestionCategoryId;
            closeQuestion.ScoreTypeId = model.ScoreTypeId;
            dbContext.CloseQuestions.Update(closeQuestion);
            var closeFeedbackQuestionRemove = dbContext.CloseFeedbackQuestions.Where(x => x.CloseQuestionId.Equals(model.Id)).ToList();
            dbContext.CloseFeedbackQuestions.RemoveRange(closeFeedbackQuestionRemove);
            var closeFeedbackQuestions = new List<CloseFeedbackQuestion>();
            foreach (string feedbackTypeId in model.FeedTypeIds)
            {
                closeFeedbackQuestions.Add(new CloseFeedbackQuestion()
                {
                    CloseQuestionId = model.Id,
                    FeedbackTypeId = feedbackTypeId
                });
            }
            dbContext.CloseFeedbackQuestions.AddRange(closeFeedbackQuestions);
            var result = dbContext.SaveChanges();
            if (result > 0)
            {
                return new Response(true, "Cập nhật câu hỏi thành công");
            }
            return new Response(false, "Cập nhật câu hỏi không thành công");
        }

        public Response deleteCloseQuestion(short id)
        {
            var closeQuestion = dbContext.CloseQuestions.Find(id);
            if (closeQuestion == null)
            {
                return new Response(false, "Câu hỏi không tồn tại");
            }
            var closeFeedbackQuestionRemove = dbContext.CloseFeedbackQuestions.Where(x => x.CloseQuestionId.Equals(id)).ToList();
            dbContext.CloseFeedbackQuestions.RemoveRange(closeFeedbackQuestionRemove);
            dbContext.CloseQuestions.Remove(closeQuestion);
            var result = dbContext.SaveChanges();
            if (result > 0)
            {
                return new Response(true, "Xóa câu hỏi thành công");
            }
            return new Response(false, "Xóa câu hỏi không thành công");
        }
    }
}
