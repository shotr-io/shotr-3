#!/bin/bash

VAR=`git tag --points-at HEAD`
if [ -z "$VAR" ]
then
	# don't do anything
	echo "Empty version, won't set for release..."
	echo "::set-output name=build_branch::Testing"
else
	VERSION="${VAR:1}"
	echo "[assembly: AssemblyVersion(\"$VERSION\")]" >> ${GITHUB_WORKSPACE}/src/Shotr.Ui/Properties/AssemblyVersion.cs
	echo "[assembly: AssemblyFileVersion(\"$VERSION\")]" >> ${GITHUB_WORKSPACE}/src/Shotr.Ui/Properties/AssemblyVersion.cs
	echo "::set-output name=build_branch::BetaTest"
fi