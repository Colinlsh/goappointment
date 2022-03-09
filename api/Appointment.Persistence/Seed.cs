using Appointment.Domain;
using Appointment.Domain.Enums;
using Appointment.Domain.Main;
using Appointment.Domain.Tenant;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appointment.Persistence
{
    public class Seed
    {
        public static async Task SeedData(AppointmentDataContext context, AppointmentMainDataContext mainDataContext)
        {
            var EffectiveEndDate = DateTime.Parse("2999-12-31 00:00:00");
            var EffectiveStartDate = DateTime.Parse("2021-06-22 00:00:00");

            var users = new List<Domain.Tenant.AppUser>();

            //if (!context.Roles.Any())
            //{
            //    var roles = new List<AppUserRole>
            //    {
            //        new AppUserRole
            //        {
            //            Name = RoleType.SuperAdmin.GetDescription(),
            //            NormalizedName = RoleType.SuperAdmin.GetDescription().ToUpper(),
            //            SortOrder = 1,
            //        },
            //        new AppUserRole
            //        {
            //            Name = RoleType.TenantOwner.GetDescription(),
            //            NormalizedName = RoleType.TenantOwner.GetDescription().ToUpper(),
            //            SortOrder = 2
            //        },
            //        new AppUserRole
            //        {
            //            Name = RoleType.Customer.GetDescription(),
            //            NormalizedName = RoleType.Customer.GetDescription().ToUpper(),
            //            SortOrder = 3,
            //        }
            //    };

            //    await context.AppUserRole.AddRangeAsync(roles);

            //    await context.SaveChangesAsync();
            //}

            if (!mainDataContext.CTAppointmentStatus.Any())
            {
                var appStatus = new List<CTAppointmentStatus>
                {
                    new CTAppointmentStatus
                    {
                        Code = "DRAFT",
                        DisplayValue = "Draft",
                        Description = "Draft",
                        IsUserMaintainable = true,
                        SortOrder = 1,
                        EffectiveStartDate = EffectiveStartDate,
                        EffectiveEndDate = EffectiveEndDate,
                        CreateDate = EffectiveStartDate,
                        UpdateDate = EffectiveStartDate,
                    },
                    new CTAppointmentStatus
                    {
                        Code = "SCHEDULED",
                        DisplayValue = "Scheduled",
                        Description = "Scheduled",
                        IsUserMaintainable = true,
                        SortOrder = 1,
                        EffectiveStartDate = EffectiveStartDate,
                        EffectiveEndDate = EffectiveEndDate,
                        CreateDate = EffectiveStartDate,
                        UpdateDate = EffectiveStartDate,
                    },
                    new CTAppointmentStatus
                    {
                        Code = "ACTUALISED",
                        DisplayValue = "Actualised",
                        Description = "Actualised",
                        IsUserMaintainable = true,
                        SortOrder = 1,
                        EffectiveStartDate = EffectiveStartDate,
                        EffectiveEndDate = EffectiveEndDate,
                        CreateDate = EffectiveStartDate,
                        UpdateDate = EffectiveStartDate,
                    },
                    new CTAppointmentStatus
                    {
                        Code = "RESCHEDULED",
                        DisplayValue = "Rescheduled",
                        Description = "Rescheduled",
                        IsUserMaintainable = true,
                        SortOrder = 1,
                        EffectiveStartDate = EffectiveStartDate,
                        EffectiveEndDate = EffectiveEndDate,
                        CreateDate = EffectiveStartDate,
                        UpdateDate = EffectiveStartDate,
                    },
                    new CTAppointmentStatus
                    {
                        Code = "CANCELLED",
                        DisplayValue = "Cancelled",
                        Description = "Cancelled",
                        IsUserMaintainable = true,
                        SortOrder = 1,
                        EffectiveStartDate = EffectiveStartDate,
                        EffectiveEndDate = EffectiveEndDate,
                        CreateDate = EffectiveStartDate,
                        UpdateDate = EffectiveStartDate,
                    }
                };

                await mainDataContext.CTAppointmentStatus.AddRangeAsync(appStatus);

                await mainDataContext.SaveChangesAsync();
            }

            if (!mainDataContext.TenantMapping.Any())
            {

                var tenantMapping = new List<TenantMapping>
                {
                    new TenantMapping
                    {
                        TenantID = Guid.Parse("b3bf5c06-7b37-43f9-59e7-08d9390fafdc"),
                        TenantCode = "Tenant_001",
                        SchemaName = "Tenant_001",
                        DBServer = "db",
                        DBName = "Appointment_R0.1",
                        DBUsername = "SA",
                        DBUserPassword = "P@ssw0rd123456",
                        CreateDate = DateTime.Now,
                        CreateBy = "Colin88888888",
                        UpdateDate = DateTime.Now,
                        UpdateBy = "Colin8888888",
                        TenantIndex = 1,
                        HeCode = "AP0001",
                        IsMobileEnabled = null
                    }
                };

                await mainDataContext.TenantMapping.AddRangeAsync(tenantMapping);

                await mainDataContext.SaveChangesAsync();
            }

            // if (!context.AdminUsers.Any())
            // {
            //     var adminUsers = new List<AdminUser> {
            //         new AdminUser
            //         {
            //             Id = Guid.Parse("7322c637-e2f6-454f-0841-08d91e4e7c82"),
            //             CreateDate = DateTime.Now,
            //             UpdateDate = DateTime.Now,
            //             Username = "Colin88888888",
            //         }
            //     };

            //     await context.AdminUsers.AddRangeAsync(adminUsers);

            //     await context.SaveChangesAsync();
            // }

            // if (!mainDataContext.DashboardSuperAdminUser.Any())
            // {

            //     var dashboardSuperAdminUsers = new List<DashboardSuperAdminUser>
            //     {
            //         new DashboardSuperAdminUser
            //         {
            //             Id = Guid.Parse("7322c637-e2f6-454f-0841-08d91e4e7c82"),
            //             CreateDate = DateTime.Now,
            //             UpdateDate = DateTime.Now,
            //             Username = "Colin88888888",
            //         }
            //     };

            //     await mainDataContext.DashboardSuperAdminUser.AddRangeAsync(dashboardSuperAdminUsers);

            //     await mainDataContext.SaveChangesAsync();
            // }

            //if (!userManager.Users.Any())
            //{
            //    users = new List<AppUser>
            //    {
            //        new AppUser
            //        {
            //            Title = "Mr",
            //            UpdateDate = DateTime.Now,
            //            CreateDate =  DateTime.Now,
            //            FirstName = "Colin",
            //            LastName = "Lee",
            //            DisplayName = "Colin",
            //            Username = "Colin88888888",
            //            Email = "Colin88888888@test.com",
            //            Age = "30",
            //            Gender = "M",
            //            PhoneNumber = "98989898",
            //            ActiveStatus = "A"
            //            //,
            //            //Religion = Guid.Parse("00000000-0000-0000-0000-000000000005"),
            //            //Country = Guid.Parse("00000000-0000-0000-0000-000000000203")

            //        },
            //        new AppUser
            //        {
            //            Title = "Mrs",
            //            UpdateDate = DateTime.Now,
            //            CreateDate =  DateTime.Now,
            //            FirstName = "Jane",
            //            LastName = "Goh",
            //            DisplayName = "Jane",
            //            Username = "Jane88888888",
            //            Email = "Jane88888888@test.com",
            //            Age = "30",
            //            Gender = "F",
            //            PhoneNumber = "98888888",
            //            ActiveStatus = "A"
            //            //,
            //            //Religion = Guid.Parse("00000000-0000-0000-0000-000000000005"),
            //            //Country = Guid.Parse("00000000-0000-0000-0000-000000000203")
            //        },
            //        new AppUser
            //        {
            //            Title = "Mr",
            //            UpdateDate = DateTime.Now,
            //            CreateDate =  DateTime.Now,
            //            FirstName = "Yong Qian",
            //            LastName = "Yong",
            //            DisplayName = "Yong",
            //            Username = "Yong88888888",
            //            Email = "Yong88888888@test.com",
            //            Age = "30",
            //            Gender = "M",
            //            PhoneNumber = "88888888",
            //            ActiveStatus = "A"
            //            //,
            //            //Religion = Guid.Parse("00000000-0000-0000-0000-000000000005"),
            //            //Country = Guid.Parse("00000000-0000-0000-0000-000000000203")
            //        },
            //        new AppUser
            //        {
            //            Title = "Mrs",
            //            UpdateDate = DateTime.Now,
            //            CreateDate =  DateTime.Now,
            //            FirstName = "Shanon",
            //            LastName = "Yong",
            //            DisplayName = "Shanon",
            //            Username = "Shanon88888888",
            //            Email = "Shanon88888888@test.com",
            //            Age = "30",
            //            Gender = "F",
            //            PhoneNumber = "88888888",
            //            ActiveStatus = "A"
            //            //,
            //            //Religion = Guid.Parse("00000000-0000-0000-0000-000000000005"),
            //            //Country = Guid.Parse("00000000-0000-0000-0000-000000000203")
            //        },
            //        new AppUser
            //        {
            //            Title = "Mr",
            //            UpdateDate = DateTime.Now,
            //            CreateDate =  DateTime.Now,
            //            FirstName = "Bolin",
            //            LastName = "Chen",
            //            DisplayName = "Bolin",
            //            Username = "Bolin88888888",
            //            Email = "Bolin88888888@test.com",
            //            Age = "30",
            //            Gender = "M",
            //            PhoneNumber = "98888888",
            //            ActiveStatus = "A"
            //            //,
            //            //Religion = Guid.Parse("00000000-0000-0000-0000-000000000005"),
            //            //Country = Guid.Parse("00000000-0000-0000-0000-000000000203")
            //        }
            //    };

            //    foreach (var user in users)
            //    {
            //        var test = await userManager.CreateAsync(user, "Pa$$w0rd");
            //    }
            //}


            //if (!context.Activity.Any())
            //{
            //    var activities = new List<Activity>
            //    {
            //        new Activity
            //        {
            //            Title = "Past Activity 1",
            //            Date = DateTime.Now.AddMonths(-2),
            //            Description = "Activity 2 months ago",
            //            Category = "drinks",
            //            City = "London",
            //            Venue = "Pub",
            //            CreateDate = DateTime.Now,
            //            UpdateDate = DateTime.Now,
            //            IsUserMaintainable = true,
            //            Attendees =  new List<ActivityAttendee>
            //            {
            //                new ActivityAttendee
            //                {
            //                    AppUser = users[0],
            //                    IsHost = true
            //                }
            //            }
            //        },
            //        new Activity
            //        {
            //            Title = "Past Activity 2",
            //            Date = DateTime.Now.AddMonths(-1),
            //            Description = "Activity 1 month ago",
            //            Category = "culture",
            //            City = "Paris",
            //            Venue = "Louvre",
            //            CreateDate = DateTime.Now,
            //            UpdateDate = DateTime.Now,
            //            IsUserMaintainable = true,
            //            Attendees = new List<ActivityAttendee>
            //            {
            //                new ActivityAttendee
            //                {
            //                    AppUser = users[0],
            //                    IsHost = true
            //                },
            //                new ActivityAttendee
            //                {
            //                    AppUser = users[1],
            //                    IsHost = false
            //                },
            //            }
            //        },
            //        new Activity
            //        {
            //            Title = "Future Activity 1",
            //            Date = DateTime.Now.AddMonths(1),
            //            Description = "Activity 1 month in future",
            //            Category = "culture",
            //            City = "London",
            //            Venue = "Natural History Museum",
            //            CreateDate = DateTime.Now,
            //            UpdateDate = DateTime.Now,
            //            IsUserMaintainable = true,
            //            Attendees = new List<ActivityAttendee>
            //            {
            //                new ActivityAttendee
            //                {
            //                    AppUser = users[2],
            //                    IsHost = true
            //                },
            //                new ActivityAttendee
            //                {
            //                    AppUser = users[1],
            //                    IsHost = false
            //                },
            //            }
            //        },
            //        new Activity
            //        {
            //            Title = "Future Activity 2",
            //            Date = DateTime.Now.AddMonths(2),
            //            Description = "Activity 2 months in future",
            //            Category = "music",
            //            City = "London",
            //            Venue = "O2 Arena",
            //            CreateDate = DateTime.Now,
            //            UpdateDate = DateTime.Now,
            //            IsUserMaintainable = true,
            //            Attendees = new List<ActivityAttendee>
            //            {
            //                new ActivityAttendee
            //                {
            //                    AppUser = users[0],
            //                    IsHost = true
            //                },
            //                new ActivityAttendee
            //                {
            //                    AppUser = users[2],
            //                    IsHost = false
            //                },
            //            }
            //        },
            //        new Activity
            //        {
            //            Title = "Future Activity 3",
            //            Date = DateTime.Now.AddMonths(3),
            //            Description = "Activity 3 months in future",
            //            Category = "drinks",
            //            City = "London",
            //            Venue = "Another pub",
            //            CreateDate = DateTime.Now,
            //            UpdateDate = DateTime.Now,
            //            IsUserMaintainable = true,
            //            Attendees = new List<ActivityAttendee>
            //            {
            //                new ActivityAttendee
            //                {
            //                    AppUser = users[1],
            //                    IsHost = true
            //                },
            //                new ActivityAttendee
            //                {
            //                    AppUser = users[0],
            //                    IsHost = false
            //                },
            //            }
            //        },
            //        new Activity
            //        {
            //            Title = "Future Activity 4",
            //            Date = DateTime.Now.AddMonths(4),
            //            Description = "Activity 4 months in future",
            //            Category = "drinks",
            //            City = "London",
            //            Venue = "Yet another pub",
            //            CreateDate = DateTime.Now,
            //            UpdateDate = DateTime.Now,
            //            IsUserMaintainable = true,
            //            Attendees = new List<ActivityAttendee>
            //            {
            //                new ActivityAttendee
            //                {
            //                    AppUser = users[1],
            //                    IsHost = true
            //                }
            //            }
            //        },
            //        new Activity
            //        {
            //            Title = "Future Activity 5",
            //            Date = DateTime.Now.AddMonths(5),
            //            Description = "Activity 5 months in future",
            //            Category = "drinks",
            //            City = "London",
            //            Venue = "Just another pub",
            //            CreateDate = DateTime.Now,
            //            UpdateDate = DateTime.Now,
            //            IsUserMaintainable = true
            //        },
            //        new Activity
            //        {
            //            Title = "Future Activity 6",
            //            Date = DateTime.Now.AddMonths(6),
            //            Description = "Activity 6 months in future",
            //            Category = "music",
            //            City = "London",
            //            Venue = "Roundhouse Camden",
            //            CreateDate = DateTime.Now,
            //            UpdateDate = DateTime.Now,
            //            IsUserMaintainable = true,
            //            Attendees = new List<ActivityAttendee>
            //            {
            //                new ActivityAttendee
            //                {
            //                    AppUser = users[3],
            //                    IsHost = true
            //                },
            //                new ActivityAttendee
            //                {
            //                    AppUser = users[4],
            //                    IsHost = false
            //                },
            //            }
            //        },
            //        new Activity
            //        {
            //            Title = "Future Activity 7",
            //            Date = DateTime.Now.AddMonths(7),
            //            Description = "Activity 2 months ago",
            //            Category = "travel",
            //            City = "London",
            //            Venue = "Somewhere on the Thames",
            //            CreateDate = DateTime.Now,
            //            UpdateDate = DateTime.Now,
            //            IsUserMaintainable = true
            //        },
            //        new Activity
            //        {
            //            Title = "Future Activity 8",
            //            Date = DateTime.Now.AddMonths(8),
            //            Description = "Activity 8 months in future",
            //            Category = "film",
            //            City = "London",
            //            Venue = "Cinema",
            //            CreateDate = DateTime.Now,
            //            UpdateDate = DateTime.Now,
            //            IsUserMaintainable = true,
            //            Attendees = new List<ActivityAttendee>
            //            {
            //                new ActivityAttendee
            //                {
            //                    AppUser = users[4],
            //                    IsHost = true
            //                },
            //                new ActivityAttendee
            //                {
            //                    AppUser = users[3],
            //                    IsHost = false
            //                },
            //            }
            //        }
            //    };

            //    await context.Activity.AddRangeAsync(activities);
            //    await context.SaveChangesAsync();
            //}

            //if (!context.Answer.Any())
            //{
            //    var answers = new List<Answer>
            //    {
            //        new Answer
            //        {
            //            DisplayValue = "To get married",
            //            EffectiveStartDate = DateTime.Now,
            //            EffectiveEndDate = EffectiveEndDate,
            //            CreateDate = DateTime.Now,
            //            UpdateDate = DateTime.Now
            //        },
            //        new Answer
            //        {
            //            DisplayValue = "A serious relationship",
            //            EffectiveStartDate = DateTime.Now,
            //            EffectiveEndDate = EffectiveEndDate,
            //            CreateDate = DateTime.Now,
            //            UpdateDate = DateTime.Now
            //        },
            //        new Answer
            //        {
            //            DisplayValue = "Casual relationship/friendship",
            //            EffectiveStartDate = DateTime.Now,
            //            EffectiveEndDate = EffectiveEndDate,
            //            CreateDate = DateTime.Now,
            //            UpdateDate = DateTime.Now
            //        },
            //        new Answer
            //        {
            //            DisplayValue = "See how it goes",
            //            EffectiveStartDate = DateTime.Now,
            //            EffectiveEndDate = EffectiveEndDate,
            //            CreateDate = DateTime.Now,
            //            UpdateDate = DateTime.Now
            //        },
            //        new Answer
            //        {
            //            DisplayValue = "I am ready now",
            //            EffectiveStartDate = DateTime.Now,
            //            EffectiveEndDate = EffectiveEndDate,
            //            CreateDate = DateTime.Now,
            //            UpdateDate = DateTime.Now
            //        },
            //        new Answer
            //        {
            //            DisplayValue = "Within 2 years",
            //            EffectiveStartDate = DateTime.Now,
            //            EffectiveEndDate = EffectiveEndDate,
            //            CreateDate = DateTime.Now,
            //            UpdateDate = DateTime.Now
            //        },
            //        new Answer
            //        {
            //            DisplayValue = "More than 2 years",
            //            EffectiveStartDate = DateTime.Now,
            //            EffectiveEndDate = EffectiveEndDate,
            //            CreateDate = DateTime.Now,
            //            UpdateDate = DateTime.Now
            //        },
            //        new Answer
            //        {
            //            DisplayValue = "Not sure yet",
            //            EffectiveStartDate = DateTime.Now,
            //            EffectiveEndDate = EffectiveEndDate,
            //            CreateDate = DateTime.Now,
            //            UpdateDate = DateTime.Now
            //        },
            //         new Answer
            //        {
            //            DisplayValue = "Chinese",
            //            EffectiveStartDate = DateTime.Now,
            //            EffectiveEndDate = EffectiveEndDate,
            //            CreateDate = DateTime.Now,
            //            UpdateDate = DateTime.Now
            //        },
            //        new Answer
            //        {
            //            DisplayValue = "Halal Certified",
            //            EffectiveStartDate = DateTime.Now,
            //            EffectiveEndDate = EffectiveEndDate,
            //            CreateDate = DateTime.Now,
            //            UpdateDate = DateTime.Now
            //        },
            //        new Answer
            //        {
            //            DisplayValue = "Others",
            //            EffectiveStartDate = DateTime.Now,
            //            EffectiveEndDate = EffectiveEndDate,
            //            CreateDate = DateTime.Now,
            //            UpdateDate = DateTime.Now
            //        },
            //    };

            //    await context.Answer.AddRangeAsync(answers);
            //    await context.SaveChangesAsync();
            //}

            //if (!context.Question.Any())
            //{
            //    var _users = context.Users.ToList();
            //    var answers = context.Answer.ToList();
            //    var questionnaires = new List<Question>
            //    {
            //        new Question
            //        {
            //            DisplayValue = "What kind of relationships are you looking for?",
            //            EffectiveStartDate = DateTime.Now ,
            //            EffectiveEndDate = EffectiveEndDate,
            //            CreateDate = DateTime.Now,
            //            UpdateDate = DateTime.Now,
            //            Type = "MCQ",
            //            AppUserAnswers = new List<AppUserQuestionAnswer>
            //            {
            //                new AppUserQuestionAnswer
            //                {
            //                    AppUser = _users[3],
            //                    Answer = answers[3]
            //                },
            //                new AppUserQuestionAnswer
            //                {
            //                    AppUser = _users[2],
            //                    Answer = answers[2]
            //                }
            //            },
            //            Answers = new List<QuestionAnswer>
            //            {
            //                new QuestionAnswer
            //                {
            //                    Answer = answers[0],
            //                    AnswerFk = answers[0].AnswerId
            //                },
            //                new QuestionAnswer
            //                {
            //                    Answer = answers[1],
            //                    AnswerFk = answers[1].AnswerId
            //                },
            //                new QuestionAnswer
            //                {
            //                    Answer = answers[2],
            //                    AnswerFk = answers[2].AnswerId
            //                },
            //                new QuestionAnswer
            //                {
            //                    Answer = answers[3],
            //                    AnswerFk = answers[3].AnswerId
            //                }
            //            }
            //        },
            //        new Question
            //        {
            //            DisplayValue = "What kind of food are you looking for?",
            //            EffectiveStartDate = DateTime.Now ,
            //            EffectiveEndDate = EffectiveEndDate,
            //            CreateDate = DateTime.Now,
            //            UpdateDate = DateTime.Now,
            //            Type = "MCQ",
            //            AppUserAnswers = new List<AppUserQuestionAnswer>
            //            {
            //                new AppUserQuestionAnswer
            //                {
            //                    AppUser = _users[3],
            //                    Answer = answers[3]
            //                },
            //                new AppUserQuestionAnswer
            //                {
            //                    AppUser = _users[2],
            //                    Answer = answers[2]
            //                }
            //            },
            //            Answers = new List<QuestionAnswer>
            //            {
            //                new QuestionAnswer
            //                {
            //                    Answer = answers[4],
            //                    AnswerFk = answers[4].AnswerId
            //                },
            //                new QuestionAnswer
            //                {
            //                    Answer = answers[5],
            //                    AnswerFk = answers[5].AnswerId
            //                },
            //                new QuestionAnswer
            //                {
            //                    Answer = answers[6],
            //                    AnswerFk = answers[6].AnswerId
            //                },
            //                new QuestionAnswer
            //                {
            //                    Answer = answers[7],
            //                    AnswerFk = answers[7].AnswerId
            //                }
            //            }
            //        },
            //        new Question
            //        {
            //            DisplayValue = "TEST QUESTION",
            //            EffectiveStartDate = DateTime.Now ,
            //            EffectiveEndDate = EffectiveEndDate,
            //            CreateDate = DateTime.Now,
            //            UpdateDate = DateTime.Now,
            //            Type = "MCQ",
            //            AppUserAnswers = new List<AppUserQuestionAnswer>
            //            {
            //                new AppUserQuestionAnswer
            //                {
            //                    AppUser = _users[3],
            //                    Answer = answers[3]
            //                },
            //                new AppUserQuestionAnswer
            //                {
            //                    AppUser = _users[2],
            //                    Answer = answers[2]
            //                }
            //            },
            //            Answers = new List<QuestionAnswer>
            //            {
            //                new QuestionAnswer
            //                {
            //                    Answer = answers[4],
            //                    AnswerFk = answers[4].AnswerId
            //                },
            //                new QuestionAnswer
            //                {
            //                    Answer = answers[5],
            //                    AnswerFk = answers[5].AnswerId
            //                },
            //                new QuestionAnswer
            //                {
            //                    Answer = answers[6],
            //                    AnswerFk = answers[6].AnswerId
            //                },
            //                new QuestionAnswer
            //                {
            //                    Answer = answers[7],
            //                    AnswerFk = answers[7].AnswerId
            //                }
            //            }
            //        },
            //        new Question
            //        {
            //            DisplayValue = "TEST QUESTION 2",
            //            EffectiveStartDate = DateTime.Now ,
            //            EffectiveEndDate = EffectiveEndDate,
            //            CreateDate = DateTime.Now,
            //            UpdateDate = DateTime.Now,
            //            Type = "MCQ",
            //            AppUserAnswers = new List<AppUserQuestionAnswer>
            //            {
            //                new AppUserQuestionAnswer
            //                {
            //                    AppUser = _users[3],
            //                    Answer = answers[3]
            //                },
            //                new AppUserQuestionAnswer
            //                {
            //                    AppUser = _users[2],
            //                    Answer = answers[2]
            //                }
            //            },
            //            Answers = new List<QuestionAnswer>
            //            {
            //                new QuestionAnswer
            //                {
            //                    Answer = answers[4],
            //                    AnswerFk = answers[4].AnswerId
            //                },
            //                new QuestionAnswer
            //                {
            //                    Answer = answers[5],
            //                    AnswerFk = answers[5].AnswerId
            //                },
            //                new QuestionAnswer
            //                {
            //                    Answer = answers[6],
            //                    AnswerFk = answers[6].AnswerId
            //                },
            //                new QuestionAnswer
            //                {
            //                    Answer = answers[7],
            //                    AnswerFk = answers[7].AnswerId
            //                }
            //            }
            //        },
            //        new Question
            //        {
            //            DisplayValue = "TEST QUESTION 3",
            //            EffectiveStartDate = DateTime.Now ,
            //            EffectiveEndDate = EffectiveEndDate,
            //            CreateDate = DateTime.Now,
            //            UpdateDate = DateTime.Now,
            //            Type = "MCQ",
            //            AppUserAnswers = new List<AppUserQuestionAnswer>
            //            {
            //                new AppUserQuestionAnswer
            //                {
            //                    AppUser = _users[3],
            //                    Answer = answers[3]
            //                },
            //                new AppUserQuestionAnswer
            //                {
            //                    AppUser = _users[2],
            //                    Answer = answers[2]
            //                }
            //            },
            //            Answers = new List<QuestionAnswer>
            //            {
            //                new QuestionAnswer
            //                {
            //                    Answer = answers[4],
            //                    AnswerFk = answers[4].AnswerId
            //                },
            //                new QuestionAnswer
            //                {
            //                    Answer = answers[5],
            //                    AnswerFk = answers[5].AnswerId
            //                },
            //                new QuestionAnswer
            //                {
            //                    Answer = answers[6],
            //                    AnswerFk = answers[6].AnswerId
            //                },
            //                new QuestionAnswer
            //                {
            //                    Answer = answers[7],
            //                    AnswerFk = answers[7].AnswerId
            //                }
            //            }
            //        },
            //        new Question
            //        {
            //            DisplayValue = "TEST QUESTION 4",
            //            EffectiveStartDate = DateTime.Now ,
            //            EffectiveEndDate = EffectiveEndDate,
            //            CreateDate = DateTime.Now,
            //            UpdateDate = DateTime.Now,
            //            Type = "MCQ",
            //            AppUserAnswers = new List<AppUserQuestionAnswer>
            //            {
            //                new AppUserQuestionAnswer
            //                {
            //                    AppUser = _users[3],
            //                    Answer = answers[3]
            //                },
            //                new AppUserQuestionAnswer
            //                {
            //                    AppUser = _users[2],
            //                    Answer = answers[2]
            //                }
            //            },
            //            Answers = new List<QuestionAnswer>
            //            {
            //                new QuestionAnswer
            //                {
            //                    Answer = answers[4],
            //                    AnswerFk = answers[4].AnswerId
            //                },
            //                new QuestionAnswer
            //                {
            //                    Answer = answers[5],
            //                    AnswerFk = answers[5].AnswerId
            //                },
            //                new QuestionAnswer
            //                {
            //                    Answer = answers[6],
            //                    AnswerFk = answers[6].AnswerId
            //                },
            //                new QuestionAnswer
            //                {
            //                    Answer = answers[7],
            //                    AnswerFk = answers[7].AnswerId
            //                }
            //            }
            //        },
            //        new Question
            //        {
            //            DisplayValue = "Favourite Food",
            //            EffectiveStartDate = DateTime.Now,
            //            EffectiveEndDate = EffectiveEndDate,
            //            CreateDate = DateTime.Now,
            //            UpdateDate = DateTime.Now,
            //            Type = "OPEN",
            //        },
            //        new Question
            //        {
            //            DisplayValue = "Disliked Food",
            //            EffectiveStartDate = DateTime.Now,
            //            EffectiveEndDate = EffectiveEndDate,
            //            CreateDate = DateTime.Now,
            //            UpdateDate = DateTime.Now,
            //            Type = "OPEN",
            //        },
            //        new Question
            //        {
            //            DisplayValue = "Allergies",
            //            EffectiveStartDate = DateTime.Now,
            //            EffectiveEndDate = EffectiveEndDate,
            //            CreateDate = DateTime.Now,
            //            UpdateDate = DateTime.Now,
            //            Type = "OPEN",
            //        },
            //        new Question
            //        {
            //            DisplayValue = "Preferred Diet",
            //            EffectiveStartDate = DateTime.Now,
            //            EffectiveEndDate = EffectiveEndDate,
            //            CreateDate = DateTime.Now,
            //            UpdateDate = DateTime.Now,
            //            Type = "COMBO",
            //            Answers = new List<QuestionAnswer>
            //            {
            //                new QuestionAnswer
            //                {
            //                    Answer = answers[9],
            //                    AnswerFk = answers[9].AnswerId
            //                },
            //                new QuestionAnswer
            //                {
            //                    Answer = answers[10],
            //                    AnswerFk = answers[10].AnswerId
            //                },
            //                new QuestionAnswer
            //                {
            //                    Answer = answers[11],
            //                    AnswerFk = answers[11].AnswerId
            //                },
            //            }
            //        },
            //    };

            //    await context.Question.AddRangeAsync(questionnaires);
            //    await context.SaveChangesAsync();
            //}

            //var _answers = new List<Answer>
            //{

            //};

            //await context.Answer.AddRangeAsync(_answers);
            //await context.SaveChangesAsync();


            //var _questionnaires = new List<Question>
            //{


            //};

            //await context.Question.AddRangeAsync(_questionnaires);
            //await context.SaveChangesAsync();

            //if (!context.Occupation.Any())
            //{
            //    var _occupations = new List<Occupation>
            //    {
            //        new Occupation
            //        {
            //            DisplayValue = "software engineer",
            //            Description = "software engineer",
            //            EffectiveStartDate = DateTime.Now,
            //            EffectiveEndDate = EffectiveEndDate,
            //            CreateDate = DateTime.Now,
            //            UpdateDate = DateTime.Now,
            //            SortOrder = 1
            //        },
            //        new Occupation
            //        {
            //            DisplayValue = "sales associate",
            //            Description = "sales associate",
            //            EffectiveStartDate = DateTime.Now,
            //            EffectiveEndDate = EffectiveEndDate,
            //            CreateDate = DateTime.Now,
            //            UpdateDate = DateTime.Now,
            //            SortOrder = 2
            //        },
            //        new Occupation
            //        {
            //            DisplayValue = "nurse",
            //            Description = "nurse",
            //            EffectiveStartDate = DateTime.Now,
            //            EffectiveEndDate = EffectiveEndDate,
            //            CreateDate = DateTime.Now,
            //            UpdateDate = DateTime.Now,
            //            SortOrder = 3
            //        },
            //        new Occupation
            //        {
            //            DisplayValue = "teacher",
            //            Description = "teacher",
            //            EffectiveStartDate = DateTime.Now,
            //            EffectiveEndDate = EffectiveEndDate,
            //            CreateDate = DateTime.Now,
            //            UpdateDate = DateTime.Now,
            //            SortOrder = 4
            //        },

            //    };

            //    await context.Occupation.AddRangeAsync(_occupations);
            //    await context.SaveChangesAsync();
            //}

        }
    }
}
