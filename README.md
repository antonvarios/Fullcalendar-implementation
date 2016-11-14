List of changes and new files:

UserColumns.cs
UserDialog.ts
UserEndpoint.cs
UserForm.cs
UserGrid.ts
UserIndex.cshtml
UserPage.cs
UserRepository.cs
UserRow.cs

AdminLTEController.cs
Calendar.cshtml
CalendarModel.edmx
> Auto generated classes listed below.CalendarModel.edmx.sql
DefaultDb.edmx
> Auto generated classes listed below.
Email.cs
MessageHelper.cs
NewEventModel.cs
Sms.cs
User.cs



Methods/Properties/Variables Created during implementations of this project:
ewm.AdminLTE	AdminLTEController	Calendar() : ActionResult
ewm.AdminLTE	AdminLTEController	CreateEvent(NewEventModel) : void
ewm.AdminLTE	AdminLTEController	CreateSeries(NewEventModel) : string
ewm.AdminLTE	AdminLTEController	DeleteEvent(UpdateEventModel) : void
ewm.AdminLTE	AdminLTEController	DeleteSeries(UpdateEventModel) : void
ewm.AdminLTE	AdminLTEController	GetCalendarEvents(string, string) : JArray
ewm.AdminLTE	AdminLTEController	GetUsers() : JsonResult
ewm.AdminLTE	AdminLTEController	InitialiseTest() : bool
ewm.AdminLTE	AdminLTEController	RandomHexString() : string
ewm.AdminLTE	AdminLTEController	SendMessageTo(List<string>, string) : bool
ewm.AdminLTE	AdminLTEController	UpdateEvent(UpdateEventModel) : void
ewm.AdminLTE	AdminLTEController	UpdateSeries(UpdateEventModel) : void

ewm.Modules.AdminLTE	Sms	 
ewm.Modules.AdminLTE	Sms	ParseSmsResponseJson(string) : void
ewm.Modules.AdminLTE	Sms	SendSms(List<string>, string) : void
ewm.Modules.AdminLTE	Sms	SendSMS(Sms.SmsMessage) : void
ewm.Modules.AdminLTE	Sms	Sms()
ewm.Modules.AdminLTE	Sms.SmsMessage	 
ewm.Modules.AdminLTE	Sms.SmsMessage	MessageId.get() : string
ewm.Modules.AdminLTE	Sms.SmsMessage	MessageId.set(string) : void
ewm.Modules.AdminLTE	Sms.SmsMessage	Messageprice.get() : string
ewm.Modules.AdminLTE	Sms.SmsMessage	Messageprice.set(string) : void
ewm.Modules.AdminLTE	Sms.SmsMessage	RemainingBalance.get() : string
ewm.Modules.AdminLTE	Sms.SmsMessage	RemainingBalance.set(string) : void
ewm.Modules.AdminLTE	Sms.SmsMessage	SmsMessage()
ewm.Modules.AdminLTE	Sms.SmsMessage	Status.get() : string
ewm.Modules.AdminLTE	Sms.SmsMessage	Status.set(string) : void
ewm.Modules.AdminLTE	Sms.SmsMessage	Text.get() : string
ewm.Modules.AdminLTE	Sms.SmsMessage	Text.set(string) : void
ewm.Modules.AdminLTE	Sms.SmsMessage	To.get() : string
ewm.Modules.AdminLTE	Sms.SmsMessage	To.set(string) : void
ewm.Modules.AdminLTE	Sms.SmsResponse	 
ewm.Modules.AdminLTE	Sms.SmsResponse	Messagecount.get() : string
ewm.Modules.AdminLTE	Sms.SmsResponse	Messagecount.set(string) : void
ewm.Modules.AdminLTE	Sms.SmsResponse	Messages.get() : List<Sms.SmsMessage>
ewm.Modules.AdminLTE	Sms.SmsResponse	Messages.set(List<Sms.SmsMessage>) : void
ewm.Modules.AdminLTE	Sms.SmsResponse	SmsResponse()


ewm.Modules.AdminLTE	Email	 
ewm.Modules.AdminLTE	Email	SendEmail(List<string>, string) : bool
ewm.Modules.AdminLTE	Email	SendEmail(string, string) : bool

ewm.Modules.AdminLTE	NewEventModel	className.get() : string
ewm.Modules.AdminLTE	NewEventModel	className.set(string) : void
ewm.Modules.AdminLTE	NewEventModel	endDate.get() : string
ewm.Modules.AdminLTE	NewEventModel	endDate.set(string) : void
ewm.Modules.AdminLTE	NewEventModel	endTime.get() : string
ewm.Modules.AdminLTE	NewEventModel	endTime.set(string) : void
ewm.Modules.AdminLTE	NewEventModel	eventLengthInMinutes.get() : int
ewm.Modules.AdminLTE	NewEventModel	eventLengthInMinutes.set(int) : void
ewm.Modules.AdminLTE	NewEventModel	NewEventModel()
ewm.Modules.AdminLTE	NewEventModel	repeatOnDays.get() : IEnumerable<string>
ewm.Modules.AdminLTE	NewEventModel	repeatOnDays.set(IEnumerable<string>) : void
ewm.Modules.AdminLTE	NewEventModel	selectedUsers.get() : IEnumerable<string>
ewm.Modules.AdminLTE	NewEventModel	selectedUsers.set(IEnumerable<string>) : void
ewm.Modules.AdminLTE	NewEventModel	startDate.get() : string
ewm.Modules.AdminLTE	NewEventModel	startDate.set(string) : void
ewm.Modules.AdminLTE	NewEventModel	startTime.get() : string
ewm.Modules.AdminLTE	NewEventModel	startTime.set(string) : void

ewm.Modules.AdminLTE	UpdateEventModel	 
ewm.Modules.AdminLTE	UpdateEventModel	eventEnd.get() : string
ewm.Modules.AdminLTE	UpdateEventModel	eventEnd.set(string) : void
ewm.Modules.AdminLTE	UpdateEventModel	eventId.get() : int
ewm.Modules.AdminLTE	UpdateEventModel	eventId.set(int) : void
ewm.Modules.AdminLTE	UpdateEventModel	eventStart.get() : string
ewm.Modules.AdminLTE	UpdateEventModel	eventStart.set(string) : void
ewm.Modules.AdminLTE	UpdateEventModel	UpdateEventModel()

EDMX - Database connection implementations:
ewm.Modules.AdminLTE	ewm_Calednar_v1Entities	 
ewm.Modules.AdminLTE	ewm_Calednar_v1Entities	Classes.get() : DbSet<Classes>
ewm.Modules.AdminLTE	ewm_Calednar_v1Entities	Classes.set(DbSet<Classes>) : void
ewm.Modules.AdminLTE	ewm_Calednar_v1Entities	ewm_Calednar_v1Entities()
ewm.Modules.AdminLTE	ewm_Calednar_v1Entities	Members.get() : DbSet<Members>
ewm.Modules.AdminLTE	ewm_Calednar_v1Entities	Members.set(DbSet<Members>) : void
ewm.Modules.AdminLTE	ewm_Calednar_v1Entities	OnModelCreating(DbModelBuilder) : void

ewm.Modules.AdminLTE	ewm_Default_v1Entities	 
ewm.Modules.AdminLTE	ewm_Default_v1Entities	ewm_Default_v1Entities()
ewm.Modules.AdminLTE	ewm_Default_v1Entities	Exceptions.get() : DbSet<Exception>
ewm.Modules.AdminLTE	ewm_Default_v1Entities	Exceptions.set(DbSet<Exception>) : void
ewm.Modules.AdminLTE	ewm_Default_v1Entities	Languages.get() : DbSet<Language>
ewm.Modules.AdminLTE	ewm_Default_v1Entities	Languages.set(DbSet<Language>) : void
ewm.Modules.AdminLTE	ewm_Default_v1Entities	OnModelCreating(DbModelBuilder) : void
ewm.Modules.AdminLTE	ewm_Default_v1Entities	RolePermissions.get() : DbSet<RolePermission>
ewm.Modules.AdminLTE	ewm_Default_v1Entities	RolePermissions.set(DbSet<RolePermission>) : void
ewm.Modules.AdminLTE	ewm_Default_v1Entities	Roles.get() : DbSet<Role>
ewm.Modules.AdminLTE	ewm_Default_v1Entities	Roles.set(DbSet<Role>) : void
ewm.Modules.AdminLTE	ewm_Default_v1Entities	UserPermissions.get() : DbSet<UserPermission>
ewm.Modules.AdminLTE	ewm_Default_v1Entities	UserPermissions.set(DbSet<UserPermission>) : void
ewm.Modules.AdminLTE	ewm_Default_v1Entities	UserPreferences.get() : DbSet<UserPreference>
ewm.Modules.AdminLTE	ewm_Default_v1Entities	UserPreferences.set(DbSet<UserPreference>) : void
ewm.Modules.AdminLTE	ewm_Default_v1Entities	UserRoles.get() : DbSet<UserRole>
ewm.Modules.AdminLTE	ewm_Default_v1Entities	UserRoles.set(DbSet<UserRole>) : void
ewm.Modules.AdminLTE	ewm_Default_v1Entities	Users.get() : DbSet<User>
ewm.Modules.AdminLTE	ewm_Default_v1Entities	Users.set(DbSet<User>) : void
ewm.Modules.AdminLTE	ewm_Default_v1Entities	VersionInfoes.get() : DbSet<VersionInfo>
ewm.Modules.AdminLTE	ewm_Default_v1Entities	VersionInfoes.set(DbSet<VersionInfo>) : void
ewm.Modules.AdminLTE	ewm_Default_v1Entities	VersionInfoes1.get() : DbSet<VersionInfo1>
ewm.Modules.AdminLTE	ewm_Default_v1Entities	VersionInfoes1.set(DbSet<VersionInfo1>) : void



** Addtional changes were made to the Serenity template to include the use of 'PhoneNumber' Column:
ewm	UserDefinition	PhoneNumber.get() : string
ewm	UserDefinition	PhoneNumber.set(string) : void

ewm.Administration.Entities	UserRow	PhoneNumber.get() : string
ewm.Administration.Entities	UserRow	PhoneNumber.set(string) : void
ewm.Administration.Forms	UserColumns	PhoneNumber.get() : string
ewm.Administration.Forms	UserColumns	PhoneNumber.set(string) : void
ewm.Administration.Forms	UserForm	PhoneNumber.get() : string
ewm.Administration.Forms	UserForm	PhoneNumber.set(string) : void
ewm.Modules.AdminLTE		User	PhoneNumber.get() : string
ewm.Modules.AdminLTE		User	PhoneNumber.set(string) : void


Changes to '\ewm\ewm.Web\Web.config' to include the following:
  <connectionStrings>

  ...
  
    <add name="ewm_Calednar_v1Entities" connectionString="metadata=res://*/Modules.AdminLTE.CalendarModel.csdl|res://*/Modules.AdminLTE.CalendarModel.ssdl|res://*/Modules.AdminLTE.CalendarModel.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=(LocalDb)\MSSQLLocalDB;initial catalog=ewm_Calednar_v1;Integrated Security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
    <add name="ewm_Default_v1Entities" connectionString="metadata=res://*/Modules.AdminLTE.DefaultDb.csdl|res://*/Modules.AdminLTE.DefaultDb.ssdl|res://*/Modules.AdminLTE.DefaultDb.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=(LocalDb)\MSSQLLocalDB;initial catalog=ewm_Default_v1;Integrated Security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
  </connectionStrings>

You would also need to create a 'AppSettings.config' file and place it in 'C:/temp/AppSettings.config' with the SMTP and API details as below. 
Gmail was used in this case (mail.google.com) but any number of email providers can be used:


<appSettings>   
   <!-- Gmail-->
   <add key="mailAccount" value="<SMPT ACCOUNT>" />
   <add key="mailPassword" value="<LOGIN CREDENTIALS>" />
   <add key="smtpHost" value="<SMTP SERVER NAME>" />


   <!-- NEXEO-->
   <add key="api_key" value="<PERSONAL API KEY HERE>" />
   <add key="api_secret" value="<PERSONAL API SECRET HERE>" />  
</appSettings>

Databases:

The databases used in this project are located in the 'App_Data' folder as *.mdf and *.ldf files and are included along with this porject. The database files MUST be imported into the local MSSQL Instance prior to execution of the project. 

ewm_Calednar_v1.ldf
ewm_Calednar_v1.mdf
ewm_Default_v1.ldf
ewm_Default_v1.mdf