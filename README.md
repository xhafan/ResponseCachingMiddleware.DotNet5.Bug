# ResponseCachingMiddleware.DotNet5.Bug

Run the solution, it should run both ResponseCachingMiddleware.DotNet5.Bug Web API server and RequestsGeneratorApp console app which will start sending requests to the Web API server. After couple of requests sent to the Web API server, kill the console app via CTRL+C, and it will usually make the Web API server throw this exception:

```
System.ArgumentOutOfRangeException: Cannot allocate more than 4096 bytes in a single buffer (Parameter 'size')
 at System.Buffers.MemoryPoolThrowHelper.ThrowArgumentOutOfRangeException_BufferRequestTooLarge(Int32 maxSize)
 at System.Buffers.SlabMemoryPool.Rent(Int32 size)
 at Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.Http1OutputProducer.GetSpan(Int32 sizeHint)
 at Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpProtocol.GetSpan(Int32 sizeHint)
 at Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpResponsePipeWriter.GetSpan(Int32 sizeHint)
 at Microsoft.AspNetCore.ResponseCaching.CachedResponseBody.CopyToAsync(PipeWriter destination, CancellationToken cancellationToken)
 at Microsoft.AspNetCore.ResponseCaching.ResponseCachingMiddleware.TryServeCachedResponseAsync(ResponseCachingContext context, IResponseCacheEntry cacheEntry)
 at Microsoft.AspNetCore.ResponseCaching.ResponseCachingMiddleware.TryServeFromCacheAsync(ResponseCachingContext context)
 at Microsoft.AspNetCore.ResponseCaching.ResponseCachingMiddleware.Invoke(HttpContext httpContext)
 at ResponseCachingMiddleware.DotNet5.Bug.RequestLoggingMiddleware.Invoke(HttpContext httpContext) in d:\projects\ResponseCachingMiddleware.DotNet5.Bug\ResponseCachingMiddleware.DotNet5.Bug\RequestLoggingMiddleware.cs:line 22
 at Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpProtocol.ProcessRequests[TContext](IHttpApplication`1 application)
```

Video demonstrating the usage and the bug: https://www.youtube.com/watch?v=ZjceMXzSQNU