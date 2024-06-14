using FeedbackApp.Data.Entities;
using FeedbackApp.Data;
using FeedbackApp.Models.ScoreType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeedbackApp.Utilities;
using FeedbackApp.Models.Score;
using static System.Formats.Asn1.AsnWriter;

namespace FeedbackApp.Services
{
    public class ScoreService
    {
        private readonly AppDbContext dbContext;
        public ScoreService()
        {
            var dbContextFactory = new DesignTimeDbContextFactory();
            dbContext = dbContextFactory.CreateDbContext(null);
        }

        public Response CreateScore(ScoreCreateModel model)
        {
            var scores = dbContext.Scores.Where(x => x.ScoreTypeId.ToUpper().Equals(model.ScoreTypeId.ToUpper()) && x.Number == model.Number);
            if (scores.Count() > 0)
            {
                return new Response(false, "Mã mức độ điểm đã tồn tại");
            }

            var newScore = new Score()
            {
                ScoreTypeId = model.ScoreTypeId.ToUpper(),
                Number = model.Number,
                Name = model.Name,
            };
            dbContext.Scores.Add(newScore);
            var result = dbContext.SaveChanges();
            if (result > 0)
            {
                return new Response(true, "Thêm mức độ đánh giá thành công");
            }
            return new Response(false, "Thêm mức độ đánh giá không thành công");
        }
        public Response UpdateScore(ScoreUpdateModel model)
        {

            var score = dbContext.Scores.Find(model.Id);
            if (score == null)
            {
                return new Response(false, "Không thể tìm thấy mức độ đánh giá");
            }
            score.Name = model.Name;
            score.Number = model.Number;
            dbContext.Scores.Update(score);
            var result = dbContext.SaveChanges();
            if (result > 0)
            {
                return new Response(true, "Chỉnh mức độ đánh giá thành công");
            }
            return new Response(false, "Chỉnh mức độ đánh giá không thành công");
        }

        public Response DeleteType(short id)
        {

            var score = dbContext.Scores.Find(id);
            if (score == null)
            {
                return new Response(false, "Không thể tìm thấy mức độ đánh giá");
            }
            dbContext.Scores.Remove(score);
            var result = dbContext.SaveChanges();
            if (result > 0)
            {
                return new Response(true, "Xóa mức độ đánh giá thành công");
            }
            return new Response(false, "Xóa mức độ đánh giá không thành công");
        }

        public ScoreViewModel GetScoreById(short id)
        {

            var score = dbContext.Scores.Find(id);
            var result = new ScoreViewModel()
            {
                ScoreTypeId = score.ScoreTypeId,
                Id = score.Id,
                Name = score.Name,
                Number = score.Number,
            };
            return result;
        }

        public List<ScoreViewModel> GetScoreByTypeId(string typeId)
        {

            var scores = dbContext.Scores.Where(x => x.ScoreTypeId.Equals(typeId)).Select(x => new ScoreViewModel()
            {
                ScoreTypeId = x.ScoreTypeId,
                Id = x.Id,
                Name = x.Name,
                Number = x.Number,
            }).OrderBy(x => x.Number).ToList();
            return scores;
        }

        public List<ScoreViewModel> GetScores(string keyword = null)
        {

            var scores = dbContext.Scores.Select(x => new ScoreViewModel()
            {
                ScoreTypeId = x.ScoreTypeId,
                Id = x.Id,
                Name = x.Name,
                Number = x.Number
            }).ToList();
            if (keyword != null)
            {
                scores = scores.Where(x => x.Name.ToUpper().Contains(keyword.ToUpper())).Select(x => new ScoreViewModel()
                {
                    ScoreTypeId= x.ScoreTypeId,
                    Id = x.Id,
                    Name = x.Name,
                    Number = x.Number
                }).ToList();
            }
            return scores;
        }
    }
}
