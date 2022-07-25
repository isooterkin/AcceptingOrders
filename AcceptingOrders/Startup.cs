using Microsoft.AspNetCore.Localization;

namespace AcceptingOrders
{
    public class Startup
    {
        public void Configure(IApplicationBuilder applicationBuilder, IWebHostEnvironment webHostEnvironment)
        {
            if (webHostEnvironment.IsDevelopment())
                applicationBuilder.UseDeveloperExceptionPage();
            else
            {
                applicationBuilder.UseExceptionHandler("/Error");
                applicationBuilder.UseHsts();
            }

            applicationBuilder.UseHttpsRedirection();

            applicationBuilder.UseRequestLocalization(options => options
                .AddSupportedCultures(new string[] { "en-GB", "en-US" })
                .AddSupportedUICultures(new string[] { "en-GB", "en-US" })
                .SetDefaultCulture("en-GB")
                .RequestCultureProviders
                .Insert(0, new CustomRequestCultureProvider(context => Task.FromResult(new ProviderCultureResult("en-GB"))!)));

            applicationBuilder.UseStaticFiles();

            applicationBuilder.UseRouting();

            applicationBuilder.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action}/{id?}",
                    defaults: new
                    {
                        controller = "OrderModels",
                        action = "Index"
                    });
            });
        }
    }
}