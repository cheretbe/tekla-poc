Tekla Structures API POC (proof of concept) projects.

* **https://github.com/dawiddyrcz/Awesome-tekla-open-api**
* https://developer.tekla.com/tekla-structures/api/10
* https://www.techpowerup.com/download/visual-c-redistributable-runtime-package-all-in-one/
* http://razorcx.com/
    * https://github.com/razorcx
    * https://www.youtube.com/c/RazorCXTechnologies/videos
* https://mainpart.eu/#/app-dev
    * https://www.youtube.com/user/40ushek/videos
    * https://www.youtube.com/watch?v=S-d0TBqMqVM Tekla Open API Tutorial. Creating macro fitting a beam by face
* WPF
    * https://developer.tekla.com/tekla-structures/documentation/tekla-open-api-ui-design-wpf
    * WinForm vs WPF vs UWP vs Console - The C# Desktop UI Showdown (and the future with .NET 5) https://www.youtube.com/watch?v=yq0dSkA1vpM
* Initialization (.ini) files
    * https://teklastructures.support.tekla.com/2020/en/cus_create_startup_shortcuts_with_customized_initializations
    * https://teklastructures.support.tekla.com/2020/en/xs_default_license
    * https://teklastructures.support.tekla.com/2020/en/XS_DEFAULT_ROLE
    * https://teklastructures.support.tekla.com/2020/en/xs_default_environment
* API
    * `ModelHandler.CreateNewSingleUserModel` Method: https://developer.tekla.com/api/10/guid/4a87383d-506b-847e-0259-27e1e9b1dfb0
* Build
    * https://github.com/microsoft/vswhere
* VS settings
    * https://visualstudioextensions.vlasovstudio.com/2017/06/29/changing-visual-studio-2017-private-registry-settings/
    * https://github.com/dotnet/project-system/blob/master/docs/repo/content/DesignTimeBuildOutputPane.cmd


`c:\Users\vagrant\Documents\tekla_custom_settings.ini`:
```batch
rem Note that both XS_DEFAULT_ENVIRONMENT and XS_DEFAULT_LICENSE must be set for bypass to work
set XS_DEFAULT_LICENSE=FULL
set XS_DEFAULT_ENVIRONMENT=%XSDATADIR%\Environments\blank_project\env_blank_project.ini
```

```batch
::  /create:"C:\TeklaStructuresModels\empty_model"
"C:\Program Files\Tekla Structures\2020.0\nt\bin\TeklaStructures.exe" -I c:\Users\vagrant\Documents\tekla_custom_settings.ini

"C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin\MSBuild.exe" console-test-1\console-test-1.sln /target:console-test-1 /p:Configuration=Release
```
