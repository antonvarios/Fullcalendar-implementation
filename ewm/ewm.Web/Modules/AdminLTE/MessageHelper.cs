using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ewm.Modules.AdminLTE {
    /// <summary>
    /// Creates prefabricated messages with the given paramters.
    /// </summary>
    public static class MessageHelper {

        /// <summary>
        /// Creates a message about a change in the schedule.
        /// </summary>
        /// <param name="title">Title of the event.</param>
        /// <param name="_s">Start time of the event.</param>
        /// <param name="_e">End time of the event.</param>
        /// <returns></returns>
        public static string ClassUpdate(string title, DateTime _s, DateTime _e) {
            return "The new schedule for " + title + " is from " + _s.ToString() + " to " + _e.ToString();
        }

        /// <summary>
        /// Creates a message about a new class.
        /// </summary>
        /// <param name="title">Title of the event.</param>
        /// <returns></returns>
        public static string NewClassString(string title) {
            return "You have been registered for a new Class: " + title;
        }

        /// <summary>
        /// Creates a message about an update to a series of events with the given name.
        /// </summary>
        /// <param name="title">Title of the series.</param>
        /// <returns></returns>
        public static string ClassSeriesUpdate(string title) {
            return "Your schedule for: " + title + " has been updated. Check calendars for new schedule.";
        }
        
        /// <summary>
        /// Creates a message about an event being cancelled.
        /// </summary>
        /// <param name="title">Title of the event.</param>
        /// <param name="_s">Start time of the event.</param>
        /// <returns></returns>
        public static string ClassCancelled(string title, DateTime _s) {
            return "Your class: " + title + " at: " + _s.ToShortDateString() + " has been cancelled.";
        }

        /// <summary>
        /// Creates a message about a series of event being cancelled.
        /// </summary>
        /// <param name="title">Title of the series.</param>
        /// <returns></returns>
        public static string ClassSeriesCancelled(string title) {
            return "Your schedule for: " + title + " has been cancelled. Check calendars for new schedule.";
        }
    }
}