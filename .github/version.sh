#!/bin/bash

VAR=`git tag --points-at HEAD`
if [ -z "$VAR" ]
then
	# don't do anything
	echo "Empty version, won't set for release..."
	echo "BUILD_BRANCH=Testing" >> $GITHUB_ENV
else
	VERSION="${VAR:1}"
	echo "[assembly: AssemblyVersion(\"$VERSION\")]" >> ${GITHUB_WORKSPACE}/src/Shotr.Ui/Properties/AssemblyVersion.cs
	echo "[assembly: AssemblyFileVersion(\"$VERSION\")]" >> ${GITHUB_WORKSPACE}/src/Shotr.Ui/Properties/AssemblyVersion.cs
	echo "BUILD_BRANCH=BetaTest" >> $GITHUB_ENV
fi