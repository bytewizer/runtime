using System;

using Bytewizer.TinyCLR.Pipeline.Builder;

namespace Bytewizer.Playground.Pipeline
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware1(this IApplicationBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            // Properties use to set values used by other middleware
            builder.SetProperty("key1", "Property Value1");

            return builder.Use(typeof(Middleware1), new MiddlewareOptions());
        }

        public static IApplicationBuilder UseMiddleware1(this IApplicationBuilder builder, MiddlewareOptions options)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            // Properties use to set values used by other middleware
            builder.SetProperty("key1", "Property Value1");

            return builder.Use(typeof(Middleware1), options);
        }

        public static IApplicationBuilder UseMiddleware2(this IApplicationBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            // Properties use to set values used by other middleware
            builder.SetProperty("key2", "Property Value2");

            return builder.Use(typeof(Middleware2));
        }

        public static IApplicationBuilder UseMiddleware2(this IApplicationBuilder builder, MiddlewareOptions options)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            // Properties use to set values used by other middleware
            builder.SetProperty("key2", "Property Value2");

            return builder.Use(typeof(Middleware2), options);
        }

        public static IApplicationBuilder UseMiddleware3(this IApplicationBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            // Properties use to set values used by other middleware
            builder.SetProperty("key3", "Property Value3");

            return builder.Use(typeof(Middleware3));
        }

        public static IApplicationBuilder UseMiddleware3(this IApplicationBuilder builder, MiddlewareOptions options)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            // Properties use to set values used by other middleware
            builder.SetProperty("key3", "Property Value3");

            return builder.Use(typeof(Middleware3), options);
        }
    }
}
