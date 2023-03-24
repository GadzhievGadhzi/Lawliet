namespace Lawliet.Middleware {
    public class StatefulМiddleware {
        private readonly RequestDelegate _next;

        public StatefulМiddleware(RequestDelegate next) {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context) {
            var routeValues = context.Request.RouteValues;
            var controller = routeValues["controller"];
            var action = routeValues["action"];

            await _next.Invoke(context);
        }
    }
}