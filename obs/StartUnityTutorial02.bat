cd /d %~dp0

if exist %~dp0unityProject goto :_open

start "" "%unitypath%" -createproject %~dp0Tutorial02
goto :eof

:_open

start "" "%unitypath2018%" -projectPath %~dp0Tutorial02
goto :eof