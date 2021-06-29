$VERSION = & git.exe tag --points-at main
if ($VERSION) {
	$NVERSION = $VERSION.substring(1)
	echo "[assembly: AssemblyVersion(`"$NVERSION`")]" | Out-File -Append -FilePath ${GITHUB_WORKSPACE}/src/Shotr.Ui/Properties/AssemblyVersion.cs -Encoding utf8
	echo "[assembly: AssemblyFileVersion(`"$NVERSION`")]" | Out-File -Append -FilePath ${GITHUB_WORKSPACE}/src/Shotr.Ui/Properties/AssemblyVersion.cs -Encoding utf8
	echo "Version is: $NVERSION"
	echo "CURRENT_BRANCH=BetaTest" | Out-File -FilePath $Env:GITHUB_ENV -Encoding utf8 -Append
} else {
	echo "Version is empty...skipping set."
	echo "CURRENT_BRANCH=Testing"
}