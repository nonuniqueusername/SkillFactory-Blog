using AutoMapper;
using Microsoft.EntityFrameworkCore;
using BlogApp.BLL.Services.IServices;
using BlogApp.BLL.Services;
using BlogApp.DAL.Models;
using BlogApp.DAL.Repositories.IRepositories;
using BlogApp.DAL.Repositories;
using BlogApp.DAL;
using NLog.Web;
using NLog;

namespace BlogApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
            logger.Debug("init main");
            try
            {
                var builder = WebApplication.CreateBuilder(args);

                string connection = builder.Configuration.GetConnectionString("DefaultConnection");
                builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(connection))
                    .AddIdentity<User, Role>(opts =>
                    {
                        opts.Password.RequiredLength = 5;
                        opts.Password.RequireNonAlphanumeric = false;
                        opts.Password.RequireLowercase = false;
                        opts.Password.RequireUppercase = false;
                        opts.Password.RequireDigit = false;
                        opts.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+�������������������������������������Ũ��������������������������";
                        opts.User.RequireUniqueEmail = true;
                    })
                    .AddEntityFrameworkStores<AppDbContext>();

                var mapperConfig = new MapperConfiguration((v) =>
                {
                    v.AddProfile(new MappingProfile());
                });

                IMapper mapper = mapperConfig.CreateMapper();

                // ����������� �������� ����������� ��� �������������� � ����� ������
                builder.Services.AddSingleton(mapper)
                    .AddTransient<ICommentRepository, CommentRepository>()
                    .AddTransient<IPostRepository, PostRepository>()
                    .AddTransient<ITagRepository, TagRepository>()
                    .AddTransient<IUserService, UserService>()
                    .AddTransient<ICommentService, CommentService>()
                    .AddTransient<IHomeService, HomeService>()
                    .AddTransient<IPostService, PostService>()
                    .AddTransient<IRoleService, RoleService>()
                    .AddTransient<ITagService, TagService>()
                    .AddControllersWithViews();

                builder.Logging.ClearProviders();
                builder.Host.UseNLog();


                var app = builder.Build();

                // Configure the HTTP request pipeline.
                if (!app.Environment.IsDevelopment())
                {
                    app.UseExceptionHandler("/Home/Error");
                    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                    app.UseHsts();
                }

                app.UseHttpsRedirection();
                app.UseStaticFiles();
                app.UseRouting();
                app.UseAuthentication();
                app.UseAuthorization();
                app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}");

                app.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                app.Run();
            }
            catch(Exception exception)
            {
				logger.Error(exception, "Stopped program because of exception");
				throw;
			}
            finally
            {
				NLog.LogManager.Shutdown();
			}
        }
    }
}