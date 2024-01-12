# Cola.Core

[![Version](https://flat.badgen.net/nuget/v/Cola.SystemBuilder?label=version)](https://github.com/odinGitGmail/Cola.SystemBuilder) [![download](https://flat.badgen.net/nuget/dt/Cola.SystemBuilder)](https://www.nuget.org/packages/Cola.SystemBuilder) [![commit](https://flat.badgen.net/github/last-commit/odinGitGmail/Cola.SystemBuilder)](https://flat.badgen.net/github/last-commit/odinGitGmail/Cola.SystemBuilder) [![Blog](https://flat.badgen.net/static/blog/odinsam.com)](https://odinsam.com)

#### Cors跨域配置

```json
{
  "ColaCors": {
    "Cors": [
      {
        "CorsName": "LimitRequests",
        // 支持多个域名端口，注意端口号后不要带/斜杆：比如localhost:8000/，是错的。http://127.0.0.1:1818 和 http://localhost:1818 是不一样的，需要写两个
        "AllowOriginsIp": "http://127.0.0.1:2364,http://localhost:2364,http://localhost:8080,http://localhost:8021,http://localhost:1818",
        "AllowHeaders": ""
      }
    ]
  }
}
```

#### Cors 调用
```csharp
builder.Services.AddColaCors(config,"LimitRequests");
//  注意顺序
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors();
```

