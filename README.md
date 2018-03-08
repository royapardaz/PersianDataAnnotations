## Persian DataAnnotations
با تشکر از https://github.com/amastaneh این کتابخانه از کتابخانه ایشان در تاریخ 1396/12/17 Fork شده و مقداری اصلاحات در آن انجام شده است.


## &#x202b; شیوه استفاده در ASP.NET Core MVC

  1- &#x202b; با استفاده از [نیوگت / NuGet](https://nuget.org/packages/PersianDataAnnotationsCore) به سادگی می توانید این کتابخانه را به پروژه خود اضافه کنید
  
```
  PM> Install-Package PersianDataAnnotationsCore
```
  2- &#x202b; فقط همین یک خط را اضافه کنید و کار تمام میشود

```c#
public void ConfigureServices(IServiceCollection services)
{
    services.AddMvc(options => options.ModelMetadataDetailsProviders.Add(new PersianDataAnnotationsCore.PersianValidationMetadataProvider()));
}
```
