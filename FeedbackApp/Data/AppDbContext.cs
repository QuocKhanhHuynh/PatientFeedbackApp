using FeedbackApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XAct.Library.Settings;
using XSystem.Security.Cryptography;

namespace FeedbackApp.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions option) : base(option) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Limit>().HasOne(x => x.Employee).WithMany(x => x.Limits).HasForeignKey(x => x.Username);
            modelBuilder.Entity<Limit>().HasOne(x => x.Function).WithMany(x => x.Limits).HasForeignKey(x => x.FunctionId);
            modelBuilder.Entity<Limit>().HasKey(x => new {x.Username, x.FunctionId});

            modelBuilder.Entity<Score>().HasOne(x => x.ScoreType).WithMany(x => x.Scores).HasForeignKey(x => x.ScoreTypeId);

            modelBuilder.Entity<CloseQuestion>().HasOne(x => x.ScoreType).WithMany(x => x.CloseQuestions).HasForeignKey(x => x.ScoreTypeId);
            modelBuilder.Entity<CloseQuestion>().HasOne(x => x.CloseQuestionCategory).WithMany(x => x.CloseQuestions).HasForeignKey(x => x.CloseQuestionCategoryId);
           // modelBuilder.Entity<CloseQuestion>().HasKey(x => new { x.CloseQuestionCategoryId, x.Id });

            modelBuilder.Entity<CloseFeedbackQuestion>().HasOne(x => x.FeedbackType).WithMany(x => x.CloseFeedbackQuestions).HasForeignKey(x => x.FeedbackTypeId);
            modelBuilder.Entity<CloseFeedbackQuestion>().HasOne(x => x.CloseQuestion).WithMany(x => x.CloseFeedbackQuestions).HasForeignKey(x => x.CloseQuestionId);
            //modelBuilder.Entity<CloseFeedbackQuestion>().HasOne(x => x.CloseQuestion).WithMany(x => x.CloseFeedbackQuestions).HasForeignKey(x => x.CloseQuestionCategoryId);
            modelBuilder.Entity<CloseFeedbackQuestion>().HasKey(x => new {x.FeedbackTypeId, x.CloseQuestionId});

            modelBuilder.Entity<OpenFeedbackQuestion>().HasOne(x => x.OpenQuestion).WithMany(x => x.OpenFeedbackQuestions).HasForeignKey(x => x.OpenQuestionId);
            modelBuilder.Entity<OpenFeedbackQuestion>().HasOne(x => x.FeedbackType).WithMany(x => x.OpenFeedbackQuestions).HasForeignKey(x => x.FeedbackTypeId);
            modelBuilder.Entity<OpenFeedbackQuestion>().HasKey(x => new { x.FeedbackTypeId, x.OpenQuestionId });

            modelBuilder.Entity<Feedback>().HasOne(x => x.Client).WithMany(x => x.Feedbacks).HasForeignKey(x => x.PhoneNumber);
            modelBuilder.Entity<Feedback>().HasOne(x => x.FeedbackType).WithMany(x => x.Feedbacks).HasForeignKey(x => x.FeebackTypeId);

            modelBuilder.Entity<CloseFeedbackDetail>().HasOne(x => x.Feedback).WithMany(x => x.CloseFeedbackDetails).HasForeignKey(x => x.FeedbackId);
            modelBuilder.Entity<CloseFeedbackDetail>().HasOne(x => x.CloseQuestion).WithMany(x => x.CloseFeedbackDetails).HasForeignKey(x => x.CloseQuestionId);
            modelBuilder.Entity<CloseFeedbackDetail>().HasOne(x => x.Score).WithMany(x => x.CloseFeedbackDetails).HasForeignKey(x => x.ScoreId);
            modelBuilder.Entity<CloseFeedbackDetail>().HasKey(x => new { x.FeedbackId, x.CloseQuestionId });

            modelBuilder.Entity<OpenFeedbackDetail>().HasOne(x => x.Feedback).WithMany(x => x.OpenFeedbackDetail).HasForeignKey(x => x.FeedbackId);
            modelBuilder.Entity<OpenFeedbackDetail>().HasOne(x => x.OpenQuestion).WithMany(x => x.OpenFeedbackDetail).HasForeignKey(x => x.OpenQuestionId);
            modelBuilder.Entity<OpenFeedbackDetail>().HasKey(x => new { x.FeedbackId, x.OpenQuestionId });
            //var password = BCrypt.Net.BCrypt.HashPassword("Khanh@123", BCrypt.Net.BCrypt.GenerateSalt(12));
            byte[] temp = ASCIIEncoding.ASCII.GetBytes("Khanh@123");
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);

            string hasPass = "";

            foreach (byte item in hasData)
            {
                hasPass += item.ToString();
            }
            modelBuilder.Entity<Employee>().HasData(new Employee()
            {
                Username = "quockhanh",
                Password = hasPass,
                Fullname = "Huỳnh Quốc Khánh",
                PhoneNumber = "0334190027",
                Email = "khanhhuynh912@gmail.com"
            });

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Function> Functions { get; set; }
        public DbSet<Limit> Limits { get; set; }
        public DbSet<FeedbackType> FeedbackTypes { get; set; }
        public DbSet<ScoreType> ScoreTypes { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<CloseQuestionCategory> CloseQuestionCategories { get; set; }
        public DbSet<CloseQuestion> CloseQuestions { get; set; }
        public DbSet<CloseFeedbackQuestion> CloseFeedbackQuestions { get; set; }
        public DbSet<OpenQuestion> OpenQuestions { get; set; }
        public DbSet<OpenFeedbackQuestion> OpenFeedbackQuestions { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<CloseFeedbackDetail> CloseFeedbackDetails { get; set; }
        public DbSet<OpenFeedbackDetail> OpenFeedbackDetails { get; set; }
    }
}
