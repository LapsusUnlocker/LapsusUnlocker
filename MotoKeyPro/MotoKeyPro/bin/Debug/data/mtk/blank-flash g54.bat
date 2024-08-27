@ECHO OFF
SET auth=.\auth_sv5.auth
SET flash=.\download_agent\blankflash.xml

if exist %auth% (
	SPFlashToolV6.exe -f %flash% -c firmware-upgrade -a %auth% --fastboot -b
) else (
	SPFlashToolV6.exe -f %flash% -c firmware-upgrade --fastboot -b
)


pause
