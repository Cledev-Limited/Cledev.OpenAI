﻿using Cledev.OpenAI.V1.Contracts.Files;

namespace Cledev.OpenAI.V1.Extensions;

internal static class UploadFileRequestExtensions
{
    internal static MultipartFormDataContent ToMultipartFormDataContent(this UploadFileRequest request)
    {
        return new MultipartFormDataContent
        {
            { new ByteArrayContent(request.File), "file", request.FileName },
            { new StringContent(request.Purpose), "purpose" }
        };
    }
}
