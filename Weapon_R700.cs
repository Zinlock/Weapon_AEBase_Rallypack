datablock AudioProfile(RPX_R700Fire1Sound)
{
	filename    = "./wav/R700_fire1.wav";
	description = HeavyClose3D;
	preload = true;
};

datablock AudioProfile(RPX_R700Fire2Sound)
{
	filename    = "./wav/R700_fire2.wav";
	description = HeavyClose3D;
	preload = true;
};

datablock AudioProfile(RPX_R700Fire3Sound)
{
	filename    = "./wav/R700_fire3.wav";
	description = HeavyClose3D;
	preload = true;
};

datablock AudioProfile(RPX_R700ReloadMagOutSound)
{
	filename    = "./wav/R700_reload_magout.wav";
	description = AudioClosest3D;
	preload = true;
};

datablock AudioProfile(RPX_R700ReloadMagInSound)
{
	filename    = "./wav/R700_reload_magin.wav";
	description = AudioClosest3D;
	preload = true;
};

datablock AudioProfile(RPX_R700BoltBackSound)
{
	filename    = "./wav/R700_bolt_back.wav";
	description = AudioClosest3D;
	preload = true;
};

datablock AudioProfile(RPX_R700BoltForwardSound)
{
	filename    = "./wav/R700_bolt_forward.wav";
	description = AudioClosest3D;
	preload = true;
};

datablock DebrisData(RPX_R700MagDebris)
{
	shapeFile = "./dts/R700_mag.dts";
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

datablock ItemData(RPX_R700Item)
{
	category = "Weapon";
	className = "Weapon";

	shapeFile = "./dts/R700_item.dts";
	rotate = false;
	mass = 1;
	density = 0.2;
	elasticity = 0.2;
	friction = 0.6;
	emap = true;

	uiName = "RPX: Remington 700";
	iconName = "./icon/r700";
	doColorShift = true;
	colorShiftColor = "1 1 1 1";

	image = RPX_R700EquipImage;
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

datablock ShapeBaseImageData(RPX_R700Image)
{
	shapeFile = "./dts/R700_image.dts";
	emap = true;

	mountPoint = 0;
	offset = "0 0.2 0";
	eyeOffset = 0;
	rotation = eulerToMatrix( "0 0 0" );

	correctMuzzleVector = true;

	className = "WeaponImage";

	item = RPX_R700Item;
	ammo = " ";

	casing = AE_BERifleShellDebris;
	shellExitDir        = "1 0 0.5";
	shellExitOffset     = "0 0 0";
	shellExitVariance   = 25;	
	shellVelocity       = 5.0;

	hideHands = true;
	armReady = true;

	doColorShift = true;
	colorShiftColor = RPX_R700Item.colorShiftColor;

	isScopedImage = true;
	scopingImage = RPX_R700ScopeImage;

	muzzleFlashScale = "1 1 1";

	bulletScale = "1 1 1";
	projectile = AETrailedProjectile;
	projectileType = Projectile;
	projectileDamage = 60;
	projectileCount = 1;
	projectileHeadshotMult = 2.2;
	projectileVelocity = 200;
	projectileTagStrength = 0.35;
	projectileTagRecovery = 0.03;

	useNewSpread = true;

	recoilHeight = 120;
	recoilWidth = 40;
	recoilHeightMax = 2000;
	recoilWidthMax = 500;

	spreadBurst = 1;
	spreadBase = 500;
	spreadReset = 700;
	spreadMin = 500;
	spreadAdd = 50;
	spreadMax = 2000;

	screenshakeMin = "0.05 0.05 0.05";
	screenshakeMax = "0.2 0.2 0.2";
	farShotSound = RPX_SniperDistFireSound;
	farShotDistance = 40;

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
	staticTracerEffect = "";
	staticScaleCalibre = 0.5;
	staticScaleLength = 0.5;
	staticUnitsPerSecond = $RPX_SR_BulletSpeed;

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
	stateEmitter[2]					= AEBaseShotgunFlashEmitter;
	stateEmitterTime[2]				= 0.05;
	stateEmitterNode[2]				= "muzzlePoint";
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
	stateTimeoutValue[4]			= 0.4;
	stateTransitionOnTimeout[4]		= "FireLoadCheckB";
	
	stateName[5]				= "FireLoadCheckB";
	stateTransitionOnAmmo[5]		= "Bolt";
	stateTransitionOnNoAmmo[5]		= "Reload2Start";
	stateTransitionOnNotLoaded[5]  = "Bolt";

	stateName[7]                  = "Bolt";
	stateTimeoutValue[7]          = 0.9;
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
	stateEmitter[30]					= AEBaseShotgunFlashEmitter;
	stateEmitterTime[30]				= 0.05;
	stateEmitterNode[30]				= "muzzlePoint";
};

function RPX_R700Image::AEOnFire(%this,%obj,%slot)
{
	%obj.blockImageDismount = true;
	%obj.schedule(400, unBlockImageDismount);

	cancel(%obj.reloadSoundSchedule);
	%obj.stopAudio(0); 
	%obj.playAudio(0, RPX_R700Fire @ getRandom(1, 3) @ Sound);	

	%obj.aeplayThread(2, plant);

	Parent::AEOnFire(%this, %obj, %slot);
}

function RPX_R700Image::onBolt(%this, %obj, %slot)
{
	schedule(getRandom(500,600),0,serverPlay3D,AEShellSniper @ getRandom(1,3) @ Sound,%obj.getPosition());

	%obj.stopAudio(2);
	%obj.playAudio(2, RPX_R700BoltBackSound);

	%obj.reload2Schedule = %obj.schedule(400, stopAudio, 1);
	%obj.reload3Schedule = %obj.schedule(400, playAudio, 1, RPX_R700BoltForwardSound);
}

function RPX_R700Image::onReloadStart(%this, %obj, %slot)
{
	%obj.reload0Schedule = %obj.schedule(100, stopAudio, 2);
	%obj.reload1Schedule = %obj.schedule(100, playAudio, 2, RPX_R700ReloadMagOutSound);
}

function RPX_R700Image::onReload(%this, %obj, %slot)
{
	%obj.reload2Schedule = %obj.schedule(200, stopAudio, 1);
	%obj.reload3Schedule = %obj.schedule(200, playAudio, 1, RPX_R700ReloadMagInSound);

	%this.onMagDrop(%obj,%slot);
	%obj.reload4Schedule = schedule(getRandom(300,400),0,serverPlay3D,AEMagMetalAR @ getRandom(1,3) @ Sound,%obj.getPosition());
}

function RPX_R700Image::onReload2Start(%this, %obj, %slot)
{
	%obj.reload0Schedule = %obj.schedule(100, stopAudio, 2);
	%obj.reload1Schedule = %obj.schedule(100, playAudio, 2, RPX_R700BoltBackSound);
	
	%obj.reload5Schedule = %obj.schedule(500, stopAudio, 1);
	%obj.reload6Schedule = %obj.schedule(500, playAudio, 1, RPX_R700ReloadMagOutSound);
}

function RPX_R700Image::onReload2(%this, %obj, %slot)
{
	%obj.reload2Schedule = %obj.schedule(400, stopAudio, 2);
	%obj.reload3Schedule = %obj.schedule(400, playAudio, 2, RPX_R700ReloadMagInSound);

	%obj.reload0Schedule = %obj.schedule(1200, stopAudio, 1);
	%obj.reload1Schedule = %obj.schedule(1200, playAudio, 1, RPX_R700BoltForwardSound);
	
	%this.onMagDrop(%obj,%slot);
	%obj.reload4Schedule = schedule(getRandom(300,400),0,serverPlay3D,AEMagMetalAR @ getRandom(1,3) @ Sound,%obj.getPosition());
}

function RPX_R700Image::onDryFire(%this, %obj, %slot)
{
	%obj.aeplayThread(2, plant);
	serverPlay3D(AEDryFireSound, %obj.getHackPosition());
}

function RPX_R700Image::onReady(%this,%obj,%slot)
{
	if(getSimTime() - %obj.reloadTime[%this.getID()] <= %this.stateTimeoutValue[0] * 1000 + 1000)
		%obj.schedule(0, setImageAmmo, %slot, 0);
	
	%obj.baadDisplayAmmo(%this);
	%this.AEPreLoadAmmoReserveCheck(%obj, %slot);
	%this.AEPreAmmoCheck(%obj, %slot);
}

function RPX_R700Image::onMount(%this,%obj,%slot)
{
	%this.AEMountSetup(%obj, %slot);
	parent::onMount(%this,%obj,%slot);
}

function RPX_R700Image::onUnMount(%this, %obj, %slot)
{	
	%this.AEUnmountCleanup(%obj, %slot);

	cancel(%obj.reload0Schedule);
	cancel(%obj.reload1Schedule);
	cancel(%obj.reload2Schedule);
	cancel(%obj.reload3Schedule);
	cancel(%obj.reload4Schedule);
	parent::onUnMount(%this,%obj,%slot);	
}

function RPX_R700Image::onMagDrop(%this,%obj,%slot)
{
	%a = new Camera()
	{
		datablock = Observer;
		position = %obj.getPosition();
		scale = "1 1 1";
	};

	%a.setTransform(%obj.getSlotTransform(0));
	%a.mountImage(RPX_R700MagImage,0);
	%a.schedule(2500,delete);
}

datablock ShapeBaseImageData(RPX_R700MagImage)
{
	shapeFile = "base/data/shapes/empty.dts";
	mountPoint = 0;
	offset = "-0.06 0.75 -0.10";
	rotation = eulerToMatrix( "0 33 0" );
	
	casing = RPX_R700MagDebris;
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

function RPX_R700MagImage::onDone(%this,%obj,%slot)
{
	%obj.unMountImage(%slot);
}

RPXGenerateADSImage(RPX_R700ScopeImage, RPX_R700Image,
                    "0 0.6 -0.61", eulerToMatrix("0 -30 0"), // eye offset, rotation
										$ae_MedScopeFOV, 0, // fov, projectile z offset
										16, 21, // reload start 1 and 2 state ids
										"R_MovePenalty = 0.5;" NL
										"stateTimeoutValue[0] = 0.3;" NL
										"stateSequence[0] = \"scopeIn\";" NL
										"stateSequence[7] = \"boltScoped\";", // extra fields
										AEAdsIn1Sound, AEAdsOut1Sound, // ADS in, out sound
										0.25, 0.25, // recoil mult X, Z
										0.25, 0.25, // recoil mult max X, Z
										0.01); // spread mult

RPXGenerateEquipImage(RPX_R700EquipImage, RPX_R700Image, 0.4, "unholster", RPX_RifleUnholsterSound);