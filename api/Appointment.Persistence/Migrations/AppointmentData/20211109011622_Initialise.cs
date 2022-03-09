using System;
using Appointment.Persistence.Schema;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Appointment.Persistence.Migrations.AppointmentData
{
    public partial class Initialise : Migration
    {
        private readonly IDbContextSchema _schema;

        public Initialise(IDbContextSchema schema)
        {
            _schema = schema ?? throw new ArgumentNullException(nameof(schema));
        }
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: _schema.Schema);

            migrationBuilder.CreateTable(
                name: "Activity",
                schema: _schema.Schema,
                columns: table => new
                {
                    ActivityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Venue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsUserMaintainable = table.Column<bool>(type: "bit", nullable: false),
                    IsCancelled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.ActivityId);
                });

            migrationBuilder.CreateTable(
                name: "Answer",
                schema: _schema.Schema,
                columns: table => new
                {
                    AnswerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DisplayValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EffectiveStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EffectiveEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.AnswerId);
                });

            migrationBuilder.CreateTable(
                name: "CalendarItem",
                schema: _schema.Schema,
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DurationHour = table.Column<int>(type: "int", nullable: false),
                    DurationMinutes = table.Column<int>(type: "int", nullable: false),
                    EffectiveStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EffectiveEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerProfile",
                schema: _schema.Schema,
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerProfile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                schema: _schema.Schema,
                columns: table => new
                {
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DisplayValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsUserMaintainable = table.Column<bool>(type: "bit", nullable: false),
                    EffectiveStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EffectiveEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.QuestionId);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                schema: _schema.Schema,
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EffectiveStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EffectiveEndDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2999, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceItem",
                schema: _schema.Schema,
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DurationHour = table.Column<int>(type: "int", nullable: false),
                    DurationMinutes = table.Column<int>(type: "int", nullable: false),
                    EffectiveStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EffectiveEndDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2999, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                schema: _schema.Schema,
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoreName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperatingStartHour = table.Column<int>(type: "int", nullable: false),
                    OperatingStartMinutes = table.Column<int>(type: "int", nullable: false),
                    OperatingEndHour = table.Column<int>(type: "int", nullable: false),
                    OperatingEndMinutes = table.Column<int>(type: "int", nullable: false),
                    IsOpenOnWeekends = table.Column<bool>(type: "bit", nullable: false),
                    IsOpenOnSaturday = table.Column<bool>(type: "bit", nullable: false),
                    IsOpenOnSunday = table.Column<bool>(type: "bit", nullable: false),
                    ServiceHoursPerHour = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TelegramCustomerProfile",
                schema: _schema.Schema,
                columns: table => new
                {
                    TelegramCustomerProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChatId = table.Column<long>(type: "bigint", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelegramCustomerProfile", x => x.TelegramCustomerProfileId);
                });

            migrationBuilder.CreateTable(
                name: "TenantSettings",
                schema: _schema.Schema,
                columns: table => new
                {
                    TenantSettingID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsUserMaintainable = table.Column<bool>(type: "bit", nullable: false),
                    EffectiveStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EffectiveEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantSettings", x => x.TenantSettingID);
                });

            migrationBuilder.CreateTable(
                name: "UserProfile",
                schema: _schema.Schema,
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: ""),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReligionFK = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000009")),
                    CountryFK = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000233")),
                    OccupationFK = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActivityPhoto",
                schema: _schema.Schema,
                columns: table => new
                {
                    PhotoId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    ActivityFk = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityPhoto", x => x.PhotoId);
                    table.ForeignKey(
                        name: "FK_ActivityPhoto_Activity_ActivityFk",
                        column: x => x.ActivityFk,
                        principalSchema: _schema.Schema,
                        principalTable: "Activity",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointment",
                schema: _schema.Schema,
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppointmentStatusFK = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusChangeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CalendarItemFK = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisitFK = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsCancelled = table.Column<bool>(type: "bit", nullable: false),
                    CancellationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CancellationRequestBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CancellationReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRemainderSent = table.Column<bool>(type: "bit", nullable: false),
                    IsReScheduled = table.Column<bool>(type: "bit", nullable: false),
                    IsCustomerTurnUp = table.Column<bool>(type: "bit", nullable: false),
                    IsTelegram = table.Column<bool>(type: "bit", nullable: false),
                    BookDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointment_CalendarItem_CalendarItemFK",
                        column: x => x.CalendarItemFK,
                        principalSchema: _schema.Schema,
                        principalTable: "CalendarItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionAnswer",
                schema: _schema.Schema,
                columns: table => new
                {
                    QuestionFk = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnswerFk = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionAnswer", x => new { x.QuestionFk, x.AnswerFk });
                    table.ForeignKey(
                        name: "FK_QuestionAnswer_Answer_AnswerFk",
                        column: x => x.AnswerFk,
                        principalSchema: _schema.Schema,
                        principalTable: "Answer",
                        principalColumn: "AnswerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionAnswer_Question_QuestionFk",
                        column: x => x.QuestionFk,
                        principalSchema: _schema.Schema,
                        principalTable: "Question",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceServiceItem",
                schema: _schema.Schema,
                columns: table => new
                {
                    ServiceFK = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceItemFK = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceServiceItem", x => new { x.ServiceFK, x.ServiceItemFK });
                    table.ForeignKey(
                        name: "FK_ServiceServiceItem_Service_ServiceFK",
                        column: x => x.ServiceFK,
                        principalSchema: _schema.Schema,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceServiceItem_ServiceItem_ServiceItemFK",
                        column: x => x.ServiceItemFK,
                        principalSchema: _schema.Schema,
                        principalTable: "ServiceItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoreOffDays",
                schema: _schema.Schema,
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoreFK = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OffDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EffectiveStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EffectiveEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreOffDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreOffDays_Store_StoreFK",
                        column: x => x.StoreFK,
                        principalSchema: _schema.Schema,
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoreSpecialOffs",
                schema: _schema.Schema,
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoreFK = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OffDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OffStartHour = table.Column<int>(type: "int", nullable: false),
                    OffStartMinutes = table.Column<int>(type: "int", nullable: false),
                    OffEndHour = table.Column<int>(type: "int", nullable: false),
                    OffEndMinutes = table.Column<int>(type: "int", nullable: false),
                    IsDaily = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    EffectiveStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EffectiveEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreSpecialOffs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreSpecialOffs_Store_StoreFK",
                        column: x => x.StoreFK,
                        principalSchema: _schema.Schema,
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdminUser",
                schema: _schema.Schema,
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActiveStatus = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "A"),
                    UserProfileFK = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EffectiveStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EffectiveEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdminUser_UserProfile_UserProfileFK",
                        column: x => x.UserProfileFK,
                        principalSchema: _schema.Schema,
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUser",
                schema: _schema.Schema,
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActiveStatus = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "A"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserProfileFK = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUser", x => x.Username);
                    table.ForeignKey(
                        name: "FK_AppUser_UserProfile_UserProfileFK",
                        column: x => x.UserProfileFK,
                        principalSchema: _schema.Schema,
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserPhoto",
                schema: _schema.Schema,
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    AppUserProfileFK = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserPhoto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserPhoto_UserProfile_AppUserProfileFK",
                        column: x => x.AppUserProfileFK,
                        principalSchema: _schema.Schema,
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserQuestionAnswer",
                schema: _schema.Schema,
                columns: table => new
                {
                    AppUserProfileFK = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionFK = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnswerFK = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserQuestionAnswer", x => new { x.AppUserProfileFK, x.QuestionFK, x.AnswerFK });
                    table.ForeignKey(
                        name: "FK_AppUserQuestionAnswer_Answer_AnswerFK",
                        column: x => x.AnswerFK,
                        principalSchema: _schema.Schema,
                        principalTable: "Answer",
                        principalColumn: "AnswerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserQuestionAnswer_Question_QuestionFK",
                        column: x => x.QuestionFK,
                        principalSchema: _schema.Schema,
                        principalTable: "Question",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserQuestionAnswer_UserProfile_AppUserProfileFK",
                        column: x => x.AppUserProfileFK,
                        principalSchema: _schema.Schema,
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentCustomerProfile",
                schema: _schema.Schema,
                columns: table => new
                {
                    AppointmentFK = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerProfileFK = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentCustomerProfile", x => new { x.AppointmentFK, x.CustomerProfileFK });
                    table.ForeignKey(
                        name: "FK_AppointmentCustomerProfile_Appointment_AppointmentFK",
                        column: x => x.AppointmentFK,
                        principalSchema: _schema.Schema,
                        principalTable: "Appointment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentCustomerProfile_CustomerProfile_CustomerProfileFK",
                        column: x => x.CustomerProfileFK,
                        principalSchema: _schema.Schema,
                        principalTable: "CustomerProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentService",
                schema: _schema.Schema,
                columns: table => new
                {
                    AppointmentFK = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SerivceFK = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentService", x => new { x.AppointmentFK, x.SerivceFK });
                    table.ForeignKey(
                        name: "FK_AppointmentService_Appointment_AppointmentFK",
                        column: x => x.AppointmentFK,
                        principalSchema: _schema.Schema,
                        principalTable: "Appointment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentService_Service_SerivceFK",
                        column: x => x.SerivceFK,
                        principalSchema: _schema.Schema,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentTelegramCustomerProfile",
                schema: _schema.Schema,
                columns: table => new
                {
                    AppointmentFK = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TelegramCustomerProfileFK = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentTelegramCustomerProfile", x => new { x.AppointmentFK, x.TelegramCustomerProfileFK });
                    table.ForeignKey(
                        name: "FK_AppointmentTelegramCustomerProfile_Appointment_AppointmentFK",
                        column: x => x.AppointmentFK,
                        principalSchema: _schema.Schema,
                        principalTable: "Appointment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentTelegramCustomerProfile_TelegramCustomerProfile_TelegramCustomerProfileFK",
                        column: x => x.TelegramCustomerProfileFK,
                        principalSchema: _schema.Schema,
                        principalTable: "TelegramCustomerProfile",
                        principalColumn: "TelegramCustomerProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivityAttendee",
                schema: _schema.Schema,
                columns: table => new
                {
                    AppUserFK = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActivityFK = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppUserUsername = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ActivityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsHost = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityAttendee", x => new { x.AppUserFK, x.ActivityFK });
                    table.ForeignKey(
                        name: "FK_ActivityAttendee_Activity_ActivityId",
                        column: x => x.ActivityId,
                        principalSchema: _schema.Schema,
                        principalTable: "Activity",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActivityAttendee_AppUser_AppUserUsername",
                        column: x => x.AppUserUsername,
                        principalSchema: _schema.Schema,
                        principalTable: "AppUser",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                schema: _schema.Schema,
                columns: table => new
                {
                    RefreshTokenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppUserUsername = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Expires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Revoked = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.RefreshTokenId);
                    table.ForeignKey(
                        name: "FK_RefreshToken_AppUser_AppUserUsername",
                        column: x => x.AppUserUsername,
                        principalSchema: _schema.Schema,
                        principalTable: "AppUser",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityAttendee_ActivityId",
                schema: _schema.Schema,
                table: "ActivityAttendee",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityAttendee_AppUserUsername",
                schema: _schema.Schema,
                table: "ActivityAttendee",
                column: "AppUserUsername");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityPhoto_ActivityFk",
                schema: _schema.Schema,
                table: "ActivityPhoto",
                column: "ActivityFk");

            migrationBuilder.CreateIndex(
                name: "IX_AdminUser_UserProfileFK",
                schema: _schema.Schema,
                table: "AdminUser",
                column: "UserProfileFK",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_CalendarItemFK",
                schema: _schema.Schema,
                table: "Appointment",
                column: "CalendarItemFK",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentCustomerProfile_CustomerProfileFK",
                schema: _schema.Schema,
                table: "AppointmentCustomerProfile",
                column: "CustomerProfileFK");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentService_SerivceFK",
                schema: _schema.Schema,
                table: "AppointmentService",
                column: "SerivceFK");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentTelegramCustomerProfile_TelegramCustomerProfileFK",
                schema: _schema.Schema,
                table: "AppointmentTelegramCustomerProfile",
                column: "TelegramCustomerProfileFK");

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_UserProfileFK",
                schema: _schema.Schema,
                table: "AppUser",
                column: "UserProfileFK",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppUserPhoto_AppUserProfileFK",
                schema: _schema.Schema,
                table: "AppUserPhoto",
                column: "AppUserProfileFK");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserQuestionAnswer_AnswerFK",
                schema: _schema.Schema,
                table: "AppUserQuestionAnswer",
                column: "AnswerFK");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserQuestionAnswer_QuestionFK",
                schema: _schema.Schema,
                table: "AppUserQuestionAnswer",
                column: "QuestionFK");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswer_AnswerFk",
                schema: _schema.Schema,
                table: "QuestionAnswer",
                column: "AnswerFk");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_AppUserUsername",
                schema: _schema.Schema,
                table: "RefreshToken",
                column: "AppUserUsername");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceServiceItem_ServiceItemFK",
                schema: _schema.Schema,
                table: "ServiceServiceItem",
                column: "ServiceItemFK");

            migrationBuilder.CreateIndex(
                name: "IX_StoreOffDays_StoreFK",
                schema: _schema.Schema,
                table: "StoreOffDays",
                column: "StoreFK");

            migrationBuilder.CreateIndex(
                name: "IX_StoreSpecialOffs_StoreFK",
                schema: _schema.Schema,
                table: "StoreSpecialOffs",
                column: "StoreFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityAttendee",
                schema: _schema.Schema);

            migrationBuilder.DropTable(
                name: "ActivityPhoto",
                schema: _schema.Schema);

            migrationBuilder.DropTable(
                name: "AdminUser",
                schema: _schema.Schema);

            migrationBuilder.DropTable(
                name: "AppointmentCustomerProfile",
                schema: _schema.Schema);

            migrationBuilder.DropTable(
                name: "AppointmentService",
                schema: _schema.Schema);

            migrationBuilder.DropTable(
                name: "AppointmentTelegramCustomerProfile",
                schema: _schema.Schema);

            migrationBuilder.DropTable(
                name: "AppUserPhoto",
                schema: _schema.Schema);

            migrationBuilder.DropTable(
                name: "AppUserQuestionAnswer",
                schema: _schema.Schema);

            migrationBuilder.DropTable(
                name: "QuestionAnswer",
                schema: _schema.Schema);

            migrationBuilder.DropTable(
                name: "RefreshToken",
                schema: _schema.Schema);

            migrationBuilder.DropTable(
                name: "ServiceServiceItem",
                schema: _schema.Schema);

            migrationBuilder.DropTable(
                name: "StoreOffDays",
                schema: _schema.Schema);

            migrationBuilder.DropTable(
                name: "StoreSpecialOffs",
                schema: _schema.Schema);

            migrationBuilder.DropTable(
                name: "TenantSettings",
                schema: _schema.Schema);

            migrationBuilder.DropTable(
                name: "Activity",
                schema: _schema.Schema);

            migrationBuilder.DropTable(
                name: "CustomerProfile",
                schema: _schema.Schema);

            migrationBuilder.DropTable(
                name: "Appointment",
                schema: _schema.Schema);

            migrationBuilder.DropTable(
                name: "TelegramCustomerProfile",
                schema: _schema.Schema);

            migrationBuilder.DropTable(
                name: "Answer",
                schema: _schema.Schema);

            migrationBuilder.DropTable(
                name: "Question",
                schema: _schema.Schema);

            migrationBuilder.DropTable(
                name: "AppUser",
                schema: _schema.Schema);

            migrationBuilder.DropTable(
                name: "Service",
                schema: _schema.Schema);

            migrationBuilder.DropTable(
                name: "ServiceItem",
                schema: _schema.Schema);

            migrationBuilder.DropTable(
                name: "Store",
                schema: _schema.Schema);

            migrationBuilder.DropTable(
                name: "CalendarItem",
                schema: _schema.Schema);

            migrationBuilder.DropTable(
                name: "UserProfile",
                schema: _schema.Schema);
        }
    }
}
