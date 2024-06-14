using FeedbackApp.Data;
using FeedbackApp.Models.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeedbackApp.Utilities;
using FeedbackApp.Data.Entities;
using XSystem.Security.Cryptography;

namespace FeedbackApp.Services
{
    public class EmployeeService
    {
        private readonly AppDbContext dbContext;
        public EmployeeService()
        {
            var dbContextFactory = new DesignTimeDbContextFactory();
            dbContext = dbContextFactory.CreateDbContext(null);
        }

        public Response CreateEmployee(EmployeeCreateModel model)
        {
            var employeeWithUsername = dbContext.Employees.FirstOrDefault(x => x.Username.Equals(model.Username));
            if (employeeWithUsername != null)
            {
                return new Response(false, "Tên đăng nhập đã tồn tại, vui lòng đổi tên khác!");
            }
            /*
            var employeeWithPhoneNumber = dbContext.Employees.FirstOrDefault(x => x.PhoneNumber.Equals(model.PhoneNumber));
            if (employeeWithPhoneNumber != null)
            {
                return new Response(false, "Số điện thoại đã được dùng, vui lòng đổi số khác!");
            }*/
            //var passwordHash = BCrypt.Net.BCrypt.HashPassword(model.Password);

            string hasPass = hashPassword(model.Password);

            var newEmployee = new Employee()
            {
                Username = model.Username,
                Password = hasPass,
                Fullname = model.Fullname,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
            };
            dbContext.Employees.Add(newEmployee);
            var limits = new List<Limit>();
            foreach (short function in model.Functions)
            {
                limits.Add(new Limit()
                {
                    Username = model.Username,
                    FunctionId = function
                });
            }
            var result = dbContext.SaveChanges();
            if (result > 0)
            {
                dbContext.Limits.AddRange(limits);
                var result2 = dbContext.SaveChanges();
                if (result2 == 0)
                {
                    return new Response(false, "Tạo tài khoản nhân viên không thành công");
                }
                return new Response(true, "Tạo tài khoản nhân viên thành công");
            }
            return new Response(false, "Tạo tài khoản nhân viên không thành công");
        }

        public Response Login(LoginModel model)
        {
            var employee = dbContext.Employees.FirstOrDefault(x => x.Username.Equals(model.Username));
            if (employee == null)
            {
                return new Response(false, "Tài khoản không tồn tại");
            }
            /*var passwordHash = BCrypt.Net.BCrypt.HashPassword(model.Password, BCrypt.Net.BCrypt.GenerateSalt(12));
            var isVerify = BCrypt.Net.BCrypt.Verify(passwordHash, employee.Password);*/
            var passwordHash = hashPassword(model.Password);
            if (!employee.Password.Equals(passwordHash))
            {
                return new Response(false, "Mật khẩu sai");
            }
            return new Response(true, "Đăng nhập thành công");
        }

        public List<EmployeeViewModel> GetEmployees(string keyword = null)
        {
            var query = dbContext.Employees;
            var filter = query.ToList();
            if (keyword != null)
            {
                filter = query.Where(x => x.Username.ToUpper().Contains(keyword.ToUpper()) || x.Fullname.ToUpper().Contains(keyword.ToLower())).ToList();
            }
            var employees = new List<EmployeeViewModel>();
            foreach (var item in filter)
            {
                var employee = new EmployeeViewModel()
                {
                    Username = item.Username,
                    Fullname = item.Fullname,
                    PhoneNumber = item.PhoneNumber,
                    Email = item.Email
                };
                var Limits = dbContext.Limits.Where(x => x.Username.Equals(item.Username)).Select(x => x.FunctionId).ToList();
                employee.Functions = Limits;
                employees.Add(employee);
            }
            return employees;
        }

        public EmployeeViewModel GetEmployeesByUserName(string username)
        {
            var employee = dbContext.Employees.FirstOrDefault(x => x.Username.Equals(username));
            var result = new EmployeeViewModel()
            {
                Username = employee.Username,
                Fullname = employee.Fullname,
                PhoneNumber = employee.PhoneNumber,
                Email = employee.Email
            };
            var Limits = dbContext.Limits.Where(x => x.Username.Equals(employee.Username)).Select(x => x.FunctionId).ToList();
            result.Functions = Limits;
            return result;
        }

        public Response UpdateEmployee(EmployeeUpdateModel model)
        {
            var employee = dbContext.Employees.FirstOrDefault(x => x.Username.Equals(model.Username));
            if (employee == null)
            {
                return new Response(false, "Tài khoản không tồn tại");
            }

            employee.Fullname = model.Fullname;
            employee.PhoneNumber = model.PhoneNumber;
            employee.Email = model.Email;
            dbContext.Employees.Update(employee);
            if (model.Functions != null && model.Functions.Count > 0)
            {
                var limitRemove = dbContext.Limits.Where(x => x.Username.Equals(model.Username)).ToList();
                dbContext.Limits.RemoveRange(limitRemove);
                var limits = new List<Limit>();
                foreach (short function in model.Functions)
                {
                    limits.Add(new Limit()
                    {
                        Username = model.Username,
                        FunctionId = function
                    });
                }
                dbContext.Limits.AddRange(limits);
            }
            var result = dbContext.SaveChanges();
            if (result > 0)
            {
                return new Response(true, "Cập nhật tài khoản nhân viên thành công");
            }
            return new Response(false, "Cập nhật tài khoản nhân viên không thành công");
        }

        public Response deleteEmployee(string username)
        {
            var employee = dbContext.Employees.FirstOrDefault(x => x.Username.Equals(username));
            if (employee == null)
            {
                return new Response(false, "Tài khoản không tồn tại");
            }
            var limitRemove = dbContext.Limits.Where(x => x.Username.Equals(username)).ToList();
            dbContext.Limits.RemoveRange(limitRemove);
            dbContext.Employees.Remove(employee);
            var result = dbContext.SaveChanges();
            if (result > 0)
            {
                return new Response(true, "Xóa tài khoản nhân viên thành công");
            }
            return new Response(false, "Xóa tài khoản nhân viên không thành công");
        }

        public Response updatePassword(EmployeePasswordUpdateModel model)
        {
            var employee = dbContext.Employees.FirstOrDefault(x => x.Username.Equals(model.Username));
            if (employee == null)
            {
                return new Response(false, "Tài khoản không tồn tại");
            }
            var oldPasswordHash = hashPassword(model.oldPassword);
            if (!employee.Password.Equals(oldPasswordHash))
            {
                return new Response(false, "Mật khẩu hiện tại không chính xác, vui lòng kiểm tra lại!");
            }
            var newPasswordHash = hashPassword(model.newPassword);
            employee.Password = newPasswordHash;
            dbContext.Employees.Update(employee);
            var result = dbContext.SaveChanges();
            if (result > 0)
            {
                return new Response(true, "Cập nhật mật khẩu thành công");
            }
            return new Response(false, "Cập nhật mật khẩu không thành công");
        }

        /*public Response forgetPassword(EmployeePasswordForgetModel model)
        {
            var employee = dbContext.Employees.FirstOrDefault(x => x.Username.Equals(model.Username));
            if (employee == null)
            {
                return new Response(false, "Tài khoản không tồn tại");
            }
            if (!employee.PhoneNumber.Equals(model.PhoneNumber))
            {
                return new Response(false, "Số điện thoại không chính xác");
            }
            var newPasswordHash = BCrypt.Net.BCrypt.HashPassword(model.newPassword);
            employee.Password = newPasswordHash;
            dbContext.Employees.Update(employee);
            var result = dbContext.SaveChanges();
            if (result > 0)
            {
                return new Response(true, "Cập nhật mật khẩu thành công");
            }
            return new Response(false, "Cập nhật mật khẩu không thành công");
        }*/

        private string hashPassword(string password)
        {
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(password);
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);

            string hasPass = "";

            foreach (byte item in hasData)
            {
                hasPass += item.ToString();
            }
            return hasPass;
        }
    }
}
