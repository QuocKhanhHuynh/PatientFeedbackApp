using FeedbackApp.Data;
using FeedbackApp.Data.Entities;
using FeedbackApp.Models.Function;
using FeedbackApp.Models.ScoreType;
using FeedbackApp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.Services
{
    public class ScoreTypeService
    {
        private readonly AppDbContext dbContext;
        public ScoreTypeService()
        {
            var dbContextFactory = new DesignTimeDbContextFactory();
            dbContext = dbContextFactory.CreateDbContext(null);
        }

        public Response CreateScoreType(ScoreTypeCreateViewModel model)
        {
            var scoreType = dbContext.ScoreTypes.Find(model.Id.ToUpper());
            if (scoreType != null)
            {
                return new Response(false, "Mã loại mức độ điểm đã tồn tại");
            }

            var newScoreType = new ScoreType()
            {
                Id = model.Id.ToUpper(),
                Name = model.Name,
            };
            dbContext.ScoreTypes.Add(newScoreType);
            var result = dbContext.SaveChanges();
            if (result > 0)
            {
                return new Response(true, "Thêm loại điểm đánh giá thành công");
            }
            return new Response(false, "Thêm loại điểm đánh giá không thành công");
        }
        public Response UpdateScoreType(ScoreTypeUpdateViewModel model)
        {

            var scoreType = dbContext.ScoreTypes.Find(model.Id);
            if (scoreType == null)
            {
                return new Response(false, "Không thể tìm thấy loại điểm đánh giá");
            }
            scoreType.Name = model.Name;
            dbContext.ScoreTypes.Update(scoreType);
            var result = dbContext.SaveChanges();
            if (result > 0)
            {
                return new Response(true, "Chỉnh loại điểm đánh giá thành công");
            }
            return new Response(false, "Chỉnh loại điểm đánh giá không thành công");
        }

        public Response DeleteScoreType(string id)
        {

            var scoreType = dbContext.ScoreTypes.Find(id);
            if (scoreType == null)
            {
                return new Response(false, "Không thể tìm thấy loại điểm đánh giá");
            }
            dbContext.ScoreTypes.Remove(scoreType);
            var result = dbContext.SaveChanges();
            if (result > 0)
            {
                return new Response(true, "Xóa loại điểm đánh giá thành công");
            }
            return new Response(false, "Xóa loại điểm đánh giá không thành công");
        }

        public ScoreTypeViewModel GetScoreTypeById(string id)
        {

            var scoreType = dbContext.ScoreTypes.Find(id);
            var result = new ScoreTypeViewModel()
            {
                Id = scoreType.Id,
                Name = scoreType.Name,
            };
            return result;
        }

        public List<ScoreTypeViewModel> GetScoreTypes(string keyword = null)
        {

            var scoreTypes = dbContext.ScoreTypes.Select(x => new ScoreTypeViewModel()
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            if (keyword != null)
            {
                scoreTypes = scoreTypes.Where(x => x.Name.ToUpper().Contains(keyword.ToUpper()) || x.Id.ToString().ToUpper().Contains(keyword.ToUpper())).Select(x => new ScoreTypeViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                }).ToList();
            }
            return scoreTypes;
        }
    }
}
