using System.ComponentModel.DataAnnotations;

namespace LibraryBookManagement.Models
{
    public class DateInPastAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime dateTime)
            {
                dateTime = DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
                return dateTime < DateTime.UtcNow;
            }
            return false;
        }
    }
}
