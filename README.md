# Cledev.OpenAI _(Beta)_
.NET 7 SDK for OpenAI with a [Blazor Server Playground](https://github.com/lucabriguglia/Cledev.OpenAI.Playground)

[![Main](https://github.com/lucabriguglia/Cledev.OpenAI/actions/workflows/main.yml/badge.svg)](https://github.com/lucabriguglia/Cledev.OpenAI/actions/workflows/main.yml)
[![Nuget Package](https://img.shields.io/badge/nuget-1.0.0-blue.svg)](https://www.nuget.org/packages/Cledev.OpenAI)

```
Install-Package Cledev.OpenAI
```

## APIs

- **Models**
  - List Models
  - Retrieve Model
- **Completions**
  - Create Completion
- **Edits**
  - Create Edit
- **ChatGPT**
  - Create Chat Completion
- **Images**
  - Create Image
  - Create Image Edit
  - Create Image Variation
- **Embeddings**
  - Create Embeddings
- **Files**
  - List Files
  - Upload File
  - Delete File
  - Retrieve File
- **Fine-tunes**
  - Create Fine-tune
  - List Fine-tunes
  - Retrieve Fine-tune
  - Cancel Fine-tune
  - List Fine-tune Events
  - Delete Fine-tune Model
- **Moderations**
  - Create Moderation
- **Whisper**
  - _(coming soon)_

## Configuration

### Option 1

```C#
services.AddOpenAIClient();
```

This option requires an appsettings.json file

```json
{
  "OpenAI": {
    "ApiKey": "YOUR_API_KEY",
    "Organization": "OUR_ORGANIZATION"
  }
}
```

### Option 2

```C#
services.AddOpenAIClient(options =>
{
     options.ApiKey = "YOUR_API_KEY";
     options.Organization = "YOUR_ORGANIZATION";
 });
```

## Usage

Inject `IOpenAIClient` interface into your service

_(complete guide available soon)_
