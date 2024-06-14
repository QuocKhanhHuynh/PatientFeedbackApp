using FeedbackApp.Data.Entities;
using FeedbackApp.Data;
using FeedbackApp.Models.CloseQuestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeedbackApp.Utilities;
using FeedbackApp.Models.OpenQuestion;

namespace FeedbackApp.Services
{
    public class OpenQuestionService
    {
        private readonly AppDbContext dbContext;
        public OpenQuestionService()
        {
            var dbContextFactory = new DesignTimeDbContextFactory();
            dbContext = dbContextFactory.CreateDbContext(null);
        }

        public Response CreateOpenQuestion(OpenQuestionCreateModel model)
        {
            var openQuestion = dbContext.OpenQuestions.FirstOrDefault(x => x.OrdinalNumber == model.OrdinalNumber);
            if (openQuestion != null)
            {
                return new Response(false, "Số thứ tự câu hỏi trong danh mục đã có, vui lòng đổi số thứ tự khác");
            }

            var newOpenQuestion = new OpenQuestion()
            {
                Name = model.Name,
                Status = true,
                OrdinalNumber = model.OrdinalNumber
            };
            dbContext.OpenQuestions.Add(newOpenQuestion);
            var openFeedbackQuestions = new List<OpenFeedbackQuestion>();
            var result = dbContext.SaveChanges();
            foreach (string feedbackTypeId in model.FeedTypeIds)
            {
                openFeedbackQuestions.Add(new OpenFeedbackQuestion()
                {
                    OpenQuestionId = newOpenQuestion.Id,
                    FeedbackTypeId = feedbackTypeId
                });
            }
            if (result > 0)
            {
                dbContext.OpenFeedbackQuestions.AddRange(openFeedbackQuestions);
                var result2 = dbContext.SaveChanges();
                if (result2 == 0)
                {
                    return new Response(false, "Tạo câu hỏi không thành công");
                }
                return new Response(true, "Tạo câu hỏi thành công");
            }
            return new Response(false, "Tạo câu hỏi không thành công");
        }

        public List<OpenQuestionViewModel> GetOpenQuestions(string keyword = null)
        {
            var query = dbContext.OpenQuestions;
            var filter = query.ToList();
            if (keyword != null)
            {
                filter = query.Where(x => x.Name.ToUpper().Contains(keyword.ToUpper())).ToList();
            }
            var newOpenQuestions = new List<OpenQuestionViewModel>();
            foreach (var item in filter)
            {
                var newOpenQuestion = new OpenQuestionViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    OrdinalNumber = item.OrdinalNumber,
                    Status = item.Status
                };
                var feedbackTypeIds = dbContext.CloseFeedbackQuestions.Where(x => x.CloseQuestionId.Equals(item.Id)).Select(x => x.FeedbackTypeId).ToList();
                newOpenQuestion.FeedbackTypeIds = feedbackTypeIds;
                newOpenQuestions.Add(newOpenQuestion);
            }
            return newOpenQuestions;
        }

        public OpenQuestionViewModel GetOpenQuestionById(short id)
        {
            var openQuestion = dbContext.OpenQuestions.FirstOrDefault(x => x.Id == id);
            var result = new OpenQuestionViewModel()
            {
                Id = openQuestion.Id,
                Name = openQuestion.Name,
                OrdinalNumber = openQuestion.OrdinalNumber,
                Status = openQuestion.Status
            };
            var feedbackTypeIds = dbContext.OpenFeedbackQuestions.Where(x => x.OpenQuestionId.Equals(result.Id)).Select(x => x.FeedbackTypeId).ToList();
            result.FeedbackTypeIds = feedbackTypeIds;
            return result;
        }

        public Response UpdateOpenQuestion(OpenQuestionUpdateModel model)
        {
            var openQuestion = dbContext.OpenQuestions.Find(model.Id);
            if (openQuestion == null)
            {
                return new Response(false, "Câu hỏi không tồn tại");
            }

            openQuestion.Name = model.Name;
            openQuestion.OrdinalNumber = model.OrdinalNumber;
            openQuestion.Status = model.Status;
            dbContext.OpenQuestions.Update(openQuestion);
            var openFeedbackQuestionRemove = dbContext.OpenFeedbackQuestions.Where(x => x.OpenQuestionId.Equals(model.Id)).ToList();
            dbContext.OpenFeedbackQuestions.RemoveRange(openFeedbackQuestionRemove);
            var openFeedbackQuestions = new List<OpenFeedbackQuestion>();
            foreach (string feedbackTypeId in model.FeedTypeIds)
            {
                openFeedbackQuestions.Add(new OpenFeedbackQuestion()
                {
                    OpenQuestionId = model.Id,
                    FeedbackTypeId = feedbackTypeId
                });
            }
            dbContext.OpenFeedbackQuestions.AddRange(openFeedbackQuestions);
            var result = dbContext.SaveChanges();
            if (result > 0)
            {
                return new Response(true, "Cập nhật câu hỏi thành công");
            }
            return new Response(false, "Cập nhật câu hỏi không thành công");
        }

        public Response deleteOpenQuestion(short id)
        {
            var openQuestion = dbContext.OpenQuestions.Find(id);
            if (openQuestion == null)
            {
                return new Response(false, "Câu hỏi không tồn tại");
            }
            var openFeedbackQuestionRemove = dbContext.OpenFeedbackQuestions.Where(x => x.OpenQuestionId.Equals(id)).ToList();
            dbContext.OpenFeedbackQuestions.RemoveRange(openFeedbackQuestionRemove);
            dbContext.OpenQuestions.Remove(openQuestion);
            var result = dbContext.SaveChanges();
            if (result > 0)
            {
                return new Response(true, "Xóa câu hỏi thành công");
            }
            return new Response(false, "Xóa câu hỏi không thành công");
        }
    }
}
