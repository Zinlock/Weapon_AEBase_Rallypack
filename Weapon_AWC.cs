datablock AudioProfile(RPX_AWCFire1Sound)
{
	filename    = "./wav/AWC_fire1.wav";
	description = MediumClose3D;
	preload = true;
};

datablock AudioProfile(RPX_AWCFire2Sound)
{
	filename    = "./wav/AWC_fire2.wav";
	description = MediumClose3D;
	preload = true;
};

datablock AudioProfile(RPX_AWCFire3Sound)
{
	filename    = "./wav/AWC_fire3.wav";
	description = MediumClose3D;
	preload = true;
};

datablock ItemData(RPX_AWCItem)
{
	category = "Weapon";
	className = "Weapon";

	shapeFile = "./dts/AWC_item.dts";
	rotate = false;
	mass = 1;
	density = 0.2;
	elasticity = 0.2;
	friction = 0.6;
	emap = true;

	uiName = "RPX: AWC";
	iconName = "./icon/awc";
	doColorShift = true;
	colorShiftColor = "1 1 1 1";

	image = RPX_AWCEquipImage;
	canDrop = true;

	AEAmmo = 5;
	AEType = AE_HeavierRAmmoItem.getID(); 
	AEBase = 1;

	RPM = 312;
	Recoil = "High";
	uiColor = "1 1 1";
	description = "";

	useImpactSounds = true;
	softImpactThreshold = 2;
	softImpactSound = "AEWepImpactSoft1Sound AEWepImpactSoft2Sound AEWepImpactSoft3Sound";
	hardImpactThreshold = 8;
	hardImpactSound = "AEWepImpactHard1Sound AEWepImpactHard2Sound AEWepImpactHard3Sound";
};

datablock ShapeBaseImageData(RPX_AWCImage)
{
	shapeFile = "./dts/AWC_image.dts";
	emap = true;

	mountPoint = 0;
	offset = "0 0.2 0";
	eyeOffset = 0;
	rotation = eulerToMatrix( "0 0 0" );

	correctMuzzleVector = true;

	className = "WeaponImage";

	item = RPX_AWCItem;
	ammo = " ";

	casing = AE_BERifleShellDebris;
	shellExitDir        = "1 0 0.5";
	shellExitOffset     = "0 0 0";
	shellExitVariance   = 25;	
	shellVelocity       = 5.0;

	hideHands = true;
	armReady = true;

	doColorShift = true;
	colorShiftColor = RPX_AWCItem.colorShiftColor;

	isScopedImage = true;
	scopingImage = RPX_AWCScopeImage;

	muzzleFlashScale = "1 1 1";

	bulletScale = "1 1 1";
	projectile = AETrailedProjectile;
	projectileType = Projectile;
	projectileDamage = 85;
	projectileCount = 1;
	projectileHeadshotMult = 2.1;
	projectileVelocity = 200;
	projectileTagStrength = 0.35;
	projectileTagRecovery = 0.03;

	useNewSpread = true;

	recoilHeight = 120;
	recoilWidth = 40;
	recoilHeightMax = 2000;
	recoilWidthMax = 500;

	spreadBurst = 1;
	spreadBase = 650;
	spreadReset = 700;
	spreadMin = 650;
	spreadAdd = 50;
	spreadMax = 2000;

	screenshakeMin = "0.05 0.05 0.05";
	screenshakeMax = "0.2 0.2 0.2";

	sonicWhizz = true;
	whizzSupersonic = 2;
	whizzThrough = false;
	whizzDistance = 14;
	whizzChance = 100;
	whizzAngle = 80;

	projectileFalloffStart = $ae_falloffSniperStart;
	projectileFalloffEnd = $ae_falloffSniperEnd;
	projectileFalloffDamage = $ae_falloffSniper;
	
	staticHitscan = true;
	staticEffectiveRange = $RPX_SR_EffectiveRange;
	staticTotalRange = 2000;
	staticGravityScale = $RPX_SR_BulletDrop;
	staticSwayMod = $RPX_SR_BulletSway;
	staticEffectiveSpeedBonus = 0;
	staticSpawnFakeProjectiles = true;
	staticTracerEffect = AEStealthBulletStaticShape;
	staticScaleCalibre = 0.5;
	staticScaleLength = 0.5;
	staticUnitsPerSecond = $RPX_SR_BulletSpeed;
	
	laserSize = "1.25 1.25 1.25";
	laserColor = "1.0 0.1 0.1 1";
	laserDistance = 600;
	laserOffStates = "ReloadStart Reload ReloadEnd Reload2Start Reload2 Reload2End";
  laserFade = 400;

	stateName[0]                     	= "Activate";
	stateTimeoutValue[0]             	= 0.01;
	stateTransitionOnTimeout[0]       	= "LoadCheckA";
	stateSequence[0]          = "root";
	// stateSequence[0]			= "unholster";
	// stateSound[0]         = RPX_RifleUnholsterSound;

	stateName[1]                     	= "Ready";
	stateScript[1]				= "onReady";
	stateTransitionOnNotLoaded[1]     = "Empty";
	stateTransitionOnNoAmmo[1]       	= "ReloadStart";
	stateTransitionOnTriggerDown[1]  	= "preFire";
	stateAllowImageChange[1]         	= true;

	stateName[2]                       = "preFire";
	stateTransitionOnTimeout[2]        = "Fire";
	stateTransitionOnNoAmmo[2]       	= "NoAmmoFlashFix";
	stateScript[2]                     = "AEOnFire";
	stateFire[2]                       = true;

	stateName[3]                    = "Fire";
	stateTransitionOnTimeout[3]     = "SemiAutoCheck";
	stateEmitter[3]					= AEBaseSmokeBigEmitter;
	stateEmitterTime[3]				= 0.05;
	stateEmitterNode[3]				= "muzzlePoint";
	stateAllowImageChange[3]        = false;
	stateSequence[3]                = "Fire";
	stateWaitForTimeout[3]			= true;

	stateName[4]				= "FireLoadCheckA";
	stateScript[4]				= "AEMagLoadCheck";
	stateTimeoutValue[4]			= 0.5;
	stateTransitionOnTimeout[4]		= "FireLoadCheckB";
	
	stateName[5]				= "FireLoadCheckB";
	stateTransitionOnAmmo[5]		= "Bolt";
	stateTransitionOnNoAmmo[5]		= "Reload2Start";
	stateTransitionOnNotLoaded[5]  = "Bolt";

	stateName[7]                  = "Bolt";
	stateTimeoutValue[7]          = 1.0;
	stateSequence[7]              = "bolt";
	stateTransitionOnTimeout[7]   = "Ready";
	stateScript[7]                = "onBolt";
	stateEjectShell[7]            = true;

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
	stateTimeoutValue[17]			= 1.3;
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
	stateTimeoutValue[21]			= 0.8;
	stateScript[21]				= "onReload2Start";
	stateTransitionOnTimeout[21]		= "Reload2";
	stateWaitForTimeout[21]			= true;
	stateSequence[21]			= "ReloadStartEmpty";

	stateName[22]				= "Reload2";
	stateTimeoutValue[22]			= 1.9;
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
	
	stateName[28]           = "SemiAutoCheck";
	stateTransitionOnTriggerUp[28] = "FireLoadCheckA";
	
	stateName[30]           = "NoAmmoFlashFix";
	stateTransitionOnTimeout[30] = "Fire";
};

function RPX_AWCImage::AEOnFire(%this,%obj,%slot)
{
	%obj.blockImageDismount = true;
	%obj.schedule(400, unBlockImageDismount);

	cancel(%obj.reloadSoundSchedule);
	%obj.stopAudio(0); 
	%obj.playAudio(0, RPX_AWCFire @ getRandom(1, 3) @ Sound);	

	%obj.aeplayThread(2, plant);

	Parent::AEOnFire(%this, %obj, %slot);
}

function RPX_AWCImage::onBolt(%this, %obj, %slot)
{
	schedule(getRandom(500,600),0,serverPlay3D,AEShellSniper @ getRandom(1,3) @ Sound,%obj.getPosition());

	%obj.stopAudio(2);
	%obj.playAudio(2, RPX_AWPBoltBackSound);

	%obj.reload2Schedule = %obj.schedule(400, stopAudio, 1);
	%obj.reload3Schedule = %obj.schedule(400, playAudio, 1, RPX_AWPBoltForwardSound);
}

function RPX_AWCImage::onReloadStart(%this, %obj, %slot)
{
	%obj.reload0Schedule = %obj.schedule(150, stopAudio, 2);
	%obj.reload1Schedule = %obj.schedule(150, playAudio, 2, RPX_AWPReloadMagOutSound);
}

function RPX_AWCImage::onReload(%this, %obj, %slot)
{
	%obj.reload2Schedule = %obj.schedule(400, stopAudio, 1);
	%obj.reload3Schedule = %obj.schedule(400, playAudio, 1, RPX_AWPReloadMagInSound);

	%this.onMagDrop(%obj,%slot);
	%obj.reload4Schedule = schedule(getRandom(300,400),0,serverPlay3D,AEMagMetalAR @ getRandom(1,3) @ Sound,%obj.getPosition());
}

function RPX_AWCImage::onReload2Start(%this, %obj, %slot)
{
	%obj.reload0Schedule = %obj.schedule(100, stopAudio, 2);
	%obj.reload1Schedule = %obj.schedule(100, playAudio, 2, RPX_AWPBoltBackSound);
}

function RPX_AWCImage::onReload2(%this, %obj, %slot)
{
	%obj.stopAudio(2);
	%obj.playAudio(2, RPX_AWPReloadMagOutSound);

	%obj.reload2Schedule = %obj.schedule(700, stopAudio, 1);
	%obj.reload3Schedule = %obj.schedule(700, playAudio, 1, RPX_AWPReloadMagInSound);

	%obj.reload0Schedule = %obj.schedule(1200, stopAudio, 2);
	%obj.reload1Schedule = %obj.schedule(1200, playAudio, 2, RPX_AWPBoltForwardSound);
	
	%this.onMagDrop(%obj,%slot, 1);
	%obj.reload4Schedule = schedule(getRandom(300,400),0,serverPlay3D,AEMagMetalAR @ getRandom(1,3) @ Sound,%obj.getPosition());
}

function RPX_AWCImage::onDryFire(%this, %obj, %slot)
{
	%obj.aeplayThread(2, plant);
	serverPlay3D(AEDryFireSound, %obj.getHackPosition());
}

function RPX_AWCImage::onReady(%this,%obj,%slot)
{
	if(getSimTime() - %obj.reloadTime[%this.getID()] <= %this.stateTimeoutValue[0] * 1000 + 1000)
		%obj.schedule(0, setImageAmmo, %slot, 0);
	
	%obj.baadDisplayAmmo(%this);
	%this.AEPreLoadAmmoReserveCheck(%obj, %slot);
	%this.AEPreAmmoCheck(%obj, %slot);
}

function RPX_AWCImage::onMount(%this,%obj,%slot)
{
	%this.AEMountSetup(%obj, %slot);
	parent::onMount(%this,%obj,%slot);
}

function RPX_AWCImage::onUnMount(%this, %obj, %slot)
{	
	%this.AEUnmountCleanup(%obj, %slot);

	cancel(%obj.reload0Schedule);
	cancel(%obj.reload1Schedule);
	cancel(%obj.reload2Schedule);
	cancel(%obj.reload3Schedule);
	cancel(%obj.reload4Schedule);
	parent::onUnMount(%this,%obj,%slot);	
}

function RPX_AWCImage::onMagDrop(%this,%obj,%slot, %empty)
{
	%a = new Camera()
	{
		datablock = Observer;
		position = %obj.getPosition();
		scale = "1 1 1";
	};

	%a.setTransform(%obj.getSlotTransform(0));
	if(%empty)
		%a.mountImage(RPX_AWCMagEmptyImage,0);
	else
		%a.mountImage(RPX_AWCMagImage,0);
	%a.schedule(2500,delete);
}

datablock ShapeBaseImageData(RPX_AWCMagImage)
{
	shapeFile = "base/data/shapes/empty.dts";
	mountPoint = 0;
	offset = "-0.06 1.12 -0.10";
	rotation = eulerToMatrix( "0 33 0" );
	
	casing = RPX_AWPMagDebris;
	shellExitDir        = "-1.0 1.0 -0.5";
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

function RPX_AWCMagImage::onDone(%this,%obj,%slot)
{
	%obj.unMountImage(%slot);
}

datablock ShapeBaseImageData(RPX_AWCMagEmptyImage)
{
	shapeFile = "base/data/shapes/empty.dts";
	mountPoint = 0;
	offset = "-0.66 0.64 -0.27";
	rotation = eulerToMatrix( "0 -30 50" );
	
	casing = RPX_AWPMagDebris;
	shellExitDir        = "0.3 1.0 -0.5";
	shellExitOffset     = "0 0 0";
	shellExitVariance   = 8.0;
	shellVelocity       = 5.0;
	
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

function RPX_AWCMagEmptyImage::onDone(%this,%obj,%slot)
{
	%obj.unMountImage(%slot);
}

datablock ShapeBaseImageData(RPX_AWCScopeImage : RPX_AWCImage)
{
	offset = "0 0.2 0";
	eyeOffset = "0 0.6 -0.62";
	rotation = eulerToMatrix( "0 -30 0" );

	correctMuzzleVector = true;

	className = "WeaponImage";

	item = RPX_AWCItem;

	scopingImage = RPX_AWCImage;
	sourceImage = RPX_AWCImage;

	desiredFOV = $ae_MedScopeFOV;
	projectileZOffset = 0;
	R_MovePenalty = 0.5;
	
	recoilHeight = 30;
	recoilWidth = 10;
	recoilHeightMax = 200;
	recoilWidthMax = 30;

	spreadBurst = 1;
	spreadBase = 0;
	spreadReset = 700;
	spreadMin = 50;
	spreadAdd = 50;
	spreadMax = 200;

	stateName[0]                     	= "Activate";
	stateTimeoutValue[0]             	= 0.3;
	stateTransitionOnTimeout[0]       	= "LoadCheckA";
	stateSequence[0]			= "scopeIn";

	stateSequence[7] = "boltScoped";

	stateScript[16] = "onDone";
	stateTimeoutValue[16]        = 1;
	stateTransitionOnTimeout[16] = "";
	stateSound[16]               = "";

	stateScript[21]              = "onDone";
	stateTimeoutValue[21]        = 1;
	stateTransitionOnTimeout[21] = "";
	stateSound[21]               = "";
};

function RPX_AWCScopeImage::onMount(%this,%obj,%slot)
{
	%obj.aeplayThread(2, plant);

	if(isObject(%obj.client) && %obj.client.IsA("GameConnection"))
		%obj.client.play2D(AEAdsIn1Sound);

	%this.AEMountSetup(%obj, %slot);
	parent::onMount(%this,%obj,%slot);
}

function RPX_AWCScopeImage::onUnMount(%this, %obj, %slot)
{
	if(isObject(%obj.client) && %obj.client.IsA("GameConnection"))
		%obj.client.play2D(AEAdsOut1Sound);

	%this.AEUnmountCleanup(%obj, %slot);
	parent::onUnMount(%this,%obj,%slot);	
}

function RPX_AWCScopeImage::onReady(%this,%obj,%slot)
{
	%obj.baadDisplayAmmo(%this);
}

function RPX_AWCScopeImage::onBolt(%this,%obj,%slot) { RPX_AWCImage::onBolt(%this,%obj,%slot); }

function RPX_AWCScopeImage::AEOnFire(%this,%obj,%slot) { RPX_AWCImage::AEOnFire(%this,%obj,%slot); }

function RPX_AWCScopeImage::onDryFire(%this,%obj,%slot) { RPX_AWCImage::onDryFire(%this,%obj,%slot); }

function RPX_AWCScopeImage::onDone(%this,%obj,%slot)
{
	%obj.reloadTime[%this.sourceImage.getID()] = getSimTime();
	%obj.mountImage(%this.sourceImage, 0);
}

datablock ShapeBaseImageData(RPX_AWCEquipImage)
{
	shapeFile = "./dts/AWC_image.dts";
	emap = true;
	mountPoint = 0;
	offset = "0 0.2 0";
	eyeOffset = "0 0 0";
	rotation = eulerToMatrix( "0 0 0" );
	correctMuzzleVector = true;
	className = "WeaponImage";
	item = RPX_AWCItem;
	sourceImage = RPX_AWCImage;
	ammo = " ";
	melee = false;
	armReady = true;
	hideHands = true;
	doColorShift = true;
	colorShiftColor = RPX_AWCItem.colorShiftColor;

	isSafetyImage = true;

	stateName[0]                     	= "Activate";
	stateTimeoutValue[0]             	= 0.4;
	stateTransitionOnTimeout[0]       	= "Done";
	stateSequence[0]			= "unholster";
	stateSound[0]         = RPX_RifleUnholsterSound;
	
	stateName[1]                     	= "Done";
	stateScript[1]				= "onDone";

};

function RPX_AWCEquipImage::onMount(%this,%obj,%slot)
{
	%this.AEMountSetup(%obj, %slot);
	parent::onMount(%this,%obj,%slot);
}

function RPX_AWCEquipImage::onUnMount(%this, %obj, %slot)
{
	%this.AEUnmountCleanup(%obj, %slot);
	parent::onUnMount(%this,%obj,%slot);	
}

function RPX_AWCEquipImage::onDone(%this,%obj,%slot)
{
	%obj.mountImage(%this.sourceImage, 0);
}
