using System.Runtime.CompilerServices;
using System.Text.Json;
using Cledev.OpenAI.Extensions;
using Cledev.OpenAI.V1;
using Cledev.OpenAI.V1.Contracts.Audio;
using Cledev.OpenAI.V1.Contracts.Chats;
using Cledev.OpenAI.V1.Contracts.Completions;
using Cledev.OpenAI.V1.Contracts.Moderations;
using Cledev.OpenAI.V1.Enums;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static System.Net.Mime.MediaTypeNames;

var jsonSerializerOptions = new JsonSerializerOptions
{
    WriteIndented = true
};

Console.WriteLine("OpenAI.NET Example");

var builder = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddUserSecrets<Program>();

IConfiguration configuration = builder.Build();
var serviceCollection = new ServiceCollection();
serviceCollection.AddScoped(_ => configuration);

serviceCollection.AddOpenAIClient();

var serviceProvider = serviceCollection.BuildServiceProvider();
var client = serviceProvider.GetRequiredService<IOpenAIClient>();

//Models
//var response = await client.ListModels();
//var response = await client.RetrieveModel("text-davinci-003");

//Completions
//var response = await client.CreateCompletion(CompletionsModel.Ada, "Say something nice");
//var response = await client.CreateCompletion("What is MOB programming?", OpenAIModels.TextDavinciV3, maxTokens: 100);

//Edits
//var response = await client.CreateEdit(input: "What day of the wek is it?", instruction: "Fix the spelling mistakes");

//Images
//var response = await client.CreateImage(prompt: "A cute baby sea otter");

//Embeddings
//var response = await client.CreateEmbeddings(new CreateEmbeddingsRequest
//{
//    Model = EmbeddingsModel.TextEmbeddingAdaV2.ToStringModel(),
//    Input = "The food was delicious and the waiter..."
//});

//Files
//var file = await File.ReadAllBytesAsync("Data/fine-tune-1.jsonl");
//var uploadedFile = await client.UploadFile(file, "fine-tune-1.jsonl", "fine-tune");
//var response = await client.RetrieveFile(uploadedFile!.Id);

//Fine Tunes
//var response = await client.ListFineTunes();

//Moderations
//var response = await client.CreateModeration(new CreateModerationRequest
//{
//    Input = "I want to kill them"
//});

//Console.WriteLine($"{JsonSerializer.Serialize(response, jsonSerializerOptions)}");

//await TestCreateCompletionAsStream();
//await TestCreateChatCompletionAsStream();
await TestCreateAudioTranscription();

Console.ReadKey();

async Task TestCreateCompletionAsStream()
{
    var request = new CreateCompletionRequest
    {
        Model = CompletionsModel.TextDavinciV3.ToStringModel(),
        Stream = true,
        Prompt = "Please write a 1000 word assay about differences between functional programming and object oriented programming",
        MaxTokens = 500
    };

    var completions = client.CreateCompletionAsStream(request);

    await foreach (var completion in completions)
    {
        Console.Write(completion.Choices[0].Text);
    }
}

async Task TestCreateChatCompletionAsStream()
{
    var request = new CreateChatCompletionRequest
    {
        Model = ChatModel.Gpt35Turbo.ToStringModel(),
        Stream = true,
        MaxTokens = 500,
        Messages = new List<ChatCompletionMessage>
        {
            new("system", "You are a helpful assistant."),
            new("user", "Who won the world series in 2020?"),
            new("assistant", "The Los Angeles Dodgers won the World Series in 2020."),
            new("user", "Where was it played?")
        }
    };

    var completions = client.CreateChatCompletionAsStream(request);

    await foreach (var completion in completions)
    {
        Console.Write(completion.Choices[0].Message?.Content);
    }
}

async Task TestCreateAudioTranscription()
{
    const string fileName = "YOUR_RECORDING.m4a";
    var fileBytes = await File.ReadAllBytesAsync($"Data/{fileName}");

    var request = new CreateAudioTranscriptionRequest
    {
        Model = AudioModel.Whisper1.ToStringModel(),
        File = fileBytes,
        FileName = fileName
    };

    var response = await client.CreateAudioTranscription(request);

    Console.Write(response?.Text);
}
