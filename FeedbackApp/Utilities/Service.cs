using FeedbackApp.Data.Entities;
using FeedbackApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.Utilities
{
    public class Service
    {
        public static EmployeeService employeeService = new EmployeeService();
        public static FunctionService functionService = new FunctionService();
        public static FeedbackTypeService feedbackTypeService = new FeedbackTypeService();
        public static ScoreTypeService scoreTypeService = new ScoreTypeService();
        public static ScoreService scoreService = new ScoreService();
        public static CloseQuestionCategoryService closeQuestionCategoyService = new CloseQuestionCategoryService();
        public static CloseQuestionService closeQuestionService = new CloseQuestionService();
        public static OpenQuestionService openQuestionService = new OpenQuestionService();
        public static ClientService clientService = new ClientService();
        public static FeedbackService feedbackService = new FeedbackService();
    }
}