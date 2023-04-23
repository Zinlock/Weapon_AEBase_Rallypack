datablock AudioProfile(RPX_berettaFire1Sound)
{
	filename    = "./wav/beretta_fire1.wav";
	description = HeavyClose3D;
	preload = true;
};

datablock AudioProfile(RPX_berettaFire2Sound)
{
	filename    = "./wav/beretta_fire2.wav";
	description = HeavyClose3D;
	preload = true;
};

datablock AudioProfile(RPX_berettaFire3Sound)
{
	filename    = "./wav/beretta_fire3.wav";
	description = HeavyClose3D;
	preload = true;
};

datablock AudioProfile(RPX_berettaReloadMagOutSound)
{
	filename    = "./wav/beretta_reload_magout.wav";
	description = AudioClosest3D;
	preload = true;
};

datablock AudioProfile(RPX_berettaReloadMagInSound)
{
	filename    = "./wav/beretta_reload_magin.wav";
	description = AudioClosest3D;
	preload = true;
};

datablock AudioProfile(RPX_berettaReloadEndEmptySound)
{
	filename    = "./wav/beretta_reload_slide.wav";
	description = AudioClosest3D;
	preload = true;
};

datablock DebrisData(RPX_berettaMagDebris)
{
	shapeFile = "./dts/beretta_mag.dts";
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

datablock ItemData(RPX_berettaItem)
{
	category = "Weapon";
	className = "Weapon";

	shapeFile = "./dts/beretta_item.dts";
	rotate = false;
	mass = 1;
	density = 0.2;
	elasticity = 0.2;
	friction = 0.6;
	emap = true;

	uiName = "RPX: Beretta 92FS";
	iconName = "./icon/beretta";
	doColorShift = true;
	colorShiftColor = "1 1 1 1";

	image = RPX_berettaImage;
	canDrop = true;

	AEAmmo = 18;
	AEType = AE_LightPAmmoItem.getID(); 
	AEBase = 1;

	RPM = 312;
	Recoil = "Low";
	uiColor = "1 1 1";
	description = "";

	useImpactSounds = true;
	softImpactThreshold = 2;
	softImpactSound = "AEWepImpactSoft1Sound AEWepImpactSoft2Sound AEWepImpactSoft3Sound";
	hardImpactThreshold = 8;
	hardImpactSound = "AEWepImpactHard1Sound AEWepImpactHard2Sound AEWepImpactHard3Sound";
};

datablock ShapeBaseImageData(RPX_berettaImage)
{
	shapeFile = "./dts/beretta_image.dts";
	emap = true;

	mountPoint = 0;
	offset = "0 0.1 0";
	eyeOffset = 0;
	rotation = eulerToMatrix( "0 0 0" );

	correctMuzzleVector = true;

	className = "WeaponImage";

	item = RPX_berettaItem;
	ammo = " ";

	casing = AE_BEPistolShellDebris;
	shellExitDir        = "1 0 0.5";
	shellExitOffset     = "0 0 0";
	shellExitVariance   = 25;	
	shellVelocity       = 5.0;

	hideHands = true;
	armReady = true;

	doColorShift = true;
	colorShiftColor = RPX_berettaItem.colorShiftColor;

	shellSound = AEShellSMG;
	shellSoundMin = 600;
	shellSoundMax = 700;

	muzzleFlashScale = "1 1 1";

	bulletScale = "1 1 1";
	projectile = AETrailedProjectile;
	projectileType = Projectile;
	projectileDamage = 17;
	projectileCount = 1;
	projectileHeadshotMult = 1.35;
	projectileVelocity = 200;
	projectileTagStrength = 0.35;
	projectileTagRecovery = 0.03;

	useNewSpread = true;

	recoilHeight = 90;
	recoilWidth = 20;
	recoilHeightMax = 2000;
	recoilWidthMax = 200;

	spreadBurst = 2;
	spreadBase = 100;
	spreadReset = 300;
	spreadMin = 100;
	spreadAdd = 30;
	spreadMax = 300;

	screenshakeMin = "0.02 0.02 0.02";
	screenshakeMax = "0.2 0.2 0.2";
	farShotSound = RPX_PistolDistFireSound;
	farShotDistance = 40;

	sonicWhizz = true;
	whizzSupersonic = false;
	whizzThrough = false;
	whizzDistance = 10;
	whizzChance = 100;
	whizzAngle = 80;

	projectileFalloffStart = $ae_falloffPistolStart;
	projectileFalloffEnd = $ae_falloffPistolEnd;
	projectileFalloffDamage = $ae_falloffPistol;

	stateName[0]                     	= "Activate";
	stateTimeoutValue[0]             	= 0.3;
	stateTransitionOnTimeout[0]       	= "LoadCheckA";
	stateSequence[0]			= "unholster";
	stateSound[0]         = RPX_SMGUnholsterSound;

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
	stateEmitter[2]					= AEBaseGenericFlashEmitter;
	stateEmitterTime[2]				= 0.05;
	stateEmitterNode[2]				= "muzzlePoint";
	stateFire[2]                       = true;
	stateEjectShell[2]                       = true;

	stateName[3]                    = "Fire";
	stateTransitionOnTimeout[3]     = "SemiAutoCheck";
	stateEmitter[3]					= AEBaseSmokeEmitter;
	stateEmitterTime[3]				= 0.05;
	stateEmitterNode[3]				= "muzzlePoint";
	stateAllowImageChange[3]        = false;
	stateSequence[3]                = "Fire";
	stateWaitForTimeout[3]			= true;
	
	stateName[6]                    = "FireEmpty";
	stateTransitionOnTimeout[6]     = "SemiAutoCheck";
	stateEmitter[6]					= AEBaseSmokeEmitter;
	stateEmitterTime[6]				= 0.05;
	stateEmitterNode[6]				= "muzzlePoint";
	stateAllowImageChange[6]        = false;
	stateSequence[6]                = "FireEmpty";
	stateWaitForTimeout[6]			= true;
	
	stateName[4]				= "FireLoadCheckA";
	stateScript[4]				= "AEMagLoadCheck";
	stateTimeoutValue[4]			= 0.066;
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
	stateTimeoutValue[16]			= 0.4;
	stateScript[16]				= "onReloadStart";
	stateTransitionOnTimeout[16]		= "Reload";
	stateWaitForTimeout[16]			= true;
	stateSequence[16]			= "ReloadStart";
	
	stateName[17]				= "Reload";
	stateTimeoutValue[17]			= 1.2;
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
	stateTimeoutValue[21]			= 0.2;
	stateScript[21]				= "onReload2Start";
	stateTransitionOnTimeout[21]		= "Reload2";
	stateWaitForTimeout[21]			= true;
	stateSequence[21]			= "ReloadStartEmpty";

	stateName[22]				= "Reload2";
	stateTimeoutValue[22]			= 1.6;
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
	stateTransitionOnTimeout[30] = "FireEmpty";
	stateEmitter[30]					= AEBaseGenericFlashEmitter;
	stateEmitterTime[30]				= 0.05;
	stateEmitterNode[30]				= "muzzlePoint";
};

function RPX_berettaImage::AEOnFire(%this,%obj,%slot)
{
	%obj.blockImageDismount = true;
	%obj.schedule(400, unBlockImageDismount);

	cancel(%obj.reloadSoundSchedule);
	%obj.stopAudio(0); 
	%obj.playAudio(0, RPX_berettaFire @ getRandom(1, 3) @ Sound);	

	Parent::AEOnFire(%this, %obj, %slot);
}

function RPX_berettaImage::onReloadStart(%this, %obj, %slot)
{
	%obj.reload0Schedule = %obj.schedule(150, stopAudio, 2);
	%obj.reload1Schedule = %obj.schedule(150, playAudio, 2, RPX_berettaReloadMagOutSound);
}

function RPX_berettaImage::onReload(%this, %obj, %slot)
{
	%obj.reload2Schedule = %obj.schedule(400, stopAudio, 1);
	%obj.reload3Schedule = %obj.schedule(400, playAudio, 1, RPX_berettaReloadMagInSound);

	%this.onMagDrop(%obj,%slot);
	%obj.reload4Schedule = schedule(getRandom(300,400),0,serverPlay3D,AEMagPistol @ getRandom(1,3) @ Sound,%obj.getPosition());
}

function RPX_berettaImage::onReload2Start(%this, %obj, %slot)
{
	%obj.reload0Schedule = %obj.schedule(200, stopAudio, 2);
	%obj.reload1Schedule = %obj.schedule(200, playAudio, 2, RPX_berettaReloadMagOutSound);
}

function RPX_berettaImage::onReload2(%this, %obj, %slot)
{
	%obj.reload2Schedule = %obj.schedule(400, stopAudio, 1);
	%obj.reload3Schedule = %obj.schedule(400, playAudio, 1, RPX_berettaReloadMagInSound);

	%obj.reload0Schedule = %obj.schedule(900, stopAudio, 2);
	%obj.reload1Schedule = %obj.schedule(900, playAudio, 2, RPX_berettaReloadEndEmptySound);
	
	%this.onMagDrop(%obj,%slot, 1);
	%obj.reload4Schedule = schedule(getRandom(300,400),0,serverPlay3D,AEMagPistol @ getRandom(1,3) @ Sound,%obj.getPosition());
}

function RPX_berettaImage::onDryFire(%this, %obj, %slot)
{
	%obj.aeplayThread(2, plant);
	serverPlay3D(AEDryFireSound, %obj.getHackPosition());
}

function RPX_berettaImage::onReady(%this,%obj,%slot)
{
	if(getSimTime() - %obj.reloadTime[%this.getID()] <= %this.stateTimeoutValue[0] * 1000 + 1000)
		%obj.schedule(0, setImageAmmo, %slot, 0);
	
	%obj.baadDisplayAmmo(%this);
	%this.AEPreLoadAmmoReserveCheck(%obj, %slot);
	%this.AEPreAmmoCheck(%obj, %slot);
}

function RPX_berettaImage::onMount(%this,%obj,%slot)
{
	%this.AEMountSetup(%obj, %slot);
	parent::onMount(%this,%obj,%slot);
}

function RPX_berettaImage::onUnMount(%this, %obj, %slot)
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

function RPX_berettaImage::onMagDrop(%this,%obj,%slot, %empty)
{
	%a = new Camera()
	{
		datablock = Observer;
		position = %obj.getPosition();
		scale = "1 1 1";
	};

	%a.setTransform(%obj.getSlotTransform(0));
	if(%empty)
		%a.mountImage(RPX_berettaMagEmptyImage,0);
	else
		%a.mountImage(RPX_berettaMagImage,0);
	%a.schedule(2500,delete);
}

datablock ShapeBaseImageData(RPX_berettaMagImage)
{
	shapeFile = "base/data/shapes/empty.dts";
	mountPoint = 0;
	offset = "-1.17 0.43 -0.38";
	rotation = eulerToMatrix( "90 180 0" );
	
	casing = RPX_berettaMagDebris;
	shellExitDir        = "1.0 0 -0.2";
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

function RPX_berettaMagImage::onDone(%this,%obj,%slot)
{
	%obj.unMountImage(%slot);
}

datablock ShapeBaseImageData(RPX_berettaMagEmptyImage)
{
	shapeFile = "base/data/shapes/empty.dts";
	mountPoint = 0;
	offset = "-0.03 0.15 0.03";
	rotation = eulerToMatrix( "0 80 0" );
	
	casing = RPX_berettaMagDebris;
	shellExitDir        = "0.1 -0.1 -1.0";
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

function RPX_berettaMagEmptyImage::onDone(%this,%obj,%slot)
{
	%obj.unMountImage(%slot);
}