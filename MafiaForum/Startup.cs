using MafiaForum.Models;
using MafiaForum.Models.Interfaces;
using MafiaForum.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace MafiaForum
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole>(opts => {
                    opts.Password.RequiredLength = 5;   // ����������� �����
                    opts.Password.RequireNonAlphanumeric = false;   // ��������� �� �� ���������-�������� �������
                    opts.Password.RequireLowercase = false; // ��������� �� ������� � ������ ��������
                    opts.Password.RequireUppercase = false; // ��������� �� ������� � ������� ��������
                    opts.Password.RequireDigit = false; // ��������� �� �����

                    opts.User.RequireUniqueEmail = true;    // ���������� email
                    opts.User.AllowedUserNameCharacters = ".@abcdefghijklmnopqrstuvwxyz0123456789"; // ���������� �������
            })
                .AddEntityFrameworkStores<ApplicationContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IForum, ForumService>();
            services.AddScoped<IPost, PostService>();
            services.AddScoped<IUser, UserService>();
            services.AddScoped<IUpload, UploadService>();
            services.AddSingleton(Configuration);

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();    // ����������� ��������������
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}