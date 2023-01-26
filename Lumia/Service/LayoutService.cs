using Lumia.Data;
using Lumia.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Lumia.Service
{
    public class LayoutService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;
        private readonly DataContext _dataContext;

        public LayoutService(IHttpContextAccessor httpContextAccessor,UserManager<AppUser> userManager,DataContext dataContext)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _dataContext = dataContext;
        }
        public async Task<AppUser> GetUser()
        {
           
            AppUser appUser = null;

            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                appUser = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity.Name);

                return appUser;
            }


            return null;
        }

        public async Task<List<Setting>> GetSetting()
        {
            return await _dataContext.Settings.ToListAsync();
        }
    }
}
