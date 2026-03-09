using Microsoft.AspNetCore.Mvc.Rendering;

namespace Checktify.Entity.WebApplication.ViewModels.UserVM
{
    public class UserEditVM
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public Guid? CompanyId { get; set; }
        public Guid? WorkScheduleId { get; set; }
        public string SelectedRole { get; set; }
        public IEnumerable<SelectListItem> Roles { get; set; }
    }
}
