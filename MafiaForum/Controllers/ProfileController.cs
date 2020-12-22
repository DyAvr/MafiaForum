using System.Linq;
using System.Threading.Tasks;
using MafiaForum.Models;
using MafiaForum.Models.Interfaces;
using MafiaForum.ViewModels.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;

namespace MafiaForum.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<User> _userManager; //Provided by Microsoft.AspNetCore.Identity
        private readonly IUser _userService;
        private readonly IUpload _uploadService; //To upload profile image to the cloud
        private readonly IConfiguration _configuration;

        public ProfileController(UserManager<User> userManager, IUser userService, IUpload uploadService, IConfiguration configuration)
        {
            this._userManager = userManager;
            this._userService = userService;
            this._uploadService = uploadService;
            _configuration = configuration;
        }

        public IActionResult Detail(string id)
        {
            var user = _userService.GetById(id);
            var userRoles = _userManager.GetRolesAsync(user).Result;    

            var model = new ProfileViewModel
            {
                UserId = user.Id,
                UserName = user.UserName,
                Nickname = user.Nickname,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                UserRating = user.Rating.ToString(),
                Email = user.Email,
                ProfileImageUrl = user.ProfileImageUrl,
                MemeberSince = user.MemberSince,
                IsAdmin = userRoles.Contains("admin")
            };

            return View(model);
        }

        // public IActionResult Index()
        // {
        //     var profiles = _userService.GetAll()
        //         .OrderByDescending(user => user.Rating)
        //         .Select(u => new ProfileViewModel
        //         {
        //             Nickname = u.Nickname,
        //             ProfileImageUrl = u.ProfileImageUrl,
        //             UserRating = u.Rating.ToString(),
        //             MemeberSince = u.MemberSince,
        //         });
        //
        //     var model = new ProfileListViewModel
        //     {
        //         Profiles = profiles
        //     };
        //
        //     return View(model);
        // }

        [HttpPost]
        public async Task<IActionResult> UploadProfileImage(IFormFile file)
        {
            var userId = _userManager.GetUserId(User);

            //Connect to Azure Storage Container
            var connectionString = _configuration.GetConnectionString("AzureStorageAccount");
            //Get Blob Container
            var container = _uploadService.GetBlobContainer(connectionString, "profile-images");

            //Parse the Content Disposition response header
            var contentDisposition = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
            //Grab the filename
            var filename = contentDisposition.FileName.Trim('"');

            //Get a reference to a Block Blob
            var blockBlob = container.GetBlockBlobReference(filename);
            //On that block blob, upload our file
            await blockBlob.UploadFromStreamAsync(file.OpenReadStream());

            //Set the user's profile image to the received URI
            await _userService.SetProfileImage(userId,blockBlob.Uri);
            //Redirect to user's profile page

            return RedirectToAction("Detail","Profile", new {id = userId});
        }
    }
}