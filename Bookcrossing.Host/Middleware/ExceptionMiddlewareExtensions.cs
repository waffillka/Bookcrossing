﻿using Bookcrossing.Application.Logger;
using Bookcrossing.Contracts.Exceptions.ModelExceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Bookcrossing.Host.Middleware
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILoggerManager logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (contextFeature != null)
                    {
                        logger.LogError($"Something went wrong: {contextFeature.Error}");

                        switch (contextFeature.Error)
                        {

                            default:
                                {
                                    await context.Response.WriteAsync(new ErrorDetails()
                                    {
                                        StatusCode = context.Response.StatusCode,
                                        Message = "Internal Server Error."
                                    }.ToString());
                                    break;
                                }
                        }
                    }
                });
            });
        }
    }
}
