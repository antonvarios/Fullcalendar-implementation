using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ewm.Modules.AdminLTE {
    /// <summary>
    /// Model that passes information between the View JS and the controller.
    /// This is used when modifying events.
    /// </summary>
    public class UpdateEventModel {
        public int eventId { get; set; }
        public string eventStart { get; set; }
        public string eventEnd { get; set; }
    }
}