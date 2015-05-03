using EmployeeEducationInfo.BLL;
using EmployeeEducationInfo.IBLL;
using EmployeeEducationInfo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.EmployeeEducationInfo.Infrastructure
{
    public class EmployeeBinder : IModelBinder
    {
        IEmployeeService employeeService = new EmployeeService();
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Employee model = (Employee)bindingContext.Model ?? new Employee();

            if (string.IsNullOrEmpty(GetValue(bindingContext, "Id")))
            {
                var emp = employeeService.GetAllEmployees().OrderBy(s => s.Id).Skip(employeeService.GetAllEmployees().Count() - 1).SingleOrDefault();
                if (emp != null)
                    model.Id = emp.Id + 1; 
                else
                    model.Id = 1;
            }
            else
            {
                model.Id = Convert.ToInt32(GetValue(bindingContext, "Id"));
            }
            if (!string.IsNullOrEmpty(GetValue(bindingContext, "Age")))
                model.Age = Convert.ToInt32(GetValue(bindingContext, "Age"));
            if (!string.IsNullOrEmpty(GetValue(bindingContext, "Seniority")))
                model.Seniority = Convert.ToInt32(GetValue(bindingContext, "Seniority"));
            model.Name = GetValue(bindingContext, "Name");
            if (bindingContext.ValueProvider.GetValue("EducationInfo.Education") != null)
            {
                int count = GetValue(bindingContext, "EducationInfo.Education").Split(',').Length;
                for (int i = 0; i < count; i++)
                {
                    var sdateArr = GetValue(bindingContext, "EducationInfo.StartTime").Split(',');
                    var edateArr = GetValue(bindingContext, "EducationInfo.EndTime").Split(',');
                    var eduexpArr = GetValue(bindingContext, "EducationInfo.Education").Split(',');
                    var eduIdArr = GetValue(bindingContext, "EducationInfo.Id").Split(',');
                    EducationInfo eduInfo = new EducationInfo();
                    eduInfo.StartTime = Convert.ToDateTime(sdateArr[i]);
                    eduInfo.EndTime = Convert.ToDateTime(edateArr[i]);
                    eduInfo.Education = eduexpArr[i];
                    eduInfo.EmployeeId = model.Id;
                    eduInfo.Id = Convert.ToInt32(eduIdArr[i]);
                    model.EducationInfo.Add(eduInfo);
                }
                var eduIsDelArr = GetValue(bindingContext, "ready4delete").Split(',');
                if (!string.IsNullOrEmpty(eduIsDelArr[0]))
                {
                    for (int i = 0; i < eduIsDelArr.Length; i++)
                    {
                        int id = Convert.ToInt32(eduIsDelArr[i]);
                        var res = model.EducationInfo.Where(s => s.Id == id).SingleOrDefault();
                        if (res != null) res.IsDel = true;
                    }
                }
            }
            return model;
        }

        private string GetValue(ModelBindingContext context, string name)
        {
            ValueProviderResult result = context.ValueProvider.GetValue(name);
            if (result != null)
                return (string)result.AttemptedValue;
            else
                return "";
        }
    }
}