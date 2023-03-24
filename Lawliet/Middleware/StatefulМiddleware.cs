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

            /*if (!context.Request.Cookies.ContainsKey("currentPage")) {
                context.Response.Cookies.Append("currentPage", $"{controller}/{action}");
            } else {
                context.Response.Cookies.Append("previousPage", context.Request.Cookies["currentPage"]);
                context.Response.Cookies.Delete("currentPage");
            }*/

            await _next.Invoke(context);
        }
    }
}