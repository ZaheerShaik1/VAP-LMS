//namespace LirarayManagementSystemP
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            var builder = WebApplication.CreateBuilder(args);

//            builder.Services.AddRazorPages();

//            builder.Services.AddSession();

//            var app = builder.Build();

//            if (!app.Environment.IsDevelopment())
//            {
//                app.UseExceptionHandler("/Error");
//                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//                app.UseHsts();
//            }

//            app.UseHttpsRedirection();
//            app.UseStaticFiles();

//            app.UseRouting();

//            app.UseAuthorization();

//            app.UseSession();

//            app.MapRazorPages();
//            //app.MapGet("/", async ui_context =>
//            //{
//            //    ui_context.Response.Redirect("/Login");
//            //});


//            app.Run();
//        }
//    }
//}

namespace LirarayManagementSystemP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddSession();

            // Configure authentication
            builder.Services.AddAuthentication("YourCookieScheme")
                .AddCookie("YourCookieScheme", options =>
                {
                    options.LoginPath = "/Login"; // Adjust based on your login page
                    options.LogoutPath = "/Logout"; // Adjust based on your logout action
                });

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication(); // Ensure this is before UseAuthorization
            app.UseAuthorization();
            app.UseSession();

            app.MapRazorPages();

            app.Run();
        }
    }
}
