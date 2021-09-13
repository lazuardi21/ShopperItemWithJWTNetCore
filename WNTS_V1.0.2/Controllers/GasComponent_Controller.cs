using System.Collections.Generic;
using WNTS_V1._0._2.Interface;
using WNTS_V1._0._2.Models;
using Microsoft.AspNetCore.Mvc;

namespace WNTS_V1._0._2.Controllers
{
   public class GasComponent_Controller: Controller{  
        IGasComponent gasComponentService;  
        public GasComponent_Controller(IGasComponent _gasComponentService) {
            gasComponentService = _gasComponentService;  
        }  
        public ActionResult Index() {  
            IEnumerable <PL_GAS_COMPONENT> GasComponent = gasComponentService.GetGasComponent();  
            return View(GasComponent);  
        }
        //public ActionResult Create() {  
        //        return View();  
        //    }  
        //    [HttpPost]  
        //public ActionResult Create(Student student) {  
        //    studentService.AddStudent(student);  
        //    return RedirectToAction(nameof(Index));  
        //}  
        public ActionResult Filter(int id)
        {
            IEnumerable<PL_GAS_COMPONENT> GasComponent = gasComponentService.GetGasComponentById(id);
            //PL_GAS_COMPONENT GasComponent = gasComponentService.GetGasComponentById(id);
            return View(GasComponent);
        }

        public ActionResult FilterDate(string startdate, string enddate)
        {
            IEnumerable<PL_GAS_COMPONENT> GasComponent = gasComponentService.GetGasComponentByDate(startdate, enddate);
            //PL_GAS_COMPONENT GasComponent = gasComponentService.GetGasComponentById(id);
            return View(GasComponent);
        }
        //    [HttpPost]  
        //public ActionResult Edit(Student student) {  
        //    studentService.EditStudent(student);  
        //    return RedirectToAction(nameof(Index));  
        //}  
        //public ActionResult Delete(int id) {  
        //        Student student = studentService.GetStudentById(id);  
        //        return View(student);  
        //    }  
        //    [HttpPost]  
        //public ActionResult Delete(Student student) {  
        //    studentService.DeleteStudent(student);  
        //    return RedirectToAction(nameof(Index));  
        //}  
    }  
}
