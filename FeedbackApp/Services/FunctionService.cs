using FeedbackApp.Data;
using FeedbackApp.Data.Entities;
using FeedbackApp.Models.Employee;
using FeedbackApp.Models.Function;
using FeedbackApp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.Services
{
    public class FunctionService
    {
        private readonly AppDbContext dbContext;
        public FunctionService()
        {
            var dbContextFactory = new DesignTimeDbContextFactory();
            dbContext = dbContextFactory.CreateDbContext(null);
        }

        public Response CreateFunction(FunctionCreateModel model)
        {

            var newFunction = new Function()
            {
                Name = model.Name,
            };
            dbContext.Functions.Add(newFunction);
            var result = dbContext.SaveChanges();
            if (result > 0)
            {
                return new Response(true, "Thêm quyền thành công");
            }
            return new Response(false, "Thêm quyền không thành công");
        }
        public Response UpdateFunction(FunctionUpdateModel model)
        {

            var function = dbContext.Functions.Find(model.Id);
            if (function == null)
            {
                return new Response(false, "Không thể tìm thấy quyền");
            }
            function.Name = model.Name;
            dbContext.Functions.Update(function);
            var result = dbContext.SaveChanges();
            if (result > 0)
            {
                return new Response(true, "Chỉnh quyền thành công");
            }
            return new Response(false, "Chỉnh quyền không thành công");
        }

        public Response DeleteFunction(short id)
        {

            var function = dbContext.Functions.Find(id);
            if (function == null)
            {
                return new Response(false, "Không thể tìm thấy quyền");
            }
            dbContext.Functions.Remove(function);
            var result = dbContext.SaveChanges();
            if (result > 0)
            {
                return new Response(true, "Xóa quyền thành công");
            }
            return new Response(false, "Xóa quyền không thành công");
        }

        public FunctionViewModel GetFunctionById(short id)
        {

            var function = dbContext.Functions.Find(id);
            var result = new FunctionViewModel()
            {
                Id = function.Id,
                Name = function.Name,
            };
            return result;
        }

        public List<FunctionViewModel> GetFunctions(string keyword = null)
        {

            var functions = dbContext.Functions.Select(x => new FunctionViewModel()
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            if (keyword != null)
            {
                functions = functions.Where(x => x.Name.Contains(keyword) || x.Id.ToString().Equals(keyword)).Select(x => new FunctionViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                }).ToList();
            }
            functions = functions.OrderBy(x => x.Id).ToList();
            return functions;
        }
    }
}
