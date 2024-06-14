using FeedbackApp.Data.Entities;
using FeedbackApp.Data;
using FeedbackApp.Models.FeedbackType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeedbackApp.Utilities;
using FeedbackApp.Models.Client;

namespace FeedbackApp.Services
{
    public class ClientService
    {
        private readonly AppDbContext dbContext;
        public ClientService()
        {
            var dbContextFactory = new DesignTimeDbContextFactory();
            dbContext = dbContextFactory.CreateDbContext(null);
        }

        public Response CheckClient2(string phoneNumber, string feedbackTypeId)
        {
            var dateNow = DateTime.Now;
            var result = dbContext.Feedbacks.FirstOrDefault(x => x.PhoneNumber == phoneNumber && x.FeebackTypeId.Equals(feedbackTypeId) && x.Date.Day == dateNow.Day && x.Date.Month == dateNow.Month && x.Date.Year == dateNow.Year);
            if (result != null)
            {
                return new Response(false, "Đã thực hiện đánh giá trong ngày hôm nay");
            }
            return new Response(true, null);
        }

        public Response CheckClient1(string phoneNumber)
        {
            var client = dbContext.Clients.Find(phoneNumber);
            if (client == null)
            {
                return new Response(false, "Khách hàng chưa tạo thông tin");
            }
            return new Response(true,null);
        }

        public Response CreateClient(ClientCreateModel model)
        {
            var client = dbContext.Clients.Find(model.PhoneNumber);
            if (client != null)
            {
                return new Response(false, "Khách hàng đã có thông tin");
            }
            var newClient = new Client()
            {
                PhoneNumber = model.PhoneNumber,
                FullName = model.FullName,
                Age = model.Age,
                Gender = model.Gender,
                Distance = model.Distance,                
            };
            dbContext.Clients.Add(newClient);
            var result = dbContext.SaveChanges();
            if (result > 0)
            {
                return new Response(true, "Tạo thông tin thành công");
            }
            return new Response(false, "Tạo thông tin không thành công");
        }

        public ClientViewModel GetClient(string phoneNumber)
        {
            var query = dbContext.Clients.Find(phoneNumber);
            var client = new ClientViewModel()
            {
                PhoneNumber = query.PhoneNumber,
                FullName = query.FullName,
                Age= query.Age,
                Distance = query.Distance,
                Gender= query.Gender,
            };
            return client;
        }
    }
}
