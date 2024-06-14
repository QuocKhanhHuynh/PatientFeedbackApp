using FeedbackApp.Data.Entities;
using FeedbackApp.Data;
using FeedbackApp.Models.FeedbackType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeedbackApp.Utilities;
using FeedbackApp.Models.CloseQuestionCategory;

namespace FeedbackApp.Services
{
    public class CloseQuestionCategoryService
    {
        private readonly AppDbContext dbContext;
        public CloseQuestionCategoryService()
        {
            var dbContextFactory = new DesignTimeDbContextFactory();
            dbContext = dbContextFactory.CreateDbContext(null);
        }

        public Response CreateCloseQuestionCategory(CloseQuestionCategoryCreateModel model)
        {
            var closeQuestionCategory = dbContext.CloseQuestionCategories.Find(model.Id.ToUpper());
            if (closeQuestionCategory != null)
            {
                return new Response(false, "Mã danh mục đã tồn tại");
            }
            var newcloseQuestionCategory = new CloseQuestionCategory()
            {
                Id = model.Id.ToUpper(),
                Name = model.Name,
                Status = true
            };
            dbContext.CloseQuestionCategories.Add(newcloseQuestionCategory);
            var result = dbContext.SaveChanges();
            if (result > 0)
            {
                return new Response(true, "Thêm danh mục thành công");
            }
            return new Response(false, "Thêm danh mục không thành công");
        }
        public Response UpdateCloseQuestionCategory(CloseQuestionCategoryUpdateModel model)
        {

            var closeQuestionCategory = dbContext.CloseQuestionCategories.Find(model.Id);
            if (closeQuestionCategory == null)
            {
                return new Response(false, "Không thể tìm thấy danh mục");
            }
            closeQuestionCategory.Name = model.Name;
            closeQuestionCategory.Status = model.Status;
            dbContext.CloseQuestionCategories.Update(closeQuestionCategory);
            var result = dbContext.SaveChanges();
            if (result > 0)
            {
                return new Response(true, "Chỉnh danh mục thành công");
            }
            return new Response(false, "Chỉnh danh mục không thành công");
        }

        public Response DeleteCloseQuestionCategory(string id)
        {

            var closeQuestionCategory = dbContext.CloseQuestionCategories.Find(id);
            if (closeQuestionCategory == null)
            {
                return new Response(false, "Không thể tìm thấy danh mục");
            }
            dbContext.CloseQuestionCategories.Remove(closeQuestionCategory);
            var result = dbContext.SaveChanges();
            if (result > 0)
            {
                return new Response(true, "Xóa danh mục thành công");
            }
            return new Response(false, "Xóa danh mục không thành công");
        }

        public CloseQuestionCategoryViewModel GetCloseQuestionCategoryById(string id)
        {

            var closeQuestionCategory = dbContext.CloseQuestionCategories.Find(id);
            var result = new CloseQuestionCategoryViewModel()
            {
                Id = closeQuestionCategory.Id,
                Name = closeQuestionCategory.Name,
                Status = closeQuestionCategory.Status
            };
            return result;
        }

        public List<CloseQuestionCategoryViewModel> GetcloseQuestionCategories(string keyword = null)
        {

            var closeQuestionCategories = dbContext.CloseQuestionCategories.Select(x => new CloseQuestionCategoryViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Status = x.Status
            }).ToList();
            if (keyword != null)
            {
                closeQuestionCategories = closeQuestionCategories.Where(x => x.Name.ToUpper().Contains(keyword.ToUpper()) || x.Id.ToString().ToUpper().Contains(keyword.ToUpper())).Select(x => new CloseQuestionCategoryViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Status = x.Status
                }).ToList();
            }
            return closeQuestionCategories;
        }
    }
}
