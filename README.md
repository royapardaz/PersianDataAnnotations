## Persian DataAnnotations
## <div dir="rtl">
با تشکر از [@amastaneh] (https://github.com/amastaneh) این کتابخانه از کتابخانه ایشان در تاریخ 1396/12/17 Fork شده و مقداری اصلاحات در آن انجام شده است.
</div>
## <div dir="rtl">
## &#x202b; شیوه استفاده در ASP.NET Core MVC
</div>
```c#
public void ConfigureServices(IServiceCollection services)
{
    services.AddMvc(options => options.ModelMetadataDetailsProviders.Add(new NetCorePersianAnnotations.PersianValidationMetadataProvider()));
}
```
