using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ewm.Modules.AdminLTE {

    /// <summary>
    /// Model that passes information between the View JS and the controller.
    /// This is used for new events.
    /// </summary>
    public class NewEventModel {
        public string className { get; set; }
        public string startDate { get; set; }
        public string startTime { get; set; }
        public string endDate { get; set; }
        public string endTime { get; set; }
        public int eventLengthInMinutes { get; set; }
        public IEnumerable<string> repeatOnDays { get; set; }
        public IEnumerable<string> selectedUsers { get; set; }
    }
}