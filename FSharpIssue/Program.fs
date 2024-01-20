open System
open System.Threading.Tasks
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.Hosting
open Microsoft.AspNetCore.Http
open System.Text

[<EntryPoint>]
let main args =
    let builder = WebApplication.CreateBuilder(args)
    let app = builder.Build()
    app.UseStaticFiles() |> ignore
    app.MapGet("/", Func<HttpContext, Task>(fun (context) -> 
        context.Response.ContentType <- "text/html; charset=utf-8"
        let html = "<link href='/css/site.css' rel='stylesheet' />Hello World! <div class='spinner-border' role='status'><span class='visually-hidden'>Загрузка...</span></div>"
        context.Response.ContentLength <- Encoding.UTF8.GetByteCount(html)
        context.Response.WriteAsync html)) |> ignore

    app.Run()

    0 // Exit code

