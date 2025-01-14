datablock AudioProfile(RPX_mk18Fire1Sound)
{
	filename    = "./wav/mk18_fire1.wav";
	description = HeavyClose3D;
	preload = true;
};

datablock AudioProfile(RPX_mk18Fire2Sound)
{
	filename    = "./wav/mk18_fire2.wav";
	description = HeavyClose3D;
	preload = true;
};

datablock AudioProfile(RPX_mk18Fire3Sound)
{
	filename    = "./wav/mk18_fire3.wav";
	description = HeavyClose3D;
	preload = true;
};

datablock DebrisData(RPX_mk18MagDebris)
{
	shapeFile = "./dts/mk18_mag.dts";
	lifetime = 2.0;
	minSpinSpeed = -700.0;
	maxSpinSpeed = -600.0;
	elasticity = 0.5;
	friction = 0.1;
	numBounces = 3;
	staticOnMaxBounce = true;
	snapOnMaxBounce = false;
	fade = true;

	gravModifier = 2;
};

datablock ItemData(RPX_mk18Item)
{
	category = "Weapon";
	className = "Weapon";

	shapeFile = "./dts/mk18_item.dts";
	rotate = false;
	mass = 1;
	density = 0.2;
	elasticity = 0.2;
	friction = 0.6;
	emap = true;

	uiName = "RPX: Mk18 Tactical";
	iconName = "./icon/mk18";
	doColorShift = true;
	colorShiftColor = "1 1 1 1";

	image = RPX_mk18EquipImage;
	canDrop = true;
	
	AEAmmo = 30;
	AEType = AE_LightRAmmoItem.getID(); 
	AEBase = 1;

	RPM = 312;
	Recoil = "Medium";
	uiColor = "1 1 1";
	description = "";

	useImpactSounds = true;
	softImpactThreshold = 2;
	softImpactSound = "AEWepImpactSoft1Sound AEWepImpactSoft2Sound AEWepImpactSoft3Sound";
	hardImpactThreshold = 8;
	hardImpactSound = "AEWepImpactHard1Sound AEWepImpactHard2Sound AEWepImpactHard3Sound";
};

datablock ShapeBaseImageData(RPX_mk18Image)
{
	shapeFile = "./dts/mk18_image.dts";
	emap = true;

	mountPoint = 0;
	offset = "0 0 -0.1";
	eyeOffset = 0;
	rotation = eulerToMatrix( "0 0 0" );

	correctMuzzleVector = true;

	className = "WeaponImage";

	item = RPX_mk18Item;
	ammo = " ";

	scopingImage = RPX_mk18ScopeImage;

	casing = AE_BERifleShellDebris;
	shellExitDir        = "1 0 0.5";
	shellExitOffset     = "0 0 0";
	shellExitVariance   = 25;	
	shellVelocity       = 5.0;

	hideHands = true;
	armReady = true;

	doColorShift = true;
	colorShiftColor = RPX_mk18Item.colorShiftColor;

	shellSound = AEShellRifle;
	shellSoundMin = 600;
	shellSoundMax = 700;

	muzzleFlashScale = "0 0 0";

	bulletScale = "1 1 1";
	projectile = AEProjectile;
	projectileType = Projectile;
	projectileDamage = 22;
	projectileCount = 1;
	projectileHeadshotMult = 1.2;
	projectileVelocity = 200;
	projectileTagStrength = 0.35;
	projectileTagRecovery = 0.03;

	useNewSpread = true;

	recoilHeight = 80;
	recoilWidth = 20;
	recoilHeightMax = 2000;
	recoilWidthMax = 300;

	spreadBurst = 2;
	spreadBase = 30;
	spreadReset = 300;
	spreadMin = 60;
	spreadAdd = 22;
	spreadMax = 500;

	screenshakeMin = "0.02 0.02 0.02";
	screenshakeMax = "0.2 0.2 0.2";
	farShotSound = "";
	farShotDistance = 0;

	sonicWhizz = true;
	whizzSupersonic = true;
	whizzThrough = false;
	whizzDistance = 10;
	whizzChance = 100;
	whizzAngle = 80;

	projectileFalloffStart = $ae_falloffRifleStart;
	projectileFalloffEnd = $ae_falloffRifleEnd;
	projectileFalloffDamage = $ae_falloffRifle;

	staticHitscan = true;
	staticEffectiveRange = $RPX_AR_EffectiveRange;
	staticTotalRange = 2000;
	staticGravityScale = $RPX_AR_BulletDrop;
	staticSwayMod = $RPX_AR_BulletSway;
	staticEffectiveSpeedBonus = 0;
	staticSpawnFakeProjectiles = true;
	staticTracerEffect = AEStealthBulletStaticShape;
	staticScaleCalibre = 0.5;
	staticScaleLength = 0.25;
	staticUnitsPerSecond = $RPX_AR_BulletSpeed;

	laserSize = "1.25 1.25 1.25";
	laserColor = "1.0 0.1 0.1 1";
	laserDistance = 600;
	laserOffStates = "ReloadStart Reload ReloadEnd Reload2Start Reload2 Reload2End";
  laserFade = 400;

	stateName[0]                     	= "Activate";
	stateTimeoutValue[0]             	= 0.01;
	stateTransitionOnTimeout[0]       	= "LoadCheckA";
	stateSequence[0]			= "root";

	stateName[1]                     	= "Ready";
	stateScript[1]				= "onReady";
	stateTransitionOnNotLoaded[1]     = "Empty";
	stateTransitionOnNoAmmo[1]       	= "ReloadStart";
	stateTransitionOnTriggerDown[1]  	= "preFire";
	stateAllowImageChange[1]         	= true;

	stateName[2]                       = "preFire";
	stateTransitionOnTimeout[2]        = "Fire";
	stateScript[2]                     = "AEOnFire";
	stateFire[2]                       = true;
	stateEjectShell[2]                       = true;

	stateName[3]                    = "Fire";
	stateTransitionOnTimeout[3]     = "FireLoadCheckA";
	stateEmitter[3]					= AEBaseSmokeEmitter;
	stateEmitterTime[3]				= 0.05;
	stateEmitterNode[3]				= "muzzlePoint";
	stateAllowImageChange[3]        = false;
	stateSequence[3]                = "Fire";
	stateWaitForTimeout[3]			= true;
	
	stateName[4]				= "FireLoadCheckA";
	stateScript[4]				= "AEMagLoadCheck";
	stateTimeoutValue[4]			= 0.09;
	stateTransitionOnTimeout[4]		= "FireLoadCheckB";
	
	stateName[5]				= "FireLoadCheckB";
	stateTransitionOnAmmo[5]		= "Ready";
	stateTransitionOnNoAmmo[5]		= "Reload2Start";
	stateTransitionOnNotLoaded[5]  = "Ready";

	stateName[14]				= "LoadCheckA";
	stateScript[14]				= "AEMagLoadCheck";
	stateTimeoutValue[14]			= 0.1;
	stateTransitionOnTimeout[14]		= "LoadCheckB";
	
	stateName[15]				= "LoadCheckB";
	stateTransitionOnAmmo[15]		= "Ready";
	stateTransitionOnNotLoaded[15] = "Empty";
	stateTransitionOnNoAmmo[15]		= "Reload2Start";

	stateName[16]				= "ReloadStart";
	stateTimeoutValue[16]			= 0.5;
	stateScript[16]				= "onReloadStart";
	stateTransitionOnTimeout[16]		= "Reload";
	stateWaitForTimeout[16]			= true;
	stateSequence[16]			= "ReloadStart";
	
	stateName[17]				= "Reload";
	stateTimeoutValue[17]			= 1.4;
	stateScript[17]				= "onReload";
	stateTransitionOnTimeout[17]		= "ReloadEnd";
	stateWaitForTimeout[17]			= true;
	stateSequence[17]			= "Reload";
	
	stateName[19]				= "ReloadEnd";
	stateTimeoutValue[19]			= 0.1;
	stateScript[19]				= "AEMagReloadAll";
	stateTransitionOnTimeout[19]		= "Ready";
	stateWaitForTimeout[19]			= true;
	stateSequence[19]			= "ReloadEnd";
		
	stateName[20]				= "Reloaded";
	stateTimeoutValue[20]			= 0.1;
	stateScript[20]				= "AEMagReloadAll";
	stateTransitionOnTimeout[20]		= "Ready";

	stateName[21]				= "Reload2Start";
	stateTimeoutValue[21]			= 0.3;
	stateScript[21]				= "onReload2Start";
	stateTransitionOnTimeout[21]		= "Reload2";
	stateWaitForTimeout[21]			= true;
	stateSequence[21]			= "ReloadStartEmpty";

	stateName[22]				= "Reload2";
	stateTimeoutValue[22]			= 2.0;
	stateScript[22]				= "onReload2";
	stateTransitionOnTimeout[22]		= "Reload2End";
	stateWaitForTimeout[22]			= true;
	stateSequence[22]			= "ReloadEmpty";

	stateName[24]				= "Reload2End";
	stateTimeoutValue[24]			= 0.1;
	stateScript[24]				= "AEMagReloadAll";
	stateTransitionOnTimeout[24]		= "Ready";
	stateWaitForTimeout[24]			= true;
	stateSequence[24]			= "ReloadEndEmpty";

	stateName[26]          = "Empty";
	stateTransitionOnTriggerDown[26]  = "Dryfire";
	stateTransitionOnLoaded[26] = "Reload2Start";
	stateScript[26]        = "AEOnEmpty";

	stateName[27]           = "Dryfire";
	stateTransitionOnTriggerUp[27] = "Empty";
	stateWaitForTimeout[27]    = false;
	stateScript[27]      = "onDryFire";
};

function RPX_mk18Image::AEOnFire(%this,%obj,%slot)
{
	%obj.blockImageDismount = true;
	%obj.schedule(400, unBlockImageDismount);

	cancel(%obj.reloadSoundSchedule);
	%obj.stopAudio(0); 
	%obj.playAudio(0, RPX_mk18Fire @ getRandom(1, 3) @ Sound);	

	Parent::AEOnFire(%this, %obj, %slot);
}

function RPX_mk18Image::onReloadStart(%this, %obj, %slot)
{
	%obj.reload0Schedule = %obj.schedule(150, stopAudio, 2);
	%obj.reload1Schedule = %obj.schedule(150, playAudio, 2, RPX_m4a1ReloadMagOutSound);
}

function RPX_mk18Image::onReload(%this, %obj, %slot)
{
	%obj.reload2Schedule = %obj.schedule(400, stopAudio, 1);
	%obj.reload3Schedule = %obj.schedule(400, playAudio, 1, RPX_m4a1ReloadMagInSound);

	%this.onMagDrop(%obj,%slot);
	%obj.reload4Schedule = schedule(getRandom(300,400),0,serverPlay3D,AEMagMetalAR @ getRandom(1,3) @ Sound,%obj.getPosition());
}

function RPX_mk18Image::onReload2Start(%this, %obj, %slot)
{
	%obj.reload0Schedule = %obj.schedule(200, stopAudio, 2);
	%obj.reload1Schedule = %obj.schedule(200, playAudio, 2, RPX_m4a1ReloadMagOutSound);
}

function RPX_mk18Image::onReload2(%this, %obj, %slot)
{
	%obj.reload2Schedule = %obj.schedule(500, stopAudio, 1);
	%obj.reload3Schedule = %obj.schedule(500, playAudio, 1, RPX_m4a1ReloadMagInSound);

	%obj.reload5Schedule = %obj.schedule(1100, stopAudio, 3);
	%obj.reload6Schedule = %obj.schedule(1100, playAudio, 3, RPX_MP5ReloadTapSound);

	%obj.reload0Schedule = %obj.schedule(1050, stopAudio, 2);
	%obj.reload1Schedule = %obj.schedule(1050, playAudio, 2, RPX_m4a1ReloadEndEmptySound);
	
	%this.onMagDrop(%obj,%slot, 1);
	%obj.reload4Schedule = schedule(getRandom(300,400),0,serverPlay3D,AEMagMetalAR @ getRandom(1,3) @ Sound,%obj.getPosition());
}

function RPX_mk18Image::onDryFire(%this, %obj, %slot)
{
	%obj.aeplayThread(2, plant);
	serverPlay3D(AEDryFireSound, %obj.getHackPosition());
}

function RPX_mk18Image::onReady(%this,%obj,%slot)
{
	if(getSimTime() - %obj.reloadTime[%this.getID()] <= %this.stateTimeoutValue[0] * 1000 + 1000)
		%obj.schedule(0, setImageAmmo, %slot, 0);
	
	%obj.baadDisplayAmmo(%this);
	%this.AEPreLoadAmmoReserveCheck(%obj, %slot);
	%this.AEPreAmmoCheck(%obj, %slot);
}

function RPX_mk18Image::onMount(%this,%obj,%slot)
{
	%this.AEMountSetup(%obj, %slot);
	parent::onMount(%this,%obj,%slot);
}

function RPX_mk18Image::onUnMount(%this, %obj, %slot)
{	
	%this.AEUnmountCleanup(%obj, %slot);

	cancel(%obj.reload0Schedule);
	cancel(%obj.reload1Schedule);
	cancel(%obj.reload2Schedule);
	cancel(%obj.reload3Schedule);
	cancel(%obj.reload4Schedule);
	cancel(%obj.reload5Schedule);
	cancel(%obj.reload6Schedule);
	parent::onUnMount(%this,%obj,%slot);	
}

function RPX_mk18Image::onMagDrop(%this,%obj,%slot, %empty)
{
	%a = new Camera()
	{
		datablock = Observer;
		position = %obj.getPosition();
		scale = "1 1 1";
	};

	%a.setTransform(%obj.getSlotTransform(0));
	if(%empty)
		%a.mountImage(RPX_mk18MagEmptyImage,0);
	else
		%a.mountImage(RPX_mk18MagImage,0);
	%a.schedule(2500,delete);
}

datablock ShapeBaseImageData(RPX_mk18MagImage)
{
	shapeFile = "base/data/shapes/empty.dts";
	mountPoint = 0;
	offset = "-0.93 0.37 -0.59";
	rotation = eulerToMatrix( "0 50 0" );
	
	casing = RPX_mk18MagDebris;
	shellExitDir        = "-0.5 0 -0.5";
	shellExitOffset     = "0 0 0";
	shellExitVariance   = 9.0;
	shellVelocity       = 3.0;
	
	stateName[0]                    = "Ready";
	stateTimeoutValue[0]            = 0.01;
	stateTransitionOnTimeout[0]     = "EjectA";
	
	stateName[1]                    = "EjectA";
	stateEjectShell[1]                = true;
	stateTimeoutValue[1]            = 1;
	stateTransitionOnTimeout[1]     = "Done";
	
	stateName[2]                    = "Done";
	stateScript[2]                    = "onDone";
};

function RPX_mk18MagImage::onDone(%this,%obj,%slot)
{
	%obj.unMountImage(%slot);
}

datablock ShapeBaseImageData(RPX_mk18MagEmptyImage)
{
	shapeFile = "base/data/shapes/empty.dts";
	mountPoint = 0;
	offset = "0.13 0.47 -0.14";
	rotation = eulerToMatrix( "0 -40 0" );
	
	casing = RPX_mk18MagDebris;
	shellExitDir        = "0.5 0 -0.5";
	shellExitOffset     = "0 0 0";
	shellExitVariance   = 9.0;
	shellVelocity       = 3.0;
	
	stateName[0]                    = "Ready";
	stateTimeoutValue[0]            = 0.01;
	stateTransitionOnTimeout[0]     = "EjectA";
	
	stateName[1]                    = "EjectA";
	stateEjectShell[1]                = true;
	stateTimeoutValue[1]            = 1;
	stateTransitionOnTimeout[1]     = "Done";
	
	stateName[2]                    = "Done";
	stateScript[2]                    = "onDone";
};

function RPX_mk18MagEmptyImage::onDone(%this,%obj,%slot)
{
	%obj.unMountImage(%slot);
}

RPXGenerateADSImage(RPX_mk18ScopeImage, RPX_mk18Image,
                    "0 0.4 -0.6673", eulerToMatrix("0 -30 0"),
										$ae_HighIronsFOV, 0,
										16, 21,
										"R_MovePenalty = 0.5;" NL
										"stateTimeoutValue[0] = 0.2;" NL
										"stateSound[0] = \"\";" NL
										"stateSequence[0] = \"scopeIn\";" NL
										"stateSequence[3] = \"fireADS\";",
										AEAdsIn6Sound, AEAdsOut3Sound,
										0.5, 0.5,
										0.5, 0.5,
										0.5);

RPXGenerateEquipImage(RPX_mk18EquipImage, RPX_mk18Image, 0.4, "unholster", RPX_RifleUnholsterSound);