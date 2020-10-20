Tekla Structures API POC (proof of concept) projects.


* https://developer.tekla.com/tekla-structures/api/10
* https://www.techpowerup.com/download/visual-c-redistributable-runtime-package-all-in-one/
* http://razorcx.com/
    * https://github.com/razorcx
    * https://www.youtube.com/c/RazorCXTechnologies/videos
* WPF
    * https://developer.tekla.com/tekla-structures/documentation/tekla-open-api-ui-design-wpf
    * WinForm vs WPF vs UWP vs Console - The C# Desktop UI Showdown (and the future with .NET 5) https://www.youtube.com/watch?v=yq0dSkA1vpM
* https://teklastructures.support.tekla.com/2020/en/cus_create_startup_shortcuts_with_customized_initializations

```batch
rem Note that both XS_DEFAULT_ENVIRONMENT and XS_DEFAULT_ROLE must be set for bypass to work.

set XS_DEFAULT_ENVIRONMENT=%XSDATADIR%\environments\russia\env_Russia.ini
rem set XS_DEFAULT_ROLE=%XSDATADIR%\environments\russia\role_Все.ini

rem set XS_DEFAULT_ROLE=%XSDATADIR%\environments\russia\role_КЖ.ini
rem set XS_DEFAULT_ROLE=%XSDATADIR%\environments\russia\role_КЖ_и_КМ.ini
rem set XS_DEFAULT_ROLE=%XSDATADIR%\environments\russia\role_КЖИ.ini
rem set XS_DEFAULT_ROLE=%XSDATADIR%\environments\russia\role_КМ.ini
rem set XS_DEFAULT_ROLE=%XSDATADIR%\environments\russia\role_КМД.ini

set XS_DEFAULT_LICENSE=FULL
```

```batch
"C:\Program Files\Tekla Structures\2020.0\nt\bin\TeklaStructures.exe" -I Desktop\custom_env.ini /create:"C:\dummy"
```