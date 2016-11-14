
namespace ewm.AdminLTE {
    using Modules.AdminLTE;
    using System;
    using System.Web.Mvc;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json.Linq;
    using System.Net.Mail;
    using System.Net;
    using Serenity.Services;
    using Serenity.Data;

    [Authorize, RoutePrefix("AdminLTE"), Route("{action=index}")]
    public class AdminLTEController : Controller {

        /// <summary>
        /// Retunrs the calendar view when the Dashboard is first loaded
        /// </summary>
        /// <returns></returns>
        public ActionResult Calendar() {
            return View(MVC.Views.AdminLTE.Calendar);
        }


        /// <summary>
        /// Return events between the dates. 
        /// </summary>
        /// <param name="start">Lower bound of the filter</param>
        /// <param name="end">Upper bounnd of the filter</param>
        /// <returns></returns>
        [ServiceAuthorize("Calendar", "Student")]
        public JArray GetCalendarEvents(string start, string end) {
            using (ewm_Calednar_v1Entities context = new ewm_Calednar_v1Entities()) {
                DateTime startDate = DateTime.Parse(start);
                DateTime endDate = DateTime.Parse(end);

                var temp = from row in context.Classes
                           where row.StartDate >= startDate && row.EndDate <= endDate
                           select new {
                               id = row.Id,
                               title = row.Title,
                               start = row.StartDate,
                               end = row.EndDate,
                               color = row.StatusColor,
                               className = row.ClassName,
                           };

                JArray events = new JArray();

                foreach (var item in temp) {
                    dynamic e = new JObject();
                    e.id = item.id;
                    e.title = item.title;
                    e.start = item.start.ToString("s");
                    e.end = item.end.ToString("s");
                    e.className = item.className;
                    events.Add(e);
                }

                return events;
            }

        }

        /// <summary>
        /// Updates a single event. 
        /// this function is also invoked when an event on the calendar is moved.
        /// </summary>
        /// <param name="data"></param>
        [HttpPost]
        [ServiceAuthorize("Calendar", "Administrator")]
        public void UpdateEvent(UpdateEventModel data) {
            List<string> usernames = new List<string>();

            // EventStart comes ISO 8601 format, eg:  "2000-01-10T10:00:00Z" - need to convert to DateTime
            using (ewm_Calednar_v1Entities ent = new ewm_Calednar_v1Entities()) {
                var row = ent.Classes.FirstOrDefault(r => r.Id == data.eventId);
                if (row != null) {
                    usernames.AddRange(row.Members.Select(r => r.Username));
                    row.StartDate = DateTime.Parse(data.eventStart);
                    row.EndDate = DateTime.Parse(data.eventEnd);
                    ent.SaveChanges();
                    SendMessageTo(usernames, MessageHelper.ClassUpdate(row.Title, row.StartDate, row.EndDate));
                }
            }
        }


        /// <summary>
        /// Upadtes a series of events.
        /// </summary>
        /// <param name="model"></param>
        [HttpPost]
        [ServiceAuthorize("Calendar", "Administrator")]
        public void UpdateSeries(UpdateEventModel model) {
            List<string> usernames = new List<string>();
            using (ewm_Calednar_v1Entities ent = new ewm_Calednar_v1Entities()) {
                var row = ent.Classes.FirstOrDefault(r => r.Id == model.eventId);
                if (row != null) {
                    usernames.AddRange(row.Members.Select(r => r.Username));
                    var sameClasses = ent.Classes.Where(r => r.RepeatId == row.RepeatId);

                    foreach (var r in sameClasses) {
                        r.StartDate = DateTime.Parse(model.eventStart);
                        r.EndDate = DateTime.Parse(model.eventEnd);
                    }
                }

                ent.SaveChanges();
                SendMessageTo(usernames, MessageHelper.ClassSeriesUpdate(row.Title));
            }
        }


        /// <summary>
        /// Delete a single event.
        /// </summary>
        /// <param name="model"></param>
        [ServiceAuthorize("Calendar Delete Class", "Administrator")]
        public void DeleteEvent(UpdateEventModel model) {
            List<string> usernames = new List<string>();
            using (ewm_Calednar_v1Entities context = new ewm_Calednar_v1Entities()) {
                var row = context.Classes.FirstOrDefault(r => r.Id == model.eventId);
                if (row != null) {
                    usernames.AddRange(row.Members.Select(r => r.Username));
                    context.Classes.Remove(row);
                }

                context.SaveChanges();
                SendMessageTo(usernames, MessageHelper.ClassCancelled(row.Title, row.StartDate));
            }
        }

        [ServiceAuthorize("Calendar Delete Class Series", "Administrator")]
        public void DeleteSeries(UpdateEventModel model) {
            List<string> usernames = new List<string>();
            using (ewm_Calednar_v1Entities context = new ewm_Calednar_v1Entities()) {
                var row = context.Classes.FirstOrDefault(r => r.Id == model.eventId);
                if (row != null) {
                    usernames.AddRange(row.Members.Select(r => r.Username));

                    var classesInSeries = context.Classes.Where(r => r.RepeatId == row.RepeatId);
                    foreach (var c in classesInSeries) {
                        c.Members.Clear();
                    }
                    context.Classes.RemoveRange(classesInSeries);
                }

                context.SaveChanges();
                SendMessageTo(usernames, MessageHelper.ClassSeriesCancelled(row.Title));
            }

        }


        /// <summary>
        /// Creates a singe event. This function is deprecated.
        /// Create series has the abilitiy to create single event.
        /// /// </summary>
        /// <param name="model"></param>
        [ServiceAuthorize("Calendar", "Administrator")]
        public void CreateEvent(NewEventModel model) {
            List<string> usernames = new List<string>();
            using (ewm_Calednar_v1Entities ent = new ewm_Calednar_v1Entities()) {
                try {
                    string start = model.startDate + " " + model.startTime;
                    string end = model.endDate + " " + model.endTime;

                    Classes row = new Classes() {
                        EndDate = DateTime.Parse(end),
                        StartDate = DateTime.Parse(start),
                        ClassName = "",
                        StatusColor = "Blue",
                        Title = model.className,
                        Status = "0",
                        RepeatId = RandomHexString()
                    };

                    ent.Classes.Add(row);
                    ent.SaveChanges();
                    usernames.AddRange(row.Members.Select(r => r.Username));

                } catch (System.Exception ex) {
                    throw new System.Exception("Error creating new event!", ex);
                }
            }
        }


        /// <summary>
        /// Creates either a single event or a series of events using the NewEventModel recceived form the 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ServiceAuthorize("Calendar", "Adminitstrator")]
        public string CreateSeries(NewEventModel model) {
            using (ewm_Calednar_v1Entities ent = new ewm_Calednar_v1Entities()) {
                try {
                    List<DateTime> StartDateTimes = new List<DateTime>();
                    //calculate start times for each class.
                    string start = model.startDate + " " + model.startTime;
                    string end = model.endDate + " " + model.endTime;

                    string todayStartTime = DateTime.Today.ToShortDateString() + " " + model.startTime;
                    string todayEndTime = DateTime.Today.ToShortDateString() + " " + model.endTime;

                    //set number of minutes
                    model.eventLengthInMinutes = (int)((DateTime.Parse(todayEndTime).Subtract(DateTime.Parse(todayStartTime)))).TotalMinutes;

                    ///parse datetims for error checking
                    DateTime EndDate = DateTime.Parse(end);
                    DateTime StartDate = DateTime.Parse(start);


                    ///check possible error conditions
                    if (EndDate <= StartDate) {
                        return "Error creating event! End date should be later than the start date.";
                    }

                    if (model.selectedUsers == null || model.selectedUsers.Count() == 0) {
                        return "Error creating eveent! Please select at least one student.";
                    }

                    ///check if this is a series
                    List<DayOfWeek> repeatOnDays = new List<DayOfWeek>();
                    if (model.repeatOnDays != null && model.repeatOnDays.Count() > 0) {
                        foreach (string item in model.repeatOnDays) {
                            if (item == DayOfWeek.Wednesday.ToString()) {
                                repeatOnDays.Add(DayOfWeek.Wednesday);
                            }
                            else if (item == DayOfWeek.Tuesday.ToString()) {
                                repeatOnDays.Add(DayOfWeek.Tuesday);
                            }
                            else if (item == DayOfWeek.Thursday.ToString()) {
                                repeatOnDays.Add(DayOfWeek.Thursday);
                            }
                            else if (item == DayOfWeek.Sunday.ToString()) {
                                repeatOnDays.Add(DayOfWeek.Sunday);
                            }
                            else if (item == DayOfWeek.Saturday.ToString()) {
                                repeatOnDays.Add(DayOfWeek.Saturday);
                            }
                            else if (item == DayOfWeek.Monday.ToString()) {
                                repeatOnDays.Add(DayOfWeek.Monday);
                            }
                            else if (item == DayOfWeek.Friday.ToString()) {
                                repeatOnDays.Add(DayOfWeek.Friday);
                            }
                        }
                    }
                    else {
                        repeatOnDays.Add(DayOfWeek.Wednesday);
                        repeatOnDays.Add(DayOfWeek.Tuesday);
                        repeatOnDays.Add(DayOfWeek.Thursday);
                        repeatOnDays.Add(DayOfWeek.Sunday);
                        repeatOnDays.Add(DayOfWeek.Saturday);
                        repeatOnDays.Add(DayOfWeek.Monday);
                        repeatOnDays.Add(DayOfWeek.Friday);
                    }


                    string repeatId = RandomHexString();


                    //create events
                    TimeSpan ts = EndDate.Subtract(StartDate);
                    DateTime dt = StartDate;
                    for (int i = 0; i < ts.TotalDays; i++) {

                        if (repeatOnDays.Contains(dt.DayOfWeek)) {
                            Classes row = new Classes() {
                                EndDate = dt.AddMinutes(model.eventLengthInMinutes),
                                StartDate = dt,
                                ClassName = "",
                                StatusColor = "Blue",
                                Title = model.className,
                                Status = "0",
                                RepeatId = repeatId,
                            };

                            foreach (string s in model.selectedUsers) {
                                row.Members.Add(new Members() {
                                    Username = s
                                });
                            }

                            ent.Classes.Add(row);
                        }

                        dt = dt.AddDays(1);
                    }
                    ent.SaveChanges();

                    string msg = MessageHelper.NewClassString(model.className);
                    SendMessageTo(model.selectedUsers.ToList(), msg);

                    return model.className + " created successfully!";
                } catch (System.Exception ex) {
                    throw new System.Exception("Error creating new event!", ex);
                }
            }
        }

        /// <summary>
        /// Initialize the database to create first entry. 
        /// This is done for test and should not be used in real appliation.
        /// </summary>
        /// <returns></returns>
        [ServiceAuthorize("Calendar", "Administrator")]
        public static bool InitialiseTest() {
            using (ewm_Calednar_v1Entities context = new ewm_Calednar_v1Entities()) {
                // init connection to database
                try {
                    Classes item = new Classes() {
                        StartDate = DateTime.Now - new TimeSpan(1, 0, 0),
                        EndDate = DateTime.Now,
                        Title = "test",
                        Status = "0",
                        ClassName = "",
                        StatusColor = "Blue",
                        RepeatId = RandomHexString()
                    };

                    context.Classes.Add(item);
                    context.SaveChanges();
                } catch (System.Exception ex) {
                    return false;
                }

                return true;
            }
        }

        /// <summary>
        /// Sends messages to users at the indictated list of usersnames with the specific message 
        /// </summary>
        /// <param name="usernames">sLists of users</param>
        /// <param name="msg">Contents of the message</param>
        /// <returns></returns>
        private static bool SendMessageTo(List<string> usernames, string msg) {
            //get user specific information
            using (ewm_Default_v1Entities context = new ewm_Default_v1Entities()) {
                var users = context.Users.Where(row => usernames.Contains(row.Username)).Select(r => new {
                    phone = r.PhoneNumber,
                    email = r.Email
                });

                Sms.SendSms(users.Select(r => r.phone).ToList(), msg);
                Email.SendEmail(users.Select(r => r.email).ToList(), msg);
            }

            return true;
        }

        /// <summary>
        /// Generates a hex string that will be used to link events in a series
        /// </summary>
        /// <returns></returns>
        private static string RandomHexString() {
            // 64 character precision or 256-bits
            Random rdm = new Random();
            string hexValue = string.Empty;
            int num;

            for (int i = 0; i < 8; i++) {
                num = rdm.Next(0, int.MaxValue);
                hexValue += num.ToString("X8");
            }

            return hexValue;
        }



        /// <summary>
        /// Returns a list of usernames in the database
        /// </summary>
        /// <returns></returns>
        [ServiceAuthorize("Calendar", "Administrator")]
        public JsonResult GetUsers() {
            List<string> users = new List<string>();
            using (ewm_Default_v1Entities context = new ewm_Default_v1Entities()) {
                var temp = context.Users.Select(r => new { r.Username }).ToArray();

                foreach (var user in temp) {
                    users.Add(user.Username.ToString());
                }
            }

            return this.Json(users, JsonRequestBehavior.AllowGet);
        }
    }
}