using Hospital.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.ViewModels
{
    public class TimingViewModel
    {
        public int Id { get; set; }
        public DateTime ScheduleDate { get; set; }
        public ApplicationUser Doctor { get; set; }
        public DateTime Date { get; set; }
        public int MorningShiftStartTime { get; set; }
        public int MorningShiftEndTime { get; set; }
        public int AfternoonShiftStartTime { get; set; }
        public int AfternoonShiftEndTime { get; set; }
        public int Duration { get; set; }
        public Status Status { get; set; }
        List<SelectListItem> moringShiftStart = new List<SelectListItem> { };
        List<SelectListItem> moringShiftEnd = new List<SelectListItem> { };
        List<SelectListItem> AFternoonShiftStart = new List<SelectListItem> { };
        List<SelectListItem> AfternoonShiftEnd = new List<SelectListItem> { };
   
        public TimingViewModel()
        {

        }
        public TimingViewModel(Timing model)
        {
            Id = model.Id;
            Date = model.Date;
            MorningShiftStartTime = model.MorningShiftStartTime;
            MorningShiftEndTime = model.MorningShiftEndTime;
            AfternoonShiftStartTime = model.AfternoonShiftStartTime;
            AfternoonShiftEndTime = model.AfternoonShiftEndTime;
            Duration = model.Duration;
            Status = model.Status;
            Doctor = model.Doctor;
        }

        public Timing ConvertViewModel (TimingViewModel model)
        {
            return new Timing
            {
                Id = model.Id,
                Date = model.Date,
                MorningShiftStartTime = model.MorningShiftStartTime,
                MorningShiftEndTime = model.MorningShiftEndTime,
                AfternoonShiftStartTime = model.AfternoonShiftStartTime,
                AfternoonShiftEndTime = model.AfternoonShiftEndTime,
                Duration = model.Duration,
                Status = model.Status,
                Doctor = model.Doctor,
            };
        }
    }
}
