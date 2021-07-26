@ECHO OFF
REM @echo suppresses command line. 
REM ^ is line continuation character

REM for .NET core projects Nuget packages are installed in %UserProfile%\.nuget\packages
REM The %UserProfile% variable is a special system-wide environment variable 
REM It contains %SystemDrive%\Users\{username}

SET PackagesFolder=%UserProfile%\.nuget\packages
SET OpenCoverVersion=4.7.1221
SET ReportGeneratorVersion=4.8.12

REM Some of the APIs used by OpenCover to profile the app are missing in .net Core.  
REM    -oldstyle switch fixes this issue
REM "-filter" to selectively include or exclude assemblies and classes from coverage results.
REM DTOs, auto generated designer files, diagrams files, 
REM          unit test classes are excluded from coverage report
REM Default filters are: -[mscorlib]* -[mscorlib.*]* -[System]* -[System.*]* -[Microsoft.VisualBasic]* 
@ECHO ON
%PackagesFolder%\opencover\%OpenCoverVersion%\tools\OpenCover.Console.exe ^
    -target:"C:/Program Files/dotnet/dotnet.exe" ^
    -targetargs:"test C:\Users\vrmpr\OneDrive\Documentos\Projetos\Volvo\VolvoLab.Caminhoes\VolvoLab.Caminhoes.Application.Test\bin\Debug\net5.0\VolvoLab.Caminhoes.Tests.dll --configuration Debug --no-build" ^
    -filter:"+[VolvoLab.Caminhoes*]* -[VolvoLab.Caminhoes.Tests]* -[VolvoLab.Caminhoes.Infra.Data]* " ^
    -filter:-excludebyfile:*\*Designer.cs -mergebyhash ^
    -oldStyle ^
    -register:user ^
    -output:"OpenCoverReport.xml"
@ECHO OFF

REM delete old coverage files
REM /F /Q switches to delete files and directories even with readonly attribute without confirmation
DEL /F /Q .\coverage\*.*

REM Generate HTML based coverage reports
@ECHO ON
%PackagesFolder%\ReportGenerator\%ReportGeneratorVersion%\tools\net5.0\reportgenerator.exe ^
 -reports:OpenCoverReport.xml -targetdir:coverage Verbosity: Error

REM invoke the html coverage summary in the browser
START "" ".\coverage\index.htm"