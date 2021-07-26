REM Create a 'GeneratedReports' folder if it does not exist
if not exist "%~dp0GeneratedReports" mkdir "%~dp0GeneratedReports"

REM Remove any previously created test output directories
CD %~dp0
FOR /D /R %%X IN (%USERNAME%*) DO RD /S /Q "%%X"

REM Run the tests against the targeted output
call :RunOpenCoverUnitTestMetrics

REM Generate the report output based on the test results
if %errorlevel% equ 0 ( 
	call :RunReportGeneratorOutput	
)

REM Launch the report
if %errorlevel% equ 0 ( 
	call :RunLaunchReport	
)
exit /b %errorlevel%

:RunOpenCoverUnitTestMetrics
"C:\Users\vrmpr\.nuget\packages\opencover\4.7.1221\tools\OpenCover.Console.exe" ^
-register:user ^
-target:"C:\Users\vrmpr\.nuget\packages\xunit.runner.console\2.4.1\tools\net47\xunit.console.exe"  ^
-targetargs:"C:\Users\vrmpr\OneDrive\Documentos\Projetos\Volvo\VolvoLab.Caminhoes\VolvoLab.Caminhoes.Application.Test\obj\Debug\net5.0\VolvoLab.Caminhoes.Tests.dll -noshadow" ^
-filter:"+[VolvoLab.Caminhoes*]* -[VolvoLab.Caminhoes]* " ^
-output:"%~dp0GeneratedReports\VolvoLab.Caminhoes.xml"
exit /b %errorlevel%


:RunReportGeneratorOutput
"C:\Users\vrmpr\.nuget\packages\reportgenerator\4.8.12\tools\net5.0\ReportGenerator.exe" ^
-reports:"%~dp0\GeneratedReports\VolvoLab.Caminhoes.xml" ^
-targetdir:"%~dp0\GeneratedReports\ReportGeneratorOutput" ^
-reporttypes:Xml;Html
exit /b %errorlevel%

:RunLaunchReport
start "report" "%~dp0\GeneratedReports\ReportGeneratorOutput\index.htm"
exit /b %errorlevel%

pause	