using System.Collections.Concurrent;
using System.Net;

namespace Ecommerce__Project.Api.MiddleWare
{
    public class RateLimitingMiddleware
    {
        private static readonly ConcurrentDictionary<string, TokenBucket> _buckets = new();
        private readonly RequestDelegate _next;
        private readonly ILogger<RateLimitingMiddleware> _logger;
        private readonly int _maxRequests;
        private readonly int _timeWindowInSeconds;

        public RateLimitingMiddleware(
            RequestDelegate next,
            ILogger<RateLimitingMiddleware> logger,
            IConfiguration configuration)
        {
            _next = next;
            _logger = logger;
            _maxRequests = configuration.GetValue<int>("RateLimiting:MaxRequests", 100);
            _timeWindowInSeconds = configuration.GetValue<int>("RateLimiting:TimeWindowInSeconds", 60);
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var ipAddress = context.Connection.RemoteIpAddress?.ToString() ?? "unknown";
            var bucket = _buckets.GetOrAdd(ipAddress, _ => new TokenBucket(_maxRequests, _timeWindowInSeconds));

            if (!bucket.TryConsume())
            {
                _logger.LogWarning("Rate limit exceeded for IP: {IP}", ipAddress);
                context.Response.StatusCode = (int)HttpStatusCode.TooManyRequests;
                context.Response.Headers.Add("Retry-After", _timeWindowInSeconds.ToString());
                await context.Response.WriteAsJsonAsync(new
                {
                    error = "Too many requests",
                    message = $"Rate limit exceeded. Try again in {_timeWindowInSeconds} seconds."
                });
                return;
            }

            await _next(context);
        }
    }

    public class TokenBucket
    {
        private readonly int _capacity;
        private readonly double _refillRate;
        private double _tokens;
        private DateTime _lastRefill;

        public TokenBucket(int capacity, int timeWindowInSeconds)
        {
            _capacity = capacity;
            _refillRate = (double)capacity / timeWindowInSeconds;
            _tokens = capacity;
            _lastRefill = DateTime.UtcNow;
        }

        public bool TryConsume()
        {
            RefillTokens();
            if (_tokens >= 1)
            {
                _tokens -= 1;
                return true;
            }
            return false;
        }

        private void RefillTokens()
        {
            var now = DateTime.UtcNow;
            var timePassed = (now - _lastRefill).TotalSeconds;
            var tokensToAdd = timePassed * _refillRate;
            _tokens = Math.Min(_capacity, _tokens + tokensToAdd);
            _lastRefill = now;
        }
    }
}