using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using OpenAI.NET.Playground.Web;
using OpenAI.NET.SDK;
using OpenAI.NET.SDK.Extensions;
using OpenAI.NET.SDK.V1;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://api.openai.com/") });

builder.Services.AddOptions<OpenAISettings>().Configure(options =>
{
    options.ApiKey = builder.Configuration["OpenAI:ApiKey"];
    options.Organization = builder.Configuration["OpenAI:Organization"];
});
builder.Services.AddHttpClient<IOpenAIService, OpenAIService>();

//builder.Services.AddOpenAIService(options =>
//{
//    options.ApiKey = builder.Configuration["OpenAI:ApiKey"];
//    options.ApiKey = builder.Configuration["OpenAI:Organization"];
//});

await builder.Build().RunAsync();
