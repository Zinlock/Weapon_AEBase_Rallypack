datablock AudioProfile(RPX_rpkFire1Sound)
{
	filename    = "./wav/rpk_fire1.wav";
	description = HeavyClose3D;
	preload = true;
};

datablock AudioProfile(RPX_rpkFire2Sound)
{
	filename    = "./wav/rpk_fire2.wav";
	description = HeavyClose3D;
	preload = true;
};

datablock AudioProfile(RPX_rpkFire3Sound)
{
	filename    = "./wav/rpk_fire3.wav";
	description = HeavyClose3D;
	preload = true;
};

datablock AudioProfile(RPX_rpkReloadMagOutSound)
{
	filename    = "./wav/rpk_reload_magout.wav";
	description = AudioClosest3D;
	preload = true;
};

datablock AudioProfile(RPX_rpkReloadMagInSound)
{
	filename    = "./wav/rpk_reload_magin.wav";
	description = AudioClosest3D;
	preload = true;
};

datablock AudioProfile(RPX_rpkReloadTapSound)
{
	filename    = "./wav/rpk_reload_tap.wav";
	description = AudioClosest3D;
	preload = true;
};

datablock AudioProfile(RPX_rpkReloadEndEmptySound)
{
	filename    = "./wav/rpk_reload_bolt.wav";
	description = AudioClosest3D;
	preload = true;
};

datablock DebrisData(RPX_rpkMagDebris)
{
	shapeFile = "./dts/rpk_mag.dts";
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

datablock ItemData(RPX_rpkItem)
{
	category = "Weapon";
	className = "Weapon";

	shapeFile = "./dts/rpk_item.dts";
	rotate = false;
	mass = 1;
	density = 0.2;
	elasticity = 0.2;
	friction = 0.6;
	emap = true;

	uiName = "RPX: RPK";
	iconName = "./icon/rpk";
	doColorShift = true;
	colorShiftColor = "1 1 1 1";

	image = RPX_rpkEquipImage;
	canDrop = true;
	
	AEAmmo = 75;
	AEType = AE_HeavyRAmmoItem.getID(); 
	AEBase = 1;

	RPM = 312;
	Recoil = "Heavy";
	uiColor = "1 1 1";
	description = "";

	useImpactSounds = true;
	softImpactThreshold = 2;
	softImpactSound = "AEWepImpactSoft1Sound AEWepImpactSoft2Sound AEWepImpactSoft3Sound";
	hardImpactThreshold = 8;
	hardImpactSound = "AEWepImpactHard1Sound AEWepImpactHard2Sound AEWepImpactHard3Sound";
};

datablock ShapeBaseImageData(RPX_rpkImage)
{
	shapeFile = "./dts/rpk_image.dts";
	emap = true;

	mountPoint = 0;
	offset = "0 0.1 0";
	eyeOffset = 0;
	rotation = eulerToMatrix( "0 0 0" );

	correctMuzzleVector = true;

	className = "WeaponImage";

	item = RPX_rpkItem;
	ammo = " ";

	scopingImage = RPX_rpkScopeImage;

	casing = AE_BERifleShellDebris;
	shellExitDir        = "1 0 0.5";
	shellExitOffset     = "0 0 0";
	shellExitVariance   = 25;	
	shellVelocity       = 5.0;

	hideHands = true;
	armReady = true;

	doColorShift = true;
	colorShiftColor = RPX_rpkItem.colorShiftColor;

	shellSound = AEShellRifle;
	shellSoundMin = 600;
	shellSoundMax = 700;

	muzzleFlashScale = "1 1 1";

	bulletScale = "1 1 1";
	projectile = AETrailedProjectile;
	projectileType = Projectile;
	projectileDamage = 24;
	projectileCount = 1;
	projectileHeadshotMult = 1.3;
	projectileVelocity = 200;
	projectileTagStrength = 0.35;
	projectileTagRecovery = 0.03;

	useNewSpread = true;

	recoilHeight = 150;
	recoilWidth = 50;
	recoilHeightMax = 2500;
	recoilWidthMax = 400;

	spreadBurst = 2;
	spreadBase = 25;
	spreadReset = 300;
	spreadMin = 60;
	spreadAdd = 32;
	spreadMax = 600;

	screenshakeMin = "0.02 0.02 0.02";
	screenshakeMax = "0.2 0.2 0.2";
	farShotSound = RPX_RifleDistFireSound;
	farShotDistance = 40;

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
	staticTracerEffect = "";
	staticScaleCalibre = 0.5;
	staticScaleLength = 0.25;
	staticUnitsPerSecond = $RPX_AR_BulletSpeed;

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
	stateEmitter[2]					= AEBaseRifleFlashEmitter;
	stateEmitterTime[2]				= 0.05;
	stateEmitterNode[2]				= "muzzlePoint";
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
	stateTimeoutValue[4]			= 0.1;
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
	stateTimeoutValue[16]			= 0.6;
	stateScript[16]				= "onReloadStart";
	stateTransitionOnTimeout[16]		= "Reload";
	stateWaitForTimeout[16]			= true;
	stateSequence[16]			= "ReloadStart";
	
	stateName[17]				= "Reload";
	stateTimeoutValue[17]			= 2.6;
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
	stateTimeoutValue[21]			= 0.6;
	stateScript[21]				= "onReload2Start";
	stateTransitionOnTimeout[21]		= "Reload2";
	stateWaitForTimeout[21]			= true;
	stateSequence[21]			= "ReloadStart";

	stateName[22]				= "Reload2";
	stateTimeoutValue[22]			= 3.2;
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

function RPX_rpkImage::AEOnFire(%this,%obj,%slot)
{
	%obj.blockImageDismount = true;
	%obj.schedule(400, unBlockImageDismount);

	cancel(%obj.reloadSoundSchedule);
	%obj.stopAudio(0); 
	%obj.playAudio(0, RPX_rpkFire @ getRandom(1, 3) @ Sound);	

	Parent::AEOnFire(%this, %obj, %slot);
}

function RPX_rpkImage::onReloadStart(%this, %obj, %slot)
{
	%obj.stopAudio(2);
	%obj.playAudio(2, RPX_rpkReloadMagOutSound);
}

function RPX_rpkImage::onReload(%this, %obj, %slot)
{	
	%obj.reload0Schedule = %obj.schedule(500, stopAudio, 1);
	%obj.reload1Schedule = %obj.schedule(500, playAudio, 1, RPX_rpkReloadMagInSound);
	
	%obj.reload2Schedule = %obj.schedule(1150, stopAudio, 3);
	%obj.reload3Schedule = %obj.schedule(1150, playAudio, 3, RPX_rpkReloadTapSound);

	%this.onMagDrop(%obj,%slot);
	%obj.reload4Schedule = schedule(getRandom(300,400),0,serverPlay3D,AEMagDrum @ getRandom(1,3) @ Sound,%obj.getPosition());
}

function RPX_rpkImage::onReload2Start(%this, %obj, %slot)
{
	%obj.stopAudio(2);
	%obj.playAudio(2, RPX_rpkReloadMagOutSound);
}

function RPX_rpkImage::onReload2(%this, %obj, %slot)
{
	%obj.reload0Schedule = %obj.schedule(500, stopAudio, 1);
	%obj.reload1Schedule = %obj.schedule(500, playAudio, 1, RPX_rpkReloadMagInSound);
	
	%obj.reload2Schedule = %obj.schedule(1100, stopAudio, 3);
	%obj.reload3Schedule = %obj.schedule(1100, playAudio, 3, RPX_rpkReloadTapSound);

	%obj.reload4Schedule = %obj.schedule(2000, stopAudio, 2);
	%obj.reload5Schedule = %obj.schedule(2000, playAudio, 2, RPX_rpkReloadEndEmptySound);
	
	%this.onMagDrop(%obj,%slot);
	%obj.reload6Schedule = schedule(getRandom(300,400),0,serverPlay3D,AEMagDrum @ getRandom(1,3) @ Sound,%obj.getPosition());
}

function RPX_rpkImage::onDryFire(%this, %obj, %slot)
{
	%obj.aeplayThread(2, plant);
	serverPlay3D(AEDryFireSound, %obj.getHackPosition());
}

function RPX_rpkImage::onReady(%this,%obj,%slot)
{
	if(getSimTime() - %obj.reloadTime[%this.getID()] <= %this.stateTimeoutValue[0] * 1000 + 1000)
		%obj.schedule(0, setImageAmmo, %slot, 0);
	
	%obj.baadDisplayAmmo(%this);
	%this.AEPreLoadAmmoReserveCheck(%obj, %slot);
	%this.AEPreAmmoCheck(%obj, %slot);
}

function RPX_rpkImage::onMount(%this,%obj,%slot)
{
	%this.AEMountSetup(%obj, %slot);
	parent::onMount(%this,%obj,%slot);
}

function RPX_rpkImage::onUnMount(%this, %obj, %slot)
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

function RPX_rpkImage::onMagDrop(%this,%obj,%slot)
{
	%a = new Camera()
	{
		datablock = Observer;
		position = %obj.getPosition();
		scale = "1 1 1";
	};

	%a.setTransform(%obj.getSlotTransform(0));
	%a.mountImage(RPX_rpkMagImage,0);
	%a.schedule(2500,delete);
}

datablock ShapeBaseImageData(RPX_rpkMagImage)
{
	shapeFile = "base/data/shapes/empty.dts";
	mountPoint = 0;
	offset = "-0.09 0.81 -0.01";
	rotation = eulerToMatrix( "0 10 0" );
	
	casing = RPX_rpkMagDebris;
	shellExitDir        = "-0.25 0.1 -1";
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

function RPX_rpkMagImage::onDone(%this,%obj,%slot)
{
	%obj.unMountImage(%slot);
}

RPXGenerateADSImage(RPX_rpkScopeImage, RPX_rpkImage,
                    "0 0.4 -0.7065", eulerToMatrix("0 -30 0"),
										$ae_LowIronsFOV, 0,
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

RPXGenerateEquipImage(RPX_rpkEquipImage, RPX_rpkImage, 0.5, "unholster", RPX_RifleUnholsterSound);