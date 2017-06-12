@pushd %~dp0

%windir%\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe "AndroidAppTestSuit.csproj"

@if ERRORLEVEL 1 goto end

@cd ..\packages\SpecRun.Runner.*\tools

@set env.DeviceNameAndOS=%1
@set env.Feature=%2

@if %env.Feature% == all (@set env.Filter=/filter:!@autotestsDataDelete ) else (  @set env.Filter=/filter:%2 ) 

@set env.TestResultsReport=/report:testresults/LatestSpecflowReport.html 

SpecRun.exe run Default.srprofile "/baseFolder:%~dp0\bin\Debug" /log:specrun.log %env.Filter% %env.TestResultsReport%

@if ERRORLEVEL 440 ( EXIT -1 )

:end

@popd
