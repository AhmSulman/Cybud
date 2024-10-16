using Cybud_WPF_0._1.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cybud_WPF_0._1.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ScheduleViewModel
    {
        // Collection to hold time slots for the schedule
        public ObservableCollection<Schedule> TimeSlots { get; set; }

        // Constructor to initialize the schedule with predefined time slots
        public ScheduleViewModel()
        {
            // Initialize the collection with time slots
            TimeSlots = new ObservableCollection<Schedule>
            {
                new Schedule("08:00 AM - 09:00 AM"),
                new Schedule("09:00 AM - 10:00 AM"),
                new Schedule("10:00 AM - 11:00 AM"),
                new Schedule("11:00 AM - 12:00 PM"),
                new Schedule("12:00 PM - 01:00 PM"),
                new Schedule("01:00 PM - 02:00 PM"),
                new Schedule("02:00 PM - 03:00 PM"),
                new Schedule("03:00 PM - 04:00 PM"),
                new Schedule("04:00 PM - 05:00 PM")
            };
        }
    }
}
