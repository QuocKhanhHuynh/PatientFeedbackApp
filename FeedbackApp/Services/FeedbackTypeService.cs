using FeedbackApp.Data;
using FeedbackApp.Data.Entities;
using FeedbackApp.Models.FeedbackType;
using FeedbackApp.Models.Function;
using FeedbackApp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.Services
{
    public class FeedbackTypeService
    {
        private readonly AppDbContext dbContext;
        public FeedbackTypeService()
        {
            var dbContextFactory = new DesignTimeDbContextFactory();
            dbContext = dbContextFactory.CreateDbContext(null);
        }

        public Response CreateFeedType(FeedbackTypeCreateModel model)
        {
            var feedbackType = dbContext.FeedbackTypes.Find(model.Id.ToUpper());
            if (feedbackType != null)
            {
                return new Response(false, "Mã loại khảo sát đã tồn tại");
            }
            var newFeedType = new FeedbackType()
            {
                Id = model.Id.ToUpper(),
                Name = model.Name,
            };
            dbContext.FeedbackTypes.Add(newFeedType);
            var result = dbContext.SaveChanges();
            if (result > 0)
            {
                return new Response(true, "Thêm loại khảo sát thành công");
            }
            return new Response(false, "Thêm loại khảo sát không thành công");
        }
        public Response UpdateFeedbackType(FeedbackTypeUpdateModel model)
        {

            var feedbackType = dbContext.FeedbackTypes.Find(model.Id);
            if (feedbackType == null)
            {
                return new Response(false, "Không thể tìm thấy loại khảo sát");
            }
            feedbackType.Name = model.Name;
            dbContext.FeedbackTypes.Update(feedbackType);
            var result = dbContext.SaveChanges();
            if (result > 0)
            {
                return new Response(true, "Chỉnh loại khảo sát thành công");
            }
            return new Response(false, "Chỉnh loại khảo sát không thành công");
        }

        public Response DeleteFeedbackType(string id)
        {

            var feedbackType = dbContext.FeedbackTypes.Find(id);
            if (feedbackType == null)
            {
                return new Response(false, "Không thể tìm thấy loại khảo sát");
            }
            dbContext.FeedbackTypes.Remove(feedbackType);
            var result = dbContext.SaveChanges();
            if (result > 0)
            {
                return new Response(true, "Xóa loại khảo sát thành công");
            }
            return new Response(false, "Xóa loại khảo sát không thành công");
        }

        public FeedbackTypeViewModel GetFeedbackTypeById(string id)
        {

            var feedbackType = dbContext.FeedbackTypes.Find(id);
            var result = new FeedbackTypeViewModel()
            {
                Id = feedbackType.Id,
                Name = feedbackType.Name,
            };
            return result;
        }

        public List<FeedbackTypeViewModel> GetFeedbackTypes(string keyword = null)
        {

            var feedbackTypes = dbContext.FeedbackTypes.Select(x => new FeedbackTypeViewModel()
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            if (keyword != null)
            {
                feedbackTypes = feedbackTypes.Where(x => x.Name.ToUpper().Contains(keyword.ToUpper()) || x.Id.ToString().ToUpper().Contains(keyword.ToUpper())).Select(x => new FeedbackTypeViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                }).ToList();
            }
            return feedbackTypes;
        }
    }
}
