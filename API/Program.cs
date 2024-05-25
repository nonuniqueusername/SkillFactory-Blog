

using BlogApp.DAL.Models;
using BlogApp.DAL;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using BlogApp.BLL.Services.IServices;
using BlogApp.BLL.Services;
using BlogApp.DAL.Repositories.IRepositories;
using BlogApp.DAL.Repositories;
using BlogApp;

namespace API
{
	public class Program
	{
		public static void Main(string[] args)
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
					opts.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
					opts.User.RequireUniqueEmail = true;
				})
				.AddEntityFrameworkStores<AppDbContext>();
			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var mapperConfig = new MapperConfiguration((v) =>
			{
				v.AddProfile(new MappingProfile());
			});

			IMapper mapper = mapperConfig.CreateMapper();

			// регистрация сервисов репозитория для взаимодействия с базой данных
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

			builder.Services.AddAuthentication(optionts => optionts.DefaultScheme = "Cookies")
				.AddCookie("Cookies", options =>
				{
					options.Events = new Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents
					{
						OnRedirectToLogin = redirectContext =>
						{
							redirectContext.HttpContext.Response.StatusCode = 401;
							return Task.CompletedTask;
						}
					};
				});

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();
			app.UseAuthentication();


			app.MapControllers();

			app.Run();
		}
	}
}
