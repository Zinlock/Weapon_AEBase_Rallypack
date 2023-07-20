function rpx()
{
	exec("./server.cs");
}

$RPX_AR_EffectiveRange = 100;
$RPX_AR_BulletSway = 10.0;
$RPX_AR_BulletDrop = 1.0;
$RPX_AR_BulletSpeed = 600;

$RPX_MR_EffectiveRange = 150;
$RPX_MR_BulletSway = 3.0;
$RPX_MR_BulletDrop = 2.0;
$RPX_MR_BulletSpeed = 800;

$RPX_SR_EffectiveRange = 200;
$RPX_SR_BulletSway = 0.2;
$RPX_SR_BulletDrop = 3.0;
$RPX_SR_BulletSpeed = 1000;

// ? for commented examples of these functions, check Weapon_AWP.cs

function RPXGenerateEquipImage(%name, %base, %equipTime, %equipSequence, %equipSound)
{
	eval(
		"datablock ShapeBaseImageData(" @ %name @ " : " @ %base @ ") {" NL
			"isSafetyImage = true;" NL

			"sourceImage = %base;" NL

			"stateTimeoutValue[0] = %equipTime;" NL
			"stateTransitionOnTimeout[0] = \"Done\";" NL
			"stateSequence[0] = %equipSequence;" NL
			"stateSound[0] = %equipSound;" NL

			"stateName[1] = \"Done\";" NL
			"stateScript[1] = \"onDone\";" NL
			"stateTransitionOnTimeout[1] = \"\";" NL
			"stateTimeoutValue[1] = 1;" NL
			"stateTransitionOnTriggerDown[1] = \"\";" NL
			"stateTransitionOnTriggerUp[1] = \"\";" NL
			"stateTransitionOnAmmo[1] = \"\";" NL
			"stateTransitionOnNoAmmo[1] = \"\";" NL
			"stateTransitionOnLoaded[1] = \"\";" NL
			"stateTransitionOnNotLoaded[1] = \"\";" NL
		"};"
	);

	eval("function " @ %name @ "::onMount(%this, %obj, %slot) { %this.AEMountSetup(%obj, %slot); parent::onMount(%this,%obj,%slot); }");
	eval("function " @ %name @ "::onUnMount(%this, %obj, %slot) { %this.AEUnmountCleanup(%obj, %slot); parent::onUnMount(%this,%obj,%slot); }");
	eval("function " @ %name @ "::onDone(%this, %obj, %slot) { %obj.mountImage(%this.sourceImage, 0); }");
}

function RPXGenerateADSImage(%name, %base, %eyeOff, %rot, %fov, %zOff, %reload1Idx, %reload2Idx, %extra, %inSound, %outSound, %recoilMultX, %recoilMultZ, %recoilMaxMultX, %recoilMaxMultZ, %spreadMult)
{
	eval(
		"datablock ShapeBaseImageData(" @ %name @ " : " @ %base @ ") {" NL
			"eyeOffset = %eyeOff;" NL
			"rotation = %rot;" NL
			"sourceImage = %base;" NL
			"scopingImage = %base;" NL
			"desiredFov = %fov;" NL
			"projectileZOffset = %zOff;" NL

			"recoilHeight = %base.recoilHeight * %recoilMultZ;" NL
			"recoilWidth = %base.recoilWidth * %recoilMultX;" NL
			"recoilHeightMax = %base.recoilHeightMax * %recoilMaxMultZ;" NL
			"recoilWidthMax = %base.recoilWidthMax * %recoilMaxMultX;" NL

			"spreadBase = %base.spreadBase * %spreadMult;" NL
			"spreadMin = %base.spreadMin * %spreadMult;" NL
			"spreadAdd = %base.spreadAdd * %spreadMult;" NL
			"spreadMax = %base.spreadMax * %spreadMult;" NL

			"stateScript[" @ %reload1Idx @ "] = \"onDone\";" NL
			"stateTimeoutValue[" @ %reload1Idx @ "]        = 1;" NL
			"stateTransitionOnTimeout[" @ %reload1Idx @ "] = \"\";" NL
			"stateSound[" @ %reload1Idx @ "]               = \"\";" NL
			"stateSequence[" @ %reload1Idx @ "]            = \"\";" NL

			"stateScript[" @ %reload2Idx @ "] = \"onDone\";" NL
			"stateTimeoutValue[" @ %reload2Idx @ "]        = 1;" NL
			"stateTransitionOnTimeout[" @ %reload2Idx @ "] = \"\";" NL
			"stateSound[" @ %reload2Idx @ "]               = \"\";" NL
			"stateSequence[" @ %reload2Idx @ "]            = \"\";" NL

			%extra NL
		"};"
	);

	%fn[%c=0] = "onReloadStart";
	%fn[%c++] = "onReload2Start";
	%fn[%c++] = "onReady";
	%fn[%c++] = "onDryFire";
	%fn[%c++] = "AEOnFire";
	%fn[%c++] = "onBolt";
	%fn[%c++] = "onPump";

	for(%i = 0; %i < %c; %i++)
		eval("function " @ %name @ "::" @ %fn[%i] @ "(%this, %obj, %slot) { " @ %base @ "::" @ %fn[%i] @ "(%this, %obj, %slot); }");

	eval("function " @ %name @ "::onMount(%this,%obj,%slot) { " NL
		"%obj.aeplayThread(2, plant); if(isObject(%obj.client) && %obj.client.IsA(\"GameConnection\")) {%obj.client.play2D(" @ %inSound @ ");} " NL
		"%this.AEMountSetup(%obj, %slot); parent::onMount(%this,%obj,%slot); }");

	eval("function " @ %name @ "::onUnMount(%this,%obj,%slot) { " NL
		"if(isObject(%obj.client) && %obj.client.IsA(\"GameConnection\")) {%obj.client.play2D(" @ %outSound @ ");} " NL
		"%this.AEUnmountCleanup(%obj, %slot); parent::onUnMount(%this,%obj,%slot); }");

	eval("function " @ %name @ "::onDone(%this, %obj, %slot) { %obj.reloadTime[%this.sourceImage.getID()] = getSimTime(); %obj.mountImage(%this.sourceImage, 0);}");

	if(isObject(%name))
		return %name.getId();
	else
		return -1;
}

$error = ForceRequiredAddOn("Weapon_AEBase");

if($error == $Error::AddOn_NotFound)
{
	error("ERROR: AEBase_Rallypack - required add-on Weapon_AEBase not found");
}
else
{
	exec("./data.cs");
	exec("./Weapon_Spas12.cs");
	exec("./Weapon_MP5K.cs");
	exec("./Weapon_AK47.cs");
	exec("./Weapon_M4A1.cs");
	exec("./Weapon_92FS.cs");
	exec("./Weapon_Glock.cs");
	exec("./Weapon_AWP.cs");
	exec("./Weapon_870.cs");
	exec("./Weapon_AWC.cs");
	exec("./Weapon_Deagle.cs");
	exec("./Weapon_SSR.cs");
	exec("./Weapon_RPK.cs");
}