using Plugin.LocalNotification;
using MobileApp_AcademicTerms.Models;

namespace MobileApp_AcademicTerms.Services
{
    public class NotificationService
    {
        private readonly INotificationService _notificationService;

        public NotificationService(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task ScheduleNotification(string title, string message, DateTime scheduleDate)
        {
            if (scheduleDate <= DateTime.Now)
                return;

            try
            {
                // Create the notification
                var notification = new NotificationRequest
                {
                    NotificationId = Random.Shared.Next(),
                    Title = title,
                    Description = message,
                    Schedule = new NotificationRequestSchedule
                    {
                        NotifyTime = scheduleDate
                    }
                };

                // Show the notification
                await _notificationService.Show(notification);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Notification Error: {ex.Message}");
            }
        }

        public async Task ScheduleCourseNotifications(Course course)
        {
            if (!course.NotificationsEnabled)
                return;

            await ScheduleNotification(
                "Course Starting",
                $"The course '{course.Title}' starts today!",
                course.StartDate);

            await ScheduleNotification(
                "Course Ending",
                $"The course '{course.Title}' ends today!",
                course.EndDate);
        }

        public async Task ScheduleAssessmentNotifications(Assessment assessment)
        {
            if (!assessment.NotificationsEnabled)
                return;

            await ScheduleNotification(
                "Assessment Starting",
                $"The assessment '{assessment.Title}' starts today!",
                assessment.StartDate);

            await ScheduleNotification(
                "Assessment Ending",
                $"The assessment '{assessment.Title}' ends today!",
                assessment.EndDate);
        }
    }
}