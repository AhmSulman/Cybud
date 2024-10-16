using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cybud_WPF_0._1.Models
{
    [AddINotifyPropertyChangedInterface]
    public class Schedule
    {
        // The starting time of the time slot (e.g., "08:00 AM")
        public string Time { get; set; }

        // The activity scheduled for this time slot (e.g., "Morning Meeting")
        public string Activity { get; set; }

        // A boolean indicating whether this time slot is filled with an activity
        public bool IsFilled { get; set; }

        // Constructor for initializing the TimeSlot object with default values
        public Schedule(string time)
        {
            Time = time; // Sets the time for the time slot
            Activity = string.Empty; // Initializes the activity as an empty string (no activity)
            IsFilled = false; // Initializes the slot as not filled
        }
    }
}
