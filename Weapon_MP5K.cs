datablock AudioProfile(RPX_MP5KFire1Sound)
{
	filename    = "./wav/mp5k_fire1.wav";
	description = HeavyClose3D;
	preload = true;
};

datablock AudioProfile(RPX_MP5KFire2Sound)
{
	filename    = "./wav/mp5k_fire2.wav";
	description = HeavyClose3D;
	preload = true;
};

datablock AudioProfile(RPX_MP5KFire3Sound)
{
	filename    = "./wav/mp5k_fire3.wav";
	description = HeavyClose3D;
	preload = true;
};

datablock AudioProfile(RPX_MP5ReloadStartEmptySound)
{
	filename    = "./wav/MP5_reload_lock.wav";
	description = AudioClosest3D;
	preload = true;
};

datablock AudioProfile(RPX_MP5ReloadMagOutSound)
{
	filename    = "./wav/MP5_reload_magout.wav";
	description = AudioClosest3D;
	preload = true;
};

datablock AudioProfile(RPX_MP5ReloadMagInSound)
{
	filename    = "./wav/MP5_reload_magin.wav";
	description = AudioClosest3D;
	preload = true;
};

datablock AudioProfile(RPX_MP5ReloadTapSound)
{
	filename    = "./wav/MP5_reload_tap.wav";
	description = AudioClosest3D;
	preload = true;
};

datablock AudioProfile(RPX_MP5ReloadEndEmptySound)
{
	filename    = "./wav/MP5_reload_slap.wav";
	description = AudioClosest3D;
	preload = true;
};

datablock DebrisData(RPX_MP5KMagDebris)
{
	shapeFile = "./dts/mp5k_mag.dts";
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

datablock ItemData(RPX_MP5KItem)
{
	category = "Weapon";
	className = "Weapon";

	shapeFile = "./dts/MP5K_item.dts";
	rotate = false;
	mass = 1;
	density = 0.2;
	elasticity = 0.2;
	friction = 0.6;
	emap = true;

	uiName = "RPX: MP5K";
	iconName = "./icon/mp5k";
	doColorShift = true;
	colorShiftColor = "0.75 0.75 0.75 1";

	image = RPX_MP5KImage;
	canDrop = true;
	
	AEAmmo = 30;
	AEType = AE_LightPAmmoItem.getID(); 
	AEBase = 1;

	RPM = 312;
	Recoil = "Light";
	uiColor = "1 1 1";
	description = "";

	useImpactSounds = true;
	softImpactThreshold = 2;
	softImpactSound = "AEWepImpactSoft1Sound AEWepImpactSoft2Sound AEWepImpactSoft3Sound";
	hardImpactThreshold = 8;
	hardImpactSound = "AEWepImpactHard1Sound AEWepImpactHard2Sound AEWepImpactHard3Sound";
};

datablock ShapeBaseImageData(RPX_MP5KImage)
{
	shapeFile = "./dts/MP5K_image.dts";
	emap = true;

	mountPoint = 0;
	offset = "0 0 0";
	eyeOffset = 0;
	rotation = eulerToMatrix( "0 0 0" );

	correctMuzzleVector = true;

	className = "WeaponImage";

	item = RPX_MP5KItem;
	ammo = " ";

	casing = AE_BEPistolShellDebris;
	shellExitDir        = "1 0 0.5";
	shellExitOffset     = "0 0 0";
	shellExitVariance   = 25;	
	shellVelocity       = 5.0;

	hideHands = true;
	armReady = true;

	doColorShift = true;
	colorShiftColor = RPX_MP5KItem.colorShiftColor;

	shellSound = AEShellSMG;
	shellSoundMin = 600;
	shellSoundMax = 700;

	muzzleFlashScale = "1 1 1";

	bulletScale = "1 1 1";
	projectile = AETrailedProjectile;
	projectileType = Projectile;
	projectileDamage = 19;
	projectileCount = 1;
	projectileHeadshotMult = 1.2;
	projectileVelocity = 200;
	projectileTagStrength = 0.35;
	projectileTagRecovery = 0.03;

	useNewSpread = true;

	recoilHeight = 85;
	recoilWidth = 25;
	recoilHeightMax = 1500;
	recoilWidthMax = 300;

	spreadBurst = 2;
	spreadBase = 100;
	spreadReset = 200;
	spreadMin = 120;
	spreadAdd = 30;
	spreadMax = 1000;

	screenshakeMin = "0.02 0.02 0.02";
	screenshakeMax = "0.2 0.2 0.2";
	farShotSound = RPX_SMGDistFireSound;
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
	stateTimeoutValue[0]             	= 0.4;
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
	stateScript[2]                     = "AEOnFire";
	stateEmitter[2]					= AEBaseGenericFlashEmitter;
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
	stateTimeoutValue[21]			= 0.7;
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
};

function RPX_MP5KImage::AEOnFire(%this,%obj,%slot)
{
	%obj.blockImageDismount = true;
	%obj.schedule(400, unBlockImageDismount);

	cancel(%obj.reloadSoundSchedule);
	%obj.stopAudio(0); 
	%obj.playAudio(0, RPX_MP5KFire @ getRandom(1, 3) @ Sound);	

	Parent::AEOnFire(%this, %obj, %slot);
}

function RPX_MP5KImage::onReloadStart(%this, %obj, %slot)
{
	%obj.reload2Schedule = %obj.schedule(300, stopAudio, 2);
	%obj.reload3Schedule = %obj.schedule(300, playAudio, 2, RPX_MP5ReloadMagOutSound);
}

function RPX_MP5KImage::onReload(%this, %obj, %slot)
{	
	%obj.reload0Schedule = %obj.schedule(600, stopAudio, 1);
	%obj.reload1Schedule = %obj.schedule(600, playAudio, 1, RPX_MP5ReloadMagInSound);

	%this.onMagDrop(%obj,%slot);
	%obj.reload4Schedule = schedule(getRandom(300,400),0,serverPlay3D,AEMagMetalAR @ getRandom(1,3) @ Sound,%obj.getPosition());
}

function RPX_MP5KImage::onReload2Start(%this, %obj, %slot)
{
	%obj.reload0Schedule = %obj.schedule(150, stopAudio, 1);
	%obj.reload1Schedule = %obj.schedule(150, playAudio, 1, RPX_MP5ReloadStartEmptySound);
}

function RPX_MP5KImage::onReload2(%this, %obj, %slot)
{	
	%obj.stopAudio(2);
	%obj.playAudio(2, RPX_MP5ReloadMagOutSound);
	
	%obj.reload0Schedule = %obj.schedule(450, stopAudio, 1);
	%obj.reload1Schedule = %obj.schedule(450, playAudio, 1, RPX_MP5ReloadMagInSound);

	%obj.reload5Schedule = %obj.schedule(800, stopAudio, 3);
	%obj.reload6Schedule = %obj.schedule(800, playAudio, 3, RPX_MP5ReloadTapSound);
	
	%obj.reload2Schedule = %obj.schedule(1100, stopAudio, 2);
	%obj.reload3Schedule = %obj.schedule(1100, playAudio, 2, RPX_MP5ReloadEndEmptySound);
	
	%this.onMagDrop(%obj,%slot, 1);
	%obj.reload4Schedule = schedule(getRandom(300,400),0,serverPlay3D,AEMagMetalAR @ getRandom(1,3) @ Sound,%obj.getPosition());
}

function RPX_MP5KImage::onDryFire(%this, %obj, %slot)
{
	%obj.aeplayThread(2, plant);
	serverPlay3D(AEDryFireSound, %obj.getHackPosition());
}

function RPX_MP5KImage::onReady(%this,%obj,%slot)
{
	if(getSimTime() - %obj.reloadTime[%this.getID()] <= %this.stateTimeoutValue[0] * 1000 + 1000)
		%obj.schedule(0, setImageAmmo, %slot, 0);
	
	%obj.baadDisplayAmmo(%this);
	%this.AEPreLoadAmmoReserveCheck(%obj, %slot);
	%this.AEPreAmmoCheck(%obj, %slot);
}

function RPX_MP5KImage::onMount(%this,%obj,%slot)
{
	%this.AEMountSetup(%obj, %slot);
	parent::onMount(%this,%obj,%slot);
}

function RPX_MP5KImage::onUnMount(%this, %obj, %slot)
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

function RPX_MP5KImage::onMagDrop(%this,%obj,%slot, %empty)
{
	%a = new Camera()
	{
		datablock = Observer;
		position = %obj.getPosition();
		scale = "1 1 1";
	};

	%a.setTransform(%obj.getSlotTransform(0));
	if(%empty)
		%a.mountImage(RPX_MP5KMagEmptyImage,0);
	else
		%a.mountImage(RPX_MP5KMagImage,0);
	%a.schedule(2500,delete);
}

datablock ShapeBaseImageData(RPX_MP5KMagImage)
{
	shapeFile = "base/data/shapes/empty.dts";
	mountPoint = 0;
	offset = "-0.94 0.25 -0.47";
	rotation = eulerToMatrix( "0 50 0" );
	
	casing = RPX_MP5KMagDebris;
	shellExitDir        = "-1 0 -1";
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

function RPX_MP5KMagImage::onDone(%this,%obj,%slot)
{
	%obj.unMountImage(%slot);
}

datablock ShapeBaseImageData(RPX_MP5KMagEmptyImage)
{
	shapeFile = "base/data/shapes/empty.dts";
	mountPoint = 0;
	offset = "-0.34 0.55 -0.17";
	rotation = eulerToMatrix( "0 35 0" );
	
	casing = RPX_MP5KMagDebris;
	shellExitDir        = "-0.5 1 -0.5";
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

function RPX_MP5KMagEmptyImage::onDone(%this,%obj,%slot)
{
	%obj.unMountImage(%slot);
}