using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenAI.NET.SDK.Extensions;
using OpenAI.NET.SDK.V1;

var jsonSerializerOptions = new JsonSerializerOptions
{
    WriteIndented = true
};

Console.WriteLine("Cledev OpenAI Example");

var builder = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddUserSecrets<Program>();

IConfiguration configuration = builder.Build();
var serviceCollection = new ServiceCollection();
serviceCollection.AddScoped(_ => configuration);

serviceCollection.AddOpenAIService();

var serviceProvider = serviceCollection.BuildServiceProvider();
var service = serviceProvider.GetRequiredService<IOpenAIService>();

//var response = await service.RetrieveModels();
//var response = await service.RetrieveModel("text-davinci-003");
var response = await service.CreateCompletion(CompletionsModel.Ada, "Say something nice");
//var response = await service.CreateCompletion("What is MOB programming?", OpenAIModels.TextDavinciV3, maxTokens: 100);
//var response = await service.CreateEdit(input: "What day of the wek is it?", instruction: "Fix the spelling mistakes");
//var response = await service.CreateImage(prompt: "A cute baby sea otter");

Console.WriteLine(response.IsSuccess
    ? $"{JsonSerializer.Serialize(response.Value, jsonSerializerOptions)}"
    : $"{JsonSerializer.Serialize(response.Failure, jsonSerializerOptions)}");

Console.ReadKey();
