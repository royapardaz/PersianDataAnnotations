## Persian DataAnnotations
با تشکر از [@amastaneh] (https://github.com/amastaneh) این کتابخانه از کتابخانه ایشان در تاریخ 1396/12/17 Fork شده و مقداری اصلاحات در آن انجام شده است.


## &#x202b; شیوه استفاده در ASP.NET Core MVC

```c#
public void ConfigureServices(IServiceCollection services)
{
    services.AddMvc(options => options.ModelMetadataDetailsProviders.Add(new NetCorePersianAnnotations.PersianValidationMetadataProvider()));
}
```
